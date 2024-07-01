namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00061
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00061));
            this.BranchDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptBranch = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.BranchDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BranchDTOBindingSource
            // 
            this.BranchDTOBindingSource.DataSource = typeof(Ace.Windows.Admin.DataModel.BranchDTO);
            // 
            // rptBranch
            // 
            this.rptBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Branch_DataSet";
            reportDataSource1.Value = this.BranchDTOBindingSource;
            this.rptBranch.LocalReport.DataSources.Add(reportDataSource1);
            this.rptBranch.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00007.rdlc";
            this.rptBranch.Location = new System.Drawing.Point(0, 0);
            this.rptBranch.Name = "rptBranch";
            this.rptBranch.Size = new System.Drawing.Size(566, 380);
            this.rptBranch.TabIndex = 0;
            // 
            // SAMVEW00061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptBranch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00061";
            this.Text = "Branch Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00061_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00061_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BranchDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptBranch;
        private System.Windows.Forms.BindingSource BranchDTOBindingSource;
    }
}