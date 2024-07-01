using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00071 : IPresenter
    {
        ITCMVEW00071 View { get; set; }

        string BackupDatabaseImmediately();//Added by HWKO (15-May-2017)
        string BackupDatabaseDaily();//Added by HWKO (15-May-2017)
        string BackupDatabaseBefore();//Added by HWKO (15-May-2017)
        string BackupDatabaseAfter();//Added by HWKO (15-May-2017)
    }

    public interface ITCMVEW00071
    {
        ITCMCTL00071 Controller { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
