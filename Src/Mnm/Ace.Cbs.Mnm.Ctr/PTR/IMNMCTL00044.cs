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
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00044 : IPresenter
    {
        IMNMVEW00044 View { get; set; }
        string month { get; set; }
        string date_month { get; set; }
        bool Validate_Form();
        void ClearCustomErrorMessage();
        string CheckMonth();
        IList<BranchDTO> GetAllBranchList();
        IList<MNMDTO00010> SelectTrialBalanceGroup(string Branchno, string Currency, int Month, int ishome);
    }

    public interface IMNMVEW00044
    {
        IMNMCTL00044 Controller { get; set; }
        string currencyNo { get; set; }
        string Year { get; set; }
        string Month { get; set; }
        bool IsAllBranch { get; set; }
    }
}