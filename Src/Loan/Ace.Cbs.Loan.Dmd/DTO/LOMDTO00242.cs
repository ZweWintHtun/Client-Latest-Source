using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00242
    {
        public LOMDTO00242() { }
        public LOMDTO00242(string hpNo,string acctNo,string name,string dName,decimal interest,int term,string sgDesp)
        {
            HPNo = hpNo;
            AccountNo = acctNo;
            NAME = name;
            DealerName = dName;
            Interest = interest;
            Duration = term;
            StockGroupDesp = sgDesp;
        }

        public string HPNo { get; set; }
        public string AccountNo { get; set; }
        public string NAME { get; set; }
        public string DealerName { get; set; }
        public decimal Interest { get; set; }
        public int Duration { get; set; }
        public string StockGroupDesp { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Currency { get; set; }
        public string SourceBr { get; set; }
        public string StockGroupCode { get; set; }
        public string rptName { get; set; }
        public string storedName { get; set; }
        public string searchByOpt { get; set; }
    }
}
