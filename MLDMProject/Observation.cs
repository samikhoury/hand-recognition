using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MLDMProject
{
    [Serializable]
    public class Observation
    {
        public string freemanCode { get; set; }
        public string imagePath { get; set; }
        public string contourPath { get; set; }
        public string label { get; set; }
        public double[] freemanHist { get; set; }
        public double[] normFreemanHist { get; set; }
        public double[] wtaHist { get; set; }
        public double[] normEFD { get; set; }
        public double[] efd { get; set; }
        public double[] xContour { get; set; }
        public double[] yContour { get; set; }

        public Observation()
        {
            this.freemanCode = "";
            this.imagePath = "";
            this.contourPath = "";
            this.label = "";
            this.freemanHist = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.normFreemanHist = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.wtaHist = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        }

        public Observation(string freemanCode, string imagePath, string contourPath, string label)
        {
            this.freemanCode = freemanCode;
            this.imagePath = imagePath;
            this.contourPath = contourPath;
            this.label = label;
            this.freemanHist = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.normFreemanHist = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.wtaHist = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
        }

        public void calculHistogram()
        {
            foreach (char c in this.freemanCode)
                this.freemanHist[Int16.Parse(c.ToString())]++;
            this.freemanHist[this.freemanHist.Length - 1] = this.freemanCode.Length;
        }

        public void calculHistogram(int maxFrequency)
        {
            for (int i = 0; i < this.normFreemanHist.Length; i++)
                this.normFreemanHist[i] = (double) this.freemanHist[i] / (double) maxFrequency;
        }

        public void calculWTAHist()
        {
            for (int i = 0; i < this.freemanHist.Length - 2; i++)
                this.wtaHist[i] = this.freemanHist[i + 1] - this.freemanHist[i];
        }
    }
}
