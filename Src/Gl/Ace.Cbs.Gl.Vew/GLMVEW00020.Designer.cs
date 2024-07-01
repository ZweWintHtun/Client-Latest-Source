namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00020));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbofromAccount = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.cbotoAccount = new Ace.Windows.CXClient.Controls.AceMultiColumnsComboBox();
            this.txtFromDCode = new System.Windows.Forms.TextBox();
            this.txtToDCode = new System.Windows.Forms.TextBox();
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
            this.tsbCRUD.Size = new System.Drawing.Size(496, 31);
            this.tsbCRUD.TabIndex = 5;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Account No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Account No.";
            // 
            // cbofromAccount
            // 
            this.cbofromAccount.AutoComplete = false;
            this.cbofromAccount.AutoDropdown = false;
            this.cbofromAccount.BackColorEven = System.Drawing.Color.White;
            this.cbofromAccount.BackColorOdd = System.Drawing.Color.White;
            this.cbofromAccount.ColumnNames = "";
            this.cbofromAccount.ColumnWidthDefault = 60;
            this.cbofromAccount.ColumnWidths = "200,150, 400";
            this.cbofromAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbofromAccount.FormattingEnabled = true;
            this.cbofromAccount.LinkedColumnIndex = 0;
            this.cbofromAccount.LinkedTextBox = null;
            this.cbofromAccount.Location = new System.Drawing.Point(152, 58);
            this.cbofromAccount.Name = "cbofromAccount";
            this.cbofromAccount.Size = new System.Drawing.Size(121, 21);
            this.cbofromAccount.TabIndex = 1;
            this.cbofromAccount.SelectedIndexChanged += new System.EventHandler(this.cbofromAccount_SelectedIndexChanged);
            // 
            // cbotoAccount
            // 
            this.cbotoAccount.AutoComplete = false;
            this.cbotoAccount.AutoDropdown = false;
            this.cbotoAccount.BackColorEven = System.Drawing.Color.White;
            this.cbotoAccount.BackColorOdd = System.Drawing.Color.White;
            this.cbotoAccount.ColumnNames = "";
            this.cbotoAccount.ColumnWidthDefault = 60;
            this.cbotoAccount.ColumnWidths = "200,150, 400";
            this.cbotoAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbotoAccount.FormattingEnabled = true;
            this.cbotoAccount.LinkedColumnIndex = 0;
            this.cbotoAccount.LinkedTextBox = null;
            this.cbotoAccount.Location = new System.Drawing.Point(152, 104);
            this.cbotoAccount.Name = "cbotoAccount";
            this.cbotoAccount.Size = new System.Drawing.Size(121, 21);
            this.cbotoAccount.TabIndex = 3;
            this.cbotoAccount.SelectedIndexChanged += new System.EventHandler(this.cbotoAccount_SelectedIndexChanged);
            // 
            // txtFromDCode
            // 
            this.txtFromDCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtFromDCode.Location = new System.Drawing.Point(319, 58);
            this.txtFromDCode.Name = "txtFromDCode";
            this.txtFromDCode.ReadOnly = true;
            this.txtFromDCode.Size = new System.Drawing.Size(92, 20);
            this.txtFromDCode.TabIndex = 2;
            this.txtFromDCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtToDCode
            // 
            this.txtToDCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtToDCode.Location = new System.Drawing.Point(319, 105);
            this.txtToDCode.Name = "txtToDCode";
            this.txtToDCode.ReadOnly = true;
            this.txtToDCode.Size = new System.Drawing.Size(92, 20);
            this.txtToDCode.TabIndex = 4;
            this.txtToDCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GLMVEW00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 164);
            this.Controls.Add(this.txtToDCode);
            this.Controls.Add(this.txtFromDCode);
            this.Controls.Add(this.cbotoAccount);
            this.Controls.Add(this.cbofromAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00020";
            this.Text = "GLMVEW00020";
            this.Load += new System.EventHandler(this.GLMVEW00020_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLMVEW00020_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cbofromAccount;
        private Windows.CXClient.Controls.AceMultiColumnsComboBox cbotoAccount;
        private System.Windows.Forms.TextBox txtFromDCode;
        private System.Windows.Forms.TextBox txtToDCode;
    }
}