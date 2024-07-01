using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{
    /// <summary>
    /// LegalDAO
    /// </summary>
    public class LOMDAO00013 : DataRepository<LOMORM00013>, ILOMDAO00013
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalInfoByLoanNo(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LegalDAO.SelectLegalInfoByLoanNo");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            return query.List<LOMDTO00013>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateIntRate(decimal intRate, string loanNo, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00013.UpdateIntRate");
            query.SetDecimal("intRate", intRate);
            query.SetString("lno", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectAllByLoanNo(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00013.SelectLegalInfoByLoanNo");
            query.SetString("lno", lno);           
            query.SetString("sourceBr", sourceBr);
            return query.List<LOMDTO00013>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLegalForReleaseCase(string lno, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00013.UpdateLegalForReleaseCase");
            query.SetString("lno", lno);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalInfoByCloseDateNull(string lno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00013.SelectLegalInfoByCloseDateNull");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            return query.List<LOMDTO00013>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpateLegalForLoanRepay(decimal currentBalance,string voucherNumber,string acctNo,string lno,string sourceBr,int currentUserId)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00013.UpateLegalForLegalLoanRepay");
            query.SetString("lno", lno);
            query.SetString("accountNo", acctNo);
            query.SetString("voucherNumber", voucherNumber);
            query.SetDecimal("currentBalance", currentBalance);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", currentUserId);            
            return query.ExecuteUpdate() > 0;
        }
    }
}
