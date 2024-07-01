namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00130
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00130));
            this.rpvDrawingPrinting = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvDrawingPrinting
            // 
            this.rpvDrawingPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDrawingPrinting.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00050.rdlc";
            this.rpvDrawingPrinting.Location = new System.Drawing.Point(0, 0);
            this.rpvDrawingPrinting.Name = "rpvDrawingPrinting";
            this.rpvDrawingPrinting.Size = new System.Drawing.Size(541, 370);
            this.rpvDrawingPrinting.TabIndex = 0;
            // 
            // MNMVEW00130
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 370);
            this.Controls.Add(this.rpvDrawingPrinting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00130";
            this.Text = "RD Important Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00130_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDrawingPrinting;

    }
}