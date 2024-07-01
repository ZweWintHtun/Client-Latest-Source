using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00022 :IBaseService
    {
        IList<UserDTO> SelectByBranchCode(string branchCode);
        void DeactivateUser(IList<UserDTO> userList);
    }
}
