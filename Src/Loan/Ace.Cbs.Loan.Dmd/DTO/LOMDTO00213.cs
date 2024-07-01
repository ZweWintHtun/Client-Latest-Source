using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00213 : EntityBase<LOMDTO00213>
    {
        public LOMDTO00213() { }
        public LOMDTO00213(string hpNo, string sourceBranch, string currency)
        {
            HPNumber = hpNo;
            SourceBr = sourceBranch;
            Cur = currency;
        }

        public LOMDTO00213(string hpNo, string acctNo, string name, string address, string ph, int termNo, decimal installAmt, 
        decimal rentalChgAmt, decimal total, decimal loanAmt, decimal netLoanAmt,decimal intRate,decimal downPayment, DateTime dueDate,DateTime autoPayDate, DateTime paidDate)
        {
            HPNO = hpNo;
            AcctNo = acctNo;
            NAME = name;
            ADDRESS = address;
            PHONE = ph;
            TermNo = termNo;
            Amount = installAmt;
            RentalChgAmt = rentalChgAmt;
            Total = total;
            LoanAmount = loanAmt;
            NetLoanAmount = netLoanAmt;
            IntRate = intRate;//Added by HMW (02-02-2023)
            DownPayment = downPayment;//Added by HMW (02-02-2023)
            DueDate = dueDate;
            AutoPayDate = autoPayDate;//Added by HMW (02-02-2023)
            PaidDate = paidDate;
        }

        public virtual string HPNO { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string PHONE { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal RentalChgAmt { get; set; }
        public virtual decimal Total { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual decimal NetLoanAmount { get; set; }
        public virtual decimal IntRate { get; set; }//Added by HMW (02-02-2023)
        public virtual decimal DownPayment { get; set; }//Added by HMW (02-02-2023)
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime AutoPayDate { get; set; }//Added by HMW (02-02-2023)
        public virtual DateTime PaidDate { get; set; }

        public string DateDisplay
        {
            get { return (PaidDate.ToString("dd-MM-yyyy") == "01-01-0001") ? "-" : PaidDate.ToString("dd/MM/yyyy"); }
        }
        public virtual string HPNumber { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

       
    }
}



//public LOMDTO00213(string hpNo,string sourceBranch, string currency)
//{
//    HPNumber = hpNo;
//    SourceBr = sourceBranch;
//    Cur = currency;
//}

//public LOMDTO00213(string hpNo, string acctNo, string name,string address,string ph,string termNo,decimal installAmt, decimal rentalChgAmt, decimal total, decimal loanAmt, decimal netLoanAmt,DateTime dueDate,DateTime paidDate)
//{
//    HPNO = hpNo;
//    AcctNo = acctNo;
//    NAME = name;
//    ADDRESS = address;
//    PHONE = ph;
//    TermNo = termNo;
//    Amount = installAmt;
//    RentalChgAmt = rentalChgAmt;
//    Total = total;
//    LoanAmount = loanAmt;
//    NetLoanAmount = netLoanAmt;
//    DueDate = dueDate;
//    PaidDate = paidDate;
//}

//public virtual string HPNO { get; set; }
//public virtual string AcctNo { get; set; }
//public virtual string NAME { get; set; }
//public virtual string ADDRESS { get; set; }
//public virtual string PHONE { get; set; }
//public virtual string TermNo { get; set; }
//public virtual decimal Amount { get; set; }    
//public virtual decimal RentalChgAmt { get; set; }    
//public virtual decimal Total { get; set; }    
//public virtual decimal LoanAmount { get; set; }              
//public virtual decimal NetLoanAmount { get; set; }              
//public virtual DateTime DueDate { get; set; }    
//public virtual DateTime PaidDate { get; set; }             

//public string DateDisplay
//{
//    get { return (PaidDate.ToString("dd-MM-yyyy") == "01-01-0001") ? "-" : PaidDate.ToString("dd/MM/yyyy"); }
//}
//public virtual string HPNumber { get; set; }
//public virtual string SourceBr { get; set; }
//public virtual string Cur { get; set; }
