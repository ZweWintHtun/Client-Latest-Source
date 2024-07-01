using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using System.Collections.Generic;
using System;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00004:IDataRepository<CurrencyChargeOfAccount>
    {
        IList<MNMDTO00010> GetCCOAData(bool isHomeCur);
        bool UpdateGetCCOAData(MNMDTO00010 dto,bool isDelete);
        bool UpdateGetCCOADataForHomeCurrency(MNMDTO00010 dto,bool isDelete);
    }
}
