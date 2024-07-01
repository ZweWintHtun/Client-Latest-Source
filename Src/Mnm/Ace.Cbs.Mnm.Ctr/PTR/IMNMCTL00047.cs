//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
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
    public interface IMNMCTL00047 : IPresenter
    {
        IMNMVEW00047 View { get; set; }
        PFMDTO00001 accountinfo { get; set; }
        bool Validate_Form();
        IList<PFMDTO00001> SelectInfo(string actype);
        string SelectCurrencyByAccountNo(string acctno);
    }

    public interface IMNMVEW00047
    {
        IMNMCTL00047 Controller { get; set; }
        string AccountNumber { get; set; }
        string AcSign { get; set; }
        DateTime Date_time { get; set; }
    }
}