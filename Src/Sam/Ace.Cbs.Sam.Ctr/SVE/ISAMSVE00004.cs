// <copyright file="ISAMSVE00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00004 : IBaseService
    {
        IList<TLMDTO00040> GetAll();
       // void Save(TLMDTO00040 entity);
        void Update(TLMDTO00040 entity, IList<DataVersionChangedValueDTO> dvcvList,string status);
        void Delete(IList<TLMDTO00040> itemList);
        TLMDTO00040 SelectByBCode(string bCode);
       // void SaveServerAndServerClient(TLMDTO00040 entity);
 void SaveServerAndServerClient(TLMDTO00040 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<TLMDTO00040> CheckExist2(string bCode, string description);
    }
}