namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00088
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00088));
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvHPVoucher = new System.Windows.Forms.DataGridView();
            this.ColAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHPVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(370, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 30);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvHPVoucher
            // 
            this.dgvHPVoucher.AllowUserToAddRows = false;
            this.dgvHPVoucher.AllowUserToDeleteRows = false;
            this.dgvHPVoucher.AllowUserToOrderColumns = true;
            this.dgvHPVoucher.AllowUserToResizeColumns = false;
            this.dgvHPVoucher.AllowUserToResizeRows = false;
            this.dgvHPVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHPVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAccountNo,
            this.ColAmount,
            this.ColStatus});
            this.dgvHPVoucher.Location = new System.Drawing.Point(12, 12);
            this.dgvHPVoucher.Name = "dgvHPVoucher";
            this.dgvHPVoucher.ReadOnly = true;
            this.dgvHPVoucher.RowHeadersVisible = false;
            this.dgvHPVoucher.Size = new System.Drawing.Size(447, 250);
            this.dgvHPVoucher.TabIndex = 38;
            // 
            // ColAccountNo
            // 
            this.ColAccountNo.DataPropertyName = "Acctno";
            this.ColAccountNo.HeaderText = "AccountNo";
            this.ColAccountNo.Name = "ColAccountNo";
            this.ColAccountNo.ReadOnly = true;
            this.ColAccountNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColAccountNo.Width = 200;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "Amount";
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 150;
            // 
            // ColStatus
            // 
            this.ColStatus.DataPropertyName = "Status";
            this.ColStatus.HeaderText = "Dr/Cr";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.ReadOnly = true;
            // 
            // LOMVEW00088
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 310);
            this.Controls.Add(this.dgvHPVoucher);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00088";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hire Purchase Registration Voucher";
            this.Load += new System.EventHandler(this.LOMVEW00088_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHPVoucher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvHPVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
    }
}