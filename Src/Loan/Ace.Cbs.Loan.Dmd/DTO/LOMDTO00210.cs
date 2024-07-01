using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00210 : EntityBase<LOMDTO00210>
    {
        public LOMDTO00210() { }
        public LOMDTO00210(string sourceBranch, string currency)
        {
            SourceBr = sourceBranch;
            Cur = currency;
        }

        public LOMDTO00210(string hpNo, string acctNo, string name, decimal loanAmt, int duration,
                            decimal totalPrincipleAmt, decimal totalrentalChgAmt, decimal totalInstallmentAmt,
                            decimal totalOutstandingAmt,decimal totalOutstandingRentalChgAmt,decimal totalOutstandingInstallmentAmt,
                            decimal totalOutstandingODAmount,string stockGroup)
        {
            HPNo = hpNo;
            Caccount = acctNo;
            NAME = name;
            LimitAmount = loanAmt;
            Term = duration;
            TotalPrinciple = totalPrincipleAmt;
            TotalRentalCharges = totalrentalChgAmt;
            TotalInstallmentAmount = totalInstallmentAmt;
            TotalOutstandingAmt = totalOutstandingAmt;
            TotalOutstandingRentalChgAmt = totalOutstandingRentalChgAmt;
            TotalOutstandingInstallment=totalOutstandingInstallmentAmt;
            TotalOutstandingODAmount = totalOutstandingODAmount;
            StockGroup = stockGroup;
        }
        public virtual string HPNo { get; set; }
        public virtual string Caccount { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal LimitAmount { get; set; }
        public virtual int Term {get;set;}
        
        public virtual decimal TotalPrinciple { get; set; }
        public virtual decimal TotalRentalCharges { get; set; }
        public virtual decimal TotalInstallmentAmount { get; set; }
        
        public virtual decimal TotalOutstandingAmt { get; set; }
        public virtual decimal TotalOutstandingRentalChgAmt {get;set;}
        public virtual decimal TotalOutstandingInstallment {get;set;}
        public virtual decimal TotalOutstandingODAmount { get; set; }
        public virtual string StockGroup { get; set; }

        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
