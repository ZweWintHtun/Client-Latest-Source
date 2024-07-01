//----------------------------------------------------------------------
// <copyright file="SAMVEW00022.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
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

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00022 : BaseDockingForm, ISAMVEW00022
    {
        #region Constrator

        public SAMVEW00022()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public decimal Rate
        {
            get 
            { 
                if(string.IsNullOrEmpty(this.txtRate.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtRate.Text); 
            }
            set { this.txtRate.Text = value.ToString(); }
        }

        public decimal FixAmt
        {
            get 
            {
                if (string.IsNullOrEmpty(this.txtFixedAmount.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtFixedAmount.Text); 
            }
            set { this.txtFixedAmount.Text = value.ToString(); }
        }

        public decimal StartNo
        {
            get 
            {
                if (string.IsNullOrEmpty(this.txtStartAmount.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtStartAmount.Text);            
            }
            set { this.txtStartAmount.Text = value.ToString(); }
        }

        public decimal EndNo
        {
            get 
            {
                if (string.IsNullOrEmpty(this.txtEndAmount.Text))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtEndAmount.Text); 
            }
            set { this.txtEndAmount.Text = value.ToString(); }
        }

        public string Cur
        {
            get
            {
                if (this.cboCurrency.SelectedValue != null)
                    return this.cboCurrency.SelectedValue.ToString();
                else
                    return "";
            }
            set { this.cboCurrency.SelectedValue = value; }
        }

        public string Status { get; set; }

        private TLMDTO00003 viewData;
        public TLMDTO00003 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00003();

                this.viewData.Rate = this.Rate;
                this.viewData.FixAmount = this.FixAmt;
                this.viewData.StartNo = this.StartNo;
                this.viewData.EndNo = this.EndNo;
                this.viewData.Currency = this.Cur;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        TLMDTO00003 _previousPORateDto;
        public TLMDTO00003 PreviousPORateDto
        {
            get
            {
                if (_previousPORateDto == null)
                    return new TLMDTO00003();
                return _previousPORateDto;
            }
            set { _previousPORateDto = value; }
        }

        public IList<TLMDTO00003> PORates { get; set; }

        private ISAMCTL00022 controller;
        public ISAMCTL00022 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.PORateView = this;
            }
        }

        #endregion

        #region Method

        private void dgVPORate_DataBind()
        {
            gvPoRate.AutoGenerateColumns = false;
            this.PORates = this.controller.GetAll();
            this.gvPoRate.DataSource = this.PORates;
            this.txtRecordCount.Text = gvPoRate.RowCount.ToString();

        }

        private void BindCurrency()
        {
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = this.controller.GetCurrency();
        }


        private void ChangeControlStatusByUserType(bool isUpdateOnlyUser)
        {
            this.txtRate.Enabled = isUpdateOnlyUser;
            this.txtFixedAmount.Enabled = isUpdateOnlyUser;
            this.txtStartAmount.Enabled = isUpdateOnlyUser;
            this.txtEndAmount.Enabled = isUpdateOnlyUser;
            this.cboCurrency.Enabled = isUpdateOnlyUser;

        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.dgVPORate_DataBind();
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.txtRate.Text = string.Empty;
            this.txtFixedAmount.Text = string.Empty;
            this.txtStartAmount.Text = string.Empty;
            this.txtEndAmount.Text = string.Empty;
            this.cboCurrency.SelectedIndex = 0;


            this.Status = "Save";
        }

        private void focus()
        {
            this.cboCurrency.Focus();
        }

        #endregion

        #region Event

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save(this.ViewData);
            this.focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Controller.ClearErrors();
            this.gvPoRate.EndEdit();
            IList<TLMDTO00003> List = this.PORates.Where<TLMDTO00003>(x => x.IsCheck == true).ToList();
            foreach (TLMDTO00003 dto in List)
            {
                dto.IsCheck = false;
            }
            this.focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.gvPoRate.EndEdit();
            IList<TLMDTO00003> deleteList = this.PORates.Where<TLMDTO00003>(x => x.IsCheck == true).ToList();
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

        private void SAMVEW00022_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.dgVPORate_DataBind();
            this.BindCurrency();
            this.InitializeControls();

        }

        private void dgVPORate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvPoRate.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colEdit"))
            {
                this.ChangeControlStatusByUserType(true);

                TLMDTO00003 pORate = (TLMDTO00003)gvPoRate.Rows[e.RowIndex].DataBoundItem;

                this.PreviousPORateDto = new TLMDTO00003();

                this.PreviousPORateDto.Id = pORate.Id;
                this.Rate = this.PreviousPORateDto.Rate = pORate.Rate;
                this.FixAmt = this.PreviousPORateDto.FixAmount = pORate.FixAmount;
                this.StartNo = this.PreviousPORateDto.StartNo = pORate.StartNo;
                this.EndNo = this.PreviousPORateDto.EndNo = pORate.EndNo;
                this.Cur = this.PreviousPORateDto.Currency = pORate.Currency;


                this.ViewData = pORate;

                this.Status = "Update";
            }
        }

        private void dgVPORateEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.ToString().Equals("Undefined"))
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void txtStartAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtEndAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void txtFixedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        #endregion

    }
}

