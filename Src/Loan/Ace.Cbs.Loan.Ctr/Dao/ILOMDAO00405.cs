using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00405 : IDataRepository<LOMVIW00405>
    {

        IList<LOMDTO00406> SelectBLInterestDuePrelistingByDueDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType, string interestPaidStatus);

        IList<LOMDTO00405> SelectBLlistingbyGrade(DateTime startDate, DateTime endDate, string sourceBr, string currency, decimal minimumAmt, decimal maximumAmt, string blType);

        IList<LOMDTO00405> SelectBLServiceChargeslistingByDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType);

        IList<LOMDTO00406> SelectBLInfolistingByBLNo(string acctNo, string currency, string sourceBr);//Updated by HWKO (22-Nov-2017)

        IList<LOMDTO00405> SelectBLRepaymentInfolistingByRepayDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType);

        IList<LOMDTO00406> SelectBLNPLlistingByNPLDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType);

        // For BL Daily Position Listing Added by ZMS [02-Jul-18]
        IList<LOMDTO00423> GetBLDailyPositionListing(string loanGroup, string sourceBr);

        IList<LOMDTO00001> SelectAllBLTypes();

        // For BL Daily Position Listing Added by ZMS [02-Jul-18]
        IList<LOMDTO00423> GetAllCustomerInformation(string name, string nrc, bool isNameExact, bool isNRCExact, string aCType, string sType);

    }
}
