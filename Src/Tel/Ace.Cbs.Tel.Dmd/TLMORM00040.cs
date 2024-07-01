//----------------------------------------------------------------------
// <copyright file="TLMORM00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
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
    /// BcodeDTO
    /// </summary>
   [Serializable]
   public class TLMORM00040:Supportfields<TLMORM00040>
    {
       public TLMORM00040() { }

       public virtual string BCode { get; set; }
       public virtual string BDesp { get; set; }
       public virtual string BAccountNo { get; set; }
       public virtual string UniqueId { get; set; }
    }
}
