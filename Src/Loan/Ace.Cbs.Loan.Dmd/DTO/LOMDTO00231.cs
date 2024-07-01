using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00231 : EntityBase<LOMDTO00231>
    {
        public LOMDTO00231() { }

        public LOMDTO00231(string acctNo, string name,string nrc,DateTime closedDate,decimal ledgerBal,decimal fAmt,decimal lAmt,DateTime regDate)
        {
            AcctNo = acctNo;
            NAME = name;
            NRC = nrc;
            ClosedDate = closedDate;
            CBal = ledgerBal;
            FirstLoanAmt = fAmt;
            LastLoanAmt = lAmt;
            regDate = RegisterDate;
        }

        public string AcctNo { get; set; }   
        public string NAME { get; set; }
        public string NRC { get; set; }
        public DateTime ClosedDate { get; set; }
        public decimal CBal { get; set; }
        public decimal FirstLoanAmt { get; set; }
        public decimal LastLoanAmt { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
