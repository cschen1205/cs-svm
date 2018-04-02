using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;

namespace SimuKit.ML.SVM
{
    public class GaussianKernel : IKernel
    {
        protected double mSigma = 1;

        public double Sigma
        {
            get { return mSigma; }
            set { mSigma = value; }
        }

        public double Calc(double[] x, double[] l)
        {
            double sum = 0;
            int dimension = x.Length;
            for (int d = 0; d < dimension; ++d)
            {
                sum += System.Math.Pow(x[d] - l[d], 2);
            }
            return System.Math.Exp(-sum / (2 * mSigma * mSigma));
        }

        public IKernel Clone()
        {
            GaussianKernel clone = new GaussianKernel();
            clone.Sigma = mSigma;
            return clone;
        }
    }
}
