using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LMT99#00 DAO
    /// </summary>
    public interface ILOMDAO00011 : IDataRepository<LOMORM00011>
    {
        bool HasInLMT9900(string lno, string sourceBr);
    }
}
