using Ace.Windows.Core.DataModel;
using System;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Sub Account Type DTO Object
    /// </summary>
    [System.Serializable]
    public class PFMDTO00022 : EntityBase<PFMDTO00022>
    {
        public PFMDTO00022()
        { }

        public PFMDTO00022(int id, string code, string description, string symbol, string accountSign)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
            this.AccountSignature = accountSign;
        }

        //Id,Code,Description,Symbol,AccountSignature,AccountTypeId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00022(int id, string code, string description, string symbol, string accountSign, int accountTypeId,
             bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
            this.AccountSignature = accountSign;
            this.AccountTypeId = accountTypeId;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public PFMDTO00022(int id, string code, string description, string symbol, string accountSign, int accountTypeId, string accountTypeCode, string accountTypeDescription, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
            this.Symbol = symbol;
            this.AccountSignature = accountSign;
            this.AccountTypeId = accountTypeId;
            this.AccountTypeCode = accountTypeCode;
            this.AccountTypeDescription = accountTypeDescription;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual int AccountTypeId { get; set; }
        public virtual PFMDTO00015 AccountType { get; set; }
        public virtual string AccountTypeCode { get; set; }
        public virtual string AccountTypeDescription { get; set; }
        public virtual bool IsCheck { get; set; }

    }
}