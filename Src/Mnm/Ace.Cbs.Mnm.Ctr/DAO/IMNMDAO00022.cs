//----------------------------------------------------------------------
// <copyright file="IMNMDAO00022.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00022 : IDataRepository<MNMORM00022>
    {
        #region Unused
        IList<PFMDTO00042> SelectAll();
        #endregion

        bool DeleteAdjRemitOi(string sourceBr);

    }
}
