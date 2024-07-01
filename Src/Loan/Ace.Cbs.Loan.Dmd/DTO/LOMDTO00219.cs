using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00219 : EntityBase<LOMDTO00219>
    {
        public LOMDTO00219() { }

        public LOMDTO00219(string lno, string acctNo, string name, int termNo, decimal odAmt, int totalLateDays, decimal totalLateAmt)
        {
            Lno = lno;
            Acctno = acctNo;
            NAME = name;
            TermNo = termNo;
            ODAmount = odAmt;
            LateDays = totalLateDays;
            TotalLateFeesAmt = totalLateAmt;
        }

        public LOMDTO00219(string lno, string acctNo, string name, int termNo, decimal odAmt, int totalLateDays, decimal totalLateAmt, string companyName)
        {
            Lno = lno;
            Acctno = acctNo;
            NAME = name;
            TermNo = termNo;
            ODAmount = odAmt;
            LateDays = totalLateDays;
            TotalLateFeesAmt = totalLateAmt;
            CompanyName = companyName;
        }

        public LOMDTO00219(string lno, string acctNo, string name, int termNo, decimal odAmt, int totalLateDays, decimal totalLateAmt, string companyName, int readOnlyFlag)
        {
            Lno = lno;
            Acctno = acctNo;
            NAME = name;
            TermNo = termNo;
            ODAmount = odAmt;
            LateDays = totalLateDays;
            TotalLateFeesAmt = totalLateAmt;
            CompanyName = companyName;
            ReadOnlyFlag = readOnlyFlag;
        }

        public virtual string Lno { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }      
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual int ReadOnlyFlag_P_Int { get; set; }
        public virtual int ReadOnlyFlag_P_Late { get; set; }
        public virtual int ReadOnlyFlag_I_Late { get; set; }
        public virtual int ReadOnlyFlag_Total { get; set; }        
        public virtual int ReadOnlyFlag { get; set; }

        public virtual int LateDays { get; set; }
        public virtual decimal TotalLateFeesAmt { get; set; }
        public virtual decimal ODAmount { get; set; }

        public virtual decimal Principal_TOD { get; set; }
        public virtual decimal Interest_TOD { get; set; }
        public virtual decimal TotalLateFee_PTOD_OnIntRate { get; set; }        
        public virtual decimal TotalLateFee_PTOD_OnLateFeeRate { get; set; }
        public virtual decimal TotalLateFee_ITOD_OnLateFeeRate { get; set; }

        public virtual Boolean Interest_PTOD_Status { get; set; }
        public virtual Boolean LateFee_PTOD_Status { get; set; }
        public virtual Boolean LateFee_ITOD_Status { get; set; }
        public virtual Boolean TotalLateFee_Status { get; set; }

    }
}
