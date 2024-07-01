using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Per_Guan ORM Object
    /// </summary>
    public class PFMORM00039 : EntityBase<PFMORM00039>
    {
        public virtual string LineNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string NRC { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual Nullable<DateTime> ClosedDate { get; set; }
        public virtual string GuarantorCompanyName { get; set; }
    }
}