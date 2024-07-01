using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00406 : IDataRepository<LOMORM00405>
    {
        string SaveBLDetailsVoucher(string Lno, string Acctno, decimal FirstAmt, DateTime FirstMDueDate, int DAYSINYEAR,
                                          int CreatedUserId, string username, string soucrBr);

        string UpdateBLDetailsLCDecrease(string Lno, string Acctno, decimal LimitChangeAmt, bool LimitChangeState, int LCTermNo,decimal interestForBeforeLC,
                                          int CreatedUserId, string username, string soucrBr);

        string UpdateBLDetailsLCIncrease(string Lno, string Acctno, string Eno, decimal LimitChangeAmt, bool LimitChangeState, int LCTermNo,
                                                decimal ServiceCharges, decimal NewIntRate, decimal DocFee, decimal interestForBeforeLC,
                                         int CreatedUserId, string username, string soucrBr);

        //Modified by HMW at (30-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.    
        string BusinessLoansLateFeesAutoPayVoucherProcess(string sourceBr, int createdUserId, string userName);

        IList<LOMDTO00406> BLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);

        IList<LOMDTO00406> BLAbsentHistory_Enquiry(string acctno, string sourceBr);
        string CheckingCasesBLLimitChange(string blNo, string sourceBr);//Added By AAM(10_Sep_2018)
    }
}
