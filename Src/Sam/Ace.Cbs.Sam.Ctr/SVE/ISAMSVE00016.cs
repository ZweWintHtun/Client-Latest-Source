//----------------------------------------------------------------------
// <copyright file="ISAMSVE00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00016 : IBaseService
    {
        IList<PFMDTO00057> GetAll();
        //void Save(PFMDTO00057 entity);
        //void Update(PFMDTO00057 entity,IList<DataVersionChangedValueDTO> dvcvList);
        void Update(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<PFMDTO00057> itemList);
        PFMDTO00057 SelectByVariable(string variable);
        //void SaveServerAndServerClient(PFMDTO00057 entity);
        void SaveServerAndServerClient(PFMDTO00057 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<PFMDTO00057> CheckExist2(string variable, string value);
        
    }
}