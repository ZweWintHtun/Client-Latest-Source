//----------------------------------------------------------------------
// <copyright file="SAMVEW00001.cs" company="ACE Data Systems">
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
    public partial class SAMVEW00001 : BaseDockingForm, ISAMVEW00001
    {
        #region Constrator

        public SAMVEW00001()
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

        public string Status { get; set; }

        private PFMDTO00015 viewData;
        public PFMDTO00015 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00015();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Description;
                this.viewData.Symbol = this.Symbol;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00015> AccountTypes { get; set; }

        private ISAMCTL00001 controller;
        public ISAMCTL00001 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.AccountTypeView = this;
            }
        }

        #endregion

        #region Method

        private void dgVAccountType_DataBind()
        {
            gvAccountType.AutoGenerateColumns = false;
            this.AccountTypes = this.controller.GetAll();
            this.gvAccountType.DataSource = this.AccountTypes;
            this.txtRecordCount.Text = gvAccountType.RowCount.ToString();

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
            this.dgVAccountType_DataBind();
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

            this.Status = "Save";
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVAccountType_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.gvAccountType.EndEdit();
            IList<PFMDTO00015> List = this.AccountTypes.Where<PFMDTO00015>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00015 dto in List)
            {
                dto.IsCheck = false;
            }
            this.Controller.ClearErrors();
            this.txtCode.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvAccountType.EndEdit();
            IList<PFMDTO00015> deleteList = this.AccountTypes.Where<PFMDTO00015>(x => x.IsCheck == true).ToList();
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
            this.txtCode.Focus();
        }

        private void SAMVEW00001_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVAccountType_DataBind();
            this.InitializeControls();
        }

        private void dgVAccountType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvAccountType.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00015 accountType = (PFMDTO00015)gvAccountType.Rows[e.RowIndex].DataBoundItem;
                this.controller.PreviousAccountTypeDto = new PFMDTO00015();
                
                this.controller.PreviousAccountTypeDto.Id = accountType.Id;
                this.Code = this.controller.PreviousAccountTypeDto.Code = accountType.Code;
                this.Description = this.controller.PreviousAccountTypeDto.Description = accountType.Description;
                this.Symbol = this.controller.PreviousAccountTypeDto.Symbol = accountType.Symbol;

                this.ViewData = accountType;
                this.Status = "Update";
            }
        }

        private void dgVAccountTypeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

