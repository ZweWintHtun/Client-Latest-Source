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
    public class LOMSVE00307 : BaseService, ILOMSVE00307
    {
        #region Constructor

        public LOMSVE00307() { }

        #endregion

        #region Properties

        private ILOMDAO00307 farmLoanTotalDailyIncomeReportDAO;
        public ILOMDAO00307 FarmLoanTotalDailyIncomeReportDAO
        {
            get { return this.farmLoanTotalDailyIncomeReportDAO; }
            set { this.farmLoanTotalDailyIncomeReportDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00307> SelectAll(LOMDTO00307 dto)
        {
            IList<LOMDTO00307> DataList = new List<LOMDTO00307>();
            DataList = this.FarmLoanTotalDailyIncomeReportDAO.SelectAll(dto.StartDate,dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }
    }
}
