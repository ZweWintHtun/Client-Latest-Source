using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00003 : IBaseService
    {

        IList<LOMDTO00001> GetAll();
        //void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByCode(string CharacterCode);
        //void SaveServerAndServerClient(LOMDTO00001 entity);

        void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00001> CheckExist2(string CharacterCode, string description);

    }
}
