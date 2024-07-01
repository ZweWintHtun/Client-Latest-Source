using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00009 : IDataRepository<MNMVIW00011>
    {
        //IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation);
        //IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation);
        
        IList<ChargeOfAccountDTO> ChargeOfAccountSelectByPCEAccount(string sourcebr);
        IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate,bool isTransactionDate, string sourcebr, int workStation);
        IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate,string currency, bool isTransactionDate, string sourcebr, int workStation);
    }
}
