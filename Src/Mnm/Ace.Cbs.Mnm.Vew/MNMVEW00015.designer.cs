namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00015
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00015));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCharges = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblToCredit = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpName = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtCharges = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtPaymentOrderNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpName.SuspendLayout();
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
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblPaymentOrderNo
            // 
            this.lblPaymentOrderNo.AutoSize = true;
            this.lblPaymentOrderNo.Location = new System.Drawing.Point(12, 50);
            this.lblPaymentOrderNo.Name = "lblPaymentOrderNo";
            this.lblPaymentOrderNo.Size = new System.Drawing.Size(100, 13);
            this.lblPaymentOrderNo.TabIndex = 8;
            this.lblPaymentOrderNo.Text = "Payment Order No.:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 76);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "Amount :";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Location = new System.Drawing.Point(12, 102);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(55, 13);
            this.lblCharges.TabIndex = 10;
            this.lblCharges.Text = "Charges : ";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 129);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 11;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblToCredit
            // 
            this.lblToCredit.AutoSize = true;
            this.lblToCredit.Location = new System.Drawing.Point(10, 147);
            this.lblToCredit.Name = "lblToCredit";
            this.lblToCredit.Size = new System.Drawing.Size(82, 13);
            this.lblToCredit.TabIndex = 12;
            this.lblToCredit.Text = "(To be credited)";
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.lblName);
            this.grpName.Location = new System.Drawing.Point(15, 175);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(229, 49);
            this.grpName.TabIndex = 5;
            this.grpName.TabStop = false;
            this.grpName.Text = "Name(s)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 6;
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(129, 125);
            this.mtxtAccountNo.Mask = "&&&-&&&-&&&&&&&&&";
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ReadOnly = true;
            this.mtxtAccountNo.Size = new System.Drawing.Size(115, 20);
            this.mtxtAccountNo.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(129, 73);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtCharges
            // 
            this.txtCharges.DecimalPlaces = 2;
            this.txtCharges.IsSendTabOnEnter = true;
            this.txtCharges.Location = new System.Drawing.Point(129, 99);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(115, 20);
            this.txtCharges.TabIndex = 3;
            this.txtCharges.Text = "0.00";
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtPaymentOrderNo
            // 
            this.txtPaymentOrderNo.IsSendTabOnEnter = true;
            this.txtPaymentOrderNo.Location = new System.Drawing.Point(128, 47);
            this.txtPaymentOrderNo.MaxLength = 16;
            this.txtPaymentOrderNo.Name = "txtPaymentOrderNo";
            this.txtPaymentOrderNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaymentOrderNo.TabIndex = 1;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtYear.IsSendTabOnEnter = true;
            this.txtYear.Location = new System.Drawing.Point(275, 47);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(77, 20);
            this.txtYear.TabIndex = 7;
            // 
            // MNMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 239);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtPaymentOrderNo);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.grpName);
            this.Controls.Add(this.lblToCredit);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblCharges);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPaymentOrderNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00015";
            this.Text = "Cancel for Issued of PO By Transfer with Single Account";
            this.Load += new System.EventHandler(this.MNMVEW00015_Load);
            this.Move += new System.EventHandler(this.MNMVEW00015_Move);
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblCharges;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblToCredit;
        private System.Windows.Forms.GroupBox grpName;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0004 txtCharges;
        private System.Windows.Forms.Label lblName;
        private Windows.CXClient.Controls.CXC0001 txtPaymentOrderNo;
        private Windows.CXClient.Controls.CXC0006 txtYear;
    }
}