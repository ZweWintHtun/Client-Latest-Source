using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00025 : Supportfields<LOMORM00025>
    {
        public LOMORM00025() { }

        public virtual string DealerNo { get; set; }
        public virtual string DealerAC { get; set; }
        public virtual string Dname { get; set; }
        public virtual string Dphone { get; set; }
        public virtual string Daddress { get; set; }
        public virtual string email { get; set; }
        public virtual string NRC { get; set; }
        public virtual string fax { get; set; }
        public virtual string Business { get; set; }
        public virtual string city { get; set; }
        public virtual string BusinessEmail { get; set; }
        public virtual string BusinessAddress { get; set; }
        public virtual int commission { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}