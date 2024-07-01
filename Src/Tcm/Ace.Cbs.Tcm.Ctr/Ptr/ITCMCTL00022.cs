using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00022 : IPresenter
    {
        ITCMVEW00022 View { get; set; }
        void Delete(IList<UserDTO> deleteList);
        IList<UserDTO> SelectByBranchCode();
    }

    public interface ITCMVEW00022
    {
        ITCMCTL00022 Controller { get; set; }
        IList<UserDTO> UserList { get; set; }
        string LocalBranchCode { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
