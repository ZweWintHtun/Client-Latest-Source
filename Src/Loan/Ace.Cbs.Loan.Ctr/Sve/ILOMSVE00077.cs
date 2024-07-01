using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00077
    {
        IList<LOMDTO00077> GetAll();
        IList<LOMDTO00077> CheckExist2(string productCode, string lsBusinessCode, string umCode);
        void SaveServerAndServerClient(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00077 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00077> itemList);
    }
}
