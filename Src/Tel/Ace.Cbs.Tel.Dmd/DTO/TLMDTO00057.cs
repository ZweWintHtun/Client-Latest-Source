using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
  public  class TLMDTO00057
    {
        public TLMDTO00057() { }

        public TLMDTO00057(string cur, decimal amount, DateTime denominationDate, DateTime denominationTime, DateTime dateTime, DateTime
            time, string regiserNo, DateTime voucherDate, DateTime voucherTime, DateTime passingDate, DateTime passingTime, string branchDesp)
        {
            this.CUR = cur;
            this.AMOUNT = amount;
            this.DENOMINATIONDATE = denominationDate;
            this.DENOMINATIONTIME = denominationTime;
            this.DATE_TIME = dateTime;
            this.TIME = time;
            this.REGISTERNO = regiserNo;
            this.VOUCHER_DATE = voucherDate;
            this.VOUCHER_TIME = voucherTime;
            this.PASSING_DATE = passingDate;
            this.PASSING_TIME = passingTime;
            this.BRANCHDESP = branchDesp; 
        }

        public virtual int Id { get; set; }
        public virtual string CUR { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual DateTime DENOMINATIONDATE { get; set; }
        public virtual DateTime DENOMINATIONTIME { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual DateTime TIME { get; set; }
        public virtual string REGISTERNO { get; set; }
        public virtual DateTime VOUCHER_DATE { get; set; }
        public virtual DateTime VOUCHER_TIME { get; set; }
        public virtual DateTime PASSING_DATE { get; set; }
        public virtual DateTime PASSING_TIME { get; set; }
        public virtual string BRANCHDESP { get; set; }

    }
}
