using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Dao;
using NHibernate;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00027:DataRepository<MNMORM00027>,IMNMDAO00027
    {
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("SChargeDAO.SelectMaxId");
            MNMDTO00027 dto = query.UniqueResult<MNMDTO00027>();
            return dto.Id;
        }

        public IList<MNMDTO00027> SelectByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00027.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<MNMDTO00027>();
            //return query.UniqueResult<MNMDTO00027>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateSChargeForInterestEdit(string accountNo, decimal lastInterest, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId)
        {
            IQuery query = this.Session.CreateQuery("Update MNMORM00027 set " + month1 + " = :interest1 , " + month2 + " = :interest2 , " + month3 + " = :interest3 , LastInt = :lastInterest , UpdatedDate = :updatedDate , UpdatedUserId = :updatedUserId where Acctno = :accountNo");
            query.SetDecimal("interest1", interest1);
            query.SetDecimal("interest2", interest2);
            query.SetDecimal("interest3", interest3);
            query.SetDecimal("lastInterest", lastInterest);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        //LOMSVE00016 (Legal Case Entry)
        public MNMDTO00027 SelectSCharge(string InterestMonths, string budmth, string accountNo, string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00027.SelectByAccountNoAndLoanNo");
            //query.SetString("InterestMonths", InterestMonths);
            query.SetString("budmth", budmth);
            query.SetString("accountNo", accountNo);
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<MNMDTO00027>();
        }

        public IList<MNMDTO00027> SelectByLoanNo(string accountNo, string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00027.SelectByLoanNo");
            query.SetString("accountNo", accountNo);
            query.SetString("loanNo", loanNo);
            return query.List<MNMDTO00027>();
        }




        public IList<MNMDTO00027> SelectByLoansNo(string loanNo, string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00027.SelectByLoansNo");

            query.SetString("loanNo", loanNo);
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00027>();
        }
    }
}
