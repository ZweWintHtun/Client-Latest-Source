using Ace.Windows.Core.DataModel;
using System;

namespace Ace.Cbs.Pfm.Dmd
{
    [System.Serializable]
    public class PFMDTO00024 : Supportfields<PFMDTO00024>
    {

        public PFMDTO00024() { }

        public PFMDTO00024(string aCode, string sourceBranchCode)
        {
            this.ACode = aCode;
            this.DCODE = sourceBranchCode;
        }
        public PFMDTO00024(string aCode)
        {
            this.ACode = aCode;            
        }

        public PFMDTO00024(string aCode, string accountName, string sourcebranchCode)
        {
            this.AccountName = aCode;
            this.COASetUpAccountName = accountName;
            this.DCODE = sourcebranchCode;
        }

        public PFMDTO00024(string accountName, bool active)
        {
            this.AccountName = accountName;
            this.Active = active;
        }

        public PFMDTO00024(string coaAccountNo, int createdUserId)
        {
            this.AccountName = coaAccountNo;
            this.CreatedUserId = createdUserId;
        }

        public PFMDTO00024(string aCode, string accountName, int createdUserId)
        {
            this.ACode = aCode;
            this.AccountName = accountName;
            this.CreatedUserId = createdUserId;
        }
        
        public PFMDTO00024(string aCode, string accountName,string sourcebranchCode, int createdUserId)
        {
            this.ACode = aCode;
            this.AccountName = accountName;
            this.DCODE = sourcebranchCode;
            this.CreatedUserId = createdUserId;
        }

        public PFMDTO00024(string acode, string acName, string accountname, string sourceBranchCode, int createdUserId)
        {
            this.ACode = acode;
            this.ACName = acName;
            this.AccountName = accountname;
            this.DCODE = sourceBranchCode;
            this.CreatedUserId = createdUserId;
        }
        public PFMDTO00024(string aCode, string aCName, string dCODE, string aCType, DateTime pDate, string cBMACode, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.ACode = aCode;
            this.AccountName = aCName;
            this.DCODE = dCODE;
            this.ACType = aCType;
            this.PDate = pDate;
            this.CBMACode = cBMACode;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual string ACode { get; set; }
        public virtual string ACName { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string ACType { get; set; }
        public virtual DateTime PDate { get; set; }
        public virtual string COASetUpAccountName { get; set; }
        public virtual string CBMACode { get; set; }
        public virtual string Amount { get; set; }
        public virtual string AccountName { get; set; }
        
        public virtual string AccountNo { get; set; }//Private field for Saving Withdraw
    }
}