using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00076 : IBaseService
    {
        IList<LOMDTO00076> GetAll();
        void Update(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00076> itemList);
        LOMDTO00076 SelectByLSBusinessCode(string LSBusinessCode);

        void SaveServerAndServerClient(LOMDTO00076 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00076> CheckExist2(string LSBusinessCode, string description);
    }
}
