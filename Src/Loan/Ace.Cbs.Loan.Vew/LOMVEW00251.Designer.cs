namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00251
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00251));
            this.crReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crReportViewer1
            // 
            this.crReportViewer1.ActiveViewIndex = -1;
            this.crReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crReportViewer1.Name = "crReportViewer1";
            this.crReportViewer1.Size = new System.Drawing.Size(596, 352);
            this.crReportViewer1.TabIndex = 0;
            this.crReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // LOMVEW00251
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 352);
            this.Controls.Add(this.crReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00251";
            this.Text = "PLContractPrinting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOMVEW00251_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crReportViewer1;

    }
}