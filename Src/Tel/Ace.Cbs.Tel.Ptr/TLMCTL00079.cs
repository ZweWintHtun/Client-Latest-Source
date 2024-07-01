using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00079 : AbstractPresenter, ITLMCTL00079
    {
        #region "Properties
        private bool isValidateForm = false;
        public string AccountNo { get; set; }
        public IList<PFMDTO00021> FledgerInfoLists { get; set; }
        #endregion

        #region "For Initializer"
        private ITLMVEW00079 view;
        public ITLMVEW00079 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00079 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.Print());
            }
        }
        #endregion

        #region "Methods"

        private PFMDTO00054 Print()
        {
            PFMDTO00054 BankStatementListingByDateEntity = new PFMDTO00054();
            if (BankStatementListingByDateEntity != null)
            {
                BankStatementListingByDateEntity.AccountNo = this.View.AccountNo;
            }
            return BankStatementListingByDateEntity;
        }

        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.View.StartDate, this.View.EndDate);
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
                if (CXCLE00012.Instance.IsValidAccountNo(this.View.AccountNo, out accountType))
                {
                    if (this.View.AccountNo.Substring(0, 3) != CurrentUserEntity.BranchCode)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                    }
                    else
                    {
                        PFMDTO00028 CledgerInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(this.View.AccountNo));
                        if (CledgerInfo != null)
                        {

                            if (CledgerInfo.CurrentBal <= 0 && CledgerInfo.CloseDate != null)
                            {
                                // Account No has been closed.
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044);
                                return;
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                            }
                            this.View.isFixedAcc = false;
                            //this.View.ForFAOFAccount(false);
                        }
                        else if (CledgerInfo == null)
                        {
                            FledgerInfoLists = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00021>(x => x.GetCustomerInfoandFAOFInfoByAccountNo(this.View.AccountNo));
                            if (FledgerInfoLists.Count > 0 && FledgerInfoLists.Count > 1)
                            {
                                //this.View.ForFAOFAccount(true);
                            }
                            this.View.isFixedAcc = true;
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

        public void CLedgerMainPrint()
        {
            isValidateForm = true;
            if (this.ValidateForm(this.Print()))
            {
                CXUIScreenTransit.Transit("frmTLMVEW00051", true, new object[] { this.View.AccountNo, this.View.StartDate, this.View.EndDate, "Bank Statement Listing By Date Report", this.View.WithReversal });//Updated By HWKO (17-May-2017)
            }
            this.isValidateForm = false;
        }

        public void FAOFMainPrint()
        {
            isValidateForm = true;
            this.FledgerInfoLists = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(service => service.GetFAOFsByAccountNumber(this.View.AccountNo));
            CXUIScreenTransit.Transit("frmTLMVEW00073", true, new object[] { this.FledgerInfoLists, this.View.AccountNo, false, this.View.StartDate, this.View.EndDate, "Bank Statement Listing By Date For Fixed Deposit A/C Report", this.View.WithReversal });//Updated By HWKO (17-May-2017)
            this.isValidateForm = false;
        }
        #endregion
    }
}
