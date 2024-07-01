namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00057
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00057));
            this.rptInitial = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PFMDTO00003BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00003BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptInitial
            // 
            this.rptInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Initial_DataSet";
            reportDataSource1.Value = null;
            this.rptInitial.LocalReport.DataSources.Add(reportDataSource1);
            this.rptInitial.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00003.rdlc";
            this.rptInitial.Location = new System.Drawing.Point(0, 0);
            this.rptInitial.Name = "rptInitial";
            this.rptInitial.Size = new System.Drawing.Size(566, 380);
            this.rptInitial.TabIndex = 0;
            // 
            // PFMDTO00003BindingSource
            // 
            this.PFMDTO00003BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00003);
            // 
            // SAMVEW00057
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptInitial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00057";
            this.Text = "Initial Code Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00057_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00057_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00003BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PFMDTO00003BindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rptInitial;

        
    }
}