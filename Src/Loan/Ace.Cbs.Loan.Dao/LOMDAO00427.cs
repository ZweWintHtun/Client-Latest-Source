using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using NHibernate;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Dao;
using NHibernate.Transform;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00427 : DataRepository<LOMORM00010>, ILOMDAO00427
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListInternalCustomerByAcctno");
            query.SetString("acctNo", AcctNo);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }
        
        
        
        [Transaction(TransactionPropagation.Required)]
        public string SaveBlackLists(LOMDTO00427 BlackListDTO, string DOB)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListCustomerSave");
            query.SetString("acctNo", BlackListDTO.AccountNo);
            query.SetString("name", BlackListDTO.Name);
            query.SetString("nrc", BlackListDTO.NRC);
            query.SetString("fName", BlackListDTO.FatherName);
            query.SetString("cName", BlackListDTO.CompanyName);
            query.SetString("absentTerm", BlackListDTO.AbsentTerm);
            query.SetString("dOB", DOB);
            query.SetString("address", BlackListDTO.Address);
            query.SetInt32("userId", BlackListDTO.CreatedUserId);
            query.SetString("sourceBr", BlackListDTO.BranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 multilist = query.UniqueResult<LOMDTO00427>();
            return multilist.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveBlackLists_ExternalCust(LOMDTO00427 BlackListDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListExternalCustomerSave");
            query.SetString("name", BlackListDTO.Name);
            query.SetString("nrc", BlackListDTO.NRC);
            query.SetString("fName", BlackListDTO.FatherName);
            query.SetString("cName", BlackListDTO.CompanyName);

            string datestring = Convert.ToDateTime(BlackListDTO.DOB).ToString("yyyy/MM/dd");
            
            query.SetString("dOB", Convert.ToString(BlackListDTO.DOB));

            query.SetString("address", BlackListDTO.Address);
            query.SetInt32("userId", BlackListDTO.CreatedUserId);
            query.SetString("sourceBr", BlackListDTO.BranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 multilist = query.UniqueResult<LOMDTO00427>();
            return multilist.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00429> SelectAllBlackListsForApproveReject()
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllBlackListsForApproveReject");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00429)));
            return query.List<LOMDTO00429>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveBlackListsApproveReject(string idArray, int userId, string branchCode, string approveReject)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListsApproveRejectSave");
            query.SetString("idArray", idArray);
            query.SetInt64("userId", userId);
            query.SetString("branchCode", branchCode);
            query.SetString("approveReject", approveReject);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveBlackListsRemove(string idArray, int userId, string branchCode, string remove)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListsRemoveSave");
            query.SetString("idArray", idArray);
            query.SetInt64("userId", userId);
            query.SetString("branchCode", branchCode);
            query.SetString("remove", remove);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveWarningListsRemove(string idArray, int userId, string branchCode, string remove)
        {
            IQuery query = this.Session.GetNamedQuery("SP_WarningListsRemoveSave");
            query.SetString("idArray", idArray);
            query.SetInt64("userId", userId);
            query.SetString("branchCode", branchCode);
            query.SetString("remove", remove);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00429> SelectAllBlackListsForRemove()
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllBlackListsForRemove");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00429)));
            return query.List<LOMDTO00429>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00429> SelectAllWarningListsForRemove()
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllWarningListsForRemove");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00429)));
            return query.List<LOMDTO00429>();
        }

        // Black Lists Approve Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetAllBlackListByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllBlackListByACTypeAndDate");
            query.SetBoolean("typeofCust", TypeofCust);
            query.SetString("accountType", AccountType);
            query.SetString("startDate", StartDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", EndDate.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }

        // Black Lists Maker Checker User Entry
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> SelectAllUser(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllUser");
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> SelectAllBlackListMakerCheckerUser(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllBlackListMakerCheckerUser");
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveBlackListUser(string UserName, int CurrentUserID, string BranchCode, string ApproveType)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListMakerCheckerUserSave");
            query.SetString("userName", UserName);
            query.SetInt32("CurrentUserID", CurrentUserID);
            query.SetString("sourceBr", BranchCode);
            query.SetString("approveType", ApproveType);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }
        [Transaction(TransactionPropagation.Required)]
        public string DeleteBlackListUser(string idArray, int CurrentUserID, string BranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListMakerCheckerUserDelete");
            query.SetString("idArray", idArray);
            query.SetInt32("CurrentUserID", CurrentUserID);
            query.SetString("sourceBr", BranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }

        // Black Lists History Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetAllBlackListHistoryByACTypeAndDate(bool TypeofCust, string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllBlackListHistoryByACTypeAndDate");
            query.SetBoolean("typeofCust", TypeofCust);
            query.SetString("accountType", AccountType);
            query.SetString("startDate", StartDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", EndDate.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }
        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId(int CurrentUserID, string BranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectUserMakerCheckerApproveByUserId");
            query.SetInt32("userId", CurrentUserID);
            query.SetString("sourceBr", BranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result;
        }
    }
}
