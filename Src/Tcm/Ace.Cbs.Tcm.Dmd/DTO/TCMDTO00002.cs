//----------------------------------------------------------------------
// <copyright file="TCMDTO00002.cs" Name="Service_Charges" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/14/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00002 : EntityBase<TCMDTO00002>
    {
        public TCMDTO00002() { }

        public TCMDTO00002(int id) 
        {
            this.Id = id;
        }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Desp { get; set; }
        public virtual string GetColo { get; set; }
        public virtual DateTime VouDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}	
