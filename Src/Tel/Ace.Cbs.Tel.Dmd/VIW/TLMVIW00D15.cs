using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
    public class TLMVIW00D15
    {
        TLMVIW00D15() { }
        public virtual int Id { get; set; }
        public virtual string Eno { get; set; } //Added by HMW for "Seperating EOD Process: Day Book" to order by eno for the same date time back date TXNs 
        public virtual System.Nullable<decimal> Debit_Cash { get; set; }
        public virtual System.Nullable<decimal> Debit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Debit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Debit_Total { get; set; }
        public virtual string Account_No { get; set; }
        public virtual System.Nullable<decimal> Credit_Cash { get; set; }
        public virtual System.Nullable<decimal> Credit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Credit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Credit_Total { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> Sort_Date_Time { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Acsign { get; set; } 
    }
}
