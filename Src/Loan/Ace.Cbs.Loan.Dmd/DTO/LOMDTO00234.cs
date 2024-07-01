using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00234 : EntityBase<LOMDTO00234>
    {
        public LOMDTO00234() { }

        public LOMDTO00234(string eno, string acctNo, string resAcctNo, decimal amount, string status,string desp, 
                            string narration,string headACName,string aCode,
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

            DebitAcctNo = drAcctNo;
            DebitAcctDesp = drAcctDesp;
            DebitAcctNarration = drAcctNarration;
            DebitAcctAmount = drAcctAmount;

            CreditAcctNo = crAcctNo;
            CreditAcctDesp = crAcctDesp;
            CreditAcctNarration = crAcctNarration;
            CreditAcctAmount = crAcctAmount;

            AmountInWords = amountInWords;
            DrNarration = drNarration;
            CrNarration = crNarration;
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
