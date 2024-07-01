using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00124 : BaseService , IMNMSVE00124
    {
        ICXDAO00009 ViewDAO { get; set; }
        IList<PFMDTO00042> ReportDataList { get; set; }

        public IList<PFMDTO00042> GetIROutstandingReport(string sourceBr)
        {
            return ReportDataList = ViewDAO.SelectIR_Outstanding(sourceBr);
        }
    }
}
