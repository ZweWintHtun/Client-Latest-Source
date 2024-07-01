namespace Ace.Cbs.Tel.Vew
{
    partial class frmTLMVEW00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLMVEW00022));
            this.rdoDenoOutStandingReport = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoMultipleTransactionDenoOutstandingReport = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoPOOutstandingNormalReport = new Ace.Windows.CXClient.Controls.CXC0009();
            this.gbDenoOutstanding = new System.Windows.Forms.GroupBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDenoOutstanding.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoDenoOutStandingReport
            // 
            this.rdoDenoOutStandingReport.AutoSize = true;
            this.rdoDenoOutStandingReport.Checked = true;
            this.rdoDenoOutStandingReport.IsSendTabOnEnter = true;
            this.rdoDenoOutStandingReport.Location = new System.Drawing.Point(17, 19);
            this.rdoDenoOutStandingReport.Name = "rdoDenoOutStandingReport";
            this.rdoDenoOutStandingReport.Size = new System.Drawing.Size(146, 17);
            this.rdoDenoOutStandingReport.TabIndex = 1;
            this.rdoDenoOutStandingReport.TabStop = true;
            this.rdoDenoOutStandingReport.Text = "Deno Outstanding Report";
            this.rdoDenoOutStandingReport.UseVisualStyleBackColor = true;
            // 
            // rdoMultipleTransactionDenoOutstandingReport
            // 
            this.rdoMultipleTransactionDenoOutstandingReport.AutoSize = true;
            this.rdoMultipleTransactionDenoOutstandingReport.IsSendTabOnEnter = true;
            this.rdoMultipleTransactionDenoOutstandingReport.Location = new System.Drawing.Point(17, 55);
            this.rdoMultipleTransactionDenoOutstandingReport.Name = "rdoMultipleTransactionDenoOutstandingReport";
            this.rdoMultipleTransactionDenoOutstandingReport.Size = new System.Drawing.Size(244, 17);
            this.rdoMultipleTransactionDenoOutstandingReport.TabIndex = 2;
            this.rdoMultipleTransactionDenoOutstandingReport.Text = "Multiple Transaction Deno Outstanding Report";
            this.rdoMultipleTransactionDenoOutstandingReport.UseVisualStyleBackColor = true;
            // 
            // rdoPOOutstandingNormalReport
            // 
            this.rdoPOOutstandingNormalReport.AutoSize = true;
            this.rdoPOOutstandingNormalReport.IsSendTabOnEnter = true;
            this.rdoPOOutstandingNormalReport.Location = new System.Drawing.Point(17, 93);
            this.rdoPOOutstandingNormalReport.Name = "rdoPOOutstandingNormalReport";
            this.rdoPOOutstandingNormalReport.Size = new System.Drawing.Size(231, 17);
            this.rdoPOOutstandingNormalReport.TabIndex = 3;
            this.rdoPOOutstandingNormalReport.Text = "Dealer Payment Outstanding Normal Report";
            this.rdoPOOutstandingNormalReport.UseVisualStyleBackColor = true;
            // 
            // gbDenoOutstanding
            // 
            this.gbDenoOutstanding.Controls.Add(this.rdoDenoOutStandingReport);
            this.gbDenoOutstanding.Controls.Add(this.rdoMultipleTransactionDenoOutstandingReport);
            this.gbDenoOutstanding.Controls.Add(this.rdoPOOutstandingNormalReport);
            this.gbDenoOutstanding.Location = new System.Drawing.Point(12, 39);
            this.gbDenoOutstanding.Name = "gbDenoOutstanding";
            this.gbDenoOutstanding.Size = new System.Drawing.Size(281, 125);
            this.gbDenoOutstanding.TabIndex = 0;
            this.gbDenoOutstanding.TabStop = false;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 57;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // frmTLMVEW00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 182);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbDenoOutstanding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTLMVEW00022";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deno Outstanding Listing";
            this.Load += new System.EventHandler(this.TLMVEW00022_Load);
            this.gbDenoOutstanding.ResumeLayout(false);
            this.gbDenoOutstanding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0009 rdoDenoOutStandingReport;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoMultipleTransactionDenoOutstandingReport;
        private Ace.Windows.CXClient.Controls.CXC0009 rdoPOOutstandingNormalReport;
        private System.Windows.Forms.GroupBox gbDenoOutstanding;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;

    }
}