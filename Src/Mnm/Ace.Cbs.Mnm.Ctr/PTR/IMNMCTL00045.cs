//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
    public interface IMNMCTL00045 : IPresenter
    {
        IMNMVEW00045 View { get; set; }
        void ClearCustomErrorMessage();
        void print();
    }

    public interface IMNMVEW00045
    {
        IMNMCTL00045 Controller { get; set; }
        string Currency { get; set; }
        bool IsHomeCurrency { get; }
        string DateType { get; }
        bool WithReversal { get; }
        DateTime RequiredDate { get; }
        bool IsCBMACode { get; }
    }
}