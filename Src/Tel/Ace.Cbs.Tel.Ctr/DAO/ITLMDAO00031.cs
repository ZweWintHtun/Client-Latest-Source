//----------------------------------------------------------------------
// <copyright file="ITLMDAO00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
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
    /// TLMDAO00031 Interface
    /// </summary>
    public interface ITLMDAO00031 : IDataRepository<TLMORM00031>
    {
        bool CheckExist(int id, string zONETYPE, string brCode,string SourceBranchCode);
        IList<TLMDTO00031> SelectAll(string sourbr);
        TLMDTO00031 SelectById(int id);
        IList<TLMDTO00031> SelectAllByDistinct();
        bool CheckAccountCode(string aCode);
    }

}