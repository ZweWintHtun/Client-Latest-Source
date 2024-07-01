using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00232 : EntityBase<LOMDTO00232>
    {
        public LOMDTO00232() { }

        public LOMDTO00232(string eno, string acctNo, decimal amount, string status, string desp, string narration, DateTime datetime)
        {
            Eno = eno;
            AcctNo = acctNo;
            Amount = amount;
            Status = status;
            Desp = desp;
            Narration = narration;
            DATE_TIME = datetime;
        }

        public string Eno { get; set; }
        public string AcctNo { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Desp { get; set; }
        public string Narration { get; set; }
        public DateTime DATE_TIME { get; set; }
    }
}
