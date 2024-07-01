using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.CBM.Ctr.Sve
{
    public interface ICBMSVE00001 : IBaseService
    {
        IList<PFMDTO00042> GetAll_CBMDataByDateAndName(DateTime date, string fname,string Currency);
        PFMDTO00042 GetAllData_CBM(DateTime date, string fname,string Currency);
    }
}
