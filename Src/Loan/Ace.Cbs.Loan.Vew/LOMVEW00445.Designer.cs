namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00445
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
            this.rpvExtendLimitList = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvExtendLimitList
            // 
            this.rpvExtendLimitList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvExtendLimitList.Location = new System.Drawing.Point(0, 0);
            this.rpvExtendLimitList.Name = "rpvExtendLimitList";
            this.rpvExtendLimitList.Size = new System.Drawing.Size(730, 257);
            this.rpvExtendLimitList.TabIndex = 2;
            // 
            // LOMVEW00445
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 257);
            this.Controls.Add(this.rpvExtendLimitList);
            this.Name = "LOMVEW00445";
            this.Text = "Limit Extend List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00445_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvExtendLimitList;
    }
}