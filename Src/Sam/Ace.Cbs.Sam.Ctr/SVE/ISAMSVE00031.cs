using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Ctr.SVE
{
    public interface ISAMSVE00031 : IBaseService
    {
        IList<SAMDTO00056> SelectRateFileListByRateActive(string activeRate);
        IList<SAMDTO00056> SelectRateFileList(string rateType, string status, string selectedRate);
    }
}
