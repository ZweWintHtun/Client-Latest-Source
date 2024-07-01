namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00007));
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblNewPassword = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblConfirmPassword = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblOldPassword = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAuthorizeName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAuthorizeName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtOldPassword = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtConfirmPassword = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtNewPassword = new Ace.Windows.CXClient.Controls.CXC0001();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(245, 161);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(11, 109);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(84, 13);
            this.lblNewPassword.TabIndex = 73;
            this.lblNewPassword.Text = "New Password :";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(11, 139);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(97, 13);
            this.lblConfirmPassword.TabIndex = 66;
            this.lblConfirmPassword.Text = "Confirm Password :";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(11, 79);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(78, 13);
            this.lblOldPassword.TabIndex = 68;
            this.lblOldPassword.Text = "Old Password :";
            // 
            // lblAuthorizeName
            // 
            this.lblAuthorizeName.AutoSize = true;
            this.lblAuthorizeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizeName.Location = new System.Drawing.Point(11, 49);
            this.lblAuthorizeName.Name = "lblAuthorizeName";
            this.lblAuthorizeName.Size = new System.Drawing.Size(88, 13);
            this.lblAuthorizeName.TabIndex = 65;
            this.lblAuthorizeName.Text = "Authorize Name :";
            // 
            // txtAuthorizeName
            // 
            this.txtAuthorizeName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAuthorizeName.IsSendTabOnEnter = true;
            this.txtAuthorizeName.Location = new System.Drawing.Point(123, 45);
            this.txtAuthorizeName.MaxLength = 20;
            this.txtAuthorizeName.Name = "txtAuthorizeName";
            this.txtAuthorizeName.Size = new System.Drawing.Size(175, 20);
            this.txtAuthorizeName.TabIndex = 0;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOldPassword.IsSendTabOnEnter = true;
            this.txtOldPassword.Location = new System.Drawing.Point(123, 75);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(175, 20);
            this.txtOldPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConfirmPassword.IsSendTabOnEnter = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(123, 135);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(175, 20);
            this.txtConfirmPassword.TabIndex = 3;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNewPassword.IsSendTabOnEnter = true;
            this.txtNewPassword.Location = new System.Drawing.Point(123, 105);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(175, 20);
            this.txtNewPassword.TabIndex = 2;
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-1, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(484, 31);
            this.tlspCommon.TabIndex = 74;
            this.tlspCommon.NewButtonClick += new System.EventHandler(this.tlspCommon_NewButtonClick);
            this.tlspCommon.EditButtonClick += new System.EventHandler(this.tlspCommon_EditButtonClick);
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // frmPFMVEW00007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 194);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtAuthorizeName);
            this.Controls.Add(this.lblAuthorizeName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00007";
            this.Text = "Printing User";
            this.Load += new System.EventHandler(this.PFMVEW00007_Load);
            this.Move += new System.EventHandler(this.frmPFMVEW00007_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0007 butOk;
        private Ace.Windows.CXClient.Controls.CXC0003 lblNewPassword;
        private Ace.Windows.CXClient.Controls.CXC0003 lblConfirmPassword;
        private Ace.Windows.CXClient.Controls.CXC0003 lblOldPassword;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAuthorizeName;
        private Ace.Windows.CXClient.Controls.CXC0001 txtAuthorizeName;
        private Ace.Windows.CXClient.Controls.CXC0001 txtOldPassword;
        private Ace.Windows.CXClient.Controls.CXC0001 txtConfirmPassword;
        private Ace.Windows.CXClient.Controls.CXC0001 txtNewPassword;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;


    }
}