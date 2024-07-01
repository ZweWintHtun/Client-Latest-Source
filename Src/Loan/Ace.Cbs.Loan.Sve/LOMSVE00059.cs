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
    public class LOMSVE00059 : BaseService, ILOMSVE00059
    {
        #region Properties
        public ILOMDAO00059 ODLimitChangeByDateListingDAO { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00059> SelectODLimitChangeByDate(LOMDTO00059 dto)
        {
            IList<LOMDTO00059> DataList = new List<LOMDTO00059>();
            DataList = ODLimitChangeByDateListingDAO.SelectODLimitChangeByDate(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00059> SelectODLimitChangeByAccount(LOMDTO00059 dto)
        {
            IList<LOMDTO00059> DataList = new List<LOMDTO00059>();
            DataList = ODLimitChangeByDateListingDAO.SelectODLimitChangeByAccount(dto.StartDate, dto.EndDate,dto.AcctNo, dto.Cur, dto.SourceBr);
            return DataList;
        }
    }
}
