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
using Ace.Cbs.Loan.Ctr.Ptr ;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00002 : BaseDockingForm , ILOMVEW00002
    {
        /// <summary>
        /// Type Of Advance Code Setup View
        /// </summary>
        /// 

        #region Constructor
        public LOMVEW00002()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private LOMDTO00002 _previousAdvanceDto;
        public LOMDTO00002 PreviousAdvanceDto
        {
            get
            {
                if (_previousAdvanceDto == null)
                    return new LOMDTO00002();
                return _previousAdvanceDto;
            }
            set
            { _previousAdvanceDto = value; }
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

        private LOMDTO00002 viewData;
        public LOMDTO00002 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00002();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00002> TypesOfAdvanceList { get; set; }

        private ILOMCTL00002 controller;
        public ILOMCTL00002 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.TypeOfAdvanceView = this;
            }
        }


      
        public void focus()
        {
            this.txtCode.Focus();
        }
        #endregion

        #region Method

        private void gvAdvanceList_DataBind()
        {
            gvAdvanceList.AutoGenerateColumns = false;
            this.TypesOfAdvanceList = this.controller.GetAll();
            this.gvAdvanceList.DataSource = this.TypesOfAdvanceList;
            this.txtRecordCount.Text = gvAdvanceList.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.gvAdvanceList_DataBind();
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

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            //txtCode.Enabled = true;
            this.gvAdvanceList_DataBind();
            
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
            this.gvAdvanceList.EndEdit();
            IList<LOMDTO00002> List = this.TypesOfAdvanceList.Where<LOMDTO00002>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00002 dto in List)
            {
                dto.IsCheck = false;
            }
      
            //txtCode.Enabled = true;
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvAdvanceList.EndEdit();
            IList<LOMDTO00002> deleteList = this.TypesOfAdvanceList.Where<LOMDTO00002>(x => x.IsCheck == true).ToList();
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

        private void gvAdvanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvAdvanceList.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00002 advanceCode = (LOMDTO00002)gvAdvanceList.Rows[e.RowIndex].DataBoundItem;

                this.PreviousAdvanceDto= new LOMDTO00002();
                this.Code = this.PreviousAdvanceDto.Code = advanceCode.Code;
                this.Description = this.PreviousAdvanceDto.Description = advanceCode.Description;
                this.ViewData = advanceCode;
                this.Status = "Update";
                
                //txtCode.Enabled = false;
                
            }
        }

        private void gvAdvanceList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

         #endregion

        private void LOMVEW00002_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.gvAdvanceList_DataBind();
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

        //private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //SendKeys.Send("{Tab}");
        //       this.tsbCRUD.Focus();
        //    }
        //}


    }
}
