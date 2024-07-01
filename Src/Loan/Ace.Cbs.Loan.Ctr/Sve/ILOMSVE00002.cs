using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00002 : IBaseService
    {
        IList<LOMDTO00002> GetAll();
        //void SaveServerAndServerClient(LOMDTO00002 entity);
        void Update(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00002> itemList);
        LOMDTO00002 SelectByAdvanceCode(string advanceCode);

        void SaveServerAndServerClient(LOMDTO00002 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00002> CheckExist2(string typeOfAdvanceCode, string description);
    }
}
   