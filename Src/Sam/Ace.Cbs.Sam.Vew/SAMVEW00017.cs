//----------------------------------------------------------------------
// <copyright file="SAMVEW00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00017 : BaseDockingForm, ISAMVEW00017
    {
        #region Constrator

        public SAMVEW00017()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string ZoneType
        {
            get { return this.cboZoneType.Text; }
            set { this.cboZoneType.SelectedValue = value; }
        }

        public string ZoneTypeValue
        {
            get
            {
                if (cboZoneType.SelectedValue == null)
                    return string.Empty;
                else
                    return cboZoneType.SelectedValue.ToString();
            }
            set
            {
                this.cboZoneType.SelectedValue = value;
            }
        }

        public string BrCode
        {
            get { return this.cboBranchCode.SelectedValue.ToString(); }
            set { this.cboBranchCode.SelectedValue = value; this.cboBranchCode.Text = value; }
        }

        public string ACode
        {
            get { return this.txtAccountCode.Text; }
            set { this.txtAccountCode.Text = value; }
        }

        public string Status { get; set; }

        private TLMDTO00031 viewData;
        public TLMDTO00031 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00031();

                this.viewData.ZoneType = this.ZoneTypeValue;
                this.viewData.ZoneDescription = this.ZoneType;
                this.viewData.BranchCode = this.cboBranchCode.Text;
                this.viewData.AccountCode = this.ACode;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        private TLMDTO00031 _previousZoneDto;
        public TLMDTO00031 PreviousZoneDto
        {
            get
            {
                if(_previousZoneDto == null)
                    return new TLMDTO00031();
                return _previousZoneDto;
            }
            set { this._previousZoneDto = value; }

        }

        public IList<TLMDTO00031> Zones { get; set; }

        private ISAMCTL00017 controller;
        public ISAMCTL00017 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.ZoneView = this;
            }
        }

        #endregion

        #region Method

        private void dgVZone_DataBind()
        {
            gvZoneCode.AutoGenerateColumns = false;
            this.Zones = this.controller.GetAll();
            this.gvZoneCode.DataSource = this.Zones;
            this.txtRecordCount.Text = gvZoneCode.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboZoneType.Enabled = isUpdateOnlyUser;
            this.cboBranchCode.Enabled = isUpdateOnlyUser;
            this.txtAccountCode.Enabled = isUpdateOnlyUser;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            //this.dgVZone_DataBind();
            this.InitializeControls();
            this.focus();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.cboZoneType.SelectedIndex = -1;
            this.cboBranchCode.SelectedIndex = -1;
            this.txtAccountCode.Text = string.Empty;

            this.Status = "Save";
        }

        private void cboZoneType_Bind()
        {            
            Dictionary<string, string> zoneType = SpringApplicationContext.Instance.Resolve<Dictionary<string, string>>("ZoneType");
            cboZoneType.ValueMember = "Key";
            cboZoneType.DisplayMember = "Value";
            cboZoneType.DataSource = new BindingSource(zoneType, null);
            cboZoneType.SelectedIndex = -1;

        }

        private void cboBranchCode_Bind()
        {
            IList<BranchDTO> branches = this.controller.GetBranchCode();
            cboBranchCode.ValueMember = "BranchAlias";
            cboBranchCode.DisplayMember = "BranchAlias";
            cboBranchCode.DataSource = branches;
            cboBranchCode.SelectedIndex = -1;
        }

        public void focus()
        {
            this.cboZoneType.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVZone_DataBind();
            //this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvZoneCode.EndEdit();
            IList<TLMDTO00031> List = this.Zones.Where<TLMDTO00031>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00031 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvZoneCode.EndEdit();
            IList<TLMDTO00031> deleteList = this.Zones.Where<TLMDTO00031>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.dgVZone_DataBind();
                    this.focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00017_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVZone_DataBind();
            this.cboZoneType_Bind();
            this.cboBranchCode_Bind();
            this.InitializeControls();
        }

        private void dgVZone_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvZoneCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00031 zone = (TLMDTO00031)gvZoneCode.Rows[e.RowIndex].DataBoundItem;
              
                this.PreviousZoneDto = new TLMDTO00031();
                this.PreviousZoneDto.Id = zone.Id;
                this.ZoneType = this.PreviousZoneDto.ZoneType = zone.ZoneType;
                this.BrCode = this.PreviousZoneDto.BranchCode = zone.BranchCode;
                this.ACode = this.PreviousZoneDto.AccountCode = zone.AccountCode;
                this.ViewData = zone;
                this.Status = "Update";
            }
        }

        private void dgVZoneEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtAccountCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        #endregion
        
    }
}
