using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00076 : Supportfields<MNMDTO00076>
    {
        public MNMDTO00076()
        {

        }

        public MNMDTO00076(string pono, DateTime adate, decimal amount, string currency)
        {
            this.PONO = pono;
            this.ADATE = adate;
            this.AMOUNT = amount;
            this.CUR = currency;
        }

        public MNMDTO00076(string pono, string acctno, DateTime idate, DateTime adate, decimal amount, string status, string currency)
        {
            this.PONO = pono;
            this.ACCTNO = acctno;
            this.IDATE = idate;
            this.ADATE = adate;            
            this.AMOUNT = amount;
            this.STATUS = status;
            this.CUR = currency;
        }

        public virtual int Id { get; set; }
        public virtual string PONO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual DateTime ADATE { get; set; }
        public virtual DateTime IDATE { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string CUR { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
