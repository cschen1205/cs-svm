using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVM
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
