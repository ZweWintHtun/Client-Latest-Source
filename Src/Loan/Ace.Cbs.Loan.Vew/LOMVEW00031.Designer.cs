namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00031));
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTypeOfAdvance = new Ace.Windows.CXClient.Controls.CXC0002();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(310, 120);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(499, 31);
            this.tsbCRUD.TabIndex = 67;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Lons Types";
            // 
            // cboTypeOfAdvance
            // 
            this.cboTypeOfAdvance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTypeOfAdvance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypeOfAdvance.DropDownHeight = 200;
            this.cboTypeOfAdvance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeOfAdvance.FormattingEnabled = true;
            this.cboTypeOfAdvance.IntegralHeight = false;
            this.cboTypeOfAdvance.IsSendTabOnEnter = true;
            this.cboTypeOfAdvance.Location = new System.Drawing.Point(127, 67);
            this.cboTypeOfAdvance.Name = "cboTypeOfAdvance";
            this.cboTypeOfAdvance.Size = new System.Drawing.Size(124, 21);
            this.cboTypeOfAdvance.TabIndex = 69;
            // 
            // LOMVEW00031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 175);
            this.Controls.Add(this.cboTypeOfAdvance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.butOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00031";
            this.Text = "LOMVEW00031";
            this.Load += new System.EventHandler(this.LOMVEW00031_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 butOk;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXC0002 cboTypeOfAdvance;
    }
}