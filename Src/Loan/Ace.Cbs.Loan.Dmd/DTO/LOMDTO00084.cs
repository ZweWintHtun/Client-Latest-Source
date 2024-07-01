using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    ////// HP /////
    [Serializable]
    public class LOMDTO00084 : EntityBase<LOMDTO00084>
    {
        public LOMDTO00084() { }

        public LOMDTO00084(string dealerAC)
        {
            DealerAC = dealerAC;
        }

        //public LOMDTO00084(string retMsg)
        //{
        //    RetMsg = retMsg;
        //}

        public LOMDTO00084(string hpno, string caccount, string dealerAC, string dealerStatus,string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent, decimal sChgsPercent,

                           decimal nextYrRChgsPercent, decimal disAmt, decimal docFees,int gapPeriod,string relatedGLACode,decimal commPercent, string stockGCode, string stockISubCode, decimal productValue, int payDuration, int payOptionId,
                           DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string userName) 

        {
            HPNo = hpno;
            Caccount = caccount;
            DealerAC = dealerAC;
            DealerStatus = dealerStatus;
            guanacctno = guanteeAcctNo;
            DownPayment = downPayPercent;
            RentalCharges = rChgsPercent;
            ServiceCharges = sChgsPercent;
            NextRentalPercent = nextYrRChgsPercent;
            LoanAmount = disAmt;
            DocFees = docFees;
            GapPeriod = gapPeriod;
            Commission = commPercent;
            StockGroup = stockGCode;
            StockItems = stockISubCode;
            RelatedGLACode = relatedGLACode;
            ProductValue = productValue;
            Term = payDuration;
            RepayOption = payOptionId;
            RepaySDate = repaySDate;
            ExpiredDate = repayExpDate;
            SourceBr = sourceBr;
            Slocation = remarks;
            CreatedUserId = createdUserId;
            Eno = eno;
            UserName = userName;
        }
        //public LOMDTO00084(string acctNo, string status, decimal amt)
        //{
        //    AcctNo = acctNo;
        //    Status = status;
        //    Amount = amt;
        //}

        public int Id {get;set;}
        public string HPNo {get;set;}
        public string Caccount {get;set;}
        public string DealerAC {get;set;}
        public string DealerStatus { get; set; }
        public string StockGroup  {get;set;}
        public string StockItems  {get;set;}
        public string RelatedGLACode { get; set; }
        public decimal ProductValue { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal DocFees { get; set; }
        public int GapPeriod { get; set; }
        public int Term { get; set; }
        public int paymentfequency  {get;set;}
        public int RepayOption { get; set; }
        public decimal Installment {get;set;}
        public int PaidTerm {get;set;}
        public decimal Commission {get;set;}
        public decimal RentalCharges {get;set;}
        public int UnPaidTerm {get;set;}
        public string Slocation {get;set;}
        public decimal DownPayment {get;set;}
        public decimal ServiceCharges {get;set;}
        public string guanacctno {get;set;}
        public decimal NextRentalPercent {get;set;}
        public bool NextRentalStatus {get;set;}
        public bool Reversestatus {get;set;}
        public DateTime RepaySDate { get; set; }
        public string UId {get;set;}
        public DateTime ExpiredDate { get; set; }
        public string SourceBr {get;set;}
        public string Cur {get;set;}
        //public bool Active {get;set;}
        //public DateTime? TS { get; set; }
        public DateTime LastPaiddate { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public int CreatedUserId {get;set;}
        //public DateTime? Updateddate { get; set; }
        //public int UpdatedUserId {get;set;}
        public DateTime CloseDate { get; set; }

        public string Eno { get; set; }
        public string UserName { get; set; }

        public decimal DownPayAmt { get; set; }
        public decimal RentalChgsAmt { get; set; }
        public decimal ServiceChgsAmt { get; set; }
        public decimal CommissionAmt { get; set; }
        public decimal InstallmentAmt { get; set; }

        public string RetMsg { get; set; }
        //public string AcctNo { get; set; }
        //public string Status { get; set; }
        //public decimal Amount { get; set; }

    }
}
