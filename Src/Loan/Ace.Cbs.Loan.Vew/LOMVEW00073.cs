using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00073 : BaseDockingForm, ILOMVEW00073
    {
        public LOMVEW00073()
        {
            InitializeComponent();
        }

        #region Properties
        private LOMDTO00073 _previousUMDto;
        public LOMDTO00073 PreviousUMDto
        {
            get
            {
                if (_previousUMDto == null)
                    return new LOMDTO00073();
                return _previousUMDto;
            }
            set
            {
                _previousUMDto = value;
            }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string UMCode
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

        private LOMDTO00073 viewData;
        public LOMDTO00073 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00073();

                this.viewData.UMCode = this.UMCode;
                this.viewData.UMDesp = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00073> UMList { get; set; }

        private ILOMCTL00073 controller;
        public ILOMCTL00073 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.UMEntryView = this;
            }
        }

        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method
        private void gvUMList_DataBind()
        {
            this.gvUMList.AutoGenerateColumns = false;
            this.UMList = this.controller.GetAll();
            this.gvUMList.DataSource = this.UMList;
            this.txtRecordCount.Text = gvUMList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvUMList_DataBind();
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

        private void LOMVEW00073_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvUMList_DataBind();
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.focus();
            this.gvUMList.EndEdit();
            IList<LOMDTO00073> List = this.UMList.Where<LOMDTO00073>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00073 dto in List)
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
            this.gvUMList.EndEdit();
            IList<LOMDTO00073> deleteList = this.UMList.Where<LOMDTO00073>(x => x.IsCheck == true).ToList();
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

        private void gvUMList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvUMList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00073 um = (LOMDTO00073)gvUMList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousUMDto = new LOMDTO00073();
                this.UMCode = this.PreviousUMDto.UMCode = um.UMCode;
                this.Description = this.PreviousUMDto.UMDesp = um.UMDesp;

                this.ViewData = um;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }


        private void gvUMList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
