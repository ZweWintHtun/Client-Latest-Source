namespace Ace.Cbs.Tel.Vew
{
    partial class TLMVEW00037
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TLMVEW00037));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.rdoAmountAndIncomeOutstand = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoDrawingAmountOutstand = new Ace.Windows.CXClient.Controls.CXC0009();
            this.rdoIncomeOustand = new Ace.Windows.CXClient.Controls.CXC0009();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-3, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(521, 31);
            this.tsbCRUD.TabIndex = 7;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.PrintButtonClick += new System.EventHandler(this.tsbCRUD_PrintButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // rdoAmountAndIncomeOutstand
            // 
            this.rdoAmountAndIncomeOutstand.AutoSize = true;
            this.rdoAmountAndIncomeOutstand.IsSendTabOnEnter = true;
            this.rdoAmountAndIncomeOutstand.Location = new System.Drawing.Point(20, 124);
            this.rdoAmountAndIncomeOutstand.Name = "rdoAmountAndIncomeOutstand";
            this.rdoAmountAndIncomeOutstand.Size = new System.Drawing.Size(180, 17);
            this.rdoAmountAndIncomeOutstand.TabIndex = 6;
            this.rdoAmountAndIncomeOutstand.Text = "Amount and Income Outstanding";
            this.rdoAmountAndIncomeOutstand.UseVisualStyleBackColor = true;
            // 
            // rdoDrawingAmountOutstand
            // 
            this.rdoDrawingAmountOutstand.AutoSize = true;
            this.rdoDrawingAmountOutstand.IsSendTabOnEnter = true;
            this.rdoDrawingAmountOutstand.Location = new System.Drawing.Point(20, 90);
            this.rdoDrawingAmountOutstand.Name = "rdoDrawingAmountOutstand";
            this.rdoDrawingAmountOutstand.Size = new System.Drawing.Size(163, 17);
            this.rdoDrawingAmountOutstand.TabIndex = 5;
            this.rdoDrawingAmountOutstand.Text = "Drawing Amount Outstanding";
            this.rdoDrawingAmountOutstand.UseVisualStyleBackColor = true;
            // 
            // rdoIncomeOustand
            // 
            this.rdoIncomeOustand.AutoSize = true;
            this.rdoIncomeOustand.Checked = true;
            this.rdoIncomeOustand.IsSendTabOnEnter = true;
            this.rdoIncomeOustand.Location = new System.Drawing.Point(19, 53);
            this.rdoIncomeOustand.Name = "rdoIncomeOustand";
            this.rdoIncomeOustand.Size = new System.Drawing.Size(120, 17);
            this.rdoIncomeOustand.TabIndex = 4;
            this.rdoIncomeOustand.TabStop = true;
            this.rdoIncomeOustand.Text = "Income Outstanding";
            this.rdoIncomeOustand.UseVisualStyleBackColor = true;
            // 
            // TLMVEW00037
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 165);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.rdoAmountAndIncomeOutstand);
            this.Controls.Add(this.rdoDrawingAmountOutstand);
            this.Controls.Add(this.rdoIncomeOustand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TLMVEW00037";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drawing Remittance Listing (By Amount Outstanding)";
            this.Load += new System.EventHandler(this.TLMVEW00037_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0009 rdoAmountAndIncomeOutstand;
        private Windows.CXClient.Controls.CXC0009 rdoDrawingAmountOutstand;
        private Windows.CXClient.Controls.CXC0009 rdoIncomeOustand;
    }
}