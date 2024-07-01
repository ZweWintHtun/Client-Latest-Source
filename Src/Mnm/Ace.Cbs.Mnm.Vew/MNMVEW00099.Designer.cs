namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00099
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00099));
            this.MNMDTO00032BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvInterestSchedule = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00032BindingSource
            // 
            this.MNMDTO00032BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.DTO.MNMDTO00032);
            // 
            // rpvInterestSchedule
            // 
            this.rpvInterestSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MNMDS00018";
            reportDataSource1.Value = this.MNMDTO00032BindingSource;
            this.rpvInterestSchedule.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvInterestSchedule.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00019.rdlc";
            this.rpvInterestSchedule.Location = new System.Drawing.Point(0, 0);
            this.rpvInterestSchedule.Name = "rpvInterestSchedule";
            this.rpvInterestSchedule.Size = new System.Drawing.Size(616, 498);
            this.rpvInterestSchedule.TabIndex = 0;
            // 
            // MNMVEW00099
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 498);
            this.Controls.Add(this.rpvInterestSchedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00099";
            this.Text = "Interest Schedule Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MNMVEW00099t_FormClosed);
            this.Load += new System.EventHandler(this.MNMVEW00099_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInterestSchedule;
        private System.Windows.Forms.BindingSource MNMDTO00032BindingSource;
    }
}