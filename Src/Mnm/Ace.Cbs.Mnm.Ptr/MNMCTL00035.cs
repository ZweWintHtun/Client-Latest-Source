using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
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

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00035 : AbstractPresenter, IMNMCTL00035
    {
        private IMNMVEW00035 view;
        public IMNMVEW00035 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00035 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        private PFMDTO00054 GetCompanyEntity()
        {
            PFMDTO00054 companyEntity = new PFMDTO00054();
            companyEntity.BranchName = CurrentUserEntity.IsHOUser ? this.view.IsAllBranches ? string.Empty : this.view.BranchNo : CurrentUserEntity.BranchCode;
            //companyEntity.BranchName = this.View.BranchNo;
            companyEntity.CurrencyCode = this.View.Currency;
            return companyEntity;
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetCompanyEntity());
        }

        public void Print()
        {
            PFMDTO00042 ReportTlfDTO = this.GetViewData();
            PFMDTO00042 TrScrollTotal = CXClientWrapper.Instance.Invoke<IMNMSVE00035, PFMDTO00042>(x => x.GetTotalBalCashClear(ReportTlfDTO));
            ReportTlfDTO.ClearingTotal = TrScrollTotal.ClearingTotal;
            ReportTlfDTO.TotalCash = TrScrollTotal.TotalCash;
            ReportTlfDTO.SourceBranch = CurrentUserEntity.IsHOUser ? this.view.IsAllBranches ? string.Empty : this.view.BranchNo : CurrentUserEntity.BranchCode;
            ReportTlfDTO.IsAllBranches = view.IsAllBranches;
            ReportTlfDTO.DATE_TIME = view.RequiredDate;
            IList<MNMDTO00033> TRScrollList = new List<MNMDTO00033>();
            TRScrollList = CXClientWrapper.Instance.Invoke<IMNMSVE00035, IList<MNMDTO00033>>(x => x.GetReturnTransferData(ReportTlfDTO));

            if (TRScrollList.Count > 0)
            {
                if (ReportTlfDTO.IsWithReversal == true)
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00082TransferScrollReprot", true, new object[] { true, "Transfer Scroll", TRScrollList, ReportTlfDTO });
                }
                else
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00082TransferScrollReprot", true, new object[] { false, "Transfer Scroll", TRScrollList, ReportTlfDTO });
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
        }

        public void cboBranchNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.View.IsAllBranches)
            {
                if (string.IsNullOrEmpty(this.View.BranchNo))
                    this.SetCustomErrorMessage(this.GetControl("cboBranchNo"), "MV90029");  //Invalid Branch Code
                else
                    this.SetCustomErrorMessage(this.GetControl("cboBranchNo"), string.Empty);
            }
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!this.View.IsHomeCurrency)
            {
                if(string.IsNullOrEmpty(this.View.Currency))
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), "MV00020");  //Invalid Currency Code
                else
                    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), string.Empty);
            }
        }

        #region "View Datas"
        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ReportTLFData = new PFMDTO00042();
            ReportTLFData.DateType = this.view.DateType;
            ReportTLFData.CurrencyType = this.view.CurrencyType;
            ReportTLFData.StartDate = this.view.RequiredDate;
            ReportTLFData.IsHomeCurrency = this.view.IsHomeCurrency;
            ReportTLFData.IsWithReversal = this.view.IsWithReversal;
            //*
            ReportTLFData.SourceBranch = CurrentUserEntity.IsHOUser ? this.view.IsAllBranches ? string.Empty : this.view.BranchNo : CurrentUserEntity.BranchCode;
            //
            //ReportTLFData.SourceBranch = this.view.BranchNo;
            ReportTLFData.SourceCur = this.view.Currency;
            ReportTLFData.WorkStation = CurrentUserEntity.WorkStationId.ToString();
            ReportTLFData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            ReportTLFData.BranchName = CurrentUserEntity.BranchDescription;
            return ReportTLFData;
        }
        #endregion
    }
}
