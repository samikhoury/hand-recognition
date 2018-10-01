using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public class WTAClassifier
    {
        public string classify(Observation newObsrv, List<Observation> observations)
        {
            Random rand = new Random();
            List<double[]> list = new List<double[]>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int rand1 = rand.Next(0, 7);
            int rand2 = rand.Next(0, 7);
            while (rand2.Equals(rand1))
                rand2 = rand.Next(0, 7);
            for (int i = 0; i < observations.Count; i++)
            {
                list.Add(CopyWTA(observations[i]));
                Permute(list[i], rand1, rand2);
                int max = maxIndex(list[i]);
                int min = maxIndex2(list[i], max);
                string key = observations[i].label + ":" + max + min;
                if (dict.ContainsKey(key))
                    dict[key]++;
                else
                    dict.Add(key, 1);
            }
            double[] newTest = CopyWTA(newObsrv);
            Permute(newTest, rand1, rand2);
            int maximum = maxIndex(newTest);
            int minimum = maxIndex2(newTest, maximum);
            string keyString = "" + maximum + minimum;
            Dictionary<string, int> results = dict.Where(kv => kv.Key.EndsWith(keyString)).ToDictionary(kv => kv.Key, kv => kv.Value);
            if (results != null && results.Count != 0)
            {
                results = results.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
                string label = results.First().Key.Split(':')[0];
            }
            return "Unclassified";
        }

        public double[] CopyWTA(Observation newObsrv)
        {
            double[] copy = new double[7];
            for (int i = 0; i < newObsrv.wtaHist.Length; i++)
                copy[i] = newObsrv.wtaHist[i];
            return copy;
        }

        public int maxIndex2(double[] vector, int maxIndex)
        {
            double maxValue = double.MinValue;
            int index = 0;
            for (int i = 0; i < vector.Length; i++)
                if (i != maxIndex && vector[i] > maxValue)
                {
                    maxValue = vector[i];
                    index = i;
                }
            return index;
        }

        public int maxIndex(double[] vector)
        {
            double maxValue = vector[0];
            int index = 0;
            for (int i = 1; i < vector.Length; i++)
                if (vector[i] > maxValue)
                {
                    maxValue = vector[i];
                    index = i;
                }
            return index;
        }

        public void Permute(double[] vec, int value1, int value2)
        {
            int length = vec.Length - 1;
            double temp = vec[value1];
            vec[value1] = vec[length - value1];
            vec[length - value1] = temp;

            temp = vec[value2];
            vec[value2] = vec[length - value2];
            vec[length - value2] = temp;
        }
    }
}
