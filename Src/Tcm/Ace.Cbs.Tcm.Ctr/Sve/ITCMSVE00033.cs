//----------------------------------------------------------------------
// <copyright file="ITCMSVE00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
   public interface ITCMSVE00033 :IBaseService
    {
       IList<PFMDTO00042> SelectNotYetPostedDeliveredCheque(string sourcebr, int createduserid, DateTime startdate, DateTime enddate, string workstation);
       IList<PFMDTO00042> SelectPostedDeliveredCheque(string sourcebr, int createduserid, DateTime startdate, DateTime enddate, string workstation);
    }
}
