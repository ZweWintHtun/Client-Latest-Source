//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00008 : IBaseService
    {
        IList<TLMDTO00020> GetAll(string sourceBr);
       // void Save(TLMDTO00020 entity);
        void Update(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<TLMDTO00020> itemList);
        TLMDTO00020 SelectById(string dEPCODE);
        void SaveServerAndServerClient(TLMDTO00020 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<TLMDTO00020> CheckExist2(string dEPCODE, string sourceBr);
    }
}