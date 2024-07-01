namespace Ace.Cbs.Mnm.Vew
{
    partial class MNMVEW00003
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00003));
            this.lblRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0003();
            this.lblRequiredYear = new Ace.Windows.CXClient.Controls.CXC0003();
            this.cboRequiredMonth = new Ace.Windows.CXClient.Controls.CXC0002();
            this.btnCalculate = new Ace.Windows.CXClient.Controls.CXC0007();
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.txtRequiredYear = new Ace.Windows.CXClient.Controls.CXC0004();
            this.pgbSavingInterest = new System.Windows.Forms.ProgressBar();
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.grpBeforeDayClose = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblRequiredMonth
            // 
            this.lblRequiredMonth.AutoSize = true;
            this.lblRequiredMonth.Location = new System.Drawing.Point(65, 64);
            this.lblRequiredMonth.Name = "lblRequiredMonth";
            this.lblRequiredMonth.Size = new System.Drawing.Size(89, 13);
            this.lblRequiredMonth.TabIndex = 0;
            this.lblRequiredMonth.Text = "Required Month :";
            // 
            // lblRequiredYear
            // 
            this.lblRequiredYear.AutoSize = true;
            this.lblRequiredYear.Location = new System.Drawing.Point(65, 96);
            this.lblRequiredYear.Name = "lblRequiredYear";
            this.lblRequiredYear.Size = new System.Drawing.Size(81, 13);
            this.lblRequiredYear.TabIndex = 0;
            this.lblRequiredYear.Text = "Required Year :";
            // 
            // cboRequiredMonth
            // 
            this.cboRequiredMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRequiredMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequiredMonth.DropDownHeight = 200;
            this.cboRequiredMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequiredMonth.FormattingEnabled = true;
            this.cboRequiredMonth.IntegralHeight = false;
            this.cboRequiredMonth.IsSendTabOnEnter = true;
            this.cboRequiredMonth.Location = new System.Drawing.Point(176, 60);
            this.cboRequiredMonth.Name = "cboRequiredMonth";
            this.cboRequiredMonth.Size = new System.Drawing.Size(90, 21);
            this.cboRequiredMonth.TabIndex = 1;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Image = global::Ace.Cbs.Mnm.Vew.Properties.Resources.Custom_Icon_Design_Pretty_Office_3_Process_Accept;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCalculate.Location = new System.Drawing.Point(176, 126);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(102, 40);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(-1, 0);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(509, 31);
            this.tsbCRUD.TabIndex = 4;
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            // 
            // txtRequiredYear
            // 
            this.txtRequiredYear.DecimalPlaces = 0;
            this.txtRequiredYear.IsSendTabOnEnter = true;
            this.txtRequiredYear.Location = new System.Drawing.Point(176, 93);
            this.txtRequiredYear.MaxLength = 4;
            this.txtRequiredYear.Name = "txtRequiredYear";
            this.txtRequiredYear.Size = new System.Drawing.Size(90, 20);
            this.txtRequiredYear.TabIndex = 2;
            this.txtRequiredYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRequiredYear.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pgbSavingInterest
            // 
            this.pgbSavingInterest.Location = new System.Drawing.Point(68, 181);
            this.pgbSavingInterest.MarqueeAnimationSpeed = 40;
            this.pgbSavingInterest.Name = "pgbSavingInterest";
            this.pgbSavingInterest.Size = new System.Drawing.Size(315, 24);
            this.pgbSavingInterest.TabIndex = 5;
            // 
            // tmrProgress
            // 
            this.tmrProgress.Interval = 30;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // grpBeforeDayClose
            // 
            this.grpBeforeDayClose.Location = new System.Drawing.Point(12, 37);
            this.grpBeforeDayClose.Name = "grpBeforeDayClose";
            this.grpBeforeDayClose.Size = new System.Drawing.Size(484, 185);
            this.grpBeforeDayClose.TabIndex = 11;
            this.grpBeforeDayClose.TabStop = false;
            this.grpBeforeDayClose.Text = "Saving Interest Calculation:";
            // 
            // MNMVEW00003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 234);
            this.Controls.Add(this.pgbSavingInterest);
            this.Controls.Add(this.txtRequiredYear);
            this.Controls.Add(this.tsbCRUD);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.cboRequiredMonth);
            this.Controls.Add(this.lblRequiredYear);
            this.Controls.Add(this.lblRequiredMonth);
            this.Controls.Add(this.grpBeforeDayClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MNMVEW00003";
            this.Text = "Saving Interest Calculation";
            this.Load += new System.EventHandler(this.MNMVEW00003_Load);
            this.Move += new System.EventHandler(this.MNMVEW00003_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.CXClient.Controls.CXC0003 lblRequiredMonth;
        private Windows.CXClient.Controls.CXC0003 lblRequiredYear;
        private Windows.CXClient.Controls.CXC0002 cboRequiredMonth;
        private Windows.CXClient.Controls.CXC0007 btnCalculate;
        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.CXC0004 txtRequiredYear;
        private System.Windows.Forms.ProgressBar pgbSavingInterest;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.GroupBox grpBeforeDayClose;
    }
}