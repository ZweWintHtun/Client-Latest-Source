//----------------------------------------------------------------------
// <copyright file="ISAMSVE00022.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00022 : IBaseService
    {
        IList<TLMDTO00003> GetAll();    
        void SaveServerAndServerClient(TLMDTO00003 entity);
        void Update(TLMDTO00003 entity,IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<TLMDTO00003> itemList);
        TLMDTO00003 SelectById(int id);
        IList<CurrencyDTO> GetCurrency();
    }
}