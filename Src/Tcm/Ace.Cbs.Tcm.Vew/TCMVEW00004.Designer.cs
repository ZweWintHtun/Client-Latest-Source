namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00004
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00004));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtBudgetYear = new System.Windows.Forms.TextBox();
            this.txtPaymentOrderNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-5, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(502, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.TabStop = false;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.txtRegisterNo);
            this.groupBox2.Controls.Add(this.txtCurrency);
            this.groupBox2.Controls.Add(this.txtBudgetYear);
            this.groupBox2.Controls.Add(this.txtPaymentOrderNo);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.cxC00031);
            this.groupBox2.Controls.Add(this.cxC00032);
            this.groupBox2.Controls.Add(this.cxC00033);
            this.groupBox2.Controls.Add(this.cxC00034);
            this.groupBox2.Controls.Add(this.cxC00035);
            this.groupBox2.Location = new System.Drawing.Point(12, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 196);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Order Issue Information";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 0;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(173, 155);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtRegisterNo
            // 
            this.txtRegisterNo.IsSendTabOnEnter = true;
            this.txtRegisterNo.Location = new System.Drawing.Point(173, 26);
            this.txtRegisterNo.Name = "txtRegisterNo";
            this.txtRegisterNo.Size = new System.Drawing.Size(111, 20);
            this.txtRegisterNo.TabIndex = 1;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(173, 123);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(111, 20);
            this.txtCurrency.TabIndex = 0;
            // 
            // txtBudgetYear
            // 
            this.txtBudgetYear.Location = new System.Drawing.Point(303, 91);
            this.txtBudgetYear.Name = "txtBudgetYear";
            this.txtBudgetYear.ReadOnly = true;
            this.txtBudgetYear.Size = new System.Drawing.Size(100, 20);
            this.txtBudgetYear.TabIndex = 0;
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(173, 91);
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.ReadOnly = true;
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(111, 20);
            this.txtPaymentOrderNo.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(173, 59);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(230, 20);
            this.txtName.TabIndex = 0;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(53, 62);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(35, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Name";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(53, 94);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(94, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "PaymentOrder No.";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(53, 126);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(49, 13);
            this.cxC00033.TabIndex = 0;
            this.cxC00033.Text = "Currency";
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(53, 158);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(43, 13);
            this.cxC00034.TabIndex = 0;
            this.cxC00034.Text = "Amount";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(53, 29);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(66, 13);
            this.cxC00035.TabIndex = 0;
            this.cxC00035.Text = "Register No.";
            // 
            // TCMVEW00004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 247);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00004";
            this.Text = "Payment Order Issue For Encashment Entry";
            this.Load += new System.EventHandler(this.TCMVEW00004_Load);
            this.Move += new System.EventHandler(this.TCMVEW00004_Move);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox2;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtRegisterNo;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtBudgetYear;
        private System.Windows.Forms.TextBox txtPaymentOrderNo;
        private System.Windows.Forms.TextBox txtName;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        //private Windows.CXClient.Controls.CXC0006 txtName;
        //private Windows.CXClient.Controls.CXC0006 txtPaymentOrderNo;
        //private Windows.CXClient.Controls.CXC0006 txtBudgetYear;
        //private Windows.CXClient.Controls.CXC0006 txtCurrency;
        //private Windows.CXClient.Controls.CXC0004 txtAmount;
        //private System.Windows.Forms.TextBox txtRegisterNo;
    }
}