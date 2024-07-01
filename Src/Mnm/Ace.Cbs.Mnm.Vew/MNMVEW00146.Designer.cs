namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00146
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00146));
            this.butYes = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butNo = new Ace.Windows.CXClient.Controls.CXC0007();
            this.lblEndDate = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00031 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cxC00032 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNumber1 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblNumber2 = new Ace.Windows.CXClient.Controls.CXC0003();
            this.SuspendLayout();
            // 
            // butYes
            // 
            this.butYes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butYes.Location = new System.Drawing.Point(77, 99);
            this.butYes.Name = "butYes";
            this.butYes.Size = new System.Drawing.Size(67, 28);
            this.butYes.TabIndex = 10004;
            this.butYes.Text = "Yes";
            this.butYes.UseVisualStyleBackColor = true;
            this.butYes.Click += new System.EventHandler(this.butYes_Click);
            // 
            // butNo
            // 
            this.butNo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butNo.Location = new System.Drawing.Point(153, 99);
            this.butNo.Name = "butNo";
            this.butNo.Size = new System.Drawing.Size(67, 28);
            this.butNo.TabIndex = 10005;
            this.butNo.Text = "No";
            this.butNo.UseVisualStyleBackColor = true;
            this.butNo.Click += new System.EventHandler(this.butNo_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(12, 21);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(116, 13);
            this.lblEndDate.TabIndex = 10006;
            this.lblEndDate.Text = "Are you sure to delete?";
            // 
            // cxC00031
            // 
            this.cxC00031.AutoSize = true;
            this.cxC00031.Location = new System.Drawing.Point(12, 58);
            this.cxC00031.Name = "cxC00031";
            this.cxC00031.Size = new System.Drawing.Size(56, 13);
            this.cxC00031.TabIndex = 10007;
            this.cxC00031.Text = "Group No.";
            // 
            // cxC00032
            // 
            this.cxC00032.AutoSize = true;
            this.cxC00032.Location = new System.Drawing.Point(150, 58);
            this.cxC00032.Name = "cxC00032";
            this.cxC00032.Size = new System.Drawing.Size(51, 13);
            this.cxC00032.TabIndex = 10008;
            this.cxC00032.Text = "Entry No.";
            // 
            // lblNumber1
            // 
            this.lblNumber1.AutoSize = true;
            this.lblNumber1.Location = new System.Drawing.Point(74, 58);
            this.lblNumber1.Name = "lblNumber1";
            this.lblNumber1.Size = new System.Drawing.Size(50, 13);
            this.lblNumber1.TabIndex = 10009;
            this.lblNumber1.Text = "Number1";
            // 
            // lblNumber2
            // 
            this.lblNumber2.AutoSize = true;
            this.lblNumber2.Location = new System.Drawing.Point(207, 58);
            this.lblNumber2.Name = "lblNumber2";
            this.lblNumber2.Size = new System.Drawing.Size(50, 13);
            this.lblNumber2.TabIndex = 10010;
            this.lblNumber2.Text = "Number2";
            // 
            // MNMVEW00146
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 147);
            this.Controls.Add(this.lblNumber2);
            this.Controls.Add(this.lblNumber1);
            this.Controls.Add(this.cxC00032);
            this.Controls.Add(this.cxC00031);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.butNo);
            this.Controls.Add(this.butYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00146";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking Information System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0007 butYes;
        private Windows.CXClient.Controls.CXC0007 butNo;
        private Windows.CXClient.Controls.CXC0003 lblEndDate;
        private Windows.CXClient.Controls.CXC0003 cxC00031;
        private Windows.CXClient.Controls.CXC0003 cxC00032;
        private Windows.CXClient.Controls.CXC0003 lblNumber1;
        private Windows.CXClient.Controls.CXC0003 lblNumber2;
    }
}