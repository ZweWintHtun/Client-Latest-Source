using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// PrnFile ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00043 : Supportfields<PFMORM00043>
    {
        public PFMORM00043() { }

        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual string Channel { get; set; }
        public virtual string Reference { get; set; }
        public virtual decimal PrintLineNo { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
    }
}