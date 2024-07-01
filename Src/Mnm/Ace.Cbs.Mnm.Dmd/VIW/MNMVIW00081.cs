using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_FIXED_RENEWAL_STATUS
    /// </summary>
    [Serializable]
    //public class MNMVIW00081 : Supportfields<MNMVIW00081>
    public class MNMVIW00081 : EntityBase<MNMVIW00081>
    {
      //  public MNMVIW00081() { }

      //  public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Rno { get; set; }
        public virtual Nullable<DateTime> RDate { get; set; }
        public virtual string Desp { get; set; }
        public virtual Nullable<DateTime> MDate { get; set; }
        public virtual string Cur { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Renstat { get; set; }
        public virtual string Accruedstatus { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string SourceBr { get; set; }
      //  public virtual bool Active { get; set; }

    }
}
