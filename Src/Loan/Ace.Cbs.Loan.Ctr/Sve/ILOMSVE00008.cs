using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00008 : IBaseService
    {
        IList<LOMDTO00010> GetAll();
        //void SaveServerAndServerClient(LOMDTO00010 entity);
        //void Update(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00010> itemList);
        LOMDTO00010 SelectByCode(string kstockNo);
        void SaveServerAndServerClient(LOMDTO00010 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00010> CheckExist2(string kstockNo, string kstockName);
   
    }
}
