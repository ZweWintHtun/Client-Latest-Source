namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00057
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00057));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TLMDTO00001BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDrawingRegisterOutstanding = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvDrawingRegisterOutstanding
            // 
            this.rpvDrawingRegisterOutstanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDrawingRegisterOutstanding.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "DrawingRemittanceRegisterOutstanding";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvDrawingRegisterOutstanding.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDrawingRegisterOutstanding.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00032.rdlc";
            this.rpvDrawingRegisterOutstanding.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingRegisterOutstanding.Name = "rpvDrawingRegisterOutstanding";
            this.rpvDrawingRegisterOutstanding.Size = new System.Drawing.Size(964, 451);
            this.rpvDrawingRegisterOutstanding.TabIndex = 1;
            // 
            // TLMVEW00057
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvDrawingRegisterOutstanding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00057";
            this.Text = "Drawing Remittance Register Outstanding (By Income) Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00057_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00001BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingRegisterOutstanding;
        private System.Windows.Forms.BindingSource TLMDTO00001BindingSource;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}