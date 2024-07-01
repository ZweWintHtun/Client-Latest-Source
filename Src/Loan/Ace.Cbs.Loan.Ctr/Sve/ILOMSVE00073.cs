using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00073
    {
        IList<LOMDTO00073> GetAll();
        IList<LOMDTO00073> CheckExist2(string umCode, string desp);
        void SaveServerAndServerClient(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00073 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00073> itemList);
        string SelectUMByUMCode(string umCode);
    }
}
