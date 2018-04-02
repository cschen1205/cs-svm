using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.Solvers.Continuous.ProblemModels;

namespace SimuKit.ML.SVM
{
    public class LinearSVMCostFunction : CostFunction
    {
        protected double[,] mX;
        protected int[] mY;

        protected int mSampleCount;
        protected double mC=1;

        public double C
        {
            get {return mC;}
            set {mC=value;}
        }

        public LinearSVMCostFunction(double[,] X, int[] Y, int dimension_count, int sample_count)
            : base(dimension_count, -10, 10)
        {
            mX = X;
            mY = Y;
            mSampleCount = sample_count;
        }

        protected double cost1(double z)
        {
            if (z >= 1)
            {
                return 0;
            }
            return 1-z;
        }

        protected double cost0(double z)
        {
            if (z <= -1)
            {
                return 0;
            }
            return 1+z;
        }

        public override double Evaluate(double[] theta)
        {
            double J = 0;

            for (int i = 0; i < mSampleCount; ++i)
            {
                double z = 0;
                for (int d2 = 0; d2 < mDimensionCount; ++d2)
                {   
                    z += (theta[d2] * mX[i, d2]);
                }
                J+=mC*(mY[i] * cost1(z) + (1 - mY[i]) * cost0(z));
            }

            for (int d = 0; d < mDimensionCount; ++d)
            {
                J += (theta[d] * theta[d] / 2);
            }
            
            return J;
        }
    }
}
