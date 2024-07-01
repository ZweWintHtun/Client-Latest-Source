using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00076 : BaseDockingForm, ILOMVEW00076
    {
        public LOMVEW00076()
        {
            InitializeComponent();
        }

        #region Properties

        public string LSBusinessCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        private string _status;
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        private LOMDTO00076 _previousLSBusinesDto;
        public LOMDTO00076 PreviousLSBusinessDto
        {
            get
            {
                if (_previousLSBusinesDto == null)
                    return new LOMDTO00076();
                else
                    return _previousLSBusinesDto;
            }

            set { this._previousLSBusinesDto = value; }
        }

        private LOMDTO00076 viewData;
        public LOMDTO00076 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00076();

                this.viewData.Code = this.LSBusinessCode;
                this.viewData.Description = this.Description;
                this.viewData.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                this.viewData.Date_Time = DateTime.Now;

                return this.viewData;
            }
            set
            {
                this.viewData = value;
            }
        }

        public IList<LOMDTO00076> LSBusinessCodes { get; set; }

        private ILOMCTL00076 _controller;
        public ILOMCTL00076 Controller
        {
            get { return this._controller; }
            set { this._controller = value; _controller.LSBusinessCodeView = this; }
        }

        #endregion

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }

        #region Events

        private void LOMVEW0076_Load(object sender, EventArgs e)
        {
            try
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
                this.gvLSBusinessType_DataBind();
                InitializeControls();
            }
            catch { }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.gvLsBusinessType.EndEdit();
            IList<LOMDTO00076> List = this.LSBusinessCodes.Where<LOMDTO00076>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00076 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.Controller.Save(this.ViewData);
                this.gvLSBusinessType_DataBind();
            }
            catch { }
        }
        #endregion

        #region Methods

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.Status = "Save";
        }

        private void gvLSBusinessType_DataBind()
        {
            gvLsBusinessType.AutoGenerateColumns = false;
            this.LSBusinessCodes = this.Controller.GetAll();
            this.gvLsBusinessType.DataSource = this.LSBusinessCodes;
            this.gvLsBusinessType.Refresh();
            this.txtRecordCount.Text = this.Controller.GetAll().Count.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvLSBusinessType_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }
        #endregion

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvLsBusinessType.EndEdit();
            IList<LOMDTO00076> testingLst = this.LSBusinessCodes;
            IList<LOMDTO00076> deleteList = this.LSBusinessCodes.Where<LOMDTO00076>(x => x.IsCheck == true).ToList();

            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.txtCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.txtCode.Focus();


        }

        private void gvLsBusinessType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvLsBusinessType.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00076 lsBusiessCode = (LOMDTO00076)gvLsBusinessType.Rows[e.RowIndex].DataBoundItem;

                this.PreviousLSBusinessDto = new LOMDTO00076();
                this.LSBusinessCode = this.PreviousLSBusinessDto.Code = lsBusiessCode.Code;
                this.Description = this.PreviousLSBusinessDto.Description = lsBusiessCode.Description;
                this.ViewData = lsBusiessCode;
                this.Status = "Update";
            }
        }

        private void gvLsBusinessType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }
    }
}
