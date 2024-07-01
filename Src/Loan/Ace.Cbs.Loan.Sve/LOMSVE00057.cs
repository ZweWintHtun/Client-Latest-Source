using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00057 : BaseService, ILOMSVE00057
    {
        #region Properties
        public ILOMDAO00057 ServiceChargesListingDAO { get; set; }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00057> SelectServiceCharges(LOMDTO00057 dto)
        {
            IList<LOMDTO00057> DataList = new List<LOMDTO00057>();
            DataList = ServiceChargesListingDAO.SelectServiceCharges(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }
    }
}
