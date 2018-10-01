using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public interface IClassifier
    {
        void Train(List<Observation> observations);
        string Classify(Observation newObsrv);
    }
}
