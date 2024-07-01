namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00028
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00028));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblIBLEncash = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvEncashRegister = new Ace.Windows.CXClient.Controls.AceGridView();
            this.aceDataGridViewCheckBoxColumn1 = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtEncashRegisterNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblEncashRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            ((System.ComponentModel.ISupportInitialize)(this.gvEncashRegister)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(510, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // lblIBLEncash
            // 
            this.lblIBLEncash.AutoSize = true;
            this.lblIBLEncash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIBLEncash.Location = new System.Drawing.Point(156, 50);
            this.lblIBLEncash.Name = "lblIBLEncash";
            this.lblIBLEncash.Size = new System.Drawing.Size(165, 16);
            this.lblIBLEncash.TabIndex = 17;
            this.lblIBLEncash.Text = "IBL Encash Adjustment";
            // 
            // gvEncashRegister
            // 
            this.gvEncashRegister.AllowDrop = true;
            this.gvEncashRegister.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvEncashRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvEncashRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEncashRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aceDataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.colFromName,
            this.dataGridViewImageColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvEncashRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvEncashRegister.EnableHeadersVisualStyles = false;
            this.gvEncashRegister.IdTSList = null;
            this.gvEncashRegister.IsEscapeKey = false;
            this.gvEncashRegister.IsHeaderClick = false;
            this.gvEncashRegister.Location = new System.Drawing.Point(12, 133);
            this.gvEncashRegister.Name = "gvEncashRegister";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvEncashRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvEncashRegister.RowHeadersWidth = 25;
            this.gvEncashRegister.ShowSerialNo = true;
            this.gvEncashRegister.Size = new System.Drawing.Size(484, 208);
            this.gvEncashRegister.TabIndex = 1;
            // 
            // aceDataGridViewCheckBoxColumn1
            // 
            this.aceDataGridViewCheckBoxColumn1.CheckBoxHeader = false;
            this.aceDataGridViewCheckBoxColumn1.DataPropertyName = "IsCheck";
            this.aceDataGridViewCheckBoxColumn1.FalseValue = "false";
            this.aceDataGridViewCheckBoxColumn1.HeaderText = "";
            this.aceDataGridViewCheckBoxColumn1.Id = 0;
            this.aceDataGridViewCheckBoxColumn1.Name = "aceDataGridViewCheckBoxColumn1";
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ebank";
            this.dataGridViewTextBoxColumn2.HeaderText = "Encash Bank";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ToAccountNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "AccountNo / PO No.";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 115;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 30;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // colFromName
            // 
            this.colFromName.DataPropertyName = "Name";
            this.colFromName.HeaderText = "From Name";
            this.colFromName.Name = "colFromName";
            this.colFromName.Width = 80;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // txtEncashRegisterNo
            // 
            this.txtEncashRegisterNo.IsSendTabOnEnter = true;
            this.txtEncashRegisterNo.Location = new System.Drawing.Point(135, 95);
            this.txtEncashRegisterNo.Name = "txtEncashRegisterNo";
            this.txtEncashRegisterNo.Size = new System.Drawing.Size(90, 20);
            this.txtEncashRegisterNo.TabIndex = 0;
            this.txtEncashRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEncashRegisterNo_KeyPress);
            // 
            // lblEncashRegisterNo
            // 
            this.lblEncashRegisterNo.AutoSize = true;
            this.lblEncashRegisterNo.Location = new System.Drawing.Point(12, 98);
            this.lblEncashRegisterNo.Name = "lblEncashRegisterNo";
            this.lblEncashRegisterNo.Size = new System.Drawing.Size(114, 13);
            this.lblEncashRegisterNo.TabIndex = 18;
            this.lblEncashRegisterNo.Text = "Encash RegisterNo.   :";
            // 
            // MNMVEW00028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 356);
            this.Controls.Add(this.lblIBLEncash);
            this.Controls.Add(this.gvEncashRegister);
            this.Controls.Add(this.txtEncashRegisterNo);
            this.Controls.Add(this.lblEncashRegisterNo);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00028";
            this.Text = "IBL Encash Adjustment";
            this.Load += new System.EventHandler(this.MNMVEW00028_Load);
            this.Move += new System.EventHandler(this.MNMVEW00028_Move);
            ((System.ComponentModel.ISupportInitialize)(this.gvEncashRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblIBLEncash;
        private Windows.CXClient.Controls.AceGridView gvEncashRegister;
        private Windows.CXClient.Controls.CXC0001 txtEncashRegisterNo;
        private Windows.CXClient.Controls.CXC0003 lblEncashRegisterNo;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn aceDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromName;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}