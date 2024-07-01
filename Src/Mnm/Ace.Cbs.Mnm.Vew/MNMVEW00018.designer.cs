namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00018
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00018));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.grpPOEditting = new System.Windows.Forms.GroupBox();
            this.grpIncome = new System.Windows.Forms.GroupBox();
            this.rdoWithoutIncome = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoWithIncome = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdobyTransfer = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoByEncashment = new Ace.Windows.CXClient.Controls.CXC0009();
            this.btnContinue = new Ace.Windows.CXClient.Controls.CXC0007();
            this.grpPOEditting.SuspendLayout();
            this.grpIncome.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(489, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // grpPOEditting
            // 
            this.grpPOEditting.Controls.Add(this.grpIncome);
            this.grpPOEditting.Controls.Add(this.rdobyTransfer);
            this.grpPOEditting.Controls.Add(this.rdoByEncashment);
            this.grpPOEditting.Location = new System.Drawing.Point(12, 44);
            this.grpPOEditting.Name = "grpPOEditting";
            this.grpPOEditting.Size = new System.Drawing.Size(364, 152);
            this.grpPOEditting.TabIndex = 1;
            this.grpPOEditting.TabStop = false;
            this.grpPOEditting.Text = "PO Issue";
            // 
            // grpIncome
            // 
            this.grpIncome.Controls.Add(this.rdoWithoutIncome);
            this.grpIncome.Controls.Add(this.rdoWithIncome);
            this.grpIncome.Location = new System.Drawing.Point(59, 78);
            this.grpIncome.Name = "grpIncome";
            this.grpIncome.Size = new System.Drawing.Size(284, 54);
            this.grpIncome.TabIndex = 3;
            this.grpIncome.TabStop = false;
            this.grpIncome.Text = "Choose Income Type";
            // 
            // rdoWithoutIncome
            // 
            this.rdoWithoutIncome.AutoSize = true;
            this.rdoWithoutIncome.IsSendTabOnEnter = true;
            this.rdoWithoutIncome.Location = new System.Drawing.Point(154, 26);
            this.rdoWithoutIncome.Name = "rdoWithoutIncome";
            this.rdoWithoutIncome.Size = new System.Drawing.Size(100, 17);
            this.rdoWithoutIncome.TabIndex = 5;
            this.rdoWithoutIncome.Text = "Without Income";
            this.rdoWithoutIncome.UseVisualStyleBackColor = true;
            // 
            // rdoWithIncome
            // 
            this.rdoWithIncome.AutoSize = true;
            this.rdoWithIncome.Checked = true;
            this.rdoWithIncome.IsSendTabOnEnter = true;
            this.rdoWithIncome.Location = new System.Drawing.Point(44, 25);
            this.rdoWithIncome.Name = "rdoWithIncome";
            this.rdoWithIncome.Size = new System.Drawing.Size(85, 17);
            this.rdoWithIncome.TabIndex = 4;
            this.rdoWithIncome.TabStop = true;
            this.rdoWithIncome.Text = "With Income";
            this.rdoWithIncome.UseVisualStyleBackColor = true;
            // 
            // rdobyTransfer
            // 
            this.rdobyTransfer.AutoSize = true;
            this.rdobyTransfer.IsSendTabOnEnter = true;
            this.rdobyTransfer.Location = new System.Drawing.Point(18, 50);
            this.rdobyTransfer.Name = "rdobyTransfer";
            this.rdobyTransfer.Size = new System.Drawing.Size(79, 17);
            this.rdobyTransfer.TabIndex = 2;
            this.rdobyTransfer.TabStop = true;
            this.rdobyTransfer.Text = "By Transfer";
            this.rdobyTransfer.UseVisualStyleBackColor = true;
            this.rdobyTransfer.CheckedChanged += new System.EventHandler(this.rdobyTransfer_CheckedChanged);
            // 
            // rdoByEncashment
            // 
            this.rdoByEncashment.AutoSize = true;
            this.rdoByEncashment.Checked = true;
            this.rdoByEncashment.IsSendTabOnEnter = true;
            this.rdoByEncashment.Location = new System.Drawing.Point(18, 24);
            this.rdoByEncashment.Name = "rdoByEncashment";
            this.rdoByEncashment.Size = new System.Drawing.Size(99, 17);
            this.rdoByEncashment.TabIndex = 1;
            this.rdoByEncashment.TabStop = true;
            this.rdoByEncashment.Text = "By Encashment";
            this.rdoByEncashment.UseVisualStyleBackColor = true;
            this.rdoByEncashment.CheckedChanged += new System.EventHandler(this.rdoByEncashment_CheckedChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(398, 163);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(70, 35);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "&Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // MNMVEW00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 208);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.grpPOEditting);
            this.Controls.Add(this.tsbCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00018";
            this.Load += new System.EventHandler(this.MNMVEW00018_Load);
            this.Move += new System.EventHandler(this.MNMVEW00018_Move);
            this.grpPOEditting.ResumeLayout(false);
            this.grpPOEditting.PerformLayout();
            this.grpIncome.ResumeLayout(false);
            this.grpIncome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.GroupBox grpPOEditting;
        private Windows.CXClient.Controls.CXC0009 rdobyTransfer;
        private Windows.CXClient.Controls.CXC0009 rdoByEncashment;
        private System.Windows.Forms.GroupBox grpIncome;
        private Windows.CXClient.Controls.CXC0009 rdoWithoutIncome;
        private Windows.CXClient.Controls.CXC0009 rdoWithIncome;
        private Windows.CXClient.Controls.CXC0007 btnContinue;
    }
}