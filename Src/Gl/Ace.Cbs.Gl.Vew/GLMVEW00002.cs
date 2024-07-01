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
using Ace.Cbs.Mnm.Dmd ;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00002 :BaseDockingForm, IGLMVEW00002
    {
        #region Constructor
        public GLMVEW00002()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private IList<MNMDTO00010> ccoaDataSource;
        public IList<MNMDTO00010> DataSource
        {
            get
            {
                if (ccoaDataSource == null)
                    ccoaDataSource = new List<MNMDTO00010>();
                return ccoaDataSource;
            }
            set { ccoaDataSource = value; }
        }

        public decimal OutOfBalance
        {
            get { return Convert.ToDecimal(this.txtOutOfBalance.Value); }
            set { this.txtOutOfBalance.Text = Convert.ToString(value); }
        }

        #endregion

        #region Controller
        private IGLMCTL00002 _controller;
        public IGLMCTL00002 Controller
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

        #region "Methods"

        private void BindGridViewData()
        {
            this.gvOpeningBalanceEntry.AutoGenerateColumns = false;
            this.DataSource = this.Controller.GetCCOA();
            this.gvOpeningBalanceEntry.DataSource = null;
            //this.gvOpeningBalanceEntry.DataSource = this.Controller.GetCCOA();            
            this.gvOpeningBalanceEntry.DataSource = this.DataSource;
        }    

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
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
            this.gvOpeningBalanceEntry.ReadOnly = true;
        }
        #endregion

        #region Events
        private void GLMVEW00002_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            this.gvOpeningBalanceEntry.ReadOnly = false;            
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.tsbCRUD.butDelete.Text = "Delete";
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, true, true, false, true);  //New, Edit , Save , Delete , Cancel , Print , Exit

            if (this.OutOfBalance != 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV30031");     //"Out of balance should be zero."
                this.gvOpeningBalanceEntry.Focus();
                return;
            }

            if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
            { 
                this.Controller.UpdateOpeningBalanceEntry(false);  
                this.BindGridViewData();
                this.gvOpeningBalanceEntry.ReadOnly = true;
            }
        }

        private void gvOpeningBalanceEntry_CurrentCellDirtyStateChanged(object sender, EventArgs e)  //cooperate with CellValueChanged
        {
            if (gvOpeningBalanceEntry.IsCurrentCellDirty)
            {
                gvOpeningBalanceEntry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gvOpeningBalanceEntry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {         
            if (e.RowIndex > -1 && (e.ColumnIndex > -1 && e.ColumnIndex >= 4))
            {
                MNMDTO00010 editeddto = (MNMDTO00010)gvOpeningBalanceEntry.Rows[e.RowIndex].DataBoundItem; // want to get only cellvaluechanged obj in objList(gv)                
                this.Controller.GetEditedCCOAList(editeddto);                
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {           
            this.OutOfBalance = 0;
            //this.gvOpeningBalanceEntry.ReadOnly = true;
            //this.tsbCRUD.ButtonEnableDisabled(false, true, true, false, false, false, true);
            this.InitializeControls();
        }


        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (tsbCRUD.butDelete.Text == "DeleteAll")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes) //Are you sure you want to delete? (All records)
                {
                    this.Controller.DeleteOpeningBalanceEntry();
                }
            }
            else    // tsbCRUD.butDelete.Text == "Delete"
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC00003") == DialogResult.Yes) //Are you sure you want to delete? (All records)
                {
                    this.Controller.UpdateOpeningBalanceEntry(true);
                }
            }
            this.BindGridViewData();           
        }
        #endregion
    }   
}
