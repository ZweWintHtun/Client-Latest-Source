namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00019
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00019));
            this.txtLineNo = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.rdoLineNo = new System.Windows.Forms.RadioButton();
            this.rdoAccountNo = new System.Windows.Forms.RadioButton();
            this.rdoDepartment = new System.Windows.Forms.RadioButton();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.btnOK = new Ace.Windows.CXClient.Controls.CXC0007();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0006();
            this.SuspendLayout();
            // 
            // txtLineNo
            // 
            this.txtLineNo.Location = new System.Drawing.Point(188, 52);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(79, 20);
            this.txtLineNo.TabIndex = 0;
            this.txtLineNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineNo_KeyPress);
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(188, 130);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(155, 20);
            this.txtDepartment.TabIndex = 0;
            this.txtDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepartment_KeyPress);
            // 
            // rdoLineNo
            // 
            this.rdoLineNo.AutoSize = true;
            this.rdoLineNo.Location = new System.Drawing.Point(58, 53);
            this.rdoLineNo.Name = "rdoLineNo";
            this.rdoLineNo.Size = new System.Drawing.Size(62, 17);
            this.rdoLineNo.TabIndex = 0;
            this.rdoLineNo.TabStop = true;
            this.rdoLineNo.Text = "Line No";
            this.rdoLineNo.UseVisualStyleBackColor = true;
            this.rdoLineNo.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // rdoAccountNo
            // 
            this.rdoAccountNo.AutoSize = true;
            this.rdoAccountNo.Location = new System.Drawing.Point(58, 90);
            this.rdoAccountNo.Name = "rdoAccountNo";
            this.rdoAccountNo.Size = new System.Drawing.Size(82, 17);
            this.rdoAccountNo.TabIndex = 0;
            this.rdoAccountNo.TabStop = true;
            this.rdoAccountNo.Text = "Account No";
            this.rdoAccountNo.UseVisualStyleBackColor = true;
            this.rdoAccountNo.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // rdoDepartment
            // 
            this.rdoDepartment.AutoSize = true;
            this.rdoDepartment.Location = new System.Drawing.Point(58, 131);
            this.rdoDepartment.Name = "rdoDepartment";
            this.rdoDepartment.Size = new System.Drawing.Size(80, 17);
            this.rdoDepartment.TabIndex = 0;
            this.rdoDepartment.TabStop = true;
            this.rdoDepartment.Text = "Department";
            this.rdoDepartment.UseVisualStyleBackColor = true;
            this.rdoDepartment.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -3);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(493, 31);
            this.tsbCRUD.TabIndex = 2;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(188, 156);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(39, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(188, 90);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(135, 20);
            this.txtAccountNo.TabIndex = 109;
            this.txtAccountNo.TabStop = false;
            // 
            // GLMVEW00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 197);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.rdoDepartment);
            this.Controls.Add(this.rdoAccountNo);
            this.Controls.Add(this.rdoLineNo);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtLineNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00019";
            this.Text = "GLMVEW00019";
            this.Load += new System.EventHandler(this.GLMVEW00019_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLineNo;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.RadioButton rdoLineNo;
        private System.Windows.Forms.RadioButton rdoAccountNo;
        private System.Windows.Forms.RadioButton rdoDepartment;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0007 btnOK;
        private Windows.CXClient.Controls.CXC0006 txtAccountNo;
    }
}