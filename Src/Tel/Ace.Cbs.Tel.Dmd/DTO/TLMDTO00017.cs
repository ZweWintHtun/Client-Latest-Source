//----------------------------------------------------------------------
// <copyright file="TLMDTO00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser>Khin Phyu Lin</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// RD DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00017 : Supportfields<TLMDTO00017>
    {
        public TLMDTO00017() { }

        public TLMDTO00017(System.Nullable<Decimal> testKey)
        {
            this.TestKey = testKey;
        }

        public TLMDTO00017(string registerNo)
        {
            this.RegisterNo = registerNo;
        }

        public TLMDTO00017(string registerno,string dbank,string type,string accountno,decimal amount,string name,string nrc,decimal commision,decimal tlxcharges,string toaccountno,string toname,string tonrc,string toaddress,string tophoneno,decimal? testkey,DateTime settlementdate, string sourceBr,DateTime date_time,string userno,string budget,string cur)
        {
            this.RegisterNo = registerno;
            this.Dbank = dbank;
            this.Type = type;
            this.AccountNo = accountno;
            this.Amount = amount;
            this.Name = name;
            this.NRC = nrc;
            this.Commission = commision;
            this.TlxCharges = tlxcharges;
            this.ToAccountNo = toaccountno;
            this.ToName = toname;
            this.ToNRC = tonrc;
            this.ToAddress = toaddress;
            this.ToPhoneNo = tophoneno;
            this.TestKey = testkey;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourceBr;
            this.DateTime = date_time;
            this.UserNo = userno;
            this.Budget = budget;
            this.Currency = cur;
        }
        public TLMDTO00017(string registerNo, string drawingNo, string draftNo, string dbank, string br_Alias, string type, string acctNo, string name, string address, string nRC, string checkNo, string toAcctNo, string toName, string toNRC, string toAddress, System.Nullable<decimal> testKey, System.Nullable<decimal> amount, System.Nullable<decimal> commission, System.Nullable<decimal> tlxCharges, System.Nullable<DateTime> date_Time, System.Nullable<DateTime> receiptDate, System.Nullable<DateTime> incomeDate, string rDType, string incomeType, string acSign, string userNo, string budget, System.Nullable<DateTime> sendDate, string loanSerial, string deno_Status, string phoneNo, string toPhoneNo, string narration, string uId, string sourceBr, string cur, string channel, System.Nullable<DateTime> settlementDate, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.RegisterNo = registerNo;
            this.DrawingNo = drawingNo;
            this.DraftNo = draftNo;
            this.Dbank = dbank;
            this.Br_Alias = br_Alias;
            this.Type = type;
            this.AccountNo = acctNo;
            this.Name = name;
            this.Address = address;
            this.NRC = nRC;
            this.CheckNo = checkNo;
            this.ToAccountNo = toAcctNo;
            this.ToName = toName;
            this.ToNRC = toNRC;
            this.ToAddress = toAddress;
            this.TestKey = testKey;
            this.Amount = amount;
            this.Commission = commission;
            this.TlxCharges = tlxCharges;
            this.DateTime = date_Time;
            this.ReceiptDate = receiptDate;
            this.IncomeDate = incomeDate;
            this.RDType = rDType;
            this.IncomeType = incomeType;
            this.AccountSign = acSign;
            this.UserNo = userNo;
            this.Budget = budget;
            this.SendDate = sendDate;
            this.LoanSerial = loanSerial;
            this.Deno_Status = deno_Status;
            this.PhoneNo = phoneNo;
            this.ToPhoneNo = toPhoneNo;
            this.Narration = narration;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Channel = channel;
            this.SettlementDate = settlementDate;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		

        public TLMDTO00017(string registerNo, string drawingNo, string draftNo, string dBank, string br_Alias, string type, string accountNo, string name, string address, string nrc, string checkNo, string toAccountNo, string toName, string toNRC, string toAdress, System.Nullable<decimal> testKey, System.Nullable<decimal> amount, System.Nullable<decimal> commission, System.Nullable<decimal> tlxCharges, System.Nullable<DateTime> date_Time, System.Nullable<DateTime> receiptDate, System.Nullable<DateTime> incomeDate, string rdType, string incomeType, string accountSign, string userNo, string budget, System.Nullable<DateTime> sendDate, string loanSerial, string deno_Status, string phoneNo, string toPhoneNo, string narration, string uniqueId, string sourceBranchCode, string currency, string channel, System.Nullable<DateTime> settlementDate, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.RegisterNo = registerNo;
            this.DrawingNo = drawingNo;
            this.DraftNo = draftNo;
            this.Dbank = dBank;
            this.Br_Alias = br_Alias;
            this.Type = type;
            this.AccountNo = accountNo;
            this.Name = name;
            this.Address = address;
            this.NRC = nrc;
            this.CheckNo = checkNo;
            this.ToAccountNo = toAccountNo;
            this.ToName = toName;
            this.ToNRC = toNRC;
            this.ToAddress = address;
            this.TestKey = testKey;
            this.Amount = amount;
            this.Commission = commission;
            this.TlxCharges = tlxCharges;
            this.DateTime = date_Time;
            this.ReceiptDate = receiptDate;
            this.IncomeDate = incomeDate;
            this.RDType = rdType;
            this.IncomeType = incomeType;
            this.AccountSign = accountSign;
            this.UserNo = userNo;
            this.Budget = budget;
            this.SendDate = sendDate;
            this.LoanSerial = loanSerial;
            this.Deno_Status = deno_Status;
            this.PhoneNo = phoneNo;
            this.ToPhoneNo = toPhoneNo;
            this.Narration = narration;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.Channel = channel;
            this.SettlementDate = settlementDate;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public TLMDTO00017(string registerNo, string drawingBank, string accountNo, System.Nullable<decimal> amount, System.Nullable<decimal> commission, System.Nullable<decimal> tlxCharges,
                           string name, string incomeType, System.Nullable<decimal> testKey, string checkNo, string rdType, string accountSign, string loanSerial, string currencyCode)
        {
            this.RegisterNo = registerNo;
            this.Dbank = drawingBank;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Commission = commission;
            this.TlxCharges = tlxCharges;
            this.Name = name;
            this.IncomeType = incomeType;
            this.TestKey = testKey;
            this.CheckNo = checkNo;
            this.RDType = rdType;
            this.AccountSign = accountSign;
            this.LoanSerial = loanSerial;
            this.Currency = currencyCode;
        }

        //**TLMDAO00057.SelectDrawingRemittanceRegisterOutstanding   **//added by ASDA
        public TLMDTO00017(string registerNo, string accountNo, string br_alias,string type, System.Nullable<DateTime> dateTime,string name,string nrc,string dbank, System.Nullable<decimal> comission,
                           System.Nullable<decimal> amount, System.Nullable<DateTime> receiptDate,System.Nullable<DateTime> incomeDate, string currency, string sourceBr)
        {
            this.RegisterNo = registerNo;            
            this.AccountNo = accountNo;
            this.Br_Alias =br_alias;
            this.Type = type;
            this.DateTime = dateTime;
            this.Name = name;
            this.NRC = nrc;
            this.Dbank = dbank;
            this.Commission = comission;
            this.Amount = amount;
            this.ReceiptDate = receiptDate;
            this.IncomeDate = incomeDate;           
            this.Currency = currency;
            this.SourceBranchCode = sourceBr;
        }

        public TLMDTO00017(string registerNo, string currency, System.Nullable<decimal> amount, string toaccountno, string toname, string name, string drawingbank,string sourcebranchcode)
        {
            this.RegisterNo = registerNo;
            this.Currency=currency;
            this.Amount = amount;
            this.ToAccountNo = toaccountno;
            this.ToName = toname;
            this.Name = name;
            this.Dbank = drawingbank;
            this.SourceBranchCode = sourcebranchcode;

        }


        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, string toname, string tonrc, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, bool otherBank, string bankAlias, string incomeType, string rdType)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            this.ToNRC = tonrc;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
            this.IncomeType = incomeType;
            this.RDType = rdType;
        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, string toname, string tonrc, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, bool otherBank, string bankAlias, string rdType)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            this.ToNRC = tonrc;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
            this.RDType = rdType;
        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, string toname, string rdtype, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, bool otherBank, string bankAlias)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            this.RDType = rdtype;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, string toname, string rdtype, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, bool otherBank)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            this.RDType = rdtype;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank;

        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, string toname, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, string rdtype)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            // this.ToNRC = tonrc;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            // this.OtherBank = otherBank;
            this.RDType = rdtype;

        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string name, string toname, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, string rdtype)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.Name = name;
            this.ToName = toname;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.RDType = rdtype;

        }

        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string name, string nrc, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, string rdtype)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.Name = name;
            this.NRC = nrc;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            //this.SettlementDate = settlementDate;
            this.RDType = rdtype;

        }

        //SelectNRCForDrawingRemittanceBySettlementDate
        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type, string nrc, string name, decimal tlxcharges, decimal comission, DateTime receiptDate, string accountNo, decimal amount, string currency, DateTime settlementDate, string rdtype)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.RDType = rdtype;

        }

        public TLMDTO00017(string registerNo, string accountNo, string br_Alias, string type, DateTime dateTime, string name, string nrc, string dBank, decimal comission, decimal amount, DateTime receiptDate, DateTime incomeDate, string cur)
        {
            this.RegisterNo = registerNo;
            this.AccountNo = accountNo;
            this.Br_Alias = br_Alias;
            this.Type = type;
            this.DateTime = dateTime;
            this.Name = name;
            this.NRC = nrc;
            this.Dbank = dBank;
            this.Commission = comission;
            this.Amount = amount;
            this.ReceiptDate = receiptDate;
            this.IncomeDate = incomeDate;
            this.Currency = cur;
        }

        public TLMDTO00017(string registerNo, string cur, decimal amount, string toaccountNo, string toName, string Name, string DBank, string sourceBr, string br_Alias,string type)
        {
            this.RegisterNo = registerNo;
            this.Currency = cur;
            this.Amount = amount;
            this.ToAccountNo = toaccountNo;
            this.ToName = toName;
            this.Name = Name;
            this.Dbank = DBank;
            this.SourceBranchCode = sourceBr;
            this.Br_Alias = br_Alias;
            this.Type = type;
        }

        //(VW_MOB831)
        public TLMDTO00017(string drawingNo,string registerNo,string br_Alias,string type,string nrc,string toName,string toNRC,decimal tlxCharges,decimal comission,
            string dBank,DateTime receiptDate,string accountNo,decimal amount, DateTime dateTime,string currency,DateTime settlementDate,bool otherBank,string bankAlias)
		{
            this.DrawingNo= drawingNo;
            this.RegisterNo = registerNo ;
            this.Type = type;
            this.NRC = nrc ;
            this.Br_Alias = br_Alias;
            this.ToName = toName ;
            this.ToNRC = toNRC;
            this.TlxCharges = tlxCharges;
            this.Commission = comission;
            this.Dbank=dBank;
            this.ReceiptDate = receiptDate ;
            this.AccountNo = accountNo ;
            this.Amount = amount ;
            this.DateTime = dateTime ;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank ;
            this.Bank_Alias = bankAlias;
        }
        public TLMDTO00017(string registerNo, string name, string nrc,string address, decimal amount)
        {
            this.RegisterNo = registerNo;           
            this.Amount = amount;
            this.Name = name;
            this.NRC = nrc;
            this.Address = address;
        }

        //TLMDAO00058.SelectAmountForDrawingRemittanceByTransactionDate     
        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type,string nrc, string name, string toname, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, string rdtype,bool otherBank,string bankAlias)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;
            this.NRC = nrc;
            this.Name = name;
            this.ToName = toname;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.RDType = rdtype;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
        }

        //TLMDAO00058.SelectAmountForDrawingRemittanceBySettlementDate
        public TLMDTO00017(string drawingNo, string registerNo, string brAlias, string type,string name, string toname, decimal tlxcharges, decimal comission, string dbank, DateTime receiptDate, string accountNo, decimal amount, DateTime datetime, string currency, DateTime settlementDate, string rdtype, bool otherBank,string bankAlias)
        {
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Type = type;           
            this.Name = name;
            this.ToName = toname;
            this.TlxCharges = tlxcharges;
            this.Commission = comission;
            this.Dbank = dbank;
            this.ReceiptDate = receiptDate;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.DateTime = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.RDType = rdtype;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
        }
        public TLMDTO00017(DateTime receiptDate, string drawingNo, string registerNo,string brAlias, decimal commision, decimal amount, string dBank, decimal total, decimal tlxCharges, DateTime datetime, string curr, DateTime settlementDate, bool otherBank, string budget)
        {
            this.ReceiptDate = receiptDate;
            this.DrawingNo = drawingNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Commission = commision;
            this.Amount = amount;
            this.Dbank = dBank;
            this.Total = total;
            this.TlxCharges = tlxCharges;
            this.DateTime = datetime;
            this.Currency = curr;
            this.SettlementDate = settlementDate;
            this.OtherBank = otherBank;
            this.Budget = budget;
        }

        public virtual string RegisterNo { get; set; }
        public virtual string RegisterNo1 { get; set; }
        public virtual string DrawingNo { get; set; }
        public virtual string DraftNo { get; set; }
        public virtual string Dbank { get; set; }
        public virtual string Br_Alias { get; set; }
        public virtual string Type { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string NRC { get; set; }
        public virtual string CheckNo { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string ToName { get; set; }
        public virtual string ToNRC { get; set; }
        public virtual string ToAddress { get; set; }
        public virtual System.Nullable<decimal> TestKey { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<decimal> Commission { get; set; }
        public virtual System.Nullable<decimal> TlxCharges { get; set; }
        public virtual System.Nullable<DateTime> DateTime { get; set; }
        public virtual System.Nullable<DateTime> ReceiptDate { get; set; }
        public virtual System.Nullable<DateTime> IncomeDate { get; set; }
        public virtual string RDType { get; set; }
        public virtual string IncomeType { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Budget { get; set; }
        public virtual System.Nullable<DateTime> SendDate { get; set; }
        public virtual string LoanSerial { get; set; }
        public virtual string Deno_Status { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string ToPhoneNo { get; set; }
        public virtual string Narration { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Channel { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }

        public virtual decimal Rate { get; set; }
        public virtual string VoucherNo { get; set; }
        public virtual bool CheckClose { get; set; }
        public virtual bool CheckLink { get; set; }
        public virtual int RemitStatus { get; set; }
        public virtual bool IsChecked { get; set; }
        public virtual bool IsFailed { get; set; }

        public virtual Nullable<DateTime> StartDate { get; set; }
        public virtual Nullable<DateTime> EndDate { get; set; }
        public virtual string BranchNo { get; set; }
        public virtual string TransactionStatus { get; set; }
        public virtual bool OtherBank { get; set; }
        public virtual string Bank_Alias { get; set; }
        public virtual Nullable<decimal> CashAmount { get; set; }
        public virtual string Date { get; set; }
        public virtual string BankName { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public Nullable<decimal> StartAmount { get; set; }
        public Nullable<decimal> EndAmount { get; set; }

        public virtual string status { get; set; }
        public virtual string AmountByLetter { get; set; }
        public virtual string GroupNo { get; set; }

        public virtual string OrgCounterNo { get; set; }
        public virtual bool IsCloseAC { get; set; }
        public virtual string OldIncomeType { get; set; }
        public virtual string DrawingType { get; set; }
        public virtual string OldDrawingType { get; set; }
        public virtual string OldChequeNo { get; set; }

        public virtual decimal OverdraftAmount { get; set; }
        public virtual string DrawingAccount{ get;set; }
        public virtual decimal DrawingAmount { get; set; }
        public virtual string IBSComAccount { get; set; }
        public virtual decimal IBSComAmount { get; set; }
        public virtual string TelaxAccount { get; set; }
        public virtual decimal TelaxAmount { get; set; }
        public virtual string RequiredYear { get; set; }
        public virtual string RequiredMonth { get; set; }
        public virtual decimal Total { get; set; }
        public virtual bool IsPrintTransaction { get; set; }    //Added by ASDA
         //remitBrIblDTO.DrawingAccount, remitBrIblDTO.IBSComAccount, remitBrIblDTO.TelaxAccount
    }
}
