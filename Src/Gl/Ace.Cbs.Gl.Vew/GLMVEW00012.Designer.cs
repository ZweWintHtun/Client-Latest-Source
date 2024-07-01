namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00012
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00012));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPLA = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.dgvPLA = new System.Windows.Forms.DataGridView();
            this.AccountCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACType1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboPITA = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPITA = new System.Windows.Forms.DataGridView();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLA)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPITA)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1029, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPLA);
            this.groupBox1.Controls.Add(this.dgvPLA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 393);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profit And Loss Account for this year";
            // 
            // cboPLA
            // 
            this.cboPLA.AutoComplete = false;
            this.cboPLA.AutoDropdown = false;
            this.cboPLA.BackColorEven = System.Drawing.Color.White;
            this.cboPLA.BackColorOdd = System.Drawing.Color.White;
            this.cboPLA.ColumnNames = "";
            this.cboPLA.ColumnWidthDefault = 60;
            this.cboPLA.ColumnWidths = "200,400";
            this.cboPLA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPLA.FormattingEnabled = true;
            this.cboPLA.LinkedColumnIndex = 0;
            this.cboPLA.LinkedTextBox = null;
            this.cboPLA.Location = new System.Drawing.Point(139, 32);
            this.cboPLA.Name = "cboPLA";
            this.cboPLA.Size = new System.Drawing.Size(121, 21);
            this.cboPLA.TabIndex = 1;
            this.cboPLA.SelectedIndexChanged += new System.EventHandler(this.cboPLA_SelectedIndexChanged);
            // 
            // dgvPLA
            // 
            this.dgvPLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountCode1,
            this.AccountName1,
            this.DCode1,
            this.ACType1});
            this.dgvPLA.Location = new System.Drawing.Point(6, 75);
            this.dgvPLA.Name = "dgvPLA";
            this.dgvPLA.Size = new System.Drawing.Size(501, 312);
            this.dgvPLA.TabIndex = 2;
            // 
            // AccountCode1
            // 
            this.AccountCode1.DataPropertyName = "ACode";
            this.AccountCode1.HeaderText = "AccountCode";
            this.AccountCode1.Name = "AccountCode1";
            this.AccountCode1.ReadOnly = true;
            // 
            // AccountName1
            // 
            this.AccountName1.DataPropertyName = "AccountName";
            this.AccountName1.HeaderText = "AccountName";
            this.AccountName1.Name = "AccountName1";
            this.AccountName1.ReadOnly = true;
            this.AccountName1.Width = 177;
            // 
            // DCode1
            // 
            this.DCode1.DataPropertyName = "DCode";
            this.DCode1.HeaderText = "DCode";
            this.DCode1.Name = "DCode1";
            this.DCode1.ReadOnly = true;
            // 
            // ACType1
            // 
            this.ACType1.DataPropertyName = "ACType";
            this.ACType1.HeaderText = "ACType";
            this.ACType1.Name = "ACType1";
            this.ACType1.ReadOnly = true;
            this.ACType1.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Code";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboPITA);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dgvPITA);
            this.groupBox3.Location = new System.Drawing.Point(534, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 393);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payable Income Tax";
            // 
            // cboPITA
            // 
            this.cboPITA.AutoComplete = false;
            this.cboPITA.AutoDropdown = false;
            this.cboPITA.BackColorEven = System.Drawing.Color.White;
            this.cboPITA.BackColorOdd = System.Drawing.Color.White;
            this.cboPITA.ColumnNames = "";
            this.cboPITA.ColumnWidthDefault = 60;
            this.cboPITA.ColumnWidths = "200,400";
            this.cboPITA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPITA.FormattingEnabled = true;
            this.cboPITA.LinkedColumnIndex = 0;
            this.cboPITA.LinkedTextBox = null;
            this.cboPITA.Location = new System.Drawing.Point(139, 32);
            this.cboPITA.Name = "cboPITA";
            this.cboPITA.Size = new System.Drawing.Size(121, 21);
            this.cboPITA.TabIndex = 1;
            this.cboPITA.SelectedIndexChanged += new System.EventHandler(this.cboPITA_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Code";
            // 
            // dgvPITA
            // 
            this.dgvPITA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPITA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountCode,
            this.AccountName,
            this.DCode,
            this.ACType});
            this.dgvPITA.Location = new System.Drawing.Point(7, 75);
            this.dgvPITA.Name = "dgvPITA";
            this.dgvPITA.Size = new System.Drawing.Size(501, 312);
            this.dgvPITA.TabIndex = 2;
            // 
            // AccountCode
            // 
            this.AccountCode.DataPropertyName = "ACode";
            this.AccountCode.HeaderText = "Account Code";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "AccountName";
            this.AccountName.HeaderText = "Account Name";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.Width = 177;
            // 
            // DCode
            // 
            this.DCode.DataPropertyName = "DCode";
            this.DCode.HeaderText = "DCode";
            this.DCode.Name = "DCode";
            this.DCode.ReadOnly = true;
            // 
            // ACType
            // 
            this.ACType.DataPropertyName = "ACType";
            this.ACType.HeaderText = "ACType";
            this.ACType.Name = "ACType";
            this.ACType.ReadOnly = true;
            this.ACType.Width = 80;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(972, 451);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // GLMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 486);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00012";
            this.Text = "GLVEW00012";
            this.Load += new System.EventHandler(this.GLMVEW00012_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPITA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPLA;
        private System.Windows.Forms.DataGridView dgvPITA;
        private System.Windows.Forms.Button btnOk;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboPLA;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cboPITA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACType1;
    }
}