//----------------------------------------------------------------------
// <copyright file="LOMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KKM</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00006 : BaseDockingForm, ILOMVEW00006
    {
        #region Constrator

        public LOMVEW00006()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties
        LOMDTO00004 _previousInsuranceDto;
        public LOMDTO00004 PreviousInsuranceDto
        { 
           get
            {
                if (_previousInsuranceDto == null)
                    return new LOMDTO00004();
                    return _previousInsuranceDto;
             }
            set
               {
                   _previousInsuranceDto = value;
               }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string INSUCODE
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        public string INSUDESP
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Status { get; set; }

        private LOMDTO00004 viewData;
        public LOMDTO00004 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new LOMDTO00004();

                this.viewData.INSUCODE = this.INSUCODE;
                this.viewData.INSUDESP = this.INSUDESP;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<LOMDTO00004> INSURANs { get; set; }

        private ILOMCTL00006 controller;
        public ILOMCTL00006 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.INSURANView = this;
            }
        }

        #endregion

        #region Method

        private void dgVINSURAN_DataBind()
        {
            dgVINSURAN.AutoGenerateColumns = false;
            this.INSURANs = this.controller.GetAll();
            this.dgVINSURAN.DataSource = this.INSURANs;
            this.txtRecordCount.Text = dgVINSURAN.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVINSURAN_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }
        public void focus()
        {
            this.txtCode.Focus();
        }
        private void InitializeControls()
        {
            this.txtCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;

            this.ControlSetting("INSURAN.Enable", true);
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
            //txtCode.Enabled = true;
            this.dgVINSURAN_DataBind();
         
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
            this.dgVINSURAN.EndEdit();
            IList<LOMDTO00004> List = this.INSURANs.Where<LOMDTO00004>(x => x.IsCheck == true).ToList();
            foreach (LOMDTO00004 dto in List)
            {
                dto.IsCheck = false;
            }

           // txtCode.Enabled = true;
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.dgVINSURAN.EndEdit();
            IList<LOMDTO00004> deleteList = this.INSURANs.Where<LOMDTO00004>(x => x.IsCheck == true).ToList();
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
            this.txtCode.Focus();
        }

        private void LOMVEW00006_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVINSURAN_DataBind();
            this.InitializeControls();
        }

        private void dgVINSURAN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)dgVINSURAN.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                LOMDTO00004 iNSURAN = (LOMDTO00004)dgVINSURAN.Rows[e.RowIndex].DataBoundItem;

                //this.INSUCODE = iNSURAN.INSUCODE;
                //this.INSUDESP = iNSURAN.INSUDESP;
                this.PreviousInsuranceDto = new LOMDTO00004();
                this.INSUCODE = this.PreviousInsuranceDto.INSUCODE = iNSURAN.INSUCODE;
                this.INSUDESP = this.PreviousInsuranceDto.INSUDESP = iNSURAN.INSUDESP;

                this.ViewData = iNSURAN;
                this.ControlSetting("INSURAN.Disable", false);
                this.Status = "Update";
               // txtCode.Enabled = false;
            }
        }

        private void dgVINSURANEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        #endregion

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            e.Handled = e.KeyChar == ' ';

        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

    }
}

