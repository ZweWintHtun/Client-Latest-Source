using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00037 : IDataRepository<PFMORM00037>
    {
        IList<PFMDTO00037> SelectAllOthersBranchByReconsileBranchcodelist(string sourcebranchCode, IList<string> reconcilebranchcodelist);
        bool CheckExist(string branchCode, bool isEdit);
        IList<PFMDTO00037> SelectAll();
        PFMDTO00037 SelectByBranchCode(string branchCode);
    }
}