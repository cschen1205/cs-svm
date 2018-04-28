namespace SVM.GUI
{
    partial class FrmSVM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvTabularData = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chtViewer = new ChartDirector.WinChartViewer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInformationStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Data = new System.Windows.Forms.TabPage();
            this.btnSplitData = new System.Windows.Forms.Button();
            this.btnShuffleData = new System.Windows.Forms.Button();
            this.btnImportData = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSolver10 = new System.Windows.Forms.Button();
            this.btnSolver9 = new System.Windows.Forms.Button();
            this.btnSolver7 = new System.Windows.Forms.Button();
            this.btnSolver8 = new System.Windows.Forms.Button();
            this.btnSolver6 = new System.Windows.Forms.Button();
            this.btnSolver5 = new System.Windows.Forms.Button();
            this.btnSolver4 = new System.Windows.Forms.Button();
            this.btnSolver3 = new System.Windows.Forms.Button();
            this.btnSolver2 = new System.Windows.Forms.Button();
            this.btnSolver1 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.statusStrip4 = new System.Windows.Forms.StatusStrip();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip5 = new System.Windows.Forms.StatusStrip();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.lblTrainProgress = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtViewer)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Data.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(852, 432);
            this.splitContainer1.SplitterDistance = 562;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 410);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvTabularData);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tabular Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvTabularData
            // 
            this.lvTabularData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTabularData.FullRowSelect = true;
            this.lvTabularData.GridLines = true;
            this.lvTabularData.HideSelection = false;
            this.lvTabularData.Location = new System.Drawing.Point(3, 28);
            this.lvTabularData.MultiSelect = false;
            this.lvTabularData.Name = "lvTabularData";
            this.lvTabularData.Size = new System.Drawing.Size(548, 353);
            this.lvTabularData.TabIndex = 1;
            this.lvTabularData.UseCompatibleStateImageBehavior = false;
            this.lvTabularData.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(548, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chtViewer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(554, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chtViewer
            // 
            this.chtViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtViewer.Location = new System.Drawing.Point(3, 3);
            this.chtViewer.Name = "chtViewer";
            this.chtViewer.Size = new System.Drawing.Size(548, 378);
            this.chtViewer.TabIndex = 0;
            this.chtViewer.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInformationStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(562, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblInformationStatus
            // 
            this.lblInformationStatus.Name = "lblInformationStatus";
            this.lblInformationStatus.Size = new System.Drawing.Size(16, 17);
            this.lblInformationStatus.Text = "...";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip3);
            this.splitContainer2.Size = new System.Drawing.Size(286, 432);
            this.splitContainer2.SplitterDistance = 204;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Data);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(286, 204);
            this.tabControl2.TabIndex = 3;
            // 
            // Data
            // 
            this.Data.Controls.Add(this.btnSplitData);
            this.Data.Controls.Add(this.btnShuffleData);
            this.Data.Controls.Add(this.btnImportData);
            this.Data.Location = new System.Drawing.Point(4, 22);
            this.Data.Name = "Data";
            this.Data.Padding = new System.Windows.Forms.Padding(3);
            this.Data.Size = new System.Drawing.Size(278, 178);
            this.Data.TabIndex = 0;
            this.Data.Text = "Data";
            this.Data.UseVisualStyleBackColor = true;
            // 
            // btnSplitData
            // 
            this.btnSplitData.Location = new System.Drawing.Point(177, 19);
            this.btnSplitData.Name = "btnSplitData";
            this.btnSplitData.Size = new System.Drawing.Size(78, 64);
            this.btnSplitData.TabIndex = 0;
            this.btnSplitData.Text = "Split Data";
            this.btnSplitData.UseVisualStyleBackColor = true;
            this.btnSplitData.Click += new System.EventHandler(this.btnSplitData_Click);
            // 
            // btnShuffleData
            // 
            this.btnShuffleData.Location = new System.Drawing.Point(98, 19);
            this.btnShuffleData.Name = "btnShuffleData";
            this.btnShuffleData.Size = new System.Drawing.Size(73, 64);
            this.btnShuffleData.TabIndex = 0;
            this.btnShuffleData.Text = "Shuffle";
            this.btnShuffleData.UseVisualStyleBackColor = true;
            this.btnShuffleData.Click += new System.EventHandler(this.btnShuffleData_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(16, 19);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(76, 64);
            this.btnImportData.TabIndex = 0;
            this.btnImportData.Text = "Import";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(278, 178);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Local Search";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(286, 202);
            this.tabControl3.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(278, 176);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Train";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 170);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSolver10);
            this.panel2.Controls.Add(this.btnSolver9);
            this.panel2.Controls.Add(this.btnSolver7);
            this.panel2.Controls.Add(this.btnSolver8);
            this.panel2.Controls.Add(this.btnSolver6);
            this.panel2.Controls.Add(this.btnSolver5);
            this.panel2.Controls.Add(this.btnSolver4);
            this.panel2.Controls.Add(this.btnSolver3);
            this.panel2.Controls.Add(this.btnSolver2);
            this.panel2.Controls.Add(this.btnSolver1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 400);
            this.panel2.TabIndex = 0;
            // 
            // btnSolver10
            // 
            this.btnSolver10.Location = new System.Drawing.Point(16, 282);
            this.btnSolver10.Name = "btnSolver10";
            this.btnSolver10.Size = new System.Drawing.Size(219, 24);
            this.btnSolver10.TabIndex = 4;
            this.btnSolver10.Text = "Run Solver 10";
            this.btnSolver10.UseVisualStyleBackColor = true;
            // 
            // btnSolver9
            // 
            this.btnSolver9.Location = new System.Drawing.Point(16, 252);
            this.btnSolver9.Name = "btnSolver9";
            this.btnSolver9.Size = new System.Drawing.Size(219, 24);
            this.btnSolver9.TabIndex = 4;
            this.btnSolver9.Text = "Run Solver 9";
            this.btnSolver9.UseVisualStyleBackColor = true;
            // 
            // btnSolver7
            // 
            this.btnSolver7.Location = new System.Drawing.Point(16, 192);
            this.btnSolver7.Name = "btnSolver7";
            this.btnSolver7.Size = new System.Drawing.Size(219, 24);
            this.btnSolver7.TabIndex = 4;
            this.btnSolver7.Text = "Run Solver 7";
            this.btnSolver7.UseVisualStyleBackColor = true;
            // 
            // btnSolver8
            // 
            this.btnSolver8.Location = new System.Drawing.Point(16, 222);
            this.btnSolver8.Name = "btnSolver8";
            this.btnSolver8.Size = new System.Drawing.Size(219, 24);
            this.btnSolver8.TabIndex = 4;
            this.btnSolver8.Text = "Run Solver 8";
            this.btnSolver8.UseVisualStyleBackColor = true;
            // 
            // btnSolver6
            // 
            this.btnSolver6.Location = new System.Drawing.Point(16, 162);
            this.btnSolver6.Name = "btnSolver6";
            this.btnSolver6.Size = new System.Drawing.Size(219, 24);
            this.btnSolver6.TabIndex = 4;
            this.btnSolver6.Text = "Run Solver 6";
            this.btnSolver6.UseVisualStyleBackColor = true;
            // 
            // btnSolver5
            // 
            this.btnSolver5.Location = new System.Drawing.Point(16, 132);
            this.btnSolver5.Name = "btnSolver5";
            this.btnSolver5.Size = new System.Drawing.Size(219, 24);
            this.btnSolver5.TabIndex = 4;
            this.btnSolver5.Text = "Run Solver 5";
            this.btnSolver5.UseVisualStyleBackColor = true;
            // 
            // btnSolver4
            // 
            this.btnSolver4.Location = new System.Drawing.Point(16, 102);
            this.btnSolver4.Name = "btnSolver4";
            this.btnSolver4.Size = new System.Drawing.Size(219, 24);
            this.btnSolver4.TabIndex = 5;
            this.btnSolver4.Text = "Run Solver 4";
            this.btnSolver4.UseVisualStyleBackColor = true;
            // 
            // btnSolver3
            // 
            this.btnSolver3.Location = new System.Drawing.Point(16, 72);
            this.btnSolver3.Name = "btnSolver3";
            this.btnSolver3.Size = new System.Drawing.Size(219, 24);
            this.btnSolver3.TabIndex = 3;
            this.btnSolver3.Text = "Run Solver 3";
            this.btnSolver3.UseVisualStyleBackColor = true;
            // 
            // btnSolver2
            // 
            this.btnSolver2.Location = new System.Drawing.Point(16, 40);
            this.btnSolver2.Name = "btnSolver2";
            this.btnSolver2.Size = new System.Drawing.Size(219, 24);
            this.btnSolver2.TabIndex = 1;
            this.btnSolver2.Text = "Run Solver 2";
            this.btnSolver2.UseVisualStyleBackColor = true;
            // 
            // btnSolver1
            // 
            this.btnSolver1.Location = new System.Drawing.Point(16, 10);
            this.btnSolver1.Name = "btnSolver1";
            this.btnSolver1.Size = new System.Drawing.Size(219, 24);
            this.btnSolver1.TabIndex = 2;
            this.btnSolver1.Text = "Run Solver 1";
            this.btnSolver1.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.statusStrip4);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(278, 176);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Cross Validate";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // statusStrip4
            // 
            this.statusStrip4.Location = new System.Drawing.Point(3, 151);
            this.statusStrip4.Name = "statusStrip4";
            this.statusStrip4.Size = new System.Drawing.Size(272, 22);
            this.statusStrip4.TabIndex = 1;
            this.statusStrip4.Text = "statusStrip4";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.statusStrip5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(278, 176);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip5
            // 
            this.statusStrip5.Location = new System.Drawing.Point(3, 151);
            this.statusStrip5.Name = "statusStrip5";
            this.statusStrip5.Size = new System.Drawing.Size(272, 22);
            this.statusStrip5.TabIndex = 1;
            this.statusStrip5.Text = "statusStrip5";
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrainProgress});
            this.statusStrip3.Location = new System.Drawing.Point(0, 202);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(286, 22);
            this.statusStrip3.TabIndex = 5;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // lblTrainProgress
            // 
            this.lblTrainProgress.Name = "lblTrainProgress";
            this.lblTrainProgress.Size = new System.Drawing.Size(16, 17);
            this.lblTrainProgress.Text = "...";
            // 
            // FrmSVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 456);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSVM";
            this.Text = "SimuKit-ML-SVM";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtViewer)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Data.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvTabularData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Data;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnShuffleData;
        private System.Windows.Forms.Button btnSplitData;
        private System.Windows.Forms.StatusStrip statusStrip4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip statusStrip5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSolver10;
        private System.Windows.Forms.Button btnSolver9;
        private System.Windows.Forms.Button btnSolver7;
        private System.Windows.Forms.Button btnSolver8;
        private System.Windows.Forms.Button btnSolver6;
        private System.Windows.Forms.Button btnSolver5;
        private System.Windows.Forms.Button btnSolver4;
        private System.Windows.Forms.Button btnSolver3;
        private System.Windows.Forms.Button btnSolver2;
        private System.Windows.Forms.Button btnSolver1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInformationStatus;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private ChartDirector.WinChartViewer chtViewer;
        private System.Windows.Forms.ToolStripStatusLabel lblTrainProgress;

    }
}

