using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.Solvers.Continuous.ProblemModels;
using Lang;

namespace SVM
{
    public class KernelSVMCostFunction<T> : CostFunction
        where T : CDataRecord
    {
        protected List<T> mDataSet;
        protected int[] mY;
        protected IKernel mKernel = null;

        protected double mC=1;

        protected int mSampleCount;

        public double C
        {
            get { return mC; }
            set { mC = value; }
        }

        public static double cost1(double z)
        {
            if (z >= 1)
            {
                return 0;
            }
            return 1 - z;
        }

        public static double cost0(double z)
        {
            if (z <= -1)
            {
                return 0;
            }
            return 1 + z;
        }

        public KernelSVMCostFunction(List<T> data_set, int[] Y, int sample_count, IKernel kernel)
            : base(sample_count+1, -10, 10)
        {
            mDataSet = data_set;
            mY = Y;
            mSampleCount = sample_count;
            mKernel = kernel;
        }

        public override double Evaluate(double[] theta)
        {
            double J = 0;

            for (int i = 0; i < mSampleCount; ++i)
            {
                double z = theta[0];
                for (int d2 = 1; d2 < mDimensionCount; ++d2)
                {
                    z += (theta[d2] * mKernel.Calc(mDataSet[i].Data, mDataSet[d2 - 1].Data));
                }

                J += mC * (mY[i] * cost1(z) + (1 - mY[i]) * cost0(z));
            }

            for (int d = 0; d < mDimensionCount; ++d)
            {
                J += (theta[d] * theta[d] / 2);
            }
            
            //Console.WriteLine("J: {0}", J);
            return J;
        }
    }
}
