//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00003 : IBaseService
    {
        void Save(int month, int year, int updatedUserId, string sourceBr, string WorkstationName);
        //void callStoreProcedure(int month, int year, int updatedUserId);
    }
}
