using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00216 : EntityBase<LOMDTO00216>
    {
        public LOMDTO00216() { }

        public LOMDTO00216(string chkacctNo,string hpNo, string acctNo, string name, string nrc, string termNo, int totalLateDays,int duration,DateTime dueDate,string dName)
        {
            chkAcctNo = chkacctNo;
            HPNo = hpNo;
            Caccount = acctNo;
            NAME = name;
            NRC = nrc;
            TermNo = termNo;
            TotalLateDayWithDue = totalLateDays;
            Term = duration;
            DueDate = dueDate;
            Dname = dName;
        }

        public virtual string chkAcctNo { get; set; }
        public virtual string HPNo { get; set; }
        public virtual string Caccount { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string TermNo { get; set; }
        public virtual int TotalLateDayWithDue { get; set; }
        public virtual int Term { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual string Dname { get; set; }

    }
}
