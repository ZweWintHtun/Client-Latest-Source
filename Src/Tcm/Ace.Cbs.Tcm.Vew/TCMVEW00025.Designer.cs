namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00025
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00025));
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.dtpDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.chkWithReversal = new System.Windows.Forms.CheckBox();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Enter Date :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(16, 95);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 1;
            this.lblCurrency.Text = "Currency :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-4, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(500, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            this.tsbCRUD.Load += new System.EventHandler(this.tsbCRUD_Load);
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
            this.cboCurrency.Items.AddRange(new object[] {
            "KYT",
            "USD",
            "FEC",
            "SGD"});
            this.cboCurrency.Location = new System.Drawing.Point(116, 92);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.IsSendTabOnEnter = true;
            this.dtpDate.Location = new System.Drawing.Point(116, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // chkWithReversal
            // 
            this.chkWithReversal.AutoSize = true;
            this.chkWithReversal.Location = new System.Drawing.Point(19, 128);
            this.chkWithReversal.Name = "chkWithReversal";
            this.chkWithReversal.Size = new System.Drawing.Size(93, 17);
            this.chkWithReversal.TabIndex = 3;
            this.chkWithReversal.Text = "With Reversal";
            this.chkWithReversal.UseVisualStyleBackColor = true;
            // 
            // gbName
            // 
            this.gbName.Location = new System.Drawing.Point(9, 37);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(474, 114);
            this.gbName.TabIndex = 109;
            this.gbName.TabStop = false;
            this.gbName.Text = "Cash Declaration";
            // 
            // TCMVEW00025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 163);
            this.Controls.Add(this.chkWithReversal);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.gbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00025";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Declaration";
            this.Load += new System.EventHandler(this.TCMVEW00025_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCurrency;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0005 dtpDate;
        private System.Windows.Forms.CheckBox chkWithReversal;
        private System.Windows.Forms.GroupBox gbName;
    }
}