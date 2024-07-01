namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00079
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00079));
            this.PFMDTO00014BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvChequePrinting = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00014BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00014BindingSource
            // 
            this.PFMDTO00014BindingSource.DataSource = typeof(Ace.Cbs.Pfm.Dmd.PFMDTO00014);
            // 
            // rpvChequePrinting
            // 
            this.rpvChequePrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSPFMRDLC00014";
            reportDataSource1.Value = this.PFMDTO00014BindingSource;
            this.rpvChequePrinting.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvChequePrinting.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00014.rdlc";
            this.rpvChequePrinting.Location = new System.Drawing.Point(0, 0);
            this.rpvChequePrinting.Name = "rpvChequePrinting";
            this.rpvChequePrinting.Size = new System.Drawing.Size(662, 476);
            this.rpvChequePrinting.TabIndex = 2;
            // 
            // PFMVEW00079
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.rpvChequePrinting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PFMVEW00079";
            this.Text = "Cheque Printing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00079_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00014BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvChequePrinting;
        private System.Windows.Forms.BindingSource PFMDTO00014BindingSource;
    }
}