using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SimuKit.ML.Lang;
using SimuKit.ML.SVM;
using SimuKit.ML.Util;
using SimuKit.ML.Solvers;

namespace SimuKit.ML.SVM.GUI
{
    public partial class FrmSVM : Form
    {
        protected double mTrainingPercent = 100;
        protected double mTestingPercent = 0;
        protected double mCrossValidationPercent = 0;

        private List<Button> mSolverCommands = new List<Button>();

        private BackgroundWorker mTrainWorker = null;

        public FrmSVM()
        {
            InitializeComponent();

            mSolverCommands.Add(btnSolver1);
            mSolverCommands.Add(btnSolver2);
            mSolverCommands.Add(btnSolver3);
            mSolverCommands.Add(btnSolver4);
            mSolverCommands.Add(btnSolver5);
            mSolverCommands.Add(btnSolver6);
            mSolverCommands.Add(btnSolver7);
            mSolverCommands.Add(btnSolver8);
            mSolverCommands.Add(btnSolver9);
            mSolverCommands.Add(btnSolver10);

            LinearSVM<CDataRecord> linear_svm = new LinearSVM<CDataRecord>();
            linear_svm.MaxSolverIteration = 100;
            linear_svm.Stepped += (solution, k) =>
                {
                    mTrainWorker.ReportProgress(k * 100 / linear_svm.MaxSolverIteration);
                };
            mSolverCommands[0].Text = "SVM (Linear Kernel)";
            mSolverCommands[0].Tag = linear_svm;

            KernelSVM<CDataRecord> rbf_svm=new KernelSVM<CDataRecord>();
            rbf_svm.C = 20;
            rbf_svm.MaxSolverIteration = 1000;
            ((GaussianKernel)rbf_svm.Kernel).Sigma = 0.01;
            rbf_svm.Stepped += (solution, k) =>
            {
                mTrainWorker.ReportProgress(k * 100 / rbf_svm.MaxSolverIteration);
            };

            mSolverCommands[1].Text = "SVM (RBF Kernel)";
            mSolverCommands[1].Tag = rbf_svm;

            for (int i = 0; i < 2; ++i)
            {
                mSolverCommands[i].Click += (s1, e1) =>
                    {
                        if (mTrainWorker != null && mTrainWorker.IsBusy)
                        {
                            MessageBox.Show("Training in process, please try again later");
                            return;
                        }

                        Button cmd = s1 as Button;
                        Classifier<CDataRecord, double> solver = cmd.Tag as Classifier<CDataRecord, double>;

                        double training_cost=-1, cv_cost=-1, testing_cost=-1;

                        DateTime curr_tick = DateTime.Now;
                        DateTime real_tick = curr_tick;

                        mTrainWorker = new BackgroundWorker();
                        mTrainWorker.WorkerSupportsCancellation = true;
                        mTrainWorker.WorkerReportsProgress = true;
                        mTrainWorker.DoWork += (s2, e2) =>
                            {
                                List<CDataRecord> training_set = LoadDataSet(DataSetTypes.Training);
                                List<CDataRecord> cv_set = LoadDataSet(DataSetTypes.CrossValidation);
                                List<CDataRecord> test_set = LoadDataSet(DataSetTypes.Testing);
                                solver.Train(training_set);
                                solver.Predict(training_set);
                                solver.Predict(cv_set);
                                solver.Predict(test_set);
                                
                                training_cost = solver.ComputeCost(training_set);
                                cv_cost = solver.ComputeCost(cv_set);
                                testing_cost = solver.ComputeCost(test_set);
                            };
                        mTrainWorker.RunWorkerCompleted += (s2, e2) =>
                            {
                                lblTrainProgress.Text = "...";
                                UpdateTabularDataView();
                                lblInformationStatus.Text = string.Format("Cost (Training): {0:0.00} Cost (CrossValidation): {1:0.00} Cost (Testing): {2:0.00}",
                            training_cost, cv_cost, testing_cost);
                            };
                        mTrainWorker.ProgressChanged += (s2, e2) =>
                            {
                                real_tick = DateTime.Now;
                                TimeSpan ts = real_tick - curr_tick;
                                if (ts.TotalMilliseconds > 500)
                                {
                                    curr_tick = real_tick;
                                    lblTrainProgress.Text = string.Format("{0}%", e2.ProgressPercentage);
                                }
                            };

                        mTrainWorker.RunWorkerAsync();
                        
                        
                    };
            }

            for (int i = 2; i < mSolverCommands.Count; ++i)
            {
                mSolverCommands[i].Visible = false;
            }
        }

