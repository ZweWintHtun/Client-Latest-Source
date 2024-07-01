namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00013
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00013));
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lblStartNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEndNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtChequeBookNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtEndNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtStartNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.tlspCommon = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.SuspendLayout();
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.HidePromptOnLeave = true;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(124, 42);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 0;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblStartNo
            // 
            this.lblStartNo.AutoSize = true;
            this.lblStartNo.Location = new System.Drawing.Point(20, 98);
            this.lblStartNo.Name = "lblStartNo";
            this.lblStartNo.Size = new System.Drawing.Size(55, 13);
            this.lblStartNo.TabIndex = 40;
            this.lblStartNo.Text = "Start No. :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(20, 45);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 41;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblEndNo
            // 
            this.lblEndNo.AutoSize = true;
            this.lblEndNo.Location = new System.Drawing.Point(20, 124);
            this.lblEndNo.Name = "lblEndNo";
            this.lblEndNo.Size = new System.Drawing.Size(52, 13);
            this.lblEndNo.TabIndex = 42;
            this.lblEndNo.Text = "End No. :";
            // 
            // lblChequeBookNo
            // 
            this.lblChequeBookNo.AutoSize = true;
            this.lblChequeBookNo.Location = new System.Drawing.Point(20, 71);
            this.lblChequeBookNo.Name = "lblChequeBookNo";
            this.lblChequeBookNo.Size = new System.Drawing.Size(95, 13);
            this.lblChequeBookNo.TabIndex = 43;
            this.lblChequeBookNo.Text = "Cheque Book No :";
            // 
            // txtChequeBookNo
            // 
            this.txtChequeBookNo.IsSendTabOnEnter = true;
            this.txtChequeBookNo.Location = new System.Drawing.Point(124, 68);
            this.txtChequeBookNo.MaxLength = 7;
            this.txtChequeBookNo.Name = "txtChequeBookNo";
            this.txtChequeBookNo.Size = new System.Drawing.Size(58, 20);
            this.txtChequeBookNo.TabIndex = 1;
            this.txtChequeBookNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeBookNo_KeyPress);
            // 
            // txtEndNo
            // 
            this.txtEndNo.IsSendTabOnEnter = true;
            this.txtEndNo.Location = new System.Drawing.Point(124, 120);
            this.txtEndNo.MaxLength = 8;
            this.txtEndNo.Name = "txtEndNo";
            this.txtEndNo.ReadOnly = true;
            this.txtEndNo.Size = new System.Drawing.Size(58, 20);
            this.txtEndNo.TabIndex = 3;
            this.txtEndNo.TabStop = false;
            // 
            // txtStartNo
            // 
            this.txtStartNo.IsSendTabOnEnter = true;
            this.txtStartNo.Location = new System.Drawing.Point(124, 94);
            this.txtStartNo.MaxLength = 8;
            this.txtStartNo.Name = "txtStartNo";
            this.txtStartNo.Size = new System.Drawing.Size(58, 20);
            this.txtStartNo.TabIndex = 2;
            this.txtStartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNo_KeyPress);
            // 
            // tlspCommon
            // 
            this.tlspCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlspCommon.BackColor = System.Drawing.Color.PowderBlue;
            this.tlspCommon.Location = new System.Drawing.Point(-1, 0);
            this.tlspCommon.Name = "tlspCommon";
            this.tlspCommon.PrintButtonCauseValidation = true;
            this.tlspCommon.Size = new System.Drawing.Size(496, 30);
            this.tlspCommon.TabIndex = 4;
            this.tlspCommon.SaveButtonClick += new System.EventHandler(this.tlspCommon_SaveButtonClick);
            this.tlspCommon.CancelButtonClick += new System.EventHandler(this.tlspCommon_CancelButtonClick);
            this.tlspCommon.ExitButtonClick += new System.EventHandler(this.tlspCommon_ExitButtonClick);
            // 
            // frmPFMVEW00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(494, 152);
            this.Controls.Add(this.tlspCommon);
            this.Controls.Add(this.txtStartNo);
            this.Controls.Add(this.txtEndNo);
            this.Controls.Add(this.txtChequeBookNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblStartNo);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblEndNo);
            this.Controls.Add(this.lblChequeBookNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00013";
            this.Text = "Issue Cheque Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00013_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPFMVEW00013_KeyDown);
            this.Move += new System.EventHandler(this.frmPFMVEW00013_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblStartNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblEndNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtChequeBookNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtEndNo;
        private Ace.Windows.CXClient.Controls.CXC0001 txtStartNo;
        private Windows.CXClient.Controls.CXCLIC001 tlspCommon;
    }
}