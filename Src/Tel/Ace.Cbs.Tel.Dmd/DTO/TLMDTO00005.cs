//----------------------------------------------------------------------
// <copyright file="TLMDTO00005.cs" company="ACE Data Systems">
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
    /// TranType DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00005 : Supportfields<TLMDTO00005>
    {
       public TLMDTO00005() { }
       public TLMDTO00005(string status) 
       {
           this.Status = status;
       }
       public TLMDTO00005(string transactionCode,string description,string narration,string status,string pBReference,string rVReference,string uniqueId)
       {
           this.TransactionCode = transactionCode;
           this.Description = description;
           this.Narration = narration;
           this.Status = status;
           this.PBReference = pBReference;
           this.RVReference = rVReference;
           this.UniqueId = uniqueId;
       }

       public TLMDTO00005(string transactionCode, string desp, string narration, string status, string pBReference, string rVReference, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
       {
           this.TransactionCode = transactionCode;
           this.Description = desp;
           this.Narration = narration;
           this.Status = status;
           this.PBReference = pBReference;
           this.RVReference = rVReference;
           this.UniqueId = uId;
           this.Active = active;
           this.TS = tS;
           this.CreatedDate = createdDate;
           this.CreatedUserId = createdUserId;
           this.UpdatedDate = updatedDate;
           this.UpdatedUserId = updatedUserId;
       }

       //TransactionCode,Description,Narration,Status,PBReference,RVReference,UniqueId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
       public TLMDTO00005(string transactionCode, string desp, string narration, string status, string pBReference, string rVReference, string uId, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
       {
           this.TransactionCode = transactionCode;
           this.Description = desp;
           this.Narration = narration;
           this.Status = status;
           this.PBReference = pBReference;
           this.RVReference = rVReference;
           this.UniqueId = uId;
           this.Active = active;
           this.TS = tS;
           this.CreatedDate = createdDate;
           this.CreatedUserId = createdUserId;
           this.UpdatedDate = updatedDate;
           this.UpdatedUserId = updatedUserId;
       }		

       public virtual string TransactionCode{get;set;}
       public virtual string Description { get; set; }
       public virtual string Narration { get; set; }
       public virtual string Status { get; set; }
       public virtual string PBReference { get; set; }
       public virtual string RVReference { get; set; }
       public virtual string UniqueId { get; set; }
       public virtual bool IsCheck { get; set; }	
    }
}
