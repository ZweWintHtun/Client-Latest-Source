using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00245
    {
        public LOMDTO00245() { }
        
        public LOMDTO00245(string eno,string acctNo,string name,decimal amount,DateTime createdDate,string userName)
        {
            ENO = eno;
            ACCTNO = acctNo;
            NAME = name;
            AMOUNT = amount;
            CreatedDate = createdDate;
            UserName = UserName;
        }
        
        public string ENO { get; set; }
        public string ACCTNO { get; set; }
        public string NAME { get; set; }
        public decimal AMOUNT { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VoucherType { get; set; }
        public string VoucherStatus { get; set; }
        public string OptFilter { get; set; }
        public string Currency { get; set; }
        public string SourceBr { get; set; }
    }
}
