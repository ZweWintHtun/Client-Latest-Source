namespace Ace.Cbs.Sam.Vew
{
    partial class Product1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOccupationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtOccupationCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblOccupationCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvOccupationCode = new Ace.Windows.CXClient.Controls.AceGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvOccupationCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(702, 31);
            this.tsbCRUD.TabIndex = 11;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
            // 
            // colOccupationCode
            // 
            this.colOccupationCode.DataPropertyName = "Occupation_Code";
            this.colOccupationCode.HeaderText = "Code";
            this.colOccupationCode.Name = "colOccupationCode";
            this.colOccupationCode.ReadOnly = true;
            this.colOccupationCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
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
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(103, 74);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 10;
            // 
            // txtOccupationCode
            // 
            this.txtOccupationCode.IsSendTabOnEnter = true;
            this.txtOccupationCode.Location = new System.Drawing.Point(103, 48);
            this.txtOccupationCode.MaxLength = 3;
            this.txtOccupationCode.Name = "txtOccupationCode";
            this.txtOccupationCode.Size = new System.Drawing.Size(141, 20);
            this.txtOccupationCode.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(22, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description :";
            // 
            // lblOccupationCode
            // 
            this.lblOccupationCode.AutoSize = true;
            this.lblOccupationCode.Location = new System.Drawing.Point(22, 51);
            this.lblOccupationCode.Name = "lblOccupationCode";
            this.lblOccupationCode.Size = new System.Drawing.Size(38, 13);
            this.lblOccupationCode.TabIndex = 6;
            this.lblOccupationCode.Text = "Code :";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(103, 543);
            this.txtRecordCount.MaxLength = 5;
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 13;
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
            this.lblRecordCount.Location = new System.Drawing.Point(22, 546);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 7;
            this.lblRecordCount.Text = "Record Count :";
            // 
            // gvOccupationCode
            // 
            this.gvOccupationCode.AllowUserToAddRows = false;
            this.gvOccupationCode.CausesValidation = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvOccupationCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvOccupationCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOccupationCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colOccupationCode,
            this.colDescription,
            this.colEdit});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvOccupationCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvOccupationCode.EnableHeadersVisualStyles = false;
            this.gvOccupationCode.IdTSList = null;
            this.gvOccupationCode.IsEscapeKey = false;
            this.gvOccupationCode.IsHeaderClick = false;
            this.gvOccupationCode.Location = new System.Drawing.Point(25, 122);
            this.gvOccupationCode.Name = "gvOccupationCode";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvOccupationCode.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvOccupationCode.RowHeadersWidth = 25;
            this.gvOccupationCode.ShowSerialNo = false;
            this.gvOccupationCode.Size = new System.Drawing.Size(471, 301);
            this.gvOccupationCode.TabIndex = 12;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Sam.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // Product1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 434);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtOccupationCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblOccupationCode);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvOccupationCode);
            this.Name = "Product1";
            this.Text = "Product1";
            this.Load += new System.EventHandler(this.Product1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvOccupationCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOccupationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0001 txtOccupationCode;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0003 lblOccupationCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.AceGridView gvOccupationCode;
    }
}