//----------------------------------------------------------------------
// <copyright file="TLMDTO00001.cs" company="ACE Data Systems">
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
    /// RE DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00001 : Supportfields<TLMDTO00001>
    {
        public TLMDTO00001() { }
        public TLMDTO00001(string registerNo)
        {
            this.RegisterNo = registerNo;
        }
        public TLMDTO00001(string registerNo, string toAccountNo, string toName, decimal amount, System.Nullable<DateTime> issueDate, string currency)
        {
            this.RegisterNo = registerNo;
            this.ToAccountNo = toAccountNo;
            this.ToName = toName;
            this.Amount = amount;
            this.IssueDate = issueDate;
            this.Currency = currency;
        }


        public TLMDTO00001(string registerNo, string toAccountNo)
        {
            this.RegisterNo = registerNo;
            this.ToAccountNo = toAccountNo;
        }

        public TLMDTO00001(string toAccountNo, string registerNo, decimal amount)
        {
            this.ToAccountNo = toAccountNo;
            this.RegisterNo = registerNo;
            this.Amount = amount;
        }

        
        public TLMDTO00001(string registerNo , string ebank, string toAccountNo, string ToName, decimal amount, string currency, string accountsign, string sourceBranchCode)
        {
            this.RegisterNo = registerNo;
            this.Ebank = ebank;
            this.ToAccountNo = toAccountNo;
            this.ToName = ToName;
            this.Amount = amount;
            this.Currency = currency;
            this.AccountSign = accountsign;
            this.SourceBranchCode = sourceBranchCode;
        }

        public TLMDTO00001(string registerNo, string encashNo, string ebank, string br_Alias, string type, string name, string nrc, string toAccountNo, string toName, string toNRC, string toaddress, System.Nullable<decimal> testKey, decimal amount, System.Nullable<DateTime> date_Time, System.Nullable<DateTime> issueDate, string accountSign, string userNo, string budget, System.Nullable<short> printStatus, string phoneNo, string toPhoneNo, string uniqueId, string sourceBranchCode, string currency, System.Nullable<DateTime> settlementDate, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.RegisterNo = registerNo;
            this.EncashNo = encashNo;
            this.Ebank = ebank;
            this.Br_Alias = br_Alias;
            this.Type = type;
            this.Name = name;
            this.NRC = nrc;
            this.ToAccountNo = toAccountNo;
            this.ToName = toName;
            this.ToNRC = toNRC;
            this.ToAddress = toaddress;
            this.TestKey = testKey;
            this.Amount = amount;
            this.Date_Time = date_Time;
            this.IssueDate = issueDate;
            this.AccountSign = accountSign;
            this.UserNo = userNo;
            this.Budget = budget;
            this.PrintStatus = printStatus;
            this.PhoneNo = phoneNo;
            this.ToPhoneNo = toPhoneNo;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.SettlementDate = settlementDate;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public TLMDTO00001(string RegisterNo, string currency, decimal amount, string toaccountno, string toname, string name, string ebank,string sourcebranchcode)
        {
            this.RegisterNo = RegisterNo;
            this.Currency = currency;
            this.Amount = amount;
            this.ToAccountNo = toaccountno;
            this.ToName = toname;
            this.Name = name;
            this.Ebank = ebank;
            this.SourceBranchCode = sourcebranchcode;
        }

        //18
        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string toaddress, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, bool otherBank, string bankAlias)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.ToNRC = tonrc;
            this.ToAddress = toaddress;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.OtherBank = otherBank;
            this.Bank_Alias = bankAlias;
        }

        public TLMDTO00001(string eBank, string registerNo, string toacctNo, string brAlias, DateTime dateTime, string type, string toName, string toNrc, decimal amount, bool otherBank)
        {
            this.Ebank = eBank;
            this.RegisterNo = registerNo;
            this.ToAccountNo = toacctNo;
            this.Br_Alias = brAlias;
            this.Date_Time = dateTime;
            this.Type = type;
            this.ToName = toName;
            this.ToNRC = toNrc;
            this.Amount = amount;
            this.OtherBank = otherBank;
        }


        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string toaddress, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, bool otherBank)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.ToNRC = tonrc;
            this.ToAddress = toaddress;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.OtherBank = otherBank;
            // this.Bank_Alias = bankAlias;
        }


        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string toaddress, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.ToNRC = tonrc;
            this.ToAddress = toaddress;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            //this.OtherBank = otherBank;
            //this.Bank_Alias = bankAlias;
        }

        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.ToNRC = tonrc;
            // this.ToAddress = toaddress;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            //this.OtherBank = otherBank;
            //this.Bank_Alias = bankAlias;
        }

        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            //this.ToNRC = tonrc;
            // this.ToAddress = toaddress;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            //this.OtherBank = otherBank;
            //this.Bank_Alias = bankAlias;
        }

        public TLMDTO00001(string encashNo, string registerNo, string name, string bralias, string type, string toname, string toacctno, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;

        }
        //SelectAmountForEncashRemittanceBySettlementDate
        public TLMDTO00001(string encashNo, string registerNo, string name,string nrc, string bralias, string type, string toname, string toacctno, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate,string sourceBr)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourceBr;
        }
        //SelectAmountForEncashRemittanceByTransactionDate
        public TLMDTO00001(string encashNo, string registerNo, string name, string bralias, string type, string toname, string toacctno, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, string sourceBr)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            //this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourceBr;
        }
        //SelectDataForEncashRemittanceByBranchByTransactionDate
        public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type,string tonrc, string toname, string toacctno,string toaddress, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, string sourceBr)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToNRC =nrc ;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
             this.ToAddress = toaddress ;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourceBr;
        }
        //SelectDataForEncashRemittanceByBranchBySettlementDate
        public TLMDTO00001(string encashNo, string registerNo, string name,string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, string sourceBr)
        {
            this.EncashNo = encashNo;
            this.RegisterNo = registerNo;
            this.Name = name;
            this.NRC = nrc;
            this.Br_Alias = bralias;
            this.Type = type;
            //this.ToNRC = nrc;
            this.ToName = toname;
            this.ToAccountNo = toacctno;
            this.ToNRC = tonrc;
            this.Ebank = ebank;
            this.IssueDate = issueDate;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Currency = currency;
            this.SettlementDate = settlementdate;
            this.SourceBranchCode = sourceBr;
        }
        public TLMDTO00001(string eBank, string toAcctNo, string registerNo, string brAlias, DateTime dateTime, string type, string toName, string toNRC, decimal amount, string acSign, bool otherBank,string sourceBr)
        {
            this.Ebank = eBank;
            this.ToAccountNo = toAcctNo;
            this.RegisterNo = registerNo;
            this.Br_Alias = brAlias;
            this.Date_Time = dateTime;
            this.Type = type;
            this.ToName = toName;
            this.ToNRC = toNRC;
            this.Amount = amount;
            this.AccountSign = acSign;
            this.OtherBank = otherBank;
            this.SourceBranchCode = sourceBr;
        }


        #region EncashNo Editting
        // For EncashNo Editting
        public TLMDTO00001(string registerNo, string ebank,string brAlias,decimal amount,string toacctno, string toName, string toNRC, string toaddress, string name, string nrc)
        {
            this.RegisterNo = registerNo;
            this.Ebank = ebank;
            this.Br_Alias = brAlias;
            this.Amount = amount;
            this.ToAccountNo = toacctno;
            this.ToName = toName;
            this.ToNRC = toNRC;
            this.ToAddress = toaddress;
            this.Name = name;
            this.NRC = nrc;
        }
        #endregion


        public TLMDTO00001(string registerno, bool active)
        {
            this.RegisterNo = registerno;
            this.Active = active;
        }
        //For POIssue For Encashment
        public TLMDTO00001(string registerNo, string name, string currency, decimal amount, System.Nullable<DateTime> issueDate, string toacctno, bool active)
        {
            this.RegisterNo = registerNo;
            this.Name = name;
            this.Currency = currency;
            this.Amount = amount;
            this.IssueDate = issueDate;
            this.ToAccountNo = toacctno;
            this.Active = active;
        }

        ///*For Clearing Posting 19*/
        public TLMDTO00001(string registerNo,string encashno, string currency, decimal amount, string toaccountno, string toname, string name, string tonrc, string nrc, Nullable<DateTime> datetime, string ebank, string sourcebranchCode, Nullable<short> printstatus, Nullable<decimal> testkey, string bralias, string type, string toaddress, string accountsign,string budget)
        {
            this.RegisterNo = registerNo;
            this.EncashNo = encashno;
            this.Currency = currency;
            this.Amount = amount;
            this.ToAccountNo = toaccountno;
            this.ToName = toname;
            this.Name = name;
            this.ToNRC = tonrc;
            this.NRC = nrc;
            this.Date_Time = datetime;
            this.Ebank = ebank;
            this.SourceBranchCode = sourcebranchCode;
            this.PrintStatus = printstatus;
            this.TestKey = testkey;
            this.Br_Alias = bralias;
            this.Type = type;
            this.ToAddress = toaddress;
            this.ToAccountNo = toaccountno;
            this.Budget = budget;
            
        }

        ////DailyEncashRemittanceListing (same with //18)
        //public TLMDTO00001(string encashNo, string registerNo, string name, string nrc, string bralias, string type, string toname, string toacctno, string tonrc, string toaddress, string ebank, DateTime issueDate, decimal amount, DateTime datetime, string currency, DateTime settlementdate, bool otherBank, string bankAlias)
        //{
        //    this.EncashNo = encashNo;
        //    this.RegisterNo = registerNo;
        //    this.Name = name;
        //    this.NRC = nrc;
        //    this.Br_Alias = bralias;
        //    this.Type = type;
        //    this.ToName = toname;
        //    this.ToAccountNo = toacctno;
        //    this.ToNRC = tonrc;
        //    this.ToAddress = toaddress;
        //    this.Ebank = ebank;
        //    this.IssueDate = issueDate;
        //    this.Amount = amount;
        //    this.Date_Time = datetime;
        //    this.Currency = currency;
        //    this.SettlementDate = settlementdate;
        //    this.OtherBank = otherBank;
        //    this.Bank_Alias = bankAlias;
        //}

        public TLMDTO00001(DateTime issueDate, string encashNo, string bralias, string registerno, decimal amount, string ebank, DateTime datetime, string cur, DateTime settlementdate, bool otherbank, string budget)
        {
            this.IssueDate = issueDate;
            this.EncashNo = encashNo;
            this.Br_Alias = bralias;
            this.RegisterNo = registerno;
            this.Amount = amount;
            this.Ebank = ebank;
            this.Date_Time = datetime;
            this.Currency = cur;
            this.SettlementDate = settlementdate;
            this.OtherBank = otherbank;
            this.Budget = budget;
        }
        public string RegisterNo { get; set; }
        public string EncashNo{get;set;}
        public string Ebank{get;set;}
        public string Br_Alias{get;set;}
        public string Type{get;set;}
        public string Name{get;set;}
        public string NRC{get;set;}
        public string ToAccountNo { get; set; }
        public string ToName{get;set;}
        public string ToNRC{get;set;}
        public string ToAddress{get;set;}
        public System.Nullable<decimal> TestKey{get;set;}
        public decimal Amount { get; set; }
        public System.Nullable<DateTime> Date_Time{get;set;}
        public System.Nullable<DateTime> IssueDate{get;set;}
        public string AccountSign { get; set; }
        public string UserNo{get;set;}
        public string Budget{get;set;}
        public System.Nullable<short> PrintStatus{get;set;}
        public string PhoneNo{get;set;}
        public string ToPhoneNo{get;set;}
        public string UniqueId { get; set; }
        public string SourceBranchCode{get;set;}
        public string Currency{get;set;}
        public System.Nullable<DateTime> SettlementDate{get;set;}
        public string Description { get; set; }
        public string DebitOrCredit { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string FaxNo { get; set; }
        public bool IsCheck { get; set; }
        public string Status { get; set; }
        public virtual bool OtherBank { get; set; }
    
        public virtual string ENO { get; set; }
        public virtual string PONo { get; set; }
        public virtual decimal HomeExchangeRate { get; set; }
        public virtual string Channel { get; set; }
        public virtual bool POStatus { get; set; }
        public string Bank_Alias { get; set; }
        public virtual string Fax { get; set; }
        public virtual string ReportTitle { get; set; }

        public virtual int DuplicateCount { get; set; }
        public virtual string status { get; set; }
        public virtual string RegisterNo_Old { get; set; }
        public virtual string DebitACode { get; set; }
        public virtual string CreditACode { get; set; }
        public virtual string DebitACodeName { get; set; }
        public virtual string CreditACodeName { get; set; }

        #region "POPrinting"
        public DateTime RequiredDate { get; set; }
    
        #endregion

        public virtual bool IsNullPOIDate { get; set; }

       

    
      

    }
}
