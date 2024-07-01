using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00316 : BaseService, ILOMSVE00316
    {
        #region Constructor

        public LOMSVE00316() { }

        #endregion

        #region Properties

        private ILOMDAO00316 plRepaymentScheduleListingDAO;
        public ILOMDAO00316 PLRepaymentScheduleListingDAO
        {
            get { return this.plRepaymentScheduleListingDAO; }
            set { this.plRepaymentScheduleListingDAO = value; }
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectByPLNO(LOMDTO00316 dto)
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            //DataList = this.PLRepaymentScheduleListingDAO.SelectByPLNO(dto.PLNO, dto.SourceBr);//commented by AAM(12_Sep_2018)
            DataList = this.PLRepaymentScheduleListingDAO.SelectByPLNO(dto.ACNo, dto.SourceBr);//Modified by AAM(12_Sep_2018)
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectByDueDateForPLIntDuePreListing(LOMDTO00316 dto)
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            DataList = this.PLRepaymentScheduleListingDAO.SelectByDueDateForPLIntDuePreListing(dto.StartDate,dto.EndDate, dto.SourceBr,dto.Cur);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLOverdrawnListing(LOMDTO00316 dto)
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            DataList = this.PLRepaymentScheduleListingDAO.SelectPLOverdrawnListing(dto.SourceBr, dto.Cur,dto.StartDate,dto.EndDate);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLOverdrawnListingByCompanyName(LOMDTO00316 dto)
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            DataList = this.PLRepaymentScheduleListingDAO.SelectPLOverdrawnListingByCompanyName(dto.SourceBr, dto.Cur, dto.CompanyName );
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectCompanyName()
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            DataList = this.PLRepaymentScheduleListingDAO.SelectCompanyName();
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00316> SelectPLRepaymentListing(LOMDTO00316 dto)
        {
            IList<LOMDTO00316> DataList = new List<LOMDTO00316>();
            DataList = this.PLRepaymentScheduleListingDAO.SelectPLRepaymentListing(dto.StartDate,dto.EndDate,dto.SourceBr,dto.Cur);
            return DataList;
        }

        
    }
}
