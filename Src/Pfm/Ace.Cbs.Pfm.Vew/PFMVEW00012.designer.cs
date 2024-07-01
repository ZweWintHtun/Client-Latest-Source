namespace Ace.Cbs.Pfm.Vew
{
    partial class frmPFMVEW00012
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFMVEW00012));
            this.mtxtSavingAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.mtxtCurrentAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.lvCurrentNames = new System.Windows.Forms.ListView();
            this.gpSavingNames = new System.Windows.Forms.GroupBox();
            this.lvSavingNames = new System.Windows.Forms.ListView();
            this.lblSavoingBindNames = new Ace.Windows.CXClient.Controls.CXC0003();
            this.gpCurrentNames = new System.Windows.Forms.GroupBox();
            this.lblCurrentBindName = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSavingMinimumBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrentMinimumBalance = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblSavingAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblCurrentAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.ntxtCurrentMinimunBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.ntxtSavingMinimunBalance = new Ace.Windows.CXClient.Controls.CXC0004();
            this.gpSavingNames.SuspendLayout();
            this.gpCurrentNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtxtSavingAccountNo
            // 
            this.mtxtSavingAccountNo.HidePromptOnLeave = true;
            this.mtxtSavingAccountNo.IsSendTabOnEnter = true;
            this.mtxtSavingAccountNo.Location = new System.Drawing.Point(449, 45);
            this.mtxtSavingAccountNo.Name = "mtxtSavingAccountNo";
            this.mtxtSavingAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtSavingAccountNo.TabIndex = 2;
            this.mtxtSavingAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtCurrentAccountNo
            // 
            this.mtxtCurrentAccountNo.HidePromptOnLeave = true;
            this.mtxtCurrentAccountNo.IsSendTabOnEnter = true;
            this.mtxtCurrentAccountNo.Location = new System.Drawing.Point(143, 45);
            this.mtxtCurrentAccountNo.Name = "mtxtCurrentAccountNo";
            this.mtxtCurrentAccountNo.Size = new System.Drawing.Size(141, 20);
            this.mtxtCurrentAccountNo.TabIndex = 0;
            this.mtxtCurrentAccountNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lvCurrentNames
            // 
            this.lvCurrentNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCurrentNames.Location = new System.Drawing.Point(3, 16);
            this.lvCurrentNames.Name = "lvCurrentNames";
            this.lvCurrentNames.Size = new System.Drawing.Size(203, 138);
            this.lvCurrentNames.TabIndex = 4;
            this.lvCurrentNames.UseCompatibleStateImageBehavior = false;
            this.lvCurrentNames.View = System.Windows.Forms.View.List;
            // 
            // gpSavingNames
            // 
            this.gpSavingNames.Controls.Add(this.lvSavingNames);
            this.gpSavingNames.Controls.Add(this.lblSavoingBindNames);
            this.gpSavingNames.Location = new System.Drawing.Point(381, 103);
            this.gpSavingNames.Name = "gpSavingNames";
            this.gpSavingNames.Size = new System.Drawing.Size(209, 157);
            this.gpSavingNames.TabIndex = 20;
            this.gpSavingNames.TabStop = false;
            this.gpSavingNames.Text = "Name(s)";
            // 
            // lvSavingNames
            // 
            this.lvSavingNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSavingNames.Location = new System.Drawing.Point(3, 16);
            this.lvSavingNames.Name = "lvSavingNames";
            this.lvSavingNames.Size = new System.Drawing.Size(203, 138);
            this.lvSavingNames.TabIndex = 5;
            this.lvSavingNames.UseCompatibleStateImageBehavior = false;
            this.lvSavingNames.View = System.Windows.Forms.View.List;
            // 
            // lblSavoingBindNames
            // 
            this.lblSavoingBindNames.AutoSize = true;
            this.lblSavoingBindNames.Location = new System.Drawing.Point(74, 25);
            this.lblSavoingBindNames.Name = "lblSavoingBindNames";
            this.lblSavoingBindNames.Size = new System.Drawing.Size(0, 13);
            this.lblSavoingBindNames.TabIndex = 21;
            // 
            // gpCurrentNames
            // 
            this.gpCurrentNames.Controls.Add(this.lvCurrentNames);
            this.gpCurrentNames.Controls.Add(this.lblCurrentBindName);
            this.gpCurrentNames.Location = new System.Drawing.Point(75, 103);
            this.gpCurrentNames.Name = "gpCurrentNames";
            this.gpCurrentNames.Size = new System.Drawing.Size(209, 157);
            this.gpCurrentNames.TabIndex = 19;
            this.gpCurrentNames.TabStop = false;
            this.gpCurrentNames.Text = "Name(s)";
            // 
            // lblCurrentBindName
            // 
            this.lblCurrentBindName.AutoSize = true;
            this.lblCurrentBindName.Location = new System.Drawing.Point(69, 25);
            this.lblCurrentBindName.Name = "lblCurrentBindName";
            this.lblCurrentBindName.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentBindName.TabIndex = 20;
            // 
            // lblSavingMinimumBalance
            // 
            this.lblSavingMinimumBalance.AutoSize = true;
            this.lblSavingMinimumBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSavingMinimumBalance.Location = new System.Drawing.Point(318, 80);
            this.lblSavingMinimumBalance.Name = "lblSavingMinimumBalance";
            this.lblSavingMinimumBalance.Size = new System.Drawing.Size(96, 13);
            this.lblSavingMinimumBalance.TabIndex = 13;
            this.lblSavingMinimumBalance.Text = "Minimum Balance :";
            // 
            // lblCurrentMinimumBalance
            // 
            this.lblCurrentMinimumBalance.AutoSize = true;
            this.lblCurrentMinimumBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentMinimumBalance.Location = new System.Drawing.Point(11, 80);
            this.lblCurrentMinimumBalance.Name = "lblCurrentMinimumBalance";
            this.lblCurrentMinimumBalance.Size = new System.Drawing.Size(96, 13);
            this.lblCurrentMinimumBalance.TabIndex = 12;
            this.lblCurrentMinimumBalance.Text = "Minimum Balance :";
            // 
            // lblSavingAccountNo
            // 
            this.lblSavingAccountNo.AutoSize = true;
            this.lblSavingAccountNo.Location = new System.Drawing.Point(318, 48);
            this.lblSavingAccountNo.Name = "lblSavingAccountNo";
            this.lblSavingAccountNo.Size = new System.Drawing.Size(106, 13);
            this.lblSavingAccountNo.TabIndex = 11;
            this.lblSavingAccountNo.Text = "Saving Account No :";
            // 
            // lblCurrentAccountNo
            // 
            this.lblCurrentAccountNo.AutoSize = true;
            this.lblCurrentAccountNo.Location = new System.Drawing.Point(11, 48);
            this.lblCurrentAccountNo.Name = "lblCurrentAccountNo";
            this.lblCurrentAccountNo.Size = new System.Drawing.Size(107, 13);
            this.lblCurrentAccountNo.TabIndex = 14;
            this.lblCurrentAccountNo.Text = "Current Account No :";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(600, 30);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // ntxtCurrentMinimunBalance
            // 
            this.ntxtCurrentMinimunBalance.DecimalPlaces = 2;
            this.ntxtCurrentMinimunBalance.IsSendTabOnEnter = true;
            this.ntxtCurrentMinimunBalance.IsUseFloatingPoint = true;
            this.ntxtCurrentMinimunBalance.Location = new System.Drawing.Point(143, 77);
            this.ntxtCurrentMinimunBalance.MaxLength = 15;
            this.ntxtCurrentMinimunBalance.Name = "ntxtCurrentMinimunBalance";
            this.ntxtCurrentMinimunBalance.Size = new System.Drawing.Size(111, 20);
            this.ntxtCurrentMinimunBalance.TabIndex = 1;
            this.ntxtCurrentMinimunBalance.Text = "0.00";
            this.ntxtCurrentMinimunBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtCurrentMinimunBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntxtCurrentMinimunBalance.Click += new System.EventHandler(this.ntxtCurrentMinimunBalance_Click);
            // 
            // ntxtSavingMinimunBalance
            // 
            this.ntxtSavingMinimunBalance.DecimalPlaces = 2;
            this.ntxtSavingMinimunBalance.IsSendTabOnEnter = true;
            this.ntxtSavingMinimunBalance.IsUseFloatingPoint = true;
            this.ntxtSavingMinimunBalance.Location = new System.Drawing.Point(449, 77);
            this.ntxtSavingMinimunBalance.MaxLength = 15;
            this.ntxtSavingMinimunBalance.Name = "ntxtSavingMinimunBalance";
            this.ntxtSavingMinimunBalance.Size = new System.Drawing.Size(111, 20);
            this.ntxtSavingMinimunBalance.TabIndex = 3;
            this.ntxtSavingMinimunBalance.Text = "0.00";
            this.ntxtSavingMinimunBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtSavingMinimunBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntxtSavingMinimunBalance.Click += new System.EventHandler(this.ntxtSavingMinimunBalance_Click);
            // 
            // frmPFMVEW00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 268);
            this.Controls.Add(this.ntxtSavingMinimunBalance);
            this.Controls.Add(this.ntxtCurrentMinimunBalance);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.mtxtSavingAccountNo);
            this.Controls.Add(this.mtxtCurrentAccountNo);
            this.Controls.Add(this.gpSavingNames);
            this.Controls.Add(this.gpCurrentNames);
            this.Controls.Add(this.lblSavingMinimumBalance);
            this.Controls.Add(this.lblCurrentMinimumBalance);
            this.Controls.Add(this.lblSavingAccountNo);
            this.Controls.Add(this.lblCurrentAccountNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFMVEW00012";
            this.Text = "Link Account Entry";
            this.Load += new System.EventHandler(this.frmPFMVEW00012_Load);
            this.Move += new System.EventHandler(this.frmPFMVEW00012_Move);
            this.gpSavingNames.ResumeLayout(false);
            this.gpSavingNames.PerformLayout();
            this.gpCurrentNames.ResumeLayout(false);
            this.gpCurrentNames.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ace.Windows.CXClient.Controls.CXC0006 mtxtSavingAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0006 mtxtCurrentAccountNo;
        private System.Windows.Forms.ListView lvCurrentNames;
        private System.Windows.Forms.GroupBox gpSavingNames;
        private System.Windows.Forms.ListView lvSavingNames;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSavoingBindNames;
        private System.Windows.Forms.GroupBox gpCurrentNames;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrentBindName;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSavingMinimumBalance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrentMinimumBalance;
        private Ace.Windows.CXClient.Controls.CXC0003 lblSavingAccountNo;
        private Ace.Windows.CXClient.Controls.CXC0003 lblCurrentAccountNo;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Ace.Windows.CXClient.Controls.CXC0004 ntxtCurrentMinimunBalance;
        private Ace.Windows.CXClient.Controls.CXC0004 ntxtSavingMinimunBalance;

    }
}