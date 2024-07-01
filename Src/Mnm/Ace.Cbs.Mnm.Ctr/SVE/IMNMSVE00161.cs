using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00161 : IBaseService
    {
        IList<TLMDTO00019> MainPrint(DateTime startDate, DateTime endDate, string datetype, string sourcebr);
    }
}
