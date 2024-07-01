namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00007));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvFormatStyle = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colchk = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colFormatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.grpInputFormat = new System.Windows.Forms.GroupBox();
            this.mtxtFormatType = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblFormatType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butFormatEntry = new Ace.Windows.CXClient.Controls.CXC0007();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).BeginInit();
            this.grpInputFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(546, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.NewButtonClick += new System.EventHandler(this.tsbCRUD_NewButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gvFormatStyle
            // 
            this.gvFormatStyle.AllowDrop = true;
            this.gvFormatStyle.AllowUserToAddRows = false;
            this.gvFormatStyle.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvFormatStyle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFormatStyle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFormatStyle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colchk,
            this.colFormatCode,
            this.colName,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvFormatStyle.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvFormatStyle.EnableHeadersVisualStyles = false;
            this.gvFormatStyle.IdTSList = null;
            this.gvFormatStyle.IsEscapeKey = false;
            this.gvFormatStyle.IsHeaderClick = false;
            this.gvFormatStyle.Location = new System.Drawing.Point(12, 49);
            this.gvFormatStyle.Name = "gvFormatStyle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvFormatStyle.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvFormatStyle.RowHeadersWidth = 25;
            this.gvFormatStyle.ShowSerialNo = false;
            this.gvFormatStyle.Size = new System.Drawing.Size(507, 175);
            this.gvFormatStyle.TabIndex = 0;
            this.gvFormatStyle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFormatStyle_CellContentClick);
            // 
            // colchk
            // 
            this.colchk.CheckBoxHeader = false;
            this.colchk.DataPropertyName = "IsCheck";
            this.colchk.FalseValue = "false";
            this.colchk.HeaderText = "";
            this.colchk.Id = 0;
            this.colchk.Name = "colchk";
            this.colchk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colchk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colchk.TrueValue = "true";
            this.colchk.TS = null;
            this.colchk.Width = 30;
            // 
            // colFormatCode
            // 
            this.colFormatCode.DataPropertyName = "FormatType";
            this.colFormatCode.HeaderText = "Format Code";
            this.colFormatCode.Name = "colFormatCode";
            this.colFormatCode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "FormatName";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::Ace.Cbs.Gl.Vew.Properties.Resources.Edit_Main;
            this.colEdit.Name = "colEdit";
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 30;
            // 
            // grpInputFormat
            // 
            this.grpInputFormat.Controls.Add(this.mtxtFormatType);
            this.grpInputFormat.Controls.Add(this.txtName);
            this.grpInputFormat.Controls.Add(this.lblName);
            this.grpInputFormat.Controls.Add(this.lblFormatType);
            this.grpInputFormat.Location = new System.Drawing.Point(12, 263);
            this.grpInputFormat.Name = "grpInputFormat";
            this.grpInputFormat.Size = new System.Drawing.Size(482, 83);
            this.grpInputFormat.TabIndex = 0;
            this.grpInputFormat.TabStop = false;
            this.grpInputFormat.Visible = false;
            // 
            // mtxtFormatType
            // 
            this.mtxtFormatType.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtFormatType.HidePromptOnLeave = true;
            this.mtxtFormatType.IsSendTabOnEnter = true;
            this.mtxtFormatType.Location = new System.Drawing.Point(99, 19);
            this.mtxtFormatType.Mask = "&&&&&&";
            this.mtxtFormatType.Name = "mtxtFormatType";
            this.mtxtFormatType.Size = new System.Drawing.Size(115, 20);
            this.mtxtFormatType.TabIndex = 3;
            this.mtxtFormatType.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtName
            // 
            this.txtName.IsSendTabOnEnter = true;
            this.txtName.Location = new System.Drawing.Point(99, 45);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name :";
            // 
            // lblFormatType
            // 
            this.lblFormatType.AutoSize = true;
            this.lblFormatType.Location = new System.Drawing.Point(6, 22);
            this.lblFormatType.Name = "lblFormatType";
            this.lblFormatType.Size = new System.Drawing.Size(72, 13);
            this.lblFormatType.TabIndex = 4;
            this.lblFormatType.Text = "Format Type :";
            // 
            // butFormatEntry
            // 
            this.butFormatEntry.Location = new System.Drawing.Point(430, 232);
            this.butFormatEntry.Name = "butFormatEntry";
            this.butFormatEntry.Size = new System.Drawing.Size(89, 26);
            this.butFormatEntry.TabIndex = 3;
            this.butFormatEntry.Text = "&Format Entry";
            this.butFormatEntry.UseVisualStyleBackColor = true;
            this.butFormatEntry.Click += new System.EventHandler(this.butFormatEntry_Click);
            // 
            // GLMVEW00007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(541, 366);
            this.Controls.Add(this.butFormatEntry);
            this.Controls.Add(this.grpInputFormat);
            this.Controls.Add(this.gvFormatStyle);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00007";
            this.Load += new System.EventHandler(this.GLVEW00007_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFormatStyle)).EndInit();
            this.grpInputFormat.ResumeLayout(false);
            this.grpInputFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvFormatStyle;
        private System.Windows.Forms.GroupBox grpInputFormat;
        private Windows.CXClient.Controls.CXC0001 txtName;
        private Windows.CXClient.Controls.CXC0003 lblName;
        private Windows.CXClient.Controls.CXC0003 lblFormatType;
        private Windows.CXClient.Controls.CXC0007 butFormatEntry;
        private Windows.CXClient.Controls.CXC0006 mtxtFormatType;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colchk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}