using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00053 : IBaseService
    {
        IList<MNMDTO00035> GetLedgerBalanceAllByCurrency(string sourceBr, string cur);
        IList<MNMDTO00035> GetLedgerBalanceByAcSignAndCurrency(string sourceBr, string AcSign, string cur);
        IList<MNMDTO00035> GetLedgerBalanceFixed(string sourceBr,string cur);
        IList<MNMDTO00035> GetLedgerBalanceAllByAllCurrency(string sourceBr);
        IList<MNMDTO00035> GetLedgerBalanceByAcSignAndAllCurrency(string sourceBr, string AcSign);
        IList<MNMDTO00035> GetLedgerBalanceFixedAndAllCurrency(string sourceBr);
        IList<MNMDTO00035> GetLedgerBalanceOverdraftAndAllCurrency(string sourceBr);
        IList<MNMDTO00035> GetLedgerBalanceOverdraftAndCurrency(string sourceBr, string cur);
    }
}
