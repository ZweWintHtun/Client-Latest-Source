using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00068 : IBaseService
    {
        IList<LOMDTO00068> GetAll();
        IList<LOMDTO00068> CheckExist2(string groupCode, string prefix, string desp);
        void SaveServerAndServerClient(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00068 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00068> itemList);
    }
}
