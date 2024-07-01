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
    public partial class LOMVEW00447 : BaseDockingForm, ILOMVEW00415
    {
        #region Constructor
        public LOMVEW00447()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string ProductCode
        {
            get { return this.txtProductCode.Text; }
            set { this.txtProductCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text.Trim(); }
            set { this.txtDescription.Text = value; }
        }

        public string RelatedGLACode
        {
            get { return this.cboGLCode.SelectedValue == null ? "" : this.cboGLCode.SelectedValue.ToString(); }
            set { this.cboGLCode.SelectedValue = value; }
        }       

        public string Status { get; set; }
        public IList<LOMDTO00415> ProductCodeList { get; set; }

        #endregion

        #region Variables
        List<LOMDTO00415> ACodeLst = new List<LOMDTO00415>();
        #endregion

        #region Controller
        private LOMDTO00415 _previousProductCodeDto;
        public LOMDTO00415 PreviousProductCodeDto
        {
            get
            {
                if (_previousProductCodeDto.Equals(null))  return new LOMDTO00415();
                return _previousProductCodeDto;
            }
            set
            {
                _previousProductCodeDto = value;
            }
        }

        private LOMDTO00415 viewData;
        public LOMDTO00415 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00415();

                this.viewData.ProductCode = this.ProductCode;
                this.viewData.Description = this.Description;
                this.viewData.RelatedGLACode = this.RelatedGLACode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }


        private ILOMCTL00415 controller;
        public ILOMCTL00415 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.PersonalLoanProductCodeEntryView = this;
            }
        }
        #endregion

        #region Method
        public void focus()
        {
            this.txtProductCode.Focus();
        }

        private void gvStockGroupList_DataBind()
        {
            this.gvStockGroupList.AutoGenerateColumns = false;
            this.ProductCodeList = this.controller.GetAll();
            this.gvStockGroupList.DataSource = this.ProductCodeList;
            this.txtRecordCount.Text = gvStockGroupList.RowCount.ToString();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvStockGroupList_DataBind();
            this.InitializeControl();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }           

        public void BindGLcode()
        {
            ACodeLst = Controller.SelectAll_ACode().ToList();
            this.cboGLCode.DataSource = ACodeLst;
            this.cboGLCode.DisplayMember = "ACode";
            this.cboGLCode.ValueMember = "ACode";
            this.cboGLCode.SelectedIndex = -1;
            this.cboGLCode.Text = string.Empty;
        }

        public void InitializeControl()
        {
            this.BindGLcode();
            this.controller.ClearErrors();
            this.txtProductCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.cboGLCode.Text = string.Empty;
            this.txtProductCode.Enabled = true;

            this.cboGLCode.SelectedIndex = -1;
            this.Status = "Save";
            Cursor.Current = Cursors.Default;
            this.txtProductCode.Focus();
        }

        private bool CheckRequiredFields()
        {
            if (this.txtProductCode.Text == string.Empty)
            {
                MessageBox.Show("Please fill Product Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProductCode.Focus();
                return false;
            }

            if (txtDescription.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please fill Product Description!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDescription.Focus();
                return false;
            }

            if (this.cboGLCode.Text == string.Empty)
            {
                MessageBox.Show("Please select Related GL ACode!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboGLCode.Focus();
                return false;
            }

            //if (gvStockGroupList.RowCount > 0)
            //{
            //    for (int i = 0; i < gvStockGroupList.RowCount; i++)
            //    {
            //        string _ProductCode = (gvStockGroupList.Rows[i].Cells[0].Value).ToString();

            //        for (int k = 0; k < gvStockGroupList.RowCount; k++)
            //        {
            //            string _NewProductCode = (gvStockGroupList.Rows[k].Cells[0].Value).ToString();

            //            if (i != k)
            //            {
            //                if (_ProductCode == _NewProductCode)
            //                {
            //                    gvStockGroupList.ClearSelection();
            //                    gvStockGroupList.CurrentCell = null;
            //                    MessageBox.Show("Product Code is Duplicate!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    this.gvStockGroupList.Rows[k].Cells[0].Selected = true;
            //                    this.gvStockGroupList.Rows[k].Cells[0].ToolTipText = "Duplicate Product Code!";
            //                    return false;
            //                }


            //            }
            //        }

            //    }
            //}

            return true;
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtProductCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.cboGLCode.Enabled = isUpdateOnlyUser;
        }
        #endregion

        #region "ProcessCmdKey"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txtProductCode.Focused && keyData == (Keys.Enter) || txtProductCode.Focused && keyData == (Keys.Tab))
            {
                txtDescription.Focus();
                return true;
            }
            else if (txtDescription.Focused && keyData == (Keys.Enter) || txtDescription.Focused && keyData == (Keys.Tab))
            {
                cboGLCode.Focus();
                return true;
            }
            else if (cboGLCode.Focused && keyData == (Keys.Enter) || cboGLCode.Focused && keyData == (Keys.Tab))
            {
                if (cboGLCode.Text == "")
                    MessageBox.Show("Please select Related GL ACode!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);;

                this.cboGLCode.Focus();
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion

        #region Form Load
        private void LOMVEW00447_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvStockGroupList_DataBind();
            this.InitializeControl();
        }
        #endregion

        #region Events
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

                LOMDTO00415 _ProductCodedto = (LOMDTO00415)gvStockGroupList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousProductCodeDto = new LOMDTO00415();
                this.ProductCode = this.PreviousProductCodeDto.ProductCode = _ProductCodedto.ProductCode;
                this.Description = this.PreviousProductCodeDto.Description = _ProductCodedto.Description;
                this.RelatedGLACode = this.PreviousProductCodeDto.RelatedGLACode = _ProductCodedto.RelatedGLACode;
                this.ViewData = _ProductCodedto;
                this.txtProductCode.Enabled = false;
                this.Status = "Update";

            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CheckRequiredFields())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Save?", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                    this.Controller.Save(this.ViewData);

                else if (dialogResult == DialogResult.No)
                    txtProductCode.Focus();

            }
            
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvStockGroupList.EndEdit();
            IList<LOMDTO00415> deleteList = this.ProductCodeList.Where<LOMDTO00415>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //Are you sure you want to delete?
                {
                    this.Controller.Delete(deleteList);
                    this.txtProductCode.Focus();
                }
            }
            else
                this.Failure("MV90012");  //Please select at least one record.

            this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
            this.Controller.ClearErrors();
            this.txtProductCode.Focus();
            this.focus();
            this.gvStockGroupList.EndEdit();
            IList<LOMDTO00415> List = this.ProductCodeList.Where<LOMDTO00415>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00415 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void gvStockGroupList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
                e.CellStyle.ForeColor = Color.Blue;

        }
        #endregion

    }
}
