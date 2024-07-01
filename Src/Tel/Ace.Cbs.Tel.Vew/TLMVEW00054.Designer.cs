namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00054
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00054));
            this.TLMDTO00058BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvSavingAndFixedDayBook = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00058BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00058BindingSource
            // 
            this.TLMDTO00058BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00058);
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvSavingAndFixedDayBook
            // 
            this.rpvSavingAndFixedDayBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvSavingAndFixedDayBook.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "SavingDayBook_DataSet";
            reportDataSource1.Value = this.TLMDTO00058BindingSource;
            this.rpvSavingAndFixedDayBook.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSavingAndFixedDayBook.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00012.rdlc";
            this.rpvSavingAndFixedDayBook.Location = new System.Drawing.Point(0, 0);
            this.rpvSavingAndFixedDayBook.Name = "rpvSavingAndFixedDayBook";
            this.rpvSavingAndFixedDayBook.Size = new System.Drawing.Size(964, 451);
            this.rpvSavingAndFixedDayBook.TabIndex = 3;
            // 
            // TLMVEW00054
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvSavingAndFixedDayBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00054";
            this.Text = "Saving Day Book Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00054_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00058BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSavingAndFixedDayBook;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
        private System.Windows.Forms.BindingSource TLMDTO00058BindingSource;
    }
}