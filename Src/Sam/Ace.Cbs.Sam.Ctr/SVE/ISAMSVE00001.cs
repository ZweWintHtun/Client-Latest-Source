//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00001.cs" company="ACE Data Systems">
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
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00001 : IBaseService
    {
        IList<PFMDTO00015> GetAll();
       // void Save(PFMDTO00015 entity);
        void Update(PFMDTO00015 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00015> itemList);
        PFMDTO00015 SelectById(int id);
        void SaveServerAndServerClient(PFMDTO00015 entity);
    }
}