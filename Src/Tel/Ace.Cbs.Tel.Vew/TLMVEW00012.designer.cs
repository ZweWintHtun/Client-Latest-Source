namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00012
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00012));
            this.gbDenomination = new System.Windows.Forms.GroupBox();
            this.gvDenomination = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtShortage = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtSurPlus = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblShortage = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtTotalAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblSurplus = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRefundAmount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRefundAmount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTotal = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDenomination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDenomination
            // 
            this.gbDenomination.Controls.Add(this.gvDenomination);
            this.gbDenomination.Controls.Add(this.txtShortage);
            this.gbDenomination.Controls.Add(this.txtSurPlus);
            this.gbDenomination.Controls.Add(this.lblShortage);
            this.gbDenomination.Controls.Add(this.txtTotalAmount);
            this.gbDenomination.Controls.Add(this.lblSurplus);
            this.gbDenomination.Controls.Add(this.txtRefundAmount);
            this.gbDenomination.Controls.Add(this.lblRefundAmount);
            this.gbDenomination.Controls.Add(this.lblTotal);
            this.gbDenomination.Location = new System.Drawing.Point(12, 37);
            this.gbDenomination.Name = "gbDenomination";
            this.gbDenomination.Size = new System.Drawing.Size(563, 497);
            this.gbDenomination.TabIndex = 0;
            this.gbDenomination.TabStop = false;
            // 
            // gvDenomination
            // 
            this.gvDenomination.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDenomination.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDenomination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDenomination.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.Count,
            this.D1,
            this.D2,
            this.Symbol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDenomination.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvDenomination.EnableHeadersVisualStyles = false;
            this.gvDenomination.IdTSList = null;
            this.gvDenomination.IsEscapeKey = false;
            this.gvDenomination.IsHeaderClick = false;
            this.gvDenomination.Location = new System.Drawing.Point(6, 12);
            this.gvDenomination.Name = "gvDenomination";
            this.gvDenomination.RowHeadersWidth = 25;
            this.gvDenomination.ShowSerialNo = false;
            this.gvDenomination.Size = new System.Drawing.Size(316, 479);
            this.gvDenomination.TabIndex = 1;
            this.gvDenomination.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellEnter);
            this.gvDenomination.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenomination_CellValidated);
            this.gvDenomination.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvDenomination_EditingControlShowing);
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // Count
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            this.Count.DefaultCellStyle = dataGridViewCellStyle3;
            this.Count.FillWeight = 150F;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            // 
            // D1
            // 
            this.D1.DataPropertyName = "D1";
            this.D1.HeaderText = "D1";
            this.D1.Name = "D1";
            this.D1.Visible = false;
            // 
            // D2
            // 
            this.D2.DataPropertyName = "D2";
            this.D2.HeaderText = "D2";
            this.D2.Name = "D2";
            this.D2.Visible = false;
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.Visible = false;
            // 
            // txtShortage
            // 
            this.txtShortage.DecimalPlaces = 2;
            this.txtShortage.IsSendTabOnEnter = true;
            this.txtShortage.IsThousandSeperator = true;
            this.txtShortage.IsUseSpecialCharacter = true;
            this.txtShortage.Location = new System.Drawing.Point(457, 100);
            this.txtShortage.Name = "txtShortage";
            this.txtShortage.Size = new System.Drawing.Size(100, 20);
            this.txtShortage.TabIndex = 6;
            this.txtShortage.Text = "0.00";
            this.txtShortage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShortage.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtSurPlus
            // 
            this.txtSurPlus.DecimalPlaces = 2;
            this.txtSurPlus.IsSendTabOnEnter = true;
            this.txtSurPlus.IsThousandSeperator = true;
            this.txtSurPlus.Location = new System.Drawing.Point(457, 73);
            this.txtSurPlus.Name = "txtSurPlus";
            this.txtSurPlus.Size = new System.Drawing.Size(100, 20);
            this.txtSurPlus.TabIndex = 5;
            this.txtSurPlus.Text = "0.00";
            this.txtSurPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSurPlus.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblShortage
            // 
            this.lblShortage.AutoSize = true;
            this.lblShortage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShortage.Location = new System.Drawing.Point(340, 103);
            this.lblShortage.Name = "lblShortage";
            this.lblShortage.Size = new System.Drawing.Size(56, 13);
            this.lblShortage.TabIndex = 0;
            this.lblShortage.Text = "Shortage :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.DecimalPlaces = 2;
            this.txtTotalAmount.IsSendTabOnEnter = true;
            this.txtTotalAmount.IsThousandSeperator = true;
            this.txtTotalAmount.Location = new System.Drawing.Point(457, 44);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblSurplus
            // 
            this.lblSurplus.AutoSize = true;
            this.lblSurplus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSurplus.Location = new System.Drawing.Point(340, 76);
            this.lblSurplus.Name = "lblSurplus";
            this.lblSurplus.Size = new System.Drawing.Size(48, 13);
            this.lblSurplus.TabIndex = 0;
            this.lblSurplus.Text = "Surplus :";
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.DecimalPlaces = 2;
            this.txtRefundAmount.IsSendTabOnEnter = true;
            this.txtRefundAmount.IsThousandSeperator = true;
            this.txtRefundAmount.Location = new System.Drawing.Point(457, 17);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.Size = new System.Drawing.Size(100, 20);
            this.txtRefundAmount.TabIndex = 3;
            this.txtRefundAmount.Text = "0.00";
            this.txtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRefundAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // lblRefundAmount
            // 
            this.lblRefundAmount.AutoSize = true;
            this.lblRefundAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRefundAmount.Location = new System.Drawing.Point(340, 20);
            this.lblRefundAmount.Name = "lblRefundAmount";
            this.lblRefundAmount.Size = new System.Drawing.Size(87, 13);
            this.lblRefundAmount.TabIndex = 0;
            this.lblRefundAmount.Text = "Refund Amount :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(340, 47);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(591, 31);
            this.tsbCRUD.TabIndex = 58;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TLMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 546);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbDenomination);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00012";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denomination Refund Entry";
            this.Load += new System.EventHandler(this.TLMVEW00012_Load);
            this.gbDenomination.ResumeLayout(false);
            this.gbDenomination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenomination)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0003 lblShortage;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSurplus;
        private Ace.Windows.CXClient.Controls.CXC0003 lblTotal;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRefundAmount;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbDenomination;
        private Ace.Windows.CXClient.Controls.CXC0004 txtRefundAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtTotalAmount;
        private Ace.Windows.CXClient.Controls.CXC0004 txtSurPlus;
        private Ace.Windows.CXClient.Controls.CXC0004 txtShortage;
        private Windows.CXClient.Controls.AceGridView gvDenomination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn D1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;

    }
}