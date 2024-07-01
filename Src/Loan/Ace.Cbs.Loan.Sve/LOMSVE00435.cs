using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00435 : BaseService, ILOMSVE00435
    {
        #region Properties
        
        private ILOMDAO00435 wLInternalCustEntyDAO;
        public ILOMDAO00435 WLInternalCustEntyDAO

        //private ILOMDAO00435 wLInternalCustEntyDAO;
        //public ILOMDAO00435 WLInternalCustEntyDAO
        {
            get { return this.wLInternalCustEntyDAO; }
            set { this.wLInternalCustEntyDAO = value; }
        }
        #endregion

        public string SaveWarningLists(LOMDTO00427 BlackListDTO, string DOB)
        {
            return this.WLInternalCustEntyDAO.SaveWarningLists(BlackListDTO, DOB);
        }

        public IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo)
        {
            return this.WLInternalCustEntyDAO.GetLoansAccountInfoByACNo(AcctNo);
        }

        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId(int CurrentUserID, string BranchCode)
        {
            return this.WLInternalCustEntyDAO.SelectUserMakerCheckerApproveByUserId(CurrentUserID, BranchCode);
        }

        
        public string SaveWarningListsApproveReject(string idArray, int userId, string branchCode, string approveReject)
        {
            return this.WLInternalCustEntyDAO.SaveWarningListsApproveReject(idArray, userId, branchCode, approveReject);
        }

        public IList<LOMDTO00429> SelectAllWarningListsForApproveReject()
        {
            return this.WLInternalCustEntyDAO.SelectAllWarningListsForApproveReject();
        }

        public IList<LOMDTO00427> GetAllWarningListByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            return this.WLInternalCustEntyDAO.GetAllWarningListByACTypeAndDate(AccountType, StartDate, EndDate, SourceBr);
        }

        public IList<LOMDTO00427> GetAllWarningListHistoryByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            return this.WLInternalCustEntyDAO.GetAllWarningListHistoryByACTypeAndDate(AccountType, StartDate, EndDate, SourceBr);
        }

    }
}
