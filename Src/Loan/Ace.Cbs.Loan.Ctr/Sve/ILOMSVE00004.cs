//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00004 : IBaseService
    {
        IList<LOMDTO00001> SelectAll();
        //void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);        
        void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);        
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByGoodCode(string gCode);
        //void SaveServerAndServerClient(LOMDTO00001 entity);
        void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00001> CheckExist2(string gCode, string description);
    }
}