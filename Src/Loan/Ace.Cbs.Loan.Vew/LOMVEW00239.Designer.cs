namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00239
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00239));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtHPNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAcctNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDealerName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtSourceBr = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtCurrency = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTransactionDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(491, 31);
            this.tsbCRUD.TabIndex = 175;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtHPNo
            // 
            this.txtHPNo.IsSendTabOnEnter = true;
            this.txtHPNo.Location = new System.Drawing.Point(137, 44);
            this.txtHPNo.MaxLength = 15;
            this.txtHPNo.Name = "txtHPNo";
            this.txtHPNo.Size = new System.Drawing.Size(180, 20);
            this.txtHPNo.TabIndex = 176;
            this.txtHPNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHPNo_KeyDown);
            this.txtHPNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHPNo_KeyPress);
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(12, 49);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(100, 13);
            this.cxC00033.TabIndex = 177;
            this.cxC00033.Text = "Hire Purchase No  :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(13, 240);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(55, 13);
            this.cxC00031.TabIndex = 181;
            this.cxC00031.Text = "Currency :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(13, 210);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(75, 13);
            this.cxC00032.TabIndex = 179;
            this.cxC00032.Text = "Branch Code :";
            // 
            // lblAcctNo
            // 
            this.lblAcctNo.AutoSize = true;
            this.lblAcctNo.Location = new System.Drawing.Point(12, 79);
            this.lblAcctNo.Name = "lblAcctNo";
            this.lblAcctNo.Size = new System.Drawing.Size(70, 13);
            this.lblAcctNo.TabIndex = 192;
            this.lblAcctNo.Text = "Account No :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(137, 74);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.ReadOnly = true;
            this.mtxtAccountNo.Size = new System.Drawing.Size(179, 20);
            this.mtxtAccountNo.TabIndex = 191;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(136, 104);
            this.txtName.MaxLength = 15;
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(280, 40);
            this.txtName.TabIndex = 193;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(12, 109);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(41, 13);
            this.cxC00034.TabIndex = 194;
            this.cxC00034.Text = "Name :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtDealerName
            // 
            this.txtDealerName.IsSendTabOnEnter = true;
            this.txtDealerName.Location = new System.Drawing.Point(136, 155);
            this.txtDealerName.MaxLength = 15;
            this.txtDealerName.Multiline = true;
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.ReadOnly = true;
            this.txtDealerName.Size = new System.Drawing.Size(280, 40);
            this.txtDealerName.TabIndex = 195;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(12, 160);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(75, 13);
            this.cxC00035.TabIndex = 196;
            this.cxC00035.Text = "Dealer Name :";
            // 
            // txtSourceBr
            // 
            this.txtSourceBr.IsSendTabOnEnter = true;
            this.txtSourceBr.Location = new System.Drawing.Point(137, 210);
            this.txtSourceBr.MaxLength = 15;
            this.txtSourceBr.Name = "txtSourceBr";
            this.txtSourceBr.ReadOnly = true;
            this.txtSourceBr.Size = new System.Drawing.Size(180, 20);
            this.txtSourceBr.TabIndex = 197;
            // 
            // txtCurrency
            // 
            this.txtCurrency.IsSendTabOnEnter = true;
            this.txtCurrency.Location = new System.Drawing.Point(136, 240);
            this.txtCurrency.MaxLength = 15;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(180, 20);
            this.txtCurrency.TabIndex = 198;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTransactionDate.Location = new System.Drawing.Point(421, 49);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionDate.TabIndex = 200;
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cxC00036.Location = new System.Drawing.Point(324, 48);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(95, 13);
            this.cxC00036.TabIndex = 199;
            this.cxC00036.Text = "Transaction Date :";
            // 
            // LOMVEW00239
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 276);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.cxC00036);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.txtSourceBr);
            this.Controls.Add(this.txtDealerName);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.lblAcctNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.txtHPNo);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00239";
            this.Text = "Hire Purchase Registration Reversal ";
            this.Load += new System.EventHandler(this.LOMVEW00239_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtHPNo;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblAcctNo;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0001 txtDealerName;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0001 txtCurrency;
        private Windows.CXClient.Controls.CXC0001 txtSourceBr;
        private Windows.CXClient.Controls.CXC0003 lblTransactionDate;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
    }
}