using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;
using NeuronDotNet.Core.LearningRateFunctions;

namespace MLDMProject
{
    [Serializable]
    public class ANNClassifier : IClassifier
    {
        public BackpropagationNetwork network {get;set;}
        public int inputs { get; set; }
        public int hidden { get; set; }
        public int output { get; set; }
        public double learningRate { get; set; }
        public int epochs { get; set; }
        public Dictionary<string, ConfusionMatrixElement> cm { get; set; }

        //public void toyNeuralNetwork()
        //{
        //    LinearLayer inputLayer = new LinearLayer(4);
        //    LogarithmLayer hiddenLayer = new LogarithmLayer(4);
        //    LogarithmLayer outputLayer = new LogarithmLayer(3);
        //    new BackpropagationConnector(inputLayer, hiddenLayer);
        //    new BackpropagationConnector(hiddenLayer, outputLayer);
        //    network = new BackpropagationNetwork(inputLayer, outputLayer);
        //    network.SetLearningRate(0.01d);
        //    NeuronDotNet.Core.TrainingSet trainingSet = new NeuronDotNet.Core.TrainingSet(4, 3);
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 101, 100, 99, 99 }, new double[3] { 1, 0, 0 }));
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 200, 80, 150, 113 }, new double[3] { 1, 0, 0 }));
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 10, 8, 9, 10 }, new double[3] { 0, 1, 0 }));
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 50, 40, 44, 60 }, new double[3] { 0, 0, 1 }));
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 101, 98, 96, 103 }, new double[3] { 1, 0, 0 }));
        //    trainingSet.Add(new NeuronDotNet.Core.TrainingSample(new double[4] { 55, 53, 39, 59 }, new double[3] { 0, 0, 1 }));
        //    network.Learn(trainingSet, 1000);
        //    double[] output = network.Run(new double[4] { 10, 8, 9, 10 });
        //}

        public ANNClassifier(int inputs, int hidden, int output, double learningRate, int epochs)
        {
            this.inputs = inputs;
            this.hidden = hidden;
            this.output = output;
            this.learningRate = learningRate;
            this.epochs = epochs;
            this.cm = new Dictionary<string, ConfusionMatrixElement>();
            for (int i = 0; i < 10; i++)
                cm.Add(i.ToString(), new ConfusionMatrixElement());
        }

        public void Train(List<Observation> observations)
        {
            LinearLayer inputLayer = new LinearLayer(this.inputs);
            LogarithmLayer hiddenLayer = new LogarithmLayer(this.hidden);
            LogarithmLayer outputLayer = new LogarithmLayer(this.output);
            new BackpropagationConnector(inputLayer, hiddenLayer);
            new BackpropagationConnector(hiddenLayer, outputLayer);
            network = new BackpropagationNetwork(inputLayer, outputLayer);
            network.SetLearningRate(this.learningRate);
            NeuronDotNet.Core.TrainingSet trainingSet = new NeuronDotNet.Core.TrainingSet(this.inputs, this.output);
            foreach (Observation o in observations)
                trainingSet.Add(new NeuronDotNet.Core.TrainingSample(o.efd, Utility.labelToVector(o.label)));
            network.Learn(trainingSet, this.epochs);
        }

        public string Classify(Observation obsrv)
        {
            string label = "";
            double[] outputs = network.Run(obsrv.efd);
            double maxValue = double.MinValue;
            for (int i = 0; i < outputs.Length; i++)
                if (outputs[i] > maxValue)
                {
                    maxValue = outputs[i];
                    label = i.ToString();
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
