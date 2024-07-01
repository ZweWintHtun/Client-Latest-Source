namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00067
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00067));
            this.TCMDTO00013BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvLedgerBalanceByTransaction = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00013BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TCMDTO00013BindingSource
            // 
            this.TCMDTO00013BindingSource.DataSource = typeof(Ace.Cbs.Tcm.Dmd.TCMDTO00013);
            // 
            // rpvLedgerBalanceByTransaction
            // 
            this.rpvLedgerBalanceByTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "TCMDS00013";
            reportDataSource1.Value = this.TCMDTO00013BindingSource;
            this.rpvLedgerBalanceByTransaction.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvLedgerBalanceByTransaction.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tcm.Vew.RDLC.TCMRDLC00019.rdlc";
            this.rpvLedgerBalanceByTransaction.Location = new System.Drawing.Point(0, 0);
            this.rpvLedgerBalanceByTransaction.Name = "rpvLedgerBalanceByTransaction";
            this.rpvLedgerBalanceByTransaction.Size = new System.Drawing.Size(507, 271);
            this.rpvLedgerBalanceByTransaction.TabIndex = 0;
            // 
            // TCMVEW00067
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 271);
            this.Controls.Add(this.rpvLedgerBalanceByTransaction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00067";
            this.Text = "TCMVEW00067";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TCMVEW00067_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TCMDTO00013BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLedgerBalanceByTransaction;
        private System.Windows.Forms.BindingSource TCMDTO00013BindingSource;
    }
}