using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;

namespace SimuKit.ML.SVM
{
    public interface IKernel
    {
        double Calc(double[] x, double[] l);
        IKernel Clone();
    }
}
