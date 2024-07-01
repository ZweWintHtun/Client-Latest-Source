//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
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
    /// TLMDAO00010 Interface
    /// </summary>
    public interface ITLMDAO00010 : IDataRepository<TLMORM00010>
    {
        bool CheckExist(int id, string name, string iPAddress, string hostName, string maskAddress);
        IList<TLMDTO00010> SelectAll();
        TLMDTO00010 SelectById(int id);
    }
}