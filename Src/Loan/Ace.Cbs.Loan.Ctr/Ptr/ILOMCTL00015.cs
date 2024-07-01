//----------------------------------------------------------------------
// <copyright file="ILOMCTL00015" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>14.01.2015</CreatedDate>
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
    public interface ILOMCTL00015 : IPresenter
    {
        ILOMVEW00015 View { get ; set; }
        void Save();        
    }
    public interface ILOMVEW00015
    {
        ILOMCTL00015 Controller { get; set; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string AccountType { get; set; }
        string MakingDate { get; set; }
        void BindGridView(IList<TCMDTO00003> GridDataList);
    }
}
