//----------------------------------------------------------------------
// <copyright file="SAMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NL</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
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
    public partial class SAMVEW00004 : BaseDockingForm, ISAMVEW00004
    {
        #region Constrator

        public SAMVEW00004()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string BCode
        {
            get { return this.txtBankCode.Text; }
            set { this.txtBankCode.Text = value; }
        }

        public string BDesp
        {
            get { return this.txtBankName.Text; }
            set { this.txtBankName.Text = value; }
        }

        public string BAcctNo
        {
            get { return this.txtAccountNo.Text; }        
            set { this.txtAccountNo.Text = value; }            
        }

        public string Status { get; set; }

        private TLMDTO00040 viewData;
        public TLMDTO00040 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00040();

                this.viewData.BCode = this.BCode;
                this.viewData.BDesp = this.BDesp;
                this.viewData.BAccountNo = this.BAcctNo;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<TLMDTO00040> BCodes { get; set; }

        private ISAMCTL00004 controller;
        public ISAMCTL00004 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.BCodeView = this;
            }
        }

           
        TLMDTO00040 _previousBCodeDto;
        public TLMDTO00040 PreviousBCodeDto
        {
            get
            {
                if (_previousBCodeDto == null)
                    return new TLMDTO00040();
                return _previousBCodeDto;
            }
            set { _previousBCodeDto = value; }
        }

        #endregion

        #region Method

        private void dgVBCode_DataBind()
        {
            gvOtherBankCode.AutoGenerateColumns = false;
            this.BCodes = this.controller.GetAll();
            this.gvOtherBankCode.DataSource = this.BCodes;
            this.txtRecordCount.Text = gvOtherBankCode.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtBankCode.Enabled = isUpdateOnlyUser;
            this.txtBankName.Enabled = isUpdateOnlyUser;
            this.txtAccountNo.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVBCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtBankCode.Text = string.Empty;
            this.txtBankName.Text = string.Empty;
            this.txtAccountNo.Text = string.Empty;
            this.ControlSetting("BCode.Enable", true);
            this.Status = "Save";
        }

        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        public void focus()
        {
            this.txtBankCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
           // this.focus();
            this.dgVBCode_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.gvOtherBankCode.EndEdit();
            IList<TLMDTO00040> List = this.BCodes.Where<TLMDTO00040>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00040 dto in List)
            {
                dto.IsCheck = false;
            }
            this.Controller.ClearErrors();
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvOtherBankCode.EndEdit();
            IList<TLMDTO00040> deleteList = this.BCodes.Where<TLMDTO00040>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00004_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVBCode_DataBind();
            this.InitializeControls();
        }

        private void dgVBCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvOtherBankCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00040 bCode = (TLMDTO00040)gvOtherBankCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousBCodeDto = new TLMDTO00040();
                this.BCode = this.PreviousBCodeDto.BCode = bCode.BCode;
                this.BDesp = this.PreviousBCodeDto.BDesp = bCode.BDesp;
                this.BAcctNo = this.PreviousBCodeDto.BAccountNo = bCode.BAccountNo;

                this.ViewData = bCode;
                this.ControlSetting("BCode.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVBCodeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtBankCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        

        //private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = e.KeyChar == ' ';
        //}

        #endregion

    }
}

