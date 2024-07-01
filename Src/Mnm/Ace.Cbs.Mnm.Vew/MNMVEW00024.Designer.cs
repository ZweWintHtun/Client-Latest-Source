namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00024
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00024));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRegisterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDraweeBank = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDraweeBank = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblExistingRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpPayeeInfo = new System.Windows.Forms.GroupBox();
            this.txtPayerAddress = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblAddress = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblNRC = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtPayerAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblPayeeAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblChangedRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRegisterNo_ToChange = new Ace.Windows.CXClient.Controls.CXC0001();
            this.grpExistingRegister = new System.Windows.Forms.GroupBox();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpChangedRegister = new System.Windows.Forms.GroupBox();
            this.lblNewRegister = new System.Windows.Forms.Label();
            this.cxC00037 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpRemitterInfo = new System.Windows.Forms.GroupBox();
            this.txtRemitterNRC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRemitterName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblRemitterName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.grpPayeeInfo.SuspendLayout();
            this.grpExistingRegister.SuspendLayout();
            this.grpChangedRegister.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(491, 31);
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
            this.txtAmount.Location = new System.Drawing.Point(107, 149);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(18, 151);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(49, 13);
            this.cxC00031.TabIndex = 75;
            this.cxC00031.Text = "Amount :";
            // 
            // txtRegisterNo
            // 
            this.txtRegisterNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtRegisterNo.IsSendTabOnEnter = true;
            this.txtRegisterNo.Location = new System.Drawing.Point(87, 19);
            this.txtRegisterNo.Name = "txtRegisterNo";
            this.txtRegisterNo.Size = new System.Drawing.Size(119, 20);
            this.txtRegisterNo.TabIndex = 0;
            this.txtRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegisterNo_KeyPress);
            // 
            // txtDraweeBank
            // 
            this.txtDraweeBank.BackColor = System.Drawing.SystemColors.Window;
            this.txtDraweeBank.Enabled = false;
            this.txtDraweeBank.IsSendTabOnEnter = true;
            this.txtDraweeBank.Location = new System.Drawing.Point(107, 123);
            this.txtDraweeBank.Name = "txtDraweeBank";
            this.txtDraweeBank.Size = new System.Drawing.Size(90, 20);
            this.txtDraweeBank.TabIndex = 3;
            this.txtDraweeBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDraweeBank
            // 
            this.lblDraweeBank.AutoSize = true;
            this.lblDraweeBank.Location = new System.Drawing.Point(18, 126);
            this.lblDraweeBank.Name = "lblDraweeBank";
            this.lblDraweeBank.Size = new System.Drawing.Size(81, 13);
            this.lblDraweeBank.TabIndex = 79;
            this.lblDraweeBank.Text = "Drawee Bank. :";
            // 
            // lblExistingRegisterNo
            // 
            this.lblExistingRegisterNo.AutoSize = true;
            this.lblExistingRegisterNo.Location = new System.Drawing.Point(6, 22);
            this.lblExistingRegisterNo.Name = "lblExistingRegisterNo";
            this.lblExistingRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblExistingRegisterNo.TabIndex = 78;
            this.lblExistingRegisterNo.Text = "Register No. :";
            // 
            // grpPayeeInfo
            // 
            this.grpPayeeInfo.Controls.Add(this.txtPayerAddress);
            this.grpPayeeInfo.Controls.Add(this.lblAddress);
            this.grpPayeeInfo.Controls.Add(this.txtPayerNRC);
            this.grpPayeeInfo.Controls.Add(this.lblNRC);
            this.grpPayeeInfo.Controls.Add(this.txtPayerName);
            this.grpPayeeInfo.Controls.Add(this.lblName);
            this.grpPayeeInfo.Controls.Add(this.txtPayerAccountNo);
            this.grpPayeeInfo.Controls.Add(this.lblPayeeAccountNo);
            this.grpPayeeInfo.Location = new System.Drawing.Point(13, 188);
            this.grpPayeeInfo.Name = "grpPayeeInfo";
            this.grpPayeeInfo.Size = new System.Drawing.Size(463, 154);
            this.grpPayeeInfo.TabIndex = 5;
            this.grpPayeeInfo.TabStop = false;
            this.grpPayeeInfo.Text = "Payee Information :";
            // 
            // txtPayerAddress
            // 
            this.txtPayerAddress.Enabled = false;
            this.txtPayerAddress.IsSendTabOnEnter = true;
            this.txtPayerAddress.Location = new System.Drawing.Point(171, 102);
            this.txtPayerAddress.Multiline = true;
            this.txtPayerAddress.Name = "txtPayerAddress";
            this.txtPayerAddress.Size = new System.Drawing.Size(141, 41);
            this.txtPayerAddress.TabIndex = 7;
            this.txtPayerAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(44, 104);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address :";
            // 
            // txtPayerNRC
            // 
            this.txtPayerNRC.Enabled = false;
            this.txtPayerNRC.IsSendTabOnEnter = true;
            this.txtPayerNRC.Location = new System.Drawing.Point(171, 76);
            this.txtPayerNRC.Name = "txtPayerNRC";
            this.txtPayerNRC.Size = new System.Drawing.Size(141, 20);
            this.txtPayerNRC.TabIndex = 6;
            this.txtPayerNRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(44, 78);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(36, 13);
            this.lblNRC.TabIndex = 0;
            this.lblNRC.Text = "NRC :";
            // 
            // txtPayerName
            // 
            this.txtPayerName.Enabled = false;
            this.txtPayerName.IsSendTabOnEnter = true;
            this.txtPayerName.Location = new System.Drawing.Point(171, 50);
            this.txtPayerName.Name = "txtPayerName";
            this.txtPayerName.Size = new System.Drawing.Size(141, 20);
            this.txtPayerName.TabIndex = 5;
            this.txtPayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(44, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // txtPayerAccountNo
            // 
            this.txtPayerAccountNo.Enabled = false;
            this.txtPayerAccountNo.IsSendTabOnEnter = true;
            this.txtPayerAccountNo.Location = new System.Drawing.Point(171, 24);
            this.txtPayerAccountNo.Name = "txtPayerAccountNo";
            this.txtPayerAccountNo.Size = new System.Drawing.Size(115, 20);
            this.txtPayerAccountNo.TabIndex = 3;
            this.txtPayerAccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPayeeAccountNo
            // 
            this.lblPayeeAccountNo.AutoSize = true;
            this.lblPayeeAccountNo.Location = new System.Drawing.Point(44, 26);
            this.lblPayeeAccountNo.Name = "lblPayeeAccountNo";
            this.lblPayeeAccountNo.Size = new System.Drawing.Size(102, 13);
            this.lblPayeeAccountNo.TabIndex = 0;
            this.lblPayeeAccountNo.Text = "Payee\' AccountNo.:";
            // 
            // lblChangedRegisterNo
            // 
            this.lblChangedRegisterNo.AutoSize = true;
            this.lblChangedRegisterNo.Location = new System.Drawing.Point(6, 22);
            this.lblChangedRegisterNo.Name = "lblChangedRegisterNo";
            this.lblChangedRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblChangedRegisterNo.TabIndex = 78;
            this.lblChangedRegisterNo.Text = "Register No. :";
            // 
            // txtRegisterNo_ToChange
            // 
            this.txtRegisterNo_ToChange.BackColor = System.Drawing.SystemColors.Window;
            this.txtRegisterNo_ToChange.IsSendTabOnEnter = true;
            this.txtRegisterNo_ToChange.Location = new System.Drawing.Point(118, 19);
            this.txtRegisterNo_ToChange.Name = "txtRegisterNo_ToChange";
            this.txtRegisterNo_ToChange.Size = new System.Drawing.Size(119, 20);
            this.txtRegisterNo_ToChange.TabIndex = 1;
            // 
            // grpExistingRegister
            // 
            this.grpExistingRegister.Controls.Add(this.cxC00032);
            this.grpExistingRegister.Controls.Add(this.lblExistingRegisterNo);
            this.grpExistingRegister.Controls.Add(this.txtRegisterNo);
            this.grpExistingRegister.Location = new System.Drawing.Point(12, 40);
            this.grpExistingRegister.Name = "grpExistingRegister";
            this.grpExistingRegister.Size = new System.Drawing.Size(215, 68);
            this.grpExistingRegister.TabIndex = 0;
            this.grpExistingRegister.TabStop = false;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(6, 41);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(55, 13);
            this.cxC00032.TabIndex = 79;
            this.cxC00032.Text = "( Existing )";
            // 
            // grpChangedRegister
            // 
            this.grpChangedRegister.Controls.Add(this.lblNewRegister);
            this.grpChangedRegister.Controls.Add(this.cxC00037);
            this.grpChangedRegister.Controls.Add(this.lblChangedRegisterNo);
            this.grpChangedRegister.Controls.Add(this.txtRegisterNo_ToChange);
            this.grpChangedRegister.Location = new System.Drawing.Point(233, 40);
            this.grpChangedRegister.Name = "grpChangedRegister";
            this.grpChangedRegister.Size = new System.Drawing.Size(243, 68);
            this.grpChangedRegister.TabIndex = 1;
            this.grpChangedRegister.TabStop = false;
            // 
            // lblNewRegister
            // 
            this.lblNewRegister.AutoSize = true;
            this.lblNewRegister.Location = new System.Drawing.Point(74, 22);
            this.lblNewRegister.Name = "lblNewRegister";
            this.lblNewRegister.Size = new System.Drawing.Size(0, 13);
            this.lblNewRegister.TabIndex = 80;
            // 
            // cxC00037
            // 
            this.cxC00037.AutoSize = true;
            this.cxC00037.Location = new System.Drawing.Point(6, 41);
            this.cxC00037.Name = "cxC00037";
            this.cxC00037.Size = new System.Drawing.Size(93, 13);
            this.cxC00037.TabIndex = 80;
            this.cxC00037.Text = "( To be Changed )";
            // 
            // grpRemitterInfo
            // 
            this.grpRemitterInfo.Controls.Add(this.txtRemitterNRC);
            this.grpRemitterInfo.Controls.Add(this.cxC00034);
            this.grpRemitterInfo.Controls.Add(this.txtRemitterName);
            this.grpRemitterInfo.Controls.Add(this.lblRemitterName);
            this.grpRemitterInfo.Location = new System.Drawing.Point(13, 353);
            this.grpRemitterInfo.Name = "grpRemitterInfo";
            this.grpRemitterInfo.Size = new System.Drawing.Size(463, 82);
            this.grpRemitterInfo.TabIndex = 6;
            this.grpRemitterInfo.TabStop = false;
            this.grpRemitterInfo.Text = "Remitter Information :";
            // 
            // txtRemitterNRC
            // 
            this.txtRemitterNRC.Enabled = false;
            this.txtRemitterNRC.IsSendTabOnEnter = true;
            this.txtRemitterNRC.Location = new System.Drawing.Point(171, 52);
            this.txtRemitterNRC.Name = "txtRemitterNRC";
            this.txtRemitterNRC.Size = new System.Drawing.Size(141, 20);
            this.txtRemitterNRC.TabIndex = 9;
            this.txtRemitterNRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(41, 54);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(36, 13);
            this.cxC00034.TabIndex = 0;
            this.cxC00034.Text = "NRC :";
            // 
            // txtRemitterName
            // 
            this.txtRemitterName.Enabled = false;
            this.txtRemitterName.IsSendTabOnEnter = true;
            this.txtRemitterName.Location = new System.Drawing.Point(171, 26);
            this.txtRemitterName.Name = "txtRemitterName";
            this.txtRemitterName.Size = new System.Drawing.Size(141, 20);
            this.txtRemitterName.TabIndex = 8;
            this.txtRemitterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemitterName
            // 
            this.lblRemitterName.AutoSize = true;
            this.lblRemitterName.Location = new System.Drawing.Point(41, 28);
            this.lblRemitterName.Name = "lblRemitterName";
            this.lblRemitterName.Size = new System.Drawing.Size(85, 13);
            this.lblRemitterName.TabIndex = 0;
            this.lblRemitterName.Text = "Remitter\' Name :";
            // 
            // MNMVEW00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 467);
            this.Controls.Add(this.grpRemitterInfo);
            this.Controls.Add(this.grpChangedRegister);
            this.Controls.Add(this.grpExistingRegister);
            this.Controls.Add(this.grpPayeeInfo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.txtDraweeBank);
            this.Controls.Add(this.lblDraweeBank);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00024";
            this.Text = "Changing Register No. for Encashment  ";
            this.Load += new System.EventHandler(this.MNMVEW00024_Load);
            this.grpPayeeInfo.ResumeLayout(false);
            this.grpPayeeInfo.PerformLayout();
            this.grpExistingRegister.ResumeLayout(false);
            this.grpExistingRegister.PerformLayout();
            this.grpChangedRegister.ResumeLayout(false);
            this.grpChangedRegister.PerformLayout();
            this.grpRemitterInfo.ResumeLayout(false);
            this.grpRemitterInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtAmount;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0001 txtRegisterNo;
        private Windows.CXClient.Controls.CXC0001 txtDraweeBank;
        private Windows.CXClient.Controls.CXC0003 lblDraweeBank;
        private Windows.CXClient.Controls.CXC0003 lblExistingRegisterNo;
        private System.Windows.Forms.GroupBox grpPayeeInfo;
        private Windows.CXClient.Controls.CXC0001 txtPayerAddress;
        private Windows.CXClient.Controls.CXC0003 lblAddress;
        private Windows.CXClient.Controls.CXC0001 txtPayerNRC;
        private Windows.CXClient.Controls.CXC0003 lblNRC;
        private Windows.CXClient.Controls.CXC0001 txtPayerName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0001 txtPayerAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblPayeeAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblChangedRegisterNo;
        private Windows.CXClient.Controls.CXC0001 txtRegisterNo_ToChange;
        private System.Windows.Forms.GroupBox grpExistingRegister;
        private System.Windows.Forms.GroupBox grpChangedRegister;
        private System.Windows.Forms.GroupBox grpRemitterInfo;
        private Windows.CXClient.Controls.CXC0001 txtRemitterNRC;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private Windows.CXClient.Controls.CXC0001 txtRemitterName;
        private Windows.CXClient.Controls.CXC0003 lblRemitterName;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00037;
        private System.Windows.Forms.Label lblNewRegister;
    }
}