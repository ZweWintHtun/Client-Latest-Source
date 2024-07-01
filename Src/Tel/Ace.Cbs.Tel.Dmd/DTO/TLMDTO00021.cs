//----------------------------------------------------------------------
// <copyright file="TLMDTO00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nway Ei Ei Aung</CreatedUser>
// <CreatedDate>2013-11-26</CreatedDate>
// <UpdatedUser>Khin Phyu Lin</UpdatedUser>
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
    /// DrawingPrinting DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00021:Supportfields<TLMDTO00021>
    {
        public TLMDTO00021() { }

        public TLMDTO00021(int id)
        {
            this.Id = id;
        }

        public virtual int Id { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string RAmount { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string UniqueId { get; set; }
        
    }
}
