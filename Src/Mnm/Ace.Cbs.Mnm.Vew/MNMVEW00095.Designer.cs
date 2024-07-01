namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00095
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00095));
            this.MNMDTO00032BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvBalanceConfirmation = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MNMDTO00032BindingSource
            // 
            this.MNMDTO00032BindingSource.DataSource = typeof(Ace.Cbs.Mnm.Dmd.DTO.MNMDTO00032);
            // 
            // rpvBalanceConfirmation
            // 
            this.rpvBalanceConfirmation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvBalanceConfirmation.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00015.rdlc";
            this.rpvBalanceConfirmation.Location = new System.Drawing.Point(0, 0);
            this.rpvBalanceConfirmation.Name = "rpvBalanceConfirmation";
            this.rpvBalanceConfirmation.Size = new System.Drawing.Size(474, 405);
            this.rpvBalanceConfirmation.TabIndex = 0;
            // 
            // MNMVEW00095
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 405);
            this.Controls.Add(this.rpvBalanceConfirmation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00095";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00095_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00032BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvBalanceConfirmation;
        private System.Windows.Forms.BindingSource MNMDTO00032BindingSource;
    }
}