//----------------------------------------------------------------------
// <copyright file="ISAMSVE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
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
    public interface ISAMSVE00010 : IBaseService
    {
        IList<PFMDTO00053> GetAll();
       // void Save(PFMDTO00053 entity);
        void Update(PFMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00053> itemList);
        PFMDTO00053 SelectById(int id);
        void SaveServerAndServerClient(PFMDTO00053 entity);
    }
}