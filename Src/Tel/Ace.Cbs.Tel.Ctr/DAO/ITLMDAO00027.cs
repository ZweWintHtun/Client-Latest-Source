
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    /// TLMDAO00027 Interface
    /// </summary>
    public interface ITLMDAO00027 : IDataRepository<TLMORM00027>
    {
        bool CheckExist(int id, string bRANCHNO, string ipaddress);
        IList<TLMDTO00027> SelectAll();
        TLMDTO00027 SelectById(int id);
    }
}