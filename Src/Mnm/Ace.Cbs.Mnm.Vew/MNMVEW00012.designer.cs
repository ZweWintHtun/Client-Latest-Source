namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00012
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00012));
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblReceivedNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPaySlipNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblReceivedBank = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtPONo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtBudget = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtReceivedBank = new System.Windows.Forms.TextBox();
            this.txtPaySlipNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(9, 100);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(85, 13);
            this.lblAmount.TabIndex = 18;
            this.lblAmount.Text = "Amount             :";
            // 
            // lblReceivedNo
            // 
            this.lblReceivedNo.AutoSize = true;
            this.lblReceivedNo.Location = new System.Drawing.Point(9, 74);
            this.lblReceivedNo.Name = "lblReceivedNo";
            this.lblReceivedNo.Size = new System.Drawing.Size(84, 13);
            this.lblReceivedNo.TabIndex = 17;
            this.lblReceivedNo.Text = "PO No.             :";
            // 
            // lblPaySlipNo
            // 
            this.lblPaySlipNo.AutoSize = true;
            this.lblPaySlipNo.Location = new System.Drawing.Point(9, 48);
            this.lblPaySlipNo.Name = "lblPaySlipNo";
            this.lblPaySlipNo.Size = new System.Drawing.Size(85, 13);
            this.lblPaySlipNo.TabIndex = 16;
            this.lblPaySlipNo.Text = "Pay in Slip No.  :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(508, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblReceivedBank
            // 
            this.lblReceivedBank.AutoSize = true;
            this.lblReceivedBank.Location = new System.Drawing.Point(9, 127);
            this.lblReceivedBank.Name = "lblReceivedBank";
            this.lblReceivedBank.Size = new System.Drawing.Size(84, 13);
            this.lblReceivedBank.TabIndex = 18;
            this.lblReceivedBank.Text = "Received Bank:";
            // 
            // mtxtPONo
            // 
            this.mtxtPONo.BackColor = System.Drawing.Color.White;
            this.mtxtPONo.IsSendTabOnEnter = true;
            this.mtxtPONo.Location = new System.Drawing.Point(124, 71);
            this.mtxtPONo.Name = "mtxtPONo";
            this.mtxtPONo.Size = new System.Drawing.Size(141, 20);
            this.mtxtPONo.TabIndex = 2;
            // 
            // txtBudget
            // 
            this.txtBudget.BackColor = System.Drawing.Color.White;
            this.txtBudget.IsSendTabOnEnter = true;
            this.txtBudget.Location = new System.Drawing.Point(283, 71);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.ReadOnly = true;
            this.txtBudget.Size = new System.Drawing.Size(80, 20);
            this.txtBudget.TabIndex = 25;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(124, 97);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtReceivedBank
            // 
            this.txtReceivedBank.BackColor = System.Drawing.Color.White;
            this.txtReceivedBank.Location = new System.Drawing.Point(124, 127);
            this.txtReceivedBank.Name = "txtReceivedBank";
            this.txtReceivedBank.ReadOnly = true;
            this.txtReceivedBank.Size = new System.Drawing.Size(141, 20);
            this.txtReceivedBank.TabIndex = 26;
            // 
            // txtPaySlipNo
            // 
            this.txtPaySlipNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPaySlipNo.IsSendTabOnEnter = true;
            this.txtPaySlipNo.Location = new System.Drawing.Point(124, 45);
            this.txtPaySlipNo.Mask = "&00000000000";
            this.txtPaySlipNo.Name = "txtPaySlipNo";
            this.txtPaySlipNo.Size = new System.Drawing.Size(141, 20);
            this.txtPaySlipNo.TabIndex = 1;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(415, 46);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 46;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00034.Location = new System.Drawing.Point(314, 46);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(95, 13);
            this.cxC00034.TabIndex = 45;
            this.cxC00034.Text = "Transaction Date :";
            // 
            // MNMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 162);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.txtPaySlipNo);
            this.Controls.Add(this.txtReceivedBank);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtBudget);
            this.Controls.Add(this.mtxtPONo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblReceivedBank);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblReceivedNo);
            this.Controls.Add(this.lblPaySlipNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00012";
            this.Text = "PO Receipt Reverse";
            this.Load += new System.EventHandler(this.MNMVEW00012_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormName_KeyDown);
            this.Move += new System.EventHandler(this.MNMVEW00012_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0003 lblReceivedNo;
        private Windows.CXClient.Controls.CXC0003 lblPaySlipNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblReceivedBank;
        private Windows.CXClient.Controls.CXC0006 mtxtPONo;
        private Windows.CXClient.Controls.CXC0006 txtBudget;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private System.Windows.Forms.TextBox txtReceivedBank;
        private Windows.CXClient.Controls.CXC0006 txtPaySlipNo;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
    }
}