//----------------------------------------------------------------------
// <copyright file="ITLMDAO00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013.08.09</CreatedDate>
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
    public interface ITLMDAO00026 :IDataRepository<TLMORM00026>
    {
        void DeleteTransactionReconcile(string branchcode, DateTime datetime);
        IList<TLMDTO00026> SelectReconsileDWTData(IList<string> branchcodelist);
        Nullable<Int32> SelectID();
    }
}
