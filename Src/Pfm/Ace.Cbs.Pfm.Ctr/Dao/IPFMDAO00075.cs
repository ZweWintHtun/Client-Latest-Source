//----------------------------------------------------------------------
// <copyright file="IPFMDAO00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// PFMDAO00075 Interface
    /// </summary>
    public interface IPFMDAO00075 : IDataRepository<PFMORM00074>
    {
        bool CheckExist(int id, string cur, string rateType, string toCur);
        IList<PFMDTO00075> SelectAll();
        PFMDTO00075 SelectById(int id);
        IList<CurrencyDTO> SelectCurrency();
        IList<PFMDTO00075> SelectAllByLastModify();
        bool UpdateByLastModify(int updatedUserId);
        IList<decimal> SelectRate(string cur, string rateType);
        int SelectMaxId();
    }
}