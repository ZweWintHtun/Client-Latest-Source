using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00022:IBaseService
    {
        TLMDTO00017 GetRDInfo(string registerNo, string sourceBr);
        TLMDTO00017 UpdateRDInfo(TLMDTO00017 entity, int workstationId);
        string AmountDesp(decimal CuNum, string CurType);
    }
}
