using System;
using System.Collections.Specialized;
namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00053
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00053));
            this.TLMDTO00017BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCurrentDayBook = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00017BindingSource
            // 
            this.TLMDTO00017BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00017);
            // 
            // rpvCurrentDayBook
            // 
            this.rpvCurrentDayBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCurrentDayBook.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "DrawingOutstanding_DataSet";
            reportDataSource1.Value = this.TLMDTO00017BindingSource;
            this.rpvCurrentDayBook.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCurrentDayBook.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00011.rdlc";
            this.rpvCurrentDayBook.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentDayBook.Name = "rpvCurrentDayBook";
            this.rpvCurrentDayBook.Size = new System.Drawing.Size(964, 451);
            this.rpvCurrentDayBook.TabIndex = 2;
            // 
            // TLMVEW00053
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.rpvCurrentDayBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00053";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00053_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00017BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentDayBook;
        private System.Windows.Forms.BindingSource TLMDTO00017BindingSource;
    }
}