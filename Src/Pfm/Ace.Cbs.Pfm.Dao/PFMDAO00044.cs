using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao

//PassBook->Transaction Binding->Printing User(enquiry) Dao
{
    public class PFMDAO00044 : DataRepository<PFMORM00044>, IPFMDAO00044
    {
        #region IPFMDAO00044 Members
        private IPFMDAO00044 printUserDAO;
        public IPFMDAO00044 PrintUserDAO
        {
            get { return this.printUserDAO; }
            set { this.printUserDAO = value; }
        }

        public PFMDTO00044 IsValidPassword(string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00044.IsValidPassword");
            query.SetString("sourceBranch", sourceBranch);
            return query.UniqueResult<PFMDTO00044>();         
        }

        public PFMDTO00044 SelectPrintUserBySourceBr(string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00044.SelectPrintUserBySourceBr");
            query.SetString("sourceBranch", branchCode);
            return query.UniqueResult<PFMDTO00044>();
        }

        public void UpdatePrintUser(PFMDTO00044 printUserEntity)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00044.UpdatePrintUser");
            query.SetString("username", printUserEntity.UserName);
            query.SetString("password", printUserEntity.Password);
            query.SetString("confirmPassword", printUserEntity.ConfirmPassword);
            query.SetDateTime("updatedDate", (System.DateTime)printUserEntity.UpdatedDate);
            query.SetInt32("updatedUserId", (System.Int32)printUserEntity.UpdatedUserId);
            query.SetString("sourceBranch", printUserEntity.SourceBranchCode);
            query.ExecuteUpdate();
        }

        #endregion

    }
}