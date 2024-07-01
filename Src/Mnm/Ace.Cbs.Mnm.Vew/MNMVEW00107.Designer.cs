namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00107
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00107));
            this.rptFixedDepositAll = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptFixedDepositAll
            // 
            this.rptFixedDepositAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptFixedDepositAll.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00027.rdlc";
            this.rptFixedDepositAll.Location = new System.Drawing.Point(0, 0);
            this.rptFixedDepositAll.Name = "rptFixedDepositAll";
            this.rptFixedDepositAll.Size = new System.Drawing.Size(679, 482);
            this.rptFixedDepositAll.TabIndex = 0;
            // 
            // MNMVEW00107
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 482);
            this.Controls.Add(this.rptFixedDepositAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00107";
            this.Text = "MNMVEW00107";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00107_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptFixedDepositAll;
    }
}