//----------------------------------------------------------------------
// <copyright file="SAMVEW00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    public partial class SAMVEW00015 : BaseDockingForm, ISAMVEW00015
    {
        #region Constrator

        public SAMVEW00015()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        PFMDTO00007 _previousFixedRateDto;
        public PFMDTO00007 PreviousFixedRateDto
        {
            get
            {
                if (_previousFixedRateDto == null)
                    return new PFMDTO00007();
                return _previousFixedRateDto;
            }
            set { _previousFixedRateDto = value; }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Desp
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public decimal Rate
        {
            get
            {
                if (string.IsNullOrEmpty(txtRate.Text))
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
                if (string.IsNullOrEmpty(txtDuration.Text))
                    return 0;
                else
                    return Convert.ToDecimal(txtDuration.Text);
            }
            set { this.txtDuration.Text = value.ToString(); }
        }

        public string Status { get; set; }

        private PFMDTO00007 viewData;
        public PFMDTO00007 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00007();

                this.viewData.Description = this.Desp;
                this.viewData.Rate = this.Rate;
                this.viewData.Duration = this.Duration;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        public IList<PFMDTO00007> FixRates { get; set; }

        private ISAMCTL00015 controller;
        public ISAMCTL00015 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.FixRateView = this;
            }
        }

        #endregion

        #region Method

        private void dgVFixRate_DataBind()
        {
            gvFixedRate.AutoGenerateColumns = false;
            this.FixRates = this.controller.GetAll();
            this.gvFixedRate.DataSource = this.FixRates;
            this.txtRecordCount.Text = gvFixedRate.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtDescription.Enabled = isUpdateOnlyUser;
            this.txtRate.Enabled = isUpdateOnlyUser;
            this.txtDuration.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVFixRate_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtDescription.Text = string.Empty;
            this.txtRate.Text = string.Empty;
            this.txtDuration.Text = string.Empty;


            this.Status = "Save";
        }

        public void focus()
        {
            this.txtDuration.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.dgVFixRate_DataBind();
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
            this.gvFixedRate.EndEdit();
            IList<PFMDTO00007> List = this.FixRates.Where<PFMDTO00007>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00007 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvFixedRate.EndEdit();
            IList<PFMDTO00007> deleteList = this.FixRates.Where<PFMDTO00007>(x => x.IsCheck == true).ToList();
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

        private void SAMVEW00015_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVFixRate_DataBind();
            this.InitializeControls();
        }

        private void dgVFixRate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvFixedRate.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00007 fixRate = (PFMDTO00007)gvFixedRate.Rows[e.RowIndex].DataBoundItem;

                this.PreviousFixedRateDto = new PFMDTO00007();

                this.PreviousFixedRateDto.Id = fixRate.Id;
                this.Desp = this.PreviousFixedRateDto.Description = fixRate.Description;
                this.Rate = this.PreviousFixedRateDto.Rate = fixRate.Rate;
                this.Duration = this.PreviousFixedRateDto.Duration = fixRate.Duration;


                this.ViewData = fixRate;

                this.Status = "Update";
            }
        }

        private void dgVFixRateEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = e.KeyChar == ' ';
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        #endregion

    }
}