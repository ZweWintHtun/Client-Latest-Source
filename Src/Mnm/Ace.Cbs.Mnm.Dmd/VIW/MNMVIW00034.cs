using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_MOB3221
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00034
    {
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual decimal ODAmt { get; set; }
        public virtual decimal ODLimit { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
