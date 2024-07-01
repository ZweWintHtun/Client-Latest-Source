//----------------------------------------------------------------------
// <copyright file="IMNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
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
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    /// <summary>
    /// Interest Schedule Controller interface
    /// </summary>
    public interface IMNMCTL00050 : IPresenter
    {
       
        IMNMVEW00050 View { get; set; }

        PFMDTO00040 GetInterestSchedule();
        bool Validate();
        void ClearCustomErrorMessage();
        void ShowReport(string formName);
    }

    /// <summary>
    /// Interest Schedule View interface
    /// </summary>
    public interface IMNMVEW00050
    {
        IMNMCTL00050 Controller { get; set; }
        string RequiredYear { get; set; }
        string Currency { get; set; }
        string BranchCode { get; set; }
    }
}
