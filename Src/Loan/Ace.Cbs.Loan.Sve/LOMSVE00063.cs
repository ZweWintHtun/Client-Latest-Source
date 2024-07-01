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
    public class LOMSVE00063 : BaseService, ILOMSVE00063
    {
        #region Properties
        public ILOMDAO00063 NonPerformanceLoansCaseListingDAO { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectNonPerformanceLoansCase(LOMDTO00013 dto)
        {
            IList<LOMDTO00013> DataList = new List<LOMDTO00013>();
            DataList = NonPerformanceLoansCaseListingDAO.SelectNonPerformanceLoansCase(dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalSueCaseList(LOMDTO00013 dto)
        {
            IList<LOMDTO00013> DataList = new List<LOMDTO00013>();
            DataList = NonPerformanceLoansCaseListingDAO.SelectLegalSueCaseList(dto.StartDate,dto.EndDate,dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00013> SelectLegalSueCaseClose(LOMDTO00013 dto)
        {
            IList<LOMDTO00013> DataList = new List<LOMDTO00013>();
            DataList = NonPerformanceLoansCaseListingDAO.SelectLegalSueCaseClose(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

    }
}
