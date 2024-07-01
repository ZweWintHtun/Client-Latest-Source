namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00063
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00063));
            this.PFMDTO00042BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DepositListingByAllandByCounterDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TLMDTO00009BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvDepositListingByAll = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositListingByAllandByCounterDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PFMDTO00042BindingSource
            // 
            this.PFMDTO00042BindingSource.DataMember = "PFMDTO00042";
            // 
            // DepositListingByAllandByCounterDTOBindingSource
            // 
            this.DepositListingByAllandByCounterDTOBindingSource.DataMember = "DepositListingByAllandByCounterDTO";
            // 
            // rpvDepositListingByAll
            // 
            this.rpvDepositListingByAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDepositListingByAll.Font = new System.Drawing.Font("Zawgyi-One", 8F);
            reportDataSource1.Name = "DepositListingByAllandByCounterDTO_DataSet";
            reportDataSource1.Value = this.PFMDTO00042BindingSource;
            this.rpvDepositListingByAll.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDepositListingByAll.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Tel.Vew.RDLC.TLMRDLC00021.rdlc";
            this.rpvDepositListingByAll.Location = new System.Drawing.Point(0, 0);
            this.rpvDepositListingByAll.Name = "rpvDepositListingByAll";
            this.rpvDepositListingByAll.Size = new System.Drawing.Size(540, 451);
            this.rpvDepositListingByAll.TabIndex = 1;
            // 
            // TLMVEW00063
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 451);
            this.Controls.Add(this.rpvDepositListingByAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00063";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TLMVEW00063_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PFMDTO00042BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositListingByAllandByCounterDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLMDTO00009BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDepositListingByAll;
        private System.Windows.Forms.BindingSource DepositListingByAllandByCounterDTOBindingSource;
        private System.Windows.Forms.BindingSource TLMDTO00009BindingSource;
        private System.Windows.Forms.BindingSource PFMDTO00042BindingSource;
    }
}