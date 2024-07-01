using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00072
    {
        IList<LOMDTO00072> GetAll();
        IList<LOMDTO00072> CheckExist2(string cropCode, string desp);
        void SaveServerAndServerClient(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00072 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00072> itemList);
    }
}
