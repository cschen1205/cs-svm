using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;

namespace SimuKit.ML.SVM
{
    public class SVMParamSelector<T>
        where T : CDataRecord
    {
        public void Select_C_and_Sigma(List<T> X, List<T> Xval, int max_iterations, out double best_C, out double best_sigma)
        {
            double[] C_candidates=new double[]{0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30};
            double[] sigma_candidates=new double[]{0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30};

            int C_length=C_candidates.Length;
            int sigma_length=sigma_candidates.Length;

            double min_prediction_error=double.MaxValue;

            best_C = -1;
            best_sigma = -1;

            for(int i=0; i < C_length; ++i)
            {
	            for(int j=0; j < sigma_length; ++j)
                {
                    KernelSVM<T> svm=new KernelSVM<T>();
                    GaussianKernel kernel = svm.Kernel as GaussianKernel;
                    kernel.Sigma=sigma_candidates[j];
                    svm.C=C_candidates[i];
                    svm.MaxSolverIteration = max_iterations;
                    
                    svm.Train(X);

                    double prediction_error = svm.GetPredictionError(Xval);
		            
		            if(min_prediction_error > prediction_error)
                    {
			            min_prediction_error=prediction_error;
			            best_C=C_candidates[i];
			            best_sigma=sigma_candidates[j];
		            }
	            }
            }
         }

        
    }
}
