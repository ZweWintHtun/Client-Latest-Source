//----------------------------------------------------------------------
// <copyright file="ILOMSVE00032" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19.01.2015</CreatedDate>
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
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00032 : IBaseService
    {
        PFMDTO00028 CheckAccountNo(string accountNo, string sourceBr);
        IList<LOMDTO00013> GetLegalListByAccountNo(string accountNo, string sourceBr);
    }
}
