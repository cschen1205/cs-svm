using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lang;
using SimuKit.Solvers.Continuous.LocalSearch;
using Solvers;
using SimuKit.Solvers.Continuous;
using SimuKit.Solvers.Core;

namespace SVM
{
    public class KernelSVM<T> : Classifier<T, double>
        where T : CDataRecord
    {
        Dictionary<string, double[]> mTheta = new Dictionary<string, double[]>();

        List<string> mClassFieldLabels = new List<string>();

        protected SingleTrajectoryContinuousSolver mLocalSearcher = new GradientDescent();
        protected int mMaxSolverIteration = 2000;

        public List<double[]> mKernelCentroids = new List<double[]>();

        protected IKernel mKernel = new GaussianKernel();

        public delegate void SteppedHandle(BaseSolution<double> solution, int step);
        public event SteppedHandle Stepped;
        public delegate void SolutionUpdatedHandle(BaseSolution<double> solution, int step);
        public event SolutionUpdatedHandle SolutionUpdated;

        protected void OnStepped(BaseSolution<double> solution, int step)
        {
            if (Stepped != null)
            {
                Stepped(solution, step);
            }
        }

        protected void OnSolutionUpdated(BaseSolution<double> best_solution, int step)
        {
            if (SolutionUpdated != null)
            {
                SolutionUpdated(best_solution, step);
            }
        }

        public IKernel Kernel
        {
            get { return mKernel; }
            set { mKernel = value; }
        }

        public int MaxSolverIteration
        {
            get { return mMaxSolverIteration; }
            set { mMaxSolverIteration = value; }
        }

        protected double mC = 1;
        public double C
        {
            get { return mC; }
            set { mC = value; }
        }

        public KernelSVM()
        {
            mLocalSearcher.Stepped += (s, step) =>
            {
                OnStepped(s, step);
            };
            mLocalSearcher.SolutionUpdated += (s, step) =>
            {
                OnSolutionUpdated(s, step);
            };
        }

        public SingleTrajectoryContinuousSolver LocalSearch
        {
            get { return mLocalSearcher; }
            set
            {
                if (mLocalSearcher != value)
                {
                    mLocalSearcher = value;
                    mLocalSearcher.Stepped += (s, step) =>
                    {
                        OnStepped(s, step);
                    };
                    mLocalSearcher.SolutionUpdated += (s, step) =>
                    {
                        OnSolutionUpdated(s, step);
                    };
                }
            }
        }

        /// <summary>
        /// Method used to find the error in terms of SVM cost function
        /// </summary>
        /// <param name="data_set"></param>
        /// <returns></returns>
        public override double ComputeCost(List<T> data_set)
        {
            int sample_count = data_set.Count;

            int[] Y = new int[sample_count];

            double total_error = 0;
            foreach (string class_label in mClassFieldLabels)
            {
                for (int i = 0; i < sample_count; ++i)
                {
                    T rec = data_set[i];
                    Y[i] = rec.Label == class_label ? 1 : 0;
                }

                KernelSVMCostFunction<T> f = new KernelSVMCostFunction<T>(data_set, Y, sample_count, mKernel);
                f.C = mC;

                double error = f.Evaluate(mTheta[class_label]);
                total_error += error;
            }
            return total_error;
        }

        /// <summary>
        /// Method used to find the prediction accuracy of the SVM model
        /// </summary>
        /// <param name="data_set"></param>
        /// <returns></returns>
        public double GetPredictionError(List<T> Xval)
        {
            int sample_count = Xval.Count;

            double total_error = 0;
            int total_count = 0;
            foreach (string class_label in mClassFieldLabels)
            {
                for (int i = 0; i < sample_count; ++i)
                {
                    T rec = Xval[i];
                    double actual_y = rec.Label == class_label ? 1 : 0;

                    string predicted_label=Predict(rec);

                    double predicted_y = predicted_label == class_label ? 1 : 0;

                    if (predicted_y == actual_y)
                    {
                        total_error += 1;
                    }
                    total_count++;
                }
            }
            return total_error / total_count;
        }

        public override void Train(List<T> records)
        {
            HashSet<string> class_labels = new HashSet<string>();
            foreach (T rec in records)
            {
                class_labels.Add(rec.Label);
            }

            mClassFieldLabels = class_labels.ToList();
            mTheta.Clear();
            mKernelCentroids.Clear();

            int m = records.Count;
            if (m == 0)
            {
                throw new ArgumentException("sample count==0");
            }
            int dimension = records[0].Dimension;

            int[] Y = new int[m];

            for (int i = 0; i < m; ++i)
            {
                T rec = records[i];
                mKernelCentroids.Add((double[])rec.Data.Clone());
            }

            double[] theta_0 = new double[m + 1];
            foreach (string class_label in mClassFieldLabels)
            {
                for (int i = 0; i < m; ++i)
                {
                    T rec = records[i];
                    Y[i] = rec.Label == class_label ? 1 : 0;
                }
                for (int d = 0; d < dimension; ++d)
                {
                    theta_0[d] = 0;
                }


                KernelSVMCostFunction<T> f = new KernelSVMCostFunction<T>(records, Y, m, mKernel);
                f.C = mC;
                ContinuousSolution solution = mLocalSearcher.Minimize(theta_0, f, mMaxSolverIteration);
                mTheta[class_label] = solution.Values;
            }
        }

        public List<KeyValuePair<string, double>> Rank(List<T> X, T rec)
        {
            List<KeyValuePair<string, double>> ranks = new List<KeyValuePair<string, double>>();

            int sample_count = X.Count;
            int theta_dimension = sample_count + 1;

            foreach (string class_label in mClassFieldLabels)
            {
                double[] theta = mTheta[class_label];

                double z = theta[0];
                for (int d2 = 1; d2 < theta_dimension; ++d2)
                {
                    z += (theta[d2] * mKernel.Calc(rec.Data, X[d2 - 1].Data));
                }
                ranks.Add(new KeyValuePair<string, double>(class_label, z));
            }

            ranks.Sort((s1, s2) =>
            {
                return s2.Value.CompareTo(s1.Value);
            });

            return ranks;
        }

        public override void Predict(List<T> Xval)
        {
            int m = Xval.Count;
            for (int i = 0; i < m; ++i)
            {
                T Xval_i = Xval[i];
                Xval_i.PredictedLabel = Predict(Xval_i);
            }
        }

        public override string Predict(T rec)
        {
            int kernel_count = mKernelCentroids.Count;
            int theta_dimension = kernel_count + 1;

            double max_z = double.MinValue;
            string predicted_label = null;
            foreach (string class_label in mClassFieldLabels)
            {
                double[] theta = mTheta[class_label];
                double z = theta[0];
                for (int d2 = 1; d2 < theta_dimension; ++d2)
                {
                    z += (theta[d2] * mKernel.Calc(rec.Data, mKernelCentroids[d2 - 1]));
                }
                if (max_z < z)
                {
                    max_z = z;
                    predicted_label = class_label;
                }
            }

            return predicted_label;
        }
    }
}
