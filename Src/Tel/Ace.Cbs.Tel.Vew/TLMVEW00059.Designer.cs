namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00059
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00059));
            this.EncashRegisterOutstandingDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpnEncashOutstanding = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.EncashRegisterOutstandingDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EncashRegisterOutstandingDTOBindingSource
            // 
            this.EncashRegisterOutstandingDTOBindingSource.DataMember = "EncashRegisterOutstandingDTO";
            // 
            // rpnEncashOutstanding
            // 
            this.rpnEncashOutstanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpnEncashOutstanding.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "EncashRegisterOutstandingDataSet";
            reportDataSource1.Value = this.EncashRegisterOutstandingDTOBindingSource;
            this.rpnEncashOutstanding.LocalReport.DataSources.Add(reportDataSource1);
            this.rpnEncashOutstanding.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00017.rdlc";
            this.rpnEncashOutstanding.Location = new System.Drawing.Point(0, 0);
            this.rpnEncashOutstanding.Name = "rpnEncashOutstanding";
            this.rpnEncashOutstanding.Size = new System.Drawing.Size(964, 451);
            this.rpnEncashOutstanding.TabIndex = 1;
            // 
            // TLMVEW00059
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpnEncashOutstanding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00059";
            this.Text = "Encash Remittance Register Outstanding";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00059_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EncashRegisterOutstandingDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpnEncashOutstanding;
        private System.Windows.Forms.BindingSource EncashRegisterOutstandingDTOBindingSource;
    }
}