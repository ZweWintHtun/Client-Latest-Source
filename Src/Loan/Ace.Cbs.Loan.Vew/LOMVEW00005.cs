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
    public partial class LOMVEW00005 : BaseDockingForm, ILOMVEW00005
    {
        #region Constructor
        public LOMVEW00005()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private ILOMCTL00005 _controller;
        public ILOMCTL00005 Controller
        {
            get { return this._controller; }
            set
            {
                this._controller = value;
                this._controller.LandView = this;
            }
        }

        private LOMDTO00001 _previousDto;
        public LOMDTO00001 PreviousLandDto
        {
            get
            {
                if (_previousDto == null)
                    return new LOMDTO00001();
                return _previousDto;
            }
            set { this._previousDto = value; }            
        }
        public IList<LOMDTO00001> Lands { get; set; }
        public string Status { get; set; }
        private LOMDTO00001 viewData;
        public LOMDTO00001 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00001();

                this.viewData.Code = this.lCode;
                this.viewData.Description = this.lDesp;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public string lCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string lDesp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
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

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        private void InitializeControls()
        {
            this.txtCode.ResetText();
            this.txtDescription.ResetText();
            this.ControlSetting("Land.Enable", true);
            this.Status = "Save";
        }

        private void gvLandCode_DataBind()
        {
            this.gvLandCode.AutoGenerateColumns = false;
            this.Lands = this.Controller.SelectAll();
            this.gvLandCode.DataSource = Lands;
            this.txtRowCount.Text = this.gvLandCode.RowCount.ToString();
        }

        private void changeControlByUserType(bool p)
        {
            this.txtCode.Enabled = p;
            this.txtDescription.Enabled = p;
        }

        #endregion

        #region Events

        private void tsbCURD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void tsbCURD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvLandCode.EndEdit();
            IList<LOMDTO00001> itemList = this.Lands.Where<LOMDTO00001>(x => x.IsCheck == true).ToList<LOMDTO00001>();
            if (itemList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(itemList);
                    this.gvLandCode_DataBind();
                    txtCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void tsbCURD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCURD_SaveButtonClick(object sender, EventArgs e)
        {           
            this.Controller.Save(this.ViewData);
            this.gvLandCode_DataBind();
          //  this.txtCode.Focus();
            txtCode.Enabled = true;
        }

        private void LOMVEW00005_FormLoad(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvLandCode_DataBind();
            this.InitializeControls();
        }

        private void gvLandCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;
            DataGridViewRow gvRows = (DataGridViewRow)gvLandCode.Rows[e.RowIndex];
            DataGridViewCell cell = (DataGridViewCell)gvRows.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.changeControlByUserType(true);
                LOMDTO00001 landDto = (LOMDTO00001)gvLandCode.Rows[e.RowIndex].DataBoundItem;
                this.PreviousLandDto = new LOMDTO00001();
                this.lCode = PreviousLandDto.Code = landDto.Code;
                this.lDesp = PreviousLandDto.Description = landDto.Description;
                this.ViewData = landDto;
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
