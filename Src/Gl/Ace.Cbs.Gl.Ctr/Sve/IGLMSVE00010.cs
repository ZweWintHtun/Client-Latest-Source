using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00010 : IBaseService
    {
        IList<GLMDTO00013> SelectIncomeExpenditure(string budMonth, string year, int month, string branchCode);
    }
}
