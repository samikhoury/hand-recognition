using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;

namespace MLDMProject
{
    [Serializable]
    public class RFClassifier
    {
        public List<DecisionTree> trees { get; set; }
        public List<C45Learning> teachers { get; set; }
        public int numbOfTrees { get; set; }
        public double error { get; set; }
        public Dictionary<string, ConfusionMatrixElement> cm { get; set; }

        public RFClassifier(int input, int output, int numberOfTrees)
        {
            this.numbOfTrees = numberOfTrees;
            DecisionVariable[] variables = new DecisionVariable[input];
            for (int i = 0; i < input; i++)
                variables[i] = new DecisionVariable(i.ToString(), DecisionVariableKind.Continuous);
            this.trees = new List<DecisionTree>();
            this.teachers = new List<C45Learning>();
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
            for (int i = 0; i < this.numbOfTrees; i++)
            {
                DecisionTree tree = new DecisionTree(variables, output);
                C45Learning teacher = new C45Learning(tree);
                this.trees.Add(tree);
                this.teachers.Add(teacher);
            }
            this.error = 0;
        }

        public void Train(List<Observation> observations, double percentage, bool forTest = false)
        {
            for (int i = 0; i < this.numbOfTrees; i++)
            {
                List<int> randomSubset = new List<int>();
                Utility.GenerateRandomSubset(observations.Count, percentage, randomSubset);
                List<Observation> trainingElements = Utility.Split(observations, randomSubset);
                double[][] inputs = Utility.toDoubleArrayEFDBased(trainingElements);
                int[] outputs = Utility.labelsToIntArray(trainingElements);
                this.teachers[i].Run(inputs, outputs);
            }
            if (!forTest)
            {
                double hit = 0;
                foreach (Observation o in observations)
                    if (Classify(o).Equals(o.label))
                        hit++;
                this.error = 1 - (hit / observations.Count);
            }
        }

        public string Classify(Observation newObsrv)
        {
            Dictionary<string, int> majVote = new Dictionary<string, int>();
            for (int i = 0; i < this.numbOfTrees; i++)
            {
                Func<double[], int> treeRules = this.trees[i].ToExpression().Compile();
                string test = treeRules(newObsrv.efd).ToString();
                if (majVote.ContainsKey(test))
                    majVote[test]++;
                else
                    majVote.Add(test, 1);
            }
            majVote = majVote.OrderByDescending(s => s.Value).ToDictionary(s => s.Key, s => s.Value);
            return majVote.First().Key;
        }

        public string RandomCrossValidation(int repetition, List<Observation> observations, double percentage, double ssPer)
        {
            StringBuilder builder = new StringBuilder();
            double accuracy = 0;
            for (int i = 0; i < repetition; i++)
            {
                double temp = OneRandomFoldCrossValidation(observations, percentage, ssPer);
                accuracy += temp;
                builder.Append("Random fold #" + (i + 1) + " accuracy rate: " + temp + "%" + Environment.NewLine);
            }
            accuracy /= repetition;
            builder.Append("Accuracy rate after " + repetition + " random folds: " + accuracy + "%" + Environment.NewLine);
            return builder.ToString();
        }

        public double OneRandomFoldCrossValidation(List<Observation> observations, double percentage, double ssPer)
        {
            List<int> training = new List<int>();
            List<int> validation = new List<int>();
            Utility.GenerateRandomFold(observations.Count, percentage, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            Train(trainingElements, ssPer, true);
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

        public string KFoldCrossValidation(List<Observation> observations, int numFolds, double ssPer)
        {
            StringBuilder builder = new StringBuilder();
            double accuracy = 0;
            for (int i = 1; i <= numFolds; i++)
            {
                double temp = OneFoldCrossValidation(observations, numFolds, i, ssPer);
                accuracy += temp;
                builder.Append("Fold #" + i + " accuracy rate: " + temp + "%" + Environment.NewLine);
            }
            accuracy /= numFolds;
            builder.Append("Accuracy rate after " + numFolds + " folds: " + accuracy + "%" + Environment.NewLine);
            return builder.ToString();
        }

        public double OneFoldCrossValidation(List<Observation> observations, int numFolds, int foldIndex, double ssPer)
        {
            List<int> training = new List<int>();
            List<int> validation = new List<int>();
            Utility.GenerateFold(observations.Count, numFolds, foldIndex, training, validation);
            List<Observation> trainingElements = Utility.Split(observations, training);
            int hits = 0;
            Train(trainingElements, ssPer, true);
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
