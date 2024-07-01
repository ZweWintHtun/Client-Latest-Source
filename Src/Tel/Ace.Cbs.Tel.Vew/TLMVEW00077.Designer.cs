namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00077
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00077));
            this.TLMDTO00009BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptCashDenominationMultiTransaction = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00009BindingSource
            // 
            this.TLMDTO00009BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00009);
            // 
            // rptCashDenominationMultiTransaction
            // 
            this.rptCashDenominationMultiTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSCashDenoForMulti";
            reportDataSource1.Value = this.TLMDTO00009BindingSource;
            this.rptCashDenominationMultiTransaction.LocalReport.DataSources.Add(reportDataSource1);
            this.rptCashDenominationMultiTransaction.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00031.rdlc";
            this.rptCashDenominationMultiTransaction.Location = new System.Drawing.Point(0, 0);
            this.rptCashDenominationMultiTransaction.Name = "rptCashDenominationMultiTransaction";
            this.rptCashDenominationMultiTransaction.Size = new System.Drawing.Size(566, 380);
            this.rptCashDenominationMultiTransaction.TabIndex = 0;
            // 
            // TLMVEW00077
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptCashDenominationMultiTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00077";
            this.Text = "TLMVEW00077";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00077_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCashDenominationMultiTransaction;
        private System.Windows.Forms.BindingSource TLMDTO00009BindingSource;
    }
}