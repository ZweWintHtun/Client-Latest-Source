//----------------------------------------------------------------------
// <copyright file="TLMSVE00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-09-05</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00050:BaseService,ITLMSVE00050
    {
       #region DAO Properties
       public ICXDAO00009 ViewDAO { get; set; }

       #endregion

       #region "Methods"
       public IList<TLMDTO00037> SelectAllView()
       {
           //to use if Date time picker is no date,
           IList<TLMDTO00037> iblTestKeyListingReportView = ViewDAO.SelectIBLTestKeyListingReport();
           return iblTestKeyListingReportView;
       }

       public string SelectMaxDate(DateTime datetime)
       {
           Nullable<DateTime> startdate = ViewDAO.SelectMaxDate(datetime);
           string maxdate = Convert.ToString(startdate);
           return maxdate;
       }

       public IList<TLMDTO00037> SelectAllIBLTestKeyListingByMaxDate(DateTime date)
       {
           IList<TLMDTO00037> IBLTestKeyAlllist = this.SelectAllView();
          // DateTime maxdate = this.SelectMaxDate(date);

               //to retrieve select * from view where datetime=maxdate;
           IBLTestKeyAlllist = ViewDAO.SelectAllIBLTestKeyListingByMaxDate(date);
           
          
           return IBLTestKeyAlllist;


       }
       #endregion
    }
    
}
