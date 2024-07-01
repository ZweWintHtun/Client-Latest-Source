//----------------------------------------------------------------------
// <copyright file="TLMCTL00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-08-23</CreatedDate>
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
   public class TLMCTL00050:AbstractPresenter,ITLMCTL00050
   {
       #region "Wire To"
       private ITLMVEW00050 iblTestKeyListingView;
        public ITLMVEW00050 IBLTestKeyListingView
        {
            get { return this.iblTestKeyListingView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00050 view)
        {
            if (this.iblTestKeyListingView == null)
            {
                this.iblTestKeyListingView = view;
                this.Initialize(this.iblTestKeyListingView, new TLMDTO00037());
            }
        }
       #endregion

       #region "Method"
        public IList<TLMDTO00037> GetPrintData(DateTime date)
        {
           IList<TLMDTO00037> IBlTestKeyListingReportList = new List<TLMDTO00037>();
           #region Old Code
           //string maxdate = CXClientWrapper.Instance.Invoke<ITLMSVE00050,string>(x => x.SelectMaxDate(date));  
          
           //if (!maxdate.Equals(string.Empty))
           //{
           //    DateTime maxdateDateTime = Convert.ToDateTime(maxdate);
           //    //DateTime dated = CXClientWrapper.Instance.Invoke<ITLMSVE00050, DateTime>(x => x.SelectMaxDate(date));
           //    if (maxdateDateTime != null)
           //    {
           //        IBlTestKeyListingReportList = CXClientWrapper.Instance.Invoke<ITLMSVE00050, TLMDTO00037>(x => x.SelectAllIBLTestKeyListingByMaxDate(maxdateDateTime));
           //        if (IBlTestKeyListingReportList.Count==0)
           //        {
           //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");                       
           //        }
           //    }
           //}
           //else
           //{
           //    //this.iblTestKeyListingView.CloseForm();
           //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("ME00028");
           //}
           //return IBlTestKeyListingReportList;           
           #endregion
           
           #region edited code (bug No.497 - request by HMW - (29-12-14)bugList )

           IBlTestKeyListingReportList = CXClientWrapper.Instance.Invoke<ITLMSVE00050, TLMDTO00037>(x => x.SelectAllIBLTestKeyListingByMaxDate(date));
           if (IBlTestKeyListingReportList.Count == 0)
           {
               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
           }
            return IBlTestKeyListingReportList; 

           #endregion          
        }
        public IList<TLMDTO00037> GetALLPrintData()
        {
            IList<TLMDTO00037> IBlTestKeyListingReportList = new List<TLMDTO00037>();
            IBlTestKeyListingReportList = CXClientWrapper.Instance.Invoke<ITLMSVE00050, TLMDTO00037>(x => x.SelectAllView());
            if (IBlTestKeyListingReportList == null)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
            return IBlTestKeyListingReportList;
        }
        #endregion
   }
}
