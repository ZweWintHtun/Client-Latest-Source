namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00006));
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.rdoTrialBalance = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoIncomeAndExp = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoBalanceSheet = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoProfitAndLoss = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.grpSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelection
            // 
            this.grpSelection.Controls.Add(this.rdoTrialBalance);
            this.grpSelection.Controls.Add(this.rdoIncomeAndExp);
            this.grpSelection.Controls.Add(this.rdoBalanceSheet);
            this.grpSelection.Controls.Add(this.rdoProfitAndLoss);
            this.grpSelection.Location = new System.Drawing.Point(21, 50);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(302, 159);
            this.grpSelection.TabIndex = 4;
            this.grpSelection.TabStop = false;
            this.grpSelection.Text = "Select the required statement that you wnat to view Report.";
            // 
            // rdoTrialBalance
            // 
            this.rdoTrialBalance.AutoSize = true;
            this.rdoTrialBalance.IsSendTabOnEnter = true;
            this.rdoTrialBalance.Location = new System.Drawing.Point(21, 124);
            this.rdoTrialBalance.Name = "rdoTrialBalance";
            this.rdoTrialBalance.Size = new System.Drawing.Size(87, 17);
            this.rdoTrialBalance.TabIndex = 7;
            this.rdoTrialBalance.TabStop = true;
            this.rdoTrialBalance.Text = "&Trial Balance";
            this.rdoTrialBalance.UseVisualStyleBackColor = true;
            // 
            // rdoIncomeAndExp
            // 
            this.rdoIncomeAndExp.AutoSize = true;
            this.rdoIncomeAndExp.IsSendTabOnEnter = true;
            this.rdoIncomeAndExp.Location = new System.Drawing.Point(21, 92);
            this.rdoIncomeAndExp.Name = "rdoIncomeAndExp";
            this.rdoIncomeAndExp.Size = new System.Drawing.Size(128, 17);
            this.rdoIncomeAndExp.TabIndex = 6;
            this.rdoIncomeAndExp.TabStop = true;
            this.rdoIncomeAndExp.Text = "&Income && Expenditure";
            this.rdoIncomeAndExp.UseVisualStyleBackColor = true;
            // 
            // rdoBalanceSheet
            // 
            this.rdoBalanceSheet.AutoSize = true;
            this.rdoBalanceSheet.IsSendTabOnEnter = true;
            this.rdoBalanceSheet.Location = new System.Drawing.Point(21, 60);
            this.rdoBalanceSheet.Name = "rdoBalanceSheet";
            this.rdoBalanceSheet.Size = new System.Drawing.Size(95, 17);
            this.rdoBalanceSheet.TabIndex = 5;
            this.rdoBalanceSheet.TabStop = true;
            this.rdoBalanceSheet.Text = "&Balance Sheet";
            this.rdoBalanceSheet.UseVisualStyleBackColor = true;
            // 
            // rdoProfitAndLoss
            // 
            this.rdoProfitAndLoss.AutoSize = true;
            this.rdoProfitAndLoss.IsSendTabOnEnter = true;
            this.rdoProfitAndLoss.Location = new System.Drawing.Point(21, 28);
            this.rdoProfitAndLoss.Name = "rdoProfitAndLoss";
            this.rdoProfitAndLoss.Size = new System.Drawing.Size(83, 17);
            this.rdoProfitAndLoss.TabIndex = 4;
            this.rdoProfitAndLoss.TabStop = true;
            this.rdoProfitAndLoss.Text = "&Profit && Loss";
            this.rdoProfitAndLoss.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(485, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(210, 226);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(76, 26);
            this.butOk.TabIndex = 7;
            this.butOk.Text = "&OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // GLMVEW00006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(484, 271);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00006";
            this.Text = "Selection";
            this.Load += new System.EventHandler(this.GLVEW00006_Load);
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelection;
        private Windows.CXClient.Controls.CXC0009 rdoTrialBalance;
        private Windows.CXClient.Controls.CXC0009 rdoIncomeAndExp;
        private Windows.CXClient.Controls.CXC0009 rdoBalanceSheet;
        private Windows.CXClient.Controls.CXC0009 rdoProfitAndLoss;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0007 butOk;
    }
}