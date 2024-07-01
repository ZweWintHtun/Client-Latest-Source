//----------------------------------------------------------------------
// <copyright file="TLMCTL00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// BankStatement Listing By Date  Controller
    /// </summary>
    public class TLMCTL00031 : AbstractPresenter, ITLMCTL00031
    {
        #region "Properties
        private bool isValidateForm = false;
        public string AccountNo { get; set; }
        public IList<PFMDTO00021> FledgerInfoLists { get; set; }
        #endregion

        #region "For Initializer"
        private ITLMVEW00031 bankstatementListingByDateView;
        public ITLMVEW00031 BankstatementListingByDateView
        {
            get { return this.bankstatementListingByDateView; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00031 view)
        {
            if (this.bankstatementListingByDateView == null)
            {
                this.bankstatementListingByDateView = view;
                this.Initialize(this.bankstatementListingByDateView, this.Print());
            }
        }
        #endregion

        #region "Methods"
        private PFMDTO00054 Print()
        { 
            PFMDTO00054 BankStatementListingByDateEntity = new PFMDTO00054();
            if (BankStatementListingByDateEntity != null)
            {
                    BankStatementListingByDateEntity.AccountNo = this.bankstatementListingByDateView.AccountNo;
             }
                return BankStatementListingByDateEntity;          
        }

        public void CLedgerMainPrint()
        {
            isValidateForm = true;
            if (this.ValidateForm(this.Print()))
            {
                CXUIScreenTransit.Transit("frmTLMVEW00051", true, new object[] { this.bankstatementListingByDateView.AccountNo, this.bankstatementListingByDateView.StartDate, this.bankstatementListingByDateView.EndDate, "Bank Statement Listing By Date Report", this.bankstatementListingByDateView.WithReversal });//Updated By HWKO (17-May-2017)
            }
            this.isValidateForm = false;
        }

        public void FAOFMainPrint()
        {
            isValidateForm = true;
            this.FledgerInfoLists = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(service => service.GetFAOFsByAccountNumber(this.bankstatementListingByDateView.AccountNo));
            CXUIScreenTransit.Transit("frmTLMVEW00073", true, new object[] { this.FledgerInfoLists, this.bankstatementListingByDateView.AccountNo, this.bankstatementListingByDateView.IsAllCustmers, this.bankstatementListingByDateView.StartDate, this.bankstatementListingByDateView.EndDate, "Bank Statement Listing By Date For Fixed Deposit A/C Report",this.bankstatementListingByDateView.WithReversal });//Updated By HWKO (17-May-2017)
            this.isValidateForm = false;
        }

        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.bankstatementListingByDateView.StartDate, this.bankstatementListingByDateView.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");
            }
            return date;
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == true)
            {
                return;
            }
            else
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.bankstatementListingByDateView.AccountNo, out accountType))
                {
                    if (this.bankstatementListingByDateView.AccountNo.Substring(0, 3) != CurrentUserEntity.BranchCode)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                    }
                    else
                    {
                        PFMDTO00028 CledgerInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(this.BankstatementListingByDateView.AccountNo));
                        if (CledgerInfo != null)
                        {
                            //Commented by AAM(12_Sep_2018)
                            //if (CledgerInfo.CurrentBal <= 0 && CledgerInfo.CloseDate != null)
                            //{
                            //    // Account No has been closed.
                            //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044);
                            //    return;
                            //}
                            //else
                            //{
                            //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                            //}

                            this.bankstatementListingByDateView.isFixedAcc = false;
                            //this.bankstatementListingByDateView.ForFAOFAccount(false);
                        }
                        else if (CledgerInfo == null)
                        {
                            FledgerInfoLists = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00021>(x => x.GetCustomerInfoandFAOFInfoByAccountNo(this.bankstatementListingByDateView.AccountNo));
                            //if (FledgerInfoLists.Count > 0 && FledgerInfoLists.Count > 1)
                            //{
                            //    this.bankstatementListingByDateView.ForFAOFAccount(true);
                            //}
                            this.bankstatementListingByDateView.isFixedAcc = true;
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                            return;
                        }
                    }
                }
            }
        }

        #endregion
    }

}

