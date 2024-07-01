//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
using Ace.Cbs.Mnm.Dmd;
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00053 : AbstractPresenter, IMNMCTL00053
    {
        bool isFixedBal = false;
        #region Properties

        private IMNMVEW00053 view;
        public IMNMVEW00053 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion      

        #region Helper Methods

        private PFMDTO00054 GetVlaidateData()
        {
            PFMDTO00054 ValidateDto = new PFMDTO00054();
            return ValidateDto;
        }

        private void WireTo(IMNMVEW00053 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        #endregion

        #region Events calling Methods
        private IList<MNMDTO00035> GetList()
        {
            if (this.View.IsAllCurrency)
            {
                //CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
                if (this.View.ACTypeAll)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceAllByAllCurrency(CurrentUserEntity.BranchCode));
                else if (this.View.ACTypeCurrent)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceByAcSignAndAllCurrency(CurrentUserEntity.BranchCode, "C"));
                else if (this.View.ACTypeSaving)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceByAcSignAndAllCurrency(CurrentUserEntity.BranchCode, "S"));
                else if (this.View.ACTypeFixed)
                {
                    this.isFixedBal = true;
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceFixedAndAllCurrency(CurrentUserEntity.BranchCode));
                }
                else if (this.View.ACTypeOD)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceOverdraftAndAllCurrency(CurrentUserEntity.BranchCode));
            }
            else
            {
                if (this.View.ACTypeAll)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceAllByCurrency(CurrentUserEntity.BranchCode, this.View.Currency));
                else if (this.View.ACTypeCurrent)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceByAcSignAndCurrency(CurrentUserEntity.BranchCode, "C", this.View.Currency));
                else if (this.View.ACTypeSaving)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceByAcSignAndCurrency(CurrentUserEntity.BranchCode, "S", this.View.Currency));
                else if (this.View.ACTypeFixed)
                {
                    this.isFixedBal = true;
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceFixed(CurrentUserEntity.BranchCode, this.View.Currency));
                }
                else if (this.View.ACTypeOD)
                    return CXClientWrapper.Instance.Invoke<IMNMSVE00053, IList<MNMDTO00035>>(x => x.GetLedgerBalanceOverdraftAndCurrency(CurrentUserEntity.BranchCode, this.View.Currency));
            }
            return null;
        }

        public string GetFormName()
        {
           string formName = string.Empty;
           if (this.view.ACTypeAll)
               formName = "Listing for Ledger Balance (All) as at " + DateTime.Now.ToString("dd / MM / yyyy");
            else if(this.view.ACTypeCurrent)
               formName = "Listing for Ledger Balance (Current A/C) as at " + DateTime.Now.ToString("dd / MM / yyyy");
            else if(this.view.ACTypeFixed)
               formName = "Listing for Ledger Balance (Fixed Deposit A/C) as at " + DateTime.Now.ToString("dd / MM / yyyy");
            else if(this.view.ACTypeOD)
               formName = "Listing for Ledger Balance (Overdraft) as at " + DateTime.Now.ToString("dd / MM / yyyy");
            else if(this.view.ACTypeSaving)
               formName = "Listing for Ledger Balance (Saving A/C) as at " + DateTime.Now.ToString("dd / MM / yyyy");

          return formName;
        }

        public void Print()
        {
            if (this.ValidateForm())
            {
                this.isFixedBal = false;
                IList<MNMDTO00035> ledgerList = new List<MNMDTO00035>();
                ledgerList = this.GetList();
                if (ledgerList.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
                else
                {
                    if (this.View.SortAccountNo)
                    {
                        ledgerList = ledgerList.OrderBy(x => x.AcctNo).ToList();
                    }
                    else
                    {
                        ledgerList = ledgerList.OrderBy(x => x.Cbal).ToList();
                    }
                    if (this.view.ACTypeSaving)
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00163", true, new object[] { ledgerList, this.GetFormName(), this.isFixedBal, this.View.Currency }); 
                    }
                    else 
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00102", true, new object[] { ledgerList, this.GetFormName(), this.isFixedBal, this.View.Currency });
                    }
                }
            }
        }

        public void cboCurrency_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!this.View.IsAllCurrency)
            {
                if(string.IsNullOrEmpty(this.View.Currency))
                   this.SetCustomErrorMessage(this.GetControl("cboCurrency"), "MV00020");  //Invalid Currency Code
                else
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), string.Empty);
            }
        }
        #endregion
    }
}
