using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Current Account Closing DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00072 : Supportfields<PFMDTO00072>
    {
        public PFMDTO00072()
        {
            this.ChequeNo = string.Empty;
        }

        public PFMDTO00072(string accountSignature, string currencyCode, decimal currentBalance, string customerId, string customerName,string Nrc,string nameOfFirm)
        {
            this.AccountSignature = accountSignature;
            this.CurrencyCode = currencyCode;
            this.CurrentBalance = currentBalance;
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.DebitCOAAccountNo = Nrc;
            this.BankAccountDescription = nameOfFirm;
        }

        public PFMDTO00072(string accountSignature, string currencyCode, decimal currentBalance, string customerId, string customerName, DateTime openDate)
        {
            this.AccountSignature = accountSignature;
            this.CurrencyCode = currencyCode;
            this.CurrentBalance = currentBalance;
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.OpenDate = openDate;
        }

        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string CurrencyCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountSignature { get; set; }
        public string CustomerId { get; set; }
        public string[] CustomerIds { get; set; }
        public string CustomerName { get; set; }
        public string ChequeNo { get; set; }
        public string BranchCode { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal Charges { get; set; }
        public decimal TotalInterest { get; set; }
        public string BankAccountNo { get; set; }
        public string DebitCOAAccountNo { get; set; }
        public string CreditCOAAccountNo { get; set; }
        public string CreditAccountNo1 { get; set; }
        public string CreditAccountNo2 { get; set; }
        public decimal CreditAmount1 { get; set; }
        public decimal CreditAmount2 { get; set; }
        public string DebitAccountNo1 { get; set; }
        public string DebitAccountNo2 { get; set; }
        public decimal DebitAmount1 { get; set; }
        public decimal DebitAmount2 { get; set; }        
        public Nullable<decimal> HomeExchangeRate { get; set; }
        public Nullable<DateTime> NextSettlementDate { get; set; }
        public string InterestType { get; set; }
        public string BankAccountDescription { get; set; }//Add by hmw        
        public string CreditDescription2 { get; set; }//Add by hmw
        public string DebitDescription1 { get; set; }//Add by hmw
        public bool HasCheque { get; set; }
        public string BType { get; set; }
        public string LoanNo { get; set; }
        public decimal SAmt { get; set; }
        public decimal sCharge { get; set; }
        public decimal docFee { get; set; }
        public bool isScharge { get; set; }
        public bool LoansExpiredDate { get; set; }
        public string companyName { get; set; }
        public string LoanCOAAccountNo { get; set; }//Added by HMW at 25-03-2020
    }
}
