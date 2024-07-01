using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00057
    {
        public LOMDTO00057() { }

        public LOMDTO00057(int id,string lno, string acctno, string desp, DateTime voudate,
            decimal amount, bool legalcase, bool nplcase)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctno;
            this.Desp = desp;
            this.VOUDate = voudate;
            this.Amount = amount;
            this.LegalCase = legalcase;
            this.NplCase = nplcase;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Desp { get; set; }
        public virtual Nullable<DateTime> VOUDate { get; set; }
        public virtual string Cur { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual bool NplCase { get; set; }
        public virtual string SourceBr { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
