using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
   public interface ILOMSVE00007 : IBaseService
    {
       IList<LOMDTO00009> GetAll();
       //void SaveServerAndServerClient(LOMDTO00009 entity);
       //void Update(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList);
       void Update(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
       void Delete(IList<LOMDTO00009> itemList);
       LOMDTO00009 SelectByCode(string stockNo);
       void SaveServerAndServerClient(LOMDTO00009 entity, IList<DataVersionChangedValueDTO> dvcvList);
       IList<LOMDTO00009> CheckExist2(string stockNo, string stockName);

    }
}
