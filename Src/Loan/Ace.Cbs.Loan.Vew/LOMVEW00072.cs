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
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00072 : BaseDockingForm, ILOMVEW00072
    {
        #region Constructor
        public LOMVEW00072()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private LOMDTO00072 _previousCropTypeDto;
        public LOMDTO00072 PreviousCropTypeDto
        {
            get
            {
                if (_previousCropTypeDto == null)
                    return new LOMDTO00072();
                return _previousCropTypeDto;
            }
            set
            {
                _previousCropTypeDto = value;
            }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string CropCode
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

        private LOMDTO00072 viewData;
        public LOMDTO00072 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00072();

                this.viewData.CropCode = this.CropCode;
                this.viewData.Desp = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00072> CropTypeList { get; set; }

        private ILOMCTL00072 controller;
        public ILOMCTL00072 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.CropTypeEntryView = this;
            }
        }

        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method
        private void gvCropTypeList_DataBind()
        {
            this.gvCropTypeList.AutoGenerateColumns = false;
            this.CropTypeList = this.controller.GetAll();
            this.gvCropTypeList.DataSource = this.CropTypeList;
            this.txtRecordCount.Text = gvCropTypeList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvCropTypeList_DataBind();
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
        }

        #endregion

        private void LOMVEW00072_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvCropTypeList_DataBind();
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.focus();
            this.gvCropTypeList.EndEdit();
            IList<LOMDTO00072> List = this.CropTypeList.Where<LOMDTO00072>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00072 dto in List)
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
            this.Controller.Save(this.ViewData);
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvCropTypeList.EndEdit();
            IList<LOMDTO00072> deleteList = this.CropTypeList.Where<LOMDTO00072>(x => x.IsCheck == true).ToList();
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
            this.focus();
        }

        private void gvCropTypeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvCropTypeList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00072 cropTypeCode = (LOMDTO00072)gvCropTypeList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousCropTypeDto = new LOMDTO00072();
                this.CropCode = this.PreviousCropTypeDto.CropCode = cropTypeCode.CropCode;
                this.Description = this.PreviousCropTypeDto.Desp = cropTypeCode.Desp;

                this.ViewData = cropTypeCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }


        private void gvCropTypeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            catch { }
        }
    }
}
