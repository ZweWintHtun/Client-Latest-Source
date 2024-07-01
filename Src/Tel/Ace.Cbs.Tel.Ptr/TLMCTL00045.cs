//----------------------------------------------------------------------
// <copyright file="TLMCTL00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
  public class TLMCTL00045:AbstractPresenter,ITLMCTL00045
  {
      #region "Wire To"
      private ITLMVEW00045 poOutstandingReportview;
        public ITLMVEW00045 View
        {
            get { return this.poOutstandingReportview; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00045 view)
        {
            if (this.poOutstandingReportview == null)
            {
                this.poOutstandingReportview = view;
                this.Initialize(this.poOutstandingReportview, new TLMDTO00045());
            }
        }
      #endregion

      #region"Methods"
        public IList<TLMDTO00016> GetPrintData(string SourceBr)
        {
            IList<TLMDTO00016> PoDenoList = new List<TLMDTO00016>();

            return PoDenoList = CXClientWrapper.Instance.Invoke<ITLMSVE00045, TLMDTO00016>(x => x.GetPOOutstandingReport(SourceBr));

            //List<TLMDTO00016> POOutstandingReportList = new List<TLMDTO00016>();
            //if (PoDenoList.Count != 0 )
            //{
            //    for (int i = 0; i < PoDenoList.Count; i++)
            //    {
            //        TLMDTO00016 DenoOutstanding = new TLMDTO00016();
            //        DenoOutstanding.AccountNo = PoDenoList[i].ACode;
            //        DenoOutstanding.PONo = PoDenoList[i].PONo;
            //        DenoOutstanding.SettlementDate = PoDenoList[i].ADate;
            //        DenoOutstanding.IDate = PoDenoList[i].IDate;
            //        DenoOutstanding.Amount = PoDenoList[i].Amount;
            //        DenoOutstanding.Status = PoDenoList[i].Status;
            //        DenoOutstanding.Currency = PoDenoList[i].Currency;
            //        DenoOutstanding.SourceBranchCode = PoDenoList[i].SourceBranchCode;


            //        POOutstandingReportList.Add(DenoOutstanding);
            //    }
            //}
         
            //return PoDenoList;

        }
      #endregion
  }
}
