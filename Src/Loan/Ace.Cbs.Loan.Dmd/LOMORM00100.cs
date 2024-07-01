//----------------------------------------------------------------------
// <copyright file="MIFORM00051.cs" Name="Installment Period" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Thet Aung Khine</CreatedUser>
// <CreatedDate>24/10/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00100 : EntityBase<LOMORM00100>
    {
        public LOMORM00100() { }
        
        public virtual string NAME { get; set; }
        public virtual int NOOFDAY { get; set; }
        public virtual int NOOFMONTH { get; set; }
    }
}
