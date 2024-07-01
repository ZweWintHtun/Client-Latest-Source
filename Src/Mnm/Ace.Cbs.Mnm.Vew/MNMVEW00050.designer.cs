namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00050));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtRequiredYear = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblRequiredYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(494, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtRequiredYear
            // 
            this.mtxtRequiredYear.IsSendTabOnEnter = true;
            this.mtxtRequiredYear.Location = new System.Drawing.Point(178, 92);
            this.mtxtRequiredYear.Mask = "&&&&/&&&&";
            this.mtxtRequiredYear.Name = "mtxtRequiredYear";
            this.mtxtRequiredYear.Size = new System.Drawing.Size(70, 20);
            this.mtxtRequiredYear.TabIndex = 3;
            // 
            // lblRequiredYear
            // 
            this.lblRequiredYear.AutoSize = true;
            this.lblRequiredYear.Location = new System.Drawing.Point(79, 95);
            this.lblRequiredYear.Name = "lblRequiredYear";
            this.lblRequiredYear.Size = new System.Drawing.Size(81, 13);
            this.lblRequiredYear.TabIndex = 78;
            this.lblRequiredYear.Text = "Required Year :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(79, 65);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 78;
            this.lblCurrency.Text = "Currency :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.DropDownHeight = 200;
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.IntegralHeight = false;
            this.cboCurrency.IsSendTabOnEnter = true;
            this.cboCurrency.Location = new System.Drawing.Point(178, 62);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(16, 37);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(462, 100);
            this.grpBeforeDayClose.TabIndex = 79;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Interest Schedule :";
            // 
            // MNMVEW00050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 149);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblRequiredYear);
            this.Controls.Add(this.mtxtRequiredYear);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpBeforeDayClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00050";
            this.Text = "Interest Schedule";
            this.Load += new System.EventHandler(this.MNMVEW00050_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtRequiredYear;
        private Windows.CXClient.Controls.CXC0003 lblRequiredYear;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
    }
}