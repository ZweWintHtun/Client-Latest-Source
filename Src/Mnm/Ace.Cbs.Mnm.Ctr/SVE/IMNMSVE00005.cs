using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00005 : IBaseService
    {
        string CheckDate(DateTime Dailydate, string sourcebr);
        void Posting(DateTime startDate, DateTime endDate, string workstation, int createdUserId,string branchCode);

    }
}
