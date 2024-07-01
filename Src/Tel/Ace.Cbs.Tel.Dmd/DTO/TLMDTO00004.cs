//----------------------------------------------------------------------
// <copyright file="TLMDTO00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
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
    /// IblTLF DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00004 : EntityBase<TLMDTO00004>
    {
        public TLMDTO00004() { }
        public TLMDTO00004(int id) 
        {
            this.Id = id + 1;
        }

        public TLMDTO00004(string relatedAccount, string relatedBr)
        {
            this.RelatedBranch = relatedBr;
            this.RelatedAccount = relatedAccount;
        }

        public TLMDTO00004(string eno, DateTime date_time, decimal amount, string cheque, string accountNo)
        {
            this.Eno = eno;
            this.Date_Time = date_time;
            this.Amount = amount;
            this.Cheque = cheque;
            this.AccountNo = accountNo;
        }

        public TLMDTO00004(string tobranch,string eno,string currency,decimal amount,string relatedAccount, string cheque, string accountNo,string tranType)
        {
            this.ToBranch = tobranch;
            this.Eno = eno;
            this.Currency = currency;
            this.Amount = amount;
            this.RelatedAccount = relatedAccount;
            this.Cheque = cheque;
            this.AccountNo = accountNo;
            this.TranType = tranType;
        }

        public TLMDTO00004(string accountno)
        {
            this.AccountNo = accountno;
        }

        public TLMDTO00004(int id, string fromBranch, string toBranch, string acctNo, decimal amount, string tranType, DateTime dATE_TIME, bool inOut, bool success, string eNo, string uSERNO, string cheque, System.Nullable<decimal> income, System.Nullable<decimal> commuCharge, System.Nullable<bool> reversal, System.Nullable<int> incomeType, string relatedAC, string relatedBr, string uID, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.FromBranch = fromBranch;
            this.ToBranch = toBranch;
            this.AccountNo = acctNo;
            this.Amount = amount;
            this.TranType = tranType;
            this.Date_Time = dATE_TIME;
            this.InOut = inOut;
            this.Success = success;
            this.Eno = eNo;
            this.UserNo = uSERNO;
            this.Cheque = cheque;
            this.Income = income;
            this.Communicationcharge = commuCharge;
            this.Reversal = reversal;
            this.IncomeType = incomeType;
            this.RelatedAccount = relatedAC;
            this.RelatedBranch = relatedBr;
            this.UniqueId = uID;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		

        public TLMDTO00004(string acctno, decimal income, decimal communicationcharge)
        {
            this.AccountNo = acctno;
            this.Income = income;
            this.Communicationcharge = communicationcharge;
        }


        public TLMDTO00004(int id, string fromBranch, string toBranch, string accountNo, decimal amount, string tranType, DateTime date_Time, bool inOut, bool success, string eno, string userNo, string cheque, decimal income, decimal communicationcharge, bool reversal, int incomeType, string relatedAccount, string relatedBranch, string uniqueId, string sourceBranchCode, string currency, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.FromBranch = fromBranch;
            this.ToBranch = toBranch;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.TranType = tranType;
            this.Date_Time = date_Time;
            this.InOut = inOut;
            this.Success = success;
            this.Eno = eno;
            this.UserNo = userNo;
            this.Cheque = cheque;
            this.Income = income;
            this.Communicationcharge = communicationcharge;
            this.Reversal = reversal;
            this.IncomeType = incomeType;
            this.RelatedAccount = relatedAccount;
            this.RelatedBranch = relatedBranch;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBranchCode;
            this.Currency = currency;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        #region NMS
        public TLMDTO00004(string fromBranch, string toBranch, string accountNo, decimal amount, string trantype, DateTime dateTime, bool inOut, bool success, string eNo, string userNo, string cheque, decimal inCome, decimal communicationCharge, bool reversal,
           int incomeType, string relatedAC, string relatedBranch, string sourceBr, string currency, string branchCode, string branchAlias, string branchDescription)
        {
            this.FromBranch = fromBranch;
            this.ToBranch = toBranch;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.TranType = trantype;
            this.Date_Time = dateTime;
            this.InOut = inOut;
            this.Success = success;
            this.Eno = eNo;
            this.UserNo = userNo;
            this.Cheque = cheque;
            this.Income = inCome;
            this.Communicationcharge = communicationCharge;
            this.Reversal = reversal;
            this.IncomeType = incomeType;
            this.RelatedAccount = relatedAC;
            this.RelatedBranch = relatedBranch;
            this.SourceBranchCode = sourceBr;
            this.Currency = currency;
            this.BranchCode = branchCode;
            this.BranchAlias = branchAlias;
            this.BranchDescription = branchDescription;
        }

        public TLMDTO00004(string fromBranch, string toBranch, string accountNo, decimal amount, string trantype, DateTime dateTime, bool inOut, bool success, string eNo, string userNo, string cheque, decimal inCome, decimal communicationCharge, bool reversal,
        int incomeType, string relatedAC, string relatedBranch, string sourceBr, string currency)
        {
            this.FromBranch = fromBranch;
            this.ToBranch = toBranch;
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.TranType = trantype;
            this.Date_Time = dateTime;
            this.InOut = inOut;
            this.Success = success;
            this.Eno = eNo;
            this.UserNo = userNo;
            this.Cheque = cheque;
            this.Income = inCome;
            this.Communicationcharge = communicationCharge;
            this.Reversal = reversal;
            this.IncomeType = incomeType;
            this.RelatedAccount = relatedAC;
            this.RelatedBranch = relatedBranch;
            this.SourceBranchCode = sourceBr;
            this.Currency = currency;
            
        }

       
        #endregion

        public virtual int Id { get; set; }
        public virtual string FromBranch{get;set;}
        public virtual string ToBranch{get;set;}
        public virtual string AccountNo{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual string TranType{get;set;}
        public virtual System.DateTime Date_Time{get;set;}
        public virtual bool InOut{get;set;}
        public virtual bool Success{get;set;}
        public virtual string Eno{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Cheque{get;set;}
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> Communicationcharge { get; set; }
        public virtual System.Nullable<bool> Reversal{get;set;}
        public virtual int? IncomeType { get; set; }
        public virtual string RelatedAccount { get; set; }
        public virtual string RelatedBranch { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string ActiveAccount { get; set; }
        public decimal HomeCreditCashAmount { get; set; }
        public decimal HomeDebitCashAmount { get; set; }
        public decimal HomeCreditTransferAmount { get; set; }
        public decimal HomeDebitTransferAmount { get; set; }

        public decimal ActiveCreditCashAmount { get; set; }
        public decimal ActiveDebitCashAmount { get; set; }
        public decimal ActiveCreditTransferAmount { get; set; }
        public decimal ActiveDebitTransferAmount { get; set; }
       

        #region NMS
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string BankName { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string BranchAlias { get; set; }
        public virtual string BranchDescription { get; set; }
        public virtual string ReportTitle { get; set; }
        public virtual string Status { get; set; }
        public virtual string IncomeTypeStatus { get; set; }
        #endregion

    }
}
