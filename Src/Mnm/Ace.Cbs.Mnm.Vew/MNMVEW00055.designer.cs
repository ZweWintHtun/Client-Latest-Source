namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00055
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00055));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblCounterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEnterDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboCounterNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.dtpEnterDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.chkBeforeEditing = new Ace.Windows.CXClient.Controls.CXC0008();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dgvCashControl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(495, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblCounterNo
            // 
            this.lblCounterNo.AutoSize = true;
            this.lblCounterNo.Location = new System.Drawing.Point(17, 78);
            this.lblCounterNo.Name = "lblCounterNo";
            this.lblCounterNo.Size = new System.Drawing.Size(70, 13);
            this.lblCounterNo.TabIndex = 38;
            this.lblCounterNo.Text = "Counter No. :";
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.Location = new System.Drawing.Point(17, 106);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(64, 13);
            this.lblEnterDate.TabIndex = 39;
            this.lblEnterDate.Text = "Enter Date :";
            // 
            // cboCounterNo
            // 
            this.cboCounterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCounterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCounterNo.DropDownHeight = 200;
            this.cboCounterNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCounterNo.FormattingEnabled = true;
            this.cboCounterNo.IntegralHeight = false;
            this.cboCounterNo.IsSendTabOnEnter = true;
            this.cboCounterNo.Location = new System.Drawing.Point(108, 74);
            this.cboCounterNo.Name = "cboCounterNo";
            this.cboCounterNo.Size = new System.Drawing.Size(115, 21);
            this.cboCounterNo.TabIndex = 2;
            // 
            // dtpEnterDate
            // 
            this.dtpEnterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEnterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnterDate.IsSendTabOnEnter = true;
            this.dtpEnterDate.Location = new System.Drawing.Point(108, 103);
            this.dtpEnterDate.Name = "dtpEnterDate";
            this.dtpEnterDate.Size = new System.Drawing.Size(115, 20);
            this.dtpEnterDate.TabIndex = 3;
            // 
            // chkBeforeEditing
            // 
            this.chkBeforeEditing.AutoSize = true;
            this.chkBeforeEditing.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkBeforeEditing.IsSendTabOnEnter = true;
            this.chkBeforeEditing.Location = new System.Drawing.Point(20, 134);
            this.chkBeforeEditing.Name = "chkBeforeEditing";
            this.chkBeforeEditing.Size = new System.Drawing.Size(92, 17);
            this.chkBeforeEditing.TabIndex = 4;
            this.chkBeforeEditing.Text = "Before Editing";
            this.chkBeforeEditing.UseVisualStyleBackColor = true;
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
            this.cboCurrency.Location = new System.Drawing.Point(108, 45);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(17, 49);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 49;
            this.lblCurrency.Text = "Currency :";
            // 
            // dgvCashControl
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashControl.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashControl.Location = new System.Drawing.Point(229, 103);
            this.dgvCashControl.Name = "dgvCashControl";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashControl.Size = new System.Drawing.Size(27, 20);
            this.dgvCashControl.TabIndex = 50;
            this.dgvCashControl.Visible = false;
            // 
            // MNMVEW00055
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 170);
            this.Controls.Add(this.dgvCashControl);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.chkBeforeEditing);
            this.Controls.Add(this.dtpEnterDate);
            this.Controls.Add(this.cboCounterNo);
            this.Controls.Add(this.lblEnterDate);
            this.Controls.Add(this.lblCounterNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00055";
            this.Text = "Cash Control Report (By Counter)";
            this.Load += new System.EventHandler(this.MNMVEW00055_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblCounterNo;
        private Windows.CXClient.Controls.CXC0003 lblEnterDate;
        private Windows.CXClient.Controls.CXC0002 cboCounterNo;
        private Windows.CXClient.Controls.CXC0005 dtpEnterDate;
        private Windows.CXClient.Controls.CXC0008 chkBeforeEditing;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private System.Windows.Forms.DataGridView dgvCashControl;

    }
}