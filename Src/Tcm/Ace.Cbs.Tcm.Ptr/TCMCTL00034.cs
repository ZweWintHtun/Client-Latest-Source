//----------------------------------------------------------------------
// <copyright file="TCMCTL00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>♠ Ye Mann Aung ♠</CreatedUser>
// <CreatedDate>13/12/2013</CreatedDate>
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
    /// Clearing Paid Cheque Report Controller
    /// </summary>
    public class TCMCTL00034 : AbstractPresenter, ITCMCTL00034
    {
        private ITCMVEW00034 _view;

        public ITCMVEW00034 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00034 view)
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
            dto.StartDate = this._view.StartDateTime;
            dto.EndDate = this._view.EndDateTime;
            return dto;
        }

        #region Data Properties


        private IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Print Method 

        public void Print()
        {
            string workstation = CurrentUserEntity.WorkStationId.ToString();
            this.PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00034,IList<PFMDTO00042>>( x => x.GetPrintData(this._view.StartDateTime,this._view.EndDateTime,CurrentUserEntity.CurrentUserID,workstation,this._view.TransactionStatus,CurrentUserEntity.BranchCode));
            if (this.PrintDataList.Count < 1)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
            else
            {
                switch(this._view.TransactionStatus)
                {
                    case "Receipt":
                          CXUIScreenTransit.Transit("frmTCmReceiptReport", true, new object[] { this.PrintDataList, this._view.StartDateTime.ToShortDateString(), this._view.EndDateTime.ToShortDateString() });
                          break;
                        
                    case "POReceipt":
                          CXUIScreenTransit.Transit("frmTCMPOReceipt", true, new object[] { this.PrintDataList, this._view.StartDateTime.ToShortDateString(), this._view.EndDateTime.ToShortDateString() });
                          break;
                }
            }

        }

        #endregion

    }
}
