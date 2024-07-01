using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00056 : IBaseService
    {
        IList<SAMDTO00054> GetAll();
        void Update(SAMDTO00054 entity, IList<DataVersionChangedValueDTO> dvcvList);
        void Delete(IList<SAMDTO00054> itemList);
        IList<SAMDTO00054> SelectByStateCode(string StateCode);
        void SaveServerAndServerClient(SAMDTO00054 entity);
        IList<SAMDTO00054> CheckExist2(string StateCode, string TownshipCode);
    }
}
