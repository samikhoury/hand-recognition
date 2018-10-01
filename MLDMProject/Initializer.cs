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
    public class Initializer
    {
        public Dictionary<string, int> labels { get; set; }
        public int maxFrequency { get; set; }
        public int numbEFD { get; set; }
        public Initializer()
        {
            labels = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                labels.Add(i.ToString(), 0);
            this.maxFrequency = 0;
            this.numbEFD = 4;
        }

        public void serialize()
        {
            string initializer;
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Debug"))
                initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initializer");
            else
            {
                string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Debug\");
                initializer = Path.Combine(tempPath, "initializer");
            }
            Stream stream = File.Open(initializer, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

        public void deserialize()
        {
            string initializer;
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Debug"))
                initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initializer");
            else
            {
                string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Debug\");
                initializer = Path.Combine(tempPath, "initializer");
            }
            Stream stream = File.Open(initializer, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            Initializer temp = (Initializer)bformatter.Deserialize(stream);
            stream.Close();
            this.labels = temp.labels;
            this.maxFrequency = temp.maxFrequency;
            this.numbEFD = temp.numbEFD;
        }
    }
}
