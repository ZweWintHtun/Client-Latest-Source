namespace Ace.Cbs.Loan.Vew
{
    partial class LOMVEW00055
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOMVEW00055));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.butOk = new Ace.Windows.CXClient.Controls.CXC0007();
            this.rdoOctDec = new System.Windows.Forms.RadioButton();
            this.rdoJulSep = new System.Windows.Forms.RadioButton();
            this.rdoAprJun = new System.Windows.Forms.RadioButton();
            this.rdoJanMar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(484, 36);
            this.tsbCRUD.TabIndex = 57;
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(99, 146);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 24);
            this.butOk.TabIndex = 66;
            this.butOk.Text = "&Ok";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // rdoOctDec
            // 
            this.rdoOctDec.AutoSize = true;
            this.rdoOctDec.Location = new System.Drawing.Point(25, 118);
            this.rdoOctDec.Name = "rdoOctDec";
            this.rdoOctDec.Size = new System.Drawing.Size(127, 17);
            this.rdoOctDec.TabIndex = 65;
            this.rdoOctDec.TabStop = true;
            this.rdoOctDec.Text = "October to December";
            this.rdoOctDec.UseVisualStyleBackColor = true;
            // 
            // rdoJulSep
            // 
            this.rdoJulSep.AutoSize = true;
            this.rdoJulSep.Location = new System.Drawing.Point(25, 95);
            this.rdoJulSep.Name = "rdoJulSep";
            this.rdoJulSep.Size = new System.Drawing.Size(109, 17);
            this.rdoJulSep.TabIndex = 64;
            this.rdoJulSep.TabStop = true;
            this.rdoJulSep.Text = "July to September";
            this.rdoJulSep.UseVisualStyleBackColor = true;
            // 
            // rdoAprJun
            // 
            this.rdoAprJun.AutoSize = true;
            this.rdoAprJun.Location = new System.Drawing.Point(25, 72);
            this.rdoAprJun.Name = "rdoAprJun";
            this.rdoAprJun.Size = new System.Drawing.Size(83, 17);
            this.rdoAprJun.TabIndex = 63;
            this.rdoAprJun.TabStop = true;
            this.rdoAprJun.Text = "April to June";
            this.rdoAprJun.UseVisualStyleBackColor = true;
            // 
            // rdoJanMar
            // 
            this.rdoJanMar.AutoSize = true;
            this.rdoJanMar.Location = new System.Drawing.Point(25, 49);
            this.rdoJanMar.Name = "rdoJanMar";
            this.rdoJanMar.Size = new System.Drawing.Size(107, 17);
            this.rdoJanMar.TabIndex = 62;
            this.rdoJanMar.TabStop = true;
            this.rdoJanMar.Text = "January to March";
            this.rdoJanMar.UseVisualStyleBackColor = true;
            // 
            // LOMVEW00055
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 180);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.rdoOctDec);
            this.Controls.Add(this.rdoJulSep);
            this.Controls.Add(this.rdoAprJun);
            this.Controls.Add(this.rdoJanMar);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOMVEW00055";
            this.Text = "LOMVEW00055";
            this.Load += new System.EventHandler(this.LOMVEW00055_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0007 butOk;
        private System.Windows.Forms.RadioButton rdoOctDec;
        private System.Windows.Forms.RadioButton rdoJulSep;
        private System.Windows.Forms.RadioButton rdoAprJun;
        private System.Windows.Forms.RadioButton rdoJanMar;
    }
}