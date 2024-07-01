//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMSVE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
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
    public interface ILOMSVE00009 : IBaseService
    {
        IList<LOMDTO00007> SelectAll();
       // LOMORM00007 Save(LOMDTO00007 entity);
        //void Update(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00007> itemList);
        LOMDTO00007 SelectByGJTCode(string GjtCode);
        //void SaveServerAndServerClient(LOMDTO00007 entity);

        void SaveServerAndServerClient(LOMDTO00007 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00007> CheckExist2(string GjtCode, string description);
    }
}
