using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00071 : IBaseService
    {
        string BackupDatabaseImmediately();//Added by HWKO (15-May-2017)
        string BackupDatabaseDaily();//Added by HWKO (15-May-2017)
        string BackupDatabaseBefore();//Added by HWKO (15-May-2017)
        string BackupDatabaseAfter();//Added by HWKO (15-May-2017)
    }
}
