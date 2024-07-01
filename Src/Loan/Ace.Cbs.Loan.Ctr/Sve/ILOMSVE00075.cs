using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00075 : IBaseService
    {
        IList<LOMDTO00075> GetAll();
        LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode);

        void SaveServerAndServerClient(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList); 
        IList<LOMDTO00075> CheckExist2(string seasonCode);

        void Update(LOMDTO00075 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00075> itemList);
    }
}
