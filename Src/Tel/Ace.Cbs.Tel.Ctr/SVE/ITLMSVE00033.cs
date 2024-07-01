//----------------------------------------------------------------------
// <copyright file="ITLMSVE00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-17</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using System.Collections.Generic;
using System;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00033:IBaseService

    {
       IList<TLMDTO00017> GetDrawingDataForEachBranch(DateTime datetime, string transfertype, string branchcode, string sourcebrcode);
        IList<TLMDTO00025> GetReconcileDTOList(string sourcebranchcode);
        //IList<TLMDTO00025> GetReconcileDWTDTOList(string sourcebranchcode);
        //IList<BranchDTO> SelectAllOthersBranchByReconsileBranchcodelist(string sourcebranchcode, IList<string> reconsilebranhcodelist);
       //  void UpdateCurselReconcile();
       // TLMDTO00017 GetDrawingDataForEachBranch(DateTime datetime, string transfertype, string branchcode, string sourcebrcode);
        //IList<TLMDTO00001> GetEncashDataForEachBranchSide(DateTime datetime, string transfertype, string branchcode, string sourcebranchcode);
        IList<TLMDTO00025> SelectDatasForIBLReconcile(IList<BranchDTO> Branches, DateTime datetime, string transactionType, string transfertype, string sourcebr,int currentUserId);
       
        IList<TLMDTO00025> SelectReconsileListForRemittance(IList<string> branches, string type, DateTime date_time);
    }
}
