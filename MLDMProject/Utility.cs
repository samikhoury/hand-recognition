using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MLDMProject
{
    public class Utility
    {
        public static double[] labelToVector(string label)
        {
            double[] vector = new double[10];
            int lab = int.Parse(label);
            for (int i = 0; i < 10; i++)
                if (i == lab)
                    vector[i] = 1;
                else
                    vector[i] = 0;
            return vector;
        }

        public static double[][] toDoubleArray(List<Observation> observations)
        {
            double [][] results = new double [observations.Count][];
            for (int i = 0; i < observations.Count; i++)
                results[i] = observations[i].freemanHist;
            return results;
        }

        public static double[][] toDoubleArrayEFDBased(List<Observation> observations)
        {
            double[][] results = new double[observations.Count][];
            for (int i = 0; i < observations.Count; i++)
                results[i] = observations[i].efd;
            return results;
        }

        public static double[] labelsToDoubleArray(List<Observation> observations)
        {
            double[] results = new double[observations.Count];
            for (int i = 0; i < observations.Count; i++)
                results[i] = Double.Parse(observations[i].label);
            return results;
        }

        public static int[] labelsToIntArray(List<Observation> observations)
        {
            int[] results = new int[observations.Count];
            for (int i = 0; i < observations.Count; i++)
                results[i] = Int16.Parse(observations[i].label);
            return results;
        }

        public static void UpdateNormHistogram(List<Observation> observations, int maxFrequency)
        {
            foreach (Observation o in observations)
                o.calculHistogram(maxFrequency);
        }

        public static void GenerateRandomFold(int size, double percentage, List<int> training, List<int> validation)
        {
            Random rand = new Random();
            int trainSize = (int )percentage * size / 100;
            int validSize = size - trainSize;
            int index = 0;
            while (index < validSize)
            {
                int randomIndex = rand.Next(0, size);
                if (validation.Contains(randomIndex))
                    continue;
                validation.Add(randomIndex);
                index++;
            }
            for (int i = 0; i < size; i++)
            {
                if (validation.Contains(i))
                    continue;
                training.Add(i);
            }
        }

        public static void GenerateRandomSubset(int size, double percentage, List<int> training)
        {
            Random rand = new Random();
            int trainSize = (int)percentage * size / 100;
            int index = 0;
            while (index < trainSize)
            {
                int randomIndex = rand.Next(0, size);
                if (training.Contains(randomIndex))
                    continue;
                training.Add(randomIndex);
                index++;
            }
        }

        public static void GenerateFold(int size, int fold, int indexFold, List<int> training, List<int> validation)
        {
            int numbelements = size / fold;
            int endIndex = indexFold * numbelements;
            endIndex = endIndex > size ? size : endIndex;
            int startIndex = endIndex - numbelements;
            for (int i = startIndex; i < endIndex; i++)
                validation.Add(i);
            for (int i = 0; i < size; i++)
            {
                if (validation.Contains(i))
                    continue;
                training.Add(i);
            }
        }

        public static List<Observation> Split(List<Observation> observations, List<int> training)
        {
            List<Observation> splited = new List<Observation>();
            for (int i = 0; i < training.Count; i++)
                splited.Add(observations[training[i]]);
            return splited;
        }

        public static void GenerateEFD(Observation newObsrv, int numOfD)
        {
            EllipticFD efd = new EllipticFD(newObsrv.xContour, newObsrv.yContour, numOfD);
            List<double> temp = new List<double>();
            temp.AddRange(efd.ax);
            temp.AddRange(efd.ay);
            temp.AddRange(efd.bx);
            temp.AddRange(efd.by);
            temp.Remove(temp[numOfD * 2]);          //Values are zeros
            temp.Remove(temp[numOfD * 3 - 1]);      //Values are zeros
            newObsrv.efd = temp.ToArray();
            newObsrv.normEFD = efd.efd;
        }

        public static void EFDGenerator(List<Observation> observations, int numOfD)
        {
            foreach (Observation obsrv in observations)
                Utility.GenerateEFD(obsrv, numOfD);
        }
    }
}
