namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00031));
            this.rdoAll = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSelectedRate = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.chkAllStatus = new Ace.Windows.CXClient.Controls.CXC0008();
            this.rdoHistory = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoActive = new Ace.Windows.CXClient.Controls.CXC0009();
            this.cboSelectedRate = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.IsSendTabOnEnter = true;
            this.rdoAll.Location = new System.Drawing.Point(19, 44);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 75;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "&All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoSelectedRate
            // 
            this.rdoSelectedRate.AutoSize = true;
            this.rdoSelectedRate.IsSendTabOnEnter = true;
            this.rdoSelectedRate.Location = new System.Drawing.Point(19, 67);
            this.rdoSelectedRate.Name = "rdoSelectedRate";
            this.rdoSelectedRate.Size = new System.Drawing.Size(93, 17);
            this.rdoSelectedRate.TabIndex = 76;
            this.rdoSelectedRate.Text = "&Selected Rate";
            this.rdoSelectedRate.UseVisualStyleBackColor = true;
            this.rdoSelectedRate.CheckedChanged += new System.EventHandler(this.rdoSelectedRate_CheckedChanged);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(494, 31);
            this.tsbCRUD.TabIndex = 78;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.chkAllStatus);
            this.gbStatus.Controls.Add(this.rdoHistory);
            this.gbStatus.Controls.Add(this.rdoActive);
            this.gbStatus.Location = new System.Drawing.Point(19, 99);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(218, 55);
            this.gbStatus.TabIndex = 79;
            this.gbStatus.TabStop = false;
            // 
            // chkAllStatus
            // 
            this.chkAllStatus.AutoSize = true;
            this.chkAllStatus.IsSendTabOnEnter = true;
            this.chkAllStatus.Location = new System.Drawing.Point(14, 0);
            this.chkAllStatus.Name = "chkAllStatus";
            this.chkAllStatus.Size = new System.Drawing.Size(70, 17);
            this.chkAllStatus.TabIndex = 83;
            this.chkAllStatus.Text = "All Status";
            this.chkAllStatus.UseVisualStyleBackColor = true;
            this.chkAllStatus.CheckedChanged += new System.EventHandler(this.chkAllStatus_CheckedChanged_1);
            // 
            // rdoHistory
            // 
            this.rdoHistory.AutoSize = true;
            this.rdoHistory.IsSendTabOnEnter = true;
            this.rdoHistory.Location = new System.Drawing.Point(124, 24);
            this.rdoHistory.Name = "rdoHistory";
            this.rdoHistory.Size = new System.Drawing.Size(57, 17);
            this.rdoHistory.TabIndex = 81;
            this.rdoHistory.Text = "History";
            this.rdoHistory.UseVisualStyleBackColor = true;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Checked = true;
            this.rdoActive.IsSendTabOnEnter = true;
            this.rdoActive.Location = new System.Drawing.Point(40, 24);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 80;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // cboSelectedRate
            // 
            this.cboSelectedRate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSelectedRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSelectedRate.DropDownHeight = 200;
            this.cboSelectedRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedRate.FormattingEnabled = true;
            this.cboSelectedRate.IntegralHeight = false;
            this.cboSelectedRate.IsSendTabOnEnter = true;
            this.cboSelectedRate.Location = new System.Drawing.Point(129, 65);
            this.cboSelectedRate.Name = "cboSelectedRate";
            this.cboSelectedRate.Size = new System.Drawing.Size(227, 21);
            this.cboSelectedRate.TabIndex = 82;
            // 
            // SAMVEW00031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 173);
            this.Controls.Add(this.cboSelectedRate);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.rdoSelectedRate);
            this.Controls.Add(this.rdoAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SAMVEW00031";
            this.Text = "SAMVEW00031";
            this.Load += new System.EventHandler(this.SAMVEW00031_Load);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0009 rdoAll;
        private Windows.CXClient.Controls.CXC0009 rdoSelectedRate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbStatus;
        private Windows.CXClient.Controls.CXC0009 rdoHistory;
        private Windows.CXClient.Controls.CXC0009 rdoActive;
        private Windows.CXClient.Controls.CXC0002 cboSelectedRate;
        private Windows.CXClient.Controls.CXC0008 chkAllStatus;

    }
}