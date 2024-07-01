namespace Ace.Cbs.Cx.Cle
{
    partial class frmCXCLE00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCXCLE00016));
            this.txtUserName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtPassword = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtConfirmPassword = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTestKey = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblComfirmPassword = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPassword = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblUserID = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTestkey = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butApprove = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butCancel = new Ace.Windows.CXClient.Controls.CXC0007();
            this.chkRememberPassword = new Ace.Windows.CXClient.Controls.CXC0008();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserName.IsSendTabOnEnter = true;
            this.txtUserName.Location = new System.Drawing.Point(126, 43);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(131, 20);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.IsSendTabOnEnter = true;
            this.txtPassword.Location = new System.Drawing.Point(126, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.IsSendTabOnEnter = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(126, 97);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(131, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComfirmPassword_KeyDown);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            // 
            // txtTestKey
            // 
            this.txtTestKey.IsSendTabOnEnter = true;
            this.txtTestKey.Location = new System.Drawing.Point(126, 16);
            this.txtTestKey.Name = "txtTestKey";
            this.txtTestKey.Size = new System.Drawing.Size(131, 20);
            this.txtTestKey.TabIndex = 1;
            this.txtTestKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTestKey_KeyDown);
            // 
            // lblComfirmPassword
            // 
            this.lblComfirmPassword.AutoSize = true;
            this.lblComfirmPassword.Location = new System.Drawing.Point(21, 100);
            this.lblComfirmPassword.Name = "lblComfirmPassword";
            this.lblComfirmPassword.Size = new System.Drawing.Size(97, 13);
            this.lblComfirmPassword.TabIndex = 6;
            this.lblComfirmPassword.Text = "Confirm Password :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 73);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password :";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(21, 46);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(49, 13);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "User ID :";
            // 
            // lblTestkey
            // 
            this.lblTestkey.AutoSize = true;
            this.lblTestkey.Location = new System.Drawing.Point(21, 19);
            this.lblTestkey.Name = "lblTestkey";
            this.lblTestkey.Size = new System.Drawing.Size(51, 13);
            this.lblTestkey.TabIndex = 0;
            this.lblTestkey.Text = "Testkey :";
            // 
            // butApprove
            // 
            this.butApprove.CausesValidation = false;
            this.butApprove.Location = new System.Drawing.Point(79, 163);
            this.butApprove.Name = "butApprove";
            this.butApprove.Size = new System.Drawing.Size(75, 27);
            this.butApprove.TabIndex = 9;
            this.butApprove.Text = "Approve";
            this.butApprove.UseVisualStyleBackColor = true;
            this.butApprove.Click += new System.EventHandler(this.butApprove_Click);
            // 
            // butCancel
            // 
            this.butCancel.CausesValidation = false;
            this.butCancel.Location = new System.Drawing.Point(177, 163);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 27);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.IsSendTabOnEnter = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(24, 130);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(126, 17);
            this.chkRememberPassword.TabIndex = 8;
            this.chkRememberPassword.Text = "Password Remember";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // frmCXCLE00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 202);
            this.Controls.Add(this.chkRememberPassword);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butApprove);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtTestKey);
            this.Controls.Add(this.lblComfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.lblTestkey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCXCLE00016";
            this.Text = "Manager Approve Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCXCLE00016_FormClosed);
            this.Load += new System.EventHandler(this.frmCXCLE00016_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCXCLE00016_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblTestkey;
        private Windows.CXClient.Controls.CXC0003 lblUserID;
        private Windows.CXClient.Controls.CXC0003 lblPassword;
        private Windows.CXClient.Controls.CXC0003 lblComfirmPassword;
        private Windows.CXClient.Controls.CXC0001 txtTestKey;
        private Windows.CXClient.Controls.CXC0001 txtConfirmPassword;
        private Windows.CXClient.Controls.CXC0001 txtPassword;
        private Windows.CXClient.Controls.CXC0001 txtUserName;
        private Windows.CXClient.Controls.CXC0007 butApprove;
        private Windows.CXClient.Controls.CXC0007 butCancel;
        private Windows.CXClient.Controls.CXC0008 chkRememberPassword;
    }
}