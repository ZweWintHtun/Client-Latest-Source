namespace Ace.Cbs.Sam.Vew
{
    partial class SAMVEW00010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAMVEW00010));
            this.txtKeyName = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtKeyValue = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblKeyName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblKeyValue = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblLocation = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblType = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvAppSettings = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBinaryValue = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRecordCount = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblRecordCount = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPhoto = new Ace.Windows.CXClient.Controls.CXC0003();
            this.picPhoto = new Ace.Windows.CXClient.Controls.CXC0010();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butClearPhoto = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtPhoto = new Ace.Windows.CXClient.Controls.CXC0001();
            this.butBrowse = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtLocation = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtType = new Ace.Windows.CXClient.Controls.CXC0004();
            ((System.ComponentModel.ISupportInitialize)(this.gvAppSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyName
            // 
            this.txtKeyName.IsSendTabOnEnter = true;
            this.txtKeyName.Location = new System.Drawing.Point(98, 48);
            this.txtKeyName.MaxLength = 30;
            this.txtKeyName.Name = "txtKeyName";
            this.txtKeyName.Size = new System.Drawing.Size(141, 20);
            this.txtKeyName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.IsSendTabOnEnter = true;
            this.txtDescription.Location = new System.Drawing.Point(98, 101);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(175, 42);
            this.txtDescription.TabIndex = 3;
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.IsSendTabOnEnter = true;
            this.txtKeyValue.Location = new System.Drawing.Point(98, 75);
            this.txtKeyValue.MaxLength = 30;
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(141, 20);
            this.txtKeyValue.TabIndex = 2;
            // 
            // lblKeyName
            // 
            this.lblKeyName.AutoSize = true;
            this.lblKeyName.Location = new System.Drawing.Point(11, 52);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(56, 13);
            this.lblKeyName.TabIndex = 0;
            this.lblKeyName.Text = "KeyName:";
            // 
            // lblKeyValue
            // 
            this.lblKeyValue.AutoSize = true;
            this.lblKeyValue.Location = new System.Drawing.Point(11, 78);
            this.lblKeyValue.Name = "lblKeyValue";
            this.lblKeyValue.Size = new System.Drawing.Size(55, 13);
            this.lblKeyValue.TabIndex = 0;
            this.lblKeyValue.Text = "KeyValue:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 105);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 153);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 178);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // gvAppSettings
            // 
            this.gvAppSettings.AllowUserToAddRows = false;
            this.gvAppSettings.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvAppSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAppSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAppSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colTS,
            this.colKeyName,
            this.colKeyValue,
            this.colDescription,
            this.colLocation,
            this.colType,
            this.colBinaryValue,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAppSettings.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvAppSettings.EnableHeadersVisualStyles = false;
            this.gvAppSettings.IdTSList = null;
            this.gvAppSettings.IsEscapeKey = false;
            this.gvAppSettings.IsHeaderClick = false;
            this.gvAppSettings.Location = new System.Drawing.Point(6, 228);
            this.gvAppSettings.Name = "gvAppSettings";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAppSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvAppSettings.RowHeadersWidth = 25;
            this.gvAppSettings.ShowSerialNo = false;
            this.gvAppSettings.Size = new System.Drawing.Size(829, 304);
            this.gvAppSettings.TabIndex = 9;
            this.gvAppSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVAppSettings_CellContentClick);
            this.gvAppSettings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgVAppSettingsEntry_CellFormatting);
            this.gvAppSettings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvAppSettings_DataError);
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
            this.colTS.Width = 50;
            // 
            // colKeyName
            // 
            this.colKeyName.DataPropertyName = "KeyName";
            this.colKeyName.HeaderText = "KeyName";
            this.colKeyName.Name = "colKeyName";
            this.colKeyName.ReadOnly = true;
            // 
            // colKeyValue
            // 
            this.colKeyValue.DataPropertyName = "KeyValue";
            this.colKeyValue.HeaderText = "KeyValue";
            this.colKeyValue.Name = "colKeyValue";
            this.colKeyValue.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 75;
            // 
            // colBinaryValue
            // 
            this.colBinaryValue.DataPropertyName = "BinaryValue";
            this.colBinaryValue.HeaderText = "Photo";
            this.colBinaryValue.Name = "colBinaryValue";
            this.colBinaryValue.ReadOnly = true;
            this.colBinaryValue.Width = 75;
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
            this.txtRecordCount.Location = new System.Drawing.Point(98, 538);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(57, 20);
            this.txtRecordCount.TabIndex = 10;
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
            this.lblRecordCount.Location = new System.Drawing.Point(9, 541);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(76, 13);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(11, 204);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(38, 13);
            this.lblPhoto.TabIndex = 0;
            this.lblPhoto.Text = "Photo:";
            // 
            // picPhoto
            // 
            this.picPhoto.Location = new System.Drawing.Point(302, 52);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(143, 128);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 15;
            this.picPhoto.TabStop = false;
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
            this.tsbCRUD.Size = new System.Drawing.Size(850, 31);
            this.tsbCRUD.TabIndex = 8;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butClearPhoto
            // 
            this.butClearPhoto.Location = new System.Drawing.Point(365, 199);
            this.butClearPhoto.Name = "butClearPhoto";
            this.butClearPhoto.Size = new System.Drawing.Size(80, 23);
            this.butClearPhoto.TabIndex = 7;
            this.butClearPhoto.Text = "Clear Photo";
            this.butClearPhoto.UseVisualStyleBackColor = true;
            this.butClearPhoto.Click += new System.EventHandler(this.butClearPhoto_Click);
            // 
            // txtPhoto
            // 
            this.txtPhoto.IsSendTabOnEnter = true;
            this.txtPhoto.Location = new System.Drawing.Point(98, 200);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.ReadOnly = true;
            this.txtPhoto.Size = new System.Drawing.Size(175, 20);
            this.txtPhoto.TabIndex = 12;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(279, 199);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(80, 23);
            this.butBrowse.TabIndex = 6;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.DecimalPlaces = 0;
            this.txtLocation.IsSendTabOnEnter = true;
            this.txtLocation.Location = new System.Drawing.Point(98, 150);
            this.txtLocation.MaxLength = 3;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(57, 20);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.Text = "0";
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLocation.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtType
            // 
            this.txtType.DecimalPlaces = 0;
            this.txtType.IsSendTabOnEnter = true;
            this.txtType.Location = new System.Drawing.Point(98, 175);
            this.txtType.MaxLength = 3;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(57, 20);
            this.txtType.TabIndex = 5;
            this.txtType.Text = "0";
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtType.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // SAMVEW00010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 563);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.butClearPhoto);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.gvAppSettings);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblKeyValue);
            this.Controls.Add(this.lblKeyName);
            this.Controls.Add(this.txtKeyValue);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtKeyName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAMVEW00010";
            this.Text = "AppSetting Entry";
            this.Load += new System.EventHandler(this.SAMVEW00010_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAppSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0001 txtKeyName;
        private Windows.CXClient.Controls.CXC0001 txtDescription;
        private Windows.CXClient.Controls.CXC0001 txtKeyValue;
        private Windows.CXClient.Controls.CXC0003 lblKeyName;
        private Windows.CXClient.Controls.CXC0003 lblKeyValue;
        private Windows.CXClient.Controls.CXC0003 lblDescription;
        private Windows.CXClient.Controls.CXC0003 lblLocation;
        private Windows.CXClient.Controls.CXC0003 lblType;
        private Windows.CXClient.Controls.AceGridView gvAppSettings;
        private Windows.CXClient.Controls.CXC0004 txtRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblRecordCount;
        private Windows.CXClient.Controls.CXC0003 lblPhoto;
        private Windows.CXClient.Controls.CXC0010 picPhoto;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0007 butClearPhoto;
        private Windows.CXClient.Controls.CXC0001 txtPhoto;
        private Windows.CXClient.Controls.CXC0007 butBrowse;
        private Windows.CXClient.Controls.CXC0004 txtLocation;
        private Windows.CXClient.Controls.CXC0004 txtType;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewImageColumn colBinaryValue;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
    }
}