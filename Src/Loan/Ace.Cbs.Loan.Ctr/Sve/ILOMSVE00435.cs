using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00435
    {
        IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo);
        string SaveWarningLists(LOMDTO00427 WarningListDTO, string DOB);

        LOMDTO00427 SelectUserMakerCheckerApproveByUserId(int CurrentUserID, string BranchCode);

        IList<LOMDTO00429> SelectAllWarningListsForApproveReject();
        string SaveWarningListsApproveReject(string idArray, int userId, string branchCode, string approveReject);

        IList<LOMDTO00427> GetAllWarningListByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr);

        IList<LOMDTO00427> GetAllWarningListHistoryByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr);
    }
}
