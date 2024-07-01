using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00010 : IBaseService
    {
        IList<LOMDTO00008> SelectAll();
        //LOMORM00008 Save(LOMDTO00008 entity);
        //void Update(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Update(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList,string status);
        void Delete(IList<LOMDTO00008> itemList);
        LOMDTO00008 SelectByGJKind(string kind);
        //void SaveServerAndServerClient(LOMDTO00008 entity);

        void SaveServerAndServerClient(LOMDTO00008 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00008> CheckExist2(string kind, string description);
    }
}
