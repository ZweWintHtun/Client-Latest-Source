using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00204 : EntityBase<LOMDTO00204>
    {
        public LOMDTO00204() { }

        public LOMDTO00204(string lno, string acctNo, string name, string loanType, decimal amt, decimal srvChg, decimal docFees, DateTime sDate, DateTime expDate, string address, string phno, string nrc,
            decimal oldinterestrate,decimal newinterestrate,decimal sumofscharge,decimal outstandingamt,decimal loanamt)
        {
            Lno = lno;
            AcctNo = acctNo;
            Name = name;
            LOANSDESP = loanType;
            SAmt = amt;
            SCharges = srvChg;
            docfee = docFees;
            this.sDate = sDate;
            ExpireDate = expDate;
            Address = address;
            Phone = phno;
            NRC = nrc;
            OldInterestRate = oldinterestrate;
            NewInterestRate = newinterestrate;
            SumofSCharge = sumofscharge;
            OutStandingLoanAmt = outstandingamt;
            LoanAmt = loanamt;
        }
        //LoanNo,AccountNo,NAME,LoanType,Amount,ServiceCharges,SundryAmount,StartDate,ExpiredDate,ADDRESS,PhoneNo
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string LOANSDESP { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual decimal SCharges { get; set; }
        public virtual decimal docfee { get; set; }
        public virtual DateTime sDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string NRC { get; set; }
        public virtual decimal OldInterestRate { get; set; }
        public virtual decimal NewInterestRate { get; set; }
        public virtual decimal SumofSCharge { get; set; }
        public virtual decimal OutStandingLoanAmt { get; set; }
        public virtual decimal LoanAmt { get; set; }
    }
}
