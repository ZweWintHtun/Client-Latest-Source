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
    public class LOMSVE00035 : BaseService, ILOMSVE00035
    {
        #region Properties
        public ILOMDAO00035 ODRegistrationListingDAO { get; set; }
        #endregion

        #region SelectODDataByLoansType Method
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectODDataByLoansType(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ODRegistrationListingDAO.SelectByLoansType(dto.StartDate, dto.EndDate, dto.Loans_Type, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllODData(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ODRegistrationListingDAO.SelectAll(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllDataByLoansType(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ODRegistrationListingDAO.SelectAllByLoansType(dto.StartDate, dto.EndDate, dto.Loans_Type, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllData(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ODRegistrationListingDAO.SelectAllLoansOD(dto.StartDate, dto.EndDate, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00035> SelectAllLoansDailyPositionByCur(LOMDTO00035 dto)
        {
            IList<LOMDTO00035> DataList = new List<LOMDTO00035>();
            DataList = ODRegistrationListingDAO.SelectAllLoansDailyPositionByCur(dto.Cur, dto.SourceBr);
            return DataList;
        }
        #endregion
    }
}
