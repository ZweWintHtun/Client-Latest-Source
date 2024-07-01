namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00006));
            this.rpvCurrentAccountJoint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvCurrentAccountJoint
            // 
            this.rpvCurrentAccountJoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvCurrentAccountJoint.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Pfm.Vew.RDLC.PFMRDLC00008.rdlc";
            this.rpvCurrentAccountJoint.Location = new System.Drawing.Point(0, 0);
            this.rpvCurrentAccountJoint.Name = "rpvCurrentAccountJoint";
            this.rpvCurrentAccountJoint.Size = new System.Drawing.Size(846, 746);
            this.rpvCurrentAccountJoint.TabIndex = 0;
            // 
            // PFMVEW00006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 746);
            this.Controls.Add(this.rpvCurrentAccountJoint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PFMVEW00006";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFMVEW00006";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PFMVEW00006_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurrentAccountJoint;
    }
}