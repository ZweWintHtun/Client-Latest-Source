//----------------------------------------------------------------------
// <copyright file="MNMVEW00066.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00066 : BaseForm , IMNMVEW00066
    {
        #region Properties

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        } 
     
        public DateTime RequiredDate
        {
            get { return dtpRequiredDate.Value; }
            set { dtpRequiredDate.Text = value.ToString(); }
        }
        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                    return null;
                else
                    return cboCurrency.SelectedValue.ToString();
            }
            set
            {                
                cboCurrency.SelectedValue = value;
            }
        }       

        public IList<PFMDTO00042> PrintDataList { get; set; }        
        
        #endregion

        #region Controller

        private IMNMCTL00066 _controller;
        public IMNMCTL00066 Controller
        {
            get
            {
                return this._controller;
            }
            set 
            {
                this._controller = value;
                this._controller.View = this;
            }
        }

        #endregion

        #region Constructor
        public MNMVEW00066()
        {
            InitializeComponent();
        }
        #endregion

        #region Method

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpRequiredDate.Value = DateTime.Now;
            this.BindCurrency();          
        }

        public bool CheckDate()
        {
            if (this.FormName == "Coming Accrued Listing" ||  this.formName == "Coming Interest Listing")
            {
                if (this.dtpRequiredDate.Value.Date < DateTime.Now.Date)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00173, this.dtpRequiredDate.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));//Datetime cannot be Less than today date. (to get right msg code)
                    this.dtpRequiredDate.Focus();
                    return false;
                }
            }
            return true;
        }

        public string GetFormName()
        {
            string name = string.Empty;
            if (this.FormName == "Renewal Voucher Listing")
            {
                name = "Renewal Voucher Listing";
            }
            else if (this.FormName == "Coming Accrued Listing")
            {
                name = "Coming Accrued Listing";
            }
            else if (this.FormName == "Coming Interest Listing")
            {
                name = "Coming Interest Listing";
            }
            return name;
        }

        #endregion

        #region Events
        private void MNMVEW00066_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.Text = this.GetFormName();
            this.grpBeforeDayClose.Text = this.GetFormName();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.dtpRequiredDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpRequiredDate.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy")); //Required Date {0} cannot be greater than Today. 
                this.dtpRequiredDate.Focus();
                return;
            }
            else
            {
                if (this.Controller.Validate_Form() && this.CheckDate())
                    this.Controller.Print();
            }

        }
        #endregion
    }
}
