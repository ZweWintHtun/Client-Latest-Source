using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Service;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00405 : BaseService, ILOMSVE00405
    {
        #region Constructor

        public LOMSVE00405() { }

        #endregion

        #region Properties

        private ILOMDAO00405 bLInterestDuePreListingDAO;
        public ILOMDAO00405 BLInterestDuePreListingDAO
        {
            get { return this.bLInterestDuePreListingDAO; }
            set { this.bLInterestDuePreListingDAO = value; }
        }
        private ITLMDAO00018 loansDAO;
        public ITLMDAO00018 LoansDAO
        {
            get { return this.loansDAO; }
            set { this.loansDAO = value; }
        }
        private ILOMDAO00406 bLDetailsDAO;
        public ILOMDAO00406 BLDetailsDAO
        {
            get { return this.bLDetailsDAO; }
            set { this.bLDetailsDAO = value; }
        }
        #endregion

        #region Methods
       
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> SelectBLInterestDuePrelistingByDueDate(LOMDTO00406 dto)
        {
            IList<LOMDTO00406> DataList = new List<LOMDTO00406>();
            DataList = this.BLInterestDuePreListingDAO.SelectBLInterestDuePrelistingByDueDate(Convert.ToDateTime(dto.StartDate), Convert.ToDateTime(dto.EndDate), dto.SourceBr, dto.Cur, dto.BLType, dto.InterestStatusDesp);
            return DataList;
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00405> SelectBLlistingByGrade(LOMDTO00405 dto)
        {
            IList<LOMDTO00405> DataList = new List<LOMDTO00405>();
            DataList = this.BLInterestDuePreListingDAO.SelectBLlistingbyGrade(dto.StartDate, dto.EndDate, dto.SourceBranchCode, dto.Currency,Convert.ToDecimal(dto.MinimumAmount),Convert.ToDecimal(dto.MaximumAmount),dto.BusinessLoansTypes);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00405> SelectBLServiceChargeslistingByDate(LOMDTO00405 dto)
        {
            IList<LOMDTO00405> DataList = new List<LOMDTO00405>();
            DataList = this.BLInterestDuePreListingDAO.SelectBLServiceChargeslistingByDate(dto.StartDate, dto.EndDate, dto.SourceBranchCode, dto.Currency,dto.BusinessLoansTypes);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00018> SelectBusinessLoansNoBySourceBr(string sourceBr)
        {
            IList<TLMDTO00018> DataList = new List<TLMDTO00018>();
            DataList = this.loansDAO.SelectBusinessLoansNoBySourceBr(sourceBr);
            return DataList;
        }
        
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> SelectBLInfolistingByBLNo(LOMDTO00406 dto)
        {
            IList<LOMDTO00406> DataList = new List<LOMDTO00406>();
            //Added by HWKO (22-Nov-2017)
            DataList = this.BLInterestDuePreListingDAO.SelectBLInfolistingByBLNo(dto.Acctno, dto.Cur, dto.SourceBr);
            //Commented by HWKO (22-Nov-2017)
           // DataList = this.BLInterestDuePreListingDAO.SelectBLInfolistingByBLNo(dto.Lno, dto.Cur, dto.SourceBr);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00405> SelectBLRepaymentInfolistingByRepayDate(LOMDTO00405 dto)
        {
            IList<LOMDTO00405> DataList = new List<LOMDTO00405>();
            DataList = this.BLInterestDuePreListingDAO.SelectBLRepaymentInfolistingByRepayDate(dto.StartDate, dto.EndDate, dto.SourceBranchCode, dto.Currency,dto.BusinessLoansTypes);
            return DataList;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> SelectBLNPLlistingByNPLDate(LOMDTO00406 dto)
        {
            IList<LOMDTO00406> DataList = new List<LOMDTO00406>();
            DataList = this.BLInterestDuePreListingDAO.SelectBLNPLlistingByNPLDate(Convert.ToDateTime(dto.StartDate), Convert.ToDateTime(dto.EndDate), dto.SourceBr, dto.Cur,dto.BLType);
            return DataList;
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> BLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00406> BlDto = new List<LOMDTO00406>();
            BlDto = this.BLDetailsDAO.BLAbsentHistoryListing(startDate, endDate, acctno, sourceBr);
            if (BlDto == null || BlDto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
                return null;
            }
            else return this.BLDetailsDAO.BLAbsentHistoryListing(startDate, endDate, acctno, sourceBr);
        }
        
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> BLAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            // Modified By AAM (23-Nov-2017)
            IList<LOMDTO00406> BlDto = new List<LOMDTO00406>();
            BlDto = this.BLDetailsDAO.BLAbsentHistory_Enquiry(acctno, sourceBr);

            if (BlDto == null || BlDto.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.ME30012;//Data Not Found.
                return null;
            }//// Modified By AAM (23-Nov-2017)

            if (BlDto[0].chkAcctNo == "-1")
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00046;//Invalid Account No.
            }
            return BlDto;
        }

        #region BLDailyPositionListing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00423> GetBLDailyPositionListing(string loanGroup, string sourceBr)
        {
            IList<LOMDTO00423> dto = null;
            return this.BLInterestDuePreListingDAO.GetBLDailyPositionListing(loanGroup, sourceBr);
            return dto;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00001> GetAllBLType()
        {
            IList<LOMDTO00001> dto = null;
            dto = this.BLInterestDuePreListingDAO.SelectAllBLTypes();
            return dto;
        }
        #endregion

        #region Account Information Enquiry
        public IList<LOMDTO00423> GetAllCustomerInformation(string name, string nrc, bool isNameExact, bool isNRCExact, string aCType, string sType)
        {
            IList<LOMDTO00423> dto = null;
            dto = this.BLInterestDuePreListingDAO.GetAllCustomerInformation(name, nrc, isNameExact, isNRCExact, aCType, sType);
            return dto;
        }

        public TLMDTO00018 CountofLoan_byAccountNo(string accountNo, string TranName)
        {
            return LoansDAO.CountofLoan_byAccountNo(accountNo, TranName);
        }
        #endregion

        #endregion
    }
}
