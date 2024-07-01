//----------------------------------------------------------------------
// <copyright file="ISAMSVE00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    /// <summary>
    /// RateFile Setup
    /// </summary>
    public interface ISAMSVE00023 : IBaseService
    {
        IList<PFMDTO00009> GetAll();
        void SaveServerAndServerClient(PFMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(PFMDTO00009 entity,IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<PFMDTO00009> itemList);
        PFMDTO00009 SelectByCode(string code);
        PFMDTO00009 SelectByRateCode(string code);
    }
}