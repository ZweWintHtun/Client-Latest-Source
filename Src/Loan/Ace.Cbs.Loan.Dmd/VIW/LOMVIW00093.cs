using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_FARMLOANREPORT
    /// </summary>
    ///
    [Serializable]
    public class LOMVIW00093
    {
        public LOMVIW00093() { }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual string SeasonCode { get; set; }
        public virtual string SeasonDesp { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string VillageDesp { get; set; }
        public virtual string CropCode { get; set; }
        public virtual string CropDesp { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<decimal> Penalties { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual Nullable<DateTime> WithdrawDate { get; set; }
        public virtual Nullable<decimal> LoanAmtPerAcre { get; set; }
        public virtual Nullable<decimal> TotalAcre { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool Active { get; set; }
    }
}
