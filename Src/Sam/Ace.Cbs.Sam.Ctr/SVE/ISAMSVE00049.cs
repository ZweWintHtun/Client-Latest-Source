//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00049.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00049 : IBaseService
    {
        IList<PFMDTO00056> GetAll();
        void SaveServerAndServerClient(PFMDTO00056 entity);
        void Update(PFMDTO00056 entity,IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00056> itemList);
        PFMDTO00056 SelectById(int id);
    }
}