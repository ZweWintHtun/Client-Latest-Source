using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00230 : EntityBase<LOMDTO00230>
    {
        public LOMDTO00230() { }

        public LOMDTO00230(string acctNo, string name, int lateDays, decimal todAmount, decimal totalLateFeesAmount, DateTime tODPaidDate)
        {
            AcctNo = acctNo;
            NAME = name;
            //LateDays = lateDays; // modify by ZMS(16-July-2018)
            TODAmount = todAmount;
            TotalLateFeesAmt = totalLateFeesAmount;
            TODPaidDate = tODPaidDate;
        }

        public string AcctNo { get; set; }
        public string NAME { get; set; }
        public int LateDays { get; set; }
        public decimal TODAmount { get; set; }
        public decimal TotalLateFeesAmt { get; set; }
        public DateTime TODPaidDate { get; set; }

        public virtual decimal TotalLateFee_PTOD_OnIntRate { get; set; }
        public virtual decimal TotalLateFee_PTOD_OnLateFeeRate { get; set; }
        public virtual decimal TotalLateFee_ITOD_OnLateFeeRate { get; set; }
        public virtual decimal Principal_TOD { get; set; }
        public virtual decimal Interest_TOD { get; set; }
        public int TermNo { get; set; }
    }
}
