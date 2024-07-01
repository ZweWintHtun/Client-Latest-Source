//----------------------------------------------------------------------
// <copyright file="IMNMDAO00024.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00024 : IDataRepository<MNMORM00024>
    {
        bool DeleteAdjRemitTodScharge(string sourceBr);
    }
}
