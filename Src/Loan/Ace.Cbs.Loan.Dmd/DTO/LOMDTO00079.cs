using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00079 : EntityBase<LOMDTO00079>
    {
        public LOMDTO00079() { }

        public LOMDTO00079(string lno, string acctno1, string name1,
            string nrc1, string phone1, string acctno2, string name2,
            string nrc2, string phone2, string userno, string sourceBr,
            string cur)
        {
            this.Lno = lno;
            this.AcctNo1 = acctno1;
            this.Name1 = name1;
            this.NRC1 = nrc1;
            this.Phone1 = phone1;
            this.AcctNo2 = acctno2;
            this.Name2 = name2;
            this.NRC2 = nrc2;
            this.Phone2 = phone2;
            this.USERNO = userno;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

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
