//----------------------------------------------------------------------
// <copyright file="TLMORM00042.cs" company="ACE Data Systems">
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
    /// MessageCodeTranslator ORM Entity
    /// </summary>
    /// 
     [Serializable]
    public class TLMORM00055 : Supportfields<TLMORM00055>
    {
        public TLMORM00055() { }

        public virtual string ErrorCode { get; set; }
        public virtual string CXMessageCode { get; set; }
        public virtual string Description { get; set; }
    }
}
