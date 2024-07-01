//----------------------------------------------------------------------
// <copyright file="SAMVEW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00002 : BaseDockingForm,ISAMVEW00002
    {
        #region Constrator

        public SAMVEW00002()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public int AccountTypeId
        {
            get
            {
                if (this.cboAccountType.SelectedValue == null)
                {
                    return 0;
                }
                else
                {
                    return  Convert.ToInt32(this.cboAccountType.SelectedValue);
                }
            }
            set { this.cboAccountType.SelectedValue = Convert.ToInt32(value); }
        }

        public string AccountTypeCode
        {
            get
            {
                if (this.cboAccountType.SelectedText == null)
                {
                    return null;
                }
                else
                {
                    return this.cboAccountType.SelectedText.ToString();
                }
            }
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

        public string Symbol
        {
            get { return this.txtSymbol.Text; }
            set { this.txtSymbol.Text = value; }
        }

        public string AccountSign
        {
            get { return this.txtAccountSign.Text; }
            set { this.txtAccountSign.Text = value; }
        }

        public string Status { get; set; }

        private PFMDTO00022 viewData;
        public PFMDTO00022 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00022();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;
                this.viewData.Symbol = this.Symbol;
                this.viewData.AccountSignature = this.AccountSign;
                this.viewData.AccountTypeId = this.AccountTypeId;
                this.viewData.AccountTypeCode = this.AccountTypeCode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        private PFMDTO00022 _previousSubAccountType;
        public PFMDTO00022 PreviousSubAccountType
        {
            get
            {
                if (_previousSubAccountType == null)
                    return new PFMDTO00022();
                return _previousSubAccountType;
            }
            set { this._previousSubAccountType = value; }
        }

        public IList<PFMDTO00022> SubAccountTypes { get; set; }

        private ISAMCTL00002 controller;
        public ISAMCTL00002 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.SubAccountTypeView = this;
            }
        }

        #endregion

        #region Method

        private void dgVSubAccountType_DataBind()
        {
            dgVSubAccountType.AutoGenerateColumns = false;
            this.SubAccountTypes = this.controller.GetAll();
            this.dgVSubAccountType.DataSource = this.SubAccountTypes;
            this.txtRecordCount.Text = dgVSubAccountType.RowCount.ToString();

        }

        private void cboAccountType_DataBind()
        {
            cboAccountType.DisplayMember = "Code";
            cboAccountType.ValueMember = "Id";
            cboAccountType.DataSource = this.Controller.SelectAll();
            cboAccountType.SelectedIndex = -1;
        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtSymbol.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVSubAccountType_DataBind();
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
            this.txtSymbol.Text = string.Empty;
            this.txtAccountSign.Text = string.Empty;
            this.cboAccountType.SelectedIndex = -1;

            this.Status = "Save";
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVSubAccountType_DataBind();

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();

            this.dgVSubAccountType.EndEdit();
            IList<PFMDTO00022> List = this.SubAccountTypes.Where<PFMDTO00022>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00022 dto in List)
            {
                dto.IsCheck = false;
            }
            this.cboAccountType.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.dgVSubAccountType.EndEdit();
            IList<PFMDTO00022> deleteList = this.SubAccountTypes.Where<PFMDTO00022>(x => x.IsCheck == true).ToList();
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
            this.cboAccountType.Focus();
        }

        private void SAMVEW00002_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsdCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVSubAccountType_DataBind();
            this.cboAccountType_DataBind();
            this.InitializeControls();
        }

        private void dgVSubAccountType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)dgVSubAccountType.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00022 subAccountType = (PFMDTO00022)dgVSubAccountType.Rows[e.RowIndex].DataBoundItem;

                this.PreviousSubAccountType = new PFMDTO00022();
                this.PreviousSubAccountType.Id = subAccountType.Id;
                this.Code = this.PreviousSubAccountType.Code = subAccountType.Code;
                this.Description = this.PreviousSubAccountType.Description = subAccountType.Description;
                this.Symbol = this.PreviousSubAccountType.Symbol = subAccountType.Symbol;
                this.AccountSign = this.PreviousSubAccountType.AccountSignature = subAccountType.AccountSignature;
                this.AccountTypeId = this.PreviousSubAccountType.AccountTypeId = subAccountType.AccountTypeId;

                this.ViewData = subAccountType;
                this.Status = "Update";
            }
        }

        private void dgVSubAccountTypeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void txtAccountSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';
        }

        private void txtSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        #endregion

    }
}

