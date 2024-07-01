using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00070 : IBaseService
    {
        IList<LOMDTO00070> GetAll();
        IList<LOMDTO00070> CheckExist2(string villageCode, string desp);
        void SaveServerAndServerClient(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00070 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00070> itemList);
    }
}
