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
    public interface IMNMCTL00059 : IPresenter
    {
        IMNMVEW00059 View { get; set; }
        void Print(string acctno, string cur);
        void ClearCustomErrorMessage();
    }
       

    public interface IMNMVEW00059
    {
        IMNMCTL00059 Controller { get; set; }
        string currencyNo { get; set; }
        string AccountNo { get; set; }
    }
}