namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00008));
            this.txtCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gbIncome = new System.Windows.Forms.GroupBox();
            this.rdoTakeIncomeFromAmount = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoTakeIncomeSeperately = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranchNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.label2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIncome = new Ace.Windows.CXClient.Controls.CXC0004();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtRemittanceAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblCommunicationCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblIncome = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRemittanceAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBranchNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbRemittanceCalculator = new System.Windows.Forms.GroupBox();
            this.gbIncome.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRemittanceCalculator.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommunicationCharges
            // 
            this.txtCommunicationCharges.DecimalPlaces = 2;
            this.txtCommunicationCharges.IsSendTabOnEnter = true;
            this.txtCommunicationCharges.Location = new System.Drawing.Point(164, 68);
            this.txtCommunicationCharges.Name = "txtCommunicationCharges";
            this.txtCommunicationCharges.ReadOnly = true;
            this.txtCommunicationCharges.Size = new System.Drawing.Size(100, 20);
            this.txtCommunicationCharges.TabIndex = 100;
            this.txtCommunicationCharges.Text = "0.00";
            this.txtCommunicationCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommunicationCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbIncome
            // 
            this.gbIncome.Controls.Add(this.rdoTakeIncomeFromAmount);
            this.gbIncome.Controls.Add(this.rdoTakeIncomeSeperately);
            this.gbIncome.Location = new System.Drawing.Point(20, 114);
            this.gbIncome.Name = "gbIncome";
            this.gbIncome.Size = new System.Drawing.Size(411, 49);
            this.gbIncome.TabIndex = 4;
            this.gbIncome.TabStop = false;
            // 
            // rdoTakeIncomeFromAmount
            // 
            this.rdoTakeIncomeFromAmount.AutoSize = true;
            this.rdoTakeIncomeFromAmount.IsSendTabOnEnter = true;
            this.rdoTakeIncomeFromAmount.Location = new System.Drawing.Point(197, 19);
            this.rdoTakeIncomeFromAmount.Name = "rdoTakeIncomeFromAmount";
            this.rdoTakeIncomeFromAmount.Size = new System.Drawing.Size(200, 17);
            this.rdoTakeIncomeFromAmount.TabIndex = 5;
            this.rdoTakeIncomeFromAmount.Text = "Take income from remittance amount";
            this.rdoTakeIncomeFromAmount.UseVisualStyleBackColor = true;
            // 
            // rdoTakeIncomeSeperately
            // 
            this.rdoTakeIncomeSeperately.AutoSize = true;
            this.rdoTakeIncomeSeperately.Checked = true;
            this.rdoTakeIncomeSeperately.IsSendTabOnEnter = true;
            this.rdoTakeIncomeSeperately.Location = new System.Drawing.Point(15, 19);
            this.rdoTakeIncomeSeperately.Name = "rdoTakeIncomeSeperately";
            this.rdoTakeIncomeSeperately.Size = new System.Drawing.Size(138, 17);
            this.rdoTakeIncomeSeperately.TabIndex = 4;
            this.rdoTakeIncomeSeperately.TabStop = true;
            this.rdoTakeIncomeSeperately.Text = "Take income seperately";
            this.rdoTakeIncomeSeperately.UseVisualStyleBackColor = true;
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(102, 56);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // cboBranchNo
            // 
            this.cboBranchNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchNo.DropDownHeight = 200;
            this.cboBranchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchNo.FormattingEnabled = true;
            this.cboBranchNo.IntegralHeight = false;
            this.cboBranchNo.IsSendTabOnEnter = true;
            this.cboBranchNo.Location = new System.Drawing.Point(102, 24);
            this.cboBranchNo.Name = "cboBranchNo";
            this.cboBranchNo.Size = new System.Drawing.Size(141, 21);
            this.cboBranchNo.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(102, 88);
            this.txtAmount.MaxLength = 13;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Amount :";
            // 
            // txtIncome
            // 
            this.txtIncome.DecimalPlaces = 2;
            this.txtIncome.IsSendTabOnEnter = true;
            this.txtIncome.Location = new System.Drawing.Point(164, 42);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.ReadOnly = true;
            this.txtIncome.Size = new System.Drawing.Size(100, 20);
            this.txtIncome.TabIndex = 999;
            this.txtIncome.Text = "0.00";
            this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncome.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCalculate);
            this.groupBox1.Controls.Add(this.txtCommunicationCharges);
            this.groupBox1.Controls.Add(this.txtIncome);
            this.groupBox1.Controls.Add(this.txtRemittanceAmount);
            this.groupBox1.Controls.Add(this.lblCommunicationCharges);
            this.groupBox1.Controls.Add(this.lblIncome);
            this.groupBox1.Controls.Add(this.lblRemittanceAmount);
            this.groupBox1.Location = new System.Drawing.Point(21, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // butCalculate
            // 
            this.butCalculate.Image = global::Ace.Cbs.Tel.Vew.Properties.Resources.Money_Calculator;
            this.butCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCalculate.Location = new System.Drawing.Point(303, 62);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(92, 30);
            this.butCalculate.TabIndex = 6;
            this.butCalculate.Text = "&Calculate";
            this.butCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCalculate.UseVisualStyleBackColor = true;
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // txtRemittanceAmount
            // 
            this.txtRemittanceAmount.DecimalPlaces = 2;
            this.txtRemittanceAmount.IsSendTabOnEnter = true;
            this.txtRemittanceAmount.Location = new System.Drawing.Point(164, 16);
            this.txtRemittanceAmount.Name = "txtRemittanceAmount";
            this.txtRemittanceAmount.ReadOnly = true;
            this.txtRemittanceAmount.Size = new System.Drawing.Size(100, 20);
            this.txtRemittanceAmount.TabIndex = 998;
            this.txtRemittanceAmount.Text = "0.00";
            this.txtRemittanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRemittanceAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblCommunicationCharges
            // 
            this.lblCommunicationCharges.AutoSize = true;
            this.lblCommunicationCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunicationCharges.Location = new System.Drawing.Point(20, 71);
            this.lblCommunicationCharges.Name = "lblCommunicationCharges";
            this.lblCommunicationCharges.Size = new System.Drawing.Size(127, 13);
            this.lblCommunicationCharges.TabIndex = 0;
            this.lblCommunicationCharges.Text = "Communication Charges :";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.Location = new System.Drawing.Point(20, 45);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(48, 13);
            this.lblIncome.TabIndex = 2;
            this.lblIncome.Text = "Income :";
            // 
            // lblRemittanceAmount
            // 
            this.lblRemittanceAmount.AutoSize = true;
            this.lblRemittanceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemittanceAmount.Location = new System.Drawing.Point(20, 19);
            this.lblRemittanceAmount.Name = "lblRemittanceAmount";
            this.lblRemittanceAmount.Size = new System.Drawing.Size(106, 13);
            this.lblRemittanceAmount.TabIndex = 1;
            this.lblRemittanceAmount.Text = "Remittance Amount :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.Location = new System.Drawing.Point(18, 59);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 2;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblBranchNo
            // 
            this.lblBranchNo.AutoSize = true;
            this.lblBranchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchNo.Location = new System.Drawing.Point(18, 27);
            this.lblBranchNo.Name = "lblBranchNo";
            this.lblBranchNo.Size = new System.Drawing.Size(64, 13);
            this.lblBranchNo.TabIndex = 1;
            this.lblBranchNo.Text = "Branch No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(477, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbRemittanceCalculator
            // 
            this.gbRemittanceCalculator.Controls.Add(this.lblBranchNo);
            this.gbRemittanceCalculator.Controls.Add(this.gbIncome);
            this.gbRemittanceCalculator.Controls.Add(this.lblCurrency);
            this.gbRemittanceCalculator.Controls.Add(this.cboCurrency);
            this.gbRemittanceCalculator.Controls.Add(this.groupBox1);
            this.gbRemittanceCalculator.Controls.Add(this.cboBranchNo);
            this.gbRemittanceCalculator.Controls.Add(this.label2);
            this.gbRemittanceCalculator.Controls.Add(this.txtAmount);
            this.gbRemittanceCalculator.Location = new System.Drawing.Point(15, 40);
            this.gbRemittanceCalculator.Name = "gbRemittanceCalculator";
            this.gbRemittanceCalculator.Size = new System.Drawing.Size(448, 285);
            this.gbRemittanceCalculator.TabIndex = 0;
            this.gbRemittanceCalculator.TabStop = false;
            this.gbRemittanceCalculator.Text = "Remittance Calculator";
            // 
            // TLMVEW00008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 339);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbRemittanceCalculator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00008";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance Calculator";
            this.Load += new System.EventHandler(this.TLMVEW00008_Load);
            this.gbIncome.ResumeLayout(false);
            this.gbIncome.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRemittanceCalculator.ResumeLayout(false);
            this.gbRemittanceCalculator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0004 txtCommunicationCharges;
        private System.Windows.Forms.GroupBox gbIncome;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTakeIncomeFromAmount;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoTakeIncomeSeperately;
        private Ace.Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Ace.Windows.CXClient.Controls.CXC0002 cboBranchNo;
        private Ace.Windows.CXClient.Controls.CXC0004 txtAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 label2;
        private Ace.Windows.CXClient.Controls.CXC0004 txtIncome;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ace.Windows.CXClient.Controls.CXC0004 txtRemittanceAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCommunicationCharges;
        private Ace.Windows.CXClient.Controls.CXC0003 lblIncome;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRemittanceAmount;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Ace.Windows.CXClient.Controls.CXC0003 lblBranchNo;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0007 butCalculate;
        private System.Windows.Forms.GroupBox gbRemittanceCalculator;
    }
}