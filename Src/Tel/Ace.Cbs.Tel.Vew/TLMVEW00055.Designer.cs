namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00055
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00055));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDomesticDayBook = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvDomesticDayBook
            // 
            this.rpvDomesticDayBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDomesticDayBook.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "DrawingOutstanding_DataSet";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvDomesticDayBook.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDomesticDayBook.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00013.rdlc";
            this.rpvDomesticDayBook.Location = new System.Drawing.Point(0, 0);
            this.rpvDomesticDayBook.Name = "rpvDomesticDayBook";
            this.rpvDomesticDayBook.Size = new System.Drawing.Size(964, 451);
            this.rpvDomesticDayBook.TabIndex = 2;
            // 
            // TLMVEW00055
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvDomesticDayBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00055";
            this.Text = "Domestic Day Book Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00055_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDomesticDayBook;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}