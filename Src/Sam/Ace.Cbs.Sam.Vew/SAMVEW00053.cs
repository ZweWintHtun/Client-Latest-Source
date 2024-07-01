using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00053 : BaseDockingForm, ISAMVEW00053
    {
        /// <summary>
        /// Nationality Code Setup View
        /// </summary>
        /// 
        #region Constrator
        public SAMVEW00053()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        SAMDTO00053 _previousNationalityCodeDto;
        public SAMDTO00053 PreviousNationalityDto
        {
            get
            {
                if (_previousNationalityCodeDto == null)
                    return new SAMDTO00053();
                return _previousNationalityCodeDto;
            }
            set { _previousNationalityCodeDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string NationalityCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private SAMDTO00053 viewData;
        public SAMDTO00053 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new SAMDTO00053();

                this.viewData.Nationality_Code = this.NationalityCode;
                this.viewData.Description = this.Desp;
                //this.viewData.USERNO = this.USERNO;
                //this.viewData.DATE_TIME = this.DATE_TIME;
                //this.viewData.EDITDATE_TIME = this.EDITDATE_TIME;
                //this.viewData.EDITUSER = this.EDITUSER;
                //this.viewData.EDITTYPE = this.EDITTYPE;
                //this.viewData.DEFAULTS = this.DEFAULTS;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<SAMDTO00053> NationalityCodes { get; set; }

        private ISAMCTL00053 controller;
        public ISAMCTL00053 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.NationalityCodeView = this;
            }
        }

        #endregion

        #region Method

        private void dgvNationalityCode_DataBind()
        {
            gvNationalityCode.AutoGenerateColumns = false;
            this.NationalityCodes = this.controller.GetAll();
            this.gvNationalityCode.DataSource = this.NationalityCodes;
            this.txtRecordCount.Text = gvNationalityCode.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgvNationalityCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            //this.ControlSetting("OccupationCode.Enable", true);
            this.Status = "Save";
        }

        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        public void focus()
        {
            this.txtCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
           // this.txtCode.Focus();
           // this.focus();
            this.dgvNationalityCode_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvNationalityCode.EndEdit();
            IList<SAMDTO00053> List = this.NationalityCodes.Where<SAMDTO00053>(x => x.IsCheck == true).ToList();
            foreach (SAMDTO00053 dto in List)
            {
                dto.IsCheck = false;
            }
            this.txtCode.Focus();
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvNationalityCode.EndEdit();
            IList<SAMDTO00053> deleteList = this.NationalityCodes.Where<SAMDTO00053>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.txtCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00053_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgvNationalityCode_DataBind();
            this.InitializeControls();
        }

        private void gvNationalityCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvNationalityCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                SAMDTO00053 nationalityCode = (SAMDTO00053)gvNationalityCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousNationalityDto = new SAMDTO00053();

                this.NationalityCode = this.PreviousNationalityDto.Nationality_Code = nationalityCode.Nationality_Code;
                this.Desp = this.PreviousNationalityDto.Description = nationalityCode.Description;

                this.ViewData = nationalityCode;
                //this.ControlSetting("OccupationCode.Disable", false);
                this.Status = "Update";
            }
        }

        private void gvNationalityCodeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void SAMVEW00053_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }


        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        #endregion
    }
}
