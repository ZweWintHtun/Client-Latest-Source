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

        public LOMDTO00230(string acctNo, string name, int lateDays, decimal todAmount, decimal totalLateFeesAmount)
        {
            AcctNo = acctNo;
            NAME = name;
            LateDays = lateDays;
            TODAmount = todAmount;
            TotalLateFeesAmt = totalLateFeesAmount;
        }

        public string AcctNo { get; set; }
        public string NAME { get; set; }
        public int LateDays { get; set; }
        public decimal TODAmount { get; set; }
        public decimal TotalLateFeesAmt { get; set; }
    }
}
