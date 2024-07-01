//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMSVE00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00026 : IBaseService
    {
        void SaveServerAndServerClient(TLMDTO00028 entity, IList<TLMDTO00032> itemList, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(TLMDTO00028 item);
        IList<BranchDTO> SelectAllBranch();
        TLMDTO00028 SelectById(string currency, string branchCode, string sourceBranch);
        IList<TLMDTO00032> SelectItemlistById(int id);
    }
}