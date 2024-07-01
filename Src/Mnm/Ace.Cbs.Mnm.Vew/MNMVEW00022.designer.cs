namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00022));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDraweeBank = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDraweeBank = new Ace.Windows.CXClient.Controls.CXC0001();
            this.grpPayerInfo = new System.Windows.Forms.GroupBox();
            this.txtPayerAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtNarration = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNarration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerPhoneNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPhoneNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPayerAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpPayeeInfo = new System.Windows.Forms.GroupBox();
            this.txtPayeeAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtPayeePhoneNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayeeAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayeeNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayeeName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPayeeAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpPayerInfo.SuspendLayout();
            this.grpPayeeInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(590, 31);
            this.tsbCRUD.TabIndex = 13;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblRegisterNo
            // 
            this.lblRegisterNo.AutoSize = true;
            this.lblRegisterNo.Location = new System.Drawing.Point(32, 49);
            this.lblRegisterNo.Name = "lblRegisterNo";
            this.lblRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblRegisterNo.TabIndex = 64;
            this.lblRegisterNo.Text = "Register No. :";
            // 
            // lblDraweeBank
            // 
            this.lblDraweeBank.AutoSize = true;
            this.lblDraweeBank.Location = new System.Drawing.Point(32, 75);
            this.lblDraweeBank.Name = "lblDraweeBank";
            this.lblDraweeBank.Size = new System.Drawing.Size(81, 13);
            this.lblDraweeBank.TabIndex = 64;
            this.lblDraweeBank.Text = "Drawee Bank. :";
            // 
            // txtDraweeBank
            // 
            this.txtDraweeBank.BackColor = System.Drawing.SystemColors.Window;
            this.txtDraweeBank.Enabled = false;
            this.txtDraweeBank.IsSendTabOnEnter = true;
            this.txtDraweeBank.Location = new System.Drawing.Point(137, 72);
            this.txtDraweeBank.Name = "txtDraweeBank";
            this.txtDraweeBank.Size = new System.Drawing.Size(90, 20);
            this.txtDraweeBank.TabIndex = 1;
            // 
            // grpPayerInfo
            // 
            this.grpPayerInfo.Controls.Add(this.txtPayerAccountNo);
            this.grpPayerInfo.Controls.Add(this.txtNarration);
            this.grpPayerInfo.Controls.Add(this.lblNarration);
            this.grpPayerInfo.Controls.Add(this.txtPayerPhoneNo);
            this.grpPayerInfo.Controls.Add(this.lblPhoneNo);
            this.grpPayerInfo.Controls.Add(this.txtPayerAddress);
            this.grpPayerInfo.Controls.Add(this.lblAddress);
            this.grpPayerInfo.Controls.Add(this.txtPayerNRC);
            this.grpPayerInfo.Controls.Add(this.lblNRC);
            this.grpPayerInfo.Controls.Add(this.txtPayerName);
            this.grpPayerInfo.Controls.Add(this.lblName);
            this.grpPayerInfo.Controls.Add(this.lblPayerAccountNo);
            this.grpPayerInfo.Location = new System.Drawing.Point(15, 100);
            this.grpPayerInfo.Name = "grpPayerInfo";
            this.grpPayerInfo.Size = new System.Drawing.Size(274, 202);
            this.grpPayerInfo.TabIndex = 2;
            this.grpPayerInfo.TabStop = false;
            this.grpPayerInfo.Text = "Payer Information :";
            // 
            // txtPayerAccountNo
            // 
            this.txtPayerAccountNo.IsSendTabOnEnter = true;
            this.txtPayerAccountNo.Location = new System.Drawing.Point(122, 16);
            this.txtPayerAccountNo.Name = "txtPayerAccountNo";
            this.txtPayerAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayerAccountNo.TabIndex = 8;
            this.txtPayerAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtNarration
            // 
            this.txtNarration.IsSendTabOnEnter = true;
            this.txtNarration.Location = new System.Drawing.Point(122, 171);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(141, 20);
            this.txtNarration.TabIndex = 7;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(17, 174);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(56, 13);
            this.lblNarration.TabIndex = 0;
            this.lblNarration.Text = "Narration :";
            // 
            // txtPayerPhoneNo
            // 
            this.txtPayerPhoneNo.IsSendTabOnEnter = true;
            this.txtPayerPhoneNo.Location = new System.Drawing.Point(122, 145);
            this.txtPayerPhoneNo.Name = "txtPayerPhoneNo";
            this.txtPayerPhoneNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayerPhoneNo.TabIndex = 6;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(17, 148);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(64, 13);
            this.lblPhoneNo.TabIndex = 0;
            this.lblPhoneNo.Text = "Phone No. :";
            // 
            // txtPayerAddress
            // 
            this.txtPayerAddress.IsSendTabOnEnter = true;
            this.txtPayerAddress.Location = new System.Drawing.Point(122, 98);
            this.txtPayerAddress.Multiline = true;
            this.txtPayerAddress.Name = "txtPayerAddress";
            this.txtPayerAddress.Size = new System.Drawing.Size(141, 41);
            this.txtPayerAddress.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(17, 101);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address :";
            // 
            // txtPayerNRC
            // 
            this.txtPayerNRC.IsSendTabOnEnter = true;
            this.txtPayerNRC.Location = new System.Drawing.Point(122, 72);
            this.txtPayerNRC.Name = "txtPayerNRC";
            this.txtPayerNRC.Size = new System.Drawing.Size(141, 20);
            this.txtPayerNRC.TabIndex = 4;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(17, 75);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(36, 13);
            this.lblNRC.TabIndex = 0;
            this.lblNRC.Text = "NRC :";
            // 
            // txtPayerName
            // 
            this.txtPayerName.IsSendTabOnEnter = true;
            this.txtPayerName.Location = new System.Drawing.Point(122, 46);
            this.txtPayerName.Name = "txtPayerName";
            this.txtPayerName.Size = new System.Drawing.Size(141, 20);
            this.txtPayerName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // lblPayerAccountNo
            // 
            this.lblPayerAccountNo.AutoSize = true;
            this.lblPayerAccountNo.Location = new System.Drawing.Point(17, 23);
            this.lblPayerAccountNo.Name = "lblPayerAccountNo";
            this.lblPayerAccountNo.Size = new System.Drawing.Size(99, 13);
            this.lblPayerAccountNo.TabIndex = 0;
            this.lblPayerAccountNo.Text = "Payer\' AccountNo.:";
            // 
            // grpPayeeInfo
            // 
            this.grpPayeeInfo.Controls.Add(this.txtPayeeAccountNo);
            this.grpPayeeInfo.Controls.Add(this.txtPayeePhoneNo);
            this.grpPayeeInfo.Controls.Add(this.cxC00032);
            this.grpPayeeInfo.Controls.Add(this.txtPayeeAddress);
            this.grpPayeeInfo.Controls.Add(this.cxC00033);
            this.grpPayeeInfo.Controls.Add(this.txtPayeeNRC);
            this.grpPayeeInfo.Controls.Add(this.cxC00034);
            this.grpPayeeInfo.Controls.Add(this.txtPayeeName);
            this.grpPayeeInfo.Controls.Add(this.cxC00035);
            this.grpPayeeInfo.Controls.Add(this.lblPayeeAccountNo);
            this.grpPayeeInfo.Location = new System.Drawing.Point(295, 100);
            this.grpPayeeInfo.Name = "grpPayeeInfo";
            this.grpPayeeInfo.Size = new System.Drawing.Size(274, 202);
            this.grpPayeeInfo.TabIndex = 8;
            this.grpPayeeInfo.TabStop = false;
            this.grpPayeeInfo.Text = "Payee Information :";
            // 
            // txtPayeeAccountNo
            // 
            this.txtPayeeAccountNo.IsSendTabOnEnter = true;
            this.txtPayeeAccountNo.Location = new System.Drawing.Point(122, 16);
            this.txtPayeeAccountNo.Name = "txtPayeeAccountNo";
            this.txtPayeeAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeAccountNo.TabIndex = 13;
            this.txtPayeeAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPayeeAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayeeAccountNo_KeyPress);
            // 
            // txtPayeePhoneNo
            // 
            this.txtPayeePhoneNo.IsSendTabOnEnter = true;
            this.txtPayeePhoneNo.Location = new System.Drawing.Point(122, 145);
            this.txtPayeePhoneNo.Name = "txtPayeePhoneNo";
            this.txtPayeePhoneNo.Size = new System.Drawing.Size(141, 20);
            this.txtPayeePhoneNo.TabIndex = 12;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(17, 148);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(64, 13);
            this.cxC00032.TabIndex = 0;
            this.cxC00032.Text = "Phone No. :";
            // 
            // txtPayeeAddress
            // 
            this.txtPayeeAddress.IsSendTabOnEnter = true;
            this.txtPayeeAddress.Location = new System.Drawing.Point(122, 98);
            this.txtPayeeAddress.Multiline = true;
            this.txtPayeeAddress.Name = "txtPayeeAddress";
            this.txtPayeeAddress.Size = new System.Drawing.Size(141, 41);
            this.txtPayeeAddress.TabIndex = 11;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(17, 101);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(51, 13);
            this.cxC00033.TabIndex = 0;
            this.cxC00033.Text = "Address :";
            // 
            // txtPayeeNRC
            // 
            this.txtPayeeNRC.IsSendTabOnEnter = true;
            this.txtPayeeNRC.Location = new System.Drawing.Point(122, 72);
            this.txtPayeeNRC.Name = "txtPayeeNRC";
            this.txtPayeeNRC.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeNRC.TabIndex = 10;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(17, 75);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(36, 13);
            this.cxC00034.TabIndex = 0;
            this.cxC00034.Text = "NRC :";
            // 
            // txtPayeeName
            // 
            this.txtPayeeName.IsSendTabOnEnter = true;
            this.txtPayeeName.Location = new System.Drawing.Point(122, 46);
            this.txtPayeeName.Name = "txtPayeeName";
            this.txtPayeeName.Size = new System.Drawing.Size(141, 20);
            this.txtPayeeName.TabIndex = 9;
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Location = new System.Drawing.Point(17, 49);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(41, 13);
            this.cxC00035.TabIndex = 0;
            this.cxC00035.Text = "Name :";
            // 
            // lblPayeeAccountNo
            // 
            this.lblPayeeAccountNo.AutoSize = true;
            this.lblPayeeAccountNo.Location = new System.Drawing.Point(17, 23);
            this.lblPayeeAccountNo.Name = "lblPayeeAccountNo";
            this.lblPayeeAccountNo.Size = new System.Drawing.Size(102, 13);
            this.lblPayeeAccountNo.TabIndex = 0;
            this.lblPayeeAccountNo.Text = "Payee\' AccountNo.:";
            // 
            // mtxtRegisterNo
            // 
            this.mtxtRegisterNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtRegisterNo.IsSendTabOnEnter = true;
            this.mtxtRegisterNo.Location = new System.Drawing.Point(137, 46);
            this.mtxtRegisterNo.Name = "mtxtRegisterNo";
            this.mtxtRegisterNo.Size = new System.Drawing.Size(90, 20);
            this.mtxtRegisterNo.TabIndex = 0;
            this.mtxtRegisterNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtRegisterNo_KeyPress);
            // 
            // MNMVEW00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 317);
            this.Controls.Add(this.mtxtRegisterNo);
            this.Controls.Add(this.grpPayeeInfo);
            this.Controls.Add(this.grpPayerInfo);
            this.Controls.Add(this.txtDraweeBank);
            this.Controls.Add(this.lblDraweeBank);
            this.Controls.Add(this.lblRegisterNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00022";
            this.Text = "RD Personal Information";
            this.Load += new System.EventHandler(this.MNMVEW00022_Load);
            this.Move += new System.EventHandler(this.MNMVEW00022_Move);
            this.grpPayerInfo.ResumeLayout(false);
            this.grpPayerInfo.PerformLayout();
            this.grpPayeeInfo.ResumeLayout(false);
            this.grpPayeeInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblRegisterNo;
        private Windows.CXClient.Controls.CXC0003 lblDraweeBank;
        private Windows.CXClient.Controls.CXC0001 txtDraweeBank;
        private System.Windows.Forms.GroupBox grpPayerInfo;
        private Windows.CXClient.Controls.CXC0001 txtNarration;
        private Windows.CXClient.Controls.CXC0003 lblNarration;
        private Windows.CXClient.Controls.CXC0001 txtPayerPhoneNo;
        private Windows.CXClient.Controls.CXC0003 lblPhoneNo;
        private Windows.CXClient.Controls.CXC0001 txtPayerAddress;
        private Windows.CXClient.Controls.CXC0003 lblAddress;
        private Windows.CXClient.Controls.CXC0001 txtPayerNRC;
        private Windows.CXClient.Controls.CXC0003 lblNRC;
        private Windows.CXClient.Controls.CXC0001 txtPayerName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 lblPayerAccountNo;
        private System.Windows.Forms.GroupBox grpPayeeInfo;
        private Windows.CXClient.Controls.CXC0001 txtPayeePhoneNo;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0001 txtPayeeAddress;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0001 txtPayeeNRC;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0001 txtPayeeName;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 lblPayeeAccountNo;
        private Windows.CXClient.Controls.CXC0006 mtxtRegisterNo;
        private Windows.CXClient.Controls.CXC0006 txtPayerAccountNo;
        private Windows.CXClient.Controls.CXC0006 txtPayeeAccountNo;
    }
}