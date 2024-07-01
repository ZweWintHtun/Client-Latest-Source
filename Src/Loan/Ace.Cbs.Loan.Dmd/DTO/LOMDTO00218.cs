using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00218 : EntityBase<LOMDTO00218>
    {
        public LOMDTO00218() { }

        public LOMDTO00218(string hpNo,string acctNo, string name, int termNo,decimal odAmt,int totalLateDays,decimal totalLateAmt)
        {
            HPNo = hpNo;
            AcctNo = acctNo;
            NAME = name;
            TermNo = termNo;
            ODAmount = odAmt;
            LateDays = totalLateDays;
            TotalLateFeesAmt = totalLateAmt;
        }

        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal ODAmount { get; set; }
        public virtual int LateDays { get; set; }
        public virtual decimal TotalLateFeesAmt { get; set; }

        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

         public virtual decimal Principal_TOD { get; set; }
         public virtual decimal Interest_TOD { get; set; }

         public virtual decimal Total_LateFee_PTOD_OnIntRate { get; set; }
         public virtual decimal Total_LateFee_PTOD_OnLateFeeRate { get; set; }
         public virtual decimal Total_LateFee_ITOD_OnLateFeeRate { get; set; }
         public virtual string Phone { get; set; }

    }
}
