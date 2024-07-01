//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>27/01/2013</CreatedDate>
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
    public interface IMNMCTL00058 : IPresenter
    {
        IMNMVEW00058 View { get; set; }
        void Print(DateTime sdate,DateTime edate,string cur,string status);
        bool Validate_Form();
        void ClearCustomErrorMessage();       
    }

    public interface IMNMVEW00058
    {
        IMNMCTL00058 Controller { get; set; }
        string currencyNo { get; set; }
        string FormName { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}