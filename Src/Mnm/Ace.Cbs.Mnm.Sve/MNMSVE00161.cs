using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00161 : BaseService, IMNMSVE00161
    {
        #region Properties
        ICXDAO00009 ViewDAO { get; set; }
        #endregion

        public IList<TLMDTO00019> MainPrint(DateTime startDate,DateTime endDate,string datetype,string sourcebr)
        {
            IList<TLMDTO00019> IxIntWitList= ViewDAO.SelectFixedInterestWithdrawListing(startDate, endDate, datetype, sourcebr);
            return IxIntWitList;
        }
    }
}
