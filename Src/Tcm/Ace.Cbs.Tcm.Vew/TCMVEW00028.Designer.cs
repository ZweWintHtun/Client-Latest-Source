namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00028
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00028));
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.dtpSdate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(30, 62);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(36, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Date :";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(30, 99);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(55, 13);
            this.cxC00032.TabIndex = 2;
            this.cxC00032.Text = "Currency :";
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
            this.cboCurrency.Location = new System.Drawing.Point(91, 99);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(117, 21);
            this.cboCurrency.TabIndex = 2;
            // 
            // dtpSdate
            // 
            this.dtpSdate.CustomFormat = "dd/MMM/yyyy";
            this.dtpSdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSdate.IsSendTabOnEnter = true;
            this.dtpSdate.Location = new System.Drawing.Point(91, 62);
            this.dtpSdate.Name = "dtpSdate";
            this.dtpSdate.Size = new System.Drawing.Size(116, 20);
            this.dtpSdate.TabIndex = 1;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(481, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbName
            // 
            this.gbName.Location = new System.Drawing.Point(12, 36);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(453, 106);
            this.gbName.TabIndex = 110;
            this.gbName.TabStop = false;
            this.gbName.Text = "Day Book Summary";
            // 
            // TCMVEW00028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 154);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.dtpSdate);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.gbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00028";
            this.Text = "Day Book Summary";
            this.Load += new System.EventHandler(this.TCMVEW00028_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0005 dtpSdate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbName;
    }
}