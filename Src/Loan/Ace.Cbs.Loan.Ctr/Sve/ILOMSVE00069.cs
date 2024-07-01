using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00069 : IBaseService
    {
        IList<LOMDTO00069> GetAll();
        IList<LOMDTO00069> CheckExist2(string groupCode, string subCode, string desp);
        void SaveServerAndServerClient(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00069 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00069> itemList);
    }
}
