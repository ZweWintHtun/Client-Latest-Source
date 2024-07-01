//----------------------------------------------------------------------
// <copyright file="TLMORM00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Naway Ei Ei Aung</CreatedUser>
// <CreatedDate>2013-11-26</CreatedDate>
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
    /// DrawingPrinting ORM Entity
    /// </summary>
    [Serializable]
    public class TLMORM00021:EntityBase<TLMORM00021>
    {
        public TLMORM00021() { }

        public virtual string RegisterNo { get; set; }
        public virtual string RAmount { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string UniqueId { get; set; }
        
        
        
    }
}
