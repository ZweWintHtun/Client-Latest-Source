using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00237 : EntityBase<LOMDTO00237>
    {
        public LOMDTO00237() { }

        public LOMDTO00237(string hpNo,string acctNo,string dealerAC,decimal downpayPercent,decimal loansAmt,decimal rentalPercent,int duration,
                            string paymentOpt,decimal dealerCommi, decimal nextYrRentalPercent, decimal productValue, decimal docFees, int gapPeriod, 
                            DateTime repayStartDate,DateTime repayExpDate,string guan_acctNo,string prodGrp,string prodName,string relatedGL,
                            decimal downPayAmt,decimal rentalChg,decimal commission,decimal installmentAmt,string remarks)
        {
            HPNo = hpNo;
            Caccount = acctNo;
            DealerAC = dealerAC;
            DownPayPercent = downpayPercent;
            LoanAmount = loansAmt;
            RCharges_Percent = rentalPercent;
            Duration = duration;
            PaymentOption=paymentOpt;
            DealerCommi=dealerCommi;
            NextRentalPercent=nextYrRentalPercent;
            ProductValue=productValue;
            DocFees=docFees;
            GapPeriod=gapPeriod;
            RepayStartDate=repayStartDate;
            ExpiredDate=repayExpDate;
            guanacctno=guan_acctNo;
            ProductGroup=prodGrp;
            ProductName=prodName;
            RelatedGLACode=relatedGL;
            DownPayment=downPayAmt;
            RentalCharges=rentalChg;
            Commission=commission;
            InstallmentAmount = installmentAmt;
            Remarks = remarks;
        }

        public string HPNo { get; set; }
        public string Caccount { get; set; }
        public string DealerAC { get; set; }
        public decimal DownPayPercent { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal RCharges_Percent { get; set; }
        public int Duration { get; set; }
        public string PaymentOption { get; set; }
        public decimal DealerCommi { get; set; }
        public decimal NextRentalPercent { get; set; }
        public decimal ProductValue { get; set; }
        public decimal DocFees { get; set; }
        public int GapPeriod { get; set; }
        public DateTime RepayStartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string guanacctno { get; set; }
        public string ProductGroup { get; set; }
        public string ProductName { get; set; }
        public string RelatedGLACode { get; set; }
        public decimal DownPayment { get; set; }
        public decimal RentalCharges { get; set; }
        public decimal Commission { get; set; }
        public decimal InstallmentAmount { get; set; }
        public string Remarks { get; set; }
    }
}
