using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    /// <summary>
    /// VW_BusinessLoansInterestDueListing DTO
    /// </summary>
    [Serializable]
    public class LOMDTO00414
    {
        public LOMDTO00414() { }

         public LOMDTO00414(int id, string lno, string acctno, string name, string address, string phone, Nullable<decimal> firstSamt,
                          Nullable<decimal> currentSamt,string sourcebr, string cur, 
                          Nullable<DateTime> voucherDate, DateTime expireDate,string repayNo,Nullable<decimal> repayInt,
                          Nullable<decimal> repayAmt, Nullable<DateTime> rDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.VoucherDate = voucherDate;
            this.ExpireDate = expireDate;
            this.REPAYNO= repayNo;
            this.InterestForRepay = repayInt;
            this.RepayAmount = repayAmt;
            this.RepayDate = rDate;
        }
         public virtual int Id { get; set; }
         public virtual string LNo { get; set; }
         public virtual string AccountNo { get; set; }
         public virtual string NAME { get; set; }
         public virtual string ADDRESS { get; set; }
         public virtual string PHONE { get; set; }
         public virtual Nullable<DateTime> IntPaidDate { get; set; }
         public virtual Nullable<decimal> FirstSAmt { get; set; }
         public virtual Nullable<decimal> IntRate { get; set; }
         public virtual Nullable<DateTime> VoucherDate { get; set; }
         public virtual Nullable<DateTime> ExpireDate { get; set; }
         public virtual Nullable<DateTime> FirstDueDate { get; set; }
         public virtual Nullable<decimal> TotalLateFee { get; set; }
         public virtual Nullable<decimal> CurrentSanAmt { get; set; }
         public virtual Nullable<decimal> TODAmt { get; set; }
         public virtual string SourceBranchCode { get; set; }
         public virtual string Currency { get; set; }
         public virtual Nullable<decimal> TotalInt { get; set; }
         public virtual Nullable<decimal> LastInt { get; set; }
         public virtual Nullable<DateTime> SDate { get; set; }
         public virtual Nullable<decimal> SCharges { get; set; }
         public virtual bool isSCharge { get; set; }


         public virtual DateTime StartDate { get; set; }
         public virtual DateTime EndDate { get; set; }

         public virtual string REPAYNO { get; set; }
         public virtual Nullable<decimal> InterestForRepay { get; set; }
         public virtual Nullable<decimal> RepayAmount { get; set; }
         public virtual Nullable<DateTime> RepayDate { get; set; }
    }
}
