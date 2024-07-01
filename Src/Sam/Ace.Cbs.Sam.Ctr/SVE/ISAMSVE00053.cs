using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ctr.Sve
{
    public interface ISAMSVE00053 : IBaseService
    {
        IList<SAMDTO00053> GetAll();
     //   void Save(SAMDTO00053 entity);
        void Update(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<SAMDTO00053> itemList);
        SAMDTO00053 SelectByNationalityCode(string NationalityCode);
        void SaveServerAndServerClient(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<SAMDTO00053> CheckExist2(string NationalityCode, string description);
    }
}
