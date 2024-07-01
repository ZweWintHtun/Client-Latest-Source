//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>31/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// Sub Ledger by Transaction Controller interface
    /// </summary>
    public interface IMNMCTL00053 : IPresenter
    {
        IMNMVEW00053 View { get; set; }
        void Print();
    }

    /// <summary>
    /// Sub Ledger by Transaction View interface
    /// </summary>
    public interface IMNMVEW00053
    {
        IMNMCTL00053 Controller { get; set; }
        bool ACTypeAll { get; }
        bool ACTypeCurrent { get; }
        bool ACTypeSaving { get; }
        bool ACTypeFixed { get; }
        bool ACTypeOD { get; }
        bool SortAccountNo { get; }
        bool SortAmount { get; }
        bool IsAllCurrency { get; }
        string Currency { get; }
        string FormName { get; set; }
    }
}