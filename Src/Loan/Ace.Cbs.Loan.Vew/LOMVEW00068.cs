using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00068 : BaseDockingForm, ILOMVEW00068
    {
        #region Constructor
        public LOMVEW00068()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private LOMDTO00068 _previousStockGroupDto;
        public LOMDTO00068 PreviousStockGroupDto
        {
            get
            {
                if (_previousStockGroupDto == null)
                    return new LOMDTO00068();
                return _previousStockGroupDto;
            }
            set
            {
                _previousStockGroupDto = value;
            }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string GroupCode
        {
            get { return this.txtStockGroupCode.Text; }
            set { this.txtStockGroupCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }

            set { this.txtDescription.Text = value; }
        }

        public string PreFix
        {
            get { return this.txtPrefixCode.Text; }

            set { this.txtPrefixCode.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00068 viewData;
        public LOMDTO00068 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00068();

                this.viewData.PreFix = this.PreFix;
                this.viewData.Description = this.Description;
                this.viewData.GroupCode = this.GroupCode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00068> StockGroupList { get; set; }

        private ILOMCTL00068 controller;
        public ILOMCTL00068 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.HirePurchaseStockGroupEntryView = this;
            }
        }

        public void focus()
        {
            this.txtStockGroupCode.Focus();
        }
        #endregion

        #region Method
        private void gvStockGroupList_DataBind()
        {
            gvStockGroupList.AutoGenerateColumns = false;
            this.StockGroupList = this.controller.GetAll();
            this.gvStockGroupList.DataSource = this.StockGroupList;
            this.txtRecordCount.Text = gvStockGroupList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvStockGroupList_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtStockGroupCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtPrefixCode.Text = string.Empty;

            this.Status = "Save";
        }

        #endregion

        private void LOMVEW00068_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvStockGroupList_DataBind();
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtStockGroupCode.Focus();
            this.focus();
            this.gvStockGroupList.EndEdit();
            IList<LOMDTO00068> List = this.StockGroupList.Where<LOMDTO00068>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00068 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvStockGroupList.EndEdit();
            IList<LOMDTO00068> deleteList = this.StockGroupList.Where<LOMDTO00068>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.txtStockGroupCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.focus();
        }

        private void gvStockGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvStockGroupList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00068 stockGroupCode = (LOMDTO00068)gvStockGroupList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousStockGroupDto = new LOMDTO00068();
                this.GroupCode = this.PreviousStockGroupDto.GroupCode = stockGroupCode.GroupCode;
                this.Description = this.PreviousStockGroupDto.Description = stockGroupCode.Description;
                this.PreFix = this.PreviousStockGroupDto.PreFix = stockGroupCode.PreFix;
                this.ViewData = stockGroupCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtStockGroupCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtPrefixCode.Enabled = isUpdateOnlyUser;
        }

        private void gvStockGroupList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
