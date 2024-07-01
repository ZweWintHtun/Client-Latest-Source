namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00225
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00225));
            this.OptByCompany = new System.Windows.Forms.RadioButton();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.OptALL = new System.Windows.Forms.RadioButton();
            this.cboCompany = new Ace.Windows.CXClient.Controls.CXC0002();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // OptByCompany
            // 
            this.OptByCompany.AutoSize = true;
            this.OptByCompany.Location = new System.Drawing.Point(147, 19);
            this.OptByCompany.Name = "OptByCompany";
            this.OptByCompany.Size = new System.Drawing.Size(115, 17);
            this.OptByCompany.TabIndex = 1;
            this.OptByCompany.Text = "By Company Name";
            this.OptByCompany.UseVisualStyleBackColor = true;
            this.OptByCompany.Click += new System.EventHandler(this.OptByCompany_Click);
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(15, 172);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(88, 13);
            this.cxC00032.TabIndex = 84;
            this.cxC00032.Text = "Company Name :";
            // 
            // OptALL
            // 
            this.OptALL.AutoSize = true;
            this.OptALL.Checked = true;
            this.OptALL.Location = new System.Drawing.Point(33, 19);
            this.OptALL.Name = "OptALL";
            this.OptALL.Size = new System.Drawing.Size(36, 17);
            this.OptALL.TabIndex = 0;
            this.OptALL.TabStop = true;
            this.OptALL.Text = "All";
            this.OptALL.UseVisualStyleBackColor = true;
            this.OptALL.Click += new System.EventHandler(this.OptAll_Click);
            // 
            // cboCompany
            // 
            this.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCompany.DropDownHeight = 200;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.IntegralHeight = false;
            this.cboCompany.IsSendTabOnEnter = true;
            this.cboCompany.Location = new System.Drawing.Point(109, 172);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(115, 21);
            this.cboCompany.TabIndex = 85;
            this.cboCompany.SelectedIndexChanged += new System.EventHandler(this.cboCompany_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptByCompany);
            this.groupBox1.Controls.Add(this.OptALL);
            this.groupBox1.Location = new System.Drawing.Point(18, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 55);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By:";
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
            this.cboCurrency.Location = new System.Drawing.Point(109, 139);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 82;
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranch.DropDownHeight = 200;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.IntegralHeight = false;
            this.cboBranch.IsSendTabOnEnter = true;
            this.cboBranch.Location = new System.Drawing.Point(109, 104);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(115, 21);
            this.cboBranch.TabIndex = 80;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(482, 31);
            this.tsbCRUD.TabIndex = 78;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(15, 139);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 81;
            this.cxC00033.Text = "Currency :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(15, 104);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 79;
            this.cxC00031.Text = "Branch Code :";
            // 
            // LOMVEW00225
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 205);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cxC00031);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00225";
            this.Text = "Personal Loans Daily Position Listing";
            this.Load += new System.EventHandler(this.LOMVEW00225_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton OptByCompany;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private System.Windows.Forms.RadioButton OptALL;
        private Windows.CXClient.Controls.CXC0002 cboCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
    }
}