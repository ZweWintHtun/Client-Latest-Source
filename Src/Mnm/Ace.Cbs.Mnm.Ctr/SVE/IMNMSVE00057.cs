using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00057 : IBaseService
    {
        IList<PFMDTO00017> GetCurrentAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        IList<PFMDTO00017> GetSavingAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        IList<PFMDTO00017> GetBusinessLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr); // Added By HWKO (23-Jun-2017)
        IList<PFMDTO00017> GetHirePurchaseLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr); // Added By HWKO (23-Jun-2017)
        IList<PFMDTO00017> GetPersonalLoanAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr); // Added By HWKO (23-Jun-2017)
        IList<PFMDTO00017> GetDealerAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr);// Added by HWKO (04-Aug-2017)
    }
}
