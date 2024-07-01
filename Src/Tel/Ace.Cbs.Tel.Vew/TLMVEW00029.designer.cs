namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00029
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00029));
            this.butPassing = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpIBLDrRePassing = new System.Windows.Forms.GroupBox();
            this.rdoByDateTime = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByRegisterNo = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByBranchCode = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpIBLDrRePassing.SuspendLayout();
            this.SuspendLayout();
            // 
            // butPassing
            // 
            this.butPassing.Image = ((System.Drawing.Image)(resources.GetObject("butPassing.Image")));
            this.butPassing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPassing.Location = new System.Drawing.Point(136, 178);
            this.butPassing.Name = "butPassing";
            this.butPassing.Size = new System.Drawing.Size(76, 32);
            this.butPassing.TabIndex = 4;
            this.butPassing.Text = "&Passing";
            this.butPassing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPassing.UseVisualStyleBackColor = true;
            this.butPassing.Click += new System.EventHandler(this.butPassing_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(493, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpIBLDrRePassing
            // 
            this.grpIBLDrRePassing.Controls.Add(this.rdoByDateTime);
            this.grpIBLDrRePassing.Controls.Add(this.rdoByRegisterNo);
            this.grpIBLDrRePassing.Controls.Add(this.rdoByBranchCode);
            this.grpIBLDrRePassing.Location = new System.Drawing.Point(12, 42);
            this.grpIBLDrRePassing.Name = "grpIBLDrRePassing";
            this.grpIBLDrRePassing.Size = new System.Drawing.Size(200, 130);
            this.grpIBLDrRePassing.TabIndex = 6;
            this.grpIBLDrRePassing.TabStop = false;
            this.grpIBLDrRePassing.Text = "Choose Type of Passing";
            // 
            // rdoByDateTime
            // 
            this.rdoByDateTime.AutoSize = true;
            this.rdoByDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoByDateTime.IsSendTabOnEnter = true;
            this.rdoByDateTime.Location = new System.Drawing.Point(58, 62);
            this.rdoByDateTime.Name = "rdoByDateTime";
            this.rdoByDateTime.Size = new System.Drawing.Size(89, 17);
            this.rdoByDateTime.TabIndex = 5;
            this.rdoByDateTime.Text = "&By Date Time";
            this.rdoByDateTime.UseVisualStyleBackColor = true;
            // 
            // rdoByRegisterNo
            // 
            this.rdoByRegisterNo.AutoSize = true;
            this.rdoByRegisterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoByRegisterNo.IsSendTabOnEnter = true;
            this.rdoByRegisterNo.Location = new System.Drawing.Point(58, 98);
            this.rdoByRegisterNo.Name = "rdoByRegisterNo";
            this.rdoByRegisterNo.Size = new System.Drawing.Size(99, 17);
            this.rdoByRegisterNo.TabIndex = 6;
            this.rdoByRegisterNo.Text = "&By Register No.";
            this.rdoByRegisterNo.UseVisualStyleBackColor = true;
            // 
            // rdoByBranchCode
            // 
            this.rdoByBranchCode.AutoSize = true;
            this.rdoByBranchCode.Checked = true;
            this.rdoByBranchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoByBranchCode.IsSendTabOnEnter = true;
            this.rdoByBranchCode.Location = new System.Drawing.Point(58, 25);
            this.rdoByBranchCode.Name = "rdoByBranchCode";
            this.rdoByBranchCode.Size = new System.Drawing.Size(102, 17);
            this.rdoByBranchCode.TabIndex = 4;
            this.rdoByBranchCode.TabStop = true;
            this.rdoByBranchCode.Text = "&By Branch Code";
            this.rdoByBranchCode.UseVisualStyleBackColor = true;
            // 
            // frmTLMVEW00029
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 224);
            this.Controls.Add(this.grpIBLDrRePassing);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.butPassing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTLMVEW00029";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IBL Drawing Remittance Passing";
            this.Load += new System.EventHandler(this.frmTLMVEW00029_Load);
            this.grpIBLDrRePassing.ResumeLayout(false);
            this.grpIBLDrRePassing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0007 butPassing;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpIBLDrRePassing;
        private Windows.CXClient.Controls.CXC0009 rdoByDateTime;
        private Windows.CXClient.Controls.CXC0009 rdoByRegisterNo;
        private Windows.CXClient.Controls.CXC0009 rdoByBranchCode;
    }
}