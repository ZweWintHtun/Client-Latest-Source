//----------------------------------------------------------------------
// <copyright file="SAMVEW00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Vew
{
    /// <summary>
    /// RateInfo Setup View
    /// </summary>
    public partial class SAMVEW00051 : BaseDockingForm, ISAMVEW00051
    {
        #region Constrator

        public SAMVEW00051()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public string Cur
        {
            get 
            {
                if (this.cboCur.SelectedValue != null)
                    return this.cboCur.SelectedValue.ToString();
                else
                    return "";
            }
            set { this.cboCur.SelectedValue = value; }
        }

        public string RateType
        {
            get 
            {
                if (this.cboRateType.SelectedValue != null)
                    return this.cboRateType.SelectedValue.ToString();
                else
                    return "";
            }
            set { this.cboRateType.SelectedValue = value; }
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

        public string DenoRate
        {
            get { return this.txtDenoRate.Text; }
            set { this.txtDenoRate.Text = value; }
        }

        public DateTime RDate
        {
            get 
            {
                if (this.dtpRDate.Text != "")
                    return Convert.ToDateTime(this.dtpRDate.Text);
                else
                    return DateTime.Now;
            }
            set { this.dtpRDate.Text = value.ToString(); }
        }

        public string ToCur
        {
            get
            {
                if (this.cboToCur.SelectedValue != null)
                    return this.cboToCur.SelectedValue.ToString();
                else
                    return "";
            }
            set { this.cboToCur.SelectedValue = value; }
        }


        public string Status { get; set; }

        private PFMDTO00075 viewData;
        public PFMDTO00075 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00075();

                this.viewData.CurrencyCode = this.Cur;
                this.viewData.RateType = this.RateType;
                this.viewData.Rate = this.Rate;
                this.viewData.DenoRate = this.DenoRate;
                this.viewData.RegisterDate = this.RDate;
                this.viewData.ToCurrencyCode = this.ToCur;
                

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        PFMDTO00075 _previousRateInfoDto;
        public PFMDTO00075 PreviousRateInfoDto
        {
            get
            {
                if (_previousRateInfoDto == null)
                    return new PFMDTO00075();
                return _previousRateInfoDto;
            }
            set { _previousRateInfoDto = value; }
        }

        public IList<PFMDTO00075> RateInfos { get; set; }

        private ISAMCTL00051 controller;
        public ISAMCTL00051 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.RateInfoView = this;
            }
        }

        #endregion

        #region Method

        private void dgVRateInfo_DataBind()
        {
            gvCurrencyRate.AutoGenerateColumns = false;
            this.RateInfos = this.controller.GetAll();
            this.gvCurrencyRate.DataSource = this.RateInfos;
            this.txtRecordCount.Text = gvCurrencyRate.RowCount.ToString();

        }

        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.cboCur.Enabled = isUpdateOnlyUser;
            this.cboRateType.Enabled = isUpdateOnlyUser;
            this.txtRate.Enabled = isUpdateOnlyUser;
            this.txtDenoRate.Enabled = isUpdateOnlyUser;
            this.dtpRDate.Enabled = isUpdateOnlyUser;
            this.cboToCur.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVRateInfo_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.cboCur.SelectedIndex  = -1;
            this.cboRateType.SelectedIndex = -1;
            this.txtRate.Text = string.Empty;
            this.txtDenoRate.Text = string.Empty;
            this.dtpRDate.Text = DateTime.Now.ToString();
            this.cboToCur.SelectedIndex = -1;


            this.Status = "Save";
        }

        private void BindFromCurrcency()
        {
            IList<CurrencyDTO> CurList = this.controller.GetCurrency();
            this.cboCur.DisplayMember = "Cur";
            this.cboCur.ValueMember = "Cur";
            this.cboCur.DataSource = CurList;
            this.cboCur.SelectedIndex = -1;       

         }

        private void BindToCurrency()
        {
            IList<CurrencyDTO> CurList = this.controller.GetCurrency();
            this.cboToCur.DisplayMember = "Cur";
            this.cboToCur.ValueMember = "Cur";
            this.cboToCur.DataSource = CurList;
            this.cboToCur.SelectedIndex = -1;           
        }

        private void BindRateType()
        {
            Dictionary<string, string> rateType = SpringApplicationContext.Instance.Resolve<Dictionary<string, string>>("RateType");
            this.cboRateType.ValueMember = "Key";
            this.cboRateType.DisplayMember = "Value";
            this.cboRateType.DataSource = new BindingSource(rateType, null);
            this.cboRateType.SelectedIndex = -1;
        }

        private void focus()
        {
            this.cboCur.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
           // this.focus();
            this.dgVRateInfo_DataBind();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvCurrencyRate.EndEdit();
            IList<PFMDTO00075> List = this.RateInfos.Where<PFMDTO00075>(x => x.IsCheck == true).ToList();
            foreach (PFMDTO00075 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvCurrencyRate.EndEdit();
            IList<PFMDTO00075> deleteList = this.RateInfos.Where<PFMDTO00075>(x => x.IsCheck == true).ToList();
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

        private void SAMVEW00051_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVRateInfo_DataBind();
            this.BindFromCurrcency();
            this.BindToCurrency();
            this.BindRateType();
            this.InitializeControls();
        }

        private void dgVRateInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvCurrencyRate.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                PFMDTO00075 rateInfo = (PFMDTO00075)gvCurrencyRate.Rows[e.RowIndex].DataBoundItem;

                this.PreviousRateInfoDto = new PFMDTO00075();
                this.PreviousRateInfoDto.Id = rateInfo.Id;
                this.Cur = this.PreviousRateInfoDto.CurrencyCode = rateInfo.CurrencyCode;
                this.RateType = this.PreviousRateInfoDto.RateType = rateInfo.RateType;
                this.Rate = this.PreviousRateInfoDto.Rate = rateInfo.Rate;
                this.DenoRate = this.PreviousRateInfoDto.DenoRate = rateInfo.DenoRate;
                this.RDate = this.PreviousRateInfoDto.RegisterDate = rateInfo.RegisterDate;
                this.ToCur = this.PreviousRateInfoDto.ToCurrencyCode = rateInfo.ToCurrencyCode;
             

                this.ViewData = rateInfo;

                this.Status = "Update";
            }
        }

        private void dgVRateInfoEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtDenoRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }
        #endregion
    }
}

