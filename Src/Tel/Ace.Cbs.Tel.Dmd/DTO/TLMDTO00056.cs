//----------------------------------------------------------------------
// <copyright file="TLMDTO00053.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-09-26</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
    public class TLMDTO00056
    {
        public string RegisterNo { get; set; }
        public string EncashNo { get; set; }
        public string EBank { get; set; }
        public string DBank { get; set; }
        public string Br_Alias { get; set; }
        public string Type { get; set; }
        public string FromName { get; set; }
        public string FromNRC { get; set; }
        public string ToAccountNo { get; set; }
        public string ToName { get; set; }
        public string ToNRC { get; set; }
        public string ToAddress { get; set; }
        public decimal TestKey { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date_Time { get; set; }
        public DateTime IssueDate { get; set; }
        public string AccountSign { get; set; }
        public string UserNo { get; set; }
        public string Budget { get; set; }
        public string PhoneNo { get; set; }
        public string ToPhoneNo { get; set; }
        public string SourceBranch { get; set; }
        public string Currency { get; set; }
        public DateTime SettlementDate { get; set; }
        public DateTime SendDate { get; set; }
        public string Eno { get; set; }
        public string AccountNo { get; set; }
        public string Cheque { get; set; }
        public string PONo { get; set; }
        public string PONoStatus { get; set; }
        public bool CloseStatus { get; set; }
        public string BudgetYear { get; set; }
        public string NarrationText { get; set; }
        public string BranchCode { get; set; }
        public string SourceCurrency { get; set; }
        public decimal HomeExRate{ get; set; }
        public string Channel { get; set; }
        public decimal Commission { get; set; }
        public decimal TelaxCharges { get; set; }
        public int ProcessTime { get; set; }
        public int IntervalTime { get; set; }
        public bool isSelected { get; set; }
    }
}
