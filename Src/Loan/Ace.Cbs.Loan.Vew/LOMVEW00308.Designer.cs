namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00308
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00308));
            this.LOMDTO00307BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFLTotalDailyIncome = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00307BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvFLTotalDailyIncome
            // 
            this.rpvFLTotalDailyIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLOMRDLC00024";
            reportDataSource1.Value = this.LOMDTO00307BindingSource;
            this.rpvFLTotalDailyIncome.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFLTotalDailyIncome.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Loan.Vew.RDLC.LOMRDLC00024.rdlc";
            this.rpvFLTotalDailyIncome.Location = new System.Drawing.Point(0, 0);
            this.rpvFLTotalDailyIncome.Name = "rpvFLTotalDailyIncome";
            this.rpvFLTotalDailyIncome.Size = new System.Drawing.Size(615, 460);
            this.rpvFLTotalDailyIncome.TabIndex = 1;
            // 
            // LOMVEW00308
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvFLTotalDailyIncome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00308";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00308_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOMDTO00307BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvFLTotalDailyIncome;
        private System.Windows.Forms.BindingSource LOMDTO00307BindingSource;
    }
}