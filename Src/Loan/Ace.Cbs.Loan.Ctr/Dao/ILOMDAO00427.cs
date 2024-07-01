using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00427 : IDataRepository<LOMORM00010>
    {
        IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo);
        string SaveBlackLists(LOMDTO00427 BlackListDTO, string DOB);

        string SaveBlackLists_ExternalCust(LOMDTO00427 BlackListDTO);

        IList<LOMDTO00429> SelectAllBlackListsForApproveReject();
        string SaveBlackListsApproveReject(string idArray, int userId, string branchCode, string approveReject);

        string SaveBlackListsRemove(string idArray, int userId, string branchCode, string remove);
        IList<LOMDTO00429> SelectAllBlackListsForRemove();

        string SaveWarningListsRemove(string idArray, int userId, string branchCode, string remove);
        IList<LOMDTO00429> SelectAllWarningListsForRemove();

        IList<LOMDTO00427> GetAllBlackListByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr);

        IList<LOMDTO00427> SelectAllUser(string SourceBr);
        IList<LOMDTO00427> SelectAllBlackListMakerCheckerUser(string SourceBr);
        string SaveBlackListUser(string UserName, int CurrentUserID, string BranchCode, string ApproveType);
        string DeleteBlackListUser(string idArray, int CurrentUserID, string BranchCode);

        IList<LOMDTO00427> GetAllBlackListHistoryByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr);

        LOMDTO00427 SelectUserMakerCheckerApproveByUserId(int CurrentUserID, string BranchCode);
    }
}
