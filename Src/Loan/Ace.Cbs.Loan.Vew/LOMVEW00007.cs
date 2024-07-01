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
    public partial class LOMVEW00007 : BaseDockingForm, ILOMVEW00007
    {
        public LOMVEW00007()
        {
            InitializeComponent();
        }

        #region Properties

        LOMDTO00009 _previousStockNoDto;
        public LOMDTO00009 PreviousStockNoDto
        {
            get
            {
                if (_previousStockNoDto == null)
                    return new LOMDTO00009();
                return _previousStockNoDto;
            }
            set { _previousStockNoDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string StockNo
        {
            get { return this.txtStock.Text; }
            set { this.txtStock.Text = value; }
        }

        public string Name
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00009 viewData;
        public LOMDTO00009 ViewData
        {
            get
            {
                if (this.viewData == null)
                    this.viewData = new LOMDTO00009();

                this.viewData.StockNo = this.StockNo;
                this.viewData.Name = this.Name;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00009> StockCode { get; set; }

        private ILOMCTL00007 controller;
        public ILOMCTL00007 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.StockNoView= this;
            }
        }

        #endregion

        #region Method

        private void gvStockCode_DataBind()
        {
            gvStockCode.AutoGenerateColumns = false;
            this.StockCode = this.controller.GetAll();
            this.gvStockCode.DataSource = this.StockCode;
            this.txtRecordCount.Text = gvStockCode.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtStock.Enabled = isUpdateOnlyUser;
            this.txtName.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvStockCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtStock.Text = string.Empty;
            this.txtName.Text = string.Empty;
          //  this.focus();
            //this.ControlSetting("OccupationCode.Enable", true);
            this.Status = "Save";
        }

       // public void ControlSetting(string name, bool isEnable)
        //{
         //   if (isEnable)
           //     this.EnableControls(name);
           // else
            //    this.DisableControls(name);
       // }

        public void focus()
        {
            this.txtStock.Focus();
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
            //this.txtStock.Focus();
            //this.focus();
		  this.gvStockCode_DataBind();
            txtStock.Enabled = true;

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {

            this.InitializeControls();
           this.Controller.ClearErrors();
    
           // this.txtStock.Text = string.Empty;
          
            this.txtStock.Focus();
          //  this.focus();
            this.gvStockCode.EndEdit();
            IList<LOMDTO00009> List = this.StockCode.Where<LOMDTO00009>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00009 dto in List)
            {
                dto.IsCheck = false;
            }
          //  txtStock.Enabled = true;
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
             this.gvStockCode.EndEdit();
            IList<LOMDTO00009> deleteList = this.StockCode.Where<LOMDTO00009>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.txtStock.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void gvStockCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvStockCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00009 characterCode = (LOMDTO00009)gvStockCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousStockNoDto = new LOMDTO00009();

                this.StockNo = this.PreviousStockNoDto.StockNo = characterCode.StockNo;
                this.Name = this.PreviousStockNoDto.Name = characterCode.Name;

                this.ViewData = characterCode;
              //  txtStock.Enabled = false;
                //this.ControlSetting("OccupationCode.Disable", false);
                this.Status = "Update";
            }
        }
        private void gvStockCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void LOMVEW00007_Load(object sender, EventArgs e)
        {
             this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvStockCode_DataBind();
            this.InitializeControls();
           // this.Controller.ClearErrors();

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //private void LOMVEW00007_KeyDown(object sender, KeyEventArgs e)
        //{
        //     if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}


        #endregion



    }
}
