using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00051 : BaseService, IMNMSVE00051
    {
        ICXDAO00009 ViewDAO { get; set; }

        public IList<MNMDTO00034> GetInterestList(string sourceBr)
        {
            return this.ViewDAO.SelectInterest(sourceBr);
        }
    }
}
