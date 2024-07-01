using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00017 : IBaseService
    {
        IList<TLMDTO00015> GetOnlineDenominationData(string sourceBr);
        void Update(string entryno,string currency, CXDTO00001 denodto,int updatedUserId);
        IList<TLMDTO00015> GetChargesAmount(string entryNo, string sourceBr);
    }
}
