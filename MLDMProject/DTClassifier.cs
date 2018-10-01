using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;

namespace MLDMProject
{
    [Serializable]
    public class DTClassifier : IClassifier
    {

        public DecisionTree tree { get; set; }
        public C45Learning teacher { get; set; }
        public double error { get; set; }
        public Dictionary<string, ConfusionMatrixElement> cm { get; set; }

        public DTClassifier(int input, int output)
        {            
            DecisionVariable[] variables = new DecisionVariable[input];
            for (int i = 0; i < input; i++)
                variables[i] = new DecisionVariable(i.ToString(), DecisionVariableKind.Continuous);
            this.tree = new DecisionTree(variables, output);
            this.teacher = new C45Learning(tree);
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public void Train(List<Observation> observations)
        {
            double[][] inputs = Utility.toDoubleArrayEFDBased(observations);
            int[] outputs = Utility.labelsToIntArray(observations);
            error = teacher.Run(inputs, outputs);
        }

        public string Classify(Observation newObsrv)
        {
            Func<double[], int> treeRules = tree.ToExpression().Compile();
            int test = treeRules(newObsrv.efd);
            return test.ToString();
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
