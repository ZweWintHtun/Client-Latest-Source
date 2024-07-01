//----------------------------------------------------------------------
// <copyright file="TLMDTO00008.cs" Name="DEP_TLF" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KoKoTun</CreatedUser>
// <CreatedDate>01/24/2014</CreatedDate>
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
    [Serializable]
    public class TLMDTO00008 : Supportfields<TLMDTO00008>
    {
        public TLMDTO00008() { }

        public TLMDTO00008(int id, string eNO, string dEPCODE, string aCCTNO, string nAME, decimal qUANTITY, decimal aMOUNT, decimal qUOTANO, System.Nullable<DateTime> dATE_TIME, string sTATUS, string uID, string sOURCEBR, string currencyCode, System.Nullable<decimal> rATE, System.Nullable<DateTime> sETTLEMENTDATE)
        {
            this.Id = id;
            this.ENO = eNO;
            this.DepositCode = dEPCODE;
            this.AccountNo = aCCTNO;
            this.NAME = nAME;
            this.Quantity = qUANTITY;
            this.AMOUNT = aMOUNT;
            this.QUOTANO = qUOTANO;
            this.DATE_TIME = dATE_TIME;
            this.STATUS = sTATUS;
            this.UID = uID;
            this.SourceBranchCode = sOURCEBR;
            this.CurrencyCode = currencyCode;
            this.RATE = rATE;
            this.SETTLEMENTDATE = sETTLEMENTDATE;
        }

        public TLMDTO00008(int id, string eNO, string dEPCODE, string aCCTNO, string nAME, decimal qUANTITY, decimal aMOUNT, decimal qUOTANO, System.Nullable<DateTime> dATE_TIME, string sTATUS, string uID, string sOURCEBR, string currencyCode, System.Nullable<decimal> rATE, System.Nullable<DateTime> sETTLEMENTDATE, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.Id = id;
            this.ENO = eNO;
            this.DepositCode = dEPCODE;
            this.AccountNo = aCCTNO;
            this.NAME = nAME;
            this.Quantity = qUANTITY;
            this.AMOUNT = aMOUNT;
            this.QUOTANO = qUOTANO;
            this.DATE_TIME = dATE_TIME;
            this.STATUS = sTATUS;
            this.UID = uID;
            this.SourceBranchCode = sOURCEBR;
            this.CurrencyCode = currencyCode;
            this.RATE = rATE;
            this.SETTLEMENTDATE = sETTLEMENTDATE;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public int SrNo { get; set; }
        public virtual int Id { get; set; }
        public virtual string ENO { get; set; }
        public virtual string DepositCode { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual decimal QUOTANO { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }        
        public virtual System.Nullable<decimal> RATE { get; set; }
        public virtual System.Nullable<DateTime> SETTLEMENTDATE { get; set; }
        public virtual bool IsCheck { get; set; }
        public decimal AccumulateAmount { get; set; }
    }
}