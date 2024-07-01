//----------------------------------------------------------------------
// <copyright file="TLMDTO000XX.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-11</CreatedDate>
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
    /// MessageCodeTranslator DTO Entity
    /// </summary>     
    [Serializable]
    public class TLMDTO00055 : Supportfields<TLMDTO00055>
    {
        public TLMDTO00055() { }

        //ErrorCode,CXMessageCode,Description,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public TLMDTO00055(string errorCode, string cxMessageCode, string desp, bool active, DateTime createdDate, 
            int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, byte[] tS)
        {
            this.ErrorCode = errorCode;
            this.CXMessageCode = cxMessageCode;
            this.Description = desp;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.TS = tS;
        }


        public TLMDTO00055(string cxMessageCode)
        {
            this.CXMessageCode = cxMessageCode;
        }

        public string ErrorCode { get; set; }
        public string CXMessageCode { get; set; }
        public string Description { get; set; }
    }
}
