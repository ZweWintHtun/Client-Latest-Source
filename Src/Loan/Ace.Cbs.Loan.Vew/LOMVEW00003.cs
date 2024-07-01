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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00003 : BaseDockingForm, ILOMVEW00003
    {
        #region Constructor
        public LOMVEW00003()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        LOMDTO00001 _previousCharacterCodeDto;
        public LOMDTO00001 PreviousCharacterCodeDto
        {
            get
            {
                if (_previousCharacterCodeDto == null)
                    return new LOMDTO00001();
                return _previousCharacterCodeDto;
            }
            set { _previousCharacterCodeDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string CharacterCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00001 viewData;
        public LOMDTO00001 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00001();

                this.viewData.Code = this.CharacterCode;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00001> CharacterCodes { get; set; }

        private ILOMCTL00003 controller;
        public ILOMCTL00003 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.CharacterCodeView = this;
            }
        }

        #endregion

        #region Method

        private void gvCharacterCode_DataBind()
        {
            gvCharacterCode.AutoGenerateColumns = false;
            this.CharacterCodes = this.controller.GetAll();
            this.gvCharacterCode.DataSource = this.CharacterCodes;
            this.txtRecordCount.Text = gvCharacterCode.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvCharacterCode_DataBind();
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

            this.Status = "Save";
            this.focus();

        }

        //public void ControlSetting(string name, bool isEnable)
        //{
        //    if (isEnable)
        //        this.Enabled(name);
        //    else
        //        this.DisableControls(name);
        //}

        public void focus()
        {
            this.txtCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            //  this.txtCode.Focus();
            //  txtCode.Enabled = true;
            //  this.txtDescription.Focus();
            this.gvCharacterCode_DataBind();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();

          //  this.txtCode.Focus();
            this.focus();

            this.gvCharacterCode.EndEdit();
            IList<LOMDTO00001> List = this.CharacterCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00001 dto in List)
            {
                dto.IsCheck = false;
            }
            //txtCode.Enabled = true;
        }

        private void gvCharacterCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void gvCharacterCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvCharacterCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00001 characterCode = (LOMDTO00001)gvCharacterCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousCharacterCodeDto = new LOMDTO00001();

                this.CharacterCode = this.PreviousCharacterCodeDto.Code = characterCode.Code;
                this.Description = this.PreviousCharacterCodeDto.Description = characterCode.Description;

                this.ViewData = characterCode;
                //txtCode.Enabled = false;
                //this.ControlSetting("OccupationCode.Disable", false);
                this.Status = "Update";
            }
        }

        private void LOMVEW00003_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvCharacterCode_DataBind();
            this.InitializeControls();

        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvCharacterCode.EndEdit();
            IList<LOMDTO00001> deleteList = this.CharacterCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
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


        #endregion

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            DateTime newdate;
            

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
