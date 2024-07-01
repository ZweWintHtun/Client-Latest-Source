namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00100));
            this.MNMDTO00032BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSavingBalance = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00032BindingSource
            // 
            this.MNMDTO00032BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.DTO.MNMDTO00032);
            // 
            // rpvSavingBalance
            // 
            this.rpvSavingBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS0020";
            reportDataSource1.Value = this.MNMDTO00032BindingSource;
            this.rpvSavingBalance.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSavingBalance.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00020.rdlc";
            this.rpvSavingBalance.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingBalance.Name = "rpvSavingBalance";
            this.rpvSavingBalance.Size = new System.Drawing.Size(659, 420);
            this.rpvSavingBalance.TabIndex = 0;
            // 
            // MNMVEW00100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 420);
            this.Controls.Add(this.rpvSavingBalance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00100";
            this.Text = "Saving Balance (Interest)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingBalance;
        private System.Windows.Forms.BindingSource MNMDTO00032BindingSource;
    }
}