using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00215 : EntityBase<LOMDTO00215>
    {
        public LOMDTO00215() { }

        public LOMDTO00215(string plNo, string acctNo, string name, string nrc, string companyName, string termNo, int totalLateDays)
        {
            PLNo = plNo;
            AccountNo = acctNo;
            NAME = name;
            NRC = nrc;
            CompanyName = companyName;
            TermNo = termNo;
            TotalLateDays = totalLateDays;
        }

        public virtual string PLNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string TermNo { get; set; }
        public virtual int TotalLateDays { get; set; }

    }
}
