using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00208 : EntityBase<LOMDTO00208>
    {
        public LOMDTO00208() { }
        public LOMDTO00208(string sourceBranch, string currency)//, DateTime searchDate
        {
            SourceBr = sourceBranch;
            Cur = currency;
            //Date = searchDate;
        }

        public LOMDTO00208(string hpNo, string acctNo, string name, decimal loanAmount, decimal outstandingBal,DateTime expDate,string stockGroup)
        {
            HPNo = hpNo;
            Caccount = acctNo;
            NAME = name;
            LoanAmount = loanAmount;
            OutstandingBalance = outstandingBal;
            ExpiredDate = expDate;
            StockGroup = stockGroup;
        }

        public virtual string HPNo { get; set; }
        public virtual string Caccount { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual string StockGroup { get; set; }

        //public virtual DateTime Date { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
