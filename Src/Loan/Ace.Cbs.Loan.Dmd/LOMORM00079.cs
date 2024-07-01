using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Personal Guarantee of FarmLoan ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00079 : Supportfields<LOMORM00079>
    {
        public LOMORM00079() { }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo1 { get; set; }
        public virtual string Name1 { get; set; }
        public virtual string NRC1 { get; set; }
        public virtual string Phone1 { get; set; }
        public virtual string AcctNo2 { get; set; }
        public virtual string Name2 { get; set; }
        public virtual string NRC2 { get; set; }
        public virtual string Phone2 { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

    }
}
