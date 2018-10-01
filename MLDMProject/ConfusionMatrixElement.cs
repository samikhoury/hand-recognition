using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    [Serializable]
    public class ConfusionMatrixElement
    {
        public int positive { get; set; }
        public int negative { get; set; }
        public int numb_of_examples { get; set; }
        public Dictionary<string, int> misclassified { get; set; }

        public ConfusionMatrixElement()
        {
            this.positive = 0;
            this.negative = 0;
            this.numb_of_examples = 0;
            this.misclassified = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                this.misclassified.Add(i.ToString(), 0);
        }
    }
}
