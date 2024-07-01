using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00300 : DataRepository<LOMORM00300>, ILOMDAO00300
    {
        [Transaction(TransactionPropagation.Required)]
        public string CalculateFarmLoanPenalFee(string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_PenalFeeCalculation");
                query.SetString("SourceBr", sourceBr);
                query.SetDecimal("RInterest", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
