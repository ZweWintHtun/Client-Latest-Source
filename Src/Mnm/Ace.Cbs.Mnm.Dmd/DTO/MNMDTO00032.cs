using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd.DTO
{
     [Serializable]
   public class MNMDTO00032 : EntityBase<MNMDTO00032>
    {
       public MNMDTO00032(string acode, string status, string sourcecur, decimal LocalAmt, decimal homeAmt, decimal localOAmt, decimal homeOAmt, decimal clearing_Amount, decimal clearing_HomeAmount, decimal cash_LocalAmt, decimal cash_HomeAmt, string sourcebr)
        {
            this.ACODE = acode;
            this.Status_Letter_One = status;
            this.SOURCECUR = sourcecur;
            this.LocalAmt = LocalAmt;
            this.HomeAmt = homeAmt;
            this.LocalOAmt = localOAmt;
            this.HomeOAmt = homeOAmt;
            this.Clearing_Amount = clearing_Amount;
            this.Clearing_HomeAmount = clearing_HomeAmount;
            this.Cash_LocalAmt = cash_LocalAmt;
            this.Cash_HomeAmt = cash_HomeAmt;
            this.SOURCEBR = sourcebr;
        }

       public MNMDTO00032()
       { }
        public virtual string ACODE { get; set; }
        public virtual string Status_Letter_One { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string Budget { get; set; }
        public virtual string Month { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CheckTime { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual decimal Clearing_Amount { get; set; }
        public virtual decimal Clearing_HomeAmount { get; set; }
        public virtual decimal Cash_LocalAmt { get; set; }
        public virtual decimal Cash_HomeAmt { get; set; }
    }
}
