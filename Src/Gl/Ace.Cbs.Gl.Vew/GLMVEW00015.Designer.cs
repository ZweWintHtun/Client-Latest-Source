namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00015
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00015));
            this.GLMDTO00013BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvIncomeExpenditure = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00013BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GLMDTO00013BindingSource
            // 
            this.GLMDTO00013BindingSource.DataSource = typeof(Ace.Cbs.Gl.Dmd.GLMDTO00013);
            // 
            // rpvIncomeExpenditure
            // 
            this.rpvIncomeExpenditure.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "GLMDS00015";
            reportDataSource1.Value = this.GLMDTO00013BindingSource;
            this.rpvIncomeExpenditure.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvIncomeExpenditure.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Gl.Vew.RDLC.GLMRDLC00003.rdlc";
            this.rpvIncomeExpenditure.Location = new System.Drawing.Point(0, 0);
            this.rpvIncomeExpenditure.Name = "rpvIncomeExpenditure";
            this.rpvIncomeExpenditure.Size = new System.Drawing.Size(501, 266);
            this.rpvIncomeExpenditure.TabIndex = 0;
            // 
            // GLMVEW00015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 266);
            this.Controls.Add(this.rpvIncomeExpenditure);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00015";
            this.Text = "GLVEW00015";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GLMVEW00015_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GLMDTO00013BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvIncomeExpenditure;
        private System.Windows.Forms.BindingSource GLMDTO00013BindingSource;

    }
}