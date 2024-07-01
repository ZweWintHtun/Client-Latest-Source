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
    public interface IMNMCTL00035 : IPresenter
    {
        IMNMVEW00035 View { get; set; }
        bool Validate_Form();
        void Print();
        void ClearCustomErrorMessage();

        PFMDTO00042 GetViewData();
    }

    public interface IMNMVEW00035
    {
        IMNMCTL00035 Controller { get; set; }
        string BranchNo { get; set; }
        string BranchCode { get; set; }
        //string Branch { get;set; }
        string Currency { get;set; }
        string DateType { get; set; }
        DateTime RequiredDate { get; set; }
        bool IsAllBranches { get; set; }
        bool IsWithReversal { get; set; }
        bool IsHomeCurrency { get; set; }
        string CurrencyType { get; set; }
    }
}
