//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
    public interface ISAMSVE00050 : IBaseService
    {
        IList<PFMDTO00048> GetAll();
        void Update(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        //void SaveServerAndServerClient(PFMDTO00048 entity);
        void SaveServerAndServerClient(PFMDTO00048 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<PFMDTO00048> CheckExist2(string occupationCode, string description);
        //void Update(PFMDTO00048 entity,IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00048> itemList);
        PFMDTO00048 SelectByCode(string code);
    }
}