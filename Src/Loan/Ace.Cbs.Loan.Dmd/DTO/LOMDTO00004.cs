//----------------------------------------------------------------------
// <copyright file="LONDTO00004.cs" Name="INSURAN" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Insurance DTO Entity
    /// </summary>
    /// 
    [Serializable]
    public class LOMDTO00004 : Supportfields<LOMDTO00004>
    {
        public LOMDTO00004() { }

        public LOMDTO00004(string iNSUCODE, string iNSUDESP)
        {
            this.INSUCODE = iNSUCODE;
            this.INSUDESP = iNSUDESP;
        }

        public LOMDTO00004(string iNSUCODE, string iNSUDESP, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.INSUCODE = iNSUCODE;
            this.INSUDESP = iNSUDESP;
           
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00004(string iNSUCODE, string iNSUDESP,DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.INSUCODE = iNSUCODE;
            this.INSUDESP = iNSUDESP;
          
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00004(string iNSUCODE, string iNSUDESP, byte[] tS,bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.INSUCODE = iNSUCODE;
            this.INSUDESP = iNSUDESP;            
            this.TS = tS;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }



        public virtual string INSUCODE { get; set; }
        public virtual string INSUDESP { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}