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
    public partial class LOMVEW00004 : BaseDockingForm ,ILOMVEW00004
    {
        #region Constructor
        public LOMVEW00004()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        LOMDTO00001 _previousGoodWillCodeDto;
        public LOMDTO00001 PreviousGoodWillDto
        {
            get
            {
                if (_previousGoodWillCodeDto == null)
                    return new LOMDTO00001();
                return _previousGoodWillCodeDto;
            }
            set { _previousGoodWillCodeDto = value; }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string GoodWillCode
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

                this.viewData.Code = this.GoodWillCode;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00001> GoodWillCodes { get; set; }

        private ILOMCTL00004 controller;
        public ILOMCTL00004 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.GoodWillView = this;
            }
        }
        #endregion

        #region Methods
        public void gvGoodWillCode_DataBind()
        {
            this.gvGoodWillCode.AutoGenerateColumns = false;
            this.GoodWillCodes = this.Controller.SelectAll();
            this.gvGoodWillCode.DataSource = this.GoodWillCodes;
            this.txtRecordCount.Text = gvGoodWillCode.RowCount.ToString();
        }

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtCode.Focus();
            this.Status = "Save";
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvGoodWillCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        #region Events

        private void LOMVEW00004_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvGoodWillCode_DataBind();
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();

            this.txtCode.Focus();           
            this.gvGoodWillCode.EndEdit();
            IList<LOMDTO00001> List = this.GoodWillCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00001 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.gvGoodWillCode_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvGoodWillCode.EndEdit();
            IList<LOMDTO00001> deleteList = this.GoodWillCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
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
        }

        private void gvGoodWillCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }            
        }

        private void gvGoodWillCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvGoodWillCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00001 GoodWillCodeInfo = (LOMDTO00001)gvGoodWillCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousGoodWillDto = new LOMDTO00001();

                this.GoodWillCode = this.PreviousGoodWillDto.Code = GoodWillCodeInfo.Code;
                this.Description = this.PreviousGoodWillDto.Description = GoodWillCodeInfo.Description;

                this.ViewData = GoodWillCodeInfo;
                this.Status = "Update";
            }
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
        }
    }
}
