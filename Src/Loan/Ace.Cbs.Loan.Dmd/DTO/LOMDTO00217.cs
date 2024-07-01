using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00217 : EntityBase<LOMDTO00217>
    {
        public LOMDTO00217() { }

        public LOMDTO00217(string chkacctNo, string hpNo, string acctNo, string name, string nrc, string termNo, int totalLateDays, int duration, DateTime dueDate, string companyName)
        {
            chkAcctNo = chkacctNo;
            PLNo = hpNo;
            ACNo = acctNo;
            NAME = name;
            NRC = nrc;
            TermNo = termNo;
            TotalLateDayWithDue = totalLateDays;
            Term = duration;
            DueDate = dueDate;
            CompanyName = companyName;
        }

        public virtual string chkAcctNo { get; set; }
        public virtual string PLNo { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string TermNo { get; set; }
        public virtual int TotalLateDayWithDue { get; set; }
        public virtual int Term { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual string CompanyName { get; set; }

    }
}
