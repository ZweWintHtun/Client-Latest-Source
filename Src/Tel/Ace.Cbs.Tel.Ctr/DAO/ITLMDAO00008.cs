//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KoKoTun</CreatedUser>
// <CreatedDate>01/24/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// TLMDAO00008 Interface
    /// </summary>
    public interface ITLMDAO00008 : IDataRepository<TLMORM00008>
    {
        bool CheckExist(int id,string eNO, string dEPCODE, string aCCTNO, string nAME, decimal qTY, decimal aMOUNT, string qUOTANO, string uID);
        IList<TLMDTO00008> SelectAll();
        TLMDTO00008 SelectById(int id);
    }
}