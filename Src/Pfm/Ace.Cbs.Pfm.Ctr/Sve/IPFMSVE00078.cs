using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00078 : IBaseService
    {
        string SaveServerAndServerClient(IList<PFMDTO00078> lstSolidarity, IList<DataVersionChangedValueDTO> dvcvList);
        string GenerateSolidarityLendingGroupNo();
        IList<PFMDTO00078> SelectByGroupNo(string groupNo);
        void Delete(IList<PFMDTO00078> itemList);
        PFMORM00078 DeleteServer(PFMDTO00078 solidarityDTO);
        void Update(PFMDTO00078 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        PFMORM00078 UpdateServer(PFMDTO00078 entity, IList<DataVersionChangedValueDTO> dvcvList);
    }
}
