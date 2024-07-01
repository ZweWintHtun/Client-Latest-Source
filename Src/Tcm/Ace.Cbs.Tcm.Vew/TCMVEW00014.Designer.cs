namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00014));
            this.gbSystemInformation = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBankHead = new System.Windows.Forms.Label();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblSystemDate = new System.Windows.Forms.Label();
            this.lblBranchDescription = new System.Windows.Forms.Label();
            this.butStartUp = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbSystemInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSystemInformation
            // 
            this.gbSystemInformation.Controls.Add(this.lblStatus);
            this.gbSystemInformation.Controls.Add(this.lblDate);
            this.gbSystemInformation.Controls.Add(this.lblBankHead);
            this.gbSystemInformation.Controls.Add(this.lblSystemStatus);
            this.gbSystemInformation.Controls.Add(this.lblSystemDate);
            this.gbSystemInformation.Controls.Add(this.lblBranchDescription);
            this.gbSystemInformation.ForeColor = System.Drawing.Color.SteelBlue;
            this.gbSystemInformation.Location = new System.Drawing.Point(12, 21);
            this.gbSystemInformation.Name = "gbSystemInformation";
            this.gbSystemInformation.Size = new System.Drawing.Size(384, 131);
            this.gbSystemInformation.TabIndex = 0;
            this.gbSystemInformation.TabStop = false;
            this.gbSystemInformation.Text = "System Information";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(169, 95);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(169, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 13);
            this.lblDate.TabIndex = 4;
            // 
            // lblBankHead
            // 
            this.lblBankHead.AutoSize = true;
            this.lblBankHead.Location = new System.Drawing.Point(169, 26);
            this.lblBankHead.Name = "lblBankHead";
            this.lblBankHead.Size = new System.Drawing.Size(0, 13);
            this.lblBankHead.TabIndex = 3;
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Location = new System.Drawing.Point(19, 95);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(74, 13);
            this.lblSystemStatus.TabIndex = 2;
            this.lblSystemStatus.Text = "System Status";
            // 
            // lblSystemDate
            // 
            this.lblSystemDate.AutoSize = true;
            this.lblSystemDate.Location = new System.Drawing.Point(19, 60);
            this.lblSystemDate.Name = "lblSystemDate";
            this.lblSystemDate.Size = new System.Drawing.Size(67, 13);
            this.lblSystemDate.TabIndex = 1;
            this.lblSystemDate.Text = "System Date";
            // 
            // lblBranchDescription
            // 
            this.lblBranchDescription.AutoSize = true;
            this.lblBranchDescription.Location = new System.Drawing.Point(19, 26);
            this.lblBranchDescription.Name = "lblBranchDescription";
            this.lblBranchDescription.Size = new System.Drawing.Size(97, 13);
            this.lblBranchDescription.TabIndex = 0;
            this.lblBranchDescription.Text = "Branch Description";
            // 
            // butStartUp
            // 
            this.butStartUp.Image = ((System.Drawing.Image)(resources.GetObject("butStartUp.Image")));
            this.butStartUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butStartUp.Location = new System.Drawing.Point(406, 113);
            this.butStartUp.Name = "butStartUp";
            this.butStartUp.Size = new System.Drawing.Size(74, 39);
            this.butStartUp.TabIndex = 7;
            this.butStartUp.Text = "Start Up";
            this.butStartUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butStartUp.UseVisualStyleBackColor = true;
            this.butStartUp.Click += new System.EventHandler(this.butStartUp_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // TCMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 176);
            this.ControlBox = false;
            this.Controls.Add(this.butStartUp);
            this.Controls.Add(this.gbSystemInformation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00014";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Start Up";
            this.Load += new System.EventHandler(this.TCMVEW00014_Load);
            this.gbSystemInformation.ResumeLayout(false);
            this.gbSystemInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSystemInformation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblBankHead;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Label lblSystemDate;
        private System.Windows.Forms.Label lblBranchDescription;
        private System.Windows.Forms.Button butStartUp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}