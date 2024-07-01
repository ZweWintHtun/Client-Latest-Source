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
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00043 : IPresenter
    {
        IMNMVEW00043 View { get; set; }
        string month { get; set; }
        string str_month { get; set; }
        bool Validate_Form();
        void ClearCustomErrorMessage();
        IList<BranchDTO> GetAllBranchList();
        IList<MNMDTO00010> SelectTrialBalanceDetail(string Branchno, string Currency, int Month, bool ishome);
            }

    public interface IMNMVEW00043
    {
        IMNMCTL00043 Controller { get; set; }
        string currencyNo { get; set; }
        string Year { get; set; }
        string Month { get; set; }
        bool IsAllBranch { get; set; }
    }
}