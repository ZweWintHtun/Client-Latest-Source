//----------------------------------------------------------------------
// <copyright file="TLMDTO00048.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Phyu Lin</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd.DTO
{
    [Serializable]
    public class TLMDTO00048 : Supportfields<TLMDTO00048>
    {
        public TLMDTO00048() { }

        public virtual string RegisterNo { get; set; }
        public virtual string EncashNo { get; set; }
        public virtual string Ebank { get; set; }
        public virtual string Br_Alias { get; set; }
        public virtual string Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string ToName { get; set; }
        public virtual string ToNRC { get; set; }
        public virtual string ToAddress { get; set; }
        public virtual string ToPhoneNo { get; set; }
        public virtual System.Nullable<decimal> TestKey { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Budget { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string Eno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string PONo { get; set; }
        public virtual bool POStatus { get; set; }
        public virtual bool CloseStatus { get; set; }
        public virtual string Narration { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string HomeExchangeRate { get; set; }
        public virtual string Channel { get; set; }
    }
}
