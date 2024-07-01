namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00021
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00021));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvInitialCode = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colInitial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblInitialCode = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtInitialCode = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            ((System.ComponentModel.ISupportInitialize)(this.gvInitialCode)).BeginInit();
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
            this.tsbCRUD.Size = new System.Drawing.Size(620, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvInitialCode
            // 
            this.gvInitialCode.AllowUserToAddRows = false;
            this.gvInitialCode.AllowUserToOrderColumns = true;
            this.gvInitialCode.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvInitialCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvInitialCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInitialCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colInitial,
            this.colDescription,
            this.colTS,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvInitialCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvInitialCode.EnableHeadersVisualStyles = false;
            this.gvInitialCode.IdTSList = null;
            this.gvInitialCode.IsEscapeKey = false;
            this.gvInitialCode.IsHeaderClick = false;
            this.gvInitialCode.Location = new System.Drawing.Point(15, 115);
            this.gvInitialCode.Name = "gvInitialCode";
            this.gvInitialCode.RowHeadersWidth = 25;
            this.gvInitialCode.ShowSerialNo = false;
            this.gvInitialCode.Size = new System.Drawing.Size(580, 410);
            this.gvInitialCode.TabIndex = 4;
            this.gvInitialCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVInitial_CellContentClick);
            this.gvInitialCode.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVInitialEntry_CellFormatting);
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
            // colInitial
            // 
            this.colInitial.DataPropertyName = "Initial";
            this.colInitial.HeaderText = "Initial";
            this.colInitial.Name = "colInitial";
            this.colInitial.ReadOnly = true;
            this.colInitial.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // colTS
            // 
            this.colTS.DataPropertyName = "TS";
            this.colTS.HeaderText = "TS";
            this.colTS.Name = "colTS";
            this.colTS.Visible = false;
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
            this.txtRecordCount.Location = new System.Drawing.Point(109, 533);
            this.txtRecordCount.MaxLength = 5;
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
            this.lblRecordCount.Location = new System.Drawing.Point(12, 536);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(79, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count :";
            // 
            // lblInitialCode
            // 
            this.lblInitialCode.AutoSize = true;
            this.lblInitialCode.Location = new System.Drawing.Point(12, 42);
            this.lblInitialCode.Name = "lblInitialCode";
            this.lblInitialCode.Size = new System.Drawing.Size(38, 13);
            this.lblInitialCode.TabIndex = 0;
            this.lblInitialCode.Text = "Code :";
            // 
            // txtInitialCode
            // 
            this.txtInitialCode.IsSendTabOnEnter = true;
            this.txtInitialCode.Location = new System.Drawing.Point(109, 39);
            this.txtInitialCode.MaxLength = 7;
            this.txtInitialCode.Name = "txtInitialCode";
            this.txtInitialCode.Size = new System.Drawing.Size(141, 20);
            this.txtInitialCode.TabIndex = 1;
            this.txtInitialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInitialCode_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 67);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(109, 64);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // SAMVEW00021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 570);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtInitialCode);
            this.Controls.Add(this.lblInitialCode);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gvInitialCode);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00021";
            this.Text = "Initial Code Entry";
            this.Load += new System.EventHandler(this.SAMVEW00021_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvInitialCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvInitialCode;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblInitialCode;
        private Windows.CXClient.Controls.CXC0001 txtInitialCode;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}