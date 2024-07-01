//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    /// <summary>
    /// MNMDAO00021 Interface
    /// </summary>
    public interface IMNMDAO00021 : IDataRepository<MNMORM00021>
    {
        bool CheckExist(string eNO, string aCCTNO, decimal aMOUNT, decimal hOMEAMOUNT, decimal hOMEAMT, decimal hOMEOAMT, decimal lOCALAMOUNT, decimal lOCALAMT, decimal lOCALOAMT, string sTATUS, string uID, bool isEdit);
        IList<MNMDTO00021> SelectAll();
        MNMDTO00021 SelectByENO(string eNO);
    }
}