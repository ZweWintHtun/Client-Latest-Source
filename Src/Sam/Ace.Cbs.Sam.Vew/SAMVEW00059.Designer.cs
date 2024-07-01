namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00059
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

        ///// <summary>
        ///// Required method for Designer support - do not modify
        ///// the contents of this method with the code editor.
        ///// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00059));
            this.rptState = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StateDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StateDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptState
            // 
            this.rptState.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "State_DataSet";
            reportDataSource1.Value = null;
            this.rptState.LocalReport.DataSources.Add(reportDataSource1);
            this.rptState.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Sam.Vew.RDLC.SAMRDLC00005.rdlc";
            this.rptState.Location = new System.Drawing.Point(0, 0);
            this.rptState.Name = "rptState";
            this.rptState.Size = new System.Drawing.Size(566, 380);
            this.rptState.TabIndex = 0;
            // 
            // StateDTOBindingSource
            // 
            this.StateDTOBindingSource.DataSource = typeof(Ace.Windows.Admin.DataModel.StateDTO);
            // 
            // SAMVEW00059
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 380);
            this.Controls.Add(this.rptState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00059";
            this.Text = "State Code Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAMVEW00059_FormClosing);
            this.Load += new System.EventHandler(this.SAMVEW00059_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StateDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource StateDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rptState;
    }
}