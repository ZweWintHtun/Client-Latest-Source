using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00022
    {
        public MNMVIW00022() { }

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual int CBal { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
