using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    // FAOF entity
    [Serializable]
    public class MNMVIW00021 : Supportfields<MNMVIW00021>
    {
        public MNMVIW00021() { }

        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Township_Code { get; set; }
        public virtual string City_Code { get; set; }
        public virtual string State_Code { get; set; }
        public virtual Nullable<DateTime> OpenDate { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual string Description { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string AccruedStatus { get; set; }
        public virtual bool Active { get; set; }
    }
}