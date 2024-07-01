//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00047 : AbstractPresenter, IMNMCTL00047
    {
        #region Properties

        private IMNMVEW00047 view;
        public IMNMVEW00047 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        public IList<PFMDTO00001> CustList { get; set; }
        public PFMDTO00001 accountinfo { get; set; }

        #endregion   

        #region Helper Methods

        private void WireTo(IMNMVEW00047 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        private PFMDTO00001 GetVlaidateData()
        {
            PFMDTO00001 ValidateDto = new PFMDTO00001();
            ValidateDto.DATE_TIME = view.Date_time;
            ValidateDto.AccountNo = View.AccountNumber;
            return ValidateDto;
        }

        #endregion

        #region Events calling Methods

        public void mtxtAccountNo_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            Nullable<CXDMD00011> accountType;
            string accountNo = this.View.AccountNumber.Replace("-", "");
            try
            {
                if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    string AccountType = string.Empty;
                    switch (this.View.AcSign)
                    {
                        case "CS": AccountType = "Current.Specific"; break;
                        case "SS": AccountType = "Saving.Specific"; break;  
                    }

                   accountinfo = CXClientWrapper.Instance.Invoke<IMNMSVE00047, PFMDTO00001>(x => x.CheckingAccountNo(accountNo, AccountType, CurrentUserEntity.BranchCode));
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                if (ex.Message == "MV00114")
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void dtpDate_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                // Check dtpStartDate Date Time
                if (this.view.Date_time.Date > DateTime.Now.Date)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.view.Date_time.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                    return;
                }
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetVlaidateData());
        }


        #endregion

        #region Methods

        public IList<PFMDTO00001> SelectInfo(string actype)
        {
            CustList = CXClientWrapper.Instance.Invoke<IMNMSVE00047, IList<PFMDTO00001>>(x => x.SelectData(actype, CurrentUserEntity.BranchCode));
            if (CustList.Count <= 0 || CustList == null)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039);/*No data for Report.*/               
            }
            return CustList;
        }

        public string SelectCurrencyByAccountNo(string acctno)
        {
            
            string cur = CXClientWrapper.Instance.Invoke<IMNMSVE00047, string>(x => x.SelectTopCurrencyCodeByAccountNo(acctno));
            if (string.IsNullOrEmpty(cur))
            {
                this.SetCustomErrorMessage(this.GetControl("gvBalanceConfirmation"), "MV00020");
            }
            
            return cur;
        }

        #endregion 

    }
}
