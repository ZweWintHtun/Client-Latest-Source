using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00238 //: EntityBase<LOMDTO00238>
    {
        public LOMDTO00238() { }

        public LOMDTO00238(string aCode, string acName)
        {
            ACode = aCode;
            ACName = acName;
        }

        public LOMDTO00238(int no, string acctNo, decimal amount)
        {
            No = no;
            AccountNo = acctNo;
            Amount = amount;
        }

        public string ACode { get; set; }
        public string ACName { get; set; }

        public int No { get; set; }
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string AccountAndAmount { get { return AccountNo + "*" + Amount; } }

    }
}
