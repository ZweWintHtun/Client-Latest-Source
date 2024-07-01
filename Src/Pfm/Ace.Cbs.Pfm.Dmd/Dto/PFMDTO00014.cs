using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Cheque DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00014 : EntityBase<PFMDTO00014>
    {
        public PFMDTO00014() { }

        public PFMDTO00014(int id, string accountNo, System.Nullable<DateTime> dATE_TIME, string userNo, string chequeBookNo, string chequeNo, string sourceBranchCode, bool active, int createdUserId, DateTime createdDate, byte[] tS, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.AccountNo = accountNo;
            this.DATE_TIME = dATE_TIME;
            this.UserNo = userNo;
            this.ChequeBookNo = chequeBookNo;
            this.ChequeNo = chequeNo;
            this.SourceBranchCode = sourceBranchCode;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public PFMDTO00014(string accountNo, string chequeBookNo,string chequeNo)
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.ChequeNo = chequeNo;
        }

        public PFMDTO00014(string accountNo, string chequeBookNo, string chequeNo, DateTime dateTime, string sourceBranch)
        {
            this.AccountNo = accountNo;
            this.ChequeBookNo = chequeBookNo;
            this.ChequeNo = chequeNo;
            this.DATE_TIME = dateTime;
            this.SourceBranchCode=sourceBranch;
        }
       
        public virtual string AccountNo { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ChequeBookNo { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
       
    }
}