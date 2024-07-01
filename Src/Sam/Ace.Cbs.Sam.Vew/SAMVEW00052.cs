//----------------------------------------------------------------------
// <copyright file="SAMVEW00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00052 : BaseDockingForm, ISAMVEW00052
    {
        #region Constrator

        public SAMVEW00052()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string TranCode
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public string TransactionStatus
        {
            get { return this.txtStatus.Text; }
            set { this.txtStatus.Text = value; }
        }

        public string PBReference
        {
            get { return this.txtPBReference.Text; }
            set { this.txtPBReference.Text = value; }
        }

        public string RVReference
        {
            get { return this.txtRVReference.Text; }
            set { this.txtRVReference.Text = value; }
        }

        public string Status { get; set; }

        private TLMDTO00005 viewData;
        public TLMDTO00005 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00005();

                this.viewData.TransactionCode = this.TranCode;
                this.viewData.Description = this.Desp;
                this.viewData.Narration = this.Narration;
                this.viewData.Status = this.TransactionStatus;
                this.viewData.PBReference = this.PBReference;
                this.viewData.RVReference = this.RVReference;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        TLMDTO00005 _previousTranTypeDto;
        public TLMDTO00005 PreviousTranTypeDto
        {
            get
            {
                if (_previousTranTypeDto == null)
                    return new TLMDTO00005();
                return _previousTranTypeDto;
            }
            set { _previousTranTypeDto = value; }
        }

        public IList<TLMDTO00005> TranTypes { get; set; }

        private ISAMCTL00052 controller;
        public ISAMCTL00052 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.TranTypeView = this;
            }
        }

        #endregion

        #region Method

        private void dgVTranType_DataBind()
        {
            gvTransactionType.AutoGenerateColumns = false;
            this.TranTypes = this.controller.GetAll();
            this.gvTransactionType.DataSource = this.TranTypes;
            this.txtRecordCount.Text = gvTransactionType.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtNarration.Enabled = isUpdateOnlyUser;
            this.txtStatus.Enabled = isUpdateOnlyUser;
            this.txtPBReference.Enabled = isUpdateOnlyUser;
            this.txtRVReference.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVTranType_DataBind();
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
            this.txtNarration.Text = string.Empty;
            this.txtStatus.Text = string.Empty;
            this.txtPBReference.Text = string.Empty;
            this.txtRVReference.Text = string.Empty;

            this.ControlSetting("TranType.Enable", true);
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
          //  this.txtCode.Focus();
            this.dgVTranType_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvTransactionType.EndEdit();
            IList<TLMDTO00005> List = this.TranTypes.Where<TLMDTO00005>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00005 dto in List)
            {
                dto.IsCheck = false;
            }
            this.txtCode.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvTransactionType.EndEdit();
            IList<TLMDTO00005> deleteList = this.TranTypes.Where<TLMDTO00005>(x => x.IsCheck == true).ToList();
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
        }

        private void SAMVEW00052_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVTranType_DataBind();
            this.InitializeControls();
        }

        private void dgVTranType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvTransactionType.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00005 tranType = (TLMDTO00005)gvTransactionType.Rows[e.RowIndex].DataBoundItem;
                this.PreviousTranTypeDto = new TLMDTO00005();

                this.TranCode = this.PreviousTranTypeDto.TransactionCode = tranType.TransactionCode;
                this.Desp = this.PreviousTranTypeDto.Description =tranType.Description;
                this.Narration = this.PreviousTranTypeDto.Narration = tranType.Narration;
                this.TransactionStatus = this.PreviousTranTypeDto.Status = tranType.Status;
                this.PBReference = this.PreviousTranTypeDto.PBReference = tranType.PBReference;
                this.RVReference = this.PreviousTranTypeDto.RVReference = tranType.RVReference;


                this.ViewData = tranType;
                this.ControlSetting("TranType.Disable", false);
                this.Status= "Update";
            }
        }

        private void dgVTranTypeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtPBReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtRVReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        

        //private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        //{
        //    e.KeyChar = Char.ToUpper(e.KeyChar);
        //}

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        #endregion
    }
}

