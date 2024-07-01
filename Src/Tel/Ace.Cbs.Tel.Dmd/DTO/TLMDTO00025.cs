//----------------------------------------------------------------------
// <copyright file="TLMDTO00025.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// Reconsile DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00025 : EntityBase<TLMDTO00025>
    {
        public TLMDTO00025() { }

        public TLMDTO00025(string branchcode, DateTime datetime, string type, short dagrno, int agrno, int dupno, int cursel)
        {
            this.BranchCode =branchcode;
            this.Date_Time = datetime;
            this.Type = type;
            this.DagRno = dagrno;
            this.AgRno = agrno;
            this.DupNo = dupno;
            this.Cursel = cursel;

        }

        public TLMDTO00025(string branchcode, DateTime datetime, string type, short dagrno, int agrno, int dupno, int cursel,string sourceBranch,string branchdescription,string branchalias)
        {
           // this.BranchCode = branchcode;
            this.Date_Time = datetime;
            this.Type = type;
            this.DagRno = dagrno;
            this.AgRno = agrno;
            this.DupNo = dupno;
            this.Cursel = cursel;
            this.SourceBranchCode = sourceBranch;
            this.Branch = new BranchDTO(branchcode, branchdescription, branchalias);

        }

        public TLMDTO00025(string branchcode)
        {
            this.BranchCode = branchcode;          
        }
        public virtual string BranchCode { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual System.Nullable<short> DagRno { get; set; }
        public virtual System.Nullable<int> AgRno { get; set; }
        public virtual System.Nullable<int> DupNo { get; set; }
        public virtual System.Nullable<int> Cursel { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string Status { get; set; }
        public virtual BranchDTO Branch { get; set; }

        public virtual IList<TLMDTO00017> RDInfo { get; set; }
        public virtual IList<TLMDTO00001> REInfo { get; set; }
        public virtual IList<TLMDTO00004> IBLTLFInfo { get; set; }
    }
}
