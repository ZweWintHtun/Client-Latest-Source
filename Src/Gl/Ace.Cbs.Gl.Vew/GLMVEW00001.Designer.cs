namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00001
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00001));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvCurrencyRate = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJanuary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFebruary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApril = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJune = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAugust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeptember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOctober = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNovember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrencyRate)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(1032, 31);
            this.tsbCRUD.TabIndex = 23;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvCurrencyRate
            // 
            this.gvCurrencyRate.AllowUserToAddRows = false;
            this.gvCurrencyRate.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCurrencyRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCurrencyRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCurrencyRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colCurrency,
            this.colDescription,
            this.colJanuary,
            this.colFebruary,
            this.colMarch,
            this.colApril,
            this.colMay,
            this.colJune,
            this.colJuly,
            this.colAugust,
            this.colSeptember,
            this.colOctober,
            this.colNovember,
            this.colDecember});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCurrencyRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCurrencyRate.EnableHeadersVisualStyles = false;
            this.gvCurrencyRate.IdTSList = null;
            this.gvCurrencyRate.IsEscapeKey = false;
            this.gvCurrencyRate.IsHeaderClick = false;
            this.gvCurrencyRate.Location = new System.Drawing.Point(12, 44);
            this.gvCurrencyRate.Name = "gvCurrencyRate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCurrencyRate.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvCurrencyRate.RowHeadersWidth = 25;
            this.gvCurrencyRate.ShowSerialNo = false;
            this.gvCurrencyRate.Size = new System.Drawing.Size(1008, 348);
            this.gvCurrencyRate.TabIndex = 24;
            this.gvCurrencyRate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCurrencyRate_CellContentClick);
            this.gvCurrencyRate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvCurrencyRate_CellFormatting);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "Cur";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            this.colCurrency.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 150;
            // 
            // colJanuary
            // 
            this.colJanuary.DataPropertyName = "Month1Ammount";
            this.colJanuary.HeaderText = "January";
            this.colJanuary.Name = "colJanuary";
            this.colJanuary.ReadOnly = true;
            this.colJanuary.Width = 80;
            // 
            // colFebruary
            // 
            this.colFebruary.DataPropertyName = "Month2Ammount";
            this.colFebruary.HeaderText = "February";
            this.colFebruary.Name = "colFebruary";
            this.colFebruary.ReadOnly = true;
            this.colFebruary.Width = 80;
            // 
            // colMarch
            // 
            this.colMarch.DataPropertyName = "Month3Ammount";
            this.colMarch.HeaderText = "March";
            this.colMarch.Name = "colMarch";
            this.colMarch.ReadOnly = true;
            this.colMarch.Width = 80;
            // 
            // colApril
            // 
            this.colApril.DataPropertyName = "Month4Ammount";
            this.colApril.HeaderText = "April";
            this.colApril.Name = "colApril";
            this.colApril.ReadOnly = true;
            this.colApril.Width = 80;
            // 
            // colMay
            // 
            this.colMay.DataPropertyName = "Month5Ammount";
            this.colMay.HeaderText = "May";
            this.colMay.Name = "colMay";
            this.colMay.ReadOnly = true;
            this.colMay.Width = 80;
            // 
            // colJune
            // 
            this.colJune.DataPropertyName = "Month6Ammount";
            this.colJune.HeaderText = "June";
            this.colJune.Name = "colJune";
            this.colJune.ReadOnly = true;
            this.colJune.Width = 80;
            // 
            // colJuly
            // 
            this.colJuly.DataPropertyName = "Month7Ammount";
            this.colJuly.HeaderText = "July";
            this.colJuly.Name = "colJuly";
            this.colJuly.ReadOnly = true;
            this.colJuly.Width = 80;
            // 
            // colAugust
            // 
            this.colAugust.DataPropertyName = "Month8Ammount";
            this.colAugust.HeaderText = "August";
            this.colAugust.Name = "colAugust";
            this.colAugust.ReadOnly = true;
            this.colAugust.Width = 80;
            // 
            // colSeptember
            // 
            this.colSeptember.DataPropertyName = "Month9Ammount";
            this.colSeptember.HeaderText = "September";
            this.colSeptember.Name = "colSeptember";
            this.colSeptember.ReadOnly = true;
            this.colSeptember.Width = 80;
            // 
            // colOctober
            // 
            this.colOctober.DataPropertyName = "Month10Ammount";
            this.colOctober.HeaderText = "October";
            this.colOctober.Name = "colOctober";
            this.colOctober.ReadOnly = true;
            this.colOctober.Width = 80;
            // 
            // colNovember
            // 
            this.colNovember.DataPropertyName = "Month11Ammount";
            this.colNovember.HeaderText = "November";
            this.colNovember.Name = "colNovember";
            this.colNovember.ReadOnly = true;
            this.colNovember.Width = 80;
            // 
            // colDecember
            // 
            this.colDecember.DataPropertyName = "Month12Ammount";
            this.colDecember.HeaderText = "December";
            this.colDecember.Name = "colDecember";
            this.colDecember.ReadOnly = true;
            this.colDecember.Width = 80;
            // 
            // GLMVEW00001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 400);
            this.Controls.Add(this.gvCurrencyRate);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00001";
            this.Text = "Currency Rate By Month";
            this.Load += new System.EventHandler(this.GLMVEW00001_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrencyRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvCurrencyRate;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJanuary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFebruary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApril;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJune;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAugust;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeptember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOctober;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNovember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecember;
    }
}