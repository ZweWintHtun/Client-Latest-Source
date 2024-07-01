using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

using Ace.Cbs.Mnm.Dmd;
///new reference add
using Ace.Cbs.Tcm.Dmd;
using System.Data;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00023 : IDataRepository<GLMORM00023>
    {
        //IList<MNMDTO00010> SelectAllForMonthly(string budget, string dcode);
        IList<GLMDTO00023> SelectAllMonthlyCOA(string dcode);
        IList<GLMDTO00023> SelectACodeAndBal(string currentMonth, string budget, string dcode);
        IList<MNMDTO00010> SelectTotalBalAndAcodeFromVWCCOA(string currentMonth, string budget, string dcode);
        IList<GLMDTO00024> SelectFromVWLedgerListingMonthlyPosting(DateTime startdate, DateTime enddate, string sourceBr, string workStation);

        PFMDTO00042 SelectReportTLfHomeOAmt_Of_Monthly_Posting(DateTime startdate, DateTime enddate, string sourceBr, string workStation);
        PFMDTO00042 LEDGERLISTINGOfMonthlyPostingProc(string acode, DateTime startdate, DateTime enddate, string sourceBr, string workStation);
        IList<GLMDTO00024> MonthlyPostingofCashAccProc(DateTime startdate, DateTime enddate, string workStation, string sourceBr);

        //bool UpdateMonthlyccoaMultipleData(IList<GLMDTO00023> allMonthlyCOAList, DateTime startdate, DateTime enddate, string branchCode, string workStation);

        ////For Reports
        IList<GLMDTO00023> SelectMonthlyCOAForIncomeReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation);
       
        IList<GLMDTO00023> SelectMonthlyCOAForExpenditureReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation);

        IList<GLMDTO00023> SelectMonthlyCOAForGeneralAssetsReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation);

        IList<GLMDTO00023> SelectMonthlyCOAForGeneralLiabilityReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation);

        void UpdateAll(GLMDTO00023 monthlycoaitemdto);

        GLMDTO00023 SelectAllByAccountCode(string ACode);

        GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode); //Added by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)

        IList<GLMDTO00023> SelectAllAccountType();

        IList<GLMDTO00023> SelectAllBranchCode();

        IList<GLMDTO00023> SelectAllTITLE();

        IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type);

        IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE);

        IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode);

        void SaveAll(GLMDTO00023 monthlycoaitemdto);

        void Update_All(GLMDTO00023 monthlycoaitemdto);

        void Update_Title_ItemOrder(GLMDTO00023 monthlycoaitemdto);

        void Update_SubTitle_SubItemOrder(GLMDTO00023 monthlycoaitemdto);

        void DeleteAll(GLMDTO00023 monthlycoaitemdto);

    }
}
