//----------------------------------------------------------------------
// <copyright file="ISAMSVE00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
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
    public interface ISAMSVE00021 : IBaseService
    {
        IList<PFMDTO00003> GetAll();
       // void Save(PFMDTO00003 entity);
        void Update(PFMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<PFMDTO00003> itemList);
        PFMDTO00003 SelectByInitial(string initial);
        void SaveServerAndServerClient(PFMDTO00003 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<PFMDTO00003> CheckExist2(string zoneCode, string description);
    }
}