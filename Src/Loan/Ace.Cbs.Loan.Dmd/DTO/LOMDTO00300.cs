using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00300 : Supportfields<LOMDTO00300>
    {
        public LOMDTO00300() { }

        public virtual int ID { get; set; }
        public virtual string Lno { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string LoanProductType { get; set; }
        public virtual int DCount { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<decimal> FirstAmt { get; set; }
        public virtual Nullable<decimal> PenalFee { get; set; }
        public virtual Nullable<decimal> LastPenalFee { get; set; }
        public virtual Nullable<DateTime> LastPenalDate { get; set; }
        public virtual bool IsCalculate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
