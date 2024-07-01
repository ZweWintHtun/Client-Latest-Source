using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00405 : IBaseService
    {
        ILOMDAO00405 BLInterestDuePreListingDAO { get; set; }
        //IList<LOMDTO00405> SelectBLInterestDuePrelistingByDueDate(LOMDTO00405 dto);
       
        IList<LOMDTO00406> SelectBLInterestDuePrelistingByDueDate(LOMDTO00406 dto);

        IList<LOMDTO00405> SelectBLlistingByGrade(LOMDTO00405 dto);

        IList<LOMDTO00405> SelectBLServiceChargeslistingByDate(LOMDTO00405 dto);

        IList<TLMDTO00018> SelectBusinessLoansNoBySourceBr(string sourceBr);

        //LOMDTO00405 SelectBLInfolistingByBLNo(LOMDTO00405 dto);
        IList<LOMDTO00406> SelectBLInfolistingByBLNo(LOMDTO00406 dto);

        IList<LOMDTO00405> SelectBLRepaymentInfolistingByRepayDate(LOMDTO00405 dto);

        IList<LOMDTO00406> SelectBLNPLlistingByNPLDate(LOMDTO00406 dto);

        IList<LOMDTO00406> BLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);

        IList<LOMDTO00406> BLAbsentHistory_Enquiry(string acctno, string sourceBr);

        // For BL Daily Position Listing
        IList<LOMDTO00001> GetAllBLType();

        IList<LOMDTO00423> GetBLDailyPositionListing(string loanGroup, string sourceBr);

        // For Account Information Enquiry
        IList<LOMDTO00423> GetAllCustomerInformation(string name, string nrc, bool isNameExact, bool isNRCExact, string aCType, string sType);

        TLMDTO00018 CountofLoan_byAccountNo(string accountNo, string TranName);
    }
}
