//----------------------------------------------------------------------
// <copyright file="TLMSVE00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-06-24</CreatedDate>
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
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.Contracts.Dao;

namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00045:BaseService,ITLMSVE00045
   {
       #region "Properties"

       private ITLMDAO00016 poDAO;
       public ITLMDAO00016 PODAO
       {
           get;
           set;
       }
       #endregion 

       #region "Main Methods"
       public IList<TLMDTO00016> GetPOOutstandingReport(string SourceBr)
       {
           IList<TLMDTO00016> polist = PODAO.SelectPOByPOOutstandingNormal(SourceBr);
           return polist;           
       }
       #endregion
   }
}
