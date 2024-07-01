namespace Ace.Cbs.Gl.Vew
{
    partial class GLMVEW00003
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMVEW00003));
            this.tsbCRUD = new Ace.Windows.CXClient.Controls.CXCLIC001();
            this.gvYearlyBudgetEntry = new Ace.Windows.CXClient.Controls.AceGridView();
            this.colIsSelected = new Ace.Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn();
            this.colACCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBudgetFigure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvYearlyBudgetEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbCRUD
            // 
            this.tsbCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCRUD.BackColor = System.Drawing.Color.PowderBlue;
            this.tsbCRUD.Location = new System.Drawing.Point(0, -2);
            this.tsbCRUD.Name = "tsbCRUD";
            this.tsbCRUD.PrintButtonCauseValidation = true;
            this.tsbCRUD.Size = new System.Drawing.Size(763, 31);
            this.tsbCRUD.TabIndex = 27;
            this.tsbCRUD.EditButtonClick += new System.EventHandler(this.tsbCRUD_EditButtonClick);
            this.tsbCRUD.SaveButtonClick += new System.EventHandler(this.tsbCRUD_SaveButtonClick);
            this.tsbCRUD.DeleteButtonClick += new System.EventHandler(this.tsbCRUD_DeleteButtonClick);
            this.tsbCRUD.CancelButtonClick += new System.EventHandler(this.tsbCRUD_CancelButtonClick);
            this.tsbCRUD.ExitButtonClick += new System.EventHandler(this.tsbCRUD_ExitButtonClick);
            this.tsbCRUD.Load += new System.EventHandler(this.tsbCRUD_Load);
            // 
            // gvYearlyBudgetEntry
            // 
            this.gvYearlyBudgetEntry.AllowUserToAddRows = false;
            this.gvYearlyBudgetEntry.AllowUserToDeleteRows = false;
            this.gvYearlyBudgetEntry.CausesValidation = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gvYearlyBudgetEntry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvYearlyBudgetEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvYearlyBudgetEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colACCode,
            this.colDeptCode,
            this.colDescription,
            this.colCurrency,
            this.colBudgetFigure});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvYearlyBudgetEntry.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvYearlyBudgetEntry.EnableHeadersVisualStyles = false;
            this.gvYearlyBudgetEntry.IdTSList = null;
            this.gvYearlyBudgetEntry.IsEscapeKey = false;
            this.gvYearlyBudgetEntry.IsHeaderClick = false;
            this.gvYearlyBudgetEntry.Location = new System.Drawing.Point(12, 35);
            this.gvYearlyBudgetEntry.Name = "gvYearlyBudgetEntry";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvYearlyBudgetEntry.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvYearlyBudgetEntry.RowHeadersWidth = 25;
            this.gvYearlyBudgetEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvYearlyBudgetEntry.ShowSerialNo = false;
            this.gvYearlyBudgetEntry.Size = new System.Drawing.Size(585, 593);
            this.gvYearlyBudgetEntry.TabIndex = 28;
            this.gvYearlyBudgetEntry.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvYearlyBudgetEntry_CellValidating);
            this.gvYearlyBudgetEntry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvYearlyBudgetEntry_CellValueChanged);
            this.gvYearlyBudgetEntry.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvYearlyBudgetEntry_CurrentCellDirtyStateChanged);
            this.gvYearlyBudgetEntry.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvYearlyBudgetEntry_EditingControlShowing);
            // 
            // colIsSelected
            // 
            this.colIsSelected.CheckBoxHeader = false;
            this.colIsSelected.DataPropertyName = "IsCheck";
            this.colIsSelected.HeaderText = "";
            this.colIsSelected.Id = 0;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsSelected.TS = null;
            this.colIsSelected.Width = 30;
            // 
            // colACCode
            // 
            this.colACCode.DataPropertyName = "ACODE";
            this.colACCode.HeaderText = "A/C Code";
            this.colACCode.Name = "colACCode";
            this.colACCode.ReadOnly = true;
            // 
            // colDeptCode
            // 
            this.colDeptCode.DataPropertyName = "DCODE";
            this.colDeptCode.HeaderText = "Dept Code";
            this.colDeptCode.Name = "colDeptCode";
            this.colDeptCode.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "ACNAME";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colCurrency
            // 
            this.colCurrency.DataPropertyName = "CUR";
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            // 
            // colBudgetFigure
            // 
            this.colBudgetFigure.DataPropertyName = "BF";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colBudgetFigure.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBudgetFigure.HeaderText = "Budget Figure";
            this.colBudgetFigure.Name = "colBudgetFigure";
            // 
            // GLMVEW00003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 640);
            this.Controls.Add(this.gvYearlyBudgetEntry);
            this.Controls.Add(this.tsbCRUD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GLMVEW00003";
            this.Text = "Yearly Budget Entry";
            ((System.ComponentModel.ISupportInitialize)(this.gvYearlyBudgetEntry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.CXClient.Controls.CXCLIC001 tsbCRUD;
        private Windows.CXClient.Controls.AceGridView gvYearlyBudgetEntry;
        private Windows.CXClient.Controls.AceDataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colACCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBudgetFigure;
    }
}