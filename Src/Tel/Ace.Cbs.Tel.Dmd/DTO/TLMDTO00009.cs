//----------------------------------------------------------------------
// <copyright file="TLMDTO00009.cs" company="ACE Data Systems">
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
    /// Depodeno DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00009 : Supportfields<TLMDTO00009>
    {
        public TLMDTO00009() { }

     //     ( vw_multideno.tlf_eno,
     //vw_multideno.groupno,
     //vw_multideno.actype,
     //vw_multideno.amount,
     //vw_multideno.userno,
     //vw_multideno.Income,
     //vw_multideno.Commucharge,
     //vw_multideno.counterno)
        public TLMDTO00009(string tlfeno, string groupno, string actype, Nullable<decimal> amount, string userno,
            Nullable<decimal> income,Nullable<decimal> comCharges,string counterNo)
        {
            this.GroupNo = groupno;
            this.Tlf_Eno = tlfeno;
            this.AccountType = actype;
            this.Amount = amount.Value;
            this.UserNo = userno;
            this.Income = income;
            this.Communicationcharge = comCharges;
            this.CounterNo = counterNo;
        }

        public TLMDTO00009(string tlfeno,string entryno,string accounttype,Nullable<decimal> amount,string currency,string sourcebranch) 
        {
            this.GroupNo = tlfeno;
            this.Tlf_Eno = entryno;
            this.AccountType = accounttype;
            this.Amount = amount.Value;
            this.Currency = currency;
            this.SourceBranchCode = sourcebranch;

        }
        public TLMDTO00009(string groupNo, string eno, decimal amount)
        {
            this.GroupNo = groupNo;
            this.Tlf_Eno = eno;
            this.Amount = amount;
        }

        public TLMDTO00009(int groupNo)
        {
            this.Id = groupNo;
        }
        public TLMDTO00009(int id, string groupNo, string tlf_Eno, string acType, decimal amount, bool reverse_Status, System.Nullable<decimal> income, System.Nullable<decimal> commuCharge, string uId, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.Tlf_Eno = tlf_Eno;
            this.AccountType = acType;
            this.Amount = amount;
            this.Reverse_Status = reverse_Status;
            this.Income = income;
            this.Communicationcharge = commuCharge;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }		

        public TLMDTO00009(string actype, decimal income, decimal charges)
        {
            this.AccountType = actype;
            this.Income = income;
            this.Communicationcharge = charges;
        }

        public TLMDTO00009(decimal amount)
        {
            this.Amount = amount;
        }

        public TLMDTO00009(string groupNo,bool reverse) 
        {
            this.GroupNo = groupNo;
            this.Reverse_Status = reverse;
        }

        public TLMDTO00009(string accountType,decimal amount , bool active)
        {
            this.AccountType = accountType;
            this.Amount = amount;
            this.Active = active;
        }
        public TLMDTO00009(string accountType, decimal amount, bool active, string tlf_Eno)
        {
            this.AccountType = accountType;
            this.Amount = amount;
            this.Active = active;
            this.Tlf_Eno = tlf_Eno;
        }
        public TLMDTO00009(string accountType, string tlf_Eno, decimal amount, string Cur)
        {
            this.AccountType = accountType;
            this.Amount = amount;
            this.Currency = Cur;
            this.Tlf_Eno = tlf_Eno;
        }

        //Added By ZMS For Multiple Deposit And Withdraw Reversal (19/12/2017)
        public TLMDTO00009(string accountType, string eno,bool rStatus)
        {
            this.AccountType = accountType;
            this.Tlf_Eno = eno;
            this.Reverse_Status = rStatus;
        }

        public virtual int Id { get; set; }
        public virtual string GroupNo{get;set;}
        public virtual string Tlf_Eno{get;set;}
        public virtual string AccountType{get;set;}
        public virtual decimal Amount { get; set; }
        public virtual bool Reverse_Status{get;set;}
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> Commissions { get; set; }
        public virtual System.Nullable<decimal> Communicationcharge { get; set; }
        public virtual string UserNo{get;set;}
        public virtual string CounterNo { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual string BankName { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
    }
}
