//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00015 : IBaseService
    {
        IList<PFMDTO00007> GetAll();
        //void Save(PFMDTO00007 entity);
        void Update(PFMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00007> itemList);
        PFMDTO00007 SelectById(int id);
        void SaveServerAndServerClient(PFMDTO00007 entity);
    }
}