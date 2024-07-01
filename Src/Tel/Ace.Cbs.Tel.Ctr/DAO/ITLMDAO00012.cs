//----------------------------------------------------------------------
// <copyright file="ITLMDAO00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    /// TLMDAO00012 Interface
    /// </summary>
    public interface ITLMDAO00012 : IDataRepository<TLMORM00012>
    {
        bool CheckExistForSave(int id, string Cur, string symbol);
        bool CheckExistForUpdate(int id, string Cur, string symbol);
        //bool CheckExist(int id, string dESP);
        IList<TLMDTO00012> SelectAll();
        TLMDTO00012 SelectById(int id);
        IList<string> SelectDescriptionByCurrrency(string currency);
    }
}