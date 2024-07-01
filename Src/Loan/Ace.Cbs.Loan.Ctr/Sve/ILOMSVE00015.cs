//----------------------------------------------------------------------
// <copyright file="ILOMSVE00015" company="ACE Data Systems">
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
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00015 : IBaseService
    {
        IList<TCMDTO00003> GetNPLIntList(string loanNo, string aType, string sourceBr);
        bool ReleaseNPLCase(IList<TCMDTO00003> nplList,bool IsVoucher,string currency,string loanAType,string channel,string sourceBr,int workstationId, string nplReleaseUser, int updatedUserID);
    }
}
