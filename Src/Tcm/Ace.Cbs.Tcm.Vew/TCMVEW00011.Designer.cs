namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00011
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00011));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEntryNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCounterNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtUserNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblUserNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAmount = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtType = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEntryNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(494, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEntryNo);
            this.groupBox1.Controls.Add(this.txtCounterNo);
            this.groupBox1.Controls.Add(this.lblCounterNo);
            this.groupBox1.Controls.Add(this.txtUserNo);
            this.groupBox1.Controls.Add(this.lblUserNo);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblEntryNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEntryNo.IsSendTabOnEnter = true;
            this.txtEntryNo.Location = new System.Drawing.Point(111, 19);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(141, 20);
            this.txtEntryNo.TabIndex = 1;
            // 
            // txtCounterNo
            // 
            this.txtCounterNo.Enabled = false;
            this.txtCounterNo.IsSendTabOnEnter = true;
            this.txtCounterNo.Location = new System.Drawing.Point(111, 123);
            this.txtCounterNo.Name = "txtCounterNo";
            this.txtCounterNo.Size = new System.Drawing.Size(141, 20);
            this.txtCounterNo.TabIndex = 5;
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(15, 127);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(70, 13);
            this.lblCounterNo.TabIndex = 0;
            this.lblCounterNo.Text = "Counter No. :";
            // 
            // txtUserNo
            // 
            this.txtUserNo.Enabled = false;
            this.txtUserNo.IsSendTabOnEnter = true;
            this.txtUserNo.Location = new System.Drawing.Point(111, 97);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(141, 20);
            this.txtUserNo.TabIndex = 4;
            // 
            // lblUserNo
            // 
            this.lblUserNo.AutoSize = true;
            this.lblUserNo.Location = new System.Drawing.Point(15, 101);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(55, 13);
            this.lblUserNo.TabIndex = 0;
            this.lblUserNo.Text = "User No. :";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.IsSendTabOnEnter = true;
            this.txtAmount.Location = new System.Drawing.Point(111, 71);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(141, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(15, 75);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount :";
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.IsSendTabOnEnter = true;
            this.txtType.Location = new System.Drawing.Point(111, 45);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(141, 20);
            this.txtType.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(15, 50);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type :";
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Location = new System.Drawing.Point(15, 22);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(57, 13);
            this.lblEntryNo.TabIndex = 0;
            this.lblEntryNo.Text = "Entry No. :";
            // 
            // TCMVEW00011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 209);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00011";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Individual Denomination Delete Entry";
            this.Load += new System.EventHandler(this.TCMVEW00011_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0006 txtCounterNo;
        private Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Windows.CXClient.Controls.CXC0006 txtUserNo;
        private Windows.CXClient.Controls.CXC0003 lblUserNo;
        private Windows.CXClient.Controls.CXC0006 txtAmount;
        private Windows.CXClient.Controls.CXC0003 lblAmount;
        private Windows.CXClient.Controls.CXC0006 txtType;
        private Windows.CXClient.Controls.CXC0003 lblType;
        private Windows.CXClient.Controls.CXC0003 lblEntryNo;
        private Windows.CXClient.Controls.CXC0006 txtEntryNo;
    }
}