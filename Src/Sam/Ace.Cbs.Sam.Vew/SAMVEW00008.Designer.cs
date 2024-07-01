namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00008
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00008));
            this.lblDepositCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDepositCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvDepositCode = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepositCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsdCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDepositCode
            // 
            this.lblDepositCode.AutoSize = true;
            this.lblDepositCode.Location = new System.Drawing.Point(15, 46);
            this.lblDepositCode.Name = "lblDepositCode";
            this.lblDepositCode.Size = new System.Drawing.Size(35, 13);
            this.lblDepositCode.TabIndex = 0;
            this.lblDepositCode.Text = "Code:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 72);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // txtDepositCode
            // 
            this.txtDepositCode.IsSendTabOnEnter = true;
            this.txtDepositCode.Location = new System.Drawing.Point(116, 42);
            this.txtDepositCode.MaxLength = 5;
            this.txtDepositCode.Name = "txtDepositCode";
            this.txtDepositCode.Size = new System.Drawing.Size(141, 20);
            this.txtDepositCode.TabIndex = 1;
            this.txtDepositCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepositCode_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(116, 68);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // gvDepositCode
            // 
            this.gvDepositCode.AllowUserToAddRows = false;
            this.gvDepositCode.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDepositCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDepositCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDepositCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colDepositCode,
            this.colDescription,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDepositCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDepositCode.EnableHeadersVisualStyles = false;
            this.gvDepositCode.IdTSList = null;
            this.gvDepositCode.IsEscapeKey = false;
            this.gvDepositCode.IsHeaderClick = false;
            this.gvDepositCode.Location = new System.Drawing.Point(18, 119);
            this.gvDepositCode.Name = "gvDepositCode";
            this.gvDepositCode.RowHeadersWidth = 25;
            this.gvDepositCode.ShowSerialNo = false;
            this.gvDepositCode.Size = new System.Drawing.Size(580, 410);
            this.gvDepositCode.TabIndex = 4;
            this.gvDepositCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVDEPOSITCODE_CellContentClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.FalseValue = "False";
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
            this.colTS.HeaderText = "";
            this.colTS.Name = "colTS";
            this.colTS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTS.Visible = false;
            // 
            // colDepositCode
            // 
            this.colDepositCode.DataPropertyName = "DepositCode";
            this.colDepositCode.HeaderText = "Deposit Code";
            this.colDepositCode.Name = "colDepositCode";
            this.colDepositCode.ReadOnly = true;
            this.colDepositCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
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
            this.txtRecordCount.Location = new System.Drawing.Point(116, 535);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 5;
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
            this.lblRecordCount.Location = new System.Drawing.Point(15, 538);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // tsdCRUD
            // 
            this.tsdCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsdCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsdCRUD.CausesValidation = false;
            this.tsdCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsdCRUD.Name = "tsdCRUD";
            this.tsdCRUD.PrintButtonCauseValidation = true;
            this.tsdCRUD.Size = new System.Drawing.Size(625, 31);
            this.tsdCRUD.TabIndex = 3;
            this.tsdCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsdCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsdCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsdCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // SAMVEW00008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 563);
            this.Controls.Add(this.tsdCRUD);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.gvDepositCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDepositCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDepositCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00008";
            this.Text = "Deposit Code Entry";
            this.Load += new System.EventHandler(this.SAMVEW00008_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDepositCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblDepositCode;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0001 txtDepositCode;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.AceGridView gvDepositCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXCLIC001 tsdCRUD;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepositCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}