//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00007 : IBaseService
    {
        IList<SAMDTO00003> GetAll();
        //void Save(SAMDTO00003 entity);
        void Update(SAMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<SAMDTO00003> itemList);
        SAMDTO00003 SelectById(int id);
        void SaveServerAndServerClient(SAMDTO00003 entity);
    }
}