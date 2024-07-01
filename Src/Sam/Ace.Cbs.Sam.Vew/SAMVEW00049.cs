//----------------------------------------------------------------------
// <copyright file="SAMVEW00049.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00049 : BaseDockingForm, ISAMVEW00049
    {
        #region Constrator

        public SAMVEW00049()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }
        public bool chkStatus
        {
            get { return this.chkAllBranch.Checked; }
            set { this.chkAllBranch.Checked = value; }
        }

           
        public string Status { get; set; }

        private PFMDTO00056 viewData;
        public PFMDTO00056 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00056();

                this.viewData.Name = this.Name;
                this.viewData.BranchCode = BranchNo;
               
                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00056> Sys001s { get; set; }

        private ISAMCTL00049 controller;
        public ISAMCTL00049 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.Sys001View = this;
            }
        }

        private PFMDTO00056 _previousSys001Dto;
        public PFMDTO00056 PreviousSys001Dto
        {
            get
            {
                if (_previousSys001Dto == null)
                    return new PFMDTO00056();
                return _previousSys001Dto;
            }
            set { _previousSys001Dto = value; }
        }

        public string BranchNo
        {
            get
            {
                if (this.cboBranchNo.SelectedValue == null || this.chkAllBranch.Checked)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.SelectedValue.ToString();
                }
            }

            set { this.cboBranchNo.SelectedValue = value; }
        }

        IList<BranchDTO> BranchList = new List<BranchDTO>();

        #endregion

        #region Method

        private void dgVSys001_DataBind()
        {
            gvSystemDefine.AutoGenerateColumns = false;
            this.Sys001s = this.controller.GetAll();
            this.gvSystemDefine.DataSource = this.Sys001s;
            this.txtRecordCount.Text = gvSystemDefine.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtName.Enabled = isUpdateOnlyUser;
            
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVSys001_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            return;
        }

        private void InitializeControls()
        {
            this.txtName.Text = string.Empty;          
            this.Status = "Save";
            this.chkAllBranch.Enabled = true;
            this.chkAllBranch.Checked = true;
            this.txtName.Focus();
        }

        private void BindBranchCode()
        {
            IList<BranchDTO> BranchCodeList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select");            
            BranchList = (from value in BranchCodeList
                        where value.Active = true 
                        select value).ToList();
            this.cboBranchNo.DisplayMember = "BranchCode";
            this.cboBranchNo.ValueMember = "BranchCode";
            this.cboBranchNo.DataSource = BranchList;
            this.cboBranchNo.SelectedIndex = -1;
        }
        
        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {            
            this.Controller.Save(this.ViewData, BranchList);
            ///this.txtName.Focus();
            this.dgVSys001_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
             this.InitializeControls();
             this.Controller.ClearErrors();
             this.gvSystemDefine.EndEdit();
             IList<PFMDTO00056> List = this.Sys001s.Where<PFMDTO00056>(x => x.IsCheck == true).ToList();
             foreach (PFMDTO00056 dto in List)
             {
                 dto.IsCheck = false;
             }
            this.txtName.Focus();
            this.chkAllBranch.Checked=true;
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvSystemDefine.EndEdit();
            IList<PFMDTO00056> deleteList = this.Sys001s.Where<PFMDTO00056>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.txtName.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
        }

        private void SAMVEW00049_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVSys001_DataBind();
            this.BindBranchCode();
            this.InitializeControls();
            
        }

        private void dgVSys001_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvSystemDefine.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00056 sys001 = (PFMDTO00056)gvSystemDefine.Rows[e.RowIndex].DataBoundItem;

                this.PreviousSys001Dto = new PFMDTO00056();
                this.PreviousSys001Dto.Id = sys001.Id;
                this.Name = this.PreviousSys001Dto.Name = sys001.Name;
                this.BranchNo = this.PreviousSys001Dto.Name = sys001.BranchCode;
             
                this.ViewData = sys001;

                this.Status = "Update";
                this.chkAllBranch.Checked = false;
                this.chkAllBranch.Enabled = false;
                this.cboBranchNo.Enabled = false;
            }
        }

        private void dgVSys001Entry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        #endregion

        private void chkAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllBranch.Checked)
            {
                this.cboBranchNo.Enabled = false;
                this.cboBranchNo.SelectedValue = string.Empty;
                this.cboBranchNo.SelectedText = string.Empty;
                this.cboBranchNo.SelectedIndex = -1;
            }
            else
                this.cboBranchNo.Enabled = true; 
        }

        private void cboBranchNo_Validated(object sender, EventArgs e)
        {
            
        }
    }
}

