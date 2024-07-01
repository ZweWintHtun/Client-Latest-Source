//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00020 : IBaseService
    {
        IList<TLMDTO00027> GetAll();
        void Save(TLMDTO00027 entity);
        void Update(TLMDTO00027 entity);
        void Delete(IList<TLMDTO00027> itemList);
        TLMDTO00027 SelectById(int id);
    }
}