//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMDAO00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using ACE.Windows.Core.DAO;
using ACE.CBS.SAM.DMD;

namespace ACE.CBS.SAM.CTR.DAO
{
    /// <summary>
    /// SAMDAO00001 Interface
    /// </summary>
    public interface ISAMDAO00001 : IDataRepository<SAMORM00001>
    {
        bool CheckExist(int id, string code, string description, string symbol);
        IList<SAMDTO00001> SelectAll();
        SAMDTO00001 SelectById(int id);
        bool UpdateById(SAMDTO00001 accountTypeInfo);
        bool DeleteById(SAMDTO00001 accountTypeInfo);
    }
}