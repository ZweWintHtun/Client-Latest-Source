//----------------------------------------------------------------------
// <copyright file="SAMVEW00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    /// <summary>
    /// RateFile Setup View
    /// </summary>
    public partial class SAMVEW00023 : BaseDockingForm, ISAMVEW00023
    {
        #region Constrator

        public SAMVEW00023()
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

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public DateTime DATE_TIME
        {
            get
            {
                if (dtpRequiredMonth.Text == "")
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(this.dtpRequiredMonth.Text);                   
            }
            set { this.dtpRequiredMonth.Text = value.ToString(); }
        }

        public decimal Rate
        {
            get 
            {
                if (string.IsNullOrEmpty(this.txtRate.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtRate.Text); 
            }
            set { this.txtRate.Text = value.ToString(); }
        }

        public decimal Duration
        {
            get 
            {
                if (string.IsNullOrEmpty(this.txtDuration.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtDuration.Text); 
            }
            set { this.txtDuration.Text = value.ToString(); }
        }
        public string Status { get; set; }

        private PFMDTO00009 viewData;
        public PFMDTO00009 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00009();

                this.viewData.Code = this.Code;
                this.viewData.Description = this.Desp;
                this.viewData.DATE_TIME = this.DATE_TIME;
                this.viewData.Rate = this.Rate;
                this.viewData.Duration = this.Duration;
                this.viewData.LASTMODIFY = this.chkLastModify.Checked;               

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        PFMDTO00009 _previousRateDto;
        public PFMDTO00009 PreviousRateDto
        {
            get
            {
                if (_previousRateDto == null)
                    return new PFMDTO00009();
                return _previousRateDto;
            }
            set { _previousRateDto = value; }
        }

        public IList<PFMDTO00009> RateFiles { get; set; }

        private ISAMCTL00023 controller;
        public ISAMCTL00023 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.RateFileView = this;
            }
        }

        #endregion

        #region Method

        private void dgVRateFile_DataBind()
        {
            gvRateSetup.AutoGenerateColumns = false;
            this.RateFiles = this.controller.GetAll();
            this.gvRateSetup.DataSource = this.RateFiles;
            this.txtRecordCount.Text = gvRateSetup.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtCode.Enabled = isUpdateOnlyUser;
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.dtpRequiredMonth.Enabled = isUpdateOnlyUser;
            this.txtRate.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVRateFile_DataBind();
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
            this.dtpRequiredMonth.Text = DateTime.Now.ToString();
            this.txtRate.Text = string.Empty;
            this.txtDuration.Text = string.Empty;
            this.chkLastModify.Checked = false;
            this.ControlSetting("RateFile.Enable", true);
            this.Status = "Save";
        }
        public void ControlSetting(string name, bool isEnable)
        {
            if (isEnable)
                this.EnableControls(name);
            else
                this.DisableControls(name);
        }

        private void focus()
        {
            this.txtCode.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
          //  this.focus();
            this.dgVRateFile_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvRateSetup.EndEdit();
            IList<PFMDTO00009> List = this.RateFiles.Where<PFMDTO00009>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00009 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvRateSetup.EndEdit();
            IList<PFMDTO00009> deleteList = this.RateFiles.Where<PFMDTO00009>(x => x.IsCheck == true).ToList();
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

        private void SAMVEW00023_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVRateFile_DataBind();
            this.InitializeControls();
        }

        private void dgVRateFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvRateSetup.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00009 rateFile = (PFMDTO00009)gvRateSetup.Rows[e.RowIndex].DataBoundItem;

                this.PreviousRateDto = new PFMDTO00009();
                this.Code = this.PreviousRateDto.Code = rateFile.Code;
                this.Desp = this.PreviousRateDto.Description = rateFile.Description;
                this.DATE_TIME = this.PreviousRateDto.DATE_TIME = rateFile.DATE_TIME;
                this.Rate = this.PreviousRateDto.Rate = rateFile.Rate;
                this.Duration = this.PreviousRateDto.Duration = rateFile.Duration;
				this.chkLastModify.Checked = this.PreviousRateDto.LASTMODIFY = rateFile.LASTMODIFY;
                this.ViewData = rateFile;
                this.DisableControls("RateFile.Disable");
                this.ControlSetting("RateFile.Disable", false);
                this.Status = "Update";
            }
        }

        private void dgVRateFileEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;
        }
        #endregion
    }
}

