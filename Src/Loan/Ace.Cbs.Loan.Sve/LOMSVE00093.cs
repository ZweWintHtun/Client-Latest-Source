using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00093 : BaseService, ILOMSVE00093
    {
        #region Constructor

        public LOMSVE00093() { }

        #endregion

        #region Properties
        
        private ILOMDAO00093 farmLoanReportDAO;
        public ILOMDAO00093 FarmLoanReportDAO
        {
            get { return this.farmLoanReportDAO; }
            set { this.farmLoanReportDAO = value; }
        }

        private ILOMDAO00094 lsFarmLoanReportDAO;
        public ILOMDAO00094 LSFarmLoanReportDAO
        {
            get { return this.lsFarmLoanReportDAO; }
            set { this.lsFarmLoanReportDAO = value; }
        }
        
        #endregion

        #region Select Methods

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanType(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAllByLoanType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr,dto.LoanType);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllLiveStockByLoanType(LOMDTO00093 dto)
        {
            IList<LOMDTO00094> DataList = new List<LOMDTO00094>();
            DataList = this.LSFarmLoanReportDAO.SelectAllByLoanType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.LoanType);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanTypeBySeasonType(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAllByLoanTypeBySeasonType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.SeasonDesp, dto.LoanType);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByLoanTypeByCropType(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAllByLoanTypeByCropType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.CropDesp, dto.LoanType);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllByLoanTypeByBusinessType(LOMDTO00093 dto)
        {
            IList<LOMDTO00094> DataList = new List<LOMDTO00094>();
            DataList = this.LSFarmLoanReportDAO.SelectAllByLoanTypeByBusinessType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.CropDesp,dto.LoanType);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAll(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAll(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00094> SelectAllLS(LOMDTO00093 dto)
        {
            IList<LOMDTO00094> DataList = new List<LOMDTO00094>();
            DataList = this.LSFarmLoanReportDAO.SelectAll(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllBySeasonType(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAllBySeasonType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.SeasonDesp);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00093> SelectAllByCropType(LOMDTO00093 dto)
        {
            IList<LOMDTO00093> DataList = new List<LOMDTO00093>();
            DataList = this.FarmLoanReportDAO.SelectAllByCropType(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr, dto.CropDesp);
            return DataList;
        }

        #endregion
    }
}
