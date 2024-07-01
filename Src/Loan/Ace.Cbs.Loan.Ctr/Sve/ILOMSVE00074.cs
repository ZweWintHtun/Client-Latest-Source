using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00074 : IBaseService
    {
        IList<LOMDTO00074> GetAll();
        //void SaveServerAndServerClient(LOMDTO00074 entity);
        void Update(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00074> itemList);
        LOMDTO00074 SelectByProductCode(string advanceCode);

        void SaveServerAndServerClient(LOMDTO00074 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00074> CheckExist2(string ProductCode, string description);
    }
}
