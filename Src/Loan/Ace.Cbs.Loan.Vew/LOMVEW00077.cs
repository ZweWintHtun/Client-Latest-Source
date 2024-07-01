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
    public partial class LOMVEW00077 : BaseDockingForm, ILOMVEW00077
    {
        public LOMVEW00077()
        {
            InitializeComponent();
        }

        #region Properties
        private LOMDTO00077 _previousLSProductTypeItemDto;
        public LOMDTO00077 PreviousLSProductTypeItemDto
        {
            get
            {
                if (_previousLSProductTypeItemDto == null)
                    return new LOMDTO00077();
                return _previousLSProductTypeItemDto;
            }
            set
            {
                _previousLSProductTypeItemDto = value;
            }
        }

        public string Id
        {
            get { throw new NotImplementedException(); }
        }

        public string ProductCode
        {
            get
            {
                if (this.cboProductType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboProductType.SelectedValue.ToString();
                }
            }
            set { this.cboProductType.SelectedValue = value; }
        }

        public string LSBusinessCode
        {
            get
            {
                if (this.cboLSBusinessType.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboLSBusinessType.SelectedValue.ToString();
                }
            }
            set { this.cboLSBusinessType.SelectedValue = value; }
        }

        public string UMCode
        {
            get
            {
                if (this.cboUMCode.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboUMCode.SelectedValue.ToString();
                }
            }
            set { this.cboUMCode.SelectedValue = value; }
        }

        public int DurationMonths
        {
            
            get
            {
                int result = 0;
                Int32.TryParse(this.txtDurationMonths.Text, out result);
                return result;
            }
            set
            {
                this.txtDurationMonths.Text = Convert.ToString(value);
            }
        }

        public string Status { get; set; }

        private LOMDTO00077 viewData;
        public LOMDTO00077 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00077();

                this.viewData.ProductCode = this.ProductCode;
                this.viewData.LSBusinessCode = this.LSBusinessCode;
                this.viewData.UMCode = this.UMCode;
                this.viewData.DurationMonths = this.DurationMonths;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00077> LSProductTypeItemList { get; set; }

        private ILOMCTL00077 controller;
        public ILOMCTL00077 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.LSProductTypeItemSetupView = this;
            }
        }

        public void focus()
        {
            this.cboProductType.Focus();
        }
        #endregion

        #region Method
        private void gvLSProductTypeItemList_DataBind()
        {
            this.gvLSProductTypeItemList.AutoGenerateColumns = false;
            this.LSProductTypeItemList = this.controller.GetAll();
            this.gvLSProductTypeItemList.DataSource = this.LSProductTypeItemList;
            this.txtRecordCount.Text = gvLSProductTypeItemList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvLSProductTypeItemList_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.BindProductType();
            this.BindLSBusinessType();
            this.BindUM();
            this.cboProductType.SelectedIndex = -1;
            this.cboLSBusinessType.SelectedIndex = -1;
            this.cboUMCode.SelectedIndex = -1;
            this.txtDurationMonths.Text = string.Empty;

            this.Status = "Save";
        }

        public void BindProductType()
        {
            IList<LOMDTO00074> ProductTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00074>("LOMORM00074.SelectAllProductCode", new object[] { true });
            this.cboProductType.ValueMember = "Code";
            this.cboProductType.DisplayMember = "Description";
            this.cboProductType.DataSource = ProductTypeList;
            this.cboProductType.SelectedIndex = -1;
        }

        public void BindLSBusinessType()
        {
            IList<LOMDTO00076> LSBusinessTypeList = CXCLE00002.Instance.GetListObject<LOMDTO00076>("LOMORM00076.SelectAllLSBusinessCode", new object[] { true });
            this.cboLSBusinessType.ValueMember = "Code";
            this.cboLSBusinessType.DisplayMember = "Description";
            this.cboLSBusinessType.DataSource = LSBusinessTypeList;
            this.cboLSBusinessType.SelectedIndex = -1;
        }

        public void BindUM()
        {
            IList<LOMDTO00073> UMList = CXCLE00002.Instance.GetListObject<LOMDTO00073>("LOMORM00073.SelectAllUMCode", new object[] { true });
            this.cboUMCode.ValueMember = "UMCode";
            this.cboUMCode.DisplayMember = "UMDesp";
            this.cboUMCode.DataSource = UMList;
            this.cboUMCode.SelectedIndex = -1;
        }

        #endregion

        private void LOMVEW00077_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvLSProductTypeItemList_DataBind();
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
            this.cboProductType.Focus();
            this.focus();
            this.gvLSProductTypeItemList.EndEdit();
            IList<LOMDTO00077> List = this.LSProductTypeItemList.Where<LOMDTO00077>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00077 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvLSProductTypeItemList.EndEdit();
            IList<LOMDTO00077> deleteList = this.LSProductTypeItemList.Where<LOMDTO00077>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.cboProductType.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");  //Please select at least one record.
            }
            this.focus();
        }

        private void gvLSProductTypeItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvLSProductTypeItemList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00077 lsBusinessTypeItemCode = (LOMDTO00077)gvLSProductTypeItemList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousLSProductTypeItemDto = new LOMDTO00077();
                this.ProductCode = this.PreviousLSProductTypeItemDto.ProductCode = lsBusinessTypeItemCode.ProductCode;
                this.LSBusinessCode = this.PreviousLSProductTypeItemDto.LSBusinessCode = lsBusinessTypeItemCode.LSBusinessCode;
                this.UMCode = this.PreviousLSProductTypeItemDto.UMCode = lsBusinessTypeItemCode.UMCode;
                this.DurationMonths = this.PreviousLSProductTypeItemDto.DurationMonths = lsBusinessTypeItemCode.DurationMonths;
                this.ViewData = lsBusinessTypeItemCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboProductType.Enabled = isUpdateOnlyUser;
            this.cboLSBusinessType.Enabled = isUpdateOnlyUser;
            this.cboUMCode.Enabled = isUpdateOnlyUser;
            this.txtDurationMonths.Enabled = isUpdateOnlyUser;
        }

        private void gvLSProductTypeItemList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

    }
}
