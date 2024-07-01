using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00008 :AbstractPresenter, ITLMCTL00008
    {
        private ITLMVEW00008 view;
        public ITLMVEW00008 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00008 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        private PFMDTO00028 GetViewData()
        {
            PFMDTO00028 dto = new PFMDTO00028();
            dto.CurrentBal = this.view.Amount;
            dto.CurrencyCode = this.view.Currency;
            dto.SourceBranchCode = this.view.BranchCode;
            return dto;
        }

        public void CalculateCharges(decimal amount, string branchCode, string currency, bool takeIncomeSeperately)
        {
            if (this.ValidateForm(this.GetViewData()))
            {               
                CXDTO00005 getValues = CXCLE00015.Instance.CalculateCharges(branchCode, currency, amount, takeIncomeSeperately,CurrentUserEntity.BranchCode);
                if (getValues != null)
                {
                    this.View.RemittanceAmount = getValues.RemittanceAmount;
                    this.View.Income = getValues.Commission;
                    this.View.CommunicationCharges = getValues.CommunicationCharges;
                }
            }
        }

        public IList<BranchDTO> GetAllBranchList()
        {
            return CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.Select").Where( x => x.BranchCode != CurrentUserEntity.BranchCode ).ToList();
        }

        public void Clearing()
        {
            this.View.Amount = 0;
            this.View.RemittanceAmount = 0;
            this.View.Income = 0;
            this.View.CommunicationCharges = 0;
            this.ClearAllCustomErrorMessage();
        }
    }
}
