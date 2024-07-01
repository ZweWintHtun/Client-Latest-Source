namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00030));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpPostDate = new Ace.Windows.CXClient.Controls.CXC0005();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butModify = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butPreview = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpPostDate);
            this.panel1.Controls.Add(this.cboCurrency);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 144);
            this.panel1.TabIndex = 2;
            // 
            // dtpPostDate
            // 
            this.dtpPostDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpPostDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpPostDate.Enabled = false;
            this.dtpPostDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPostDate.IsSendTabOnEnter = true;
            this.dtpPostDate.Location = new System.Drawing.Point(111, 34);
            this.dtpPostDate.Name = "dtpPostDate";
            this.dtpPostDate.Size = new System.Drawing.Size(115, 20);
            this.dtpPostDate.TabIndex = 0;
            this.dtpPostDate.Value = new System.DateTime(2013, 7, 4, 0, 0, 0, 0);
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(111, 80);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(115, 21);
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCurrency_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Currency : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Post Date : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butPreview);
            this.panel2.Location = new System.Drawing.Point(251, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 144);
            this.panel2.TabIndex = 3;
            // 
            // butModify
            // 
            this.butModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butModify.Location = new System.Drawing.Point(14, 79);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(75, 29);
            this.butModify.TabIndex = 12;
            this.butModify.Text = "&Modify";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // butPreview
            // 
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPreview.Location = new System.Drawing.Point(14, 30);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(75, 29);
            this.butPreview.TabIndex = 11;
            this.butPreview.Text = "P&review";
            this.butPreview.UseVisualStyleBackColor = true;
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-6, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(502, 31);
            this.tsbCRUD.TabIndex = 10;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TCMVEW00030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 188);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00030";
            this.Text = "Daily Report Listing";
            this.Load += new System.EventHandler(this.TCMVEW00030_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label2;
        private Windows.CXClient.Controls.CXC0005 dtpPostDate;
        private Windows.CXClient.Controls.CXC0007 butModify;
        private Windows.CXClient.Controls.CXC0007 butPreview;
    }
}