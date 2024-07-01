namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00074
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00074));
            this.TLMDTO00054BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDrawingRemitEntry = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00054BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TLMDTO00054BindingSource
            // 
            this.TLMDTO00054BindingSource.DataSource = typeof(Ace.Cbs.Tel.Dmd.TLMDTO00054);
            // 
            // rpvDrawingRemitEntry
            // 
            this.rpvDrawingRemitEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DrawingRemitDataSet";
            reportDataSource1.Value = this.TLMDTO00054BindingSource;
            this.rpvDrawingRemitEntry.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDrawingRemitEntry.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00030.rdlc";
            this.rpvDrawingRemitEntry.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingRemitEntry.Name = "rpvDrawingRemitEntry";
            this.rpvDrawingRemitEntry.Size = new System.Drawing.Size(579, 306);
            this.rpvDrawingRemitEntry.TabIndex = 0;
            // 
            // TLMVEW00074
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 304);
            this.Controls.Add(this.rpvDrawingRemitEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00074";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TLMVEW00074";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00074_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00054BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingRemitEntry;
        private System.Windows.Forms.BindingSource TLMDTO00054BindingSource;
    }
}