namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00058
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00058));
            this.rptCity = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CityDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CityDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptCity
            // 
            this.rptCity.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "City_DataSet";
            reportDataSource1.Value = null;
            this.rptCity.LocalReport.DataSources.Add(reportDataSource1);
            this.rptCity.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00004.rdlc";
            this.rptCity.Location = new System.Drawing.Point(0, 0);
            this.rptCity.Name = "rptCity";
            this.rptCity.Size = new System.Drawing.Size(566, 380);
            this.rptCity.TabIndex = 0;
            // 
            // CityDTOBindingSource
            // 
            this.CityDTOBindingSource.DataSource = typeof(Ace.Windows.Admin.DataModel.CityDTO);
            // 
            // SAMVEW00058
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptCity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00058";
            this.Text = "City Code Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00058_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00058_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CityDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CityDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rptCity;
    }
}