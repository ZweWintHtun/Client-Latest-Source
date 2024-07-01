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
    public partial class LOMVEW00001 : BaseDockingForm, ILOMVEW00001
    {
        public LOMVEW00001()
        {
            InitializeComponent();
        }

        #region Properties

        LOMDTO00001 _previousBusinessCodeDto;
        public LOMDTO00001 PreviousBusinessDto
        {
            get
            {
                if (_previousBusinessCodeDto == null)
                    return new LOMDTO00001();
                return _previousBusinessCodeDto;
            }
            set { _previousBusinessCodeDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string BusinessCode
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

                this.viewData.Code = this.BusinessCode;
                this.viewData.Description = this.Description;               

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00001> BusinessCodes { get; set; }

        private ILOMCTL00001 controller;
        public ILOMCTL00001 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.BusinessCodeView = this;
            }
        }

        #endregion

        #region Method

        private void gvBusinessCode_DataBind()
        {
            gvBusinessCode.AutoGenerateColumns = false;
            this.BusinessCodes = this.controller.GetAll();
            this.gvBusinessCode.DataSource = this.BusinessCodes;
            this.txtRecordCount.Text = gvBusinessCode.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvBusinessCode_DataBind();
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
        public void focus()
        {
            this.txtCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);            
            //txtCode.Enabled = true;
            this.gvBusinessCode_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
       
            this.txtCode.Focus();
            this.focus();
            this.gvBusinessCode.EndEdit();
            IList<LOMDTO00001> List = this.BusinessCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00001 dto in List)
            {
                dto.IsCheck = false;
            }

            //txtCode.Enabled = true;


        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvBusinessCode.EndEdit();
            IList<LOMDTO00001> deleteList = this.BusinessCodes.Where<LOMDTO00001>(x => x.IsCheck == true).ToList();
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
            this.focus();
        }

        private void LOMVEW00001_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvBusinessCode_DataBind();
            this.InitializeControls();
        }

        private void gvBusinessCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvBusinessCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00001 nationalityCode = (LOMDTO00001)gvBusinessCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousBusinessDto = new LOMDTO00001();

                this.BusinessCode = this.PreviousBusinessDto.Code = nationalityCode.Code;
                this.Description = this.PreviousBusinessDto.Description = nationalityCode.Description;

                this.ViewData = nationalityCode;
                //txtCode.Enabled = false;
             //   this.ControlSetting("Business.Disable", false);
                this.Status = "Update";
               
            }
        }

        private void gvBusinessCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
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
