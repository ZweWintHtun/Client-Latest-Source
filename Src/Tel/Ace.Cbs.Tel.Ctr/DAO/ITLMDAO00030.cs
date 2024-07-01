//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00030.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00030 : IDataRepository<TLMORM00030>
    {
        IList<TLMDTO00030> SelectById(int remitbrIblID);
        bool DeleteById(int remitbrIblID, int userId);
        TLMDTO00030 SelectByIdForSaveAppServer(int IblDwtRateId);
    }
}
