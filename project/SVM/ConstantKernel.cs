using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;

namespace SimuKit.ML.SVM
{
    public class ConstantKernel : IKernel
    {
        public double Calc(double[] x, double[] l)
        {
            return 1;
        }

        public IKernel Clone()
        {
            return new ConstantKernel();
        }
    }
}
