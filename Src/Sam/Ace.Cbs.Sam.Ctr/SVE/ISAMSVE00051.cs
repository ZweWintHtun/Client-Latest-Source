//----------------------------------------------------------------------
// <copyright file="ISAMSVE00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00051 : IBaseService
    {
        IList<PFMDTO00075> GetAll();
        void SaveServerAndServerClient(PFMDTO00075 entity);
        void Update(PFMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00075> itemList);
        PFMDTO00075 SelectById(int id);
        IList<CurrencyDTO> GetCurrency();
    }
}