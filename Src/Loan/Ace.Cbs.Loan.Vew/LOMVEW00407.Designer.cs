namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00407
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00407));
            this.btnCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblBudgetYear = new System.Windows.Forms.Label();
            this.lblBudgetYearLabel = new System.Windows.Forms.Label();
            this.dtpStartDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.lblToDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFromDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpIntCal = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpIntCal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Money_Calculator;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCalculate.Location = new System.Drawing.Point(113, 100);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(102, 40);
            this.btnCalculate.TabIndex = 78;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblBudgetYear
            // 
            this.lblBudgetYear.AutoSize = true;
            this.lblBudgetYear.Location = new System.Drawing.Point(440, 15);
            this.lblBudgetYear.Name = "lblBudgetYear";
            this.lblBudgetYear.Size = new System.Drawing.Size(0, 13);
            this.lblBudgetYear.TabIndex = 77;
            // 
            // lblBudgetYearLabel
            // 
            this.lblBudgetYearLabel.AutoSize = true;
            this.lblBudgetYearLabel.Location = new System.Drawing.Point(363, 15);
            this.lblBudgetYearLabel.Name = "lblBudgetYearLabel";
            this.lblBudgetYearLabel.Size = new System.Drawing.Size(72, 13);
            this.lblBudgetYearLabel.TabIndex = 76;
            this.lblBudgetYearLabel.Text = "Budget Year :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IsSendTabOnEnter = true;
            this.dtpStartDate.Location = new System.Drawing.Point(113, 36);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(115, 20);
            this.dtpStartDate.TabIndex = 72;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(19, 67);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 13);
            this.lblToDate.TabIndex = 74;
            this.lblToDate.Text = "End Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(19, 39);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(61, 13);
            this.lblFromDate.TabIndex = 75;
            this.lblFromDate.Text = "Start Date :";
            // 
            // grpIntCal
            // 
            this.grpIntCal.Controls.Add(this.btnCalculate);
            this.grpIntCal.Controls.Add(this.lblBudgetYear);
            this.grpIntCal.Controls.Add(this.lblBudgetYearLabel);
            this.grpIntCal.Controls.Add(this.dtpStartDate);
            this.grpIntCal.Controls.Add(this.lblToDate);
            this.grpIntCal.Controls.Add(this.lblFromDate);
            this.grpIntCal.Controls.Add(this.dtpEndDate);
            this.grpIntCal.Location = new System.Drawing.Point(6, 37);
            this.grpIntCal.Name = "grpIntCal";
            this.grpIntCal.Size = new System.Drawing.Size(505, 148);
            this.grpIntCal.TabIndex = 78;
            this.grpIntCal.TabStop = false;
            this.grpIntCal.Text = "Business Loan Daily Interest Calculation";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IsSendTabOnEnter = true;
            this.dtpEndDate.Location = new System.Drawing.Point(113, 64);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEndDate.TabIndex = 73;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(519, 31);
            this.tsbCRUD.TabIndex = 77;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // LOMVEW00407
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 191);
            this.Controls.Add(this.grpIntCal);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00407";
            this.Text = "Business Loans Daily Interest Calculation";
            this.Load += new System.EventHandler(this.LOMVEW00407_Load);
            this.grpIntCal.ResumeLayout(false);
            this.grpIntCal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 btnCalculate;
        private System.Windows.Forms.Label lblBudgetYear;
        private System.Windows.Forms.Label lblBudgetYearLabel;
        private Windows.CXClient.Controls.CXC0005 dtpStartDate;
        private Windows.CXClient.Controls.CXC0003 lblToDate;
        private Windows.CXClient.Controls.CXC0003 lblFromDate;
        private System.Windows.Forms.GroupBox grpIntCal;
        private Windows.CXClient.Controls.CXC0005 dtpEndDate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;

    }
}