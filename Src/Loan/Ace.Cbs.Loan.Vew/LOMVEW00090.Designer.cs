namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00090
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00090));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.pInterestBudgetYear = new System.Windows.Forms.Panel();
            this.txtToDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtFromDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cboMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInterestBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.pInterestBudgetYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(502, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // pInterestBudgetYear
            // 
            this.pInterestBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInterestBudgetYear.Controls.Add(this.txtToDate);
            this.pInterestBudgetYear.Controls.Add(this.txtFromDate);
            this.pInterestBudgetYear.Controls.Add(this.cboMonth);
            this.pInterestBudgetYear.Controls.Add(this.cxC00031);
            this.pInterestBudgetYear.Controls.Add(this.cxC00033);
            this.pInterestBudgetYear.Controls.Add(this.cxC00032);
            this.pInterestBudgetYear.Controls.Add(this.lblInterestBudgetYear);
            this.pInterestBudgetYear.Location = new System.Drawing.Point(12, 40);
            this.pInterestBudgetYear.Name = "pInterestBudgetYear";
            this.pInterestBudgetYear.Size = new System.Drawing.Size(476, 91);
            this.pInterestBudgetYear.TabIndex = 3;
            // 
            // txtToDate
            // 
            this.txtToDate.Enabled = false;
            this.txtToDate.IsSendTabOnEnter = true;
            this.txtToDate.Location = new System.Drawing.Point(288, 18);
            this.txtToDate.MaxLength = 4;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(67, 20);
            this.txtToDate.TabIndex = 0;
            this.txtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToDate_KeyPress);
            this.txtToDate.Leave += new System.EventHandler(this.txtToDate_Leave);
            // 
            // txtFromDate
            // 
            this.txtFromDate.IsSendTabOnEnter = true;
            this.txtFromDate.Location = new System.Drawing.Point(186, 18);
            this.txtFromDate.MaxLength = 10;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = true;
            this.txtFromDate.Size = new System.Drawing.Size(67, 20);
            this.txtFromDate.TabIndex = 16;
            this.txtFromDate.TabStop = false;
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DropDownHeight = 200;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.IntegralHeight = false;
            this.cboMonth.IsSendTabOnEnter = true;
            this.cboMonth.Location = new System.Drawing.Point(150, 50);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(142, 21);
            this.cboMonth.TabIndex = 1;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(19, 54);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(115, 13);
            this.cxC00031.TabIndex = 13;
            this.cxC00031.Text = "Interest Budget Month:";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cxC00033.Location = new System.Drawing.Point(259, 21);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(23, 13);
            this.cxC00033.TabIndex = 13;
            this.cxC00033.Text = "To:";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cxC00032.Location = new System.Drawing.Point(147, 21);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(33, 13);
            this.cxC00032.TabIndex = 13;
            this.cxC00032.Text = "From:";
            // 
            // lblInterestBudgetYear
            // 
            this.lblInterestBudgetYear.AutoSize = true;
            this.lblInterestBudgetYear.Location = new System.Drawing.Point(19, 21);
            this.lblInterestBudgetYear.Name = "lblInterestBudgetYear";
            this.lblInterestBudgetYear.Size = new System.Drawing.Size(107, 13);
            this.lblInterestBudgetYear.TabIndex = 13;
            this.lblInterestBudgetYear.Text = "Interest Budget Year:";
            // 
            // LOMVEW00090
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 143);
            this.Controls.Add(this.pInterestBudgetYear);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00090";
            this.Text = "Farm Loan Interest Calculation (Monthly)";
            this.Load += new System.EventHandler(this.LOMVEW00090_Load);
            this.pInterestBudgetYear.ResumeLayout(false);
            this.pInterestBudgetYear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Panel pInterestBudgetYear;
        private Windows.CXClient.Controls.CXC0001 txtToDate;
        private Windows.CXClient.Controls.CXC0001 txtFromDate;
        private Windows.CXClient.Controls.CXC0002 cboMonth;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblInterestBudgetYear;
    }
}