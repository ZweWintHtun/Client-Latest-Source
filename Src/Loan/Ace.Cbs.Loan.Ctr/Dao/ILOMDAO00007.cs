//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMDAO00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LOMDAO00007 Interface
    /// </summary>
    public interface ILOMDAO00007 : IDataRepository<LOMORM00007>
    {
        bool CheckExist(string gjtype, string desp, bool isEdit);
        IList<LOMDTO00007> SelectAll();
        LOMDTO00007 SelectByGjtype(string gjtype);
        void ManualUpdate(LOMORM00007 entity);
        IList<LOMDTO00007> CheckExist2(string code, string desp);
    }
}