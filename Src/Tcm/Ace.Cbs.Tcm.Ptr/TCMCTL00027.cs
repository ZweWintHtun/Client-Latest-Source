//----------------------------------------------------------------------
// <copyright file="TLMCTL00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-04</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// Daily Closing Clearing Report Controller
    /// </summary>
    public class TCMCTL00027:AbstractPresenter,ITCMCTL00027
    {
        #region "Wire To"
        private ITCMVEW00027 _view;
        public ITCMVEW00027 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00027 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetDailyClosingData());
            }
        }
        #endregion

        #region Data Properties
        private IList<PFMDTO00042> PrintDataList { get; set; }
        #endregion

        #region Helper Mehtods 

        public void ClearingCustomerErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        private IList<TCMDTO00027> GetAbstractReportList(IList<PFMDTO00042> datalist)
        {
            var list = (from x in datalist
                        group x by new { x.BankDescription, x.SourceCur }
                            into grp
                            select new
                            {
                                grp.Key.BankDescription,
                                grp.Key.SourceCur,
                                Receipt = grp.Sum(x => x.Receipt),
                                Deliver = grp.Sum(x => x.Deliver)
                            });

            IList<TCMDTO00027> dtolist = new List<TCMDTO00027>();
            foreach (var item in list)
            {
                TCMDTO00027 dto = new TCMDTO00027();
                dto.Receipt = item.Receipt.Value;
                dto.Deliver = item.Deliver.Value;
                dto.BankDescription = item.BankDescription;
                dto.Currency = item.SourceCur;
                foreach (PFMDTO00042 reportdto in datalist.Where(x => x.BankDescription == item.BankDescription && x.SourceCur == item.SourceCur))
                {
                    if (!String.IsNullOrEmpty(reportdto.OtherBankChq))
                        dto.OtherBankChequeCount++;
                    if (!String.IsNullOrEmpty(reportdto.Cheque))
                        dto.BankChequeCount++;
                    else if (String.IsNullOrEmpty(reportdto.Cheque) && reportdto.Eno.ToString().StartsWith("R"))
                        dto.BankChequeCount++;
                }
                dtolist.Add(dto);
            }
            return dtolist;
        }
        private TCMDTO00027 GetDailyClosingData()
        {
            TCMDTO00027 dto = new TCMDTO00027();
            dto.isSchdule = this._view.isSchdule;
            dto.isAbstract = this._view.isAbstract;
            dto.isScroll = this._view.isSchdule;
            dto.isSettlementDate = this._view.isSettlementDate;
            dto.isTransactionDate = this._view.isTransactionDate;
            dto.isReserval = this._view.isReserval;
            dto.Currency = this._view.Currency;
            dto.SelectedDateTime = this._view.SelectedDateTime;
            return dto;
        }


        #endregion

        #region Methods
        public void Print()
        {
            bool isTransaction = (this._view.isTransactionDate) ? true : false;
            if (this._view.isSchdule)
            {
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                this.PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00027, IList<PFMDTO00042>>(x => x.GetScheduleReportData(isTransaction, this._view.SelectedDateTime, workstation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this._view.Currency));
                if (this.PrintDataList.Count < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
                else
                {
                    CXUIScreenTransit.Transit("frmTCMScheduleReport", true, new object[] { this.PrintDataList, this._view.SelectedDateTime.ToString("dd/MM/yyyy"), (this._view.isTransactionDate) ? "Transaction Date" : "Settlement Date" });
                }
            }
            else if (this._view.isAbstract)
            {
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                this.PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00027, IList<PFMDTO00042>>(x => x.GetAbstractReportData(isTransaction, this._view.SelectedDateTime, workstation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this._view.Currency));
                if (this.PrintDataList.Count < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
                else
                {
                    CXUIScreenTransit.Transit("frmTCMAbstractReport", true, new object[] { this.GetAbstractReportList(this.PrintDataList), this._view.SelectedDateTime.ToString("dd/MM/yyyy"), (this._view.isTransactionDate) ? "Transaction Date" : "Settlement Date" });
                }
            }
            else
            {
                bool isReversal = (this._view.isReserval) ? true : false;
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                IList<TCMDTO00027> ScrollDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00027, IList<TCMDTO00027>>
                                                       (x => x.GetScrollData(workstation, this._view.SelectedDateTime, this._view.Currency, isTransaction, isReversal, CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
                if (ScrollDataList.Count < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
                else
                {
                    CXUIScreenTransit.Transit("frmTCMScrollReport", true, new object[] { ScrollDataList, this._view.SelectedDateTime.ToString("dd/MM/yyyy"), (this._view.isTransactionDate) ? "Transaction Date" : "Settlement Date",this._view.Currency, (this._view.isReserval) ? "With Reversal" : "Without Reversal" }) ;
                }
            }
        }
        #endregion
    }
}
