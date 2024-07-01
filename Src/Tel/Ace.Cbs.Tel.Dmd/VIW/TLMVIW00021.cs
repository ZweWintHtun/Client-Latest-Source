using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
   public class TLMVIW00021
    {
          public TLMVIW00021() { }
           public virtual int Id { get; set; }
           public virtual string ENO { get; set; }
           public virtual string AccNo { get; set; }
           public virtual string Desp { get; set; }
           public virtual Nullable<decimal> Amount { get; set; }
           public virtual string UserNo { get; set; }
           public virtual Nullable<DateTime> Date_Time { get; set; }
           public virtual Nullable<DateTime> Time { get; set; }
           public virtual string AcSign { get; set; }
           public virtual string SourceCur { get; set; }
           public virtual string WorkStation { get; set; }
           public virtual string SourceBr { get; set; }
    }
}
