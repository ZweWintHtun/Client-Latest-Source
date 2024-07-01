namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00029
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
            this.GLMDTO00028BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSFP = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00028BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GLMDTO00028BindingSource
            // 
            this.GLMDTO00028BindingSource.DataSource = typeof(Ace.Cbs.Gl.Dmd.GLMDTO00028);
            // 
            // rpvSFP
            // 
            this.rpvSFP.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSGLMRDLC00028";
            reportDataSource1.Value = this.GLMDTO00028BindingSource;
            this.rpvSFP.LocalReport.DataSources.Add(reportDataSource1);
            //this.rpvSFP.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00028.rdlc";
            this.rpvSFP.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00029.rdlc";
            this.rpvSFP.Location = new System.Drawing.Point(0, 0);
            this.rpvSFP.Name = "rpvSFP";
            this.rpvSFP.Size = new System.Drawing.Size(605, 450);
            this.rpvSFP.TabIndex = 5;
            // 
            // GLMVEW00029
            // ss
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.rpvSFP);
            this.Name = "GLMVEW00029";
            this.Text = "GLMVEW00029";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GLMVEW00029_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00028BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSFP;
        private System.Windows.Forms.BindingSource GLMDTO00028BindingSource;
    }
}