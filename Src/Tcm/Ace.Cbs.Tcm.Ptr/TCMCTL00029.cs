//----------------------------------------------------------------------
// <copyright file="TCMCTL00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-12-05</CreatedDate>
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
    /// Clean Cash OD Report Controller
    /// </summary>
    public class TCMCTL00029 : AbstractPresenter, ITCMCTL00029
    {
        private ITCMVEW00029 _view;

        public ITCMVEW00029 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00029 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetOverDraftData());
            }
        }

        private PFMDTO00042 GetOverDraftData()
        {
            PFMDTO00042 dto = new PFMDTO00042();
            dto.DATE_TIME = this._view.SelectedDateTime;
            dto.SourceCur = this._view.Currency;
            return dto;
        }

        #region Helper Mehtods

        public void ClearingCustomerErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        #endregion

        #region Data Properties


        private IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Print Method

        public void Print()
        {
            if (this.ValidateForm(this.GetOverDraftData()))
            {
                string workstation = CurrentUserEntity.WorkStationId.ToString();
                this.PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00029, IList<PFMDTO00042>>(x => x.GetOverDraftData(
                    this._view.SelectedDateTime, this._view.Currency, workstation,
                    this._view.isReversal, this._view.IsTransactionDate, CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
                if (this.PrintDataList.Count < 1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
                else
                {
                    IList<PFMDTO00042> sendDataList = new List<PFMDTO00042>();
                    if (this._view.SortByTime)
                    {
                        sendDataList = this.PrintDataList.OrderBy(x => x.DATE_TIME.Value.ToShortTimeString()).ToList();
                    }
                    else
                    {
                        sendDataList = this.PrintDataList.OrderBy(x => x.AcctNo).ToList();
                    }

                    CXUIScreenTransit.Transit("frmTCMCleanCashODReport", true, new object[] { sendDataList, this._view.SelectedDateTime.ToString("yyyy/MM/dd"), (this._view.isReversal) ? "(Reversal)" : "(Without Reversal)" });
                }
            }
        }

        #endregion
    }
}
