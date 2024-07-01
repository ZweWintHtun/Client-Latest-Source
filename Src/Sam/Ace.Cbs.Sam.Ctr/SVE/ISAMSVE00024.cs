//----------------------------------------------------------------------
// <copyright file="ISAMSVE00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00024 : IBaseService
    {
        IList<TLMDTO00012> GetAll();
        //void Save(TLMDTO00012 entity);
        void Update(TLMDTO00012 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<TLMDTO00012> itemList);
        TLMDTO00012 SelectById(int id);
        IList<CurrencyDTO> GetCur();
        void SaveServerAndServerClient(TLMDTO00012 entity);
    }
}