using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00300 : BaseService, ILOMSVE00300
    {
        #region Properties

        ILOMDAO00078 FarmLoanDAO { get; set; }
        ILOMDAO00300 FarmLoanPenalFeeDAO { get; set; }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public void CalculateFarmLoanPenalFee(string sourceBr)
        {
            this.FarmLoanPenalFeeDAO.CalculateFarmLoanPenalFee(sourceBr);
        }
    }
}
