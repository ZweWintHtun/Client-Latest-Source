//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00002 : IBaseService
    {
        IList<PFMDTO00022> GetAll();
       // void Save(PFMDTO00022 entity);
        void SaveServerAndServerClient(PFMDTO00022 entity);
        void Update(PFMDTO00022 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00022> itemList);
        PFMDTO00022 SelectById(int id);
    }
}