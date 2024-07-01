//----------------------------------------------------------------------
// <copyright file="ILOMCTL00032" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00032 : IPresenter
    {
        ILOMVEW00032 View { get; set; }
        void Print();        
    }

    public interface ILOMVEW00032
    {
        ILOMCTL00032 Controller { get; set; }
        string LegalAccountNo { get; set; }
        void SetFocus();     
    }
}
