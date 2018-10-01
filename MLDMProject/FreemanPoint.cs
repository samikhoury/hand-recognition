using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public class FreemanPoint
    {
        public enum freeman { nill = -1, up = 0, upRight, right, downRight, down, downLeft, left, upLeft };
        public freeman point {get; set;}
        public int pointI { get; set; }
        public int pointJ { get; set; }
        public int angle { get; set; }
        public FreemanPoint()
        {
            point = freeman.nill;
            pointI = -1;
            pointJ = -1;
            angle = 0;
        }

        public FreemanPoint(freeman point, int pointI, int pointJ, int angle)
        {
            this.point = point;
            this.pointI = pointI;
            this.pointJ = pointJ;
            this.angle = angle;
        }
    }
}
