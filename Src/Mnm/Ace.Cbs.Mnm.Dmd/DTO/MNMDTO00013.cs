//----------------------------------------------------------------------
// <copyright file="MNMDTO00013.cs" Name="DATEFILE" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
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
    public class MNMDTO00013 : Supportfields<MNMDTO00013>
    {
        public MNMDTO00013() { }

        public MNMDTO00013(DateTime fIXINTDATE, DateTime fIXVOUDATE, string uID, string sOURCEBR)
        {
            this.FIXINTDATE = fIXINTDATE;
            this.FIXVOUDATE = fIXVOUDATE;
            this.UID = uID;
            this.SOURCEBR = sOURCEBR;
        }

        
        public virtual DateTime FIXINTDATE { get; set; }
        public virtual DateTime FIXVOUDATE { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}