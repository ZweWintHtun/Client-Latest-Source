using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;


namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00053 : IBaseService
    {
       IList<TLMDTO00058> SelectCurrentDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
       IList<TLMDTO00058> SelectCurrentReversalDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
       IList<TLMDTO00058> SelectCurrentHomeDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
       IList<TLMDTO00058> SelectCurrentHomeReversalDayBook(DateTime requireDate, int createdUserId, string acode, string currencyCode, string sourceBr, string workStation, bool issettlmedate,bool sortByTime);
    }
}
