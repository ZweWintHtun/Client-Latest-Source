//----------------------------------------------------------------------
// <copyright file="ISAMSVE00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00019 : IBaseService
    {
        IList<TLMDTO00034> GetAll(string keyType);
      //  void Save(TLMDTO00034 entity, string keyType);        
        void Delete(IList<TLMDTO00034> itemList, string keyType);
        void Update(TLMDTO00034 entity, string keyType, IList<DataVersionChangedValueDTO> dvcvList);
        TLMDTO00034 SelectById(int id);
        void SaveServerAndServerClient(TLMDTO00034 entity, string keyType);
    }
}