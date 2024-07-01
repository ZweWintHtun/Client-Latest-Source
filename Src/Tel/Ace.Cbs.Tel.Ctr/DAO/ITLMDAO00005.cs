//----------------------------------------------------------------------
// <copyright file="ITLMDAO00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// TranType DAO Interface
    /// </summary>
    public interface ITLMDAO00005 : IDataRepository<TLMORM00005>
    {
        TLMDTO00005 SelectTranTypeStatus(string transactionCode);
        bool CheckExist(string tranCode, string desp, bool isEdit);
        IList<TLMDTO00005> SelectAll();
        TLMDTO00005 SelectByTranCode(string tranCode);
        IList<TLMDTO00005> CheckExist2(string TranTypeCode, string desp);
    }
}
