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
    public partial class LOMVEW00008 : BaseDockingForm, ILOMVEW00008
    {
        public LOMVEW00008()
        {
            InitializeComponent();
        }

        #region Properties

        LOMDTO00010 _previousKStockNoDto;
        public LOMDTO00010 PreviousKStockNoDto
        {
            get
            {
                if (_previousKStockNoDto == null)
                    return new LOMDTO00010();
                return _previousKStockNoDto;
            }
            set { _previousKStockNoDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string KStockNo
        {
            get { return this.txtStock.Text; }
            set { this.txtStock.Text = value; }
        }

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00010 viewData;
        public LOMDTO00010 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00010();

                this.viewData.KStockNo = this.KStockNo;
                this.viewData.Desp = this.Desp;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00010> KStockCode { get; set; }

        private ILOMCTL00008 controller;
        public ILOMCTL00008 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.KStockNoView = this;
            }
        }


        #endregion


        #region Method

        
        private void gvKStockCode_DataBind()
        {
            gvKStockCode.AutoGenerateColumns = false;
            this.KStockCode = this.controller.GetAll();
            this.gvKStockCode.DataSource = this.KStockCode;
            this.txtRecordCount.Text = gvKStockCode.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtStock.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvKStockCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtStock.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
           //this.ControlSetting("OccupationCode.Enable", true);
            this.Status = "Save";
        }

        //public void ControlSetting(string name, bool isEnable)
        //{
        //    if (isEnable)
        //        this.EnableControls(name);
        //    else
        //        this.DisableControls(name);
        //}

        public void focus()
        {
            this.txtStock.Focus();
        }

        #endregion

  private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
    
          
            this.focus();
            this.gvKStockCode.EndEdit();
            IList<LOMDTO00010> List = this.KStockCode.Where<LOMDTO00010>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00010 dto in List)
            {
                dto.IsCheck = false;
            }
           // txtStock.Enabled = true;
        }
        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvKStockCode.EndEdit();
            IList<LOMDTO00010> deleteList = this.KStockCode.Where<LOMDTO00010>(x => x.IsCheck == true).ToList();
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

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {

            this.Controller.Save(this.ViewData);
            //this.txtStock.Focus();
            this.gvKStockCode_DataBind();
           // txtStock.Enabled = true;
        }

      

        private void gvKStockCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvKStockCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00010 KStockCode = (LOMDTO00010)gvKStockCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousKStockNoDto = new LOMDTO00010();

                this.KStockNo = this.PreviousKStockNoDto.KStockNo = KStockCode.KStockNo;
                this.Desp = this.PreviousKStockNoDto.Desp = KStockCode.Desp;

                this.ViewData = KStockCode;
              //  txtStock.Enabled = false;
                //this.ControlSetting("OccupationCode.Disable", false);
                this.Status = "Update";
            }


        }

        private void gvKStockCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void LOMVEW00008_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvKStockCode_DataBind();
            this.InitializeControls();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        //private void LOMVEW00008_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}





    }
}
