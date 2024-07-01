using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Transaction Log File DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00054 : EntityBase<PFMDTO00042>
    {
        //TLF DTO
        public PFMDTO00054() { }
        public PFMDTO00054(string eno, string acctno, decimal amount, decimal Oamount, string cheque, string userId, bool wStatus, string soruceBr, string channel, DateTime settlementDate, string errorMessage)
        {
            this.Eno = eno;
            this.AccountNo = acctno;
            this.Amount = amount;
            this.LocalOAmt = Oamount;
            this.Cheque = cheque;
            this.UserNo = userId;
            this.Withdrawstatus = wStatus;
            this.SourceBranchCode = soruceBr;
            this.Channel = channel;
            this.SettlementDate = settlementDate;
            this.ErrorMessage = errorMessage;
        }

        //TLMDAO00056.SelectDenoOutstandingReport
        public PFMDTO00054(string eno, string narration, decimal amount, DateTime date, string sourceCurrency, string sourceBr, string acctno)
        {
            this.Eno = eno;
            this.AccountNo = acctno;
            this.Narration = narration;
            this.Amount = amount;
            this.DateTime = date;
            this.SourceCurrency = sourceCurrency;
            this.SourceBranchCode = sourceBr;
        }

        public PFMDTO00054(string eno, decimal amount,string description, Nullable<decimal> rate, string sourceCurrency)
        {
            this.Eno = eno;
            this.Amount = amount;
            this.Description = description;
            this.Rate = rate;
            this.SourceCurrency = sourceCurrency;
        }

        public PFMDTO00054(string eno, string narration, decimal amount, Nullable<DateTime> date_time, string sourceCurrency, string sourceBranch)
        {
            this.Eno = eno;
            this.Amount = amount;
            this.Narration = narration;
            this.SourceBranchCode = sourceBranch;
            this.SourceCurrency = sourceCurrency;
            this.DateTime = date_time.Value;

        }

        // TLFDAO.Select Tlf Information By EntryNo and DateTime

        public PFMDTO00054(string eno, string narration, string accountNo, decimal amount, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank, string sourcebr, DateTime settlementdate)
        {
            this.Eno = eno;
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
            this.SourceBranchCode = sourcebr;
            this.SettlementDate = settlementdate;
        }

        public PFMDTO00054(string eno, string narration, string accountNo, decimal amount, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank, string cur, string othercheque, string receivedno, string poststatus, DateTime settlementdate, bool deliverReturn)
        {
            this.Eno = eno;           
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
            this.SourceCurrency = cur;
            this.OtherBankChq = othercheque;
            this.ReceiptNo = receivedno;
            this.CLRPostStatus = poststatus;
            this.SettlementDate = settlementdate;
            this.DeliverReturn = deliverReturn;
           
        }
        //***
        public PFMDTO00054(string eno, string narration, string accountNo,string acsign, decimal amount, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank, string cur,string cheque, string othercheque, string receivedno, string poststatus, DateTime settlementdate, bool deliverReturn)
        {
            this.Eno = eno;
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.AccountSign = acsign;
            this.Amount = amount;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
            this.SourceCurrency = cur;
            this.Cheque = cheque;
            this.OtherBankChq = othercheque;
            this.ReceiptNo = receivedno;
            this.CLRPostStatus = poststatus;
            this.SettlementDate = settlementdate;
            this.DeliverReturn = deliverReturn;

        }
        //***
        public PFMDTO00054(string eno, string narration, string accountNo, string Acode, string acsign, decimal amount, decimal rate, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank, string cur, string cheque, string othercheque, string receivedno, string poststatus, DateTime settlementdate, bool deliverReturn)
        {
            this.Eno = eno;
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.Acode = Acode;
            this.AccountSign = acsign;
            this.Amount = amount;
            this.Rate = rate;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
            this.SourceCurrency = cur;
            this.Cheque = cheque;
            this.OtherBankChq = othercheque;
            this.ReceiptNo = receivedno;
            this.CLRPostStatus = poststatus;
            this.SettlementDate = settlementdate;
            this.DeliverReturn = deliverReturn;

        }


        public PFMDTO00054(string eno, string narration, string accountNo, decimal amount, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank)
        {
            this.Eno = eno;
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
        }

        public PFMDTO00054(int id,bool active)
        {
            this.Id = id;
        }

        public PFMDTO00054(int id)
        {
            this.Id = id;
        }

        public PFMDTO00054(string eno, DateTime dateTime, string accountNo, decimal amount, string status, string transactionCode, string lno, string cheque,string narration )
        {
            this.Eno = eno;
            this.DateTime = dateTime;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.TransactionCode = transactionCode;
            this.Lno = lno;
            this.Cheque = cheque;
            this.Narration = narration;
          
        }

        //for TLFDAO.SelectForReversal
        public PFMDTO00054(string eno, DateTime dateTime, string accountNo, decimal amount, string status, string transactionCode, string lno, string cheque, string narration,string orgneno, DateTime settlementDate,string sourceCur)
        {
            this.Eno = eno;
            this.DateTime = dateTime;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.TransactionCode = transactionCode;
            this.Lno = lno;
            this.Cheque = cheque;
            this.Narration = narration;
            this.OrgnEno = orgneno;
            this.SettlementDate = settlementDate;
            this.SourceCurrency = sourceCur;
        }

        public PFMDTO00054(string eno, DateTime dateTime, decimal localAmt, string cheque, string trancode, string desp, string status, string accountNo, decimal rate, DateTime settDate, decimal amount,string narration,string orgnEno,string sourcebr,int updateuserID,string sourceCur)
        {
            this.Eno = eno;
            this.DateTime = dateTime;
            this.LocalAmount = localAmt;
            this.Cheque = cheque;
            this.TransactionCode = trancode;
            this.Description = desp;
            this.Status=status;
            this.AccountNo=accountNo;
            this.Rate = rate;
            this.SettlementDate = settDate;
            this.Amount = amount;
            this.Narration = narration;
            this.OrgnEno = orgnEno;
            this.SourceBranchCode = sourcebr;
            this.UpdatedUserId = updateuserID;
            this.SourceCurrency = sourceCur;
        }

        // //TLFDAO.Select Tlf Information By EntryNo,DateTime,OrgnEno,group No,active branch 
        public PFMDTO00054(string eno, string narration, string accountNo, decimal amount, string status, Nullable<DateTime> date_time, string trancode, string orgneno, string paymentorderNo, string otherbank,int updateuserId,string sourcebr)
        {
            this.Eno = eno;
            this.Narration = narration;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Status = status;
            this.DateTime = date_time.Value;
            this.TransactionCode = trancode;
            this.OrgnEno = orgneno;
            this.PaymentOrderNo = paymentorderNo;
            this.OtherBank = otherbank;
            this.UpdatedUserId = updateuserId;
            this.SourceBranchCode = sourcebr;
        }

        public PFMDTO00054(string eno, string accountno, string receiptno, string otherBank, string otherbankCheq, decimal amount, 
            string accountSign,string clrPostStatus , string transactionCode )
        {
            this.Eno = eno;
            this.AccountNo = accountno;
            this.ReceiptNo = receiptno;
            this.OtherBank = otherBank;
            this.OtherBankChq = otherbankCheq;
            this.Amount = amount;
            this.AccountSign = accountSign;
            this.CLRPostStatus = clrPostStatus;
            this.TransactionCode = transactionCode;
        }

        public PFMDTO00054(string eno, string accountno, string receiptno, string otherBank, string otherbankCheq, decimal amount,
           string accountSign, string clrPostStatus)
        {
            this.Eno = eno;
            this.AccountNo = accountno;
            this.ReceiptNo = receiptno;
            this.OtherBank = otherBank;
            this.OtherBankChq = otherbankCheq;
            this.Amount = amount;
            this.AccountSign = accountSign;
            this.CLRPostStatus = clrPostStatus;
          
        }


        // CXDAO00006.SelectTLFByENOBranchCodeDateTrancode
        public PFMDTO00054(
    int id
    , string eNO
    , string accountNo
    , decimal amount
    , string acode
    , decimal homeAmount
    , decimal homeAmt
    , decimal homeOAmt
    , decimal localAmount
    , decimal localAmt
    , decimal localOAmt
    , string sourceCurrency
    , string currencyCode
    , string cheque
    , string paymentOrderNo
    , string dRegisterNo
    , string eRegisterNo
    , string lgNo
    , string lno
    , string description
    , string narration
    , DateTime dateTime
    , string status
    , string transactionCode
    , string accountSign
    , string dOMBankPost
    , string cLRPostStatus
    , string orgnEno
    , string orgnTransactionCode
    , string orgnCheque
    , string orgnPaymentOrderNo
    , string orgnDRegister
    , string orgnERegister
    , string orgnLgNo
    , string userNo
    , string contraENo
    , string contraLNo
    , DateTime contraDateTime
    , string otherBank
    , bool deliverReturn
    , string receiptNo
    , string otherBankChq
    , DateTime checkTime
    , string otherBankAcctNo
    , string customerId
    , string gChequeNo
    , string sourceBranchCode
    , decimal rate
    , DateTime settlementDate
    , string channel
    , string referenceVoucherNo
    , string referenceType
    , bool active
    , DateTime createdDate
    , int createdUserId
    , DateTime updatedDate
    , int updatedUserId
    )
        {
            this.Id = id;
            this.Eno = eNO;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Acode = acode;
            this.HomeAmount = homeAmount;
            this.HomeAmt = homeAmt;
            this.HomeOAmt = homeOAmt;
            this.LocalAmount = localAmount;
            this.LocalAmt = localAmt;
            this.LocalOAmt = localOAmt;
            this.SourceCurrency = sourceCurrency;
            this.CurrencyCode = currencyCode;
            this.Cheque = cheque;
            this.PaymentOrderNo = paymentOrderNo;
            this.DRegisterNo = dRegisterNo;
            this.ERegisterNo = eRegisterNo;
            this.LgNo = lgNo;
            this.Lno = lno;
            this.Description = description;
            this.Narration = narration;
            this.DateTime = dateTime;
            this.Status = status;
            this.TransactionCode = transactionCode;
            this.AccountSign = accountSign;
            this.DOMBankPost = dOMBankPost;
            this.CLRPostStatus = cLRPostStatus;
            this.OrgnEno = orgnEno;
            this.OrgnTransactionCode = orgnTransactionCode;
            this.OrgnCheque = orgnCheque;
            this.OrgnPaymentOrderNo = orgnPaymentOrderNo;
            this.OrgnDRegister = orgnDRegister;
            this.OrgnERegister = orgnERegister;
            this.OrgnLgNo = orgnLgNo;
            this.UserNo = userNo;
            this.ContraENo = contraENo;
            this.ContraLNo = contraLNo;
            this.ContraDateTime = contraDateTime;
            this.OtherBank = otherBank;
            this.DeliverReturn = deliverReturn;
            this.ReceiptNo = receiptNo;
            this.OtherBankChq = otherBankChq;
            this.CheckTime = checkTime;
            this.OtherBankAcctNo = otherBankAcctNo;
            this.CustomerId = customerId;
            this.GChequeNo = gChequeNo;
            this.SourceBranchCode = sourceBranchCode;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.Channel = channel;
            this.ReferenceVoucherNo = referenceVoucherNo;
            this.ReferenceType = referenceType;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
      

        public PFMDTO00054(
  string eNO
   , string accountNo
   , decimal amount
   , string acode
   , decimal homeAmount
   , decimal homeAmt
   , decimal homeOAmt
   , decimal localAmount
   , decimal localAmt
   , string sourceCurrency
   , string currencyCode
   , string cheque
   , string paymentOrderNo
   , string dRegisterNo
   , string eRegisterNo
   , string lgNo
   , string lno
   , string description
   , string narration
   , DateTime dateTime
   , string status
   , string transactionCode
   , string accountSign
   , string dOMBankPost
   , string cLRPostStatus
   , string orgnEno
   , string orgnTransactionCode
   , string orgnCheque
   , string orgnPaymentOrderNo
   , string orgnDRegister
   , string orgnERegister
   , string orgnLgNo
   , string userNo
   , string contraENo
   , string contraLNo
   , DateTime contraDateTime
   , string otherBank
   , bool deliverReturn
   , string receiptNo
   , string otherBankChq
   , DateTime checkTime
   , string otherBankAcctNo
   , string customerId
   , string gChequeNo
   , string sourceBranchCode
   , decimal rate
   , DateTime settlementDate
   , string channel
   , string referenceVoucherNo
   , string referenceType
   , bool active
   , DateTime createdDate
   , int createdUserId
   , DateTime updatedDate
   , int updatedUserId
   )
        {
          
            this.Eno = eNO;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Acode = acode;
            this.HomeAmount = homeAmount;
            this.HomeAmt = homeAmt;
            this.HomeOAmt = homeOAmt;
            this.LocalAmount = localAmount;
            this.LocalAmt = localAmt;
            this.SourceCurrency = sourceCurrency;
            this.CurrencyCode = currencyCode;
            this.Cheque = cheque;
            this.PaymentOrderNo = paymentOrderNo;
            this.DRegisterNo = dRegisterNo;
            this.ERegisterNo = eRegisterNo;
            this.LgNo = lgNo;
            this.Lno = lno;
            this.Description = description;
            this.Narration = narration;
            this.DateTime = dateTime;
            this.Status = status;
            this.TransactionCode = transactionCode;
            this.AccountSign = accountSign;
            this.DOMBankPost = dOMBankPost;
            this.CLRPostStatus = cLRPostStatus;
            this.OrgnEno = orgnEno;
            this.OrgnTransactionCode = orgnTransactionCode;
            this.OrgnCheque = orgnCheque;
            this.OrgnPaymentOrderNo = orgnPaymentOrderNo;
            this.OrgnDRegister = orgnDRegister;
            this.OrgnERegister = orgnERegister;
            this.OrgnLgNo = orgnLgNo;
            this.UserNo = userNo;
            this.ContraENo = contraENo;
            this.ContraLNo = contraLNo;
            this.ContraDateTime = contraDateTime;
            this.OtherBank = otherBank;
            this.DeliverReturn = deliverReturn;
            this.ReceiptNo = receiptNo;
            this.OtherBankChq = otherBankChq;
            this.CheckTime = checkTime;
            this.OtherBankAcctNo = otherBankAcctNo;
            this.CustomerId = customerId;
            this.GChequeNo = gChequeNo;
            this.SourceBranchCode = sourceBranchCode;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.Channel = channel;
            this.ReferenceVoucherNo = referenceVoucherNo;
            this.ReferenceType = referenceType;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00054(string eno, string accountno, decimal amount, string status, string transactioncode, string narration, DateTime datetime,string acode,
            string cheque,string sourceCurrency, decimal rate,DateTime settlementDate,byte[] ts,string accountSign)
        {
            this.Eno = eno;
            this.AccountNo = accountno;
            this.Amount = amount;
            this.Status = status;
            this.TransactionCode = transactioncode;
            this.Narration = narration;
            this.DateTime = datetime;
            this.Acode = acode;
            this.Cheque = cheque;
            this.SourceCurrency = sourceCurrency;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.TS = ts;
            this.AccountSign = accountSign;
        }

        public PFMDTO00054(string eno, string accountno, decimal amount, string status, string transactioncode, string narration, DateTime datetime, string acode,
           string cheque, string sourceCurrency, decimal rate, DateTime settlementDate, byte[] ts, string accountSign,
            decimal homeAmount, decimal homeAmt, decimal homeOAmt, decimal localAmount, decimal localAmt, decimal localOAmt, string desp,string paymentOrderNo) 
        {
            this.Eno = eno;
            this.AccountNo = accountno;
            this.Amount = amount;
            this.Status = status;
            this.TransactionCode = transactioncode;
            this.Narration = narration;
            this.DateTime = datetime;
            this.Acode = acode;
            this.Cheque = cheque;
            this.SourceCurrency = sourceCurrency;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.TS = ts;
            this.AccountSign = accountSign;
            this.HomeAmount = homeAmount;
            this.HomeAmt = homeAmt;
            this.HomeOAmt = homeOAmt;
            this.LocalAmount = localAmount;
            this.LocalAmt = localAmt;
            this.LocalOAmt = localOAmt;
            this.Description = desp;
            this.PaymentOrderNo = paymentOrderNo;
        }

        public PFMDTO00054(string poNo,string eno,string tranCode,decimal rate,DateTime settlementDate,string channel,string currency)
        {
            this.PaymentOrderNo=poNo;
            this.Eno=eno;
            this.TransactionCode=tranCode;
            this.Rate=rate;
            this.SettlementDate=settlementDate;
            this.Channel=channel;
            this.CurrencyCode=currency;
        }

        public PFMDTO00054(string narration, bool active)
        {
            this.Narration = narration;
            this.Active = active;
        }

        public PFMDTO00054(string eno, string accountno, decimal amount, string status, string transactioncode, string narration, DateTime datetime)
        {
            this.Eno = eno;
            this.AccountNo = accountno;
            this.Amount = amount;
            this.Status = status;
            this.TransactionCode = transactioncode;
            this.Narration = narration;
            this.DateTime = datetime;
        }

        public PFMDTO00054(string groupNo, string eNO, string accountNo, decimal amount, string acode, decimal homeAmount, decimal homeAmt, decimal homeOAmt, 
                           decimal localAmount, decimal localAmt, decimal localOAmt,string sourceCurrency, string description, string narration, DateTime dateTime,
                           string status, string transactionCode, string orgnTransactionCode, string accountSign, string orgnEno, string sourceBranchCode, decimal rate,
                           DateTime settlementDate, string channel, bool active, DateTime createdDate, int createdUserId)
        {
            this.GroupNo = groupNo;
            this.Eno = eNO;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Acode = acode;
            this.HomeAmount = homeAmount;
            this.HomeAmt = homeAmt;
            this.HomeOAmt = homeOAmt;
            this.LocalAmount = localAmount;
            this.LocalAmt = localAmt;
            this.LocalOAmt = localOAmt;
            this.SourceCurrency = sourceCurrency;            
            this.Description = description;
            this.Narration = narration;
            this.DateTime = dateTime;
            this.Status = status;
            this.TransactionCode = transactionCode;
            this.OrgnTransactionCode = orgnTransactionCode;
            this.AccountSign = accountSign;            
            this.OrgnEno = orgnEno;            
            this.SourceBranchCode = sourceBranchCode;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.Channel = channel;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;           
        }

        public virtual int Id { get; set; }
        public virtual string Eno { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Acode { get; set; }
        public virtual System.Nullable<decimal> HomeAmount { get; set; }
        public virtual System.Nullable<decimal> HomeAmt { get; set; }
        public virtual System.Nullable<decimal> HomeOAmt { get; set; }
        public virtual System.Nullable<decimal> LocalAmount { get; set; }
        public virtual System.Nullable<decimal> LocalAmt { get; set; }
        public virtual System.Nullable<decimal> LocalOAmt { get; set; }
        public virtual string SourceCurrency { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string PaymentOrderNo { get; set; }
        public virtual string DRegisterNo { get; set; }
        public virtual string ERegisterNo { get; set; }
        public virtual string LgNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string Description { get; set; }
        public virtual string Narration { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Status { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string DOMBankPost { get; set; }
        public virtual string CLRPostStatus { get; set; }
        public virtual string OrgnEno { get; set; }
        public virtual string OrgnTransactionCode { get; set; }
        public virtual string OrgnCheque { get; set; }
        public virtual string OrgnPaymentOrderNo { get; set; }
        public virtual string OrgnDRegister { get; set; }
        public virtual string OrgnERegister { get; set; }
        public virtual string OrgnLgNo { get; set; }
        public virtual string OrgnLNo { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ContraENo { get; set; }
        public virtual string ContraLNo { get; set; }
        public virtual System.Nullable<DateTime> ContraDateTime { get; set; }
        public virtual string OtherBank { get; set; }
        public virtual bool DeliverReturn { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual string OtherBankChq { get; set; }
        public virtual System.Nullable<DateTime> CheckTime { get; set; }
        public virtual string OtherBankAcctNo { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string GChequeNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string Channel { get; set; }
        public virtual string ReferenceVoucherNo { get; set; }
        public virtual string ReferenceType { get; set; }
        public virtual string BranchName { get; set; }
        public virtual bool Withdrawstatus { get; set; }
        public virtual string ErrorMessage { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual int SerialNo { get; set; }
        public virtual string VoucherType { get; set; }
        public virtual string Phone { get; set; }
        public virtual string BankName { get; set; }
        public virtual string Fax { get; set; }
        public virtual string TransactionStatus { get; set; }
        public DateTime IssueDate { get; set; }
        public string Budget { get; set; }
        public virtual int RecordCount { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual bool IsCheck { get; set; }
        public IList<PFMDTO00054> CashInfoList { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual decimal DenoAmount { get; set; }
        public virtual IList<string> CustomerNames { get; set; }
        public virtual string ACName { get; set; }
        public string DebitCredit { get; set; }
        public bool isAutolink { get; set; }
        public string VoucherStatus { get; set; }
        public string NewChequeNo { get; set; }

        public decimal TotalGroupAmount { get; set; }
    }
}
