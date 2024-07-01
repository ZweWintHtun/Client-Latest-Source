using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00214 : EntityBase<LOMDTO00214>
    {
        public LOMDTO00214() { }

        public LOMDTO00214(string hpNo, string acctNo, string name, string nrc, string dealerName, string termNo, int totalLateDays)
        {
            HPNo = hpNo;
            AccountNo = acctNo;
            NAME = name;
            NRC = nrc;
            DealerName = dealerName;
            TermNo = termNo;
            TotalLateDays = totalLateDays;
        }

        public virtual string HPNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string DealerName { get; set; }
        public virtual string TermNo { get; set; }
        public virtual int TotalLateDays { get; set; }

    }
}
