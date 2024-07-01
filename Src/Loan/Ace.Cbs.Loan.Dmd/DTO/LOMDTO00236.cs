using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00236 : EntityBase<LOMDTO00236>
    {
        public LOMDTO00236() { }

        public LOMDTO00236(string eno, string status, string desp, string narration, string acctNo, string resAcctNo, decimal amount, string headACName, string aCode,
                            string drAcctNo, string drAcctDesp, string drAcctNarration, decimal drAcctAmount,
                            string crAcctNo, string crAcctDesp, string crAcctNarration, decimal crAcctAmount,
                            string amountInWords, string drNarration, string crNarration)
        {
            Eno = eno;
            Status = status;
            Desp = desp;
            Narration = narration;
            AcctNo = acctNo;
            ResAcctNo = resAcctNo;
            Amount = amount;
            HeadACName = headACName;
            ACode = aCode;


        }

        public string Eno { get; set; }
        public string Status { get; set; }
        public string Desp { get; set; }
        public string Narration { get; set; }
        public string AcctNo { get; set; }
        public string ResAcctNo { get; set; }
        public decimal Amount { get; set; }
        public string HeadACName { get; set; }
        public string ACode { get; set; }

        public string DebitAcctNo { get; set; }
        public string DebitAcctDesp { get; set; }
        public string DebitAcctNarration { get; set; }
        public decimal DebitAcctAmount { get; set; }

        public string CreditAcctNo { get; set; }
        public string CreditAcctDesp { get; set; }
        public string CreditAcctNarration { get; set; }
        public decimal CreditAcctAmount { get; set; }

        public string AmountInWords { get; set; }
        public string DrNarration { get; set; }
        public string CrNarration { get; set; }

    }
}
