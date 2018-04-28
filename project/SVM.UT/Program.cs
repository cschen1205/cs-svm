using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuKit.ML.SVM.UT
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearSVM_UT.Run_Classify();
            //LinearSVM_UT.Run_Rank();

            //KernelSVM_UT.Run_Classify();
            //KernelSVM_UT.Run_Rank();
        }
    }
}
