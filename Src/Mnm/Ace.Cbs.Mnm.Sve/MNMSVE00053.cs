using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00053 : BaseService,IMNMSVE00053
    {
        ICXDAO00009 ViewDAO { get; set; }

        public IList<MNMDTO00035> GetLedgerBalanceAllByCurrency(string sourceBr, string cur)
        {
            return this.ViewDAO.SelectLedgerBalanceAllByCurrency(sourceBr, cur);
        }

        public IList<MNMDTO00035> GetLedgerBalanceByAcSignAndCurrency(string sourceBr, string AcSign, string cur)
        {
            return this.ViewDAO.SelectLedgerBalanceByAcsignAndCurrency(sourceBr, AcSign, cur);
        }

        public IList<MNMDTO00035> GetLedgerBalanceFixed(string sourceBr,string cur)
        {
            return this.ViewDAO.SelectLedgerBalanceByFixedAccount(sourceBr,cur);
        }

        public IList<MNMDTO00035> GetLedgerBalanceAllByAllCurrency(string sourceBr)
        {
            return this.ViewDAO.SelectLedgerBalanceAllByAllCurrency(sourceBr);
        }

        public IList<MNMDTO00035> GetLedgerBalanceByAcSignAndAllCurrency(string sourceBr, string AcSign)
        {
            return this.ViewDAO.SelectLedgerBalanceByAcsignAndAllCurrency(sourceBr, AcSign);
        }

        public IList<MNMDTO00035> GetLedgerBalanceFixedAndAllCurrency(string sourceBr)
        {
            return this.ViewDAO.SelectLedgerBalanceByFixedAccountAndAllCurrency(sourceBr);
        }

        public IList<MNMDTO00035> GetLedgerBalanceOverdraftAndAllCurrency(string sourceBr)
        {
            return this.ViewDAO.SelectLedgerBalanceByOverdraftAndAllCurrency(sourceBr);
        }

        public IList<MNMDTO00035> GetLedgerBalanceOverdraftAndCurrency(string sourceBr, string cur)
        {
            return this.ViewDAO.SelectLedgerBalanceByOverdraftAndCurrency(sourceBr, cur);
        }
    }
}
