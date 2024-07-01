//----------------------------------------------------------------------
// <copyright file="ITLMCTL00025.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Dao;



namespace Ace.Cbs.Tel.Ctr.Dao
{
   public interface ITLMDAO00025:IDataRepository<TLMORM00025>
    {
       void UpdateCurselReconcile(string branch, string type, DateTime date, string sourceBranch, int updatedUserId);
       void DeleteDrawingBankReconcile(string type, string branchcode, DateTime datetime,string sourceBranch);    
       IList<TLMDTO00025> SelectReconsileData(string sourcebranchCode);
       IList<TLMDTO00025> GetReconsileListForRemittance(IList<string> branchcodelist, string type, DateTime datetime);
       Nullable<Int32> SelectID();
        
       
    }
}
