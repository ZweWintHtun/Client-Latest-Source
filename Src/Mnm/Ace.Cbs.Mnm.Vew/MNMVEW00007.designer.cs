namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00007));
            this.grpSavingAC = new System.Windows.Forms.GroupBox();
            this.rdoSavingNotAccrued = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoSavingAccrued = new Ace.Windows.CXClient.Controls.CXC0009();
            this.grpFixedAC = new System.Windows.Forms.GroupBox();
            this.rdoFixedNotAccrued = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoFixedAccrued = new Ace.Windows.CXClient.Controls.CXC0009();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpSavingAC.SuspendLayout();
            this.grpFixedAC.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSavingAC
            // 
            this.grpSavingAC.Controls.Add(this.rdoSavingNotAccrued);
            this.grpSavingAC.Controls.Add(this.rdoSavingAccrued);
            this.grpSavingAC.Location = new System.Drawing.Point(19, 38);
            this.grpSavingAC.Name = "grpSavingAC";
            this.grpSavingAC.Size = new System.Drawing.Size(202, 52);
            this.grpSavingAC.TabIndex = 72;
            this.grpSavingAC.TabStop = false;
            this.grpSavingAC.Text = "Saving Account :";
            // 
            // rdoSavingNotAccrued
            // 
            this.rdoSavingNotAccrued.AutoSize = true;
            this.rdoSavingNotAccrued.IsSendTabOnEnter = true;
            this.rdoSavingNotAccrued.Location = new System.Drawing.Point(100, 21);
            this.rdoSavingNotAccrued.Name = "rdoSavingNotAccrued";
            this.rdoSavingNotAccrued.Size = new System.Drawing.Size(85, 17);
            this.rdoSavingNotAccrued.TabIndex = 75;
            this.rdoSavingNotAccrued.Text = "Not Accrued";
            this.rdoSavingNotAccrued.UseVisualStyleBackColor = true;
            // 
            // rdoSavingAccrued
            // 
            this.rdoSavingAccrued.AutoSize = true;
            this.rdoSavingAccrued.IsSendTabOnEnter = true;
            this.rdoSavingAccrued.Location = new System.Drawing.Point(18, 21);
            this.rdoSavingAccrued.Name = "rdoSavingAccrued";
            this.rdoSavingAccrued.Size = new System.Drawing.Size(65, 17);
            this.rdoSavingAccrued.TabIndex = 74;
            this.rdoSavingAccrued.Text = "Accrued";
            this.rdoSavingAccrued.UseVisualStyleBackColor = true;
            // 
            // grpFixedAC
            // 
            this.grpFixedAC.Controls.Add(this.rdoFixedNotAccrued);
            this.grpFixedAC.Controls.Add(this.rdoFixedAccrued);
            this.grpFixedAC.Location = new System.Drawing.Point(246, 40);
            this.grpFixedAC.Name = "grpFixedAC";
            this.grpFixedAC.Size = new System.Drawing.Size(203, 50);
            this.grpFixedAC.TabIndex = 73;
            this.grpFixedAC.TabStop = false;
            this.grpFixedAC.Text = "Fixed Account :";
            // 
            // rdoFixedNotAccrued
            // 
            this.rdoFixedNotAccrued.AutoSize = true;
            this.rdoFixedNotAccrued.IsSendTabOnEnter = true;
            this.rdoFixedNotAccrued.Location = new System.Drawing.Point(100, 19);
            this.rdoFixedNotAccrued.Name = "rdoFixedNotAccrued";
            this.rdoFixedNotAccrued.Size = new System.Drawing.Size(85, 17);
            this.rdoFixedNotAccrued.TabIndex = 76;
            this.rdoFixedNotAccrued.Text = "Not Accrued";
            this.rdoFixedNotAccrued.UseVisualStyleBackColor = true;
            // 
            // rdoFixedAccrued
            // 
            this.rdoFixedAccrued.AutoSize = true;
            this.rdoFixedAccrued.IsSendTabOnEnter = true;
            this.rdoFixedAccrued.Location = new System.Drawing.Point(18, 19);
            this.rdoFixedAccrued.Name = "rdoFixedAccrued";
            this.rdoFixedAccrued.Size = new System.Drawing.Size(65, 17);
            this.rdoFixedAccrued.TabIndex = 75;
            this.rdoFixedAccrued.Text = "Accrued";
            this.rdoFixedAccrued.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(480, 31);
            this.tsbCRUD.TabIndex = 74;
            // 
            // MNMVEW00007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 110);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.grpFixedAC);
            this.Controls.Add(this.grpSavingAC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00007";
            this.Text = "Interest Nature Configuration";
            this.Load += new System.EventHandler(this.MNMVEW00007_Load);
            this.grpSavingAC.ResumeLayout(false);
            this.grpSavingAC.PerformLayout();
            this.grpFixedAC.ResumeLayout(false);
            this.grpFixedAC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSavingAC;
        private Windows.CXClient.Controls.CXC0009 rdoSavingNotAccrued;
        private Windows.CXClient.Controls.CXC0009 rdoSavingAccrued;
        private System.Windows.Forms.GroupBox grpFixedAC;
        private Windows.CXClient.Controls.CXC0009 rdoFixedNotAccrued;
        private Windows.CXClient.Controls.CXC0009 rdoFixedAccrued;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}