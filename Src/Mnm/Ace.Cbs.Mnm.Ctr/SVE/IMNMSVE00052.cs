using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00052 : IBaseService
    {
        IList<PFMDTO00001> SelectCustomerInfoAll(string sourcebr, string formName);  //VW_BANKSTATEMENT_CAOF (or) VW_BANKSTATEMENT_SAOF
        IList<PFMDTO00042> GetReportData(PFMDTO00042 DataDTO, int workStationId, int createdUserId); // Sp_Insert_Report_Data
        IList<PFMDTO00001> SelectBankStatementAll_ByAcctNo( string AcctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr, string formName);  //VW_BANKSTATEMENT_ALL & //VW_BANK_STATEMENT  && //VW_BANK
        string CheckingAccountNo(string accountNo, string branchCode, string formName);  //Cledger
    }
}
