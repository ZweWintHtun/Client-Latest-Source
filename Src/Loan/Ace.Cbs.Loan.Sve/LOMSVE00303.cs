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
    public class LOMSVE00303 : BaseService, ILOMSVE00303
    {
        #region Constructor

        public LOMSVE00303() { }

        #endregion

        #region Properties

        private ILOMDAO00303 farmLoanOSTReportDAO;
        public ILOMDAO00303 FarmLoanOSTReportDAO
        {
            get { return this.farmLoanOSTReportDAO; }
            set { this.farmLoanOSTReportDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00303> SelectAll(LOMDTO00303 dto)
        {
            IList<LOMDTO00303> DataList = new List<LOMDTO00303>();
            DataList = this.FarmLoanOSTReportDAO.SelectAll(dto.ExpireDate, dto.Cur, dto.SourceBr,dto.VillageCode,dto.TownshipCode);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public object CalculateFarmLoanInterest(LOMDTO00303 dto)
        {
            string withdrawDate = dto.WithdrawDate.ToString("yyyy/MM/dd");
            string dueDate = dto.ExpireDate.ToString("yyyy/MM/dd");
            return this.FarmLoanOSTReportDAO.CalculateFarmLoanInterest(dto.Lno, dto.SAmt, withdrawDate, dueDate, dto.SourceBr);            
        }

        [Transaction(TransactionPropagation.Required)]
        public object CalculateFarmLoanPenalFee(LOMDTO00303 dto)
        {
            return this.FarmLoanOSTReportDAO.CalculateFarmLoanPenalFee(dto.Lno, dto.SAmt,dto.SourceBr);            
        }
    }
}
