using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00007:IBaseService
    {
        void Save_InterestNature_Configuration(bool isSavingAccrued, bool isFixedAccrued);
        IList<PFMDTO00053> SelectByKeyName(string keyName1, string keyname2);
    }
}
