//----------------------------------------------------------------------
// <copyright file="SAMVEW00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00008 : BaseDockingForm, ISAMVEW00008
    {
        #region Constrator

        public SAMVEW00008()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        TLMDTO00020 _previousDepositCodeDto;
        public TLMDTO00020 PreviousDepositCodeDto
        {
            get
            {
                if (_previousDepositCodeDto == null)
                    return new TLMDTO00020();
                return _previousDepositCodeDto;
            }
            set { _previousDepositCodeDto = value; }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string DepositCode
        {
            get { return this.txtDepositCode.Text; }
            set { this.txtDepositCode.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

       public string Status { get; set; }

        private TLMDTO00020 viewData;
        public TLMDTO00020 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00020();

                this.viewData.DepositCode = this.DepositCode;
                this.viewData.Description = this.Description;
                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<TLMDTO00020> DEPOSITCODEs { get; set; }

        private ISAMCTL00008 controller;
        public ISAMCTL00008 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.DEPOSITCODEView = this;
            }
        }

        #endregion

        #region Method

        private void dgVDEPOSITCODE_DataBind()
        {
            gvDepositCode.AutoGenerateColumns = false;
            this.DEPOSITCODEs = this.controller.GetAll(CurrentUserEntity.BranchCode);
            this.gvDepositCode.DataSource = this.DEPOSITCODEs;
            this.txtRecordCount.Text = gvDepositCode.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtDepositCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVDEPOSITCODE_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtDepositCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.ControlSetting("DEPOSITCODE.Enable", true);
          
            this.Status = "Save";
        }

        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            //this.txtDepositCode.Focus();
            this.dgVDEPOSITCODE_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvDepositCode.EndEdit();
            IList<TLMDTO00020> List = this.DEPOSITCODEs.Where<TLMDTO00020>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00020 dto in List)
            {
                dto.IsCheck = false;
            }
            this.txtDepositCode.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvDepositCode.EndEdit();
            IList<TLMDTO00020> deleteList = this.DEPOSITCODEs.Where<TLMDTO00020>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.txtDepositCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00008_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsdCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVDEPOSITCODE_DataBind();
            this.InitializeControls();
        }

        private void dgVDEPOSITCODE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvDepositCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00020 dEPOSITCODE = (TLMDTO00020)gvDepositCode.Rows[e.RowIndex].DataBoundItem;
                
                this.PreviousDepositCodeDto = new TLMDTO00020();
                this.DepositCode = this.PreviousDepositCodeDto.DepositCode = dEPOSITCODE.DepositCode;
                this.Description = this.PreviousDepositCodeDto.Description = dEPOSITCODE.Description;
                this.ViewData = dEPOSITCODE;
                this.ControlSetting("DEPOSITCODE.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVDEPOSITCODEEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtDepositCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        #endregion

    }
}

