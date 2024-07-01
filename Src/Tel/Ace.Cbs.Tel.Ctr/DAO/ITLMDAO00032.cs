//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// TLMDAO00032 Interface
    /// </summary>
    public interface ITLMDAO00032 : IDataRepository<TLMORM00032>
    {
        IList<TLMDTO00032> SelectById(int remitBrId);
        bool DeleteById(int remitBrId, int userId);
        TLMDTO00032 SelectByIdForSaveAppServer(int remitRateId);
        IList<TLMDTO00032> SelectRmitRatewithRemitBrandBranch();
    }
}