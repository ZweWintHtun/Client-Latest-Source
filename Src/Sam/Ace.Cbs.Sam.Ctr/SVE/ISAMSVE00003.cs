//----------------------------------------------------------------------
// <copyright file="ISAMSVE00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLLL</CreatedUser>
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
    public interface ISAMSVE00003 : IBaseService
    {
        IList<PFMDTO00004> GetAll();
        void Update(PFMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<PFMDTO00004> itemList);
        PFMDTO00004 SelectByOccupationCode(string occupationCode);
        void SaveServerAndServerClient(PFMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<PFMDTO00004> CheckExist2(string occupationCode, string description);
    }
}