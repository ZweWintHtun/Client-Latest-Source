namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00009
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00009));
            this.txtLineNo = new Ace.Windows.CXClient.Controls.CXC0004();
            this.lblLineNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCancelInformation = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSaveInformation = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblPrintInformation = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvGroupInfo = new System.Windows.Forms.GroupBox();
            this.chkDoPrinting = new Ace.Windows.CXClient.Controls.CXC0008();
            this.SuspendLayout();
            // 
            // txtLineNo
            // 
            this.txtLineNo.DecimalPlaces = 0;
            this.txtLineNo.IsSendTabOnEnter = true;
            this.txtLineNo.Location = new System.Drawing.Point(137, 182);
            this.txtLineNo.MaxLength = 2;
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(111, 20);
            this.txtLineNo.TabIndex = 6;
            this.txtLineNo.Text = "0";
            this.txtLineNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLineNo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblLineNo
            // 
            this.lblLineNo.AutoSize = true;
            this.lblLineNo.Location = new System.Drawing.Point(81, 185);
            this.lblLineNo.Name = "lblLineNo";
            this.lblLineNo.Size = new System.Drawing.Size(53, 13);
            this.lblLineNo.TabIndex = 5;
            this.lblLineNo.Text = "Line No. :";
            // 
            // lblCancelInformation
            // 
            this.lblCancelInformation.AutoSize = true;
            this.lblCancelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelInformation.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCancelInformation.Location = new System.Drawing.Point(65, 105);
            this.lblCancelInformation.Name = "lblCancelInformation";
            this.lblCancelInformation.Size = new System.Drawing.Size(309, 13);
            this.lblCancelInformation.TabIndex = 4;
            this.lblCancelInformation.Text = "Click \' Exit \' button / Press Escape to cancel the job.";
            // 
            // lblSaveInformation
            // 
            this.lblSaveInformation.AutoSize = true;
            this.lblSaveInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveInformation.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSaveInformation.Location = new System.Drawing.Point(65, 75);
            this.lblSaveInformation.Name = "lblSaveInformation";
            this.lblSaveInformation.Size = new System.Drawing.Size(289, 13);
            this.lblSaveInformation.TabIndex = 3;
            this.lblSaveInformation.Text = "Click \' Save \' button / Press \' F2 \' to Save in File.";
            // 
            // lblPrintInformation
            // 
            this.lblPrintInformation.AutoSize = true;
            this.lblPrintInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrintInformation.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPrintInformation.Location = new System.Drawing.Point(65, 46);
            this.lblPrintInformation.Name = "lblPrintInformation";
            this.lblPrintInformation.Size = new System.Drawing.Size(327, 13);
            this.lblPrintInformation.TabIndex = 2;
            this.lblPrintInformation.Text = "Click \' Print \' button / Press \' F7 \' to Print on Pass Book.";
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(0, -1);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(494, 30);
            this.tlspCommon.TabIndex = 7;
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.PrintButtonClick += new System.EventHandler(this.tlspCommon_PrintButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // gvGroupInfo
            // 
            this.gvGroupInfo.Location = new System.Drawing.Point(68, 164);
            this.gvGroupInfo.Name = "gvGroupInfo";
            this.gvGroupInfo.Size = new System.Drawing.Size(200, 55);
            this.gvGroupInfo.TabIndex = 8;
            this.gvGroupInfo.TabStop = false;
            this.gvGroupInfo.Text = "Print Info:";
            // 
            // chkDoPrinting
            // 
            this.chkDoPrinting.AutoSize = true;
            this.chkDoPrinting.IsSendTabOnEnter = true;
            this.chkDoPrinting.Location = new System.Drawing.Point(68, 139);
            this.chkDoPrinting.Name = "chkDoPrinting";
            this.chkDoPrinting.Size = new System.Drawing.Size(47, 17);
            this.chkDoPrinting.TabIndex = 9;
            this.chkDoPrinting.Text = "Print";
            this.chkDoPrinting.UseVisualStyleBackColor = true;
            this.chkDoPrinting.CheckedChanged += new System.EventHandler(this.chkDoPrinting_CheckedChanged);
            // 
            // frmPFMVEW00009
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 237);
            this.Controls.Add(this.chkDoPrinting);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.txtLineNo);
            this.Controls.Add(this.lblLineNo);
            this.Controls.Add(this.lblCancelInformation);
            this.Controls.Add(this.lblSaveInformation);
            this.Controls.Add(this.lblPrintInformation);
            this.Controls.Add(this.gvGroupInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00009";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Banking Information System";
            this.Load += new System.EventHandler(this.PFMVEW00009_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPFMVEW00009_KeyDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmPFMVEW00009_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0004 txtLineNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblLineNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCancelInformation;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSaveInformation;
        private Ace.Windows.CXClient.Controls.CXC0003 lblPrintInformation;
        private Ace.Windows.CXClient.Controls.CXCLIC001 tlspCommon;
        private System.Windows.Forms.GroupBox gvGroupInfo;
        private Ace.Windows.CXClient.Controls.CXC0008 chkDoPrinting;
    }
}