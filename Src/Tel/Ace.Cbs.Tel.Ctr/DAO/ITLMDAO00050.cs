//----------------------------------------------------------------------
// <copyright file="ITLMDAO00037.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013.8.21 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using System;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00050 : IDataRepository<TLMVIW00008>
    {
        IList<TLMDTO00037> SelectIBLTestKeyListingReport();
        Nullable<DateTime> SelectMaxDate(DateTime date);
        IList<TLMDTO00037> SelectAllIBLTestKeyListingByMaxDate(DateTime maxdate);
    }
}
