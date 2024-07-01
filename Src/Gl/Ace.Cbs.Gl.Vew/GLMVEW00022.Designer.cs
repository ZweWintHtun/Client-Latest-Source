namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00022));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.lblAccountNo = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblEngDescription = new Ace.Windows.CXClient.Controls.CXC0003();
            this.txtAccountNo = new Ace.Windows.CXClient.Controls.CXC0001();
            this.txtEnglishDescription = new Ace.Windows.CXClient.Controls.CXC0001();
            this.butAdd = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butMultiply = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butSubstract = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butDivide = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butComma = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butDot = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butLeft = new Ace.Windows.CXClient.Controls.CXC0007();
            this.butRight = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but0 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but9 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but1 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but2 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but3 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but4 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but5 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but6 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but7 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.but8 = new Ace.Windows.CXClient.Controls.CXC0007();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFormula = new Ace.Windows.CXClient.Controls.CXC0001();
            this.lblFormula = new Ace.Windows.CXClient.Controls.CXC0003();
            this.butCheckFormula = new Ace.Windows.CXClient.Controls.CXC0007();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-2, -1);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(489, 31);
            this.tsbCRUD.TabIndex = 3;
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            this.tsbCRUD.Load += new System.EventHandler(this.GLMVEW00022_Load);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(12, 39);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(70, 13);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No :";
            // 
            // lblEngDescription
            // 
            this.lblEngDescription.AutoSize = true;
            this.lblEngDescription.Location = new System.Drawing.Point(12, 64);
            this.lblEngDescription.Name = "lblEngDescription";
            this.lblEngDescription.Size = new System.Drawing.Size(109, 13);
            this.lblEngDescription.TabIndex = 0;
            this.lblEngDescription.Text = "Description (English) :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.IsSendTabOnEnter = true;
            this.txtAccountNo.Location = new System.Drawing.Point(136, 35);
            this.txtAccountNo.MaxLength = 20;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(115, 20);
            this.txtAccountNo.TabIndex = 0;
            // 
            // txtEnglishDescription
            // 
            this.txtEnglishDescription.IsSendTabOnEnter = true;
            this.txtEnglishDescription.Location = new System.Drawing.Point(136, 61);
            this.txtEnglishDescription.MaxLength = 20;
            this.txtEnglishDescription.Name = "txtEnglishDescription";
            this.txtEnglishDescription.ReadOnly = true;
            this.txtEnglishDescription.Size = new System.Drawing.Size(162, 20);
            this.txtEnglishDescription.TabIndex = 0;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(12, 12);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(30, 25);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "+";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butMultiply
            // 
            this.butMultiply.Location = new System.Drawing.Point(82, 12);
            this.butMultiply.Name = "butMultiply";
            this.butMultiply.Size = new System.Drawing.Size(30, 25);
            this.butMultiply.TabIndex = 0;
            this.butMultiply.Text = "*";
            this.butMultiply.UseVisualStyleBackColor = true;
            this.butMultiply.Click += new System.EventHandler(this.butMultiply_Click);
            // 
            // butSubstract
            // 
            this.butSubstract.Location = new System.Drawing.Point(46, 12);
            this.butSubstract.Name = "butSubstract";
            this.butSubstract.Size = new System.Drawing.Size(30, 25);
            this.butSubstract.TabIndex = 0;
            this.butSubstract.Text = "-";
            this.butSubstract.UseVisualStyleBackColor = true;
            this.butSubstract.Click += new System.EventHandler(this.butSubstract_Click);
            // 
            // butDivide
            // 
            this.butDivide.Location = new System.Drawing.Point(118, 12);
            this.butDivide.Name = "butDivide";
            this.butDivide.Size = new System.Drawing.Size(30, 25);
            this.butDivide.TabIndex = 0;
            this.butDivide.Text = "/";
            this.butDivide.UseVisualStyleBackColor = true;
            this.butDivide.Click += new System.EventHandler(this.butDivide_Click);
            // 
            // butComma
            // 
            this.butComma.Location = new System.Drawing.Point(154, 12);
            this.butComma.Name = "butComma";
            this.butComma.Size = new System.Drawing.Size(30, 25);
            this.butComma.TabIndex = 0;
            this.butComma.Text = ",";
            this.butComma.UseVisualStyleBackColor = true;
            this.butComma.Click += new System.EventHandler(this.butComma_Click);
            // 
            // butDot
            // 
            this.butDot.Location = new System.Drawing.Point(190, 12);
            this.butDot.Name = "butDot";
            this.butDot.Size = new System.Drawing.Size(30, 25);
            this.butDot.TabIndex = 0;
            this.butDot.Text = ".";
            this.butDot.UseVisualStyleBackColor = true;
            this.butDot.Click += new System.EventHandler(this.butDot_Click);
            // 
            // butLeft
            // 
            this.butLeft.Location = new System.Drawing.Point(226, 12);
            this.butLeft.Name = "butLeft";
            this.butLeft.Size = new System.Drawing.Size(30, 25);
            this.butLeft.TabIndex = 0;
            this.butLeft.Text = "{";
            this.butLeft.UseVisualStyleBackColor = true;
            this.butLeft.Click += new System.EventHandler(this.butLeft_Click);
            // 
            // butRight
            // 
            this.butRight.Location = new System.Drawing.Point(262, 12);
            this.butRight.Name = "butRight";
            this.butRight.Size = new System.Drawing.Size(30, 25);
            this.butRight.TabIndex = 0;
            this.butRight.Text = "}";
            this.butRight.UseVisualStyleBackColor = true;
            this.butRight.Click += new System.EventHandler(this.butRight_Click);
            // 
            // but0
            // 
            this.but0.Location = new System.Drawing.Point(12, 43);
            this.but0.Name = "but0";
            this.but0.Size = new System.Drawing.Size(30, 25);
            this.but0.TabIndex = 0;
            this.but0.Text = "0";
            this.but0.UseVisualStyleBackColor = true;
            this.but0.Click += new System.EventHandler(this.but0_Click);
            // 
            // but9
            // 
            this.but9.Location = new System.Drawing.Point(332, 43);
            this.but9.Name = "but9";
            this.but9.Size = new System.Drawing.Size(30, 25);
            this.but9.TabIndex = 0;
            this.but9.Text = "9";
            this.but9.UseVisualStyleBackColor = true;
            this.but9.Click += new System.EventHandler(this.but9_Click);
            // 
            // but1
            // 
            this.but1.Location = new System.Drawing.Point(46, 43);
            this.but1.Name = "but1";
            this.but1.Size = new System.Drawing.Size(30, 25);
            this.but1.TabIndex = 0;
            this.but1.Text = "1";
            this.but1.UseVisualStyleBackColor = true;
            this.but1.Click += new System.EventHandler(this.but1_Click);
            // 
            // but2
            // 
            this.but2.Location = new System.Drawing.Point(80, 43);
            this.but2.Name = "but2";
            this.but2.Size = new System.Drawing.Size(30, 25);
            this.but2.TabIndex = 0;
            this.but2.Text = "2";
            this.but2.UseVisualStyleBackColor = true;
            this.but2.Click += new System.EventHandler(this.but2_Click);
            // 
            // but3
            // 
            this.but3.Location = new System.Drawing.Point(116, 43);
            this.but3.Name = "but3";
            this.but3.Size = new System.Drawing.Size(30, 25);
            this.but3.TabIndex = 0;
            this.but3.Text = "3";
            this.but3.UseVisualStyleBackColor = true;
            this.but3.Click += new System.EventHandler(this.but3_Click);
            // 
            // but4
            // 
            this.but4.Location = new System.Drawing.Point(152, 43);
            this.but4.Name = "but4";
            this.but4.Size = new System.Drawing.Size(30, 25);
            this.but4.TabIndex = 0;
            this.but4.Text = "4";
            this.but4.UseVisualStyleBackColor = true;
            this.but4.Click += new System.EventHandler(this.but4_Click);
            // 
            // but5
            // 
            this.but5.Location = new System.Drawing.Point(188, 43);
            this.but5.Name = "but5";
            this.but5.Size = new System.Drawing.Size(30, 25);
            this.but5.TabIndex = 0;
            this.but5.Text = "5";
            this.but5.UseVisualStyleBackColor = true;
            this.but5.Click += new System.EventHandler(this.but5_Click);
            // 
            // but6
            // 
            this.but6.Location = new System.Drawing.Point(224, 43);
            this.but6.Name = "but6";
            this.but6.Size = new System.Drawing.Size(30, 25);
            this.but6.TabIndex = 0;
            this.but6.Text = "6";
            this.but6.UseVisualStyleBackColor = true;
            this.but6.Click += new System.EventHandler(this.but6_Click);
            // 
            // but7
            // 
            this.but7.Location = new System.Drawing.Point(260, 43);
            this.but7.Name = "but7";
            this.but7.Size = new System.Drawing.Size(30, 25);
            this.but7.TabIndex = 0;
            this.but7.Text = "7";
            this.but7.UseVisualStyleBackColor = true;
            this.but7.Click += new System.EventHandler(this.but7_Click);
            // 
            // but8
            // 
            this.but8.Location = new System.Drawing.Point(296, 43);
            this.but8.Name = "but8";
            this.but8.Size = new System.Drawing.Size(30, 25);
            this.but8.TabIndex = 0;
            this.but8.Text = "8";
            this.but8.UseVisualStyleBackColor = true;
            this.but8.Click += new System.EventHandler(this.but8_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butAdd);
            this.panel1.Controls.Add(this.but8);
            this.panel1.Controls.Add(this.butSubstract);
            this.panel1.Controls.Add(this.but7);
            this.panel1.Controls.Add(this.butMultiply);
            this.panel1.Controls.Add(this.but6);
            this.panel1.Controls.Add(this.butDivide);
            this.panel1.Controls.Add(this.but5);
            this.panel1.Controls.Add(this.butComma);
            this.panel1.Controls.Add(this.but4);
            this.panel1.Controls.Add(this.butDot);
            this.panel1.Controls.Add(this.but3);
            this.panel1.Controls.Add(this.butLeft);
            this.panel1.Controls.Add(this.but2);
            this.panel1.Controls.Add(this.butRight);
            this.panel1.Controls.Add(this.but1);
            this.panel1.Controls.Add(this.but0);
            this.panel1.Controls.Add(this.but9);
            this.panel1.Location = new System.Drawing.Point(15, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 78);
            this.panel1.TabIndex = 1;
            // 
            // txtFormula
            // 
            this.txtFormula.BackColor = System.Drawing.SystemColors.Window;
            this.txtFormula.IsSendTabOnEnter = true;
            this.txtFormula.Location = new System.Drawing.Point(12, 194);
            this.txtFormula.MaxLength = 20;
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(371, 101);
            this.txtFormula.TabIndex = 0;
            this.txtFormula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormula_KeyPress);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(12, 168);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(50, 13);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "Formula :";
            // 
            // butCheckFormula
            // 
            this.butCheckFormula.Location = new System.Drawing.Point(12, 301);
            this.butCheckFormula.Name = "butCheckFormula";
            this.butCheckFormula.Size = new System.Drawing.Size(94, 25);
            this.butCheckFormula.TabIndex = 2;
            this.butCheckFormula.Text = "CheckFormula";
            this.butCheckFormula.UseVisualStyleBackColor = true;
            this.butCheckFormula.Click += new System.EventHandler(this.butCheckFormula_Click);
            // 
            // GLMVEW00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 360);
            this.Controls.Add(this.butCheckFormula);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtEnglishDescription);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.lblEngDescription);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00022";
            this.Text = "Formula Edition";
            this.Load += new System.EventHandler(this.GLMVEW00022_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0003 lblAccountNo;
        private Windows.CXClient.Controls.CXC0003 lblEngDescription;
        private Windows.CXClient.Controls.CXC0001 txtAccountNo;
        private Windows.CXClient.Controls.CXC0001 txtEnglishDescription;
        private Windows.CXClient.Controls.CXC0007 butAdd;
        private Windows.CXClient.Controls.CXC0007 butMultiply;
        private Windows.CXClient.Controls.CXC0007 butSubstract;
        private Windows.CXClient.Controls.CXC0007 butDivide;
        private Windows.CXClient.Controls.CXC0007 butComma;
        private Windows.CXClient.Controls.CXC0007 butDot;
        private Windows.CXClient.Controls.CXC0007 butLeft;
        private Windows.CXClient.Controls.CXC0007 butRight;
        private Windows.CXClient.Controls.CXC0007 but0;
        private Windows.CXClient.Controls.CXC0007 but9;
        private Windows.CXClient.Controls.CXC0007 but1;
        private Windows.CXClient.Controls.CXC0007 but2;
        private Windows.CXClient.Controls.CXC0007 but3;
        private Windows.CXClient.Controls.CXC0007 but4;
        private Windows.CXClient.Controls.CXC0007 but5;
        private Windows.CXClient.Controls.CXC0007 but6;
        private Windows.CXClient.Controls.CXC0007 but7;
        private Windows.CXClient.Controls.CXC0007 but8;
        private System.Windows.Forms.Panel panel1;
        private Windows.CXClient.Controls.CXC0001 txtFormula;
        private Windows.CXClient.Controls.CXC0003 lblFormula;
        private Windows.CXClient.Controls.CXC0007 butCheckFormula;
    }
}