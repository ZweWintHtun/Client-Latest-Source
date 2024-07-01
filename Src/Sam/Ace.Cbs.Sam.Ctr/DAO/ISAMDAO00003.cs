//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMDAO00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Sam.Dmd;
using System;

namespace Ace.Cbs.Sam.Ctr.Dao
{
    /// <summary>
    /// SAMDAO00003 Interface
    /// </summary>
    public interface ISAMDAO00003 : IDataRepository<SAMORM00003>
    {
        bool CheckExist(int id, DateTime dATE, string dESCRIPTION);
        IList<SAMDTO00003> SelectAll();
        SAMDTO00003 SelectById(int id);
        IList<SAMDTO00003> SelectByDateAll();
    }
}