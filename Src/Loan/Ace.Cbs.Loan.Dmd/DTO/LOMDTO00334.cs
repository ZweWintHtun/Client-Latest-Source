using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00334
    {
        public LOMDTO00334() { }

        public LOMDTO00334(decimal loanAmt, string acctNo, string custName, string custNrc, string custAddress, string custFatherName,
            string guaName, string guaNrc, string guaAddress, string guaFatherName, string productName,
            decimal downpayment, decimal commission, decimal comRate, decimal rchgRate, int termNo, DateTime dueDate, decimal intAmtPerTerm,
            decimal rchgAmtPerTerm, DateTime ftduedate, DateTime ltduedate, decimal totalInstAmt, decimal downPaymentRate)
        {
            this.LoanAmount = loanAmt;
            this.AcctNo = acctNo;
            this.CustName = custName;
            this.CustNRC = custNrc;
            this.CustAddress = custAddress;
            this.CustFatherName = custFatherName;
            this.GuaName = guaName;
            this.GuaNRC = guaNrc;
            this.GuaAddress = guaAddress;
            this.GuaFatherName = guaFatherName;
            this.ProductName = productName;
            this.DownPayment = downpayment;
            this.Commission = commission;
            this.ComRate = comRate;
            this.RChgRate = rchgRate;
            this.TermNo = termNo;
            this.DueDate = dueDate;
            this.InstallAmtPerTerm = intAmtPerTerm;
            this.RChgAmtPerTerm = rchgAmtPerTerm;
            this.FTDueDate = ftduedate;
            this.LTDueDate = ltduedate;
            this.TotalInstallmentAmt = totalInstAmt;
            this.DownPaymentRate = downPaymentRate;
            
        }

        public LOMDTO00334(string custName,string custnrc,string custfathername,string custaddress)
        {
            this.CustName = custName;
            this.CustNRC = custnrc;
            this.CustFatherName = custfathername;
            this.CustAddress = custaddress;
        }

        public LOMDTO00334(string custName, string custnrc, string custfathername, string custaddress, string custNameCustNRC, string custNameConcatFromView, string custNameCustNRCConcatFromView, string custNameCustNRCConcatWithEnterFromView,
            string custNRCConcatFromView, string custFatherNameConcatFromView, string custAddressForOneConcatFromView, decimal downPaymentRate)
        {
            this.CustName = custName;
            this.CustNRC = custnrc;
            this.CustFatherName = custfathername;
            this.CustAddress = custaddress;
            this.CustNameCustNRC = custNameCustNRC;
            this.CustNameConcatFromView = 
            this.CustNameCustNRCConcatFromView = custNameCustNRCConcatFromView;
            this.CustNameCustNRCConcatWithEnterFromView = custNameCustNRCConcatWithEnterFromView;
            this.CustNRCConcatFromView = custNRCConcatFromView;
            this.CustFatherNameConcatFromView = custFatherNameConcatFromView;
            this.CustAddressForOneConcatFromView = custAddressForOneConcatFromView;
            this.DownPaymentRate = downPaymentRate;
        }

        public virtual string HPNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime DateFromView { get; set; }
        public virtual string ProductNameFromView { get; set; }
        public virtual string CarNoFromView { get; set; }
        public virtual string CarBoardNoFromView { get; set; }
        public virtual string NoOfProductFromView { get; set; }
        public virtual string CustNameConcatFromView { get; set; }
        public virtual string CustNameCustNRCConcatFromView { get; set; }
        public virtual string CustNameCustNRCConcatWithEnterFromView { get; set; }
        public virtual string CustNRCConcatFromView { get; set; }
        public virtual string CustFatherNameConcatFromView { get; set; }
        public virtual string CustAddressForOneConcatFromView { get; set; }
        
        public virtual decimal LoanAmount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string CustName { get; set; }
        public virtual string CustNameCustNRC { get; set; }
        public virtual string CustNRC { get; set; }
        public virtual string CustAddress { get; set; }
        public virtual string CustAddressForOne { get; set; }
        public virtual string CustFatherName { get; set; }
        public virtual string GuaName { get; set; }
        public virtual string GuaNRC { get; set; }
        public virtual string GuaAddress { get; set; }
        public virtual string GuaFatherName { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal DownPayment { get; set; }
        public virtual decimal Commission { get; set; }
        public virtual decimal ComRate { get; set; }
        public virtual decimal RChgRate { get; set; }
        public virtual int TermNo { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal InstallAmtPerTerm { get; set; }
        public virtual decimal RChgAmtPerTerm { get; set; }
        public virtual DateTime FTDueDate { get; set; }//First Term Due Date
        public virtual DateTime LTDueDate { get; set; }//Last Term Due Date
        public virtual decimal TotalInstallmentAmt { get; set; }//Total Installment Amt without Down Payment for all terms                
        public virtual decimal DownPaymentRate { get; set; }
    }
}
