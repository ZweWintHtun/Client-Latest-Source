namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00025
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00025));
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.lblCurrency = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblbranchcode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranchCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTelexCharge = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gvRemittanceBranchAndRate = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colStartAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFixAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrdiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCSdiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbldrawingAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDrawingAccount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblEncashAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtEashaccount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblcommissionAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txComssAccount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTelexAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txttelexAccount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblIRpoAccount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtIRpoaccount = new Ace.Windows.CXClient.Controls.CXC0001();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.gvRemittanceBranchAndRate)).BeginInit();
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
            this.cboCurrency.Location = new System.Drawing.Point(130, 41);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(11, 44);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblbranchcode
            // 
            this.lblbranchcode.AutoSize = true;
            this.lblbranchcode.Location = new System.Drawing.Point(11, 71);
            this.lblbranchcode.Name = "lblbranchcode";
            this.lblbranchcode.Size = new System.Drawing.Size(75, 13);
            this.lblbranchcode.TabIndex = 0;
            this.lblbranchcode.Text = "Branch Code :";
            // 
            // cboBranchCode
            // 
            this.cboBranchCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBranchCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBranchCode.DropDownHeight = 200;
            this.cboBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchCode.FormattingEnabled = true;
            this.cboBranchCode.IntegralHeight = false;
            this.cboBranchCode.IsSendTabOnEnter = true;
            this.cboBranchCode.Location = new System.Drawing.Point(130, 68);
            this.cboBranchCode.Name = "cboBranchCode";
            this.cboBranchCode.Size = new System.Drawing.Size(121, 21);
            this.cboBranchCode.TabIndex = 2;
            this.cboBranchCode.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(11, 98);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(81, 13);
            this.cxC00031.TabIndex = 0;
            this.cxC00031.Text = "Telex Charges :";
            // 
            // txtTelexCharge
            // 
            this.txtTelexCharge.DecimalPlaces = 2;
            this.txtTelexCharge.IsSendTabOnEnter = true;
            this.txtTelexCharge.IsUseFloatingPoint = true;
            this.txtTelexCharge.Location = new System.Drawing.Point(130, 95);
            this.txtTelexCharge.MaxLength = 9;
            this.txtTelexCharge.Name = "txtTelexCharge";
            this.txtTelexCharge.Size = new System.Drawing.Size(121, 20);
            this.txtTelexCharge.TabIndex = 3;
            this.txtTelexCharge.Text = "0.00";
            this.txtTelexCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTelexCharge.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTelexCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelexCharge_KeyPress);
            // 
            // gvRemittanceBranchAndRate
            // 
            this.gvRemittanceBranchAndRate.AllowUserToResizeRows = false;
            this.gvRemittanceBranchAndRate.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvRemittanceBranchAndRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvRemittanceBranchAndRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRemittanceBranchAndRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStartAmount,
            this.colEndAmount,
            this.colRate,
            this.colFixAmount,
            this.colTrdiscount,
            this.colCSdiscount});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRemittanceBranchAndRate.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvRemittanceBranchAndRate.EnableHeadersVisualStyles = false;
            this.gvRemittanceBranchAndRate.IdTSList = null;
            this.gvRemittanceBranchAndRate.IsEscapeKey = false;
            this.gvRemittanceBranchAndRate.IsHeaderClick = false;
            this.gvRemittanceBranchAndRate.Location = new System.Drawing.Point(14, 252);
            this.gvRemittanceBranchAndRate.Name = "gvRemittanceBranchAndRate";
            this.gvRemittanceBranchAndRate.RowHeadersWidth = 25;
            this.gvRemittanceBranchAndRate.ShowSerialNo = false;
            this.gvRemittanceBranchAndRate.Size = new System.Drawing.Size(653, 247);
            this.gvRemittanceBranchAndRate.TabIndex = 9;
            this.gvRemittanceBranchAndRate.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvRemittanceBranchAndRate_CellValidating);
            this.gvRemittanceBranchAndRate.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvRemittanceBranchAndRate_EditingControlShowing);
            // 
            // colStartAmount
            // 
            this.colStartAmount.DataPropertyName = "StartNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.colStartAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStartAmount.HeaderText = "Start Amount";
            this.colStartAmount.Name = "colStartAmount";
            // 
            // colEndAmount
            // 
            this.colEndAmount.DataPropertyName = "EndNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.colEndAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEndAmount.HeaderText = "End Amount";
            this.colEndAmount.Name = "colEndAmount";
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "Rate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.colRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            // 
            // colFixAmount
            // 
            this.colFixAmount.DataPropertyName = "FixAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.colFixAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFixAmount.HeaderText = "Fix Amount";
            this.colFixAmount.Name = "colFixAmount";
            // 
            // colTrdiscount
            // 
            this.colTrdiscount.DataPropertyName = "TrDiscount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.colTrdiscount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTrdiscount.HeaderText = "Tr : Discount";
            this.colTrdiscount.Name = "colTrdiscount";
            // 
            // colCSdiscount
            // 
            this.colCSdiscount.DataPropertyName = "CsDiscount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0.00";
            this.colCSdiscount.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCSdiscount.HeaderText = "CS : Discount";
            this.colCSdiscount.Name = "colCSdiscount";
            // 
            // lbldrawingAccount
            // 
            this.lbldrawingAccount.AutoSize = true;
            this.lbldrawingAccount.Location = new System.Drawing.Point(11, 124);
            this.lbldrawingAccount.Name = "lbldrawingAccount";
            this.lbldrawingAccount.Size = new System.Drawing.Size(98, 13);
            this.lbldrawingAccount.TabIndex = 0;
            this.lbldrawingAccount.Text = "Drawing Account : ";
            // 
            // txtDrawingAccount
            // 
            this.txtDrawingAccount.IsSendTabOnEnter = true;
            this.txtDrawingAccount.Location = new System.Drawing.Point(130, 121);
            this.txtDrawingAccount.MaxLength = 6;
            this.txtDrawingAccount.Name = "txtDrawingAccount";
            this.txtDrawingAccount.Size = new System.Drawing.Size(100, 20);
            this.txtDrawingAccount.TabIndex = 4;
            this.txtDrawingAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrawingAccount_KeyPress);
            // 
            // lblEncashAccount
            // 
            this.lblEncashAccount.AutoSize = true;
            this.lblEncashAccount.Location = new System.Drawing.Point(11, 150);
            this.lblEncashAccount.Name = "lblEncashAccount";
            this.lblEncashAccount.Size = new System.Drawing.Size(92, 13);
            this.lblEncashAccount.TabIndex = 0;
            this.lblEncashAccount.Text = "Encash Account :";
            // 
            // txtEashaccount
            // 
            this.txtEashaccount.IsSendTabOnEnter = true;
            this.txtEashaccount.Location = new System.Drawing.Point(130, 147);
            this.txtEashaccount.MaxLength = 6;
            this.txtEashaccount.Name = "txtEashaccount";
            this.txtEashaccount.Size = new System.Drawing.Size(100, 20);
            this.txtEashaccount.TabIndex = 5;
            this.txtEashaccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEashaccount_KeyPress);
            // 
            // lblcommissionAccount
            // 
            this.lblcommissionAccount.AutoSize = true;
            this.lblcommissionAccount.Location = new System.Drawing.Point(11, 176);
            this.lblcommissionAccount.Name = "lblcommissionAccount";
            this.lblcommissionAccount.Size = new System.Drawing.Size(111, 13);
            this.lblcommissionAccount.TabIndex = 0;
            this.lblcommissionAccount.Text = "Commission Account :";
            // 
            // txComssAccount
            // 
            this.txComssAccount.IsSendTabOnEnter = true;
            this.txComssAccount.Location = new System.Drawing.Point(130, 173);
            this.txComssAccount.MaxLength = 6;
            this.txComssAccount.Name = "txComssAccount";
            this.txComssAccount.Size = new System.Drawing.Size(100, 20);
            this.txComssAccount.TabIndex = 6;
            this.txComssAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txComssAccount_KeyPress);
            // 
            // lblTelexAccount
            // 
            this.lblTelexAccount.AutoSize = true;
            this.lblTelexAccount.Location = new System.Drawing.Point(11, 202);
            this.lblTelexAccount.Name = "lblTelexAccount";
            this.lblTelexAccount.Size = new System.Drawing.Size(82, 13);
            this.lblTelexAccount.TabIndex = 0;
            this.lblTelexAccount.Text = "Telex Account :";
            // 
            // txttelexAccount
            // 
            this.txttelexAccount.IsSendTabOnEnter = true;
            this.txttelexAccount.Location = new System.Drawing.Point(130, 199);
            this.txttelexAccount.MaxLength = 6;
            this.txttelexAccount.Name = "txttelexAccount";
            this.txttelexAccount.Size = new System.Drawing.Size(100, 20);
            this.txttelexAccount.TabIndex = 7;
            this.txttelexAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttelexAccount_KeyPress);
            // 
            // lblIRpoAccount
            // 
            this.lblIRpoAccount.AutoSize = true;
            this.lblIRpoAccount.Location = new System.Drawing.Point(11, 228);
            this.lblIRpoAccount.Name = "lblIRpoAccount";
            this.lblIRpoAccount.Size = new System.Drawing.Size(85, 13);
            this.lblIRpoAccount.TabIndex = 0;
            this.lblIRpoAccount.Text = "IR PO Account :";
            // 
            // txtIRpoaccount
            // 
            this.txtIRpoaccount.IsSendTabOnEnter = true;
            this.txtIRpoaccount.Location = new System.Drawing.Point(130, 225);
            this.txtIRpoaccount.MaxLength = 6;
            this.txtIRpoaccount.Name = "txtIRpoaccount";
            this.txtIRpoaccount.Size = new System.Drawing.Size(100, 20);
            this.txtIRpoaccount.TabIndex = 8;
            this.txtIRpoaccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIRpoaccount_KeyPress);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.CausesValidation = false;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(786, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // SAMVEW00025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtIRpoaccount);
            this.Controls.Add(this.lblIRpoAccount);
            this.Controls.Add(this.txttelexAccount);
            this.Controls.Add(this.lblTelexAccount);
            this.Controls.Add(this.txComssAccount);
            this.Controls.Add(this.lblcommissionAccount);
            this.Controls.Add(this.txtEashaccount);
            this.Controls.Add(this.lblEncashAccount);
            this.Controls.Add(this.txtDrawingAccount);
            this.Controls.Add(this.lbldrawingAccount);
            this.Controls.Add(this.gvRemittanceBranchAndRate);
            this.Controls.Add(this.txtTelexCharge);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cboBranchCode);
            this.Controls.Add(this.lblbranchcode);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.lblCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00025";
            this.Text = "IBL Rate Entry";
            this.Load += new System.EventHandler(this.SAMVEW00025_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRemittanceBranchAndRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 lblCurrency;
        private Windows.CXClient.Controls.CXC0003 lblbranchcode;
        private Windows.CXClient.Controls.CXC0002 cboBranchCode;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0004 txtTelexCharge;
        private Windows.CXClient.Controls.AceGridView gvRemittanceBranchAndRate;
        private Windows.CXClient.Controls.CXC0003 lbldrawingAccount;
        private Windows.CXClient.Controls.CXC0001 txtDrawingAccount;
        private Windows.CXClient.Controls.CXC0003 lblEncashAccount;
        private Windows.CXClient.Controls.CXC0001 txtEashaccount;
        private Windows.CXClient.Controls.CXC0003 lblcommissionAccount;
        private Windows.CXClient.Controls.CXC0001 txComssAccount;
        private Windows.CXClient.Controls.CXC0003 lblTelexAccount;
        private Windows.CXClient.Controls.CXC0001 txttelexAccount;
        private Windows.CXClient.Controls.CXC0003 lblIRpoAccount;
        private Windows.CXClient.Controls.CXC0001 txtIRpoaccount;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFixAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrdiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCSdiscount;
    }
}