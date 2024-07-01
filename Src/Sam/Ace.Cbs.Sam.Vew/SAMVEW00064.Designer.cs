namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00064
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00064));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvNRCCode = new Ace.Windows.CXClient.Controls.AceGridView();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboStateCode = new Ace.Windows.CXClient.Controls.CXC0002();
            this.txtTownshipDesp = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtTownshipCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblTownshipDesp = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblTownshipCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStateCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblStateDesp = new Ace.Windows.CXClient.Controls.CXC0003();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipDesp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvNRCCode)).BeginInit();
            this.SuspendLayout();
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
            this.tsbCRUD.Size = new System.Drawing.Size(614, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvNRCCode
            // 
            this.gvNRCCode.AllowUserToAddRows = false;
            this.gvNRCCode.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvNRCCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvNRCCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNRCCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colStateCode,
            this.colTownshipCode,
            this.colTownshipDesp,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvNRCCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvNRCCode.EnableHeadersVisualStyles = false;
            this.gvNRCCode.IdTSList = null;
            this.gvNRCCode.IsEscapeKey = false;
            this.gvNRCCode.IsHeaderClick = false;
            this.gvNRCCode.Location = new System.Drawing.Point(17, 142);
            this.gvNRCCode.Name = "gvNRCCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvNRCCode.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvNRCCode.RowHeadersWidth = 25;
            this.gvNRCCode.ShowSerialNo = false;
            this.gvNRCCode.Size = new System.Drawing.Size(582, 410);
            this.gvNRCCode.TabIndex = 5;
            this.gvNRCCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvNRCCode_CellContentClick);
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(99, 558);
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
            this.lblRecordCount.Location = new System.Drawing.Point(14, 561);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count :";
            // 
            // cboStateCode
            // 
            this.cboStateCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStateCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStateCode.DropDownHeight = 200;
            this.cboStateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateCode.FormattingEnabled = true;
            this.cboStateCode.IntegralHeight = false;
            this.cboStateCode.IsSendTabOnEnter = true;
            this.cboStateCode.Location = new System.Drawing.Point(133, 41);
            this.cboStateCode.Name = "cboStateCode";
            this.cboStateCode.Size = new System.Drawing.Size(141, 21);
            this.cboStateCode.TabIndex = 0;
            this.cboStateCode.SelectedIndexChanged += new System.EventHandler(this.cboStateCode_SelectedIndexChanged);
            this.cboStateCode.Leave += new System.EventHandler(this.cboStateCode_Leave);
            // 
            // txtTownshipDesp
            // 
            this.txtTownshipDesp.IsSendTabOnEnter = true;
            this.txtTownshipDesp.Location = new System.Drawing.Point(133, 94);
            this.txtTownshipDesp.MaxLength = 40;
            this.txtTownshipDesp.Multiline = true;
            this.txtTownshipDesp.Name = "txtTownshipDesp";
            this.txtTownshipDesp.Size = new System.Drawing.Size(175, 42);
            this.txtTownshipDesp.TabIndex = 2;
            this.txtTownshipDesp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTownshipDesp_KeyPress);
            this.txtTownshipDesp.Leave += new System.EventHandler(this.txtTownshipDesp_Leave);
            // 
            // txtTownshipCode
            // 
            this.txtTownshipCode.IsSendTabOnEnter = true;
            this.txtTownshipCode.Location = new System.Drawing.Point(133, 68);
            this.txtTownshipCode.MaxLength = 10;
            this.txtTownshipCode.Name = "txtTownshipCode";
            this.txtTownshipCode.Size = new System.Drawing.Size(141, 20);
            this.txtTownshipCode.TabIndex = 1;
            this.txtTownshipCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTownshipCode_KeyPress);
            this.txtTownshipCode.Leave += new System.EventHandler(this.txtTownshipCode_Leave);
            // 
            // lblTownshipDesp
            // 
            this.lblTownshipDesp.AutoSize = true;
            this.lblTownshipDesp.Location = new System.Drawing.Point(14, 97);
            this.lblTownshipDesp.Name = "lblTownshipDesp";
            this.lblTownshipDesp.Size = new System.Drawing.Size(115, 13);
            this.lblTownshipDesp.TabIndex = 0;
            this.lblTownshipDesp.Text = "Township Description :";
            // 
            // lblTownshipCode
            // 
            this.lblTownshipCode.AutoSize = true;
            this.lblTownshipCode.Location = new System.Drawing.Point(14, 71);
            this.lblTownshipCode.Name = "lblTownshipCode";
            this.lblTownshipCode.Size = new System.Drawing.Size(87, 13);
            this.lblTownshipCode.TabIndex = 0;
            this.lblTownshipCode.Text = "Township Code :";
            // 
            // lblStateCode
            // 
            this.lblStateCode.AutoSize = true;
            this.lblStateCode.Location = new System.Drawing.Point(14, 45);
            this.lblStateCode.Name = "lblStateCode";
            this.lblStateCode.Size = new System.Drawing.Size(66, 13);
            this.lblStateCode.TabIndex = 0;
            this.lblStateCode.Text = "State Code :";
            // 
            // lblStateDesp
            // 
            this.lblStateDesp.AutoSize = true;
            this.lblStateDesp.Location = new System.Drawing.Point(288, 45);
            this.lblStateDesp.Name = "lblStateDesp";
            this.lblStateDesp.Size = new System.Drawing.Size(57, 13);
            this.lblStateDesp.TabIndex = 0;
            this.lblStateDesp.Text = "StateDesp";
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "false";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // colStateCode
            // 
            this.colStateCode.DataPropertyName = "StateCode";
            this.colStateCode.HeaderText = "State Code";
            this.colStateCode.Name = "colStateCode";
            // 
            // colTownshipCode
            // 
            this.colTownshipCode.DataPropertyName = "TownshipCode";
            this.colTownshipCode.HeaderText = "Township Code";
            this.colTownshipCode.Name = "colTownshipCode";
            this.colTownshipCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTownshipCode.Width = 110;
            // 
            // colTownshipDesp
            // 
            this.colTownshipDesp.DataPropertyName = "TownshipDesp";
            this.colTownshipDesp.HeaderText = "Township Description";
            this.colTownshipDesp.Name = "colTownshipDesp";
            this.colTownshipDesp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTownshipDesp.Width = 250;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // SAMVEW00064
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 593);
            this.Controls.Add(this.lblStateDesp);
            this.Controls.Add(this.lblStateCode);
            this.Controls.Add(this.txtTownshipDesp);
            this.Controls.Add(this.txtTownshipCode);
            this.Controls.Add(this.lblTownshipDesp);
            this.Controls.Add(this.lblTownshipCode);
            this.Controls.Add(this.cboStateCode);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvNRCCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00064";
            this.Text = "NRC Code Entry";
            this.Load += new System.EventHandler(this.SAMVEW00064_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvNRCCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvNRCCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0002 cboStateCode;
        private Windows.CXClient.Controls.CXC0001 txtTownshipDesp;
        private Windows.CXClient.Controls.CXC0001 txtTownshipCode;
        private Windows.CXClient.Controls.CXC0003 lblTownshipDesp;
        private Windows.CXClient.Controls.CXC0003 lblTownshipCode;
        private Windows.CXClient.Controls.CXC0003 lblStateCode;
        private Windows.CXClient.Controls.CXC0003 lblStateDesp;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipDesp;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}