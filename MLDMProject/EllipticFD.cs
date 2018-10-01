using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLDMProject
{
    public class EllipticFD 
    {
        private double[] x; //the x and y coordinates
        private double[] y;

        /* The number of points on input contour */
        private int m;

        /* The number of FD coefficients */
        public int nFD;
        
        /* The Fourier Descriptors */
        public double[] ax, ay, bx, by;
        
        /* The normalized Elliptic Fourier Descriptors */
        public double[] efd;

        /**
         * Constructor
         * @param x the x coordinates of the contour
         * @param y the y coordinates of the contour
         * @param m the number of descriptors to compute, in not provided then
         * the number of descriptors is set to half the number of contour points
         */
        public EllipticFD(double[] x, double[] y, int n)
        {
            this.x = x;
            this.y = y;
            this.nFD = n;
            this.m = x.Length;
            computeEllipticFD();
        }

        /**
         * Constructor with the number of descriptors is set to half
         * the number of contour points found in x and x parameters
         * @param x the x coordinates of the contour
         * @param y the y coordinates of the contour
         */
        public EllipticFD(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
            this.nFD = x.Length / 2;
            this.m = x.Length;
            computeEllipticFD();
        }

        /**
         * Computes the Fourier and Elliptic Fourier Descriptors
         */
        private void computeEllipticFD()
        {

            // the fourier descriptors
            ax = new double[nFD];
            ay = new double[nFD];
            bx = new double[nFD];
            by = new double[nFD];

            //preconfigure some values
            double t = 2.0 * Math.PI / m;
            double p = 0.0;
            double twoOverM = 2.0 / m;
            //step through each FD
            for (int k = 0; k < nFD; k++)
            {
                //and for each point
                for (int i = 0; i < m; i++)
                {
                    p = k * t * i;
                    ax[k] += x[i] * Math.Cos(p);
                    bx[k] += x[i] * Math.Sin(p);
                    ay[k] += y[i] * Math.Cos(p);
                    by[k] += y[i] * Math.Sin(p);
                }//i-loop through the number of points


                ax[k] *= twoOverM;
                bx[k] *= twoOverM;
                ay[k] *= twoOverM;
                by[k] *= twoOverM;

            }//k-loop through the number of coeffs


            //now compute the elliptic fourier descriptors as per REF2
            efd = new double[nFD];
            int first = 1; //index of the normalization values
            //precompute the denominators
            double denomA = (ax[first] * ax[first]) + (ay[first] * ay[first]);
            double denomB = (bx[first] * bx[first]) + (by[first] * by[first]);
            for (int k = 0; k < nFD; k++)
            {
                efd[k] = Math.Sqrt((ax[k] * ax[k] + ay[k] * ay[k]) / denomA)
                        + Math.Sqrt((bx[k] * bx[k] + by[k] * by[k]) / denomB);
            }//k-loop for efd


        }//computeEllipticFD

        private void computeSchmittbuhlFD() 
        {

            // the fourier descriptors
            ax = new double[nFD];
            ay = new double[nFD];
            bx = new double[nFD];
            by = new double[nFD];
            double[] tt = new double[m];//the perimeter array
            //preconfigure some values
            double t = 2.0 * Math.PI / m;//circle circumference
            double p = 0.0;
            double twoOverM = 2.0 / m;//relative double-step
            //step through each FD
            for (int jj = 0; jj < nFD; jj++) 
            {
                //and for each point
                for (int ii = 0; ii < m; ii++) 
                {
                    double dx = x[ii] - x[(ii+1)%m];
                    double dy = y[ii] - y[(ii+1)%m];
                    //////////////ti =
                    p = jj * t * ii;
                    ax[jj] += x[ii] * Math.Cos(p);
                    bx[jj] += x[ii] * Math.Sin(p);
                    ay[jj] += y[ii] * Math.Cos(p);
                    by[jj] += y[ii] * Math.Sin(p);
                }//i-loop through the number of points


                ax[jj] *= twoOverM;
                bx[jj] *= twoOverM;
                ay[jj] *= twoOverM;
                by[jj] *= twoOverM;

            }//k-loop through the number of coeffs


            //now compute the elliptic fourier descriptors as per REF2
            efd = new double[nFD];
            int first = 1; //index of the normalization values
            //precompute the denominators
            double denomA = (ax[first] * ax[first]) + (ay[first] * ay[first]);
            double denomB = (bx[first] * bx[first]) + (by[first] * by[first]);
            for (int k = 0; k < nFD; k++) 
            {
                efd[k] = Math.Sqrt((ax[k] * ax[k] + ay[k] * ay[k]) / denomA)
                        + Math.Sqrt((bx[k] * bx[k] + by[k] * by[k]) / denomB);
            }//k-loop for efd


        }//computeEllipticFD

        /**
         * Returns the polygon computed using the FD coefficients
         * @return a nx2 element array of x,y pairs that is
         * the same length as the input polygon
         *
         */
        public double[][] createPolygon() 
        {
            double p = 0.0;
            double[][] xy = new double[m][];
            for (int i = 0; i < m; i++) 
                xy[i] = new double[2];
            double t = 2.0 * Math.PI / m;
            for (int i = 0; i < m; i++) 
            {
                xy[i][0] = ax[0] / 2.0;
                xy[i][1] = ay[0] / 2.0;

                for (int k = 1; k < nFD; k++) 
                {
                    p = t * k * i;
                    xy[i][0] += ax[k] * Math.Cos(p) + bx[k] * Math.Sin(p);
                    xy[i][1] += ay[k] * Math.Cos(p) + by[k] * Math.Sin(p);
                } //k-loop through the FDs
            }//i-loop through the points
            return xy;
        }//createPolygon

        /**
         * Returns the polygon computed using the FD coefficients
         * @return a nx2 element array of x,y pairs that is
         * the same length as the input polygon
         *
         */
        public int[][] createPolygonInt() 
        {
            double p = 0.0;
            double[][] xy = new double[m][];
            for (int i = 0; i < m; i++) 
                xy[i] = new double[2];
            int[][] ixy = new int[m][];
            for (int i = 0; i < m; i++)
                ixy[i] = new int[2];
            double t = 2.0 * Math.PI / m;
            for (int i = 0; i < m; i++) 
            {
                xy[i][0] = ax[0] / 2.0;
                xy[i][1] = ay[0] / 2.0;

                for (int k = 1; k < nFD; k++) 
                {
                    p = t * k * i;
                    xy[i][0] += ax[k] * Math.Cos(p) + bx[k] * Math.Sin(p);
                    xy[i][1] += ay[k] * Math.Cos(p) + by[k] * Math.Sin(p);
                    ixy[i][0] = (int) xy[i][0];
                    ixy[i][1] = (int) xy[i][1];

                } //k-loop through the FDs
            }//i-loop through the points
            return ixy;
        }//createPolygon
    }
}
