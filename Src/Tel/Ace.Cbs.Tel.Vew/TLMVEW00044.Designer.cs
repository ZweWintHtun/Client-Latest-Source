namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00044
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00044));
            this.TLMDTO00009BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvMultiDeno = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00009BindingSource
            // 
            this.TLMDTO00009BindingSource.DataMember = "DenoOutstandingMultipleTransactionDTO";
            // 
            // rpvMultiDeno
            // 
            this.rpvMultiDeno.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MultiTransactionDenoOutstandingDataSet";
            reportDataSource1.Value = this.TLMDTO00009BindingSource;
            this.rpvMultiDeno.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvMultiDeno.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00002.rdlc";
            this.rpvMultiDeno.Location = new System.Drawing.Point(0, 0);
            this.rpvMultiDeno.Name = "rpvMultiDeno";
            this.rpvMultiDeno.Size = new System.Drawing.Size(731, 516);
            this.rpvMultiDeno.TabIndex = 1;
            // 
            // TLMVEW00044
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 516);
            this.Controls.Add(this.rpvMultiDeno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00044";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TLMVEW00044";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00044_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvMultiDeno;
        private System.Windows.Forms.BindingSource TLMDTO00009BindingSource;
    }
}