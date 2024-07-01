using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00009 : IBaseService
    {
        IList<ChargeOfAccountDTO> ChargeOfAccountSelectByPCEAccount(string sourceBr);
       // MNMDTO00010 VW_CCOA_SumMonthByACode(string aCode, string currency, string budMonth);
        MNMDTO00037 NewSetup_SelectSDateEDate(string year);
        //IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation);        
        //IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation);
        
        
        void GetReportData(string aCode,DateTime startDate,DateTime endDate,bool isTransactionDate, int workStationId, int currentUserID); //ASDA
        MNMDTO00010 VW_CCOA_SumMonthByACode(string strOpeningField, string aCode, string currency, string budYear); //ASDA
        IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate,bool isTransactionDate, string sourcebr, int workStation);  //ASDA        
        IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate, string currency, bool isTransactionDate, string sourcebr, int workStation);  //ASDA
        
    }
}
