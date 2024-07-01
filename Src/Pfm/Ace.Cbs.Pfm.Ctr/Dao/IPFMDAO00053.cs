//----------------------------------------------------------------------
// <copyright file="IPFMDAO00053.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    /// PFMDAO00053 Interface
    /// </summary>
    public interface IPFMDAO00053 : IDataRepository<PFMORM00053>
    {
        bool CheckExist(int id, string keyName, string keyValue, int location, int type);
        IList<PFMDTO00053> SelectAll();
        PFMDTO00053 SelectById(int id);
        bool UpdateKeyValue(string keyname, string keyValue);
        IList<PFMDTO00053> SelectByKeyName(string keyName1, string keyname2);
    }
}