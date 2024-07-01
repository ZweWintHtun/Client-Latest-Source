//----------------------------------------------------------------------
// <copyright file="SAmDTO00003.cs" Name="HOLIDAY" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Dmd
{
    [Serializable]
    public class SAMDTO00003 : Supportfields<SAMDTO00003>
    {
        public SAMDTO00003() { }

        public SAMDTO00003( DateTime dATE, string dESCRIPTION )
        {
            this.DATE = dATE;
            this.DESCRIPTION = dESCRIPTION;
        }

        public SAMDTO00003(int id, DateTime dATE, string dESCRIPTION, string uSERNO, string uID)
        {
            this.Id = id;
            this.DATE = dATE;
            this.DESCRIPTION = dESCRIPTION;
            this.USERNO = uSERNO;
            this.UID = uID;
        }

        public SAMDTO00003(int id, DateTime dATE, string dESCRIPTION, string uSERNO, string uID, bool active, byte[] tS, int createdUserId, DateTime createdDate, Nullable<int> updatedUserId, Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.DATE = dATE;
            this.DESCRIPTION = dESCRIPTION;
            this.USERNO = uSERNO;
            this.UID = uID;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

                            //Id,DATE,DESCRIPTION,USERNO,UID,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public SAMDTO00003(int id, DateTime dATE, string dESCRIPTION, string uSERNO, string uID, bool active, DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId, byte[] tS)
        {
            this.Id = id;
            this.DATE = dATE;
            this.DESCRIPTION = dESCRIPTION;
            this.USERNO = uSERNO;
            this.UID = uID;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual int Id { get; set; }
        public virtual DateTime DATE { get; set; }
        public virtual string DESCRIPTION { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string UID { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}