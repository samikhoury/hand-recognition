using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public class KNNClassifier
    {
        public byte k { get; set; }
        public Dictionary<string, ConfusionMatrixElement> cm { get; set; }

        public KNNClassifier()
        {
            this.k = 1;
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public KNNClassifier(byte k)
        {
            this.k = k;
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public Int32 levenshtein(String a, String b)
        {

            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }

        public string k_NN(string newObsrvFreemancode, List<Observation> observations)
        {
            string label = "";
            Int32 miniDist = Int32.MaxValue;

            if (k == 1)
                foreach (Observation observ in observations)
                {
                    Int32 editDist = levenshtein(observ.freemanCode, newObsrvFreemancode);
                    if (editDist < miniDist)
                    {
                        miniDist = editDist;
                        label = observ.label;
                    }
                }
            else
            {
                List<kNNElement> k_NNDistances = new List<kNNElement>();
                foreach (Observation observ in observations)
                {
                    Int32 editDist = levenshtein(observ.freemanCode, newObsrvFreemancode);
                    k_NNDistances.Add(new kNNElement(observ.label, editDist));
                }
                List<string> labels = k_NNDistances.OrderBy(ob => ob.value).Take(k).Select(ob => ob.key).ToList();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (string l in labels)
                {
                    if (dict.ContainsKey(l))
                        dict[l] += 1;
                    else
                        dict.Add(l, 1);
                }
                label = dict.OrderByDescending(s => s.Value).First().Key;
            }

            return label;
        }

        public string RandomCrossValidation(int repetition, List<Observation> observations, double percentage)
        {
            StringBuilder builder = new StringBuilder();
            double accuracy = 0;
            for (int i = 0; i < repetition; i++)
            {
                double temp = OneRandomFoldCrossValidation(observations, percentage);
                accuracy += temp;
                builder.Append("Random fold #" + (i + 1) + " accuracy rate: " + temp + "%\n");
            }
            accuracy /= repetition;
            builder.Append("Accuracy rate after " + repetition + " random folds: " + accuracy + "%\n");
            return builder.ToString();
        }

        public double OneRandomFoldCrossValidation(List<Observation> observations, double percentage)
        {
            List<int> training = new List<int>();
            List<int> validation = new List<int>();
            Utility.GenerateRandomFold(observations.Count, percentage, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            for (int i = 0; i < validation.Count; i++)
            {
                Observation temp = observations[validation[i]];
                string label = k_NN(temp.freemanCode, trainingElements);
                if (temp.label.Equals(label))
                {
                    hits++;
                    this.cm[temp.label].positive++;
                }
                else
                {
                    this.cm[temp.label].negative++;
                    this.cm[temp.label].misclassified[label]++;
                }
                this.cm[temp.label].numb_of_examples++;
            }
            double accuracy = (double)hits / (double)validation.Count;
            accuracy *= 100;
            return accuracy;
        }

        public string KFoldCrossValidation(List<Observation> observations, int numFolds)
        {
            StringBuilder builder = new StringBuilder();
            double accuracy = 0;
            for (int i = 1; i <= numFolds; i++)
            {
                double temp = OneFoldCrossValidation(observations, numFolds, i);
                accuracy += temp;
                builder.Append("Fold #" + i + " accuracy rate: " + temp + "%" + Environment.NewLine);
            }
            accuracy /= numFolds;
            builder.Append("Accuracy rate after " + numFolds + " folds: " + accuracy + "%" + Environment.NewLine);
            return builder.ToString();
        }

        public double OneFoldCrossValidation(List<Observation> observations, int numFolds, int foldIndex)
        {
            List<int> training = new List<int>();
            List<int> validation = new List<int>();
            Utility.GenerateFold(observations.Count,numFolds, foldIndex, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            for (int i = 0; i < validation.Count; i++)
            {
                Observation temp = observations[validation[i]];
                string label = k_NN(temp.freemanCode, trainingElements);
                if (temp.label.Equals(label))
                {
                    hits++;
                    this.cm[temp.label].positive++;
                }
                else
                {
                    this.cm[temp.label].negative++;
                    this.cm[temp.label].misclassified[label]++;
                }
                this.cm[temp.label].numb_of_examples++;
            }
            double accuracy = (double)hits / (double)validation.Count;
            accuracy *= 100;
            return accuracy;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("\t");
            for (int i = 0; i < 10; i++)
                builder.Append(String.Format("{0,-10}", i.ToString()));
            builder.Append(String.Format("{0, -3}", "No"));
            builder.Append(Environment.NewLine);
            for (int i = 0; i < 10; i++)
            {
                builder.Append(i.ToString()).Append("\t");
                for (int j = 0; j < 10; j++)
                {
                    if (i.Equals(j))
                        builder.Append(String.Format("{0, -10}", this.cm[i.ToString()].positive));
                    else
                        builder.Append(String.Format("{0, -10}", this.cm[i.ToString()].misclassified[j.ToString()]));
                }
                builder.Append(String.Format("{0, -3}", this.cm[i.ToString()].negative));
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}
