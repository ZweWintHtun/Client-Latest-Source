namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00012
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00012));
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblCheckBookNo = new System.Windows.Forms.Label();
            this.lblStartSerialNo = new System.Windows.Forms.Label();
            this.lblEndSerialNo = new System.Windows.Forms.Label();
            this.mtxtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.txtCheckBookNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtStartSerialNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtEndSerialNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.lblNRC = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbName.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(14, 47);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblCheckBookNo
            // 
            this.lblCheckBookNo.AutoSize = true;
            this.lblCheckBookNo.Location = new System.Drawing.Point(14, 73);
            this.lblCheckBookNo.Name = "lblCheckBookNo";
            this.lblCheckBookNo.Size = new System.Drawing.Size(89, 13);
            this.lblCheckBookNo.TabIndex = 1;
            this.lblCheckBookNo.Text = "Check Book No :";
            // 
            // lblStartSerialNo
            // 
            this.lblStartSerialNo.AutoSize = true;
            this.lblStartSerialNo.Location = new System.Drawing.Point(14, 99);
            this.lblStartSerialNo.Name = "lblStartSerialNo";
            this.lblStartSerialNo.Size = new System.Drawing.Size(81, 13);
            this.lblStartSerialNo.TabIndex = 2;
            this.lblStartSerialNo.Text = "Start Serial No :";
            // 
            // lblEndSerialNo
            // 
            this.lblEndSerialNo.AutoSize = true;
            this.lblEndSerialNo.Location = new System.Drawing.Point(14, 125);
            this.lblEndSerialNo.Name = "lblEndSerialNo";
            this.lblEndSerialNo.Size = new System.Drawing.Size(78, 13);
            this.lblEndSerialNo.TabIndex = 3;
            this.lblEndSerialNo.Text = "End Serial No :";
            // 
            // mtxtAccountNo
            // 
            this.mtxtAccountNo.BackColor = System.Drawing.SystemColors.Window;
            this.mtxtAccountNo.IsSendTabOnEnter = true;
            this.mtxtAccountNo.Location = new System.Drawing.Point(122, 44);
            this.mtxtAccountNo.Name = "mtxtAccountNo";
            this.mtxtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtAccountNo.TabIndex = 1;
            this.mtxtAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCheckBookNo
            // 
            this.txtCheckBookNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCheckBookNo.IsSendTabOnEnter = true;
            this.txtCheckBookNo.Location = new System.Drawing.Point(122, 70);
            this.txtCheckBookNo.MaxLength = 7;
            this.txtCheckBookNo.Name = "txtCheckBookNo";
            this.txtCheckBookNo.Size = new System.Drawing.Size(58, 20);
            this.txtCheckBookNo.TabIndex = 2;
            this.txtCheckBookNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheckBookNo_KeyPress);
            // 
            // txtStartSerialNo
            // 
            this.txtStartSerialNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartSerialNo.IsSendTabOnEnter = true;
            this.txtStartSerialNo.Location = new System.Drawing.Point(122, 96);
            this.txtStartSerialNo.MaxLength = 8;
            this.txtStartSerialNo.Name = "txtStartSerialNo";
            this.txtStartSerialNo.Size = new System.Drawing.Size(58, 20);
            this.txtStartSerialNo.TabIndex = 3;
            this.txtStartSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartSerialNo_KeyPress);
            // 
            // txtEndSerialNo
            // 
            this.txtEndSerialNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndSerialNo.IsSendTabOnEnter = true;
            this.txtEndSerialNo.Location = new System.Drawing.Point(122, 122);
            this.txtEndSerialNo.MaxLength = 8;
            this.txtEndSerialNo.Name = "txtEndSerialNo";
            this.txtEndSerialNo.Size = new System.Drawing.Size(58, 20);
            this.txtEndSerialNo.TabIndex = 4;
            this.txtEndSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndSerialNo_KeyPress);
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.lblNRC);
            this.gbName.Controls.Add(this.lblName);
            this.gbName.Location = new System.Drawing.Point(272, 36);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(200, 111);
            this.gbName.TabIndex = 108;
            this.gbName.TabStop = false;
            this.gbName.Text = "Customer Information";
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(25, 70);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(40, 13);
            this.lblNRC.TabIndex = 110;
            this.lblNRC.Text = "lblNRC";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 109;
            this.lblName.Text = "lblName";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(488, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TCMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 159);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.gbName);
            this.Controls.Add(this.txtEndSerialNo);
            this.Controls.Add(this.txtStartSerialNo);
            this.Controls.Add(this.txtCheckBookNo);
            this.Controls.Add(this.mtxtAccountNo);
            this.Controls.Add(this.lblEndSerialNo);
            this.Controls.Add(this.lblStartSerialNo);
            this.Controls.Add(this.lblCheckBookNo);
            this.Controls.Add(this.lblAccountNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TCMVEW00012";
            this.Text = "Stop Payment Cheque Release";
            this.Load += new System.EventHandler(this.TCMVEW00012_Load);
            this.Move += new System.EventHandler(this.TCMVEW00012_Move);
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblCheckBookNo;
        private System.Windows.Forms.Label lblStartSerialNo;
        private System.Windows.Forms.Label lblEndSerialNo;
        private Windows.CXClient.Controls.CXC0006 mtxtAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtCheckBookNo;
        private Windows.CXClient.Controls.CXC0001 txtStartSerialNo;
        private Windows.CXClient.Controls.CXC0001 txtEndSerialNo;
        private System.Windows.Forms.GroupBox gbName;     
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.Label lblName;       
    }
}