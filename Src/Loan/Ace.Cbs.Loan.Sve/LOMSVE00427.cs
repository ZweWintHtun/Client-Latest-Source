using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00427 : BaseService, ILOMSVE00427
    {
        #region Properties
        private ILOMDAO00427 bLInternalCustEntyDAO;
        public ILOMDAO00427 BLInternalCustEntyDAO
        {
            get { return this.bLInternalCustEntyDAO; }
            set { this.bLInternalCustEntyDAO = value; }
        }
        #endregion

        #region Methods
        public IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo)
        {
            return this.BLInternalCustEntyDAO.GetLoansAccountInfoByACNo(AcctNo);
        }
        public string SaveBlackLists(LOMDTO00427 BlackListDTO, string DOB)
        {
            return this.BLInternalCustEntyDAO.SaveBlackLists(BlackListDTO, DOB);
        }
        public string SaveBlackLists_ExternalCust(LOMDTO00427 BlackListDTO)
        {
            return this.BLInternalCustEntyDAO.SaveBlackLists_ExternalCust(BlackListDTO);
        }
        public IList<LOMDTO00429> SelectAllBlackListsForApproveReject()
        {
            return this.BLInternalCustEntyDAO.SelectAllBlackListsForApproveReject();
        }

        public string SaveBlackListsApproveReject(string idArray, int userId, string branchCode, string approveReject)
        {
            return this.BLInternalCustEntyDAO.SaveBlackListsApproveReject(idArray, userId, branchCode, approveReject);
        }

        public string SaveBlackListsRemove(string idArray, int userId, string branchCode, string remove)
        {
            return this.BLInternalCustEntyDAO.SaveBlackListsRemove(idArray, userId, branchCode, remove);
        }

        public string SaveWarningListsRemove(string idArray, int userId, string branchCode, string remove)
        {
            return this.BLInternalCustEntyDAO.SaveWarningListsRemove(idArray, userId, branchCode, remove);
        }

        public IList<LOMDTO00429> SelectAllBlackListsForRemove()
        {
            return this.BLInternalCustEntyDAO.SelectAllBlackListsForRemove();
        }

        public IList<LOMDTO00429> SelectAllWarningListsForRemove()
        {
            return this.BLInternalCustEntyDAO.SelectAllWarningListsForRemove();
        }

        public IList<LOMDTO00427> GetAllBlackListByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            return this.BLInternalCustEntyDAO.GetAllBlackListByACTypeAndDate(TypeofCust, AccountType, StartDate, EndDate, SourceBr);
        }


        public IList<LOMDTO00427> SelectAllBlackListMakerCheckerUser(string SourceBr)
        {
            return this.BLInternalCustEntyDAO.SelectAllBlackListMakerCheckerUser(SourceBr);
        }

        public IList<LOMDTO00427> SelectAllUser(string SourceBr)
        {
            return this.BLInternalCustEntyDAO.SelectAllUser(SourceBr);
        }
        
        public string SaveBlackListUser( string UserName, int CurrentUserID, string BranchCode,string ApproveType)
        {
            return this.BLInternalCustEntyDAO.SaveBlackListUser(UserName, CurrentUserID, BranchCode, ApproveType);
        }
        
        public string DeleteBlackListUser(string idArray, int CurrentUserID,string BranchCode)
        {
            return this.BLInternalCustEntyDAO.DeleteBlackListUser(idArray, CurrentUserID, BranchCode);
        }

        public IList<LOMDTO00427> GetAllBlackListHistoryByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            return this.BLInternalCustEntyDAO.GetAllBlackListHistoryByACTypeAndDate(TypeofCust,AccountType,StartDate,EndDate,SourceBr);
        }

        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId(int CurrentUserID, string BranchCode)
        {
            return this.BLInternalCustEntyDAO.SelectUserMakerCheckerApproveByUserId(CurrentUserID, BranchCode);
        }
        #endregion
    }
}
