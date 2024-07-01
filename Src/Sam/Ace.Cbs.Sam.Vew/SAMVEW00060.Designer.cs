namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00060));
            this.rptTownship = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TownshipDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TownshipDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptTownship
            // 
            this.rptTownship.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Township_DataSet";
            reportDataSource1.Value = null;
            this.rptTownship.LocalReport.DataSources.Add(reportDataSource1);
            this.rptTownship.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00006.rdlc";
            this.rptTownship.Location = new System.Drawing.Point(0, 0);
            this.rptTownship.Name = "rptTownship";
            this.rptTownship.Size = new System.Drawing.Size(566, 380);
            this.rptTownship.TabIndex = 0;
            // 
            // TownshipDTOBindingSource
            // 
            this.TownshipDTOBindingSource.DataSource = typeof(Ace.Windows.Admin.DataModel.TownshipDTO);
            // 
            // SAMVEW00060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptTownship);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00060";
            this.Text = "Township Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00060_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00060_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TownshipDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptTownship;
        private System.Windows.Forms.BindingSource TownshipDTOBindingSource;


      
    }
}