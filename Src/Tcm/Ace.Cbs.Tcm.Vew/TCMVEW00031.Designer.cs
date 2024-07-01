namespace Ace.Cbs.Tcm.Vew
{
    partial class TCMVEW00031
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCMVEW00031));
            this.butContinue = new System.Windows.Forms.Button();
            this.rdoIndividual = new System.Windows.Forms.RadioButton();
            this.gbDenoDelete = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoCashPayment = new System.Windows.Forms.RadioButton();
            this.rdoCashReceipt = new System.Windows.Forms.RadioButton();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gbDenoDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // butContinue
            // 
            this.butContinue.Location = new System.Drawing.Point(13, 119);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(75, 24);
            this.butContinue.TabIndex = 0;
            this.butContinue.Text = "&Continue";
            this.butContinue.UseVisualStyleBackColor = true;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // rdoIndividual
            // 
            this.rdoIndividual.AutoSize = true;
            this.rdoIndividual.Location = new System.Drawing.Point(13, 86);
            this.rdoIndividual.Name = "rdoIndividual";
            this.rdoIndividual.Size = new System.Drawing.Size(70, 17);
            this.rdoIndividual.TabIndex = 0;
            this.rdoIndividual.TabStop = true;
            this.rdoIndividual.Text = "Individual";
            this.rdoIndividual.UseVisualStyleBackColor = true;
            // 
            // gbDenoDelete
            // 
            this.gbDenoDelete.Controls.Add(this.butContinue);
            this.gbDenoDelete.Controls.Add(this.rdoIndividual);
            this.gbDenoDelete.Controls.Add(this.rdoAll);
            this.gbDenoDelete.Controls.Add(this.rdoCashPayment);
            this.gbDenoDelete.Controls.Add(this.rdoCashReceipt);
            this.gbDenoDelete.Location = new System.Drawing.Point(8, 37);
            this.gbDenoDelete.Name = "gbDenoDelete";
            this.gbDenoDelete.Size = new System.Drawing.Size(476, 163);
            this.gbDenoDelete.TabIndex = 10;
            this.gbDenoDelete.TabStop = false;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(13, 63);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoCashPayment
            // 
            this.rdoCashPayment.AutoSize = true;
            this.rdoCashPayment.Location = new System.Drawing.Point(13, 40);
            this.rdoCashPayment.Name = "rdoCashPayment";
            this.rdoCashPayment.Size = new System.Drawing.Size(93, 17);
            this.rdoCashPayment.TabIndex = 0;
            this.rdoCashPayment.TabStop = true;
            this.rdoCashPayment.Text = "Cash Payment";
            this.rdoCashPayment.UseVisualStyleBackColor = true;
            // 
            // rdoCashReceipt
            // 
            this.rdoCashReceipt.AutoSize = true;
            this.rdoCashReceipt.Location = new System.Drawing.Point(13, 17);
            this.rdoCashReceipt.Name = "rdoCashReceipt";
            this.rdoCashReceipt.Size = new System.Drawing.Size(89, 17);
            this.rdoCashReceipt.TabIndex = 0;
            this.rdoCashReceipt.TabStop = true;
            this.rdoCashReceipt.Text = "Cash Receipt";
            this.rdoCashReceipt.UseVisualStyleBackColor = true;
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(496, 32);
            this.tsbCRUD.TabIndex = 9;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // TCMVEW00031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 212);
            this.Controls.Add(this.gbDenoDelete);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TCMVEW00031";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denomination Delete";
            this.Load += new System.EventHandler(this.TCMVEW00031_Load);
            this.gbDenoDelete.ResumeLayout(false);
            this.gbDenoDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butContinue;
        private System.Windows.Forms.RadioButton rdoIndividual;
        private System.Windows.Forms.GroupBox gbDenoDelete;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoCashPayment;
        private System.Windows.Forms.RadioButton rdoCashReceipt;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
    }
}