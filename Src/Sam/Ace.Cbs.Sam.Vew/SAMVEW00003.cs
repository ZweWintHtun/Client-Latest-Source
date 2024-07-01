//----------------------------------------------------------------------
// <copyright file="SAMVEW00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00003 : BaseDockingForm, ISAMVEW00003
    {
        /// <summary>
        /// OccupationCode Setup View
        /// </summary>
        #region Constrator

        public SAMVEW00003()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        PFMDTO00004 _previousOccupationCodeDto;
        public PFMDTO00004 PreviousOccupationDto
        {
            get
            {
                if (_previousOccupationCodeDto == null)
                    return new PFMDTO00004();
                return _previousOccupationCodeDto;
            }
            set { _previousOccupationCodeDto = value; }
        }


        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string OccupationCode
        {
            get { return this.txtOccupationCode.Text; }
            set { this.txtOccupationCode.Text = value; }
        }

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        

        public string Status { get; set; }

        private PFMDTO00004 viewData;
        public PFMDTO00004 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00004();

                this.viewData.Occupation_Code = this.OccupationCode;
                this.viewData.Description = this.Desp;
                //this.viewData.USERNO = this.USERNO;
                //this.viewData.DATE_TIME = this.DATE_TIME;
                //this.viewData.EDITDATE_TIME = this.EDITDATE_TIME;
                //this.viewData.EDITUSER = this.EDITUSER;
                //this.viewData.EDITTYPE = this.EDITTYPE;
                //this.viewData.DEFAULTS = this.DEFAULTS;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00004> OccupationCodes { get; set; }

        private ISAMCTL00003 controller;
        public ISAMCTL00003 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.OccupationCodeView = this;
            }
        }

        #endregion

        #region Method

        private void dgVOccupationCode_DataBind()
        {
            gvOccupationCode.AutoGenerateColumns = false;
            this.OccupationCodes = this.controller.GetAll();
            //this.OccupationCodes = this.OccupationCodes.OrderByDescending(o => o.Occupation_Code.ToString()).ToList();//Added by HWKO (26-Dec-2017)
            // Comment By AAM (08-Jan-2018).
            this.gvOccupationCode.DataSource = this.OccupationCodes;
            this.txtRecordCount.Text = gvOccupationCode.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtOccupationCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVOccupationCode_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtOccupationCode.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.ControlSetting("OccupationCode.Enable", true);
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
            this.txtOccupationCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVOccupationCode_DataBind();
          //  this.txtOccupationCode.Focus();
           // this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.txtOccupationCode.Focus();
            this.focus();
            this.gvOccupationCode.EndEdit();
            IList<PFMDTO00004> List = this.OccupationCodes.Where<PFMDTO00004>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00004 dto in List)
            {
                dto.IsCheck = false;
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvOccupationCode.EndEdit();
            IList<PFMDTO00004> deleteList = this.OccupationCodes.Where<PFMDTO00004>(x => x.IsCheck == true).ToList();
            if (deleteList.Count > 0)
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
                {
                    this.Controller.Delete(deleteList);
                    this.txtOccupationCode.Focus();
                }
            }
            else
            {
                this.Failure("MV90012");
            }
            this.focus();
        }

        private void SAMVEW00003_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVOccupationCode_DataBind();
            this.InitializeControls();
        }

        private void dgVOccupationCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvOccupationCode.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00004 occupationCode = (PFMDTO00004)gvOccupationCode.Rows[e.RowIndex].DataBoundItem;

                this.PreviousOccupationDto = new PFMDTO00004();
                
                this.OccupationCode = this.PreviousOccupationDto.Occupation_Code = occupationCode.Occupation_Code;
                this.Desp = this.PreviousOccupationDto.Description = occupationCode.Description;
                            
                this.ViewData = occupationCode;
                this.ControlSetting("OccupationCode.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVOccupationCodeEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtOccupationCode_KeyPress(object sender, KeyPressEventArgs e)
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

