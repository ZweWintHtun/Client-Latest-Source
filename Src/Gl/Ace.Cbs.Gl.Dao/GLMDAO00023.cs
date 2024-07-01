using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using NHibernate;
using NHibernate.Transform;
using System.Data;
using System.ComponentModel;
using Ace.Windows.Core.Utt;
namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00023 : DataRepository<GLMORM00023>, IGLMDAO00023
    {
        /////VW_CCoaDAO.SelectAllForMonthly
        //public IList<MNMDTO00010> SelectAllForMonthly(string budget, string dcode)
        //{
        //    IQuery Query = this.Session.GetNamedQuery("TCMVIW00009.SelectAllForMonthly");
        //    Query.SetString("budget", budget);
        //    Query.SetString("dcode", dcode);
        //    return Query.List<MNMDTO00010>();
        //}

        //VW_CCoaDAO.SelectAllForMonthly
        public IList<GLMDTO00023> SelectAllMonthlyCOA(string dcode)
        {
            IList<GLMDTO00023> result;
            IQuery query = this.Session.GetNamedQuery("SP_SelectAllMonthlyCOA");
            query.SetString("dcode", dcode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = query.List<GLMDTO00023>();
            return result;
        }
        //SelectACodeAndBal
        public IList<GLMDTO00023> SelectACodeAndBal(string currentMonth, string budget, string dcode)
        {
            IList<GLMDTO00023> result;
            IQuery query = this.Session.GetNamedQuery("SP_SelectACodeAndBal");
            query.SetString("currentMonth", currentMonth);
            query.SetString("budget", budget);
            query.SetString("dcode", dcode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = query.List<GLMDTO00023>();
            return result;
        }
        //Sele
        public IList<MNMDTO00010> SelectTotalBalAndAcodeFromVWCCOA(string currentMonth, string budget, string dcode)
        {
            IList<MNMDTO00010> result;
            IQuery query = this.Session.GetNamedQuery("SP_SelectTotalBalAndAcodeFromVWCCOA");
            query.SetString("currentMonth", currentMonth);
            query.SetString("budget", budget);
            query.SetString("dcode", dcode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
            result = query.List<MNMDTO00010>();
            return result;
        }
        ///VW_CCoaDAO.SelectAllForMonthly
        public IList<GLMDTO00024> SelectFromVWLedgerListingMonthlyPosting(DateTime startdate, DateTime enddate, string sourceBr, string workStation)
        {
            IList<GLMDTO00024> result;
            IQuery Query = this.Session.GetNamedQuery("SP_SelectFromVWLedgerListingMonthlyPosting");
            string sdate = startdate.ToString("yyyy/MM/dd");
            Query.SetString("startdate", sdate);
            string edate = enddate.ToString("yyyy/MM/dd");
            Query.SetString("enddate", edate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("workStation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00024)));
            result = Query.List<GLMDTO00024>();
            return result;
        }

        //Update Monthly_COA
       //public bool UpdateMonthlyccoaMultipleData(IList<GLMDTO00023> allMonthlyCOAList,DateTime startdate, DateTime enddate, string branchCode, string workStation)
       // {
       //     string strMonthlyCoaList = "";
       //     foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
       //     {
       //         strMonthlyCoaList += "<;>" + monthlycoaitemdto.ToDbString(monthlycoaitemdto);
       //         if (strMonthlyCoaList.Length > 0)
       //         {
       //             strMonthlyCoaList = strMonthlyCoaList.Substring(3);
       //         }
       //         strMonthlyCoaList += "</>" + monthlycoaitemdto.ToDbString(monthlycoaitemdto);
       //     }
       //     IQuery Query = this.Session.GetNamedQuery("SP_UpdateMonthlyccoaMultipleData");
       //     Query.SetString("strMonthlyCoaList", strMonthlyCoaList);
       //     Query.SetDateTime("startdate", startdate);
       //     Query.SetDateTime("enddate", enddate);
       //     Query.SetString("sourceBr", branchCode);
       //     Query.SetString("workStation", workStation);
       //     Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
       //     return Query.ExecuteUpdate() > 0;
       // }

        ///SelectReportTLfHomeOAmt_Of_Monthly_Posting
        public PFMDTO00042 SelectReportTLfHomeOAmt_Of_Monthly_Posting(DateTime startdate, DateTime enddate, string sourceBr, string workStation)
        {
            IQuery Query = this.Session.GetNamedQuery("SP_SelectReportTLfHomeOAmt_Of_Monthly_Posting");
            string sdate = startdate.ToString("yyyy/MM/dd");
            Query.SetString("startdate", sdate);
            string edate = enddate.ToString("yyyy/MM/dd");
            Query.SetString("enddate", edate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("workStation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 result = new PFMDTO00042();
            result = Query.UniqueResult<PFMDTO00042>();
            return result;
        }
        ///LEDGERLISTING_Of_Monthly_Posting_Proc
        public PFMDTO00042 LEDGERLISTINGOfMonthlyPostingProc(string acode, DateTime startdate, DateTime enddate, string sourceBr, string workStation)
        {
            IQuery Query = this.Session.GetNamedQuery("LEDGERLISTING_Of_Monthly_Posting_Proc");
            Query.SetString("acode", acode);
            string sdate = startdate.ToString("yyyy/MM/dd");
            Query.SetString("startdate", sdate);
            string edate = enddate.ToString("yyyy/MM/dd");
            Query.SetString("enddate", edate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("workStation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 result = new PFMDTO00042();
            result = Query.UniqueResult<PFMDTO00042>();
            return result;
        }
        public IList<GLMDTO00024> MonthlyPostingofCashAccProc(DateTime startdate, DateTime enddate, string workStation, string sourceBr)
        {
            IList<GLMDTO00024> result;
            IQuery Query = this.Session.GetNamedQuery("Monthly_Posting_of_CashAcc_Proc");
            string sdate = startdate.ToString("yyyy/MM/dd");
            Query.SetString("startdate", sdate);
            string edate = enddate.ToString("yyyy/MM/dd");
            Query.SetString("enddate", edate);
            Query.SetString("workStation", workStation);
            Query.SetString("sourceBr", sourceBr);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00024)));
            result = Query.List<GLMDTO00024>();
            return result;
        }
        // For Reports [IncomeExpenditure OR GeneralReturnsReport]
        public IList<GLMDTO00023> SelectMonthlyCOAForIncomeReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation)
        {
            IList<GLMDTO00023> result;
            IQuery Query = this.Session.GetNamedQuery("SP_SelectMonthlyCOAForIncome");
            Query.SetDateTime("requiredDate", requiredDate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("isIncome", isIncome);
            Query.SetString("workstation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = Query.List<GLMDTO00023>();
            return result;
           
        }
        public IList<GLMDTO00023> SelectMonthlyCOAForExpenditureReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation)
        {
            IList<GLMDTO00023> result;
            IQuery Query = this.Session.GetNamedQuery("SP_SelectMonthlyCOAForExpenditure");
            Query.SetDateTime("requiredDate", requiredDate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("isIncome", isIncome);
            Query.SetString("workstation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = Query.List<GLMDTO00023>();
            return result;
        }

        public IList<GLMDTO00023> SelectMonthlyCOAForGeneralAssetsReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation)
        {
            IList<GLMDTO00023> result;
            IQuery Query = this.Session.GetNamedQuery("SP_SelectMonthlyCOAForGeneralReturns_Assets");
            Query.SetDateTime("requiredDate", requiredDate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("isIncome", isIncome);
            Query.SetString("workstation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = Query.List<GLMDTO00023>();
            return result;
        }

        public IList<GLMDTO00023> SelectMonthlyCOAForGeneralLiabilityReport(DateTime requiredDate, string sourceBr, string isIncome, string workStation)
        {
            IList<GLMDTO00023> result;
            IQuery Query = this.Session.GetNamedQuery("SP_SelectMonthlyCOAForGeneralReturns_Liability");
            Query.SetDateTime("requiredDate", requiredDate);
            Query.SetString("sourceBr", sourceBr);
            Query.SetString("isIncome", isIncome);
            Query.SetString("workstation", workStation);
            Query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00023)));
            result = Query.List<GLMDTO00023>();
            return result;
        }
        public void UpdateAll(GLMDTO00023 monthlycoaitemdto)
        {
            //IList<GLMDTO00023> result;
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.UpdateAll");

            decimal Opening_bal = Convert.ToDecimal(monthlycoaitemdto.Opening_bal);
            query.SetDecimal("Opening_bal", Opening_bal);

            decimal Closing_bal =  Convert.ToDecimal(monthlycoaitemdto.Closing_bal);
            query.SetDecimal("Closing_bal", Closing_bal);

            decimal Credit_Amount =  Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
            query.SetDecimal("Credit_Amount", Credit_Amount);

            decimal Debit_Amount = Convert.ToDecimal(monthlycoaitemdto.Debit_Amount);
            query.SetDecimal("Debit_Amount", Debit_Amount);

            //DateTime UpdatedDate = Convert.ToDateTime(monthlycoaitemdto.UpdatedDate);
            query.SetDateTime("updatedDate", DateTime.Now);

            Int16 updatedUserId = Convert.ToInt16(monthlycoaitemdto.UpdatedUserId);
            query.SetInt16("updatedUserId", updatedUserId);

            string SUBITEM = Convert.ToString(monthlycoaitemdto.SUBITEM);
            query.SetString("SUBITEM", SUBITEM);

            string DCode = Convert.ToString(monthlycoaitemdto.DCode);
            query.SetString("DCode", DCode);

            string ITEM = Convert.ToString(monthlycoaitemdto.ITEM);
            query.SetString("ITEM", ITEM);

            query.ExecuteUpdate();     
        }

        public GLMDTO00023 SelectAllByAccountCode(string ACode)
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllByAccountCode")
            .SetString("ACode", ACode)
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            GLMDTO00023 GLMDTO00023 = query.ToList<GLMDTO00023>().FirstOrDefault();
            return GLMDTO00023;

        }

        //Added by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)
        public GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode)
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllMonthlyCOAByAccountCode")
            .SetString("ACode", ACode)
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            GLMDTO00023 GLMDTO00023 = query.ToList<GLMDTO00023>().FirstOrDefault();
            return GLMDTO00023;

        }

        public IList<GLMDTO00023> SelectAllAccountType()
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllAccountType")
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;

        }

        public IList<GLMDTO00023> SelectAllBranchCode()
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllBranchCode")
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;
        }

        public IList<GLMDTO00023> SelectAllTITLE()
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllTITLE")
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;
        }

        public IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type)
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllTITLE_By_Type")
            .SetString("Type", Type)
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;
        }

        public IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE)
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllSUBTITLE_by_TITLE")
            .SetString("TITLE", TITLE)
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;
        }

        public IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode)
        {
            var query = this.Session.GetNamedQuery("GLMORM00023.SelectAllOtherBankGroupTitle")
            .SetString("ACode", ACode)
            .SetResultTransformer(Transformers.AliasToBean<GLMDTO00023>()).List<GLMDTO00023>();
            IList<GLMDTO00023> GLMDTO00023 = query.ToList<GLMDTO00023>();
            return GLMDTO00023;

        }

        public void SaveAll(GLMDTO00023 monthlycoaitemdto)
        {
            //IList<GLMDTO00023> result;
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.SaveAll");

            query.SetString("ACODE", monthlycoaitemdto.ACODE);
            query.SetString("SUBITEM", monthlycoaitemdto.SUBITEM);
            query.SetString("TYPE", monthlycoaitemdto.TYPE);
            query.SetString("TITLE", monthlycoaitemdto.TITLE);
            query.SetString("SUBTITLE", monthlycoaitemdto.SUBTITLE);
            query.SetString("ITEM", monthlycoaitemdto.ITEM);
            query.SetInt32("SUBITEM_No", monthlycoaitemdto.SUBITEM_No);
            query.SetDecimal("Opening_bal",  Convert.ToDecimal(monthlycoaitemdto.Opening_bal));
            query.SetDecimal("Closing_bal", Convert.ToDecimal( monthlycoaitemdto.Closing_bal));
            query.SetDecimal("Credit_Amount",  Convert.ToDecimal(monthlycoaitemdto.Credit_Amount));
            query.SetDecimal("Debit_Amount", Convert.ToDecimal(monthlycoaitemdto.Debit_Amount));
            query.SetString("DCode", monthlycoaitemdto.DCode);
            query.SetBoolean("Active", monthlycoaitemdto.Active);
            query.SetString("OtherBankGroupTitle", monthlycoaitemdto.OtherBankGroupTitle);

            query.SetDateTime("CreatedDate", DateTime.Now);
            query.SetInt32("CreatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));
            query.ExecuteUpdate();   

        }

        public void Update_All(GLMDTO00023 monthlycoaitemdto)
        {
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.Update_All");

            query.SetString("TITLE", monthlycoaitemdto.TITLE);
            query.SetString("SUBTITLE", monthlycoaitemdto.SUBTITLE);
            query.SetString("ITEM", monthlycoaitemdto.ITEM);
            query.SetInt32("SUBITEM_No", monthlycoaitemdto.SUBITEM_No);
            query.SetString("OtherBankGroupTitle", monthlycoaitemdto.OtherBankGroupTitle);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));

            query.SetString("DCode", monthlycoaitemdto.DCode);
            //query.SetString("ACODE", monthlycoaitemdto.ACODE);//Comment by HMW at "28-11-2022" for data update issue (wrong acode parameter & no need in this condition)
            query.SetString("SUBITEM", monthlycoaitemdto.SUBITEM);
            query.SetString("TYPE", monthlycoaitemdto.TYPE);     
            query.SetBoolean("Active", monthlycoaitemdto.Active);
           

            query.ExecuteUpdate();
        }

        public void Update_Title_ItemOrder(GLMDTO00023 monthlycoaitemdto)
        {
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.Update_Title_ItemOrder");

            query.SetString("DCode", monthlycoaitemdto.DCode);
            query.SetString("TYPE", monthlycoaitemdto.TYPE);
            query.SetString("TITLE", monthlycoaitemdto.TITLE);           
            query.SetString("ITEM", monthlycoaitemdto.ITEM);
            query.SetBoolean("Active", monthlycoaitemdto.Active);
          
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));

            query.ExecuteUpdate();
        }

        public void Update_SubTitle_SubItemOrder(GLMDTO00023 monthlycoaitemdto)
        {
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.Update_SubTitle_SubItemOrder");

            query.SetString("DCode", monthlycoaitemdto.DCode);
            query.SetString("TYPE", monthlycoaitemdto.TYPE);
            query.SetString("TITLE", monthlycoaitemdto.TITLE);
            query.SetString("SUBTITLE", monthlycoaitemdto.SUBTITLE);
            query.SetInt32("SUBITEM_No", monthlycoaitemdto.SUBITEM_No);
            query.SetBoolean("Active", monthlycoaitemdto.Active);
           
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", Convert.ToInt32(CurrentUserEntity.CurrentUserID));

            query.ExecuteUpdate();
        }

        public void DeleteAll(GLMDTO00023 monthlycoaitemdto)
        {
            IQuery query = this.Session.GetNamedQuery("GLMORM00023.DeleteAll");

            query.SetString("SUBITEM", monthlycoaitemdto.SUBITEM);
            query.SetString("TYPE", monthlycoaitemdto.TYPE);
            query.SetString("TITLE", monthlycoaitemdto.TITLE);
            query.SetString("SUBTITLE", monthlycoaitemdto.SUBTITLE);
            query.SetString("ITEM", monthlycoaitemdto.ITEM);   
            //query.SetInt32("SUBITEM_No", monthlycoaitemdto.SUBITEM_No);        
            query.SetString("DCode", monthlycoaitemdto.DCode);

            query.ExecuteUpdate();

        }

    }
}
