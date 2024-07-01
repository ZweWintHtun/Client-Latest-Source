using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
   public class TLMVIW00014
    {
        public TLMVIW00014() { }

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
