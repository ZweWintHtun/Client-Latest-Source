using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00031 : IDataRepository<PFMORM00001>
    {
        PFMDTO00001 GetCAOFsInfoByAccountNumber(string accountNumber);
        PFMDTO00001 GetSAOFInfoByAccountNumber(string accountNumber);
        PFMDTO00001 GetFAOFInfoByAccountNumber(string accountNumber);
     
    }
}
