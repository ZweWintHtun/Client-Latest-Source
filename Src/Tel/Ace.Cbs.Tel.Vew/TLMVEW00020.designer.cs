namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00020
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00020));
            this.lblRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvEncashment = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDRCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.cboRegisterNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.gbEncashRemmit = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvEncashment)).BeginInit();
            this.gbEncashRemmit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegisterNo
            // 
            this.lblRegisterNo.AutoSize = true;
            this.lblRegisterNo.Location = new System.Drawing.Point(24, 58);
            this.lblRegisterNo.Name = "lblRegisterNo";
            this.lblRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblRegisterNo.TabIndex = 0;
            this.lblRegisterNo.Text = "Register No. :";
            // 
            // gvEncashment
            // 
            this.gvEncashment.AllowUserToAddRows = false;
            this.gvEncashment.AllowUserToDeleteRows = false;
            this.gvEncashment.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvEncashment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvEncashment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEncashment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colDescription,
            this.colCurrency,
            this.colAmount,
            this.colDRCR});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvEncashment.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvEncashment.Enabled = false;
            this.gvEncashment.EnableHeadersVisualStyles = false;
            this.gvEncashment.IdTSList = null;
            this.gvEncashment.IsEscapeKey = false;
            this.gvEncashment.IsHeaderClick = false;
            this.gvEncashment.Location = new System.Drawing.Point(14, 51);
            this.gvEncashment.Name = "gvEncashment";
            this.gvEncashment.RowHeadersWidth = 25;
            this.gvEncashment.ShowSerialNo = false;
            this.gvEncashment.Size = new System.Drawing.Size(719, 232);
            this.gvEncashment.TabIndex = 1;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAccountNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.FillWeight = 150F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 160;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "Currency";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCurrency.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // colDRCR
            // 
            this.colDRCR.DataPropertyName = "DebitCredit";
            this.colDRCR.HeaderText = "Dr/Cr";
            this.colDRCR.Name = "colDRCR";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(766, 31);
            this.tsbCRUD.TabIndex = 57;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // cboRegisterNo
            // 
            this.cboRegisterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRegisterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegisterNo.DropDownHeight = 200;
            this.cboRegisterNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegisterNo.FormattingEnabled = true;
            this.cboRegisterNo.IntegralHeight = false;
            this.cboRegisterNo.IsSendTabOnEnter = true;
            this.cboRegisterNo.Location = new System.Drawing.Point(101, 18);
            this.cboRegisterNo.Name = "cboRegisterNo";
            this.cboRegisterNo.Size = new System.Drawing.Size(141, 21);
            this.cboRegisterNo.TabIndex = 2;
            this.cboRegisterNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRegisterNo_KeyDown);
            // 
            // gbEncashRemmit
            // 
            this.gbEncashRemmit.Controls.Add(this.cboRegisterNo);
            this.gbEncashRemmit.Controls.Add(this.gvEncashment);
            this.gbEncashRemmit.Location = new System.Drawing.Point(12, 37);
            this.gbEncashRemmit.Name = "gbEncashRemmit";
            this.gbEncashRemmit.Size = new System.Drawing.Size(740, 302);
            this.gbEncashRemmit.TabIndex = 0;
            this.gbEncashRemmit.TabStop = false;
            // 
            // TLMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 349);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRegisterNo);
            this.Controls.Add(this.gbEncashRemmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00020";
            this.Text = "Encashment Remittance Voucher";
            this.Load += new System.EventHandler(this.TLMVEW00020_Load);
            this.Move += new System.EventHandler(this.TLMVEW00020_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvEncashment)).EndInit();
            this.gbEncashRemmit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblRegisterNo;
        private Ace.Windows.CXClient.Controls.AceGridView gvEncashment;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0002 cboRegisterNo;
        private System.Windows.Forms.GroupBox gbEncashRemmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDRCR;
    }
}