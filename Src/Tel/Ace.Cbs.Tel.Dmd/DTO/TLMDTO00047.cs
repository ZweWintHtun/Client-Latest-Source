using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
    //Withdraw DTO
    public class TLMDTO00047 : Supportfields<TLMDTO00047>
    {
        public TLMDTO00047() { }
        public virtual int SerialNo { get; set; }
       public virtual string GroupNo { get; set; }
       public virtual string CurrencyCode { get; set; }
       public virtual string AccountNo { get; set; }
       public virtual string Name { get; set; }
       public virtual bool IsVIP { get; set; }
       public virtual int NoOfPersonSign { get; set; }
       public virtual string JoinType { get; set; }
       public virtual string NoOfPerSignJoinType { get; set; }
       public virtual decimal CurrentBalance { get; set; }
       public virtual decimal TransactionAmount { get; set; }
       public virtual decimal TotalAmount { get; set; }
       public virtual decimal TotalCharges { get; set; }
       public virtual string IncomeType { get; set; }
       public virtual bool IsInputIncomeAmount { get; set; }
       public virtual decimal CommunicationCharges { get; set; }
       public virtual decimal Commission { get; set; }
       public virtual bool PrintTransactionStatus { get; set; }
       public virtual string ChequeNo { get; set; }
       public virtual string WithdrawType { get; set; }
       public virtual decimal ExchangeRate { get; set; }
       public virtual string VoucherNo { get; set; }
       public virtual decimal OverdraftAmount { get; set; }
       public virtual string UserNo { get; set; }
       public virtual bool WithdrawStatus { get; set; }      
       public virtual string Channel { get; set; }
       public virtual DateTime SettlementDate { get; set; }
       public virtual int ForeCheck { get; set; }
       public virtual int MinimunBalanceCheck { get; set; }
       public virtual string TransactionStatus { get; set; }
       public virtual string TransactionCode { get; set; }
       public virtual string TransactionTypeForWithdraw { get; set; }
       public virtual string ToBranch { get; set; }
       public virtual string IBSAccount { get; set; }
       public virtual string IncomeAccount { get; set; }
       public virtual string MaxItem { get; set; }
       public virtual string ACode { get; set; }
       public virtual string VoucherStatus { get; set; }
       public virtual string VoucherTransactionCode { get; set; }
       public virtual string VoucherType { get; set; }
       public virtual string IncomeDenoString { get; set; }
       public virtual string DenoString { get; set; }
       public virtual string DenoStatus{get;set;}      
       public virtual bool DenoReverse { get; set; }
       public virtual string DenoRateString { get; set; }
       public virtual string IncomeDenoRateString { get; set; }
       public virtual string CounterNo { get; set; }
       public virtual string IncomeCounterNo { get; set; }
       public virtual string PrintLineNo { get; set; }
       public virtual string FromBranch { get; set; }
       public virtual string AllDenoRate { get; set; }      
       public virtual string LinkAmount { get; set; }      
       public virtual decimal Amount { get; set; }
       public virtual decimal AdjustAmount { get; set; }
       public virtual decimal IncomeAdjustAmount { get; set; }
       public virtual decimal Comissions { get; set; }
       public virtual bool LinkStatus { get; set; }
       public virtual string SourceBranchCode { get; set; }
       public virtual string BranchCode { get; set; }
       public virtual string DenoRefundString { get; set; }
       public virtual string IncomeDenoRefundString { get; set; }
       public virtual string DenoRefundRateString { get; set; }
       public virtual string IncomeDenoRefundRateString { get; set; }
       public virtual string AccountSing { get; set; }
       public virtual bool IncomeByCashStatus { get; set; }
       public virtual bool IncomeByTransferStatus { get; set; }
       public virtual bool LocalWithdrawType { get; set; }
       public virtual bool OnlineWithdrawType { get; set; }
       public virtual bool IsIncomeByCash { get; set; }
       public virtual bool IsIncomeByTransfer { get; set; }
       public virtual bool IsLastWithdrawal { get; set; }
       public virtual string LocalBranchCode { get; set; }
       public virtual string CurrentAccountSign { get; set; }
       public virtual string SavingAccountSign { get; set; }
       public virtual bool IsAutoLink { get; set; }
     
    }
}
