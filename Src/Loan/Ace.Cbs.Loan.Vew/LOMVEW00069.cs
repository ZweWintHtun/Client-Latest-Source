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
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00069 : BaseDockingForm, ILOMVEW00069
    {
        #region Constructor
        public LOMVEW00069()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private LOMDTO00069 _previousStockItemDto;
        public LOMDTO00069 PreviousStockItemDto
        {
            get
            {
                if (_previousStockItemDto == null)
                    return new LOMDTO00069();
                return _previousStockItemDto;
            }
            set
            {
                _previousStockItemDto = value;
            }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string GroupCode
        {
            get
            {
                if (this.cboGroupCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboGroupCode.SelectedValue.ToString();
                }
            }
            set { this.cboGroupCode.SelectedValue = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }

            set { this.txtDescription.Text = value; }
        }

        public string SubCode
        {
            get { return this.txtSubCode.Text; }

            set { this.txtSubCode.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00069 viewData;
        public LOMDTO00069 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00069();

                this.viewData.SubCode = this.SubCode;
                this.viewData.Description = this.Description;
                this.viewData.GroupCode = this.GroupCode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00069> StockItemList { get; set; }

        private ILOMCTL00069 controller;
        public ILOMCTL00069 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.HirePurchaseStockSubItemCodeRegisterationView = this;
            }
        }

        public void focus()
        {
            this.cboGroupCode.Focus();
        }
        #endregion

        #region Method
        private void gvStockGroupList_DataBind()
        {
            this.gvStockItemList.AutoGenerateColumns = false;
            this.StockItemList = this.controller.GetAll();
            this.gvStockItemList.DataSource = this.StockItemList;
            this.txtRecordCount.Text = gvStockItemList.RowCount.ToString();
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
            this.BindStockGroup();
            this.cboGroupCode.SelectedIndex = -1;
            this.txtDescription.Text = string.Empty;
            this.txtSubCode.Text = string.Empty;

            this.Status = "Save";
        }

        public void BindStockGroup()
        {
            IList<LOMDTO00068> StockGroupList = CXCLE00002.Instance.GetListObject<LOMDTO00068>("LOMORM00068.SelectAllStockGroup", new object[] { true });
            this.cboGroupCode.ValueMember = "GroupCode";
            this.cboGroupCode.DisplayMember = "GroupCode";
            this.cboGroupCode.DataSource = StockGroupList;
            this.cboGroupCode.SelectedIndex = -1;
        }

        #endregion

        private void LOMVEW00069_Load(object sender, EventArgs e)
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
            this.cboGroupCode.Focus();
            this.focus();
            this.gvStockItemList.EndEdit();
            IList<LOMDTO00069> List = this.StockItemList.Where<LOMDTO00069>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00069 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvStockItemList.EndEdit();
            IList<LOMDTO00069> deleteList = this.StockItemList.Where<LOMDTO00069>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.cboGroupCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.focus();
        }

        private void gvStockItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvStockItemList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00069 stockItemCode = (LOMDTO00069)gvStockItemList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousStockItemDto = new LOMDTO00069();
                this.GroupCode = this.PreviousStockItemDto.GroupCode = stockItemCode.GroupCode;
                this.Description = this.PreviousStockItemDto.Description = stockItemCode.Description;
                this.SubCode = this.PreviousStockItemDto.SubCode = stockItemCode.SubCode;
                this.ViewData = stockItemCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboGroupCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtSubCode.Enabled = isUpdateOnlyUser;
        }

        private void gvStockItemList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
