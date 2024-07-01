//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using ACE.Windows.Core.Service;
using ACE.CBS.SAM.DMD;
using ACE.CBS.SAM.CTR.DAO;

namespace ACE.CBS.SAM.CTR.SVE
{
    public interface ISAMSVE00001 : IBaseService
    {
        IList<SAMDTO00001> GetAll();
        void Save(SAMDTO00001 entity);
        void Update(SAMDTO00001 entity);
        void Delete(IList<SAMDTO00001> itemList);
        SAMDTO00001 SelectById(int id);
    }
}