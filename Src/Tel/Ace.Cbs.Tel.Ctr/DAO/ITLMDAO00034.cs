//----------------------------------------------------------------------
// <copyright file="ITLMDAO00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
    /// TLMDAO00034 Interface
    /// </summary>
    public interface ITLMDAO00034 : IDataRepository<TLMORM00034>
    {
        bool CheckExist(int id, decimal value, string code);
        IList<TLMDTO00034> SelectAll();
        TLMDTO00034 SelectById(int id);
    }
}