using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00051 : BaseService, ILOMSVE00051
    {
        #region Properties
        public ILOMDAO00051 ExpireLoansListingDAO { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectExpireLoansByCur(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ExpireLoansListingDAO.SelectExpireLoansByCur(dto.RequiredYear,dto.RequiredMonth, dto.Cur, dto.SourceBr);
            return DataList;
        }
    }
}
