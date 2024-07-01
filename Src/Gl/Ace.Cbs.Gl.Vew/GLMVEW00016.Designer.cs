namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00016
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00016));
            this.GLMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvReportStatement = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GLMDTO00001BindingSource
            // 
            this.GLMDTO00001BindingSource.DataSource = typeof(Ace.Cbs.Gl.Dmd.GLMDTO00001);
            // 
            // rpvReportStatement
            // 
            this.rpvReportStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DS00004";
            reportDataSource1.Value = this.GLMDTO00001BindingSource;
            this.rpvReportStatement.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvReportStatement.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00004.rdlc";
            this.rpvReportStatement.Location = new System.Drawing.Point(0, 0);
            this.rpvReportStatement.Name = "rpvReportStatement";
            this.rpvReportStatement.Size = new System.Drawing.Size(529, 361);
            this.rpvReportStatement.TabIndex = 0;
            // 
            // GLMVEW00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 361);
            this.Controls.Add(this.rpvReportStatement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00016";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GLMVEW00016";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GLMVEW00016_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvReportStatement;
        private System.Windows.Forms.BindingSource GLMDTO00001BindingSource;
    }
}