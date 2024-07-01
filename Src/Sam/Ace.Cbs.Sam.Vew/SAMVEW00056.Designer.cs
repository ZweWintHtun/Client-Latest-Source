namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00056
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00056));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptOccupation = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PFMDTO00004BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00004BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptOccupation
            // 
            resources.ApplyResources(this.rptOccupation, "rptOccupation");
            reportDataSource1.Name = "Occupation_DataSet";
            reportDataSource1.Value = null;
            this.rptOccupation.LocalReport.DataSources.Add(reportDataSource1);
            this.rptOccupation.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00002.rdlc";
            this.rptOccupation.Name = "rptOccupation";
            // 
            // PFMDTO00004BindingSource
            // 
            this.PFMDTO00004BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00004);
            // 
            // SAMVEW00056
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptOccupation);
            this.Name = "SAMVEW00056";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00056_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00056_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00004BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptOccupation;
        private System.Windows.Forms.BindingSource PFMDTO00004BindingSource;




    }
}