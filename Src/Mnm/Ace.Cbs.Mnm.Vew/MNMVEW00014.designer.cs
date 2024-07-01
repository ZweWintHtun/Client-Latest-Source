namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00014));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpPORegisterByCash = new System.Windows.Forms.GroupBox();
            this.rdoMultiPO = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSinglePO = new Ace.Windows.CXClient.Controls.CXC0009();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtDate = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtGroupNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtBudgetYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpPORegisterByCash.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(511, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpPORegisterByCash
            // 
            this.grpPORegisterByCash.Controls.Add(this.rdoMultiPO);
            this.grpPORegisterByCash.Controls.Add(this.rdoSinglePO);
            this.grpPORegisterByCash.Location = new System.Drawing.Point(12, 44);
            this.grpPORegisterByCash.Name = "grpPORegisterByCash";
            this.grpPORegisterByCash.Size = new System.Drawing.Size(231, 58);
            this.grpPORegisterByCash.TabIndex = 0;
            this.grpPORegisterByCash.TabStop = false;
            this.grpPORegisterByCash.Text = "Choose PO To Edit (Cash) ";
            // 
            // rdoMultiPO
            // 
            this.rdoMultiPO.AutoSize = true;
            this.rdoMultiPO.IsSendTabOnEnter = true;
            this.rdoMultiPO.Location = new System.Drawing.Point(117, 27);
            this.rdoMultiPO.Name = "rdoMultiPO";
            this.rdoMultiPO.Size = new System.Drawing.Size(65, 17);
            this.rdoMultiPO.TabIndex = 1;
            this.rdoMultiPO.Text = "Multi PO";
            this.rdoMultiPO.UseVisualStyleBackColor = false;
            this.rdoMultiPO.CheckedChanged += new System.EventHandler(this.rdoMultiPO_CheckedChanged);
            // 
            // rdoSinglePO
            // 
            this.rdoSinglePO.AutoSize = true;
            this.rdoSinglePO.IsSendTabOnEnter = true;
            this.rdoSinglePO.Location = new System.Drawing.Point(25, 27);
            this.rdoSinglePO.Name = "rdoSinglePO";
            this.rdoSinglePO.Size = new System.Drawing.Size(72, 17);
            this.rdoSinglePO.TabIndex = 0;
            this.rdoSinglePO.Text = "Single PO";
            this.rdoSinglePO.UseVisualStyleBackColor = false;
            this.rdoSinglePO.CheckedChanged += new System.EventHandler(this.rdoSinglePO_CheckedChanged);
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(11, 144);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(100, 13);
            this.lblPaymentOrderNo.TabIndex = 0;
            this.lblPaymentOrderNo.Text = "Payment Order No.:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(11, 196);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(11, 222);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(55, 13);
            this.lblCharges.TabIndex = 0;
            this.lblCharges.Text = "Charges : ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(11, 249);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date  :";
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(12, 118);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(62, 13);
            this.lblGroupNo.TabIndex = 0;
            this.lblGroupNo.Text = "Group No. :";
            // 
            // txtCharges
            // 
            this.txtCharges.DecimalPlaces = 2;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.Location = new System.Drawing.Point(128, 219);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(115, 20);
            this.txtCharges.TabIndex = 6;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(128, 193);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAmount.Validated += new System.EventHandler(this.txtAmount_Validated);
            // 
            // txtDate
            // 
            this.txtDate.IsSendTabOnEnter = true;
            this.txtDate.Location = new System.Drawing.Point(128, 245);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(115, 20);
            this.txtDate.TabIndex = 7;
            // 
            // txtCurrency
            // 
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(128, 167);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(115, 20);
            this.txtCurrency.TabIndex = 5;
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.IsSendTabOnEnter = true;
            this.txtGroupNo.Location = new System.Drawing.Point(128, 115);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(115, 20);
            this.txtGroupNo.TabIndex = 2;
            this.txtGroupNo.TabStop = false;
            this.txtGroupNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(128, 141);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 3;
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBudgetYear.IsSendTabOnEnter = true;
            this.txtBudgetYear.Location = new System.Drawing.Point(275, 141);
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.Size = new System.Drawing.Size(77, 20);
            this.txtBudgetYear.TabIndex = 0;
            // 
            // MNMVEW00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 282);
            this.Controls.Add(this.txtBudgetYear);
            this.Controls.Add(this.txtPaymentOrderNo);
            this.Controls.Add(this.txtGroupNo);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.grpPORegisterByCash);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCharges);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPaymentOrderNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00014";
            this.Text = "PO Edit By Cash";
            this.Load += new System.EventHandler(this.MNMVEW00014_Load);
            this.Move += new System.EventHandler(this.MNMVEW00014_Move);
            this.grpPORegisterByCash.ResumeLayout(false);
            this.grpPORegisterByCash.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpPORegisterByCash;
        private Windows.CXClient.Controls.CXC0009 rdoMultiPO;
        private Windows.CXClient.Controls.CXC0009 rdoSinglePO;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0003 lblDate;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtDate;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0006 txtGroupNo;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0006 txtBudgetYear;
    }
}