using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimuKit.ML.Lang;
using SimuKit.Solvers.Continuous.LocalSearch;
using SimuKit.ML.Solvers;
using SimuKit.Solvers.Continuous;
using SimuKit.Solvers.Core;

namespace SimuKit.ML.SVM
{
    public class LinearSVM<T> : Classifier<T, double>
        where T: CDataRecord
    {
        Dictionary<string, double[]> mTheta = new Dictionary<string, double[]>();
        List<string> mClassFieldLabels = new List<string>();

        protected SingleTrajectoryContinuousSolver mLocalSearcher = new GradientDescent();
        protected int mMaxSolverIteration = 2000;

        protected double mC = 1;

        public double C
        {
            get { return mC; }
            set { mC = value; }
        }

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

        public LinearSVM()
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

        public int MaxSolverIteration
        {
            get { return mMaxSolverIteration; }
            set { mMaxSolverIteration = value; }
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

            int sample_count = records.Count;
            if (sample_count == 0)
            {
                throw new ArgumentException("sample_count==0");
            }
            int dimension = records[0].Dimension;
            

            double[,] X = new double[sample_count, dimension];
            int[] Y = new int[sample_count];
            for (int i = 0; i < sample_count; ++i)
            {
                T rec = records[i];
                for (int d = 0; d < dimension; ++d)
                {
                    X[i, d] = rec[d];
                }
            }

            double[] theta_0 = new double[dimension];
            foreach (string class_label in mClassFieldLabels)
            {
                for (int i = 0; i < sample_count; ++i)
                {
                    T rec = records[i];
                    Y[i] = rec.Label == class_label ? 1 : 0;
                }
                for (int d = 0; d < dimension; ++d)
                {
                    theta_0[d] = 0;
                }


                LinearSVMCostFunction f = new LinearSVMCostFunction(X, Y, dimension, sample_count);
                f.C = mC;

                ContinuousSolution solution = mLocalSearcher.Minimize(theta_0, f, mMaxSolverIteration);
                mTheta[class_label] = solution.Values;
            }
        }

        public List<KeyValuePair<string, double>> Rank(T rec)
        {
            List<KeyValuePair<string, double>> ranks = new List<KeyValuePair<string, double>>();

            int dimension = rec.Dimension;

            foreach (string class_label in mClassFieldLabels)
            {
                double[] theta = mTheta[class_label];

                double sum = 0;
                for (int d = 0; d < dimension; ++d)
                {
                    sum += (rec[d] * theta[d]);
                }
                //Console.WriteLine("sum: {0}", sum);
                double h = sum;
                ranks.Add(new KeyValuePair<string, double>(class_label, h));
            }

            ranks.Sort((s1, s2) =>
            {
                return s2.Value.CompareTo(s1.Value);
            });

            return ranks;
        }

        public override double ComputeCost(List<T> data_set)
        {
            int sample_count = data_set.Count;
            if (sample_count == 0) return -1;

            int dimension = data_set[0].Dimension;
            
            double[,] X = new double[sample_count, dimension];
            int[] Y = new int[sample_count];
            for (int i = 0; i < sample_count; ++i)
            {
                T rec = data_set[i];
                for (int d = 0; d < dimension; ++d)
                {
                    X[i, d] = rec[d];
                }
            }

            double total_error = 0;
            foreach (string class_label in mClassFieldLabels)
            {
                for (int i = 0; i < sample_count; ++i)
                {
                    CDataRecord rec = data_set[i] as CDataRecord;
                    Y[i] = rec.Label == class_label ? 1 : 0;
                }

                LinearSVMCostFunction f = new LinearSVMCostFunction(X, Y, dimension, sample_count);
                f.C = mC;

                double error = f.Evaluate(mTheta[class_label]);
                total_error += error;
            }
            return total_error;
        }


        public override void Predict(List<T> Xval)
        {
            int m = Xval.Count;
            for (int i = 0; i < m; ++i)
            {
                T Xval_i = Xval[i];
                Xval_i.PredictedLabel=Predict(Xval_i);
            }
        }

        public override string Predict(T rec)
        {
            int dimension = rec.Dimension;
            double max_h = double.MinValue;
            string predicted_label = null;
            foreach (string class_label in mClassFieldLabels)
            {
                double[] theta = mTheta[class_label];
                double sum = 0;
                for (int d = 0; d < dimension; ++d)
                {
                    sum += theta[d] * rec[d];
                }

                double h = sum;
                if (max_h < h)
                {
                    max_h = h;
                    predicted_label = class_label;
                }
            }

            return predicted_label;
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

                    string predicted_label = Predict(rec);

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

        
    }
}
