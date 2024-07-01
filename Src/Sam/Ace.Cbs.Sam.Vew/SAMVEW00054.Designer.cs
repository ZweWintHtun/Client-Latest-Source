namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00054
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00054));
            this.rdoAllBranch = new System.Windows.Forms.RadioButton();
            this.rdoByState = new System.Windows.Forms.RadioButton();
            this.chkRemitRate = new System.Windows.Forms.CheckBox();
            this.cboStateCode = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbBranchCodeListing = new System.Windows.Forms.GroupBox();
            this.gbBranchCodeListing.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoAllBranch
            // 
            this.rdoAllBranch.AutoSize = true;
            this.rdoAllBranch.Checked = true;
            this.rdoAllBranch.Location = new System.Drawing.Point(33, 20);
            this.rdoAllBranch.Name = "rdoAllBranch";
            this.rdoAllBranch.Size = new System.Drawing.Size(73, 17);
            this.rdoAllBranch.TabIndex = 1;
            this.rdoAllBranch.TabStop = true;
            this.rdoAllBranch.Text = "All Branch";
            this.rdoAllBranch.UseVisualStyleBackColor = true;
            this.rdoAllBranch.CheckedChanged += new System.EventHandler(this.rdoAllBranch_CheckedChanged);
            // 
            // rdoByState
            // 
            this.rdoByState.AutoSize = true;
            this.rdoByState.Location = new System.Drawing.Point(33, 43);
            this.rdoByState.Name = "rdoByState";
            this.rdoByState.Size = new System.Drawing.Size(107, 17);
            this.rdoByState.TabIndex = 2;
            this.rdoByState.Text = "By State/Division";
            this.rdoByState.UseVisualStyleBackColor = true;
            this.rdoByState.CheckedChanged += new System.EventHandler(this.rdoByState_CheckedChanged);
            // 
            // chkRemitRate
            // 
            this.chkRemitRate.AutoSize = true;
            this.chkRemitRate.Location = new System.Drawing.Point(33, 114);
            this.chkRemitRate.Name = "chkRemitRate";
            this.chkRemitRate.Size = new System.Drawing.Size(144, 17);
            this.chkRemitRate.TabIndex = 0;
            this.chkRemitRate.Text = "Include Remittacne Rate";
            this.chkRemitRate.UseVisualStyleBackColor = true;
            // 
            // cboStateCode
            // 
            this.cboStateCode.AutoComplete = false;
            this.cboStateCode.AutoDropdown = false;
            this.cboStateCode.BackColorEven = System.Drawing.Color.White;
            this.cboStateCode.BackColorOdd = System.Drawing.Color.White;
            this.cboStateCode.ColumnNames = "StateCode, Description";
            this.cboStateCode.ColumnWidthDefault = 75;
            this.cboStateCode.ColumnWidths = "";
            this.cboStateCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStateCode.Enabled = false;
            this.cboStateCode.FormattingEnabled = true;
            this.cboStateCode.LinkedColumnIndex = 0;
            this.cboStateCode.LinkedTextBox = null;
            this.cboStateCode.Location = new System.Drawing.Point(33, 76);
            this.cboStateCode.Name = "cboStateCode";
            this.cboStateCode.Size = new System.Drawing.Size(144, 21);
            this.cboStateCode.TabIndex = 3;
            this.cboStateCode.Validated += new System.EventHandler(this.cboStateCode_Validated);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(484, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.cxcliC0011_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.cxcliC0011_ExitButtonClick);
            // 
            // gbBranchCodeListing
            // 
            this.gbBranchCodeListing.Controls.Add(this.rdoAllBranch);
            this.gbBranchCodeListing.Controls.Add(this.rdoByState);
            this.gbBranchCodeListing.Controls.Add(this.chkRemitRate);
            this.gbBranchCodeListing.Controls.Add(this.cboStateCode);
            this.gbBranchCodeListing.Location = new System.Drawing.Point(12, 38);
            this.gbBranchCodeListing.Name = "gbBranchCodeListing";
            this.gbBranchCodeListing.Size = new System.Drawing.Size(244, 147);
            this.gbBranchCodeListing.TabIndex = 0;
            this.gbBranchCodeListing.TabStop = false;
            // 
            // SAMVEW00054
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 199);
            this.Controls.Add(this.gbBranchCodeListing);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00054";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Code Listing";
            this.Load += new System.EventHandler(this.SAMVEW00054_Load);
            this.gbBranchCodeListing.ResumeLayout(false);
            this.gbBranchCodeListing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoAllBranch;
        private System.Windows.Forms.RadioButton rdoByState;
        private System.Windows.Forms.CheckBox chkRemitRate;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboStateCode;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbBranchCodeListing;
    }
}