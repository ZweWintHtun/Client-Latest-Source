// <copyright file="TLMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00023 : AbstractPresenter, ITLMCTL00023
    {
        #region Properties
        private ITLMVEW00023 view;
        public ITLMVEW00023 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00023 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, new object());
            }
        }

        #endregion

        #region Constant String
        private const string DepositListingByAll = "DepositListingByAll";
        private const string DepositListingByAccountNo = "DepositListingByAccountNo";
        private const string DepositListingByCounterNo = "DepositListingByCounterNo";
        private const string DepositListingByGrade = "DepositListingByGrade";
        private const string WithdrawListingByGrade = "WithdrawListingByGrade";
        #endregion

        #region Main Method
        public void GetTransaction()
        {
            switch (this.view.Index)
            {
                case -1:
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00110);
                    break;

                #region Deposit
                case 0:
                    //CXUIScreenTransit.Transit("frmTLMVEW00024", true, new object[] { false, this.view.Name, "Deposit Listing By Account Type" });
                    this.HelperTransit("frmTLMVEW00025", DepositListingByAll);
                    break;
                case 1:
                    CXUIScreenTransit.Transit("frmTLMVEW00024", true, new object[] { false, this.view.Name, "Deposit Listing By Account Type" });
                    //this.HelperTransit("frmTLMVEW00025", DepositListingByAll);
                    break;
                case 2:
                    this.HelperTransit("frmTLMVEW00025", DepositListingByAccountNo);
                    break;
                case 3:
                    this.HelperTransit("frmTLMVEW00025", DepositListingByCounterNo);
                    break;
                case 4:
                    this.HelperTransit("frmTLMVEW00026", DepositListingByGrade);
                    break;
                #endregion

                #region Withdraw
                case 5:
                    //CXUIScreenTransit.Transit("frmTLMVEW00024", true, new object[] { false, this.view.Name, "Withdrawal Listing By Account Type" });
                    this.HelperTransit("frmTLMVEW00027WithdrawalByAll", string.Empty);
                    break;
                case 6:
                    CXUIScreenTransit.Transit("frmTLMVEW00024", true, new object[] { false, this.view.Name, "Withdrawal Listing By Account Type" });
                    //this.HelperTransit("frmTLMVEW00027WithdrawalByAll", string.Empty);
                    break;
                case 7:
                    this.HelperTransit("frmTLMVEW00027WithdrawalByAccountNo", string.Empty);
                    break;
                case 8:
                    this.HelperTransit("frmTLMVEW00027WithdrawalByCounter", string.Empty);   //WithdrawByUserNo 
                    break;
                case 9:
                    this.HelperTransit("frmTLMVEW00026", WithdrawListingByGrade);
                    break;
                #endregion
            }
 
        }
        #endregion

        #region Helper Method
        private void HelperTransit(string transitformname, string transitfor)
        {
            if (!string.IsNullOrEmpty(transitfor))
                CXUIScreenTransit.Transit(transitformname, true, new object[] { false, this.view.Name, transitfor });
            else
                CXUIScreenTransit.Transit(transitformname, true, new object[] { false, this.view.Name });
        }
        #endregion
    }
}
