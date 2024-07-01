//----------------------------------------------------------------------
// <copyright file="ITLMDAO00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// TLMDAO00003 Interface
    /// </summary>
    public interface ITLMDAO00003 : IDataRepository<TLMORM00003>
    {
        bool CheckExist(int id, decimal rate, decimal fixAmt, decimal startNo, decimal endNo, string cur);
        IList<TLMDTO00003> SelectAll();
        TLMDTO00003 SelectById(int id);
        IList<CurrencyDTO> SelectCurrency();
        IList<TLMDTO00003> SelectAllPORateByCurrency(string currency);
    }
}