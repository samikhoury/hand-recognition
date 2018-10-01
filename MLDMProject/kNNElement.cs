using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public class kNNElement
    {
        public string key { get; set; }
        public Int32 value { get; set; }

        public kNNElement()
        {
            this.key = "";
            this.value = -1;
        }

        public kNNElement(string key, Int32 value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
