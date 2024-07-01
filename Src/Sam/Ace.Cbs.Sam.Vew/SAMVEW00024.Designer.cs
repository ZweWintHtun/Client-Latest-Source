namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00024
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00024));
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblSymbol = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtSymbol = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblD1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblD2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvDenomationSetup = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtD1 = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtD2 = new Ace.Windows.CXClient.Controls.CXC0004();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomationSetup)).BeginInit();
            this.SuspendLayout();
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
            this.cboCurrency.Location = new System.Drawing.Point(104, 39);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(12, 43);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(104, 66);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(12, 170);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(47, 13);
            this.lblSymbol.TabIndex = 0;
            this.lblSymbol.Text = "Symbol :";
            // 
            // txtSymbol
            // 
            this.txtSymbol.IsSendTabOnEnter = true;
            this.txtSymbol.Location = new System.Drawing.Point(104, 166);
            this.txtSymbol.MaxLength = 5;
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(57, 20);
            this.txtSymbol.TabIndex = 5;
            this.txtSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSymbol_KeyPress);
            // 
            // lblD1
            // 
            this.lblD1.AutoSize = true;
            this.lblD1.Location = new System.Drawing.Point(12, 118);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(27, 13);
            this.lblD1.TabIndex = 0;
            this.lblD1.Text = "D1 :";
            // 
            // lblD2
            // 
            this.lblD2.AutoSize = true;
            this.lblD2.Location = new System.Drawing.Point(12, 145);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(27, 13);
            this.lblD2.TabIndex = 0;
            this.lblD2.Text = "D2 :";
            // 
            // gvDenomationSetup
            // 
            this.gvDenomationSetup.AllowUserToAddRows = false;
            this.gvDenomationSetup.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDenomationSetup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDenomationSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDenomationSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colCurrency,
            this.colDescription,
            this.colD1,
            this.colD2,
            this.colSymbol,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDenomationSetup.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDenomationSetup.EnableHeadersVisualStyles = false;
            this.gvDenomationSetup.IdTSList = null;
            this.gvDenomationSetup.IsEscapeKey = false;
            this.gvDenomationSetup.IsHeaderClick = false;
            this.gvDenomationSetup.Location = new System.Drawing.Point(13, 192);
            this.gvDenomationSetup.Name = "gvDenomationSetup";
            this.gvDenomationSetup.RowHeadersWidth = 25;
            this.gvDenomationSetup.ShowSerialNo = false;
            this.gvDenomationSetup.Size = new System.Drawing.Size(724, 350);
            this.gvDenomationSetup.TabIndex = 7;
            this.gvDenomationSetup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomationSetup_CellContentClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.TrueValue = "true";
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "Currency";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colD1
            // 
            this.colD1.DataPropertyName = "D1";
            this.colD1.HeaderText = "D1";
            this.colD1.Name = "colD1";
            this.colD1.ReadOnly = true;
            // 
            // colD2
            // 
            this.colD2.DataPropertyName = "D2";
            this.colD2.HeaderText = "D2";
            this.colD2.Name = "colD2";
            this.colD2.ReadOnly = true;
            // 
            // colSymbol
            // 
            this.colSymbol.DataPropertyName = "Symbol";
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(104, 549);
            this.txtRecordCount.MaxLength = 5;
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 8;
            this.txtRecordCount.Text = "0";
            this.txtRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecordCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(12, 552);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count :";
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
            this.tsbCRUD.Size = new System.Drawing.Size(787, 31);
            this.tsbCRUD.TabIndex = 6;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtD1
            // 
            this.txtD1.DecimalPlaces = 0;
            this.txtD1.IsSendTabOnEnter = true;
            this.txtD1.Location = new System.Drawing.Point(104, 115);
            this.txtD1.MaxLength = 5;
            this.txtD1.Name = "txtD1";
            this.txtD1.Size = new System.Drawing.Size(121, 20);
            this.txtD1.TabIndex = 3;
            this.txtD1.Text = "0";
            this.txtD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtD1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtD1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtD1_KeyPress);
            // 
            // txtD2
            // 
            this.txtD2.DecimalPlaces = 0;
            this.txtD2.IsSendTabOnEnter = true;
            this.txtD2.Location = new System.Drawing.Point(104, 141);
            this.txtD2.MaxLength = 5;
            this.txtD2.Name = "txtD2";
            this.txtD2.Size = new System.Drawing.Size(121, 20);
            this.txtD2.TabIndex = 4;
            this.txtD2.Text = "0";
            this.txtD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtD2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtD2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtD2_KeyPress);
            // 
            // SAMVEW00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 576);
            this.Controls.Add(this.txtD2);
            this.Controls.Add(this.txtD1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvDenomationSetup);
            this.Controls.Add(this.lblD2);
            this.Controls.Add(this.lblD1);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00024";
            this.Text = "Denomination Setup Entry";
            this.Load += new System.EventHandler(this.SAMVEW00024_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomationSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0003 lblSymbol;
        private Windows.CXClient.Controls.CXC0001 txtSymbol;
        private Windows.CXClient.Controls.CXC0003 lblD1;
        private Windows.CXClient.Controls.CXC0003 lblD2;
        private Windows.CXClient.Controls.AceGridView gvDenomationSetup;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtD1;
        private Windows.CXClient.Controls.CXC0004 txtD2;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}