using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00003 : BaseDockingForm , IGLMVEW00003
    {
        #region Constructor
        public GLMVEW00003()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private IList<MNMDTO00010> ccoaDataSource;
        public IList<MNMDTO00010> CCOADataSource
        {
            get
            {
                if (ccoaDataSource == null)
                    ccoaDataSource = new List<MNMDTO00010>();
                return ccoaDataSource;
            }
            set { ccoaDataSource = value; }
        }

        #region Controller
        private IGLMCTL00003 _controller;
        public IGLMCTL00003 Controller
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

        #endregion

        #region "Methods"

        private void BindGridViewData()
        {
            this.gvYearlyBudgetEntry.AutoGenerateColumns = false;
            this.CCOADataSource = this.Controller.GetCCOA();
            this.gvYearlyBudgetEntry.DataSource = null;            
            this.gvYearlyBudgetEntry.DataSource = this.CCOADataSource;
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


        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, true, false, false, true);
            this.tsbCRUD.butDelete.Text = "DeleteAll";
            this.BindGridViewData();
            //this.gvYearlyBudgetEntry.ReadOnly = true;
            this.gvYearlyBudgetEntry.Columns["colBudgetFigure"].ReadOnly = true;
            this.gvYearlyBudgetEntry.Columns["colIsSelected"].ReadOnly = true;  //colSelect
        }
        #endregion

        private void tsbCRUD_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (tsbCRUD.butDelete.Text != "DeleteAll")
            {
                IList<MNMDTO00010> CheckedCCOADataList = this.CCOADataSource.Where<MNMDTO00010>(x => x.IsCheck == true).ToList();
                if (CheckedCCOADataList.Count.Equals(0))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30013);/* No Records are selected. */
                }
                else
                {
                    if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete?
                    {
                        this.Controller.UpdateYearlyBudgetEntry(true, CheckedCCOADataList);
                        this.BindGridViewData();
                    }                   
                }
            }            
            else
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete? (All records)
                {
                    this.Controller.DeleteYearlyBudgetEntry();
                    this.BindGridViewData();
                }
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.EditedDataList == null || this.Controller.EditedDataList.Count == 0) return;
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);  //New, Edit , Save , Delete , Cancel , Print , Exit
            if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
            {
                this.Controller.UpdateYearlyBudgetEntry(false, null);
                this.BindGridViewData();
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }    

        private void gvYearlyBudgetEntry_CurrentCellDirtyStateChanged(object sender, EventArgs e) //cooperate with CellValueChanged
        {
            if (gvYearlyBudgetEntry.IsCurrentCellDirty)
            {
                gvYearlyBudgetEntry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gvYearlyBudgetEntry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && (e.ColumnIndex > -1 && e.ColumnIndex >= 4))
            {
                MNMDTO00010 editeddto = (MNMDTO00010)gvYearlyBudgetEntry.Rows[e.RowIndex].DataBoundItem; // want to get only cellvaluechanged obj in objList(gv)  
                editeddto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                this.Controller.GetEditedCCOAList(editeddto);
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
        //    this.gvYearlyBudgetEntry.ReadOnly = true;
        //    this.tsbCRUD.ButtonEnableDisabled(false, true, true, false, false, false, true);
            this.InitializeControls();          
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            
            this.gvYearlyBudgetEntry.Columns["colBudgetFigure"].ReadOnly = false;
            this.gvYearlyBudgetEntry.Columns["colIsSelected"].ReadOnly = false;   //colSelect
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.tsbCRUD.butDelete.Text = "Delete";
            this.gvYearlyBudgetEntry.Focus();
        }

        private void gvYearlyBudgetEntry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvYearlyBudgetEntry.CurrentCell.OwningColumn.Name.Equals("colBudgetFigure"))
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress -= new KeyPressEventHandler(colBudgetFigure_KeyPress);
                    textBox.KeyPress += new KeyPressEventHandler(colBudgetFigure_KeyPress);
                }
            }
        }

        private void colBudgetFigure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void gvYearlyBudgetEntry_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvYearlyBudgetEntry.CurrentCell.OwningColumn.Name.Equals("colBudgetFigure"))
            {
                if (gvYearlyBudgetEntry.CurrentCell.EditedFormattedValue.ToString().Trim().Equals(String.Empty))
                {
                    gvYearlyBudgetEntry.CurrentCell.Value = "0.00";
                }
                else
                {
                    if(!gvYearlyBudgetEntry.CurrentCell.Value.ToString().Contains(".00"))
                        gvYearlyBudgetEntry.CurrentCell.Value = gvYearlyBudgetEntry.CurrentCell.Value.ToString() + ".00";
                }
            }
        }
    }
}
