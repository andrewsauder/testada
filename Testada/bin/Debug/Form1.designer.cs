namespace Testada
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.testProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.trbCatchStepsLogLevel = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSmtpFrom = new System.Windows.Forms.TextBox();
            this.chkSmtpAuthentication = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSmtpUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmailResultsTo = new System.Windows.Forms.TextBox();
            this.chkEmailResults = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRunSelected = new System.Windows.Forms.Button();
            this.lsvTestSuite = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbCatchStepsLogLevel)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testProgressTimer
            // 
            this.testProgressTimer.Enabled = true;
            this.testProgressTimer.Tick += new System.EventHandler(this.testProgressTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(39, 17);
            this.tssLabel.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(458, 425);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Test Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(452, 419);
            this.txtLog.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableLayoutPanel3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(458, 425);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Test Settings";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label12, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.trbCatchStepsLogLevel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(452, 419);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // trbCatchStepsLogLevel
            // 
            this.trbCatchStepsLogLevel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.SetColumnSpan(this.trbCatchStepsLogLevel, 3);
            this.trbCatchStepsLogLevel.LargeChange = 1;
            this.trbCatchStepsLogLevel.Location = new System.Drawing.Point(3, 53);
            this.trbCatchStepsLogLevel.Maximum = 3;
            this.trbCatchStepsLogLevel.Minimum = 1;
            this.trbCatchStepsLogLevel.Name = "trbCatchStepsLogLevel";
            this.trbCatchStepsLogLevel.Size = new System.Drawing.Size(446, 44);
            this.trbCatchStepsLogLevel.TabIndex = 8;
            this.trbCatchStepsLogLevel.Value = 3;
            this.trbCatchStepsLogLevel.ValueChanged += new System.EventHandler(this.trbCatchStepsLogLevel_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label13, 3);
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Location = new System.Drawing.Point(3, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(446, 26);
            this.label13.TabIndex = 9;
            this.label13.Text = "How should unhandled exceptions in a test step be logged and what impact should t" +
    "hey have on the test of the test?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(370, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 319);
            this.label11.TabIndex = 5;
            this.label11.Text = "Fatal (stop test)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(153, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Warning (continue test)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Notice (continue test)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkEmailResults);
            this.tabPage2.Controls.Add(this.txtEmailResultsTo);
            this.tabPage2.Controls.Add(this.txtSmtpPassword);
            this.tabPage2.Controls.Add(this.txtSmtpUsername);
            this.tabPage2.Controls.Add(this.txtSmtpFrom);
            this.tabPage2.Controls.Add(this.txtSmtpServer);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.chkSmtpAuthentication);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.numSmtpPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Email Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Server";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(11, 33);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(187, 20);
            this.txtSmtpServer.TabIndex = 1;
            this.txtSmtpServer.TextChanged += new System.EventHandler(this.txtSmtpServer_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Port";
            // 
            // numSmtpPort
            // 
            this.numSmtpPort.Location = new System.Drawing.Point(11, 81);
            this.numSmtpPort.Name = "numSmtpPort";
            this.numSmtpPort.Size = new System.Drawing.Size(187, 20);
            this.numSmtpPort.TabIndex = 4;
            this.numSmtpPort.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSmtpPort.ValueChanged += new System.EventHandler(this.numSmtpPort_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "From Address (joe@example.com)";
            // 
            // txtSmtpFrom
            // 
            this.txtSmtpFrom.Location = new System.Drawing.Point(11, 136);
            this.txtSmtpFrom.Name = "txtSmtpFrom";
            this.txtSmtpFrom.Size = new System.Drawing.Size(187, 20);
            this.txtSmtpFrom.TabIndex = 6;
            this.txtSmtpFrom.TextChanged += new System.EventHandler(this.txtSmtpFrom_TextChanged);
            // 
            // chkSmtpAuthentication
            // 
            this.chkSmtpAuthentication.AutoSize = true;
            this.chkSmtpAuthentication.Location = new System.Drawing.Point(11, 174);
            this.chkSmtpAuthentication.Name = "chkSmtpAuthentication";
            this.chkSmtpAuthentication.Size = new System.Drawing.Size(92, 17);
            this.chkSmtpAuthentication.TabIndex = 7;
            this.chkSmtpAuthentication.Text = "Authenticate?";
            this.chkSmtpAuthentication.UseVisualStyleBackColor = true;
            this.chkSmtpAuthentication.CheckedChanged += new System.EventHandler(this.chkSmtpAuthentication_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Username";
            // 
            // txtSmtpUsername
            // 
            this.txtSmtpUsername.Location = new System.Drawing.Point(11, 226);
            this.txtSmtpUsername.Name = "txtSmtpUsername";
            this.txtSmtpUsername.Size = new System.Drawing.Size(187, 20);
            this.txtSmtpUsername.TabIndex = 9;
            this.txtSmtpUsername.TextChanged += new System.EventHandler(this.txtSmtpUsername_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Password";
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Location = new System.Drawing.Point(11, 275);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.Size = new System.Drawing.Size(187, 20);
            this.txtSmtpPassword.TabIndex = 11;
            this.txtSmtpPassword.TextChanged += new System.EventHandler(this.txtSmtpPassword_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Email Test Results To (joe@example.com)";
            // 
            // txtEmailResultsTo
            // 
            this.txtEmailResultsTo.Location = new System.Drawing.Point(253, 81);
            this.txtEmailResultsTo.Name = "txtEmailResultsTo";
            this.txtEmailResultsTo.Size = new System.Drawing.Size(187, 20);
            this.txtEmailResultsTo.TabIndex = 13;
            this.txtEmailResultsTo.TextChanged += new System.EventHandler(this.txtEmailResultsTo_TextChanged);
            // 
            // chkEmailResults
            // 
            this.chkEmailResults.AutoSize = true;
            this.chkEmailResults.Location = new System.Drawing.Point(253, 33);
            this.chkEmailResults.Name = "chkEmailResults";
            this.chkEmailResults.Size = new System.Drawing.Size(113, 17);
            this.chkEmailResults.TabIndex = 14;
            this.chkEmailResults.Text = "Email Test Results";
            this.chkEmailResults.UseVisualStyleBackColor = true;
            this.chkEmailResults.CheckedChanged += new System.EventHandler(this.chkEmailResults_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tests";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lsvTestSuite, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRunSelected, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(452, 419);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // btnRunSelected
            // 
            this.btnRunSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRunSelected.Location = new System.Drawing.Point(3, 382);
            this.btnRunSelected.Name = "btnRunSelected";
            this.btnRunSelected.Size = new System.Drawing.Size(446, 32);
            this.btnRunSelected.TabIndex = 6;
            this.btnRunSelected.Text = "RUN";
            this.btnRunSelected.UseVisualStyleBackColor = true;
            this.btnRunSelected.Visible = false;
            this.btnRunSelected.Click += new System.EventHandler(this.btnRunSelected_Click);
            // 
            // lsvTestSuite
            // 
            this.lsvTestSuite.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvTestSuite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTestSuite.FullRowSelect = true;
            this.lsvTestSuite.Location = new System.Drawing.Point(3, 3);
            this.lsvTestSuite.Name = "lsvTestSuite";
            this.lsvTestSuite.Size = new System.Drawing.Size(446, 373);
            this.lsvTestSuite.TabIndex = 5;
            this.lsvTestSuite.UseCompatibleStateImageBehavior = false;
            this.lsvTestSuite.View = System.Windows.Forms.View.Details;
            this.lsvTestSuite.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvTestSuite_ItemSelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 451);
            this.tabControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Testata";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbCatchStepsLogLevel)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer testProgressTimer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trbCatchStepsLogLevel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkEmailResults;
        private System.Windows.Forms.TextBox txtEmailResultsTo;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.TextBox txtSmtpUsername;
        private System.Windows.Forms.TextBox txtSmtpFrom;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkSmtpAuthentication;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSmtpPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView lsvTestSuite;
        private System.Windows.Forms.Button btnRunSelected;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

