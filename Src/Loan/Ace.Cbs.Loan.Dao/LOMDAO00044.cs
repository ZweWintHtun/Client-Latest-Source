using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction.Interceptor;
using NHibernate;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00044 : DataRepository<MNMORM00017>, ILOMDAO00044
    {
        [Transaction(TransactionPropagation.Required)]
        public string CalculateODInterest(LOMDTO00044 dto)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CALCULATEODINTEREST");
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                { 
                    query.SetDecimal("DAYSINYEAR", (366)); 
                }
                else
                { 
                    query.SetDecimal("DAYSINYEAR", (365)); 
                }                    
                query.SetDateTime("QTRDATE", dto.InterestCalculationDate);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

    }
}
