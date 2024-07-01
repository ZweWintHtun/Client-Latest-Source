//----------------------------------------------------------------------
// <copyright file="ILOMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> TAK </CreatedUser>
// <CreatedDate>12-01-2015</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00023 : IPresenter
    {
        ILOMVEW00023 View { get; set; }
        //IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth);
        //bool UpdateLoanInterest(IList<LOMDTO00021> liList);

        string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode);
        string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode,int userId);
    }

    public interface ILOMVEW00023
    {
        ILOMCTL00023 Controller { get; set; }
        void Successful(string message);
        void Failure(string message);
    }
}
