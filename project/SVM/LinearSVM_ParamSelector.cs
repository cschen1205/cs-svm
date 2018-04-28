using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lang;

namespace SVM
{
    public class LinearSVM_ParamSelector<T>
        where T: CDataRecord
    {
        public void Select_C(List<T> X, List<T> Xval, int max_iterations, out double best_C)
        {
            double[] C_candidates = new double[] { 0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30, 100 };

            int C_length = C_candidates.Length;

            double min_prediction_error = double.MaxValue;

            best_C = -1;

            for (int i = 0; i < C_length; ++i)
            {
                LinearSVM<T> svm = new LinearSVM<T>();
                svm.C = C_candidates[i];
                svm.MaxSolverIteration = max_iterations;

                svm.Train(X);

                double prediction_error = svm.GetPredictionError(Xval);

                if (min_prediction_error > prediction_error)
                {
                    min_prediction_error = prediction_error;
                    best_C = C_candidates[i];
                }
            }
        }
    }
}
