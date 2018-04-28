namespace SVM.GUI
{
    partial class FrmDataSplitOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTrainingPercent = new System.Windows.Forms.NumericUpDown();
            this.nudCrossValidationPercent = new System.Windows.Forms.NumericUpDown();
            this.nudTestingPercent = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMakeDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrainingPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossValidationPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestingPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Training Data (%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cross Validation Set (%):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Testing Data (%):";
            // 
            // nudTrainingPercent
            // 
            this.nudTrainingPercent.Location = new System.Drawing.Point(191, 21);
            this.nudTrainingPercent.Name = "nudTrainingPercent";
            this.nudTrainingPercent.Size = new System.Drawing.Size(120, 20);
            this.nudTrainingPercent.TabIndex = 1;
            // 
            // nudCrossValidationPercent
            // 
            this.nudCrossValidationPercent.Location = new System.Drawing.Point(191, 49);
            this.nudCrossValidationPercent.Name = "nudCrossValidationPercent";
            this.nudCrossValidationPercent.Size = new System.Drawing.Size(120, 20);
            this.nudCrossValidationPercent.TabIndex = 1;
            // 
            // nudTestingPercent
            // 
            this.nudTestingPercent.Location = new System.Drawing.Point(191, 78);
            this.nudTestingPercent.Name = "nudTestingPercent";
            this.nudTestingPercent.Size = new System.Drawing.Size(120, 20);
            this.nudTestingPercent.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(179, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnMakeDefault
            // 
            this.btnMakeDefault.Location = new System.Drawing.Point(35, 118);
            this.btnMakeDefault.Name = "btnMakeDefault";
            this.btnMakeDefault.Size = new System.Drawing.Size(88, 23);
            this.btnMakeDefault.TabIndex = 2;
            this.btnMakeDefault.Text = "Make Default";
            this.btnMakeDefault.UseVisualStyleBackColor = true;
            this.btnMakeDefault.Click += new System.EventHandler(this.btnMakeDefault_Click);
            // 
            // FrmDataSplitOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 154);
            this.Controls.Add(this.btnMakeDefault);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nudTestingPercent);
            this.Controls.Add(this.nudCrossValidationPercent);
            this.Controls.Add(this.nudTrainingPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataSplitOption";
            this.Text = "Data Split Option";
            ((System.ComponentModel.ISupportInitialize)(this.nudTrainingPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossValidationPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestingPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTrainingPercent;
        private System.Windows.Forms.NumericUpDown nudCrossValidationPercent;
        private System.Windows.Forms.NumericUpDown nudTestingPercent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMakeDefault;
    }
}