using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimuKit.ML.SVM.GUI
{
    public partial class FrmDataSplitOption : Form
    {
        public FrmDataSplitOption()
        {
            InitializeComponent();
        }

        public double TrainingPercent
        {
            get { return (double)nudTrainingPercent.Value; }
            set { nudTrainingPercent.Value = (decimal)value; }
        }

        public double TestingPercent
        {
            get { return (double)nudTestingPercent.Value; }
            set { nudTestingPercent.Value = (decimal)value; }
        }

        public double CrossValidationPercent
        {
            get { return (double)nudCrossValidationPercent.Value; }
            set { nudCrossValidationPercent.Value = (decimal)value; }
        }

        private void btnMakeDefault_Click(object sender, EventArgs e)
        {
            nudCrossValidationPercent.Value = 20;
            nudTestingPercent.Value = 20;
            nudTrainingPercent.Value = 60;
        }
    }
}
