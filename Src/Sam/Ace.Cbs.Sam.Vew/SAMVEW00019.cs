//----------------------------------------------------------------------
// <copyright file="SAMVEW00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>07/23/2013</CreatedDate>
// <UpdatedUser>NLKK</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00019 : BaseDockingForm, ISAMVEW00019
    {
        #region Constrator

        public SAMVEW00019()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Code
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public decimal Value
        {
            get 
            {
                if (txtValue.Text == "")
                    return 0;
                else
                    return Convert.ToDecimal(this.txtValue.Text.ToString().Trim()); 
            }
            set { this.txtValue.Text = value.ToString(); }
        }

        public DateTime Start_Date
        {
            get 
            {
                if (dtpStartDate.Text == "")
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(this.dtpStartDate.Text); 
            }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        //public System.Nullable<string> SourceBr
        //{
        //    get { return this.txtSourceBr.Text; }
        //    set { this.txtSourceBr.Text = value; }
        //}

        public string Status { get; set; }

        private TLMDTO00034 viewData;
        public TLMDTO00034 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00034();

                this.viewData.Code = this.Code;
                this.viewData.Value = this.Value;
                this.viewData.StartDate = this.Start_Date;
                //this.viewData.SourceBranchCode = this.Sourc;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<TLMDTO00034> Keys { get; set; }

        private ISAMCTL00019 controller;
        public ISAMCTL00019 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.DayKeyView = this;
            }
        }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        #endregion

        #region Method

        private void dgVDayKey_DataBind()
        {
            gvTestKey.AutoGenerateColumns = false;
            this.Keys = this.controller.GetAll(this.FormName);
            this.gvTestKey.DataSource = this.Keys;
            this.txtRecordCount.Text = gvTestKey.RowCount.ToString();
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtValue.Enabled = isUpdateOnlyUser;
            this.dtpStartDate.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
           // this.dgVDayKey_DataBind();
            this.InitializeControls();
            this.focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtValue.Text = string.Empty;
            this.dtpStartDate.Text = string.Empty;

            this.Status = "Save";
        }

        private void focus()
        {
            this.dtpStartDate.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //this.AutoValidate = AutoValidate.Disable;
            //if (string.IsNullOrEmpty(txtValue.Text))
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20024);   //Invalid Code
            //    this.txtValue.Focus();
            //}
            //else
            //{
                this.Controller.Save(this.ViewData, this.FormName);
                this.dgVDayKey_DataBind();
                //this.focus();
            //}
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {

            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {            
            this.InitializeControls();
            this.AutoValidate = AutoValidate.Disable;
            this.Controller.ClearErrors();
            this.gvTestKey.EndEdit();
            IList<TLMDTO00034> List = this.Keys.Where<TLMDTO00034>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00034 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.gvTestKey.EndEdit();
            IList<TLMDTO00034> deleteList = this.Keys.Where<TLMDTO00034>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList,this.FormName);
                    this.dgVDayKey_DataBind();
                    this.focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00019_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.Text = this.FormName + " Entry";
            //for amount key entry
            if (this.Text.Contains("Amount"))
            {
                this.txtCode.MaxLength = 15;
                this.txtCode.Size = new System.Drawing.Size(115, 20); 
            }

            this.dgVDayKey_DataBind();
            this.InitializeControls();
        }

        private void dgVDayKey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvTestKey.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00034 dayKey = (TLMDTO00034)gvTestKey.Rows[e.RowIndex].DataBoundItem;
                this.controller.PreviousTestKeyDto = new TLMDTO00034();

                this.controller.PreviousTestKeyDto.Id = dayKey.Id;
                this.Code = this.controller.PreviousTestKeyDto.Code = dayKey.Code;
                this.Value  = Convert.ToDecimal(dayKey.Value);
                this.controller.PreviousTestKeyDto.Value = dayKey.Value;                
                this.Start_Date =  Convert.ToDateTime(dayKey.StartDate);
                this.controller.PreviousTestKeyDto.StartDate = dayKey.StartDate;
                //this.SourceBr = dayKey.SourceBr;

                this.ViewData = dayKey;
                this.Status = "Update";
            }
        }

        private void dgVDayKeyEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)  //Added by ASDA
        {

            //if (string.IsNullOrEmpty(txtValue.Text))
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20024);  //Invalid Value 
            //    e.Cancel = true;
            //}
        }

        #endregion

        //private void txtValue_Validated(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtValue.Text))
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20024);  //Invalid Value     
        //}
    }
}
