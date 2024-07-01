using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Fledger Print File ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00058 : EntityBase<PFMORM00058>
    {
        public PFMORM00058() { }

        public virtual string AccountNo { get; set; }
        public virtual Nullable<DateTime> AccessDate { get; set; }
        public virtual string AccessUser { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual string Channel { get; set; }
        public virtual string Reference { get; set; }
        public virtual string CurrencyId { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
