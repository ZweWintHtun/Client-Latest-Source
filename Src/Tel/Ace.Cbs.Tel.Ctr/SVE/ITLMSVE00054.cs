using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;


namespace Ace.Cbs.Tel.Ctr.Sve
{
  public  interface ITLMSVE00054 : IBaseService
    {
      IList<TLMDTO00058> SelectSavingDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate);
      IList<TLMDTO00058> SelectSavingReversalDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate);
      IList<TLMDTO00058> SelectFixedDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate);
      IList<TLMDTO00058> SelectFixedReversalDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate);
    }
}
