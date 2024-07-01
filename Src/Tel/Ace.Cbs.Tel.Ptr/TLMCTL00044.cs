//----------------------------------------------------------------------
// <copyright file="TLMCTL00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-21</CreatedDate>
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
    public class TLMCTL00044 : AbstractPresenter, ITLMCTL00044
    {
        #region "Wire To"
        private ITLMVEW00044 denominationOutstandingMultipleTransactionView;
        public ITLMVEW00044 DenominationOutstandingMultipleTransactionView
        {
            get { return this.denominationOutstandingMultipleTransactionView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00044 view)
        {
            if (this.denominationOutstandingMultipleTransactionView == null)
            {
                this.denominationOutstandingMultipleTransactionView = view;
                this.Initialize(this.denominationOutstandingMultipleTransactionView, new TLMDTO00009());
            }
        }
        #endregion

        #region "Methods"
        public IList<TLMDTO00009> GetPrintData()
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            IList<TLMDTO00009> DenoOutstandingMultipleTransactionReportList = new List<TLMDTO00009>();

            DenoOutstandingMultipleTransactionReportList = CXClientWrapper.Instance.Invoke<ITLMSVE00044, TLMDTO00009>(x => x.SelectAllView(sourceBr));
            return DenoOutstandingMultipleTransactionReportList;
        }
        #endregion
    }    
}
