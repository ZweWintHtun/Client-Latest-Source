using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
        [Serializable]
   public class MNMDTO00043 : EntityBase<MNMDTO00043>
    {
        public MNMDTO00043() { }

        public MNMDTO00043(string acctno,string name,decimal fbal,decimal budendacc,decimal duration,DateTime rdate,DateTime wdate,DateTime lastintdate,decimal amount,string rno,decimal accured,decimal draccured,string sourcbr,string cur)
        {
            this.AcctNo = acctno;
            this.Name = name;
            this.Fbal = fbal;
            this.BudEndAcc = budendacc;
            this.Duration = duration;
            this.RDATE = rdate;
            this.WDate = wdate;
            this.LasIntDate = lastintdate;
            this.Amount = amount;
            this.RNo = rno;
            this.Accrued =accured;
            this.DrAccured = draccured;
            this.SourceBr = sourcbr;
            this.Cur = cur;
        }

        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Fbal { get; set; }
        public virtual decimal BudEndAcc { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual System.Nullable<DateTime> RDATE { get; set; }
        public virtual System.Nullable<DateTime> WDate { get; set; }
        public virtual System.Nullable<DateTime> LasIntDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string RNo { get; set; }
        public virtual decimal Accrued { get; set; }
        public virtual decimal DrAccured { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
