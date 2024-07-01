namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00027
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00027));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblIBLDrawing = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDrawingRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDrawingRegisterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvDrawingAdjustment = new Ace.Windows.CXClient.Controls.AceGridView();
            this.aceDataGridViewCheckBoxColumn1 = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcUpdatedUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblGroupNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblGroupNoLabel = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(508, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblIBLDrawing
            // 
            this.lblIBLDrawing.AutoSize = true;
            this.lblIBLDrawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIBLDrawing.Location = new System.Drawing.Point(156, 50);
            this.lblIBLDrawing.Name = "lblIBLDrawing";
            this.lblIBLDrawing.Size = new System.Drawing.Size(170, 16);
            this.lblIBLDrawing.TabIndex = 9;
            this.lblIBLDrawing.Text = "IBL Drawing Adjustment";
            // 
            // lblDrawingRegisterNo
            // 
            this.lblDrawingRegisterNo.AutoSize = true;
            this.lblDrawingRegisterNo.Location = new System.Drawing.Point(12, 98);
            this.lblDrawingRegisterNo.Name = "lblDrawingRegisterNo";
            this.lblDrawingRegisterNo.Size = new System.Drawing.Size(117, 13);
            this.lblDrawingRegisterNo.TabIndex = 10;
            this.lblDrawingRegisterNo.Text = "Drawing RegisterNo.   :";
            // 
            // txtDrawingRegisterNo
            // 
            this.txtDrawingRegisterNo.IsSendTabOnEnter = true;
            this.txtDrawingRegisterNo.Location = new System.Drawing.Point(135, 95);
            this.txtDrawingRegisterNo.Name = "txtDrawingRegisterNo";
            this.txtDrawingRegisterNo.Size = new System.Drawing.Size(90, 20);
            this.txtDrawingRegisterNo.TabIndex = 1;
            this.txtDrawingRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrawingRegisterNo_KeyPress);
            // 
            // gvDrawingAdjustment
            // 
            this.gvDrawingAdjustment.AllowDrop = true;
            this.gvDrawingAdjustment.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDrawingAdjustment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDrawingAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDrawingAdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aceDataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.colFromName,
            this.dgvcCurrencyCode,
            this.dgvcUpdatedUserId,
            this.dataGridViewImageColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDrawingAdjustment.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDrawingAdjustment.EnableHeadersVisualStyles = false;
            this.gvDrawingAdjustment.IdTSList = null;
            this.gvDrawingAdjustment.IsEscapeKey = false;
            this.gvDrawingAdjustment.IsHeaderClick = false;
            this.gvDrawingAdjustment.Location = new System.Drawing.Point(12, 133);
            this.gvDrawingAdjustment.Name = "gvDrawingAdjustment";
            this.gvDrawingAdjustment.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDrawingAdjustment.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvDrawingAdjustment.RowHeadersWidth = 25;
            this.gvDrawingAdjustment.ShowSerialNo = false;
            this.gvDrawingAdjustment.Size = new System.Drawing.Size(484, 208);
            this.gvDrawingAdjustment.TabIndex = 2;
            this.gvDrawingAdjustment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvDrawingAdjustment_DataError);
            // 
            // aceDataGridViewCheckBoxColumn1
            // 
            this.aceDataGridViewCheckBoxColumn1.CheckBoxHeader = false;
            this.aceDataGridViewCheckBoxColumn1.DataPropertyName = "IsCheck";
            this.aceDataGridViewCheckBoxColumn1.FalseValue = "false";
            this.aceDataGridViewCheckBoxColumn1.Frozen = true;
            this.aceDataGridViewCheckBoxColumn1.HeaderText = "";
            this.aceDataGridViewCheckBoxColumn1.Id = 0;
            this.aceDataGridViewCheckBoxColumn1.Name = "aceDataGridViewCheckBoxColumn1";
            this.aceDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.aceDataGridViewCheckBoxColumn1.TrueValue = "true";
            this.aceDataGridViewCheckBoxColumn1.TS = null;
            this.aceDataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TS";
            this.dataGridViewTextBoxColumn1.HeaderText = "TS";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Dbank";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Drawing Bank";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "AccountNo";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 30;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // colFromName
            // 
            this.colFromName.DataPropertyName = "Name";
            this.colFromName.Frozen = true;
            this.colFromName.HeaderText = "From Name";
            this.colFromName.Name = "colFromName";
            this.colFromName.ReadOnly = true;
            this.colFromName.Width = 80;
            // 
            // dgvcCurrencyCode
            // 
            this.dgvcCurrencyCode.DataPropertyName = "Currency";
            this.dgvcCurrencyCode.Frozen = true;
            this.dgvcCurrencyCode.HeaderText = "CurrencyCode";
            this.dgvcCurrencyCode.Name = "dgvcCurrencyCode";
            this.dgvcCurrencyCode.ReadOnly = true;
            this.dgvcCurrencyCode.Visible = false;
            // 
            // dgvcUpdatedUserId
            // 
            this.dgvcUpdatedUserId.DataPropertyName = "UpdatedUserId";
            this.dgvcUpdatedUserId.HeaderText = "UpdatedUserId";
            this.dgvcUpdatedUserId.Name = "dgvcUpdatedUserId";
            this.dgvcUpdatedUserId.ReadOnly = true;
            this.dgvcUpdatedUserId.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // lblGroupNo
            // 
            this.lblGroupNo.AutoSize = true;
            this.lblGroupNo.Location = new System.Drawing.Point(354, 98);
            this.lblGroupNo.Name = "lblGroupNo";
            this.lblGroupNo.Size = new System.Drawing.Size(0, 13);
            this.lblGroupNo.TabIndex = 10;
            // 
            // lblGroupNoLabel
            // 
            this.lblGroupNoLabel.AutoSize = true;
            this.lblGroupNoLabel.Location = new System.Drawing.Point(280, 98);
            this.lblGroupNoLabel.Name = "lblGroupNoLabel";
            this.lblGroupNoLabel.Size = new System.Drawing.Size(68, 13);
            this.lblGroupNoLabel.TabIndex = 11;
            this.lblGroupNoLabel.Text = "Group No   : ";
            // 
            // MNMVEW00027
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 356);
            this.Controls.Add(this.lblGroupNoLabel);
            this.Controls.Add(this.gvDrawingAdjustment);
            this.Controls.Add(this.txtDrawingRegisterNo);
            this.Controls.Add(this.lblGroupNo);
            this.Controls.Add(this.lblDrawingRegisterNo);
            this.Controls.Add(this.lblIBLDrawing);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00027";
            this.Text = "IBL Drawing Adjustment";
            this.Load += new System.EventHandler(this.MNMVEW00027_Load);
            this.Move += new System.EventHandler(this.MNMVEW00027_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblIBLDrawing;
        private Windows.CXClient.Controls.CXC0003 lblDrawingRegisterNo;
        private Windows.CXClient.Controls.CXC0001 txtDrawingRegisterNo;
        private Windows.CXClient.Controls.AceGridView gvDrawingAdjustment;
        private Windows.CXClient.Controls.CXC0003 lblGroupNo;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn aceDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCurrencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcUpdatedUserId;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Windows.CXClient.Controls.CXC0003 lblGroupNoLabel;
    }
}