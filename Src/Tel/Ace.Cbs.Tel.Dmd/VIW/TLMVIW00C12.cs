using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
  public  class TLMVIW00C12
    {
      TLMVIW00C12() { }
        public virtual int Id { get; set; }
        public virtual System.Nullable<decimal> Debit_Cash { get; set; }
        public virtual System.Nullable<decimal> Debit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Debit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Debit_Total { get; set; }
        public virtual string Account_No { get; set; }
        public virtual System.Nullable<decimal> Credit_Cash { get; set; }
        public virtual System.Nullable<decimal> Credit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Credit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Credit_Total { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> Sort_Date_Time { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
