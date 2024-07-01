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
    public class LOMSVE00314 : BaseService, ILOMSVE00314
    {
        #region Constructor

        public LOMSVE00314() { }

        #endregion

        #region Properties

        private ILOMDAO00314 expireLandLeaseListingDAO;
        public ILOMDAO00314 ExpireLandLeaseListingDAO
        {  
            get { return this.expireLandLeaseListingDAO; }
            set { this.expireLandLeaseListingDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00314> SelectAll(LOMDTO00314 dto)
        {
            IList<LOMDTO00314> DataList = new List<LOMDTO00314>();
            DataList = this.ExpireLandLeaseListingDAO.SelectAll(dto.SourceBr,dto.IsExpiredDate);
            return DataList;
        }
    }
}
