//----------------------------------------------------------------------
// <copyright file="ITLMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nway Ei EI Aung</CreatedUser>
// <CreatedDate>2013-11-26</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// DrawingPrinting DAO Interface
    /// </summary>
    public interface ITLMDAO00021:IDataRepository<TLMORM00021>
    {
        //Delete By WorkStation
        int SelectMaxId();
        bool DeleteByWorkStation(string workStation,string sourcebr);      
    }
}
