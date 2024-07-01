using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00071 :IBaseService
    {
        IList<LOMDTO00071> GetAll();
        void Update(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00071> itemList);
        LOMDTO00071 SelectBySeasonCode(string seasonCode);

        void SaveServerAndServerClient(LOMDTO00071 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00071> CheckExist2(string seasonCode, string description);
    }
}
