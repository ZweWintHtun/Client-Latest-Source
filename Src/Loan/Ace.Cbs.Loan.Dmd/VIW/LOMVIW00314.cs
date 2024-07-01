using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_ExpireLeaseLandListing
    /// Created By HWKO (11-Jul-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMVIW00314
    {
        public LOMVIW00314() { }
        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual string LandDesp { get; set; }
        public virtual Nullable<DateTime> EDate { get; set; }
        public virtual Nullable<decimal> Capital { get; set; }
        public virtual Nullable<DateTime> LandLeaseSDate { get; set; }
        public virtual Nullable<DateTime> LandLeaseEDate { get; set; }
        public virtual string IsDesp { get; set; }
        public virtual Nullable<DateTime> IsStartedDate { get; set; }
        public virtual Nullable<DateTime> IsExpiredDate { get; set; }
        public virtual Nullable<decimal> IsAmt { get; set; }
        public virtual string CusName { get; set; }
        public virtual string CusAddress { get; set; }
        public virtual string CusPhone { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool Active { get; set; }
        public virtual string LoansBusinessTypeDesp { get; set; }
    }
}
