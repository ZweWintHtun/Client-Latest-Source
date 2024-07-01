//----------------------------------------------------------------------
// <copyright file="TLMSVE00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
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

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00044:BaseService,ITLMSVE00044
    {

       #region DAO Properties
       public ICXDAO00009 ViewDAO { get; set; }

       #endregion

       #region "Methods"
       public IList<TLMDTO00009> SelectAllView(string sourceBr)
       {

           IList<TLMDTO00009> multipledenoOutstandingReportView = ViewDAO.SelectMultiTransactionDenoOutstandingReport(sourceBr);
           return multipledenoOutstandingReportView;
       }
       #endregion
    }
}
