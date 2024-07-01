using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00072 : EntityBase<MNMVIW00072>
    {

        public virtual string AcctNo { get; set; }
        public virtual string CrAcctNo { get; set; }
        public virtual string Type{ get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<DateTime>  Date_Time{ get; set; }
        public virtual string UserNo{ get; set; }
        public virtual string Desp{ get; set; }
        public virtual string Budget{ get; set; }
        public virtual string UId{ get; set; }
        public virtual string SourceBr{ get; set; }
        public virtual string Cur{ get; set; }
        public virtual string ACNAME { get; set; }
        public MNMVIW00072() { }
      
    }
}
