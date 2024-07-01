using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00004 : BaseDockingForm,IGLMVEW00004
    {
        public GLMVEW00004()
        {
            InitializeComponent();
        }

        #region Controller

        private IGLMCTL00004 _controller;
        public IGLMCTL00004 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }
        #endregion

        #region "Data Proterties"

        private IList<MNMDTO00010> ccoadto;
        public IList<MNMDTO00010> CCOADto
        {
            get { return ccoadto; }
            set { ccoadto = value; }
        }

        public bool IsHomeCurrency { get; set; }

        #endregion

        #region "Methods"

        private void BindGridViewData()
        {
            this.gvMonthlyBudgetedEntry.AutoGenerateColumns = false;
            this.gvMonthlyBudgetedEntry.DataSource = null;
            this.ccoadto = this.Controller.GetCCOA();
            this.gvMonthlyBudgetedEntry.DataSource = this.ccoadto;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void GridViewColumnReadOnly(bool status)
        {
            gvMonthlyBudgetedEntry.Columns["colJanuary"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colFebruary"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colMarch"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colApril"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colMay"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colJune"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colJuly"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colAugust"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colSeptember"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colOctober"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colNovember"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colDecember"].ReadOnly = status;
            gvMonthlyBudgetedEntry.Columns["colIsSelected"].ReadOnly = status;  //colCheck
        }

        public void InitializeControls()
        {
            this.tsbCRUD.butDelete.Text = "DeleteAll";
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, true, true, false, true);
            this.GridViewColumnReadOnly(true);
        }
        #endregion

        #region "Events"
        private void gvMonthlyBudgetedEntry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && (e.ColumnIndex > -1 && e.ColumnIndex >= 4))
            {
                MNMDTO00010 editeddto = (MNMDTO00010)gvMonthlyBudgetedEntry.Rows[e.RowIndex].DataBoundItem;
                editeddto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                this.Controller.GetEditedCCOAList(editeddto);
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.EditedCCOAList == null || this.Controller.EditedCCOAList.Count == 0) return;
            if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
            {
                this.Controller.UpdateMonthlyBudgetedEntry(false, null);
                this.BindGridViewData();
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (tsbCRUD.butDelete.Text != "DeleteAll")
            {
                IList<MNMDTO00010> CheckedCCOADataList = this.ccoadto.Where<MNMDTO00010>(x => x.IsCheck == true).ToList();
                if (CheckedCCOADataList.Count.Equals(0))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30013);/* No Records are selected. */
                }
                else
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete?
                    {
                        this.Controller.UpdateMonthlyBudgetedEntry(true, CheckedCCOADataList);
                        this.BindGridViewData();
                    }
                }
            }
            else
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete?
                {
                    this.Controller.DeleteAllMonthlyBudgetedEntry();
                    this.BindGridViewData();
                }
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.BindGridViewData();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GLMVEW00004_Load(object sender, EventArgs e)
        {
            if (this.FormName.Equals("isHomeCur"))
            {
                this.IsHomeCurrency = true;
                this.Text += "(Home Currency)";
            }
            else
                this.IsHomeCurrency = false;

            this.BindGridViewData();
            this.InitializeControls();
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            this.GridViewColumnReadOnly(false);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.tsbCRUD.butDelete.Text = "Delete";
            this.gvMonthlyBudgetedEntry.Focus();
        }

        /// <summary>
        /// This event handler manually raises the CellValueChanged event 
        /// by calling the CommitEdit method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMonthlyBudgetedEntry_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvMonthlyBudgetedEntry.IsCurrentCellDirty)
            {
                gvMonthlyBudgetedEntry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gvMonthlyBudgetedEntry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string cellName = gvMonthlyBudgetedEntry.CurrentCell.OwningColumn.Name;
            if (cellName.Equals("colJanuary") || cellName.Equals("colFebruary") || cellName.Equals("colMarch") || cellName.Equals("colApril") || cellName.Equals("colMay") || cellName.Equals("colJune") || cellName.Equals("colJuly") || cellName.Equals("colAugust") || cellName.Equals("colSeptember") || cellName.Equals("colOctober") || cellName.Equals("colNovember") || cellName.Equals("colDecember"))
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress -= new KeyPressEventHandler(_KeyPress);
                    textBox.KeyPress += new KeyPressEventHandler(_KeyPress);
                }
            }
        }

        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void gvMonthlyBudgetedEntry_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string cellName = gvMonthlyBudgetedEntry.CurrentCell.OwningColumn.Name;
            if (cellName.Equals("colJanuary") || cellName.Equals("colFebruary") || cellName.Equals("colMarch") || cellName.Equals("colApril") || cellName.Equals("colMay") || cellName.Equals("colJune") || cellName.Equals("colJuly") || cellName.Equals("colAugust") || cellName.Equals("colSeptember") || cellName.Equals("colOctober") || cellName.Equals("colNovember") || cellName.Equals("colDecember"))
            {
                if (gvMonthlyBudgetedEntry.CurrentCell.EditedFormattedValue.ToString().Trim().Equals(String.Empty))
                {
                    gvMonthlyBudgetedEntry.CurrentCell.Value = "0.00";
                }
                else
                {
                    if (!gvMonthlyBudgetedEntry.CurrentCell.Value.ToString().Contains(".00"))
                        gvMonthlyBudgetedEntry.CurrentCell.Value = gvMonthlyBudgetedEntry.CurrentCell.Value.ToString() + ".00";
                }
            }
        }
        #endregion
    }
}
