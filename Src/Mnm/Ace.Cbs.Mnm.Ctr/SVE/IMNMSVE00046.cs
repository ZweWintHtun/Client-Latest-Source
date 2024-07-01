using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00046 : IBaseService
    {
        void GetReportData(int month, int year,int workStationId, int currentUserID); // by ASDA
        IList<PFMDTO00001> SelectCurrentAC_AllByMonth(string month, string sourceBr);
        IList<PFMDTO00001> SelectSavingAC_AllByMonth(string month, string sourceBr);

        IList<MNMDTO00046> BankSatatementByAllWithdrawDeposit(string acctno, string workstation, int year, int month, int currentUserId,string branchCode);
        //IList<PFMDTO00001> SelectCustID(string accountNo, string budmonth, string budget, string acsign);
        //PFMDTO00001 SelectCustInfoByCustID(string custID);
        string SelectAccountSign(string accountNo, string sourceBr);
        PFMDTO00033 SelectBalance_ByAcctNoAndBudYear(string month, string AcctNo, string budYear, string sourceBr);
    }
}
