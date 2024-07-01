// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00025 : IBaseService
    {
        void SaveServerAndServerClient(TLMDTO00029 entity, IList<TLMDTO00030> itemList, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(TLMDTO00029 item);
        TLMDTO00029 SelectById(string currency, string branchCode, string sourceBranch);
        IList<TLMDTO00030> SelectItemlistById(int id);
    }
}
