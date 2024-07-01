//----------------------------------------------------------------------
// <copyright file="TLMDTO00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
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
    public class TLMDTO00040 : Supportfields<TLMDTO00040>
    {
        public TLMDTO00040() { }

        public TLMDTO00040(string bCode, string bDesp)
        {
            this.BCode = bCode;
            this.BDesp = bDesp;
        }

        public TLMDTO00040(string bCode, string bDesp, string bAcctNo, string uId)
        {
            this.BCode = bCode;
            this.BDesp = bDesp;
            this.BAccountNo = bAcctNo;
            this.UniqueId = uId;
        }

                              //BCode,BDesp,BAccountNo,UniqueId,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00040(string bCode, string bDesp, string bAcctNo, string uId, bool active, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.BCode = bCode;
            this.BDesp = bDesp;
            this.BAccountNo = bAcctNo;
            this.UniqueId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public TLMDTO00040(string bCode, string bDesp, string bAcctNo, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.BCode = bCode;
            this.BDesp = bDesp;
            this.BAccountNo = bAcctNo;
            this.UniqueId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public string BCode { get; set; }
        public string BDesp { get; set; }
        public string BAccountNo { get; set; }
        public string UniqueId { get; set; }
        public bool IsCheck { get; set; }
    }
}
