using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// OutstandingLoanBalance Table
    /// </summary>
    [Serializable]
    public class LOMORM00401 : Supportfields<LOMORM00401>
    {
        public LOMORM00401() { }
        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<decimal> CurrentSanAmt { get; set; }
        public virtual System.Nullable<DateTime> CurrentSanDate { get; set; }
        public virtual System.Nullable<decimal> TotalInt { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual System.Nullable<DateTime> LastIntDate { get; set; }
        public virtual System.Nullable<DateTime> IntPaidDate { get; set; }
        public virtual System.Nullable<decimal> TotalLateFee { get; set; }
        public virtual System.Nullable<decimal> LastLateFee { get; set; }
        public virtual System.Nullable<DateTime> LastLatefeeDate { get; set; }
        public virtual System.Nullable<DateTime> LatefeePaidDate { get; set; }
        public virtual System.Nullable<decimal> TODAmt { get; set; }
        public virtual System.Nullable<DateTime> TOD_Date { get; set; }
        public virtual System.Nullable<DateTime> TODPaidDate { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<DateTime> FirstDueDate { get; set; }

        public virtual int NPLCase { get; set; }
        public virtual System.Nullable<DateTime> NPLDate { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }

        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string LoanGLCode { get; set; }//added by SHO [22-Nov-21] for Project loan type separate

    }
}
