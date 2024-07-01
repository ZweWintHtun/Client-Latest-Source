using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00025
    {
        public MNMVIW00025() { }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual decimal OverDrawn_Amount { get; set; }
        public virtual decimal OvdLimit { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string ACSign { get; set; }
    }
}
