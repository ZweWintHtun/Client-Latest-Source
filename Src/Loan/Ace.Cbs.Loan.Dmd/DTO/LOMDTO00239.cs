using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00239
    {
        public LOMDTO00239() { }

        public LOMDTO00239(Int64 no, string aCode, string acName, decimal amount)
        {
            No = no;
            AccountCode = aCode;
            Description = acName;
            Amount = amount;
        }

        public Int64 No { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
