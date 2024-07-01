namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00008));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboAccountNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtAccountName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtBalance = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblMessage = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(25, 54);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(25, 81);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(25, 108);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(84, 13);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "Account Name :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(28, 134);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 13);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Balance :";
            // 
            // cboAccountNo
            // 
            this.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountNo.DropDownHeight = 200;
            this.cboAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountNo.FormattingEnabled = true;
            this.cboAccountNo.IntegralHeight = false;
            this.cboAccountNo.IsSendTabOnEnter = true;
            this.cboAccountNo.Location = new System.Drawing.Point(115, 51);
            this.cboAccountNo.Name = "cboAccountNo";
            this.cboAccountNo.Size = new System.Drawing.Size(121, 21);
            this.cboAccountNo.TabIndex = 1;
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
            this.cboCurrency.Location = new System.Drawing.Point(115, 78);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // txtAccountName
            // 
            this.txtAccountName.IsSendTabOnEnter = true;
            this.txtAccountName.Location = new System.Drawing.Point(115, 105);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(170, 20);
            this.txtAccountName.TabIndex = 3;
            // 
            // txtBalance
            // 
            this.txtBalance.IsSendTabOnEnter = true;
            this.txtBalance.Location = new System.Drawing.Point(115, 131);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(170, 20);
            this.txtBalance.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMessage.Location = new System.Drawing.Point(112, 168);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(112, 17);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Press Esc to exit";
            // 
            // GLMVEW00008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 304);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboAccountNo);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsShowDialog = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLMVEW00008";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry On Ledger";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GLMVEW00008_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLMVEW00008_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblAccountName;
        private Windows.CXClient.Controls.CXC0003 lblBalance;
        private Windows.CXClient.Controls.CXC0002 cboAccountNo;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0001 txtAccountName;
        private Windows.CXClient.Controls.CXC0001 txtBalance;
        private Windows.CXClient.Controls.CXC0003 lblMessage;
    }
}