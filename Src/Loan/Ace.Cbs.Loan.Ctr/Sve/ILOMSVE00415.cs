using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00415: IBaseService
    {
        IList<LOMDTO00415> GetAll();
        IList<LOMDTO00415> SelectAll_ACode();
        IList<LOMDTO00415> CheckExist2(string productCode, string gLCode, string desp);

        void Save(LOMDTO00415 entity);
        void Update(LOMDTO00415 entity);
        void Delete(IList<LOMDTO00415> entitylst);
    
    }
}
