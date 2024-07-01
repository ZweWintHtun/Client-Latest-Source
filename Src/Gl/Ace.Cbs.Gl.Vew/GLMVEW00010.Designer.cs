namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00010));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtRequiredYear = new System.Windows.Forms.TextBox();
            this.txtRequiredMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpIncomeAndExpenditure = new System.Windows.Forms.GroupBox();
            this.cboMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.grpIncomeAndExpenditure.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(490, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtRequiredYear
            // 
            this.txtRequiredYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtRequiredYear.Location = new System.Drawing.Point(124, 20);
            this.txtRequiredYear.Name = "txtRequiredYear";
            this.txtRequiredYear.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredYear.TabIndex = 1;
            // 
            // txtRequiredMonth
            // 
            this.txtRequiredMonth.Location = new System.Drawing.Point(360, 56);
            this.txtRequiredMonth.MaxLength = 2;
            this.txtRequiredMonth.Name = "txtRequiredMonth";
            this.txtRequiredMonth.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredMonth.TabIndex = 2;
            this.txtRequiredMonth.Tag = "";
            this.txtRequiredMonth.Visible = false;
            this.txtRequiredMonth.WordWrap = false;
            this.txtRequiredMonth.Enter += new System.EventHandler(this.txtRequiredMonth_Enter);
            this.txtRequiredMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequiredMonth_KeyDown);
            this.txtRequiredMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequiredMonth_KeyPress);
            this.txtRequiredMonth.Leave += new System.EventHandler(this.txtRequiredMonth_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Required Year :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Required Month :";
            // 
            // grpIncomeAndExpenditure
            // 
            this.grpIncomeAndExpenditure.Controls.Add(this.cboMonth);
            this.grpIncomeAndExpenditure.Controls.Add(this.label1);
            this.grpIncomeAndExpenditure.Controls.Add(this.label2);
            this.grpIncomeAndExpenditure.Controls.Add(this.txtRequiredYear);
            this.grpIncomeAndExpenditure.Controls.Add(this.txtRequiredMonth);
            this.grpIncomeAndExpenditure.Location = new System.Drawing.Point(12, 38);
            this.grpIncomeAndExpenditure.Name = "grpIncomeAndExpenditure";
            this.grpIncomeAndExpenditure.Size = new System.Drawing.Size(470, 100);
            this.grpIncomeAndExpenditure.TabIndex = 10;
            this.grpIncomeAndExpenditure.TabStop = false;
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DropDownHeight = 200;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.IntegralHeight = false;
            this.cboMonth.IsSendTabOnEnter = true;
            this.cboMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonth.Location = new System.Drawing.Point(124, 55);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(124, 21);
            this.cboMonth.TabIndex = 143;
            // 
            // GLMVEW00010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 150);
            this.Controls.Add(this.grpIncomeAndExpenditure);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GLMVEW00010";
            this.Text = "Income and Expenditure Listing";
            this.Load += new System.EventHandler(this.GLMVEW00010_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLMVEW00010_KeyDown);
            this.grpIncomeAndExpenditure.ResumeLayout(false);
            this.grpIncomeAndExpenditure.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.TextBox txtRequiredYear;
        private System.Windows.Forms.TextBox txtRequiredMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpIncomeAndExpenditure;
        private Windows.CXClient.Controls.CXC0002 cboMonth;
    }
}