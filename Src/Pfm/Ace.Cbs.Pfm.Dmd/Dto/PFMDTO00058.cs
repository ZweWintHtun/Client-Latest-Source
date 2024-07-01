using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Fledger Print File DTO Entity (FPrnFile)
    /// </summary>
    [Serializable]
    public class PFMDTO00058 : EntityBase<PFMDTO00058>
    {
        public PFMDTO00058() { }

        public PFMDTO00058(int id,decimal Credit, decimal Debit, decimal Balance, string Reference, DateTime CreatedDate)
        {
            this.Id = id;
            this.Credit = Credit;
            this.Debit = Debit;
            this.Balance = Balance;
            this.Reference = Reference;
            this.CreatedDate = CreatedDate;
        }

        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> AccessDate { get; set; }
        public virtual string AccessUser { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual string Channel { get; set; }
        public virtual int lineNo { get; set; }
        public virtual string Reference { get; set; }
        public virtual string CurrencyId { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
