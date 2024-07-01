namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00224
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00224));
            this.OptByBusinessType = new System.Windows.Forms.RadioButton();
            this.cboBusinessType = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.OptALL = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoByBLNo = new System.Windows.Forms.RadioButton();
            this.rdoByAC = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptByBusinessType
            // 
            this.OptByBusinessType.AutoSize = true;
            this.OptByBusinessType.Location = new System.Drawing.Point(199, 19);
            this.OptByBusinessType.Name = "OptByBusinessType";
            this.OptByBusinessType.Size = new System.Drawing.Size(109, 17);
            this.OptByBusinessType.TabIndex = 1;
            this.OptByBusinessType.Text = "By Business Type";
            this.OptByBusinessType.UseVisualStyleBackColor = true;
            this.OptByBusinessType.Click += new System.EventHandler(this.OptByBusinessType_Click);
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBusinessType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBusinessType.DropDownHeight = 200;
            this.cboBusinessType.FormattingEnabled = true;
            this.cboBusinessType.IntegralHeight = false;
            this.cboBusinessType.IsSendTabOnEnter = true;
            this.cboBusinessType.Location = new System.Drawing.Point(130, 221);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Size = new System.Drawing.Size(124, 21);
            this.cboBusinessType.TabIndex = 123;
            this.cboBusinessType.SelectedIndexChanged += new System.EventHandler(this.cboBusinessType_SelectedIndexChanged);
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(35, 221);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(82, 13);
            this.cxC00032.TabIndex = 122;
            this.cxC00032.Text = "Business Type :";
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(35, 191);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(55, 13);
            this.cxC00033.TabIndex = 119;
            this.cxC00033.Text = "Currency :";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(35, 161);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(75, 13);
            this.cxC00031.TabIndex = 117;
            this.cxC00031.Text = "Branch Code :";
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
            this.cboBranch.Location = new System.Drawing.Point(130, 161);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(124, 21);
            this.cboBranch.TabIndex = 118;
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
            this.cboCurrency.Location = new System.Drawing.Point(130, 191);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(124, 21);
            this.cboCurrency.TabIndex = 120;
            // 
            // OptALL
            // 
            this.OptALL.AutoSize = true;
            this.OptALL.Checked = true;
            this.OptALL.Location = new System.Drawing.Point(85, 19);
            this.OptALL.Name = "OptALL";
            this.OptALL.Size = new System.Drawing.Size(36, 17);
            this.OptALL.TabIndex = 0;
            this.OptALL.TabStop = true;
            this.OptALL.Text = "All";
            this.OptALL.UseVisualStyleBackColor = true;
            this.OptALL.Click += new System.EventHandler(this.OptALL_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptByBusinessType);
            this.groupBox1.Controls.Add(this.OptALL);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 59);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By:";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(486, 31);
            this.tsbCRUD.TabIndex = 116;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoByBLNo);
            this.groupBox2.Controls.Add(this.rdoByAC);
            this.groupBox2.Location = new System.Drawing.Point(12, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 44);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort By:";
            // 
            // rdoByBLNo
            // 
            this.rdoByBLNo.AutoSize = true;
            this.rdoByBLNo.Location = new System.Drawing.Point(199, 16);
            this.rdoByBLNo.Name = "rdoByBLNo";
            this.rdoByBLNo.Size = new System.Drawing.Size(73, 17);
            this.rdoByBLNo.TabIndex = 3;
            this.rdoByBLNo.Text = "By BL No ";
            this.rdoByBLNo.UseVisualStyleBackColor = true;
            this.rdoByBLNo.CheckedChanged += new System.EventHandler(this.rdoByBLNo_CheckedChanged);
            // 
            // rdoByAC
            // 
            this.rdoByAC.AutoSize = true;
            this.rdoByAC.Checked = true;
            this.rdoByAC.Location = new System.Drawing.Point(85, 16);
            this.rdoByAC.Name = "rdoByAC";
            this.rdoByAC.Size = new System.Drawing.Size(100, 17);
            this.rdoByAC.TabIndex = 2;
            this.rdoByAC.TabStop = true;
            this.rdoByAC.Text = "By Account No ";
            this.rdoByAC.UseVisualStyleBackColor = true;
            this.rdoByAC.CheckedChanged += new System.EventHandler(this.rdoByAC_CheckedChanged);
            // 
            // LOMVEW00224
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 253);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cboBusinessType);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOMVEW00224";
            this.Text = "Business Loans Installment Listing";
            this.Load += new System.EventHandler(this.LOMVEW00224_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton OptByBusinessType;
        private Windows.CXClient.Controls.CXC0002 cboBusinessType;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private System.Windows.Forms.RadioButton OptALL;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoByBLNo;
        private System.Windows.Forms.RadioButton rdoByAC;
    }
}