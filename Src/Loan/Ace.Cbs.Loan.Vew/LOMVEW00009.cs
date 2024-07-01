using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00009 : BaseDockingForm, ILOMVEW00009
    {
        #region Constructor 
        public LOMVEW00009()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties...

        private LOMDTO00007 _previousGjtDto;
        public LOMDTO00007 PreviousGJTDto
        {
            get
            {
                if (_previousGjtDto == null)
                    return new LOMDTO00007();
                return _previousGjtDto;
            }
            set { _previousGjtDto = value; }
        }

        public string Code
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        private LOMDTO00007 viewData;
        public LOMDTO00007 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00007();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }
        public string Status { get; set; }
       
        public IList<LOMDTO00007> GJTCodes { get; set; }

        private ILOMCTL00009 _controller;
        public ILOMCTL00009 Controller
        {
            get { return this._controller; }
            set
            {
                this._controller = value;
                this._controller.GJTCodeView = this;
            }
        }
        #endregion

        #region Implementation
        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializedControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializedControls();
        }
        #endregion

        #region Helper Methods

        private void InitializedControls()
        {
            this.txtCode.ResetText();
            this.txtDescription.ResetText();
            this.ControlSetting("GJT.Enable", true);
            this.Status = "Save";
        }

        private void gvGjtType_DataBind()
        {
            this.gvGjtType.AutoGenerateColumns = false;
            this.GJTCodes = this.Controller.SelectAll();
            this.gvGjtType.DataSource = GJTCodes;
            this.txtRowCount.Text = this.gvGjtType.RowCount.ToString();
        }

        private void changeControlByUserType(bool p)
        {
            this.txtCode.Enabled = p;
            this.txtDescription.Enabled = p;
        }  

        #endregion                

        #region Events
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
            this.Controller.ClearErrors();
            txtCode.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvGjtType.EndEdit();
            IList<LOMDTO00007> itemlist = this.GJTCodes.Where<LOMDTO00007>(x => x.IsCheck == true).ToList<LOMDTO00007>();
            if (itemlist.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(itemlist);
                    this.gvGjtType_DataBind();
                    txtCode.Focus();
                }
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //this.ViewData = new LOMDTO00007();
            //this.ViewData.Code = txtCode.Text;
            //this.ViewData.Description = txtDescription.Text;
            this.Controller.Save(this.ViewData);
            this.gvGjtType_DataBind();
           // this.txtCode.Focus();
        }

        private void LOMVEW00009_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvGjtType_DataBind();
            this.InitializedControls();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void gvGjtType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;
            DataGridViewRow gvRows = (DataGridViewRow)gvGjtType.Rows[e.RowIndex];
            DataGridViewCell cell = (DataGridViewCell)gvRows.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.changeControlByUserType(true);
                LOMDTO00007 GjtDto = (LOMDTO00007)gvGjtType.Rows[e.RowIndex].DataBoundItem;
                this.PreviousGJTDto = new LOMDTO00007();
                this.Code = this.PreviousGJTDto.Code = GjtDto.Code;
                this.Description = this.PreviousGJTDto.Description = GjtDto.Description;
                this.ViewData = GjtDto;
                this.Status = "Update";
            }
        }
        #endregion

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
