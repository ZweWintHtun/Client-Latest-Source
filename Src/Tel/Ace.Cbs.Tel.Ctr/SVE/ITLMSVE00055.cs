using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;


namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00055 : IBaseService
    {
        IList<TLMDTO00058> SelectDomesticDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
        IList<TLMDTO00058> SelectDomesticReversalDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
        IList<TLMDTO00058> SelectDomesticHomeDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
        IList<TLMDTO00058> SelectDomesticHomeReversalDayBook(DateTime requireDate, int createdUserId, string currencyCode, string sourceBr, string workStation, bool issettlmedate, bool sortByTime);
    }
}
