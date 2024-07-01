namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00060
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00060));
            this.cboRequiredDuration = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblRequiredDuration = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.SuspendLayout();
            // 
            // cboRequiredDuration
            // 
            this.cboRequiredDuration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRequiredDuration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequiredDuration.DropDownHeight = 200;
            this.cboRequiredDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequiredDuration.FormattingEnabled = true;
            this.cboRequiredDuration.IntegralHeight = false;
            this.cboRequiredDuration.IsSendTabOnEnter = true;
            this.cboRequiredDuration.Location = new System.Drawing.Point(132, 59);
            this.cboRequiredDuration.Name = "cboRequiredDuration";
            this.cboRequiredDuration.Size = new System.Drawing.Size(115, 21);
            this.cboRequiredDuration.TabIndex = 71;
            // 
            // lblRequiredDuration
            // 
            this.lblRequiredDuration.AutoSize = true;
            this.lblRequiredDuration.Location = new System.Drawing.Point(14, 62);
            this.lblRequiredDuration.Name = "lblRequiredDuration";
            this.lblRequiredDuration.Size = new System.Drawing.Size(102, 13);
            this.lblRequiredDuration.TabIndex = 72;
            this.lblRequiredDuration.Text = "Required Duration  :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 73;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // MNMVEW00060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 111);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRequiredDuration);
            this.Controls.Add(this.cboRequiredDuration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00060";
            this.Text = "Fixed Account Listing (By Duration)";
            this.Load += new System.EventHandler(this.MNMVEW00060_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboRequiredDuration;
        private Windows.CXClient.Controls.CXC0003 lblRequiredDuration;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;

    }
}