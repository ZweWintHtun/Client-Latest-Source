namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00021
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00021));
            this.label1 = new System.Windows.Forms.Label();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromLineNo = new System.Windows.Forms.TextBox();
            this.txtToLineNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Line No.";
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(501, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Line No.";
            // 
            // txtFromLineNo
            // 
            this.txtFromLineNo.Location = new System.Drawing.Point(173, 48);
            this.txtFromLineNo.Name = "txtFromLineNo";
            this.txtFromLineNo.Size = new System.Drawing.Size(63, 20);
            this.txtFromLineNo.TabIndex = 1;
            this.txtFromLineNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFromLineNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineNo_KeyPress);
            // 
            // txtToLineNo
            // 
            this.txtToLineNo.Location = new System.Drawing.Point(173, 88);
            this.txtToLineNo.Name = "txtToLineNo";
            this.txtToLineNo.Size = new System.Drawing.Size(63, 20);
            this.txtToLineNo.TabIndex = 2;
            this.txtToLineNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtToLineNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineNo_KeyPress);
            // 
            // GLMVEW00021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 137);
            this.Controls.Add(this.txtToLineNo);
            this.Controls.Add(this.txtFromLineNo);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00021";
            this.Text = "GLMVEW00021";
            this.Load += new System.EventHandler(this.GLMVEW00021_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLMVEW00021_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromLineNo;
        private System.Windows.Forms.TextBox txtToLineNo;
    }
}