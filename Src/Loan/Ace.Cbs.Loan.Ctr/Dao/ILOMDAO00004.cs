//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILONDAO00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
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
    /// LONDAO00004 Interface
    /// </summary>
    public interface ILOMDAO00004 : IDataRepository<LOMORM00004>
    {
        bool CheckExist(string iNSUCODE, string iNSUDESP, bool isEdit);
        IList<LOMDTO00004> SelectAll();
        LOMDTO00004 SelectByINSUCODE(string iNSUCODE);
        IList<LOMDTO00004> CheckExist2(string iNSUCODE, string desp);
    }
}