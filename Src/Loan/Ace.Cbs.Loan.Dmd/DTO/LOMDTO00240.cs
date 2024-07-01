using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00240
    {       
        public LOMDTO00240() { }

        public LOMDTO00240(string respCode, string respDesp, decimal totalInterest,decimal installAmount)
        {
            RespCode = respCode;
            RespDesp = respDesp;
            TotalInterest = totalInterest;
            FirstInstallment = installAmount;
        }
        public LOMDTO00240(string hpNo, string acctNo, string prdGroup, string prdName, decimal loanAmt,
                           int duration, decimal totalPrincipal, decimal totalInterest)
        {
            HPNo = hpNo;
            AccountNo = acctNo;
            ProductGroup = prdGroup;
            ProductName = prdName;
            LoanAmount = loanAmt;
            Duration = duration;
            TotalPrincipal = totalPrincipal;
            TotalInterest = totalInterest;
        }

        public string HPNo { get; set; }
        public string AccountNo { get; set; }
        public string ProductGroup { get; set; }
        public string ProductName { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public decimal TotalPrincipal { get; set; }
        public decimal TotalInterest { get; set; }

        public bool chkSelect { get; set; }

        public string RespCode { get; set; }
        public string RespDesp { get; set; }
        public decimal FirstInstallment { get; set; }
        public decimal DownPaymentAmount { get; set; }
        public decimal RentalChargesAmount { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        
        
    }
}
