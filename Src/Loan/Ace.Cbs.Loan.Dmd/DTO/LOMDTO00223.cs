using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00223 : EntityBase<LOMDTO00223>
    {
        public LOMDTO00223() { }

        public LOMDTO00223(string plNo, string acctNo, string name,decimal loanAmount, decimal outstandingBalance, DateTime expDate,string companyName)
        {
            PLNo = plNo;
            ACNo = acctNo;
            NAME = name;
            LoansAmount = loanAmount;
            OutstandingBalance = outstandingBalance;
            ExpireDate = expDate;
            CompanyName = companyName;
        }

        public virtual string PLNo { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal LoansAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public DateTime ExpireDate { get; set; }
        public virtual string CompanyName { get; set; }
    }
}
