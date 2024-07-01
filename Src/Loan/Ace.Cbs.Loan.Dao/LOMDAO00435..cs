using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd.DTO;
using NHibernate;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00435 : DataRepository<LOMORM00010>, ILOMDAO00435
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetLoansAccountInfoByACNo(string AcctNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListInternalCustomerByAcctno"); //this sp can use for both black list and warning list
            query.SetString("acctNo", AcctNo);
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

        [Transaction(TransactionPropagation.Required)]
        public string SaveWarningLists(LOMDTO00427 WarningListDTO, string DOB)
        {
            IQuery query = this.Session.GetNamedQuery("SP_WarningListCustomerSave"); //ymp
            query.SetString("acctNo", WarningListDTO.AccountNo);
            query.SetString("name", WarningListDTO.Name);
            query.SetString("nrc", WarningListDTO.NRC);
            query.SetString("fName", WarningListDTO.FatherName);
            query.SetString("cName", WarningListDTO.CompanyName);
            query.SetString("absentTerm", WarningListDTO.AbsentTerm);
            query.SetString("dOB", DOB);
            query.SetString("address", WarningListDTO.Address);
            query.SetInt32("userId", WarningListDTO.CreatedUserId);
            query.SetString("sourceBr", WarningListDTO.BranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 multilist = query.UniqueResult<LOMDTO00427>();
            return multilist.saveResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00429> SelectAllWarningListsForApproveReject()
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllWarningListsForApproveReject");
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00429)));
            return query.List<LOMDTO00429>();
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveWarningListsApproveReject(string idArray, int userId, string branchCode, string approveReject)
        {
            IQuery query = this.Session.GetNamedQuery("SP_WarningListsApproveRejectSave");
            query.SetString("idArray", idArray);
            query.SetInt64("userId", userId);
            query.SetString("branchCode", branchCode);
            query.SetString("approveReject", approveReject);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            LOMDTO00427 result = query.UniqueResult<LOMDTO00427>();
            return result.saveResult;
        }

        // Warning Lists Approve Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetAllWarningListByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllWarningListByACTypeAndDate");
            query.SetString("accountType", AccountType);
            query.SetString("startDate", StartDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", EndDate.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }

        // Warning Lists History Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00427> GetAllWarningListHistoryByACTypeAndDate(string AccountType, DateTime StartDate, DateTime EndDate, string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllWarningListHistoryByACTypeAndDate");
            query.SetString("accountType", AccountType);
            query.SetString("startDate", StartDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", EndDate.ToString("yyyy/MM/dd"));
            query.SetString("sourceBr", SourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00427)));
            return query.List<LOMDTO00427>();
        }
    }
}
