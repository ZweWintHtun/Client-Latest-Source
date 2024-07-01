//----------------------------------------------------------------------
// <copyright file="TLMDTO00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// RemitBranchIBL DTO Entity
    /// </summary>
    [Serializable]
  public class TLMDTO00029 : EntityBase<TLMDTO00029>
  {
      public TLMDTO00029() { }

      public TLMDTO00029(int Id)
      {
          this.Id = this.Id;
      }

      public TLMDTO00029(decimal TelaxCharges, string iBSComAccount, string telaxAccount) 
      {
          this.TelaxCharges = TelaxCharges;
          this.IBSComAccount = iBSComAccount;
          this.TelaxAccount = telaxAccount;
      }

      public TLMDTO00029(decimal TelaxCharges)
      {
          this.TelaxCharges = TelaxCharges;
      }

      public TLMDTO00029(decimal IblSerial,string branchcode)
      {
          this.IblSerial = IblSerial;
          this.BranchCode = branchcode;
      }

      public TLMDTO00029(string drawingAccount, string encashAccount, string ibsComAccount, string telaxAccount) 
      {
          this.DrawingAccount = drawingAccount;
          this.EncashAccount = encashAccount;
          this.IBSComAccount = ibsComAccount;
          this.TelaxAccount = telaxAccount;
      }

        //Id,BranchCode,TelaxCharges,TTSerial,DraftSerial,StateCode,DrawingAccount,EncashAccount,IBSComAccount,TelaxAccount,IblSerial
        //,IRPOAccount,UniqueIdentifier,SourceBranchCode,Currency,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
      public TLMDTO00029(int id, string bRANCHCODE, decimal tLXCHARGES, decimal tTSERIAL, decimal dRFTSERIAL, string sTATECODE,
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

        public TLMDTO00029(int id, string bRANCHCODE, decimal tLXCHARGES, decimal tTSERIAL, decimal dRFTSERIAL, string sTATECODE, string dRAWAC, string eNCASHAC, string iBSCOMAC, string tELEXAC, System.Nullable<decimal> iBLSERIAL, string iRPOAC, string uID, string sOURCEBR, string cUR, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
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

        public TLMDTO00029(decimal iblserial, bool active)
        {
            this.IblSerial = iblserial;
        }

      public virtual IList<TLMDTO00030> RmitIblRates { get; set; }
      public virtual string BranchCode { get; set; }
      public virtual decimal TelaxCharges { get; set; }
      public virtual decimal TTSerial { get; set; }
      public virtual decimal DraftSerial { get; set; }
      public virtual string StateCode { get; set; }
      public virtual string DrawingAccount { get; set; }
      public virtual string EncashAccount { get; set; }
      public virtual string IBSComAccount { get; set; }
      public virtual string TelaxAccount { get; set; }
      public virtual System.Nullable<Decimal> IblSerial { get; set; }
      public virtual string IRPOAccount { get; set; }
      public virtual string UniqueIdentifier { get; set; }
      public virtual string SourceBranchCode { get; set; }
      public virtual string Currency { get; set; }

      public virtual string Status { get; set; }
   
    }
}
