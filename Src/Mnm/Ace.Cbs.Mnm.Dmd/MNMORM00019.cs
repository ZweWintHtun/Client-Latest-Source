//----------------------------------------------------------------------
// <copyright file="MNMORM00019.cs" Name="Prev_RE" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SSA</CreatedUser>
// <CreatedDate>03/31/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMORM00019 : EntityBase<MNMORM00019>
    {
        public MNMORM00019() { }

        public virtual string RegisterNo { get; set; }
        public string EncashNo { get; set; }
        public string Ebank { get; set; }
        public string Br_Alias { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string NRC { get; set; }
        public string ToAccountNo { get; set; }
        public string ToName { get; set; }
        public string ToNRC { get; set; }
        public string ToAddress { get; set; }
        public System.Nullable<decimal> TestKey { get; set; }
        public decimal Amount { get; set; }
        public System.Nullable<DateTime> Date_Time { get; set; }
        public System.Nullable<DateTime> IssueDate { get; set; }
        public string AccountSign { get; set; }
        public string UserNo { get; set; }
        public string Budget { get; set; }
        public System.Nullable<short> PrintStatus { get; set; }
        public string PhoneNo { get; set; }
        public string ToPhoneNo { get; set; }
        public string UniqueId { get; set; }
        public string SourceBranchCode { get; set; }
        public string Currency { get; set; }
        public System.Nullable<DateTime> SettlementDate { get; set; }


       
    }
}