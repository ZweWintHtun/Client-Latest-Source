using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00316 : IDataRepository<LOMVIW00316>
    {
        //IList<LOMDTO00316> SelectByPLNO(string plno, string sourceBr);//commented by AAM(12_Sep_2018)
        IList<LOMDTO00316> SelectByPLNO(string acctNo, string sourceBr);//Modified by AAM(12_Sep_2018)
        IList<LOMDTO00316> SelectByDueDateForPLIntDuePreListing(DateTime startDate, DateTime endDate, string sourceBr, string currency);
        IList<LOMDTO00316> SelectPLOverdrawnListing(string sourceBr, string currency, DateTime startDate, DateTime endDate);
        IList<LOMDTO00316> SelectPLOverdrawnListingByCompanyName(string sourceBr, string currency, string companyName);
        IList<LOMDTO00316> SelectCompanyName();
        IList<LOMDTO00316> SelectPLRepaymentListing(DateTime startDate, DateTime endDate, string sourceBr, string currency);
        
    }
}
