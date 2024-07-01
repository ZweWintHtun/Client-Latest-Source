namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00019
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00019));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
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
            this.tsbCRUD.Size = new System.Drawing.Size(485, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtPaymentOrderNo
            // 
            this.mtxtPaymentOrderNo.Enabled = false;
            this.mtxtPaymentOrderNo.IsSendTabOnEnter = true;
            this.mtxtPaymentOrderNo.Location = new System.Drawing.Point(131, 96);
            this.mtxtPaymentOrderNo.Mask = "IR000/0000000000";
            this.mtxtPaymentOrderNo.Name = "mtxtPaymentOrderNo";
            this.mtxtPaymentOrderNo.Size = new System.Drawing.Size(115, 20);
            this.mtxtPaymentOrderNo.TabIndex = 3;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtYear.Enabled = false;
            this.txtYear.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(254, 95);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(65, 20);
            this.txtYear.TabIndex = 44;
            this.txtYear.Text = "2013/2014";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(15, 152);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(15, 99);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(100, 13);
            this.lblPaymentOrderNo.TabIndex = 0;
            this.lblPaymentOrderNo.Text = "Payment Order No.:";
            // 
            // lblRegisterNo
            // 
            this.lblRegisterNo.AutoSize = true;
            this.lblRegisterNo.Location = new System.Drawing.Point(15, 47);
            this.lblRegisterNo.Name = "lblRegisterNo";
            this.lblRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblRegisterNo.TabIndex = 0;
            this.lblRegisterNo.Text = "Register No. :";
            // 
            // txtRegisterNo
            // 
            this.txtRegisterNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRegisterNo.IsSendTabOnEnter = true;
            this.txtRegisterNo.Location = new System.Drawing.Point(131, 44);
            this.txtRegisterNo.Name = "txtRegisterNo";
            this.txtRegisterNo.Size = new System.Drawing.Size(90, 20);
            this.txtRegisterNo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 73);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 126);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(55, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Currency :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(131, 149);
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
            // 
            // txtCurrency
            // 
            this.txtCurrency.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(131, 122);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(115, 20);
            this.txtCurrency.TabIndex = 45;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(131, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 45;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MNMVEW00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 188);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtRegisterNo);
            this.Controls.Add(this.lblRegisterNo);
            this.Controls.Add(this.mtxtPaymentOrderNo);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPaymentOrderNo);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00019";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MNMVEW00019_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0001 txtYear;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0003 lblRegisterNo;
        private Windows.CXClient.Controls.CXC0001 txtRegisterNo;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0001 txtName;
    }
}