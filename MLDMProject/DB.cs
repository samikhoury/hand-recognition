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
    public class DB
    {
        public List<Observation> allobservation { get; set; }
        public HMMClassifier hmmClassifier { get; set; }
        public SVMClassifier svmClassifier { get; set; }
        public DTClassifier dtClassifier { get; set; }
        public RFClassifier rfClassifier { get; set; }
        public ANNClassifier annClassifier { get; set; }
        public LogisticRegressionClassifier lrClassifier { get; set; }

        public DB()
        {
            allobservation = new List<Observation>();
        }

        public void serialize()
        {
            string db;
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Debug"))
                db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db");
            else
            {
                string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Debug\");
                db = Path.Combine(tempPath, "db");
            }
            Stream stream = File.Open(db, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

        public void deserialize()
        {
            string db;
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Debug"))
                db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db");
            else
            {
                string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Debug\");
                db = Path.Combine(tempPath, "db");
            }
            Stream stream = File.Open(db, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            DB temp = (DB)bformatter.Deserialize(stream);
            stream.Close();
            this.allobservation = temp.allobservation;
            this.hmmClassifier = temp.hmmClassifier;
            this.svmClassifier = temp.svmClassifier;
            this.dtClassifier = temp.dtClassifier;
            this.rfClassifier = temp.rfClassifier;
            this.annClassifier = temp.annClassifier;
            this.lrClassifier = temp.lrClassifier;
        }
    }
}
