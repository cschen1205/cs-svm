using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lang;

namespace SVM
{
    public interface IKernel
    {
        double Calc(double[] x, double[] l);
        IKernel Clone();
    }
}
