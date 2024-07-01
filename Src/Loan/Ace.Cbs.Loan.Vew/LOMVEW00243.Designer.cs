namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00243
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00243));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtPNLAC = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00033 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDesp = new Ace.Windows.CXClient.Controls.CXC0001();
            this.cxC00034 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.dgvIncomeLists = new System.Windows.Forms.DataGridView();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboBranch = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cboCurrency = new Ace.Windows.CXClient.Controls.CXC0002();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00035 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDatetime = new Ace.Windows.CXClient.Controls.CXC0003();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cxC00036 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRecordsCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomeLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(549, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtPNLAC
            // 
            this.txtPNLAC.AcceptsTab = true;
            this.txtPNLAC.IsSendTabOnEnter = true;
            this.txtPNLAC.Location = new System.Drawing.Point(153, 124);
            this.txtPNLAC.MaxLength = 6;
            this.txtPNLAC.Multiline = true;
            this.txtPNLAC.Name = "txtPNLAC";
            this.txtPNLAC.Size = new System.Drawing.Size(96, 20);
            this.txtPNLAC.TabIndex = 2;
            this.txtPNLAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPNLAC_KeyDown);
            this.txtPNLAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPNLAC_KeyPress);
            // 
            // cxC00033
            // 
            this.cxC00033.AutoSize = true;
            this.cxC00033.Location = new System.Drawing.Point(29, 127);
            this.cxC00033.Name = "cxC00033";
            this.cxC00033.Size = new System.Drawing.Size(103, 13);
            this.cxC00033.TabIndex = 215;
            this.cxC00033.Text = "Profit and Loss AC  :";
            // 
            // txtDesp
            // 
            this.txtDesp.IsSendTabOnEnter = true;
            this.txtDesp.Location = new System.Drawing.Point(153, 157);
            this.txtDesp.MaxLength = 15;
            this.txtDesp.Multiline = true;
            this.txtDesp.Name = "txtDesp";
            this.txtDesp.ReadOnly = true;
            this.txtDesp.Size = new System.Drawing.Size(242, 40);
            this.txtDesp.TabIndex = 216;
            // 
            // cxC00034
            // 
            this.cxC00034.AutoSize = true;
            this.cxC00034.Location = new System.Drawing.Point(23, 160);
            this.cxC00034.Name = "cxC00034";
            this.cxC00034.Size = new System.Drawing.Size(109, 13);
            this.cxC00034.TabIndex = 217;
            this.cxC00034.Text = "Account Description :";
            // 
            // dgvIncomeLists
            // 
            this.dgvIncomeLists.AllowUserToAddRows = false;
            this.dgvIncomeLists.AllowUserToDeleteRows = false;
            this.dgvIncomeLists.AllowUserToOrderColumns = true;
            this.dgvIncomeLists.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncomeLists.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIncomeLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncomeLists.Location = new System.Drawing.Point(24, 213);
            this.dgvIncomeLists.Name = "dgvIncomeLists";
            this.dgvIncomeLists.ReadOnly = true;
            this.dgvIncomeLists.RowHeadersVisible = false;
            this.dgvIncomeLists.Size = new System.Drawing.Size(500, 288);
            this.dgvIncomeLists.TabIndex = 218;
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(57, 62);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(75, 13);
            this.cxC00032.TabIndex = 219;
            this.cxC00032.Text = "Branch Code :";
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
            this.cboBranch.Location = new System.Drawing.Point(153, 59);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(96, 21);
            this.cboBranch.TabIndex = 0;
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
            this.cboCurrency.Location = new System.Drawing.Point(153, 90);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(96, 21);
            this.cboCurrency.TabIndex = 1;
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(77, 93);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(55, 13);
            this.cxC00031.TabIndex = 221;
            this.cxC00031.Text = "Currency :";
            // 
            // cxC00035
            // 
            this.cxC00035.AutoSize = true;
            this.cxC00035.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxC00035.Location = new System.Drawing.Point(345, 62);
            this.cxC00035.Name = "cxC00035";
            this.cxC00035.Size = new System.Drawing.Size(95, 13);
            this.cxC00035.TabIndex = 223;
            this.cxC00035.Text = "Transaction Date :";
            this.cxC00035.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDatetime
            // 
            this.lblDatetime.AutoSize = true;
            this.lblDatetime.Location = new System.Drawing.Point(446, 62);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(0, 13);
            this.lblDatetime.TabIndex = 224;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cxC00036
            // 
            this.cxC00036.AutoSize = true;
            this.cxC00036.Location = new System.Drawing.Point(21, 509);
            this.cxC00036.Name = "cxC00036";
            this.cxC00036.Size = new System.Drawing.Size(83, 13);
            this.cxC00036.TabIndex = 225;
            this.cxC00036.Text = "Total Records =";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(110, 509);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(0, 13);
            this.lblRecordsCount.TabIndex = 226;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(340, 509);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(28, 13);
            this.lblTotalAmount.TabIndex = 228;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LOMVEW00243
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 536);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.cxC00036);
            this.Controls.Add(this.lblDatetime);
            this.Controls.Add(this.cxC00035);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.dgvIncomeLists);
            this.Controls.Add(this.txtDesp);
            this.Controls.Add(this.cxC00034);
            this.Controls.Add(this.txtPNLAC);
            this.Controls.Add(this.cxC00033);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00243";
            this.Text = "Profit & Loss Balance Zerorization For Income";
            this.Load += new System.EventHandler(this.LOMVEW00243_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomeLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0001 txtPNLAC;
        private Windows.CXClient.Controls.CXC0003 cxC00033;
        private Windows.CXClient.Controls.CXC0001 txtDesp;
        private Windows.CXClient.Controls.CXC0003 cxC00034;
        private System.Windows.Forms.DataGridView dgvIncomeLists;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0002 cboBranch;
        private Windows.CXClient.Controls.CXC0002 cboCurrency;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00035;
        private Windows.CXClient.Controls.CXC0003 lblDatetime;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Windows.CXClient.Controls.CXC0003 lblRecordsCount;
        private Windows.CXClient.Controls.CXC0003 cxC00036;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}