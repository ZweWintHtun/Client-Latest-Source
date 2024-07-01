using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using System.Linq;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Dmd;


namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00025 : AbstractPresenter, ITLMCTL00025
    {
        private ITLMVEW00025 view;
        public ITLMVEW00025 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00025 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetReportTLFEntity());
            }
        }

        private PFMDTO00042 GetReportTLFEntity()
        {
            PFMDTO00042 reportTLFDTO = new PFMDTO00042();
            reportTLFDTO.CounterNo = this.view.AccountNo;
            reportTLFDTO.AcctNo = this.view.AccountNo;
            return reportTLFDTO;
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetReportTLFEntity());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == true)
            {
                return;
            }

            if (CXCLE00012.Instance.CheckAccountNoType(this.view.AccountNo, CXDMD00011.AccountNoType1) || CXCLE00012.Instance.CheckAccountNoType(this.view.AccountNo, CXDMD00011.AccountNoType2))
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    if (this.view.AccountNo.Substring(0, 3) != CurrentUserEntity.BranchCode)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091 , new object[] {CurrentUserEntity.BranchCode});
 
                    }
                    bool isFAOFORCledger = CXClientWrapper.Instance.Invoke<ITLMSVE00027, bool>(x => x.IsInFAOFAccountNoOrInCledgerAcNo(this.view.AccountNo));
                    if (!isFAOFORCledger)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                }
            }

            else if (CXCLE00012.Instance.CheckAccountNoType(this.view.AccountNo, CXDMD00011.DomesticAccountType))
            {
                if (this.view.AccountNo.Substring(3) != "000")
                {
                    string coa = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.Select", new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode, true });
                    if (coa != null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                    }
                    else
                    {
                        // Invalid Account No.
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    }
                }

                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00132);
                    return;
                }
            }

            else
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00199);
                return;
            }

        }
    }
}
