//----------------------------------------------------------------------
// <copyright file="ISAMSVE00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00017 : IBaseService
    {
        IList<TLMDTO00031> GetAll(string sourcebr);
        void SaveServerAndServerClient(TLMDTO00031 entity);
        void Update(TLMDTO00031 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<TLMDTO00031> itemList);
        TLMDTO00031 SelectById(int id);
        IList<BranchDTO> GetAllBranchCode();
        IList<TLMDTO00031> GetAllByDistinct();
    }
}