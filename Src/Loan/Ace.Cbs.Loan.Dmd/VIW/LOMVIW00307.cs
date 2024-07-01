using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_FARMLOAN_TOTALDAILYINCOME
    /// Created By HWKO (24-Apr-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMVIW00307
    {
        public LOMVIW00307() { }
        public virtual int Id { get; set; }
        public virtual DateTime RepaymentDate { get; set; }
        public virtual string Lno { get; set; }
        public virtual string REPAYNO { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string VillageDesp { get; set; }
        public virtual string Name { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual Nullable<decimal> INTEREST { get; set; }
        public virtual Nullable<decimal> PENALTIES { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool Active { get; set; }
    }
}
