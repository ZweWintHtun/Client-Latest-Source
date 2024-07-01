namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00023
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00023));
            this.txtToDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtFromDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cboMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInterestBudgetYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.rdoMonthly = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoQuaterly = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPeriod1 = new Ace.Windows.CXClient.Controls.CXC0009();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoPeriod2 = new Ace.Windows.CXClient.Controls.CXC0009();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoPeriod3 = new Ace.Windows.CXClient.Controls.CXC0009();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoPeriod4 = new Ace.Windows.CXClient.Controls.CXC0009();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpMonthly = new System.Windows.Forms.GroupBox();
            this.grpQuaterly = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpMonthly.SuspendLayout();
            this.grpQuaterly.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtToDate
            // 
            this.txtToDate.IsSendTabOnEnter = true;
            this.txtToDate.Location = new System.Drawing.Point(291, 22);
            this.txtToDate.MaxLength = 4;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ReadOnly = true;
            this.txtToDate.Size = new System.Drawing.Size(67, 20);
            this.txtToDate.TabIndex = 0;
            this.txtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToDate_KeyPress);
            this.txtToDate.Leave += new System.EventHandler(this.txtToDate_Leave);
            // 
            // txtFromDate
            // 
            this.txtFromDate.IsSendTabOnEnter = true;
            this.txtFromDate.Location = new System.Drawing.Point(189, 22);
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
            this.cboMonth.Location = new System.Drawing.Point(153, 27);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(142, 21);
            this.cboMonth.TabIndex = 1;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(22, 31);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(115, 13);
            this.cxC00031.TabIndex = 13;
            this.cxC00031.Text = "Interest Budget Month:";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cxC00033.Location = new System.Drawing.Point(262, 25);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(23, 13);
            this.cxC00033.TabIndex = 13;
            this.cxC00033.Text = "To:";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cxC00032.Location = new System.Drawing.Point(150, 25);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(33, 13);
            this.cxC00032.TabIndex = 13;
            this.cxC00032.Text = "From:";
            // 
            // lblInterestBudgetYear
            // 
            this.lblInterestBudgetYear.AutoSize = true;
            this.lblInterestBudgetYear.Location = new System.Drawing.Point(23, 25);
            this.lblInterestBudgetYear.Name = "lblInterestBudgetYear";
            this.lblInterestBudgetYear.Size = new System.Drawing.Size(107, 13);
            this.lblInterestBudgetYear.TabIndex = 13;
            this.lblInterestBudgetYear.Text = "Interest Budget Year:";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(505, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.IsSendTabOnEnter = true;
            this.rdoMonthly.Location = new System.Drawing.Point(26, 48);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 17;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdoQuaterly
            // 
            this.rdoQuaterly.AutoSize = true;
            this.rdoQuaterly.Enabled = false;
            this.rdoQuaterly.IsSendTabOnEnter = true;
            this.rdoQuaterly.Location = new System.Drawing.Point(139, 48);
            this.rdoQuaterly.Name = "rdoQuaterly";
            this.rdoQuaterly.Size = new System.Drawing.Size(64, 17);
            this.rdoQuaterly.TabIndex = 18;
            this.rdoQuaterly.Text = "Quaterly";
            this.rdoQuaterly.UseVisualStyleBackColor = true;
            this.rdoQuaterly.Visible = false;
            this.rdoQuaterly.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdoPeriod1
            // 
            this.rdoPeriod1.AutoSize = true;
            this.rdoPeriod1.IsSendTabOnEnter = true;
            this.rdoPeriod1.Location = new System.Drawing.Point(26, 18);
            this.rdoPeriod1.Name = "rdoPeriod1";
            this.rdoPeriod1.Size = new System.Drawing.Size(61, 17);
            this.rdoPeriod1.TabIndex = 18;
            this.rdoPeriod1.Text = "Period1";
            this.rdoPeriod1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(105, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "From April to June";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(105, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "From July to September";
            // 
            // rdoPeriod2
            // 
            this.rdoPeriod2.AutoSize = true;
            this.rdoPeriod2.IsSendTabOnEnter = true;
            this.rdoPeriod2.Location = new System.Drawing.Point(26, 41);
            this.rdoPeriod2.Name = "rdoPeriod2";
            this.rdoPeriod2.Size = new System.Drawing.Size(61, 17);
            this.rdoPeriod2.TabIndex = 20;
            this.rdoPeriod2.Text = "Period2";
            this.rdoPeriod2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(105, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "From October to December";
            // 
            // rdoPeriod3
            // 
            this.rdoPeriod3.AutoSize = true;
            this.rdoPeriod3.IsSendTabOnEnter = true;
            this.rdoPeriod3.Location = new System.Drawing.Point(26, 64);
            this.rdoPeriod3.Name = "rdoPeriod3";
            this.rdoPeriod3.Size = new System.Drawing.Size(61, 17);
            this.rdoPeriod3.TabIndex = 22;
            this.rdoPeriod3.Text = "Period3";
            this.rdoPeriod3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(105, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "From January to March";
            // 
            // rdoPeriod4
            // 
            this.rdoPeriod4.AutoSize = true;
            this.rdoPeriod4.IsSendTabOnEnter = true;
            this.rdoPeriod4.Location = new System.Drawing.Point(26, 87);
            this.rdoPeriod4.Name = "rdoPeriod4";
            this.rdoPeriod4.Size = new System.Drawing.Size(61, 17);
            this.rdoPeriod4.TabIndex = 24;
            this.rdoPeriod4.Text = "Period4";
            this.rdoPeriod4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoQuaterly);
            this.groupBox1.Controls.Add(this.cxC00032);
            this.groupBox1.Controls.Add(this.rdoMonthly);
            this.groupBox1.Controls.Add(this.lblInterestBudgetYear);
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.cxC00033);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 83);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // grpMonthly
            // 
            this.grpMonthly.Controls.Add(this.cboMonth);
            this.grpMonthly.Controls.Add(this.cxC00031);
            this.grpMonthly.Location = new System.Drawing.Point(12, 122);
            this.grpMonthly.Name = "grpMonthly";
            this.grpMonthly.Size = new System.Drawing.Size(476, 66);
            this.grpMonthly.TabIndex = 14;
            this.grpMonthly.TabStop = false;
            this.grpMonthly.Text = "By Monthly";
            // 
            // grpQuaterly
            // 
            this.grpQuaterly.Controls.Add(this.label4);
            this.grpQuaterly.Controls.Add(this.rdoPeriod2);
            this.grpQuaterly.Controls.Add(this.rdoPeriod4);
            this.grpQuaterly.Controls.Add(this.rdoPeriod1);
            this.grpQuaterly.Controls.Add(this.label3);
            this.grpQuaterly.Controls.Add(this.label1);
            this.grpQuaterly.Controls.Add(this.rdoPeriod3);
            this.grpQuaterly.Controls.Add(this.label2);
            this.grpQuaterly.Enabled = false;
            this.grpQuaterly.Location = new System.Drawing.Point(12, 124);
            this.grpQuaterly.Name = "grpQuaterly";
            this.grpQuaterly.Size = new System.Drawing.Size(476, 116);
            this.grpQuaterly.TabIndex = 19;
            this.grpQuaterly.TabStop = false;
            this.grpQuaterly.Text = "By Quaterly";
            this.grpQuaterly.Visible = false;
            // 
            // LOMVEW00023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 248);
            this.Controls.Add(this.grpMonthly);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpQuaterly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00023";
            this.Text = "Loan Interest Calculation";
            this.Load += new System.EventHandler(this.LOMVEW00023_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMonthly.ResumeLayout(false);
            this.grpMonthly.PerformLayout();
            this.grpQuaterly.ResumeLayout(false);
            this.grpQuaterly.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblInterestBudgetYear;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboMonth;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0001 txtToDate;
        private Windows.CXClient.Controls.CXC0001 txtFromDate;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0009 rdoQuaterly;
        private Windows.CXClient.Controls.CXC0009 rdoMonthly;
        private System.Windows.Forms.Label label4;
        private Windows.CXClient.Controls.CXC0009 rdoPeriod4;
        private System.Windows.Forms.Label label3;
        private Windows.CXClient.Controls.CXC0009 rdoPeriod3;
        private System.Windows.Forms.Label label2;
        private Windows.CXClient.Controls.CXC0009 rdoPeriod2;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXC0009 rdoPeriod1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpMonthly;
        private System.Windows.Forms.GroupBox grpQuaterly;
    }
}