namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00020
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00020));
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblOldMinimumLimit = new System.Windows.Forms.Label();
            this.lblNewMinimumLimit = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtOldMinimumLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtNewMinimumLimit = new Ace.Windows.CXClient.Controls.CXC0004();
            this.txtRemark = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gvCustomer = new Ace.Windows.CXClient.Controls.AceGridView();
            this.ColCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPersonalInfo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.gbPersonalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(23, 45);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblOldMinimumLimit
            // 
            this.lblOldMinimumLimit.AutoSize = true;
            this.lblOldMinimumLimit.Location = new System.Drawing.Point(23, 72);
            this.lblOldMinimumLimit.Name = "lblOldMinimumLimit";
            this.lblOldMinimumLimit.Size = new System.Drawing.Size(97, 13);
            this.lblOldMinimumLimit.TabIndex = 1;
            this.lblOldMinimumLimit.Text = "Old Minimum Limit :";
            // 
            // lblNewMinimumLimit
            // 
            this.lblNewMinimumLimit.AutoSize = true;
            this.lblNewMinimumLimit.Location = new System.Drawing.Point(23, 97);
            this.lblNewMinimumLimit.Name = "lblNewMinimumLimit";
            this.lblNewMinimumLimit.Size = new System.Drawing.Size(103, 13);
            this.lblNewMinimumLimit.TabIndex = 2;
            this.lblNewMinimumLimit.Text = "New Minimum Limit :";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(23, 124);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(50, 13);
            this.lblRemark.TabIndex = 3;
            this.lblRemark.Text = "Remark :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(796, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(145, 42);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtOldMinimumLimit
            // 
            this.txtOldMinimumLimit.DecimalPlaces = 2;
            this.txtOldMinimumLimit.IsSendTabOnEnter = true;
            this.txtOldMinimumLimit.IsThousandSeperator = true;
            this.txtOldMinimumLimit.IsUseFloatingPoint = true;
            this.txtOldMinimumLimit.Location = new System.Drawing.Point(145, 68);
            this.txtOldMinimumLimit.MaxLength = 18;
            this.txtOldMinimumLimit.Name = "txtOldMinimumLimit";
            this.txtOldMinimumLimit.ReadOnly = true;
            this.txtOldMinimumLimit.Size = new System.Drawing.Size(111, 20);
            this.txtOldMinimumLimit.TabIndex = 6;
            this.txtOldMinimumLimit.Text = "0.00";
            this.txtOldMinimumLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOldMinimumLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtNewMinimumLimit
            // 
            this.txtNewMinimumLimit.DecimalPlaces = 2;
            this.txtNewMinimumLimit.IsSendTabOnEnter = true;
            this.txtNewMinimumLimit.IsThousandSeperator = true;
            this.txtNewMinimumLimit.IsUseFloatingPoint = true;
            this.txtNewMinimumLimit.Location = new System.Drawing.Point(145, 94);
            this.txtNewMinimumLimit.MaxLength = 18;
            this.txtNewMinimumLimit.Name = "txtNewMinimumLimit";
            this.txtNewMinimumLimit.Size = new System.Drawing.Size(111, 20);
            this.txtNewMinimumLimit.TabIndex = 2;
            this.txtNewMinimumLimit.Text = "0.00";
            this.txtNewMinimumLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewMinimumLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtRemark
            // 
            this.txtRemark.IsSendTabOnEnter = true;
            this.txtRemark.Location = new System.Drawing.Point(145, 120);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(175, 20);
            this.txtRemark.TabIndex = 3;
            // 
            // gvCustomer
            // 
            this.gvCustomer.AllowUserToAddRows = false;
            this.gvCustomer.AllowUserToDeleteRows = false;
            this.gvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCustomerID,
            this.ColName,
            this.ColNRC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCustomer.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvCustomer.EnableHeadersVisualStyles = false;
            this.gvCustomer.IdTSList = null;
            this.gvCustomer.IsEscapeKey = false;
            this.gvCustomer.IsHeaderClick = false;
            this.gvCustomer.Location = new System.Drawing.Point(10, 22);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvCustomer.RowHeadersWidth = 25;
            this.gvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCustomer.ShowSerialNo = false;
            this.gvCustomer.Size = new System.Drawing.Size(738, 257);
            this.gvCustomer.TabIndex = 4;
            // 
            // ColCustomerID
            // 
            this.ColCustomerID.DataPropertyName = "CustomerId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColCustomerID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCustomerID.HeaderText = "Customer ID";
            this.ColCustomerID.Name = "ColCustomerID";
            this.ColCustomerID.ReadOnly = true;
            this.ColCustomerID.Width = 140;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 250;
            // 
            // ColNRC
            // 
            this.ColNRC.DataPropertyName = "NRC";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColNRC.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColNRC.HeaderText = "NRC No";
            this.ColNRC.Name = "ColNRC";
            this.ColNRC.ReadOnly = true;
            this.ColNRC.Width = 250;
            // 
            // gbPersonalInfo
            // 
            this.gbPersonalInfo.Controls.Add(this.gvCustomer);
            this.gbPersonalInfo.Location = new System.Drawing.Point(11, 143);
            this.gbPersonalInfo.Name = "gbPersonalInfo";
            this.gbPersonalInfo.Size = new System.Drawing.Size(759, 294);
            this.gbPersonalInfo.TabIndex = 115;
            this.gbPersonalInfo.TabStop = false;
            // 
            // TCMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 451);
            this.Controls.Add(this.gbPersonalInfo);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtNewMinimumLimit);
            this.Controls.Add(this.txtOldMinimumLimit);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblNewMinimumLimit);
            this.Controls.Add(this.lblOldMinimumLimit);
            this.Controls.Add(this.lblAccountNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00020";
            this.Text = "Minimum Balance Entry";
            this.Load += new System.EventHandler(this.TCMVEW00020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.gbPersonalInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblOldMinimumLimit;
        private System.Windows.Forms.Label lblNewMinimumLimit;
        private System.Windows.Forms.Label lblRemark;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0004 txtOldMinimumLimit;
        private Windows.CXClient.Controls.CXC0004 txtNewMinimumLimit;
        private Windows.CXClient.Controls.CXC0001 txtRemark;
        private Windows.CXClient.Controls.AceGridView gvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNRC;
        private System.Windows.Forms.GroupBox gbPersonalInfo;
    }
}