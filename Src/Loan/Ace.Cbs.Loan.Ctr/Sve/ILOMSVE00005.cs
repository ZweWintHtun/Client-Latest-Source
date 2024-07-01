using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00005 : IBaseService
    {
        IList<LOMDTO00001> SelectAll();
        //LOMORM00005 Save(LOMDTO00001 entity);
        //void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByLandCode(string LandCode);
       // void SaveServerAndServerClient(LOMDTO00001 entity);

        void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00001> CheckExist2(string LandCode, string description);
    }
}
