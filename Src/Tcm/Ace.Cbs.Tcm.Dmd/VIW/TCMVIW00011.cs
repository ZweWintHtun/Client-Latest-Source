//----------------------------------------------------------------------
// <copyright file="TCMVIW00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-07</CreatedDate>
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
  public class TCMVIW00011
    {
      public TCMVIW00011() { }
      public virtual int Id { get; set; }
      public virtual Nullable<DateTime> ChkTime { get; set; }
      public virtual DateTime DateTime { get; set; }
      public virtual string Eno { get; set; }
      public virtual string AccountNo { get; set; }
      public virtual string OrgneNo { get; set; }
      public virtual string OtherBank { get; set; }
      public virtual string SourceCur { get; set; }
      public virtual decimal? LocalAmount { get; set; }
      public virtual string OtherBankChq { get; set; }
      public virtual string TranCode { get; set; }
      public virtual string Status { get; set; }
      public virtual string Description { get; set; }
      public virtual string WorkStation { get; set; }
      public virtual string SourceBr { get; set; }
      public virtual bool Active { get; set; }
    }
}
