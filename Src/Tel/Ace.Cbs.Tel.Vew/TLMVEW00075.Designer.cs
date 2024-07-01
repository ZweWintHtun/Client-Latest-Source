namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00075
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00075));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPONo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPONo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(489, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(92, 208);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(164, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(13, 46);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Enabled = false;
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(92, 182);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(164, 20);
            this.txtCurrency.TabIndex = 0;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(13, 73);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 15;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(92, 96);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(164, 54);
            this.txtDescription.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Description :";
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Location = new System.Drawing.Point(13, 160);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(48, 13);
            this.lblPONo.TabIndex = 14;
            this.lblPONo.Text = "PO No. :";
            // 
            // txtPONo
            // 
            this.txtPONo.Enabled = false;
            this.txtPONo.IsSendTabOnEnter = true;
            this.txtPONo.Location = new System.Drawing.Point(92, 156);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(164, 20);
            this.txtPONo.TabIndex = 0;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 186);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 18;
            this.lblCurrency.Text = "Currency :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(92, 70);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(164, 20);
            this.mtxtAccountNo.TabIndex = 0;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(13, 211);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 17;
            this.lblAmount.Text = "Amount :";
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(92, 43);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(164, 20);
            this.txtEntryNo.TabIndex = 1;
            this.txtEntryNo.Leave += new System.EventHandler(this.txtEntryNo_Leave);
            this.txtEntryNo.Validated += new System.EventHandler(this.txtEntryNo_Validated);
            // 
            // TLMVEW00075
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 246);
            this.Controls.Add(this.txtEntryNo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblEntryNo);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPONo);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00075";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Payment Denomination Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00075_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TLMVEW00075_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0003 lblPONo;
        private Windows.CXClient.Controls.CXC0006 txtPONo;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0006 txtEntryNo;
    }
}