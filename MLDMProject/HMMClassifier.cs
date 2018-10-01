using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.Math;
using Accord.Statistics.Models.Markov;
using Accord.Statistics.Models.Markov.Learning;
using Accord.Statistics.Models.Markov.Topology;

namespace MLDMProject
{
    [Serializable]
    public class HMMClassifier : IClassifier
    {
        public int intput { get; set; }
        public int output { get; set; }
        public HiddenMarkovClassifier classifier { get; set; }
        public double toleranceRate { get; set; }
        public double error { get; set; }
        public Dictionary<string, ConfusionMatrixElement> cm { get; set; }

        public HMMClassifier(int input, int output, double toleranceRate)
        {
            this.intput = input;
            this.output = output;
            this.toleranceRate = toleranceRate;
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public HMMClassifier(int input, int output)
        {
            this.intput = input;
            this.output = output;
            this.toleranceRate = 0.001;
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public string Classify(Observation newObsrv)
        {
            int[] newInstance = StringToArray(newObsrv.freemanCode);
            string output = classifier.Compute(newInstance).ToString();
            return output;
        }

        public void Train(List<Observation> observations)
        {
            int[][] inputSequences = new int[observations.Count][];
            int[] outputLabels = new int[observations.Count];
            for (int i = 0; i < observations.Count; i++)
            {
                inputSequences[i] = StringToArray(observations[i].freemanCode);
                outputLabels[i] = int.Parse(observations[i].label);
            }

            ITopology forward = new Forward(states: 8);
            classifier = new HiddenMarkovClassifier(classes: 10,
                topology: forward, symbols: 8);

            var teacher = new HiddenMarkovClassifierLearning(classifier,
                modelIndex => new BaumWelchLearning(classifier.Models[modelIndex])
                {
                    Tolerance = this.toleranceRate,
                    Iterations = 0
                });

            error = teacher.Run(inputSequences, outputLabels);
        }

        public int[] StringToArray(string str)
        {
            int[] vector = new int[str.Length];
            int index = 0;
            foreach (char c in str)
                vector[index++] = int.Parse(c.ToString());
            return vector;
        }

        public string RandomCrossValidation(int repetition, List<Observation> observations, double percentage)
        {
            StringBuilder builder = new StringBuilder();
            double accuracy = 0;
            for (int i = 0; i < repetition; i++)
            {
                double temp = OneRandomFoldCrossValidation(observations, percentage);
                accuracy += temp;
                builder.Append("Random fold #" + (i + 1) + " accuracy rate: " + temp + "%" + Environment.NewLine);
            }
            accuracy /= repetition;
            builder.Append("Accuracy rate after " + repetition + " random folds: " + accuracy + "%" + Environment.NewLine);
            return builder.ToString();
        }

        public double OneRandomFoldCrossValidation(List<Observation> observations, double percentage)
        {
            List<int> training = new List<int>();
            List<int> validation = new List<int>();
            Utility.GenerateRandomFold(observations.Count, percentage, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            Train(trainingElements);
            for (int i = 0; i < validation.Count; i++)
            {
                Observation temp = observations[validation[i]];
                string label = Classify(temp);
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
            Utility.GenerateFold(observations.Count, numFolds, foldIndex, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            Train(trainingElements);
            for (int i = 0; i < validation.Count; i++)
            {
                Observation temp = observations[validation[i]];
                string label = Classify(temp);
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
