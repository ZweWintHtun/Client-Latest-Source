using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    ///VW_BusinessLoansRepaymentListing
    /// </summary>
    ///  
    [Serializable]
    public class LOMVIW00414
    {
        public LOMVIW00414() { }
        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string PHONE { get; set; }
        public virtual Nullable<DateTime> IntPaidDate { get; set; }
        public virtual Nullable<DateTime> FirstDueDate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<decimal> CurrentSanAmt { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual Nullable<decimal> TotalLateFee { get; set; }
        public virtual Nullable<decimal> TOD { get; set; }
        public virtual string Cur { get; set; }
        public virtual Nullable<DateTime> VoucherDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<decimal> TotalInt { get; set; }
        public virtual Nullable<decimal> LastInt { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<decimal> SCharges { get; set; }
        public virtual bool isSCharge { get; set; }
        public virtual string REPAYNO { get; set; }
        public virtual Nullable<decimal> InterestForRepay { get; set; }
        public virtual Nullable<decimal> RepayAmount { get; set; }
        public virtual Nullable<DateTime> RepayDate { get; set; }
    }
}
