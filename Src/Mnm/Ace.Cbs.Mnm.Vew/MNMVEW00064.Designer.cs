namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00064
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00064));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblRequiredYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.mtxtRequiredYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(497, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblRequiredYear
            // 
            this.lblRequiredYear.AutoSize = true;
            this.lblRequiredYear.Location = new System.Drawing.Point(28, 74);
            this.lblRequiredYear.Name = "lblRequiredYear";
            this.lblRequiredYear.Size = new System.Drawing.Size(81, 13);
            this.lblRequiredYear.TabIndex = 12;
            this.lblRequiredYear.Text = "Required Year :";
            // 
            // mtxtRequiredYear
            // 
            this.mtxtRequiredYear.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtRequiredYear.HidePromptOnLeave = true;
            this.mtxtRequiredYear.IsSendTabOnEnter = true;
            this.mtxtRequiredYear.Location = new System.Drawing.Point(120, 71);
            this.mtxtRequiredYear.Mask = "9999/9999";
            this.mtxtRequiredYear.Name = "mtxtRequiredYear";
            this.mtxtRequiredYear.Size = new System.Drawing.Size(100, 20);
            this.mtxtRequiredYear.TabIndex = 13;
            this.mtxtRequiredYear.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(12, 37);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(470, 82);
            this.grpBeforeDayClose.TabIndex = 14;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Saving Interest Payment :";
            // 
            // MNMVEW00064
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 128);
            this.Controls.Add(this.mtxtRequiredYear);
            this.Controls.Add(this.lblRequiredYear);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00064";
            this.Text = "Saving Interest";
            this.Load += new System.EventHandler(this.MNMVEW00064_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblRequiredYear;
        private Windows.CXClient.Controls.CXC0006 mtxtRequiredYear;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
    }
}