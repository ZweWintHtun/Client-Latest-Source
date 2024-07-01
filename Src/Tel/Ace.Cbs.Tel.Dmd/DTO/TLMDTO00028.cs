//----------------------------------------------------------------------
// <copyright file="TLMORM00028.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
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
    /// RemitBranch DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00028 : EntityBase<TLMDTO00028>
    {
      
     
         public TLMDTO00028() { }

         public TLMDTO00028(int id)
         {
             this.Id = this.Id;
         }

         public TLMDTO00028(string encashAccount, string irpoaccount)
         {
             this.EncashAccount = encashAccount;
             this.IRPOAccount = irpoaccount;

         }
         public TLMDTO00028(string drawingAccount, string telaxAccount, string iBSComAccount)
         {
             this.DrawingAccount = drawingAccount;
             this.TelaxAccount = telaxAccount;
             this.IBSComAccount = iBSComAccount;
         }
         public TLMDTO00028(decimal ttserial)
         {
             this.TTSerial = ttserial;
         }

         public TLMDTO00028(decimal telaxCharges, bool active)
         {
             this.TelaxCharges = telaxCharges;
         }

         //Id,BranchCode,TelaxCharges,TTSerial,DraftSerial,StateCode,DrawingAccount,EncashAccount,IBSComAccount,TelaxAccount,
         //IblSerial,IRPOAccount,UniqueIdentifier,SourceBranchCode,Currency,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
         public TLMDTO00028(int id, string bRANCHCODE, decimal tLXCHARGES, decimal tTSERIAL, decimal dRFTSERIAL, string sTATECODE,
             string dRAWAC, string eNCASHAC, string iBSCOMAC, string tELEXAC, System.Nullable<decimal> iBLSERIAL, string iRPOAC,
             string uID, string sOURCEBR, string cUR, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
         {
             this.Id = id;
             this.BranchCode = bRANCHCODE;
             this.TelaxCharges = tLXCHARGES;
             this.TTSerial = tTSERIAL;
             this.DraftSerial = dRFTSERIAL;

             this.StateCode = sTATECODE;
             this.DrawingAccount = dRAWAC;

             this.EncashAccount = eNCASHAC;

             this.IBSComAccount = iBSCOMAC;
             this.TelaxAccount = tELEXAC;
             this.IblSerial = iBLSERIAL;

             this.IRPOAccount = iRPOAC;
             this.UniqueIdentifier = uID;
             this.SourceBranchCode = sOURCEBR;

             this.Currency = cUR;
             this.Active = active;
             this.TS = tS;
             this.CreatedDate = createdDate;
             this.CreatedUserId = createdUserId;
             this.UpdatedDate = updatedDate;
             this.UpdatedUserId = updatedUserId;
         }

        
        public TLMDTO00028(int id, string bRANCHCODE, decimal tLXCHARGES, decimal tTSERIAL, decimal dRFTSERIAL, string sTATECODE, string dRAWAC, string eNCASHAC, string iBSCOMAC, string tELEXAC, System.Nullable<decimal> iBLSERIAL, string iRPOAC, string uID, string sOURCEBR, string cUR, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
         {
             this.Id = id;
             this.BranchCode = bRANCHCODE;
             this.TelaxCharges = tLXCHARGES;
             this.TTSerial = tTSERIAL;
             this.DraftSerial = dRFTSERIAL;
             this.StateCode = sTATECODE;
             this.DrawingAccount = dRAWAC;
             this.EncashAccount = eNCASHAC;
             this.IBSComAccount = iBSCOMAC;
             this.TelaxAccount = tELEXAC;
             this.IblSerial = iBLSERIAL;
             this.IRPOAccount = iRPOAC;
             this.UniqueIdentifier = uID;
             this.SourceBranchCode = sOURCEBR;
             this.Currency = cUR;
             this.Active = active;
             this.TS = tS;
             this.CreatedDate = createdDate;
             this.CreatedUserId = createdUserId;
             this.UpdatedDate = updatedDate;
             this.UpdatedUserId = updatedUserId;
         }


      public IList<TLMDTO00032> RemitRates { get; set; }
      public string BranchCode { get; set; }
      public decimal TelaxCharges { get; set; }
      public decimal TTSerial { get; set; }
      public decimal DraftSerial { get; set; }
      public string StateCode { get; set; }
      public string DrawingAccount { get; set; }
      public string EncashAccount { get; set; }
      public string IBSComAccount { get; set; }
      public string TelaxAccount { get; set; }
      public System.Nullable<Decimal> IblSerial { get; set; }
      public string IRPOAccount { get; set; }
      public string UniqueIdentifier { get; set; }
      public string SourceBranchCode { get; set; }
      public string Currency { get; set; }
      public string Status { get; set; }
    }
}
