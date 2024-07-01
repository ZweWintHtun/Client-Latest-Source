namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00005));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpSavingInterestWithdraw = new System.Windows.Forms.GroupBox();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpSavingInterestWithdraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpSavingInterestWithdraw
            // 
            this.grpSavingInterestWithdraw.Controls.Add(this.mtxtAccountNo);
            this.grpSavingInterestWithdraw.Controls.Add(this.txtAmount);
            this.grpSavingInterestWithdraw.Controls.Add(this.lblAmount);
            this.grpSavingInterestWithdraw.Controls.Add(this.cxC00031);
            this.grpSavingInterestWithdraw.Location = new System.Drawing.Point(12, 38);
            this.grpSavingInterestWithdraw.Name = "grpSavingInterestWithdraw";
            this.grpSavingInterestWithdraw.Size = new System.Drawing.Size(470, 96);
            this.grpSavingInterestWithdraw.TabIndex = 0;
            this.grpSavingInterestWithdraw.TabStop = false;
            this.grpSavingInterestWithdraw.Text = "Saving Interest Withdraw Entry";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(190, 28);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.IsThousandSeperator = true;
            this.txtAmount.IsUseFloatingPoint = true;
            this.txtAmount.Location = new System.Drawing.Point(190, 53);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(73, 57);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(73, 31);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(73, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Account No. :";
            // 
            // TCMVEW00005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 148);
            this.Controls.Add(this.grpSavingInterestWithdraw);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00005";
            this.Text = "TCMVEW00005";
            this.Load += new System.EventHandler(this.TCMVEW00005_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCMVEW00005_KeyDown);
            this.grpSavingInterestWithdraw.ResumeLayout(false);
            this.grpSavingInterestWithdraw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpSavingInterestWithdraw;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
    }
}