using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using System.Text;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00068 : IBaseService
    {
        IList<SAMDTO00003> SelectAllByDate();
        void CutOff(string branchCode, DateTime NextSettlementDate, DateTime currentSettlementDate, int userId, IList<DataVersionChangedValueDTO> dvcvList);
    }
}
