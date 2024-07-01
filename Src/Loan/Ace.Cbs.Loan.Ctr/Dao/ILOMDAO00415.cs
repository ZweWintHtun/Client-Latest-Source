using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00415 : IDataRepository<LOMORM00415>
    {
        IList<LOMDTO00415> SelectAll();
        IList<LOMDTO00415> SelectAll_ACode();
        IList<LOMDTO00415> CheckExist2(string productCode, string glcode, string description);
        bool CheckExist(string productCode, string desp, string glcode, bool isEdit);
        void Save(LOMDTO00415 productdto);
        void Update(LOMDTO00415 productdto);
        void Delete(LOMDTO00415 productdto);
    }
}
