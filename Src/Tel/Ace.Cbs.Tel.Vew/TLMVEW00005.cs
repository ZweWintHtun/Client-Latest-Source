//----------------------------------------------------------------------
// <copyright file="TLMVEW00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00005 : BaseDockingForm ,ITLMVEW00005
    {
        #region"Constructor

        public TLMVEW00005()
        {
            InitializeComponent();
        }
        #endregion

        # region "View Data Properties"

        public string EntryNo
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }

        public string CounterNo
        {
            get { return this.txtCounterNo.Text; }
            set { this.txtCounterNo.Text = value; }
        }


        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboCurrency.SelectedValue = value;
            }
        }
       
        public string Center
        {
            get { return this.lblToName.Text; }
            set { this.lblToName.Text = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.ntxtAmount.Text); }
            set { this.ntxtAmount.Text = Convert.ToString(value); }
        }

        private TLMDTO00015 viewData;

        public TLMDTO00015 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00015();
                this.viewData.Currency = this.CurrencyCode;
                this.viewData.Amount = Convert.ToDecimal(this.Amount);
                
                return this.viewData;

            }

            set { this.viewData = value; }
        }
 
        #endregion

        #region"Controller"
        private ITLMCTL00005 controller;
        public ITLMCTL00005 Controller
        {
            set
            {
                this.controller = value;
                controller.View = this;
            }
            get
            {
                return this.controller;
            }

        }
        #endregion

        #region"Event"

        private void TLMVEW00005_Load(object sender, EventArgs e)
        {
            #region Old Logic
            /*
            this.ButtonEnableDisable();
            this.TextboxDisable();
            this.BindCurrencyComboBoxes();

            var temp = from x in CurrentUserEntity.CounterList
                       where x.CounterType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType)
                       select x.CounterNo;
            this.CounterNo = temp.ToList<string>().Count == 0 ? CurrentUserEntity.CounterList[0].CounterNo : temp.ToList<string>()[0];

            this.BindCashDescription();
            this.cboCurrency.Focus(); 
            */
            #endregion


            #region Seperating_EOD_Logic (By YMP at 30-07-2019)
           
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.ButtonEnableDisable();
                this.TextboxDisable();
                this.BindCurrencyComboBoxes();

                var temp = from x in CurrentUserEntity.CounterList
                           where x.CounterType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType)
                           select x.CounterNo;
                this.CounterNo = temp.ToList<string>().Count == 0 ? CurrentUserEntity.CounterList[0].CounterNo : temp.ToList<string>()[0];

                this.BindCashDescription();
                this.cboCurrency.Focus(); 
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("CounterWithdraw.AllDisable");
            }
            

            #endregion


                      
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
        }

        #endregion

        #region"Method"

        private void ButtonEnableDisable()
        {
            this.tsbCRUD.ButtonEnableDisabled(false,false,true,false,true,false,true);
        }

        private void TextboxDisable()
        {
            this.DisableControls("CounterWithdrawalEntry.DisableControls");
        }

        private void BindCurrencyComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private string GetLocalIP()
        {
            string localIP = string.Empty;
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Entry No" , this.EntryNo});
        }

        private void BindCashDescription()
        {
            string center = CXCLE00002.Instance.GetScalarObject<string>("CashSetup.Client.SelectByCenterTableCashCodeDescription", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupCenterTable), CXCOM00007.Instance.BranchCode });
            this.Center = center != string.Empty ? center : string.Empty;
        }

        #endregion


    }
}
  