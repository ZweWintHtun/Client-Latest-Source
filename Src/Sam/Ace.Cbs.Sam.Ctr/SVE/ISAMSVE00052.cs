//----------------------------------------------------------------------
// <copyright file="ISAMSVE00052.cs" company="ACE Data Systems">
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00052 : IBaseService
    {
        IList<TLMDTO00005> GetAll();
        //void Save(TLMDTO00005 entity);
        //void Update(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<TLMDTO00005> itemList);
        TLMDTO00005 SelectByTranCode(string tranCode);
        //void SaveServerAndServerClient(TLMDTO00005 entity);
        void SaveServerAndServerClient(TLMDTO00005 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<TLMDTO00005> CheckExist2(string TranTypeCode, string desp);
    }
}