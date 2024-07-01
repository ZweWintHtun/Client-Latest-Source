using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00226 : EntityBase<LOMDTO00226>
    {
        public LOMDTO00226() { }

        public LOMDTO00226(string acctNo, string lno, string name, int termNo, decimal interest, decimal installmentAmt, string businessType)
        {
            AcctNo = acctNo;
            Lno = lno;
            NAME = name;
            TermNo = termNo;
            Interest = interest;
            InstallmentAmt = installmentAmt;
            BusinessType = businessType;
        }

        public virtual string AcctNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal InstallmentAmt { get; set; }
        public virtual string BusinessType { get; set; }
    }
}
