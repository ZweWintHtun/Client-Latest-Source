//----------------------------------------------------------------------
// <copyright file="TLMDTO00010.cs" company="ACE Data Systems">
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
    /// Workstation DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00010 : EntityBase<TLMDTO00010>
    {
        public TLMDTO00010(string counterno)
        {
            this.CounterNo = counterno;
        }

        public TLMDTO00010(int id, string name, string iPAddress, string logOnUserId, string logOnGroupId, string printerName, string hostName, string maskAddress, string uniqueId, string sourceBr, string counterNo)
        {
            this.Id = id;
            this.Name = name;
            this.IPAddress = iPAddress;
            this.LogOnUserId = logOnUserId;
            this.LogOnGroupId = logOnGroupId;
            this.PrinterName = printerName;
            this.HostName = hostName;
            this.MaskAddress = maskAddress;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBr;
            this.CounterNo = counterNo;
        }

        public TLMDTO00010(int id, string name, string iPAddress, string logOnUserId, string logOnGroupId, string printerName, string hostName, string maskAddress, string uniqueId, string sourceBr, string counterNo, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.Name = name;
            this.IPAddress = iPAddress;
            this.LogOnUserId = logOnUserId;
            this.LogOnGroupId = logOnGroupId;
            this.PrinterName = printerName;
            this.HostName = hostName;
            this.MaskAddress = maskAddress;
            this.UniqueId = uniqueId;
            this.SourceBranchCode = sourceBr;
            this.CounterNo = counterNo;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }		

        public TLMDTO00010() { }
        public virtual string Name { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual string LogOnUserId { get; set; }
        public virtual string LogOnGroupId { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual string HostName { get; set; }
        public virtual string MaskAddress { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual bool IsCheck { get; set; }
        public TLMDTO00002 CounterInfo { get; set; }
    }
}