        private List<CDataRecord> LoadDataSet(DataSetTypes dstype)
        {
            List<CDataRecord> data_set = new List<CDataRecord>();

            foreach (ListViewItem item in lvTabularData.Items)
            {
                CDataRecord rec = item.Tag as CDataRecord;
                if (rec.DataSetType == dstype)
                {
                    data_set.Add(rec);
                }
            }
            return data_set;
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ImportData()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "TEXT Files (*.txt)|*.txt|DAT Files (*.dat)|*.dat|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            dlg.Title = "Import X Data";
            string curr_dir = Directory.GetCurrentDirectory();
            dlg.InitialDirectory = curr_dir;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string X_filepath = dlg.FileName;

                dlg = new OpenFileDialog();
                dlg.Filter = "TEXT Files (*.txt)|*.txt|DAT Files (*.dat)|*.dat|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                dlg.Title = "Import y Data";
                dlg.InitialDirectory = curr_dir;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string y_filepath = dlg.FileName;
                    Directory.SetCurrentDirectory(curr_dir);
                    ImportData(X_filepath, y_filepath);
                }
                else
                {
                    Directory.SetCurrentDirectory(curr_dir);
                }
            }
            else
            {
                Directory.SetCurrentDirectory(curr_dir);
            }
        }

        private void ImportData(string X_filepath, string y_filepath)
        {
            mTrainingPercent = 100;
            mTestingPercent = 0;
            mCrossValidationPercent = 0;

            lvTabularData.Items.Clear();
            lvTabularData.Columns.Clear();

            List<MLDataPoint> X_points = MLDataPointUtil.LoadDataSet(X_filepath);
            List<List<int>> y_points = IntDataTableUtil.LoadDataSet(y_filepath);

            List<CDataRecord> X = new List<CDataRecord>();
            for (int i = 0; i < X_points.Count; ++i)
            {
                CDataRecord X_i = new CDataRecord(X_points[i].Dimension);
                for (int j = 0; j < X_points[i].Dimension; ++j)
                {
                    X_i[j + 1]= X_points[i][j];
                }
                X_i.Label = y_points[i][0].ToString();
                X.Add(X_i);
            }

            lvTabularData.Columns.Add("#");
            for (int i = 0; i < X[0].Dimension; ++i)
            {
                lvTabularData.Columns.Add(string.Format("X[{0}]", i));
            }
            lvTabularData.Columns.Add("Y");
            lvTabularData.Columns.Add("Data Set");
            lvTabularData.Columns.Add("Predicted Y");

            int m=X.Count;
            for (int i = 0; i < m; ++i)
            {
                CDataRecord X_i = X[i];

                ListViewItem item = new ListViewItem();
                item.Text = (lvTabularData.Items.Count + 1).ToString();
                for (int j = 0; j < X_i.Dimension; ++j)
                {
                    item.SubItems.Add(X_i[j].ToString());
                }

                item.SubItems.Add(X_i.Label.ToString());

                item.SubItems.Add(X_i.DataSetType.ToString());
                item.SubItems.Add(X_i.PredictedLabel.ToString());
                item.Tag = X_i;

                item.ForeColor = Color.Green;
                lvTabularData.Items.Add(item);
            }
        }

        public void Shuffle(List<CDataRecord> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CDataRecord value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void btnShuffleData_Click(object sender, EventArgs e)
        {
            if (lvTabularData.Items.Count == 0)
            {
                return;
            }

            List<CDataRecord> data_set = new List<CDataRecord>();
            foreach (ListViewItem item in lvTabularData.Items)
            {
                data_set.Add(item.Tag as CDataRecord);
            }

            Shuffle(data_set);

            int item_count = lvTabularData.Items.Count;

            for (int k = 0; k < item_count; ++k)
            {
                ListViewItem item = lvTabularData.Items[k];
                CDataRecord rec = data_set[k];

                item.Text = (k + 1).ToString();
                int col_index=1;
                for (col_index = 1; col_index < rec.Dimension; ++col_index)
                {
                    item.SubItems[col_index].Text=(rec[col_index].ToString());
                }
                
                item.SubItems[col_index++].Text=rec.Label.ToString();
                item.SubItems[col_index++].Text = rec.DataSetType.ToString();
                item.SubItems[col_index++].Text=rec.PredictedLabel.ToString();
                if (rec.DataSetType == DataSetTypes.Training)
                {
                    item.ForeColor = Color.Green;
                }
                else if (rec.DataSetType == DataSetTypes.Testing)
                {
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.Blue;
                }
                item.Tag = rec;
            }
        }

        private void btnSplitData_Click(object sender, EventArgs e)
        {
            FrmDataSplitOption dlg = new FrmDataSplitOption();
            dlg.TrainingPercent = mTrainingPercent;
            dlg.TestingPercent = mTestingPercent;
            dlg.CrossValidationPercent = mCrossValidationPercent;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                double training_percent = dlg.TrainingPercent;
                double testing_percent = dlg.TestingPercent;
                double crossvalidation_percent = dlg.CrossValidationPercent;
                double sum = training_percent + testing_percent + crossvalidation_percent;
                if (sum == 0)
                {
                    mTrainingPercent = 100;
                    mTestingPercent = 0;
                    mCrossValidationPercent = 0;
                }
                else
                {
                    mTrainingPercent = training_percent*100 / sum;
                    mTestingPercent = testing_percent*100 / sum;
                    mCrossValidationPercent = crossvalidation_percent*100 / sum;
                }

                int item_count=lvTabularData.Items.Count;
                int training_pont = (int)(item_count * mTrainingPercent/100);
                int testing_point = (int)(item_count * mTestingPercent/100) + training_pont;
                for (int item_index = 0; item_index < item_count; ++item_index)
                {
                    ListViewItem item = lvTabularData.Items[item_index];
                    CDataRecord rec = item.Tag as CDataRecord;
                    if (item_index < training_pont)
                    {
                        rec.DataSetType = DataSetTypes.Training;
                    }
                    else if (item_index < testing_point)
                    {
                        rec.DataSetType = DataSetTypes.Testing;
                    }
                    else
                    {
                        rec.DataSetType = DataSetTypes.CrossValidation;
                    }
                }

                UpdateTabularDataView();
            }

            
        }

        private void UpdateTabularDataView()
        {
            int item_count = lvTabularData.Items.Count;
            int training_pont = (int)(item_count * mTrainingPercent / 100);
            int testing_point = (int)(item_count * mTestingPercent / 100) + training_pont;
            for (int item_index = 0; item_index < item_count; ++item_index)
            {
                ListViewItem item = lvTabularData.Items[item_index];
                CDataRecord rec = item.Tag as CDataRecord;

                item.Text = (item_index + 1).ToString();
                int col_index = 1;
                for (col_index = 0; col_index < rec.Dimension; ++col_index)
                {
                    item.SubItems[col_index+1].Text = (rec[col_index].ToString());
                }
                col_index++;

                item.SubItems[col_index++].Text = rec.Label.ToString();
                item.SubItems[col_index++].Text = rec.DataSetType.ToString();
                item.SubItems[col_index++].Text = rec.PredictedLabel.ToString();

                if (rec.DataSetType == DataSetTypes.Training)
                {
                    item.ForeColor = Color.Green;
                }
                else if (rec.DataSetType == DataSetTypes.Testing)
                {
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.Blue;
                }
            }
        }
    }
}
