namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00026
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00026));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtPayeeAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPayeeNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPayeePhoneNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpREPayeeInfo = new System.Windows.Forms.GroupBox();
            this.txtPayeeAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPayeePhoneNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPayeeAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPayeeAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPayeeNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayeeName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPayeeName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRemitterName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDraweeBank = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDraweeBank = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRemitterPhoneNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRemitterName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtRemitterNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtRemitterPhoneNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblRemitterNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpRemitterInfo = new System.Windows.Forms.GroupBox();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtREAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpREPayeeInfo.SuspendLayout();
            this.grpRemitterInfo.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(573, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtPayeeAddress
            // 
            this.txtPayeeAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayeeAddress.IsSendTabOnEnter = true;
            this.txtPayeeAddress.Location = new System.Drawing.Point(120, 104);
            this.txtPayeeAddress.Multiline = true;
            this.txtPayeeAddress.Name = "txtPayeeAddress";
            this.txtPayeeAddress.ReadOnly = true;
            this.txtPayeeAddress.Size = new System.Drawing.Size(141, 41);
            this.txtPayeeAddress.TabIndex = 0;
            this.txtPayeeAddress.TabStop = false;
            // 
            // txtPayeeNRC
            // 
            this.txtPayeeNRC.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayeeNRC.IsSendTabOnEnter = true;
            this.txtPayeeNRC.Location = new System.Drawing.Point(120, 78);
            this.txtPayeeNRC.Name = "txtPayeeNRC";
            this.txtPayeeNRC.ReadOnly = true;
            this.txtPayeeNRC.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeNRC.TabIndex = 0;
            this.txtPayeeNRC.TabStop = false;
            // 
            // lblPayeePhoneNo
            // 
            this.lblPayeePhoneNo.AutoSize = true;
            this.lblPayeePhoneNo.Location = new System.Drawing.Point(17, 153);
            this.lblPayeePhoneNo.Name = "lblPayeePhoneNo";
            this.lblPayeePhoneNo.Size = new System.Drawing.Size(64, 13);
            this.lblPayeePhoneNo.TabIndex = 0;
            this.lblPayeePhoneNo.Text = "Phone No. :";
            // 
            // grpREPayeeInfo
            // 
            this.grpREPayeeInfo.Controls.Add(this.txtPayeeAccountNo);
            this.grpREPayeeInfo.Controls.Add(this.txtPayeePhoneNo);
            this.grpREPayeeInfo.Controls.Add(this.lblPayeePhoneNo);
            this.grpREPayeeInfo.Controls.Add(this.txtPayeeAddress);
            this.grpREPayeeInfo.Controls.Add(this.lblPayeeAccountNo);
            this.grpREPayeeInfo.Controls.Add(this.lblPayeeAddress);
            this.grpREPayeeInfo.Controls.Add(this.txtPayeeNRC);
            this.grpREPayeeInfo.Controls.Add(this.lblPayeeNRC);
            this.grpREPayeeInfo.Controls.Add(this.txtPayeeName);
            this.grpREPayeeInfo.Controls.Add(this.lblPayeeName);
            this.grpREPayeeInfo.Location = new System.Drawing.Point(11, 127);
            this.grpREPayeeInfo.Name = "grpREPayeeInfo";
            this.grpREPayeeInfo.Size = new System.Drawing.Size(284, 186);
            this.grpREPayeeInfo.TabIndex = 0;
            this.grpREPayeeInfo.TabStop = false;
            this.grpREPayeeInfo.Text = "Payee Information :";
            // 
            // txtPayeeAccountNo
            // 
            this.txtPayeeAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayeeAccountNo.IsSendTabOnEnter = true;
            this.txtPayeeAccountNo.Location = new System.Drawing.Point(120, 26);
            this.txtPayeeAccountNo.Name = "txtPayeeAccountNo";
            this.txtPayeeAccountNo.ReadOnly = true;
            this.txtPayeeAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeAccountNo.TabIndex = 0;
            this.txtPayeeAccountNo.TabStop = false;
            // 
            // txtPayeePhoneNo
            // 
            this.txtPayeePhoneNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayeePhoneNo.IsSendTabOnEnter = true;
            this.txtPayeePhoneNo.Location = new System.Drawing.Point(120, 151);
            this.txtPayeePhoneNo.Name = "txtPayeePhoneNo";
            this.txtPayeePhoneNo.ReadOnly = true;
            this.txtPayeePhoneNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayeePhoneNo.TabIndex = 5;
            this.txtPayeePhoneNo.TabStop = false;
            // 
            // lblPayeeAccountNo
            // 
            this.lblPayeeAccountNo.AutoSize = true;
            this.lblPayeeAccountNo.Location = new System.Drawing.Point(17, 29);
            this.lblPayeeAccountNo.Name = "lblPayeeAccountNo";
            this.lblPayeeAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblPayeeAccountNo.TabIndex = 79;
            this.lblPayeeAccountNo.Text = "Account No :";
            // 
            // lblPayeeAddress
            // 
            this.lblPayeeAddress.AutoSize = true;
            this.lblPayeeAddress.Location = new System.Drawing.Point(17, 107);
            this.lblPayeeAddress.Name = "lblPayeeAddress";
            this.lblPayeeAddress.Size = new System.Drawing.Size(51, 13);
            this.lblPayeeAddress.TabIndex = 0;
            this.lblPayeeAddress.Text = "Address :";
            // 
            // lblPayeeNRC
            // 
            this.lblPayeeNRC.AutoSize = true;
            this.lblPayeeNRC.Location = new System.Drawing.Point(17, 81);
            this.lblPayeeNRC.Name = "lblPayeeNRC";
            this.lblPayeeNRC.Size = new System.Drawing.Size(36, 13);
            this.lblPayeeNRC.TabIndex = 0;
            this.lblPayeeNRC.Text = "NRC :";
            // 
            // txtPayeeName
            // 
            this.txtPayeeName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayeeName.IsSendTabOnEnter = true;
            this.txtPayeeName.Location = new System.Drawing.Point(120, 52);
            this.txtPayeeName.Name = "txtPayeeName";
            this.txtPayeeName.ReadOnly = true;
            this.txtPayeeName.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeName.TabIndex = 0;
            this.txtPayeeName.TabStop = false;
            // 
            // lblPayeeName
            // 
            this.lblPayeeName.AutoSize = true;
            this.lblPayeeName.Location = new System.Drawing.Point(17, 55);
            this.lblPayeeName.Name = "lblPayeeName";
            this.lblPayeeName.Size = new System.Drawing.Size(41, 13);
            this.lblPayeeName.TabIndex = 0;
            this.lblPayeeName.Text = "Name :";
            // 
            // lblRemitterName
            // 
            this.lblRemitterName.AutoSize = true;
            this.lblRemitterName.Location = new System.Drawing.Point(18, 25);
            this.lblRemitterName.Name = "lblRemitterName";
            this.lblRemitterName.Size = new System.Drawing.Size(41, 13);
            this.lblRemitterName.TabIndex = 0;
            this.lblRemitterName.Text = "Name :";
            // 
            // txtDraweeBank
            // 
            this.txtDraweeBank.BackColor = System.Drawing.SystemColors.Window;
            this.txtDraweeBank.IsSendTabOnEnter = true;
            this.txtDraweeBank.Location = new System.Drawing.Point(131, 63);
            this.txtDraweeBank.Name = "txtDraweeBank";
            this.txtDraweeBank.ReadOnly = true;
            this.txtDraweeBank.Size = new System.Drawing.Size(90, 20);
            this.txtDraweeBank.TabIndex = 0;
            this.txtDraweeBank.TabStop = false;
            // 
            // lblDraweeBank
            // 
            this.lblDraweeBank.AutoSize = true;
            this.lblDraweeBank.Location = new System.Drawing.Point(28, 67);
            this.lblDraweeBank.Name = "lblDraweeBank";
            this.lblDraweeBank.Size = new System.Drawing.Size(81, 13);
            this.lblDraweeBank.TabIndex = 76;
            this.lblDraweeBank.Text = "Drawee Bank. :";
            // 
            // lblRegisterNo
            // 
            this.lblRegisterNo.AutoSize = true;
            this.lblRegisterNo.Location = new System.Drawing.Point(28, 40);
            this.lblRegisterNo.Name = "lblRegisterNo";
            this.lblRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblRegisterNo.TabIndex = 75;
            this.lblRegisterNo.Text = "Register No. :";
            // 
            // lblRemitterPhoneNo
            // 
            this.lblRemitterPhoneNo.AutoSize = true;
            this.lblRemitterPhoneNo.Location = new System.Drawing.Point(18, 90);
            this.lblRemitterPhoneNo.Name = "lblRemitterPhoneNo";
            this.lblRemitterPhoneNo.Size = new System.Drawing.Size(64, 13);
            this.lblRemitterPhoneNo.TabIndex = 0;
            this.lblRemitterPhoneNo.Text = "Phone No. :";
            // 
            // txtRemitterName
            // 
            this.txtRemitterName.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemitterName.IsSendTabOnEnter = true;
            this.txtRemitterName.Location = new System.Drawing.Point(102, 22);
            this.txtRemitterName.Name = "txtRemitterName";
            this.txtRemitterName.ReadOnly = true;
            this.txtRemitterName.Size = new System.Drawing.Size(141, 20);
            this.txtRemitterName.TabIndex = 0;
            this.txtRemitterName.TabStop = false;
            // 
            // txtRemitterNRC
            // 
            this.txtRemitterNRC.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemitterNRC.IsSendTabOnEnter = true;
            this.txtRemitterNRC.Location = new System.Drawing.Point(102, 55);
            this.txtRemitterNRC.Name = "txtRemitterNRC";
            this.txtRemitterNRC.ReadOnly = true;
            this.txtRemitterNRC.Size = new System.Drawing.Size(141, 20);
            this.txtRemitterNRC.TabIndex = 0;
            this.txtRemitterNRC.TabStop = false;
            // 
            // txtRemitterPhoneNo
            // 
            this.txtRemitterPhoneNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemitterPhoneNo.IsSendTabOnEnter = true;
            this.txtRemitterPhoneNo.Location = new System.Drawing.Point(102, 87);
            this.txtRemitterPhoneNo.Name = "txtRemitterPhoneNo";
            this.txtRemitterPhoneNo.ReadOnly = true;
            this.txtRemitterPhoneNo.Size = new System.Drawing.Size(141, 20);
            this.txtRemitterPhoneNo.TabIndex = 0;
            this.txtRemitterPhoneNo.TabStop = false;
            // 
            // lblRemitterNRC
            // 
            this.lblRemitterNRC.AutoSize = true;
            this.lblRemitterNRC.Location = new System.Drawing.Point(18, 58);
            this.lblRemitterNRC.Name = "lblRemitterNRC";
            this.lblRemitterNRC.Size = new System.Drawing.Size(36, 13);
            this.lblRemitterNRC.TabIndex = 0;
            this.lblRemitterNRC.Text = "NRC :";
            // 
            // grpRemitterInfo
            // 
            this.grpRemitterInfo.Controls.Add(this.txtRemitterPhoneNo);
            this.grpRemitterInfo.Controls.Add(this.lblRemitterPhoneNo);
            this.grpRemitterInfo.Controls.Add(this.txtRemitterNRC);
            this.grpRemitterInfo.Controls.Add(this.lblRemitterNRC);
            this.grpRemitterInfo.Controls.Add(this.txtRemitterName);
            this.grpRemitterInfo.Controls.Add(this.lblRemitterName);
            this.grpRemitterInfo.Location = new System.Drawing.Point(301, 127);
            this.grpRemitterInfo.Name = "grpRemitterInfo";
            this.grpRemitterInfo.Size = new System.Drawing.Size(257, 186);
            this.grpRemitterInfo.TabIndex = 0;
            this.grpRemitterInfo.TabStop = false;
            this.grpRemitterInfo.Text = "Remitter Information :";
            // 
            // txtAmount
            // 
            this.txtAmount.DecimalPlaces = 2;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(131, 89);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtREAmount
            // 
            this.txtREAmount.AutoSize = true;
            this.txtREAmount.Location = new System.Drawing.Point(28, 92);
            this.txtREAmount.Name = "txtREAmount";
            this.txtREAmount.Size = new System.Drawing.Size(49, 13);
            this.txtREAmount.TabIndex = 81;
            this.txtREAmount.Text = "Amount :";
            // 
            // mtxtRegisterNo
            // 
            this.mtxtRegisterNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtRegisterNo.IsSendTabOnEnter = true;
            this.mtxtRegisterNo.Location = new System.Drawing.Point(131, 37);
            this.mtxtRegisterNo.Name = "mtxtRegisterNo";
            this.mtxtRegisterNo.Size = new System.Drawing.Size(90, 20);
            this.mtxtRegisterNo.TabIndex = 0;
            this.mtxtRegisterNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtRegisterNo_KeyPress);
            // 
            // MNMVEW00026
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 329);
            this.Controls.Add(this.mtxtRegisterNo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtREAmount);
            this.Controls.Add(this.grpREPayeeInfo);
            this.Controls.Add(this.txtDraweeBank);
            this.Controls.Add(this.lblDraweeBank);
            this.Controls.Add(this.lblRegisterNo);
            this.Controls.Add(this.grpRemitterInfo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00026";
            this.Text = "RE Important Data";
            this.Load += new System.EventHandler(this.MNMVEW00026_Load);
            this.Move += new System.EventHandler(this.MNMVEW00026_Move);
            this.grpREPayeeInfo.ResumeLayout(false);
            this.grpREPayeeInfo.PerformLayout();
            this.grpRemitterInfo.ResumeLayout(false);
            this.grpRemitterInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtPayeeAddress;
        private Windows.CXClient.Controls.CXC0001 txtPayeeNRC;
        private Windows.CXClient.Controls.CXC0003 lblPayeePhoneNo;
        private System.Windows.Forms.GroupBox grpREPayeeInfo;
        private Windows.CXClient.Controls.CXC0001 txtPayeePhoneNo;
        private Windows.CXClient.Controls.CXC0003 lblPayeeAddress;
        private Windows.CXClient.Controls.CXC0003 lblPayeeNRC;
        private Windows.CXClient.Controls.CXC0001 txtPayeeName;
        private Windows.CXClient.Controls.CXC0003 lblPayeeName;
        private Windows.CXClient.Controls.CXC0003 lblRemitterName;
        private Windows.CXClient.Controls.CXC0001 txtDraweeBank;
        private Windows.CXClient.Controls.CXC0003 lblDraweeBank;
        private Windows.CXClient.Controls.CXC0003 lblRegisterNo;
        private Windows.CXClient.Controls.CXC0003 lblRemitterPhoneNo;
        private Windows.CXClient.Controls.CXC0001 txtRemitterName;
        private Windows.CXClient.Controls.CXC0001 txtRemitterNRC;
        private Windows.CXClient.Controls.CXC0001 txtRemitterPhoneNo;
        private Windows.CXClient.Controls.CXC0003 lblRemitterNRC;
        private System.Windows.Forms.GroupBox grpRemitterInfo;
        private Windows.CXClient.Controls.CXC0001 txtPayeeAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 txtREAmount;
        private Windows.CXClient.Controls.CXC0003 lblPayeeAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtRegisterNo;
    }
}