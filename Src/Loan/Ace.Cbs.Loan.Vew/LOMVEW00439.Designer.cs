namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00439
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
            this.rpvBlackList = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvBlackList
            // 
            this.rpvBlackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBlackList.Location = new System.Drawing.Point(0, 0);
            this.rpvBlackList.Name = "rpvBlackList";
            this.rpvBlackList.Size = new System.Drawing.Size(730, 257);
            this.rpvBlackList.TabIndex = 1;
            // 
            // LOMVEW00439
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 257);
            this.Controls.Add(this.rpvBlackList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00439";
            this.Text = "Warning List Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00439_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBlackList;
    }
}