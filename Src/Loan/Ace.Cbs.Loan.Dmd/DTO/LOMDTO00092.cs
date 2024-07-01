using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00092 : EntityBase<LOMDTO00092>
    {
        public LOMDTO00092() { }

        public LOMDTO00092(string acctNo, string status, decimal amt,string eno)
        {
            AcctNo = acctNo;
            Status = status;
            Amount = amt;
            this.eno = eno;
        }

        public string AcctNo {get;set;}
        public string Status { get; set; }
        public decimal Amount {get;set;}
        public string eno { get; set; }
    }
}
