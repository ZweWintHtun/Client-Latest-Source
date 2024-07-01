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
    public class LOMSVE00042 : BaseService, ILOMSVE00042
    {
        #region Properties
        public ILOMDAO00042 LoansAccountCloseListingDAO { get; set; }
        #endregion

        #region Select Loans Account Close Listing By Loans Type Method
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAll(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = LoansAccountCloseListingDAO.SelectAll(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectLoansOnly(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = LoansAccountCloseListingDAO.SelectLoansOnly(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectODOnly(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = LoansAccountCloseListingDAO.SelectODOnly(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }
        #endregion
    }
}
