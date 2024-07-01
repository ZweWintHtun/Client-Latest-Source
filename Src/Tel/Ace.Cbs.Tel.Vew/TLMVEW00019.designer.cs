namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00019
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00019));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDrawingRemmit = new System.Windows.Forms.GroupBox();
            this.lblsourcebr = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSourceBranch = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRegisterNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gvDrawingRemitt = new Ace.Windows.CXClient.Controls.AceGridView();
            this.ColRegisterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCrDr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboRegisterNo = new Ace.Windows.CXClient.Controls.CXC0002();
            this.chkVIP = new Ace.Windows.CXClient.Controls.CXC0008();
            this.gbDrawingRemmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingRemitt)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(765, 31);
            this.tsbCRUD.TabIndex = 1;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // gbDrawingRemmit
            // 
            this.gbDrawingRemmit.Controls.Add(this.lblsourcebr);
            this.gbDrawingRemmit.Controls.Add(this.lblSourceBranch);
            this.gbDrawingRemmit.Controls.Add(this.lblRegisterNo);
            this.gbDrawingRemmit.Controls.Add(this.gvDrawingRemitt);
            this.gbDrawingRemmit.Controls.Add(this.cboRegisterNo);
            this.gbDrawingRemmit.Controls.Add(this.chkVIP);
            this.gbDrawingRemmit.Location = new System.Drawing.Point(12, 37);
            this.gbDrawingRemmit.Name = "gbDrawingRemmit";
            this.gbDrawingRemmit.Size = new System.Drawing.Size(740, 302);
            this.gbDrawingRemmit.TabIndex = 0;
            this.gbDrawingRemmit.TabStop = false;
            // 
            // lblsourcebr
            // 
            this.lblsourcebr.AutoSize = true;
            this.lblsourcebr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsourcebr.Location = new System.Drawing.Point(621, 22);
            this.lblsourcebr.Name = "lblsourcebr";
            this.lblsourcebr.Size = new System.Drawing.Size(69, 13);
            this.lblsourcebr.TabIndex = 4;
            this.lblsourcebr.Text = "lblsourcebr";
            // 
            // lblSourceBranch
            // 
            this.lblSourceBranch.AutoSize = true;
            this.lblSourceBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceBranch.Location = new System.Drawing.Point(516, 22);
            this.lblSourceBranch.Name = "lblSourceBranch";
            this.lblSourceBranch.Size = new System.Drawing.Size(99, 13);
            this.lblSourceBranch.TabIndex = 3;
            this.lblSourceBranch.Text = "Source Branch :";
            // 
            // lblRegisterNo
            // 
            this.lblRegisterNo.AutoSize = true;
            this.lblRegisterNo.Location = new System.Drawing.Point(11, 26);
            this.lblRegisterNo.Name = "lblRegisterNo";
            this.lblRegisterNo.Size = new System.Drawing.Size(72, 13);
            this.lblRegisterNo.TabIndex = 0;
            this.lblRegisterNo.Text = "Register No. :";
            // 
            // gvDrawingRemitt
            // 
            this.gvDrawingRemitt.AllowUserToAddRows = false;
            this.gvDrawingRemitt.AllowUserToDeleteRows = false;
            this.gvDrawingRemitt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gvDrawingRemitt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDrawingRemitt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDrawingRemitt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRegisterNo,
            this.ColDescription,
            this.ColAmount,
            this.ColCur,
            this.ColCrDr});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDrawingRemitt.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvDrawingRemitt.EnableHeadersVisualStyles = false;
            this.gvDrawingRemitt.IdTSList = null;
            this.gvDrawingRemitt.IsEscapeKey = false;
            this.gvDrawingRemitt.IsHeaderClick = false;
            this.gvDrawingRemitt.Location = new System.Drawing.Point(14, 55);
            this.gvDrawingRemitt.Name = "gvDrawingRemitt";
            this.gvDrawingRemitt.ReadOnly = true;
            this.gvDrawingRemitt.RowHeadersWidth = 25;
            this.gvDrawingRemitt.ShowSerialNo = false;
            this.gvDrawingRemitt.Size = new System.Drawing.Size(720, 232);
            this.gvDrawingRemitt.TabIndex = 0;
            this.gvDrawingRemitt.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvDrawingRemitt_DataError);
            // 
            // ColRegisterNo
            // 
            this.ColRegisterNo.DataPropertyName = "AccountNo";
            this.ColRegisterNo.HeaderText = "Account No.";
            this.ColRegisterNo.Name = "ColRegisterNo";
            this.ColRegisterNo.ReadOnly = true;
            this.ColRegisterNo.Width = 150;
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "Description";
            this.ColDescription.HeaderText = "Description";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Width = 200;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            // 
            // ColCur
            // 
            this.ColCur.DataPropertyName = "Currency";
            this.ColCur.HeaderText = "Currency";
            this.ColCur.Name = "ColCur";
            this.ColCur.ReadOnly = true;
            // 
            // ColCrDr
            // 
            this.ColCrDr.DataPropertyName = "DebitCredit";
            this.ColCrDr.HeaderText = "Cr/Dr";
            this.ColCrDr.Name = "ColCrDr";
            this.ColCrDr.ReadOnly = true;
            // 
            // cboRegisterNo
            // 
            this.cboRegisterNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRegisterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegisterNo.DropDownHeight = 200;
            this.cboRegisterNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegisterNo.FormattingEnabled = true;
            this.cboRegisterNo.IntegralHeight = false;
            this.cboRegisterNo.IsSendTabOnEnter = true;
            this.cboRegisterNo.Location = new System.Drawing.Point(100, 23);
            this.cboRegisterNo.Name = "cboRegisterNo";
            this.cboRegisterNo.Size = new System.Drawing.Size(141, 21);
            this.cboRegisterNo.TabIndex = 0;
            this.cboRegisterNo.SelectedIndexChanged += new System.EventHandler(this.cboRegisterNo_SelectedIndexChanged);
            this.cboRegisterNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRegisterNo_KeyDown);
            // 
            // chkVIP
            // 
            this.chkVIP.AutoSize = true;
            this.chkVIP.CausesValidation = false;
            this.chkVIP.IsSendTabOnEnter = true;
            this.chkVIP.Location = new System.Drawing.Point(263, 25);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(90, 17);
            this.chkVIP.TabIndex = 1;
            this.chkVIP.Text = "VIP Customer";
            this.chkVIP.UseVisualStyleBackColor = true;
            // 
            // TLMVEW00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 349);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbDrawingRemmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TLMVEW00019";
            this.Load += new System.EventHandler(this.TLMVEW00019_Load);
            this.Move += new System.EventHandler(this.TLMVEW00019_Move);
            this.gbDrawingRemmit.ResumeLayout(false);
            this.gbDrawingRemmit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDrawingRemitt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox gbDrawingRemmit;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Ace.Windows.CXClient.Controls.CXC0003 lblRegisterNo;
        private Windows.CXClient.Controls.AceGridView gvDrawingRemitt;
        private Ace.Windows.CXClient.Controls.CXC0002 cboRegisterNo;
        private Ace.Windows.CXClient.Controls.CXC0008 chkVIP;
        private Windows.CXClient.Controls.CXC0003 lblSourceBranch;
        private Windows.CXClient.Controls.CXC0003 lblsourcebr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegisterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCrDr;
    }
}