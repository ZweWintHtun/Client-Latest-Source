using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00152 : IBaseService
    {
        IList<MNMDTO00077> GetReportFixedAutoRenewalOnlyPrinciple(DateTime startDate, DateTime endDate,string cur,string status,string sourceBr, string formName);
    }
}
