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
    public partial class LOMVEW00074 : BaseDockingForm, ILOMVEW00074
    {
        /// <summary>
        /// Type Of Product Code Setup View
        /// </summary>
        /// 
        #region Constructor
        public LOMVEW00074()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private LOMDTO00074 _previousProductCodeDto;
        public LOMDTO00074 PreviousProductCodeDto
        {
            get
            {
                if (_previousProductCodeDto == null)
                    return new LOMDTO00074();
                return _previousProductCodeDto;
            }
            set
            { _previousProductCodeDto = value; }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Code
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

        private LOMDTO00074 viewData;
        public LOMDTO00074 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00074();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00074> ProductCodeList { get; set; }

        private ILOMCTL00074 controller;
        public ILOMCTL00074 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.ProductCodeView = this;
            }
        }      
        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method

        private void gvProductList_DataBind()
        {
            gvProductList.AutoGenerateColumns = false;
            this.ProductCodeList = this.controller.GetAll();
            this.gvProductList.DataSource = this.ProductCodeList;
            this.txtRecordCount.Text = gvProductList.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvProductList_DataBind();
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

        private void gvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvProductList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00074 productCode = (LOMDTO00074)gvProductList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousProductCodeDto = new LOMDTO00074();
                this.Code = this.PreviousProductCodeDto.Code = productCode.Code;
                this.Description = this.PreviousProductCodeDto.Description = productCode.Description;
                this.ViewData = productCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void gvProductList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.focus();
            this.gvProductList.EndEdit();
            IList<LOMDTO00074> List = this.ProductCodeList.Where<LOMDTO00074>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00074 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvProductList.EndEdit();
            IList<LOMDTO00074> deleteList = this.ProductCodeList.Where<LOMDTO00074>(x => x.IsCheck == true).ToList();
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
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            //txtCode.Enabled = true;
            this.gvProductList_DataBind();
        }

        private void LOMVEW00074_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvProductList_DataBind();
            this.InitializeControls();
        }

        #endregion
    }
}
