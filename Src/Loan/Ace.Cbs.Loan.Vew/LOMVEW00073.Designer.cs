﻿namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00073
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00073));
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.gvUMList = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvUMList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.DecimalPlaces = 0;
            this.txtRecordCount.IsSendTabOnEnter = true;
            this.txtRecordCount.Location = new System.Drawing.Point(94, 534);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 124;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 537);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 123;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(129, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(202, 53);
            this.txtDescription.TabIndex = 122;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 73);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 13);
            this.lblDescription.TabIndex = 121;
            this.lblDescription.Text = "UM Description";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(129, 42);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(127, 20);
            this.txtCode.TabIndex = 120;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 45);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(52, 13);
            this.lblCode.TabIndex = 119;
            this.lblCode.Text = "UM Code";
            // 
            // gvUMList
            // 
            this.gvUMList.AllowUserToAddRows = false;
            this.gvUMList.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvUMList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvUMList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUMList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colUMCode,
            this.colDescription,
            this.colEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvUMList.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvUMList.EnableHeadersVisualStyles = false;
            this.gvUMList.IdTSList = null;
            this.gvUMList.IsEscapeKey = false;
            this.gvUMList.IsHeaderClick = false;
            this.gvUMList.Location = new System.Drawing.Point(13, 129);
            this.gvUMList.Name = "gvUMList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvUMList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvUMList.RowHeadersWidth = 25;
            this.gvUMList.ShowSerialNo = false;
            this.gvUMList.Size = new System.Drawing.Size(505, 396);
            this.gvUMList.TabIndex = 118;
            this.gvUMList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUMList_CellContentClick);
            this.gvUMList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvUMList_CellFormatting);
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
            this.colTS.Width = 30;
            // 
            // colUMCode
            // 
            this.colUMCode.DataPropertyName = "UMCode";
            dataGridViewCellStyle2.NullValue = null;
            this.colUMCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUMCode.HeaderText = "UM Code";
            this.colUMCode.Name = "colUMCode";
            this.colUMCode.ReadOnly = true;
            this.colUMCode.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "UMDesp";
            this.colDescription.HeaderText = "UM Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 250;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 30;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(534, 36);
            this.tsbCRUD.TabIndex = 117;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Ace.Cbs.Loan.Vew.Properties.Resources.Edit_Main;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // LOMVEW00073
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 566);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.gvUMList);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00073";
            this.Text = "UM Setup";
            this.Load += new System.EventHandler(this.LOMVEW00073_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvUMList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private Windows.CXClient.Controls.AceGridView gvUMList;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}