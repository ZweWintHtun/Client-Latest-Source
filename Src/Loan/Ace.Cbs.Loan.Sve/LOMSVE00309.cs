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
    public class LOMSVE00309 : BaseService, ILOMSVE00309
    {
        #region Constructor

        public LOMSVE00309() { }

        #endregion

        #region Properties

        private ILOMDAO00309 farmLoanTotalDailyIncomeReportDAO;
        public ILOMDAO00309 FarmLoanTotalDailyIncomeReportDAO
        {
            get { return this.farmLoanTotalDailyIncomeReportDAO; }
            set { this.farmLoanTotalDailyIncomeReportDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00309> SelectAll(LOMDTO00309 dto)
        {
            IList<LOMDTO00309> DataList = new List<LOMDTO00309>();
            DataList = this.FarmLoanTotalDailyIncomeReportDAO.SelectAll(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }
    }
}
