using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00305 : BaseService, ILOMSVE00305
    {
        #region Constructor

        public LOMSVE00305() { }

        #endregion

        #region Properties

        private ILOMDAO00305 farmLoanOSTByWithdrawDateReportDAO;
        public ILOMDAO00305 FarmLoanOSTByWithdrawDateReportDAO
        {
            get { return this.farmLoanOSTByWithdrawDateReportDAO; }
            set { this.farmLoanOSTByWithdrawDateReportDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00305> SelectAll(LOMDTO00305 dto)
        {
            IList<LOMDTO00305> DataList = new List<LOMDTO00305>();
            DataList = this.FarmLoanOSTByWithdrawDateReportDAO.SelectAll(dto.WithdrawDate, dto.Cur, dto.SourceBr, dto.VillageCode, dto.TownshipCode);
            return DataList;
        }
    }
}
