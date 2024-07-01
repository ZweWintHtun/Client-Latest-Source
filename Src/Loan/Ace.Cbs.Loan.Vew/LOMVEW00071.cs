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
    public partial class LOMVEW00071 : BaseDockingForm, ILOMVEW00071
    {
        #region Constructor
        public LOMVEW00071()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private LOMDTO00071 _previousSeasonCodeDto;
        public LOMDTO00071 PreviousSeasonCodeDto
        {
            get
            {
                if (_previousSeasonCodeDto == null)
                    return new LOMDTO00071();
                return _previousSeasonCodeDto;
            }
            set
            { _previousSeasonCodeDto = value; }
        }

        //public int Id
        //{
        //    get { throw new NotImplementedException(); }
        //}

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

        private LOMDTO00071 viewData;
        public LOMDTO00071 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00071();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00071> SeasonCodeList { get; set; }

        private ILOMCTL00071 controller;
        public ILOMCTL00071 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.SeasonCodeView = this;
            }
        }      
        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method

        private void gvSeasonList_DataBind()
        {
            gvSeasonList.AutoGenerateColumns = false;
            this.SeasonCodeList = this.controller.GetAll();
            this.gvSeasonList.DataSource = this.SeasonCodeList;
            this.txtRecordCount.Text = gvSeasonList.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvSeasonList_DataBind();
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
        #region Event
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtCode.Focus();
            this.focus();
            this.gvSeasonList.EndEdit();
            IList<LOMDTO00071> List = this.SeasonCodeList.Where<LOMDTO00071>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00071 dto in List)
            {
                dto.IsCheck = false;
            }
        }
        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvSeasonList.EndEdit();
            IList<LOMDTO00071> deleteList = this.SeasonCodeList.Where<LOMDTO00071>(x => x.IsCheck == true).ToList();
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
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            //txtCode.Enabled = true;
            this.gvSeasonList_DataBind();
        }
        private void gvSeasonList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvSeasonList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00071 seasonCode = (LOMDTO00071)gvSeasonList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousSeasonCodeDto = new LOMDTO00071();
                this.Code = this.PreviousSeasonCodeDto.Code = seasonCode.Code;
                this.Description = this.PreviousSeasonCodeDto.Description = seasonCode.Description;
                this.ViewData = seasonCode;
                this.Status = "Update";

                //txtCode.Enabled = false;

            }
        }

        private void gvSeasonList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }
        private void LOMVEW00071_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvSeasonList_DataBind();
            this.InitializeControls();
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
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
