using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00423 : EntityBase<LOMDTO00423>
    {
        public LOMDTO00423() { }
        public LOMDTO00423(string blNo, string acctNo, string name, decimal loanAmount, decimal outstandingBal, DateTime createdDate, DateTime expDate)
        {
            BLNo = blNo;
            Caccount = acctNo;
            NAME = name;
            LoanAmount = loanAmount;
            OutstandingBalance = outstandingBal;
            CreatedDate = createdDate;
            ExpiredDate = expDate;
            //LoansGroup = laonsGroup;
        }
        public LOMDTO00423(string custID, string acctNo, string name, string nrc, string occupation, string ph, string add,string nameOnly,string acSign)
        {
            CustID = custID;
            Caccount = acctNo;
            NAME = name;
            NRC = nrc;
            Occu = occupation;
            Phone = ph;
            Address = add;
            //NameOnly = nameOnly;
            //ACSIGN = acSign;
        }

        public LOMDTO00423(string acctNo, string lno, string name, DateTime registerDate, DateTime lastExpiredDate, 
            decimal fsamt, decimal outstandingLoanAmt, decimal oldInterestRate, decimal newInterestRate, int extendDuration, decimal docFee, int termNo,
            string preextend, int defaultexternterm)
        {
            Caccount = acctNo;
            NAME = name;
            CreatedDate = registerDate;
            ExpiredDate = lastExpiredDate;
            LoanAmount = fsamt;
            OutstandingBalance = outstandingLoanAmt;
            OldInterestRate = oldInterestRate;
            NewInterestRate = newInterestRate;
            ExtendDuration = extendDuration;
            DocFee = docFee;
            TermNo = termNo;
            PREEXTEND = preextend;
            DEFAULTEXTENDTERM = defaultexternterm;            
        }

        public LOMDTO00423(decimal firstSamt, decimal increaseSamt, decimal totalSamt)//SP_GetSanctionAmountInfo by HMW at 14-Nov-2019
        {
            FirstSanctionAmount=firstSamt;
            IncreaseSanctionAmount = increaseSamt;
            TotalSanctionAmount = totalSamt;
        }

        public virtual string BLNo { get; set; }
        public virtual string Caccount { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual string LoansGroup { get; set; }

        //public virtual DateTime Date { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        public virtual string CustID { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Occu { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        //public virtual string NameOnly { get; set; }
        //public virtual string ACSIGN { get; set; }
        
        public virtual int ExtendDuration { get; set; }
        public virtual decimal DocFee { get; set; }
        public virtual decimal OldInterestRate { get; set; }
        public virtual decimal NewInterestRate { get; set; }
        public virtual int TermNo { get; set; }
        
        public virtual string PREEXTEND { get; set; }
        public virtual int DEFAULTEXTENDTERM { get; set; }

        public virtual string saveResult { get; set; }
        public virtual decimal FirstSanctionAmount { get; set; }
        public virtual decimal IncreaseSanctionAmount { get; set; }        
        public virtual decimal TotalSanctionAmount { get; set; }        
    }
}
