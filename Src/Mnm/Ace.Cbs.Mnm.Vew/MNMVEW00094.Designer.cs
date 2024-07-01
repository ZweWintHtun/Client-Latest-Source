namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00094
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00094));
            this.MNMDTO00046BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBankStatement = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MNMDTO00010BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00046BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvBankStatement
            // 
            this.rpvBankStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MNMDTO00046BindingSource;
            this.rpvBankStatement.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvBankStatement.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00014.rdlc";
            this.rpvBankStatement.Location = new System.Drawing.Point(0, 0);
            this.rpvBankStatement.Name = "rpvBankStatement";
            this.rpvBankStatement.Size = new System.Drawing.Size(501, 399);
            this.rpvBankStatement.TabIndex = 0;
            // 
            // MNMDTO00010BindingSource
            // 
            this.MNMDTO00010BindingSource.DataMember = "MNMDTO00010";
            // 
            // MNMVEW00094
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 399);
            this.Controls.Add(this.rpvBankStatement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00094";
            this.Text = "MNMVEW00094";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00094_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00046BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBankStatement;
        private System.Windows.Forms.BindingSource MNMDTO00046BindingSource;
        private System.Windows.Forms.BindingSource MNMDTO00010BindingSource;
    }
}