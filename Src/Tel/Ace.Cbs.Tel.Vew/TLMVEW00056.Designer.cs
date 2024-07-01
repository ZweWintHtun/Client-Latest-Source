namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00056
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00056));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDrawingRegisterOutstandingByReceiptDate = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataMember = "TLMDTO00017";
            // 
            // rpvDrawingRegisterOutstandingByReceiptDate
            // 
            this.rpvDrawingRegisterOutstandingByReceiptDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDrawingRegisterOutstandingByReceiptDate.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "DrawingRemittanceRegisterOutstanding";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00014.rdlc";
            this.rpvDrawingRegisterOutstandingByReceiptDate.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingRegisterOutstandingByReceiptDate.Name = "rpvDrawingRegisterOutstandingByReceiptDate";
            this.rpvDrawingRegisterOutstandingByReceiptDate.Size = new System.Drawing.Size(964, 451);
            this.rpvDrawingRegisterOutstandingByReceiptDate.TabIndex = 0;
            // 
            // TLMVEW00056
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvDrawingRegisterOutstandingByReceiptDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00056";
            this.Text = "Drawing Remittance Register Outstanding By Receipt Date";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00056_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingRegisterOutstandingByReceiptDate;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}