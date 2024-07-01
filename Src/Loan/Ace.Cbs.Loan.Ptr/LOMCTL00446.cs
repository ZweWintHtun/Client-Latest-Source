using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00446 : AbstractPresenter, ILOMCTL00446
    {
        private ILOMVEW00446 view;
        public ILOMVEW00446 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00446 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00423> GetNeedToExtendAccountInfo()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00444, IList<LOMDTO00423>>(x => x.GetNeedToExtendAccountInfo(this.View.AccountNo));
        }

        public decimal GetAccountCurBalance(string AccountNo)
        {
            return CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.SelectCurrentBalanceByAccountNo(AccountNo)).CurrentBal;
        }

        public string SaveLimitExtendInfo(string UserID, string SourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00444, string>(x => x.SaveLimitExtendInfo(this.View.TotalExtendDuration, this.View.AccountNo, this.View.DocFeeNew, this.View.IntRateNew, UserID, SourceBr, this.View.PreExtend, this.View.SChargeNew));
        }

        //Added by HMW at 29-11-2019 : To show System Date for "Back Date EOD Version"
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 29-11-2019 : To check has overdrawn or not.
        public bool HasOverDrawn(string accountNo, string sourceBr)
        {
            IList<LOMDTO00219> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.BL_OD_LateFees_Outstanding_Listing_By_Account(accountNo, sourceBr));
            if (DTOList == null || DTOList.Count == 0)
                return false;
            else
                return true;
        }

        public LOMDTO00423 GetSanctionAmountInfo(string accountNo,string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00444, LOMDTO00423>(x => x.Get_BL_SanctionAmountInfo(this.View.AccountNo, sourceBr));            
        }

        public PFMDTO00009 SelectByCode(string code)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00444, PFMDTO00009>(x => x.SelectByCode(code));
        }
        
    }
}
