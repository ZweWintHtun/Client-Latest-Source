namespace Ace.Cbs.Pfm.Vew
{
    partial class PFMVEW00035
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PFMVEW00035));
            this.rdoCertificate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPassbook = new System.Windows.Forms.RadioButton();
            this.lblSelectPrintingOption = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.butPrint = new Ace.Windows.CXClient.Controls.CXC0007();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoCertificate
            // 
            this.rdoCertificate.AutoSize = true;
            this.rdoCertificate.Location = new System.Drawing.Point(120, 18);
            this.rdoCertificate.Name = "rdoCertificate";
            this.rdoCertificate.Size = new System.Drawing.Size(72, 17);
            this.rdoCertificate.TabIndex = 1;
            this.rdoCertificate.TabStop = true;
            this.rdoCertificate.Text = "Certificate";
            this.rdoCertificate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCertificate);
            this.groupBox1.Controls.Add(this.rdoPassbook);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 53);
            this.groupBox1.TabIndex = 10000;
            this.groupBox1.TabStop = false;
            // 
            // rdoPassbook
            // 
            this.rdoPassbook.AutoSize = true;
            this.rdoPassbook.Checked = true;
            this.rdoPassbook.Location = new System.Drawing.Point(7, 18);
            this.rdoPassbook.Name = "rdoPassbook";
            this.rdoPassbook.Size = new System.Drawing.Size(72, 17);
            this.rdoPassbook.TabIndex = 0;
            this.rdoPassbook.TabStop = true;
            this.rdoPassbook.Text = "Passbook";
            this.rdoPassbook.UseVisualStyleBackColor = true;
            // 
            // lblSelectPrintingOption
            // 
            this.lblSelectPrintingOption.AutoSize = true;
            this.lblSelectPrintingOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPrintingOption.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSelectPrintingOption.Location = new System.Drawing.Point(9, 9);
            this.lblSelectPrintingOption.Name = "lblSelectPrintingOption";
            this.lblSelectPrintingOption.Size = new System.Drawing.Size(115, 13);
            this.lblSelectPrintingOption.TabIndex = 10001;
            this.lblSelectPrintingOption.Text = "Select Printing Option :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.CausesValidation = false;
            this.lblAccountNo.ForeColor = System.Drawing.Color.Red;
            this.lblAccountNo.Location = new System.Drawing.Point(143, 9);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblAccountNo.TabIndex = 10002;
            this.lblAccountNo.Text = "Account No.";
            // 
            // butPrint
            // 
            this.butPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butPrint.Location = new System.Drawing.Point(190, 84);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(50, 28);
            this.butPrint.TabIndex = 10003;
            this.butPrint.Text = "&Print";
            this.butPrint.UseVisualStyleBackColor = true;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // PFMVEW00035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 116);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.lblSelectPrintingOption);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PFMVEW00035";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Printing Option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoCertificate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPassbook;
        private System.Windows.Forms.Label lblSelectPrintingOption;
        private System.Windows.Forms.Label lblAccountNo;
        private Windows.CXClient.Controls.CXC0007 butPrint;

    }
}