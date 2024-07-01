using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00225 : EntityBase<LOMDTO00225>
    {
        public LOMDTO00225() { }

        public LOMDTO00225(string acctNo, string hpNo, string name, int termNo, decimal principal, decimal interest, decimal installmentAmt
                           , string companyName)
        {
            AcctNo = acctNo;
            PLNO = hpNo;
            NAME = name;
            TermNo = termNo;
            Principal = principal;
            Interest = interest;
            InstallmentAmt = installmentAmt;
            CompanyName = companyName;
        }

        public virtual string AcctNo { get; set; }
        public virtual string PLNO { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal Principal { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal InstallmentAmt { get; set; }
        public virtual string CompanyName { get; set; }
    }
}
