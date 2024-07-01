//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IPFMDAO00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// PFMDAO00051 Interface
    /// </summary>
    public interface IPFMDAO00051 : IDataRepository<PFMORM00051>
    {
        bool CheckExist(int id, string code, string description, int codeFormat);
        IList<PFMDTO00051> SelectAll();
        PFMDTO00051 SelectById(int id);
    }
}