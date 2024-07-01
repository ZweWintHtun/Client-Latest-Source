//----------------------------------------------------------------------
// <copyright file="CXDAO00009" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>♠ Ye Mann Aung ♠</CreatedUser>
// <CreatedDate> 2013.12.11 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Sam.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate.Transform;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// DAO Class for View Queries
    /// </summary>
    public class CXDAO00009 : DataRepository<PFMDTO00042>, ICXDAO00009
    {

       public IList<TLMDTO00009> SelectDataForMultiDeno(string cur, string branchno, DateTime cashdate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMVIW00D14.SelectDataForMultiDeno");
            query.SetString("cur", cur);
            query.SetString("sourcebr", branchno);
            query.SetDateTime("cashdate", cashdate);
            IList<TLMDTO00009> denoMultiList = query.List<TLMDTO00009>();
            return denoMultiList;
        }

        //"TLMVIW00D14.SelectDataForMultiDeno for All Counter"
        public IList<TLMDTO00009> SelectDataForMultiDenoByCounterNo(string cur, string branchno, DateTime cashdate,string counterno)
        {
            IQuery query = this.Session.GetNamedQuery("TLMVIW00D14.SelectDataForMultiDenoForAllCounter");
            query.SetString("cur", cur);
            query.SetString("sourcebr", branchno);
            query.SetString("counterno", counterno);
            query.SetDateTime("cashdate", cashdate);
            IList<TLMDTO00009> denoMultiList = query.List<TLMDTO00009>();
            return denoMultiList;
        }
        //"MNMVIW00024.SelectFixedReceiptInfo"
        public IList<MNMDTO00035> SelectFReceiptInfo(string acctno, string branchno, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SelectFixedReceiptInfo");
            query.SetString("acctno", acctno);
            query.SetString("branchno", branchno);
            query.SetString("cur", cur);
            IList<MNMDTO00035> list = query.List<MNMDTO00035>();
            return list;
        }

        //SelectDurationForFixedDeposit
        public IList<MNMDTO00035> SelectDurationForFixedDeposit(decimal duration, string branchno)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00012.SelectFixedDepositByDuration");
            query.SetDecimal("duration", duration);
            query.SetString("sourceBr", branchno);
            IList<MNMDTO00035> list = query.List<MNMDTO00035>();
            return list;
        }


        //Select Fixed Deposit Info for all
        public IList<PFMDTO00021> SelectFixedDepoInfoForAll(DateTime start_date, DateTime end_date, string branchno, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SelectFixedDepoInfoForAll");
            query.SetDateTime("sdate", start_date);
            query.SetDateTime("edate", end_date);
            query.SetString("branchno", branchno);
            query.SetString("cur", cur);
            IList<PFMDTO00021> list = query.List<PFMDTO00021>();
            return list;
        }

        //Select Fixed Deposit Info(Individual to minor)
        public IList<PFMDTO00021> SelectFixedDepoInfoForOther(DateTime start_date, DateTime end_date, string branchno, string cur, string acsign)
        {
            IQuery query = this.Session.GetNamedQuery("SelectFixedDepoInfoForOther");
            query.SetDateTime("sdate", start_date);
            query.SetDateTime("edate", end_date);
            query.SetString("branchno", branchno);
            query.SetString("cur", cur);
            query.SetString("acsign", acsign);
            IList<PFMDTO00021> list = query.List<PFMDTO00021>();
            return list;
        }

        //Select Fixed Deposit Info for all
        public IList<PFMDTO00021> SelectFixedDepoInfoForAllByFilter(DateTime start_date, DateTime end_date, string branchno, string cur, string accruedstatus)
        {
            IQuery query = this.Session.GetNamedQuery("SelectFixedDepoInfoForAllByFilter");
            query.SetDateTime("sdate", start_date);
            query.SetDateTime("edate", end_date);
            query.SetString("branchno", branchno);
            query.SetString("cur", cur);
            query.SetString("accruedstatus", accruedstatus);
            IList<PFMDTO00021> list = query.List<PFMDTO00021>();
            return list;
        }

        //Select Fixed Deposit Info(Individual to minor)
        public IList<PFMDTO00021> SelectFixedDepoInfoForOtherByFilter(DateTime start_date, DateTime end_date, string branchno, string cur, string acsign, string accruedstatus)
        {
             IQuery query = this.Session.GetNamedQuery("SelectFixedDepoInfoForOtherByFilter");
            query.SetDateTime("sdate", start_date);
            query.SetDateTime("edate", end_date);
            query.SetString("branchno", branchno);
            query.SetString("cur", cur);
            query.SetString("acsign", acsign);
            query.SetString("accruedstatus", accruedstatus);
            IList<PFMDTO00021> list = query.List<PFMDTO00021>();
            return list;
        }

        public IList<MNMDTO00077> SelectByFixedAutoRenewalListing(DateTime startDate, DateTime endDate, string cur, string status, string sourceBr, string formName)
        {

            
            IQuery query = null;
            switch (formName)
            {
                case "Fixed Auto Renewal Status Only Principle Listing":
                    query = this.Session.GetNamedQuery("MNMVIW00081.SelectFixedRenewalByOnlyPrinciple");
                    break;

                case "Fixed Auto Renewal Status Principle And Interest Listing":
                    query = this.Session.GetNamedQuery("MNMVIW00081.SelectFixedRenewalByPrincipleAndInterest");
                    break;

                case "Fixed Auto Renewal Status Not Auto Renewal Listing":
                    query = this.Session.GetNamedQuery("MNMVIW00081.SelectFixedRenewalByNotAutoRenewal");
                    break;
                //case "Fixed Auto Renewal All Listing":
                //    query = this.Session.GetNamedQuery("MNMVIW00081.SelectFixedRenewalByAll");
                //    break;
            }

            
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur",cur);
            query.SetString("accruedstatus", status);
     
            query.SetString("sourceBr", sourceBr);
            IList<MNMDTO00077> ReportDataList = query.List<MNMDTO00077>();
            return ReportDataList;
        
        }

        public IList<MNMDTO00077> SelectByFixedAutoRenewalAll(DateTime startDate, DateTime endDate, string cur, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00081.SelectFixedRenewalByAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("cur", cur);
            query.SetString("sourceBr", sourceBr);
            IList<MNMDTO00077> ReportDataList = query.List<MNMDTO00077>();
            return ReportDataList;
        
        }
        public IList<PFMDTO00029> SelectLinkACAll(string branchno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectCbalForLinkAC");
            query.SetString("branchNo", branchno);
            IList<PFMDTO00029> LinkAClist = query.List<PFMDTO00029>();
            return LinkAClist;
        }

        public IList<PFMDTO00029> SelectLinkACExcess(string branchno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectCbalForExcessAC");
            query.SetString("branchNo", branchno);
            IList<PFMDTO00029> list = query.List<PFMDTO00029>();
            return list;
        }

        public IList<PFMDTO00001> SelectCaofInfo(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectCurrentAccountInfo");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00001> list = query.List<PFMDTO00001>();
            return list;
        }

        public IList<PFMDTO00001> SelectSaofInfo(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectSavingAccountInfo");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00001> list = query.List<PFMDTO00001>();
            return list;
        }

        public PFMDTO00001 SelectCaofInfoByAcctno(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectCurrentAccountInfoByAcctno");
            query.SetString("acctno", acctno);
            PFMDTO00001 currentdto = query.UniqueResult<PFMDTO00001>();
            return currentdto;
        }

        public PFMDTO00001 SelectSaofInfoByAcctno(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectSavingAccountInfoByAcctno");
            query.SetString("acctno", acctno);
            PFMDTO00001 savingdto = query.UniqueResult<PFMDTO00001>();
            return savingdto;
        }

        public IList<PFMDTO00054> SelectDenoOutstandingReport(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00056.SelectDenoOutstandingReport");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00054> list = query.List<PFMDTO00054>();
            return list;
        }

        public IList<TLMDTO00009> SelectMultiTransactionDenoOutstandingReport(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectMultiTransactionalDenoOutstandingReport");
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00009> list = query.List<TLMDTO00009>();
            return list;
        }

        public IList<TLMDTO00004> HomeIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("IncomeListingForHome.SelectByAllBranch");
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> ActiveIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("IncomeListingForActive.SelectByAllBranch");
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branch, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("OnlineTransactionListingForHome.SelectByAllBranch");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            query.SetString("sourceBranch", sourceBranch);
            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branch, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("OnlineTransactionListingForActive.SelectByAllBranch");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            query.SetString("sourceBranch", sourceBranch);
            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranchForReversal(DateTime startDate, DateTime endDate, string branch, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("OnlineTransactionListingForActiveWithReversal.SelectByAllBranch");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            query.SetString("sourceBranch", sourceBranch);
            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> HomeTransactionByBranchListing(DateTime startDate, DateTime endDate, string branch, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("HomeTransactionByBranchListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            query.SetString("sourceBranch", sourceBranch);

            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00004> ActiveTransactionByBranchListing(DateTime startDate, DateTime endDate, string branch, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("ActiveTransactionByBranchListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            query.SetString("sourceBranch", sourceBranch);

            IList<TLMDTO00004> list = query.List<TLMDTO00004>();
            return list;
        }

        public IList<TLMDTO00037> SelectIBLTestKeyListingReport()
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00048.SelectIBLTestKeyListingReport");

            IList<TLMDTO00037> list = query.List<TLMDTO00037>();
            IList<TLMDTO00037> lists = new List<TLMDTO00037>();

            for (int i = 0; i < list.Count; i++)
            {
                TLMDTO00037 dto = new TLMDTO00037();
                dto.Code = list[i].Code;
                dto.Value = list[i].Value;
                dto.Phone = list[i].StartDate.Value.ToString("dd MMM,yyyy");
                dto.Status = list[i].Status;

                lists.Add(dto);
            }

            return lists;

        }

        public Nullable<DateTime> SelectMaxDate(DateTime date)
        {
            object maxdateobject;
            DateTime maxdateDateTime;
            IQuery query = this.Session.GetNamedQuery("TLMDAO00048.SelectMaxDate");
            query.SetString("datetime", date.ToString("yyyy/MM/dd"));
            string sqlQuery = this.GetSQLString(query.QueryString);
            maxdateobject = query.SetFirstResult(0).SetMaxResults(1).UniqueResult();
            if (maxdateobject != null)
            {
                maxdateDateTime = Convert.ToDateTime(maxdateobject);
                return maxdateDateTime;
            }
            else
            {
                return null;
            }

        }

        public IList<TLMDTO00037> SelectAllIBLTestKeyListingByMaxDate(DateTime maxdate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00048.SelectAllIBLTestKeyListingByMaxDate");
            query.SetString("maxdate", maxdate.ToString("yyyy/MM/dd"));
            IList<TLMDTO00037> list = query.List<TLMDTO00037>();
            return list;

        }

        public Nullable<decimal> SelectSumM1Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM1Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month1).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM2Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM2Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month2).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM3Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM3Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month3).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM4Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM4Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month4).Sum();

            decimal monthslists = month;

            return monthslists;

        }

        public Nullable<decimal> SelectSumM5Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM5Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month5).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM6Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM6Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month6).Sum();

            decimal monthslists = month;

            return monthslists;

        }

        public Nullable<decimal> SelectSumM7Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM7Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month7).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM8Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM8Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month8).Sum();

            decimal monthslists = month;

            return monthslists; ;

        }

        public Nullable<decimal> SelectSumM9Data(string accountNo, string budgetYear)
        {

            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM9Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month9).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM10Data(string accountNo, string budgetYear)
        {

            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM10Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month10).Sum();

            decimal monthslists = month;

            return monthslists;

        }

        public Nullable<decimal> SelectSumM11Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM11Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month11).Sum();

            decimal monthslists = month;

            return monthslists;
        }

        public Nullable<decimal> SelectSumM12Data(string accountNo, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00051.SelectSumM12Data");
            query.SetString("accountno", accountNo);
            query.SetString("budget", budgetYear);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();

            var month = (from value in list

                         select value.Month12).Sum();

            decimal monthslists = month;

            return monthslists;

        }

        public IList<PFMDTO00042> SelectDepositListingByAll(string sourceBr,string workstation)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByAll");
                query.SetString("sourceBr", sourceBr);
                query.SetString("workstation",workstation);
                IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();
                return reportTLFList;
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<PFMDTO00042> SelectDepositListingByCounterNo(string sourceBr, string counterNo,string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByCounter");
            query.SetString("sourceBr", sourceBr);
            query.SetString("counterNo", counterNo);
            query.SetString("workstation",workstation);
            IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();
            return reportTLFList;
        }

        public IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate,
            decimal minimumAmount, decimal maximumAmount, string acSign, string sourceBr,string workstation)
        {
            try
            {

                //IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecDepositListingByGrade");
                ////query.SetDateTime("startDate", startDate);
                ////query.SetDateTime("endDate", endDate);
                //query.SetString("acSign", acSign + "%");
                //query.SetString("sourceBr", sourceBr);
                //query.SetString("workstation",workstation);
                //IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();

                //if (reportTLFList != null)
                //{
                //    var qq = (from value in reportTLFList
                //              where value.Amount >= minimumAmount && value.Amount <= maximumAmount
                //              select value).ToList();
                //    reportTLFList = qq;
                //}
                //return reportTLFList;
                
                //Modified by HMW at 08-05-2019 (To show "Group No" at "Deposit Listing By Grade/By Amount Report")
                IQuery query = this.Session.GetNamedQuery("SP_Tran_Deposit_Listing_ByAmount");
                query.SetDecimal("minimumAmount", minimumAmount);
                query.SetDecimal("maximumAmount", maximumAmount);
                query.SetString("sourceBr", sourceBr);
                query.SetString("workstationId", workstation);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
                IList<PFMDTO00042> result = query.List<PFMDTO00042>();
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<PFMDTO00042> SelectDepositListingByAccountNo(string sourceBr, string accountNo,string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00064.SelecDepositListingByAccountNo");
            query.SetString("sourceBr", sourceBr);
            query.SetString("accountNo", accountNo);
            query.SetString("workstation",workstation);
            IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();

            return reportTLFList;

        }

        //public IList<PFMDTO00042> SelectDepositListingByAccountType(string workStation, string accountSign, string userNo)
        //{
        //    try
        //    {
        //        IQuery query = this.Session.GetNamedQuery("TLMDAO00065.SelecDepositListingByAccountType");
        //        query.SetString("workStation", workStation);
        //        query.SetString("userNo", userNo);
        //        IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();

        //        var results = reportTLFList.Where(X => X.AccountSign.StartsWith(accountSign))
        //                   .Select(X => X);
        //        IList<PFMDTO00042> aa = results.ToList();
        //        return aa;
        //    }
        //    catch (Exception ex)
        //    { return null; }
        //}

        public IList<PFMDTO00042> SelectDepositListingByAccountType(string sourceBr, string accountSign,string workstation)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00065.SelecDepositListingByAccountType");
                query.SetString("sourceBr", sourceBr);
                //query.SetString("userNo", userNo);
                query.SetString("acSign", accountSign + "%");
                query.SetString("workstation",workstation);
                //query.SetString("acsign", accountSign + "%");            
                IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();
                var results = reportTLFList.Where(X => X.AccountSign.StartsWith(accountSign))
                           .Select(X => X);
                IList<PFMDTO00042> aa = results.ToList();
                return aa;
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<PFMDTO00042> SelectWithdrawalListingAllReport(DateTime startDate, DateTime endDate, string sourcebranchcode, int workstation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00066.SelectWithdrawalListingAllReport");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebranchcode);
            query.SetInt32("workstationId", workstation);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithdrawalListingByAccountTypeReport(DateTime startDate, DateTime endDate, int workstation, string acsign, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00066.SelectWithdrawalListingByAccountTypeReport");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetInt32("workstation", workstation);
            query.SetString("acsign", acsign);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithdrawalListingByCounterNoReport(DateTime startDate, DateTime endDate, string sourcebr, int workstationId,string userno)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00067.SelectWithdrawalListingByCounterNoReport");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebr);
            query.SetInt32("workstationId", workstationId);
            query.SetString("userno",userno);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithdrawalListingByAccountNoReport(DateTime startDate, DateTime endDate, string accountNo, string sourcebr, int workstation)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00068.SelectWithdrawalListingByAccountNoReport");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetInt32("workstation", workstation);
            query.SetString("accountno", accountNo);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }
        public IList<PFMDTO00042> SelectTransactionDateWithReversalByHome(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectTransactionDateWithReversalByCurrencyCode(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalByCurCodeTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;

        }

        public IList<PFMDTO00042> SelectWithReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalSettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithReversalByCurrencyCodeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalByCurCodeTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        //Withdrawal Amount and Deposit Amount for Opening Balance And CLosing Balance ( Current Account And Saving Account ) of BankStatement Listing By Date <By HWH>>
        public IList<PFMDTO00042> SelectWithdrawAmountAndDepositAmountBankStatementForCS(string workstation, string accountno, DateTime firstdate, DateTime seconddate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A51.SelectWithdrawAmountAndDepositAmountBankStatement");
            query.SetString("workstation", workstation);
            query.SetString("accountno", accountno);
            query.SetString("firstdate", firstdate.ToString("yyyy/MM/dd"));
            query.SetString("seconddate", seconddate.ToString("yyyy/MM/dd"));

            IList<PFMDTO00042> bankstatementlist = query.List<PFMDTO00042>();
            return bankstatementlist;
        }

        //Select Information for ( Current Account And Saving Account ) of BankStatement Listing By Date <by HWH>
        public IList<PFMDTO00042> SelectDatasFromBankStatementForCS(string workstation, string accountno, DateTime startdate, DateTime enddate,bool withReversal)
        {
            IList<PFMDTO00042> bankstatementlist = new List<PFMDTO00042>();
            if (withReversal)
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00A51.SelectDatasFromBankStatement");
                query.SetString("workstation", workstation);
                query.SetString("accountno", accountno);
                query.SetString("startdate", startdate.ToString("yyyy/MM/dd"));
                query.SetString("enddate", enddate.ToString("yyyy/MM/dd"));

                bankstatementlist = query.List<PFMDTO00042>().OrderBy(x => x.CreatedDate).ToList();
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00A51.SelectDatasFromBankStatementWithoutReversal");
                query.SetString("workstation", workstation);
                query.SetString("accountno", accountno);
                query.SetString("startdate", startdate.ToString("yyyy/MM/dd"));
                query.SetString("enddate", enddate.ToString("yyyy/MM/dd"));

                bankstatementlist = query.List<PFMDTO00042>().OrderBy(x => x.CreatedDate).ToList();
            }
            return bankstatementlist;
        }

        //Withdrawal Amount and Deposit Amount for Opening Balance And CLosing Balance ( Fixed Account ) of BankStatement Listing By Date <By HWH>>
        public IList<PFMDTO00042> SelectWithdrawAmountAndDepositAmountBankStatementForFixed(string workstation, string accountno, DateTime firstdate, DateTime seconddate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A52.SelectWithdrawAmountAndDepositAmountBankStatement");
            query.SetString("workstation", workstation);
            query.SetString("accountno", accountno);
            query.SetString("firstdate", firstdate.ToString("yyyy/MM/dd"));
            query.SetString("seconddate", seconddate.ToString("yyyy/MM/dd"));

            IList<PFMDTO00042> bankstatementlist = query.List<PFMDTO00042>();
            return bankstatementlist;
        }

        //Select Information for ( Fixed Account No ) of BankStatement Listing By Date <by HWH>
        public IList<PFMDTO00042> SelectDatasFromBankStatementForFixed(string workstation, string accountno, DateTime startdate, DateTime enddate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A52.SelectDatasFromBankStatement");
            query.SetString("workstation", workstation);
            query.SetString("accountno", accountno);
            query.SetString("startdate", startdate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", enddate.ToString("yyyy/MM/dd"));

            IList<PFMDTO00042> bankstatementlist = query.List<PFMDTO00042>();
            return bankstatementlist;
        }

        public IList<TLMDTO00058> SelectDayBookCurrent(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrent");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);

            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;

        }

        public IList<TLMDTO00058> SelectDayBookCurrentBySettlementDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrentBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);

            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;

        }

        //Added by HWKO (14-Aug-2017)
        public IList<TLMDTO00058> SelectDayBookCurrentAll(string workStation, string sourceCur, DateTime requireDate,string acsign, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrentAll");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrentAll_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }

        }

        public IList<TLMDTO00058> SelectDayBookCurrentAllBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName)
        {
           
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrentAllBySettlementDate");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A53.SelectDayBookCurrentAllBySettlementDate_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }

        }
        //End Region

        public IList<TLMDTO00058> SelectDayBookSavings(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A54.SelectDayBookSavings");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayBookDomestic(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
 
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomestic");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomestic_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00017> SelectDataForDrawingRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectDataForDrawingRemittanceAllByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;

                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;
                encashdto.OtherBank = encashlists[i].OtherBank;
                Encashlists.Add(encashdto);

            }
            return Encashlists;

        }

        public IList<TLMDTO00017> SelectDataForDrawingRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectDataForDrawingRemittanceAllBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;

                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;
                encashdto.OtherBank = encashlists[i].OtherBank;
                Encashlists.Add(encashdto);

            }
            return Encashlists;

        }

        public IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectDataForDrawingRemittanceByBranchByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("dbank", bankno);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;
                encashdto.OtherBank = encashlists[i].OtherBank;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectDataForDrawingRemittanceByBranchBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("dbank", bankno);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;

                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;
                encashdto.OtherBank = encashlists[i].OtherBank;
                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectAmountForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectAmountForDrawingRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetDecimal("startamount", startamount);
            query.SetDecimal("endamount", endamount);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.OtherBank = encashlists[i].OtherBank;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectAmountForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectAmountForDrawingRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetDecimal("startamount", startamount);
            query.SetDecimal("endamount", endamount);
            query.SetString("sourceBr", sourceBr);

            string sqlQuery = this.GetSQLString(query.QueryString);

            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;
                encashdto.OtherBank = encashlists[i].OtherBank;
                encashdto.Bank_Alias = encashlists[i].Bank_Alias;

                Encashlists.Add(encashdto);

            }
            return Encashlists;

        }

        public IList<TLMDTO00017> SelectNRCForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNRCForDrawingRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", "%" + nrc + "%");

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNRCForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNRCForDrawingRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", "%" + nrc + "%");

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].SettlementDate.Value.ToString("yyyy/mm/dd");
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNRCExactlyForDrawingRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", nrc);

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNRCExactlyForDrawingRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", nrc);

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].SettlementDate.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNameForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNameForDrawingRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", "%" + name + "%");

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNameForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNameForDrawingRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", "%" + name + "%");

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].SettlementDate.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNameExactlyForDrawingRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", name);

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].DateTime.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00058.SelectNameExactlyForDrawingRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", name);

            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> encashlists = query.List<TLMDTO00017>();
            IList<TLMDTO00017> Encashlists = new List<TLMDTO00017>();
            for (int i = 0; i < encashlists.Count; i++)
            {
                TLMDTO00017 encashdto = new TLMDTO00017();
                encashdto.RegisterNo = encashlists[i].RegisterNo;
                encashdto.Br_Alias = encashlists[i].Br_Alias;
                encashdto.Date = encashlists[i].SettlementDate.Value.ToShortDateString();
                encashdto.Type = encashlists[i].Type;
                encashdto.Name = encashlists[i].Name;
                encashdto.CashAmount = (encashlists[i].RDType == "CS") ? encashlists[i].Amount : 0;
                encashdto.Amount = (encashlists[i].RDType == "TR") ? encashlists[i].Amount : 0;
                encashdto.Currency = encashlists[i].Currency;
                encashdto.TlxCharges = encashlists[i].TlxCharges;
                encashdto.Commission = encashlists[i].Commission;

                Encashlists.Add(encashdto);

            }
            return Encashlists;
        }

        public IList<PFMDTO00042> SelectTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A52.SelectTranDateWithReversalByForAllBranchAndSourceCur");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithReversalByForAllBranchAndSourceCurBySettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A52.SelectWithReversalByForAllBranchAndSourceCurBySettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            //query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;

        }

        public IList<TLMDTO00058> SelectDayBookCurrentReversal(string workStation, string sourceCur, System.DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentReversal");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayBookCurrentReversalBySettlementDate(string workStation, string sourceCur, System.DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentReversalBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        //Added by HWKO (14-Aug-2017)
        public IList<TLMDTO00058> SelectDayBookCurrentAllReversal(string workStation, string sourceCur, System.DateTime requireDate, string acsign, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentAllReversal");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentAllReversal_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookCurrentAllReversalBySettlementDate(string workStation, string sourceCur, System.DateTime requireDate, string acsign, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentAllReversalBySettlementDate");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00B53.SelectDayBookCurrentAllReversalBySettlementDate_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }
        //End Region

        public IList<TLMDTO00058> SelectDayBookSavingsReversal(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B54.SelectDayBookSavings_Reversal");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayBookDomesticReversal(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticReversal");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticReversal_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<PFMDTO00042> SelectAllWithoutReversalByHomeTransactionDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B52.SelectAllByBankCashWithoutReversalTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeTransactionDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B52.SelectByBankCashWithoutReversalByCurCodeTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectAllWithoutReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B52.SelectAllByBankCashWithoutReversalSettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00B52.SelectByBankCashWithoutReversalByCurCodeSettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<TLMDTO00058> SelectDayBookCurrentHome(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrent_Home");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        //Added by HWKO (14-Aug-2017)
        public IList<TLMDTO00058> SelectCurrentDayBookAllHome(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrentAll_Home");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrentAll_Home_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookCurrent_HomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrent_HomeBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        //Added by HWKO (14-Aug-2017)
        public IList<TLMDTO00058> SelectDayBookCurrentAll_HomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrentAll_HomeBySettlementDate");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookCurrentAll_HomeBySettlementDate_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayFixed(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C54.SelectDayBookFixed");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayBookDomesticHome(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
           
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookDomesticHome");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookDomesticHome_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        //public MNMDTO00010 VW_CCOA_SumMonthByACode(string aCode, string currency, string budmonth) //nnl
        //{
        //    string dmlString = "select new prevccoadto (Sum(" + budmonth + ") as AMOUNT) from TCMVIW00009 Where ACODE =" + "'" + aCode + "'" + " and CUR =" + "'" + currency + "'" + " and Active=true";
        //    IQuery query = this.Session.CreateQuery(dmlString);

        //    return query.UniqueResult<MNMDTO00010>();

        //}

        public MNMDTO00010 VW_CCOA_SumMonthByACode(string strOpeningField, string aCode, string currency, string budYear) // modify by ASDA
        {
            string dmlString = "select new prevccoadto (Sum(" + strOpeningField + ") as AMOUNT) from TCMVIW00009 Where ACODE =" + "'" + aCode + "'" + " and CUR =" + "'" + currency + "'" + " and BUDGET =" + "'" + budYear + "'" + " and Active=true";
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.UniqueResult<MNMDTO00010>();
        }
        //---------------------------------------------

        public IList<TCMDTO00013> SelectAcctNobyOVERDRAWN(string workstation, string currency, string sorting)  //nnl
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.OVERDRAWN_AMOUNT>0 and VW_L.WORKSTATION=" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }

        public IList<TCMDTO00013> SelectAcctNoAbyWorkstation(string workstation, string currency, string sorting)  //nnl
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            //IQuery query = this.Session.GetNamedQuery("TCMVIW00013.SelectLedgerBalance");            
            //query.SetString("workstation", workstation.ToString());
            //query.SetString("cur", currency);

            return query.List<TCMDTO00013>();
        }

        public IList<TCMDTO00013> SelectAcctNoCbyWorkstation(string workstation, string currency, string sorting)  //nnl
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'C%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }

        //Added by HWKO (17-Aug-2017)
        public IList<TCMDTO00013> SelectAcctNoBbyWorkstation(string workstation, string currency, string sorting) 
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'B%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }
        public IList<TCMDTO00013> SelectAcctNoHbyWorkstation(string workstation, string currency, string sorting)
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'H%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }
        public IList<TCMDTO00013> SelectAcctNoPbyWorkstation(string workstation, string currency, string sorting)
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'P%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }
        public IList<TCMDTO00013> SelectAcctNoDbyWorkstation(string workstation, string currency, string sorting)
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'D%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }
        //End Region


        public IList<TCMDTO00013> SelectAcctNoFbyWorkstation(string workstation, string currency, string sorting)  //nnl
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L where VW_L.ACSign like 'F%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }

        public IList<TCMDTO00013> SelectAcctNoSbyWorkstation(string workstation, string currency, string sorting)  //nnl
        {
            string dmlString = "select new TCMDTO00013 ( VW_L.ACCTNO, VW_L.CBAL, VW_L.OVERDRAWN_AMOUNT, VW_L.OVDLIMIT, VW_L.NAME, VW_L.WORKSTATION, VW_L.SOURCECUR, VW_L.ACSign ) from TCMVIW00013 as VW_L Where VW_L.ACSign like 'S%' and VW_L.WORKSTATION =" + "'" + workstation + "'" + " and VW_L.SOURCECUR=" + "'" + currency + "'" + " order by VW_L." + sorting;
            IQuery query = this.Session.CreateQuery(dmlString);

            return query.List<TCMDTO00013>();
        }

        public IList<TLMDTO00017> SelectDataForEncashRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectDataForEncashRemittanceAllByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();

            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }

                DTO.Currency = drawinglist[i].Currency;
                encashlists.Add(DTO);

            }

            return encashlists;
        }

        public IList<TLMDTO00017> SelectDataForEncashRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectDataForEncashRemittanceAllBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }

                DTO.Currency = drawinglist[i].Currency;

                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectDataForEncashRemittanceByBranchByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("ebank", bankno);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;

                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectDataForEncashRemittanceByBranchBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("ebank", bankno);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;

                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectAmountForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectAmountForEncashRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetDecimal("startamount", startamount);
            query.SetDecimal("endamount", endamount);
            query.SetString("sourceBr", sourceBr);


            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                // DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectAmountForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectAmountForEncashRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetDecimal("startamount", startamount);
            query.SetDecimal("endamount", endamount);
            query.SetString("sourceBr", sourceBr);


            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNRCForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNRCForEncashRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", "%" + nrc + "%");
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNRCForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNRCForEncashRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", "%" + nrc + "%");
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNRCExactlyForEncashRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", nrc);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNRCExactlyForEncashRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("nrc", nrc);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNameForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNameForEncashRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", "%" + name + "%");
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNameForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNameForEncashRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", "%" + name + "%");
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNameExactlyForEncashRemittanceByTransactionDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", name);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }

        public IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A58.SelectNameExactlyForEncashRemittanceBySettlementDate");
            query.SetDateTime("startdate", startDate);
            query.SetDateTime("enddate", endDate);
            query.SetString("name", name);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00001> drawinglist = query.List<TLMDTO00001>();
            IList<TLMDTO00017> encashlists = new List<TLMDTO00017>();

            for (int i = 0; i < drawinglist.Count; i++)
            {
                TLMDTO00017 DTO = new TLMDTO00017();
                DTO.RegisterNo = drawinglist[i].RegisterNo;
                DTO.Br_Alias = drawinglist[i].Br_Alias;
                DTO.Type = drawinglist[i].Type;
                DTO.PhoneNo = drawinglist[i].Date_Time.Value.ToShortDateString();
                DTO.Name = drawinglist[i].Name;
                DTO.Commission = (drawinglist[i].ToAccountNo == string.Empty || drawinglist[i].ToAccountNo == null) ? drawinglist[i].Amount : 0;
                DTO.Amount = (drawinglist[i].ToAccountNo != string.Empty && drawinglist[i].ToAccountNo != null) ? drawinglist[i].Amount : 0;

                if (drawinglist[i].OtherBank == false)
                {
                    DTO.Narration = "Inter Branch Total";
                }
                else
                {
                    DTO.Narration = "Inter Bank Total";
                }
                DTO.Currency = drawinglist[i].Currency;
                DTO.CashAmount = drawinglist[i].Amount;
                encashlists.Add(DTO);

            }
            return encashlists;
        }
        //For Bank Cash (modify by ZMS(29.11.17)
        public IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurTransactionDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C52.SelecteWithoutReversalByForAllBranchAndSourceCurTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }
        //For Bank Cash (modify by ZMS(29.11.17)
        public IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C52.SelecteWithoutReversalByForAllBranchAndSourceCurSettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<TLMDTO00058> SelectDayBookCurrentHomeReversal(string workStation, string sourceCur, DateTime requireDate,string acsign,bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrent_Home_Reversal");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrent_Home_Reversal_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookCurrentHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate,string acsign,bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrent_Home_Reversal");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrent_Home_Reversal_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        //Added by HWKO (14-Aug-2017)
        public IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversal(string workStation, string sourceCur, DateTime requireDate,string acsign,bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrentALL_Home_Reversal");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrentALL_Home_Reversal_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }

            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrentALL_Home_ReversalBySettlementDate");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00D53.SelectDayBookCurrentALL_Home_ReversalBySettlementDate_SortByAccountNo");
                    query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }
        //Endregion

        public IList<TLMDTO00058> SelectDayFixedReversal(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00D54.SelectDayBookFixed_Reversal");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayBookDomesticHomeReversal(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00055.SelectDayBookDomesticHomeReversal");
                    //query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00055.SelectDayBookDomesticHomeReversal_SortByAccountNo");
                    //query.SetString("acsign", acsign + "%");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }catch (Exception ex)
            { return null; }
        }

        public IList<PFMDTO00042> GetScrollData_LC(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval)
        {
            IQuery query;
            if (isReserval)
            {
                //select from VW_BANKING_CLEARING_LC
                query = this.Session.GetNamedQuery((isTransactionDate) ? "Banking_Clearing_LC.TransactionDate" : "Banking_Clearing_LC.SettlementDate");
            }
            else
            {
                //select from VW_BANKING_CLEARING_LC_WITHOUT_REVERSAL
                query = this.Session.GetNamedQuery((isTransactionDate) ? "Banking_Clearing_LC_WithReversal.TransactionDate" : "Banking_Clearing_LC_WithReversal.SettlementDate");
            }
            query.SetString("workstation", workstation);
            query.SetString("selecteddatetime", date_time.ToString("yyyy/MM/dd"));
            query.SetString("selectedCurrency", currnecy);
            string querys = this.GetSQLString(query.QueryString);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> GetScrollData_LD(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval)
        {
            IQuery query;
            if (isReserval)
            {
                //select from VW_BANKING_CLEARING_LD
                query = this.Session.GetNamedQuery((isTransactionDate) ? "BANKING_CLEARING_LD.TransactionDate" : "BANKING_CLEARING_LD.SettlementDate");
            }
            else
            {
                //select  from VW_BANKING_CLEARING_LD_WITHOUT_REVERSAL
                query = this.Session.GetNamedQuery((isTransactionDate) ? "BANKING_CLEARING_LD_WithReversal.TransactionDate" : "BANKING_CLEARING_LD_Reversal.SettlementDate");
            }
            query.SetString("workstation", workstation);
            query.SetString("selecteddatetime", date_time.ToString("yyyy/MM/dd"));
            query.SetString("selectedCurrency", currnecy);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetCleanCashData(string workStation, DateTime datetime, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00026.SelectCleanCash");
            query.SetString("workStation", workStation);
            query.SetDateTime("datetime", datetime);
            query.SetString("currency", currency);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetCleanCashByHomeCurrencyData(string workStation, DateTime datetime, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00026.SelectCleanCashByHomeCurrency");
            query.SetString("workStation", workStation);
            query.SetDateTime("datetime", datetime);
            query.SetString("currency", currency);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> GetCleanCashWithoutReversalData(string workStation, DateTime datetime, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00026.SelectCleanCashWithoutReversal");
            query.SetString("workStation", workStation);
            query.SetDateTime("datetime", datetime);
            query.SetString("currency", currency);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }


        public IList<PFMDTO00042> GetCleanCashWithoutReversalByHomeCurrencyData(string workStation, DateTime datetime, string currency)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00026.SelectCleanCashWithoutReversalByHomeCurrency");
            query.SetString("workStation", workStation);
            query.SetDateTime("datetime", datetime);
            query.SetString("currency", currency);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00017> GetAllCustomerLists()
        {
            IQuery query = this.Session.GetNamedQuery("TCMVEW00032.SelectCustomer");
            return query.List<PFMDTO00017>();
        }

        public IList<MNMDTO00010> SelectSumCCOAAmount(string cur, string acode, string budget, string dcode)
        {
            IQuery query = this.Session.GetNamedQuery("SelectByBudgetMonth");
            query.SetString("cur", cur);
            query.SetString("acode", acode);
            query.SetString("budget", budget);
            query.SetString("dcode", dcode);
            return query.List<MNMDTO00010>();
        }

        public IList<MNMDTO00023> SelectAll(DateTime startdate, DateTime enddate, string branchCode, string workstation)
        {
            IQuery query = this.Session.GetNamedQuery("VW_SelectAll");
            query.SetDateTime("startdate", startdate);
            query.SetDateTime("enddate", enddate);
            query.SetString("sourceBr", branchCode);
            query.SetString("workStation", workstation);
            return query.List<MNMDTO00023>();

        }
        public UserDTO SelectUserIdbyUsername(string username)
        {
            IQuery query = this.Session.GetNamedQuery("UserDAO.SelectByUsersName");
            query.SetString("username", username);
            UserDTO userdto = query.UniqueResult<UserDTO>();
            return userdto;
        }

        public UserDTO SelectUserNamebyUserId(int userid)
        {
            IQuery query = this.Session.GetNamedQuery("UserDAO.SelectByUsersId");
            query.SetInt32("id", userid);
            return query.UniqueResult<UserDTO>();
        }

        public UserDTO SelectUserNamebyUserIdForUserNoReport(string username)
        {
            IQuery query = this.Session.GetNamedQuery("UserDAO.SelectByUsersIdForUserNoReport");
            query.SetString("username", username);
            return query.UniqueResult<UserDTO>();
        }

        public UserDTO SelectUserInfobyUseNameForUserNoReport(string username,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("UserDAO.SelectByUserNameForUserNoReport");
            query.SetString("username", username);
            query.SetString("branchcode", sourcebr);
            return query.UniqueResult<UserDTO>();
        }


        public IList<PFMDTO00042> SelectWithdrawListingByGrade(DateTime startDate, DateTime endDate, decimal minimumAmount,
             decimal maximumAmount, string acSign, string sourceBr, int workstation)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00063.SelecWithdrawListingByGrade");
                query.SetDateTime("startDate", startDate);
                query.SetDateTime("endDate", endDate);
                query.SetString("acSign", acSign + "%");
                query.SetString("sourceBr", sourceBr);
                query.SetInt32("workstation", workstation);
                IList<PFMDTO00042> reportTLFList = query.List<PFMDTO00042>();

                if (reportTLFList != null)
                {
                    var qq = (from value in reportTLFList
                              where value.Amount >= minimumAmount && value.Amount <= maximumAmount
                              select value).ToList();
                    reportTLFList = qq;
                }
                return reportTLFList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Jan 07
        public PFMDTO00042 SelectCrTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectTCCTranDateWithReversalByForAllBranchAndSourceCur");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("cc", "CC%");
            //query.SetString("cd", "CD%");
            string sqlquerystring = this.GetSQLString(query.QueryString);
            PFMDTO00042 rtlfDTO = query.UniqueResult<PFMDTO00042>();
            return rtlfDTO;
        }
        //TLMCTL00015.SelectAccountName From COA
        public string SelectAccountNamefromCOA(string acode, string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO0009.SelectAccountName");
            query.SetString("acode", acode);
            query.SetString("sourceBranchCode", sourcebranchcode);
            string AcName = query.SetFirstResult(0).SetMaxResults(1).UniqueResult<ChargeOfAccountDTO>().ACName;
            return AcName;
        }
        public PFMDTO00042 SelectDrTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectTCDTranDateWithReversalByForAllBranchAndSourceCur");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", bankCashDTO.WorkStation);
            query.SetString("currency", bankCashDTO.CurCode);
            //query.SetString("cc", "CC%");
            query.SetString("cd", "CD%");
            string sqlquerystring = this.GetSQLString(query.QueryString);
            PFMDTO00042 rtlfDTO = query.UniqueResult<PFMDTO00042>();
            return rtlfDTO;
        }
        #endregion


        public IList<TLMDTO00058> SelectDayBookSavingsBySettlementDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00A54.SelectDayBookSavingsBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }


        public IList<TLMDTO00058> SelectDayBookSavingsReversalBySettlemtntDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("SelectDayBookSavings_ReversalBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }


        public IList<TLMDTO00058> SelectDayFixedBySettlementDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00C54.SelectDayBookFixedBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }

        public IList<TLMDTO00058> SelectDayFixedReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate)
        {
            IQuery query = this.Session.GetNamedQuery("SelectDayBookFixed_ReversalBySettlementDate");
            query.SetString("workStation", workStation);
            query.SetString("sourceCur", sourceCur);
            query.SetDateTime("requireDate", requireDate);

            IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
            return dayBookDTO;
        }


        public IList<TLMDTO00058> SelectDayBookDomesticBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
           
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticBySettlementDate");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticBySettlementDate_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookDomesticReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticReversalBySettlementDate");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00A55.SelectDayBookDomesticReversalBySettlementDate_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookDomesticHomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookDomesticHomeBySettlementDate");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00C53.SelectDayBookDomesticHomeBySettlementDate_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TLMDTO00058> SelectDayBookDomesticHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName)
        {
            
            try
            {
                if (sortByName == true)
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00055.SelectDayBookDomesticHomeReversalBySettlementDate");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
                else
                {
                    IQuery query = this.Session.GetNamedQuery("TLMDAO00055.SelectDayBookDomesticHomeReversalBySettlementDate_SortByAccountNo");
                    query.SetString("workStation", workStation);
                    query.SetString("sourceCur", sourceCur);
                    query.SetDateTime("requireDate", requireDate);

                    IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
                    return dayBookDTO;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        #region //Sub_Ledger(Domestic) Report
        public IList<MNMDTO00010> GetHOBaLAndCBalForSubLedger_Domestic(string acode, string budYear, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetHOBaLAndCBalForSubLedger_ByBudgetMonth");
            query.SetString("acode", acode);
            //query.SetString("acodefilter", strSQLFilter + "%000");
            query.SetString("budget", budYear);
            query.SetString("dcode", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            return query.List<MNMDTO00010>();
        }
        public IList<MNMDTO00010> GetHOBaLAndCBalForSubLedger_DomesticByCur(string currency, string acode, string budYear, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetHOBaLAndCBalForSubLedger_ByBudgetMonthAndCur");
            query.SetString("cur", currency);
            query.SetString("acode", acode + "%");
            //query.SetString("acodefilter", strSQLFilter + "%000");
            query.SetString("budget", budYear);
            query.SetString("dcode", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            return query.List<MNMDTO00010>();
        }
        public IList<MNMDTO00054> SelectLedgerListingByDateTime(string date1, string date2, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListingByDateTime");
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> SelectLedgerListingBySettlementDate(string date1, string date2, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListingBySettlementDate");
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        public IList<MNMDTO00054> SelectLedgerListingByDateTimeAndCurrency(string date1, string date2, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListingByDateTimeAndCurrency");
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> SelectLedgerListingBySettlementDateAndCurrency(string date1, string date2, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListingBySettlementDateAndCurrency");
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        //call from MNMSVE00054
        public IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndDateTime(string acode, string date1, string date2, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListing_ByACtypeAndDateTime");
            query.SetString("acode", acode);
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndSettlementDate(string acode, string date1, string date2, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListing_ByACtypeAndSettlementDate");
            query.SetString("acode", acode);
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndDateTimeAndCur(string acode, string date1, string date2, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListing_ByACtypeAndDateTimeAndCur");
            query.SetString("acode", acode);
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndSettlementDateAndCur(string acode, string date1, string date2, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLedgerListing_ByACtypeAndSettlementDateAndCur");
            query.SetString("acode", acode);
            query.SetString("date1", date1);
            query.SetString("date2", date2);
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        //With HomeCurrency and TransactionDate
        public IList<MNMDTO00054> GetLedgerListingRptByTDate(DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptByTDate");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebr);
            query.SetString("workstation", workstation);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptByTDate1(DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptByTDate1");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptByTDate2(string acode, DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptByTDate2");
            query.SetString("acode", acode);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        //With HomeCurrency and SettlementDate
        public IList<MNMDTO00054> GetLedgerListingRptBySDate(DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySDate");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySDate1(DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySDate1");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySDate2(string acode, DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySDate2");
            query.SetString("acode", acode);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        //With SourceCur and TransactionDate
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndTdate");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate1(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndTdate1");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate2(string acode, DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndTdate2");
            query.SetString("acode", acode);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }

        //With SourceCur and SettlementDate
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndSdate");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate1(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndSdate1");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            return query.List<MNMDTO00054>();
        }
        public IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate2(string acode, DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("GetLedgerListingRptBySourceCurAndSdate2");
            query.SetString("acode", acode);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcecur", sourcecur);
            query.SetString("sourcebr", sourcebr);
            query.SetString("workstation", workstation);
            return query.List<MNMDTO00054>();
        }
        #endregion

        //By SourceCur and Branch
        public IList<MNMDTO00010> SelectTrialBalanceDetailBySource(string month, string dcode, string cur)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetaildto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "M" + month.ToString() + ") from MNMVIW00002 as t where t.DCODE =: dcode and t.CUR =: cur and t.Active = true ");
            query.SetString("dcode", dcode);
            query.SetString("cur", cur);
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //By SourceCur (By Home)
        public IList<MNMDTO00010> SelectTrialBalanceDetailBySourceHome(string month, string cur, string dcode)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetaildto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "MSRC" + month.ToString() + ") from MNMVIW00002 as t where t.DCODE =: dcode and t.CUR =: cur and t.Active = true");
            query.SetString("cur", cur);
            query.SetString("dcode", dcode);
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //By SourceCur and AllBranch
        public IList<MNMDTO00010> SelectTrialBalanceDetailBySourceAllBranch(string month, string cur)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetaildto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "M" + month.ToString() + ") from MNMVIW00002 as t where t.DCODE = '' and t.CUR =: cur and t.Active = true");
            query.SetString("cur", cur);
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //By SourceCur and AllBranch (By Home)
        public IList<MNMDTO00010> SelectTrialBalanceDetailBySourceAllBranchHome(string month, string cur)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetaildto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "MSRC" + month.ToString() + ") from MNMVIW00002 as t where t.CUR =: cur and t.Active = true");
            query.SetString("cur", cur);
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //By HomeCur and Branch
        public IList<MNMDTO00010> SelectTrialBalanceDetailByHome(string month, string dcode)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetailHomedto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "MSRC" + month.ToString() + ") from MNMVIW00003 as t where t.DCODE =: dcode");
            query.SetString("dcode", dcode);
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //By HomeCur and AllBranch
        public IList<MNMDTO00010> SelectTrialBalanceDetailByHomeAllBranch(string month)
        {
            IQuery query = this.Session.CreateQuery("Select new trialDetailHomedto(t.ACODE,t.ACNAME,t.ACTYPE,t." + "MSRC" + month.ToString() + ") from MNMVIW00003 as t where t.DCODE ='' ");
            IList<MNMDTO00010> list = query.List<MNMDTO00010>();
            return list;
        }

        //Added by HWKO (03-Sep-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTriDetailForBackDate(string currency, string branchCode, DateTime selectedDate, string stropeningfield)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_DETAILTRIALREPORT_BACKDATE");
                query.SetString("cur", currency);
                query.SetString("sourceBr", branchCode);
                query.SetDateTime("selectedDate", selectedDate);
                query.SetString("STROPENINGFIELD", stropeningfield);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IList<MNMDTO00034> SelectInterest(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00009.SelectInterest");
            query.SetString("sourceBr", sourceBr);
            IList<MNMDTO00034> interestList = query.List<MNMDTO00034>();
            return interestList;
        }

        //Current Closed Account
        public IList<MNMDTO00037> SelectCurrentClosedAccountByDate(DateTime startDate, DateTime endDate, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00015.CurrentSelectByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<MNMDTO00037> currentAccountList = query.List<MNMDTO00037>();
            return currentAccountList;
        }

        //Saving Closed Account
        public IList<MNMDTO00037> SelectSavingClosedAccountByDate(DateTime startDate, DateTime endDate, string branch)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00022.SavingSelectByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("branch", branch);
            IList<MNMDTO00037> savingAccountList = query.List<MNMDTO00037>();
            return savingAccountList;
        }

        public DateTime SelectDateTime()
        {
            IQuery query = this.Session.GetNamedQuery("CurrentDate");
            var date = query.UniqueResult<DateTime>();

            return date;
        }

        //CustomerID Select By Date
        public IList<MNMDTO00039> SelectCustIDByDate(DateTime startDate, DateTime endDate, string branch) //, string currency //Commented by HWKO (25-Aug-2017)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00023.SelectByDate");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranch", branch);
            //query.SetString("currency", currency); //Commented by HWKO (25-Aug-2017)
            IList<MNMDTO00039> custIDByDateList = query.List<MNMDTO00039>();
            return custIDByDateList;
        }

        //CustomerID Select By Township
        public IList<MNMDTO00039> SelectCustIDByTownship(DateTime startDate, DateTime endDate, string branch, string township)//, string currency //Commented by HWKO (25-Aug-2017)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00023.SelectByTownship");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranch", branch);
            //query.SetString("currency", currency); //Commented by HWKO (25-Aug-2017)
            query.SetString("township", township);
            IList<MNMDTO00039> custIDByDateList = query.List<MNMDTO00039>();
            return custIDByDateList;
        }

        public IList<MNMDTO00040> SelectLedgerBalanceByGradeCurrent(decimal startAmount, decimal endAmount, string currency, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00025.SelectByGradeCurrentbyCurrency");
            query.SetDecimal("startAmount", startAmount);
            query.SetDecimal("endAmount", endAmount);
            query.SetString("currency", currency);
            query.SetString("branch", sourcebr);
            IList<MNMDTO00040> ledgerBalanceList = query.List<MNMDTO00040>();
            return ledgerBalanceList;
        }

        public IList<MNMDTO00040> SelectLedgerBalanceByGradeCurrentAllCurrency(decimal startAmount, decimal endAmount, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00025.SelectByGradeCurrentbyAllCurrency");
            query.SetDecimal("startAmount", startAmount);
            query.SetDecimal("endAmount", endAmount);
            query.SetString("branch", sourcebr);
            IList<MNMDTO00040> ledgerBalanceList = query.List<MNMDTO00040>();
            return ledgerBalanceList;
        }

        public IList<MNMDTO00040> SelectLedgerBalanceByGradeSaving(decimal startAmount, decimal endAmount, string currency, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00028.SelectByGradeSavingbyCurrency");
            query.SetDecimal("startAmount", startAmount);
            query.SetDecimal("endAmount", endAmount);
            query.SetString("currency", currency);
            query.SetString("branch", sourcebr);
            IList<MNMDTO00040> ledgerBalanceList = query.List<MNMDTO00040>();
            return ledgerBalanceList;
        }

        public IList<MNMDTO00040> SelectLedgerBalanceByGradeSavingAllCurrency(decimal startAmount, decimal endAmount, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00028.SelectByGradeSavingbyAllCurrency");
            query.SetDecimal("startAmount", startAmount);
            query.SetDecimal("endAmount", endAmount);
            query.SetString("branch", sourcebr);
            IList<MNMDTO00040> ledgerBalanceList = query.List<MNMDTO00040>();
            return ledgerBalanceList;
        }

        #region LedgerBalance Report

        public IList<MNMDTO00035> SelectLedgerBalanceAllByCurrency(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00010.SelectLedgerBalanceAllByCurrency");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByAcsignAndCurrency(string sourceBr, string acSign, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00010.SelectLedgerBalanceByCurrencyAndAcsign");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            query.SetString("acSign", acSign + "%");
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByFixedAccount(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00012.SelectFixed");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceAllByAllCurrency(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00010.SelectLedgerBalanceAllByAllCurrency");
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByAcsignAndAllCurrency(string sourceBr, string acSign)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00010.SelectLedgerBalanceByAllCurrencyAndAcsign");
            query.SetString("sourceBr", sourceBr);
            query.SetString("acSign", acSign + "%");
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByFixedAccountAndAllCurrency(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00012.SelectFixedByAllCurrency");
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByOverdraftAndCurrency(string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00034.SelectAllByCurrency");
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            return query.List<MNMDTO00035>();
        }

        public IList<MNMDTO00035> SelectLedgerBalanceByOverdraftAndAllCurrency(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00034.SelectAllByAllCurrency");
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00035>();
        }
        #endregion

        #region transfer scroll Report
        public IList<MNMDTO00033> SelectTRScrollHomeCurAllBrTdate(string workstation, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollHomeCurAllBrTdate");
            query.SetString("workstation", workstation);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRScrollSourceBrHomeCurTdate(string workstation, string sourcebr, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollSourceBrHomeCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRScrollHomeCurAllBrSdate(string workstation, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollHomeCurAllBrSdate");
            query.SetString("workstation", workstation);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRScrollSourceBrHomeCurSdate(string workstation, string sourcebr, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollSourceBrHomeCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }
        public IList<MNMDTO00033> SelectTRScrollAllBrSourceCurTdate(string workstation, string sourcecur, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollAllBrSourceCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }


        public IList<MNMDTO00033> SelectTRScrollSourceBrSourceCurTdate(string workstation, string sourcebr, string sourcecur, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollSourceBrSourceCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRScrollAllBrSourceCurSdate(string workstation, string sourcecur, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollAllBrSourceCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRScrollSourceBrSourceCurSdate(string workstation, string sourcebr, string sourcecur, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRScrollSourceBrSourceCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRWithoutReversalHomeCurAllBrTdate(string workstation, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalHomeCurAllBrTdate");
            query.SetString("workstation", workstation);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRWithoutReversalSourceBrHomeCurTdate(string workstation, string sourcebr, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalSourceBrHomeCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRWithoutReversalHomeCurAllBrSdate(string workstation, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalHomeCurAllBrSdate");
            query.SetString("workstation", workstation);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRWithoutReversalSourceBrHomeCurSdate(string workstation, string sourcebr, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalSourceBrHomeCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;
        }

        public IList<MNMDTO00033> SelectTRWithoutReversalAllBrSourceCurTdate(string workstation, string sourcecur, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalAllBrSourceCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;

        }

        public IList<MNMDTO00033> SelectTRWithoutReversalSourceBrSourceCurTdate(string workstation, string sourcebr, string sourcecur, DateTime TDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalSourceBrSourceCurTdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("TDatetime", TDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;

        }

        public IList<MNMDTO00033> SelectTRWithoutReversalAllBrSourceCurSdate(string workstation, string sourcecur, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalAllBrSourceCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;

        }


        public IList<MNMDTO00033> SelectTRWithoutReversalSourceBrSourceCurSdate(string workstation, string sourcebr, string sourcecur, DateTime SDatetime)
        {
            IQuery query = this.Session.GetNamedQuery("VW_TRWithoutReversalSourceBrSourceCurSdate");
            query.SetString("workstation", workstation);
            query.SetString("sourcebr", sourcebr);
            query.SetString("sourcecur", sourcecur);
            query.SetDateTime("SDatetime", SDatetime);
            IList<MNMDTO00033> TRScrollList = query.List<MNMDTO00033>();
            return TRScrollList;

        }

        #endregion


        #region transfer scroll Report

        public IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches(string workstation, DateTime datetime)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_homedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00078 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111) order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches(string workstation, string cur, DateTime datetime)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transferdto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00077 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch(string workstation, DateTime datetime,string sourcebr)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_homedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00078 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111) and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch(string workstation, string cur, DateTime datetime,string sourcebr)  //VW_TRANSFERSCROLL
        {
            IQuery query = this.Session.CreateQuery("Select new transferdto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00077 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur  and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_BySDate(string workstation, DateTime datetime)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_homedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00078 as t where t.WORKSTATION =: workstation And convert(char(10),t.SETTLEMENTDATE,111) = convert(char(10), :datetime , 111) order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_BySDate(string workstation, string cur, DateTime datetime)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transferdto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00077 as t where t.WORKSTATION =: workstation And convert(char(10),t.SETTLEMENTDATE,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_BySDate(string workstation, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_homedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00078 as t where t.WORKSTATION =: workstation And convert(char(10),t.SETTLEMENTDATE,111) = convert(char(10), :datetime , 111) and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_BySDate(string workstation, string cur, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transferdto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00077 as t where t.WORKSTATION =: workstation And  convert(char(10),t.SETTLEMENTDATE,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur  and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        //////////////////////

        public IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_withoutReverse(string workstation, DateTime datetime)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_home_reversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00080 as t where t.WORKSTATION =: workstation And convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111) order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_withoutReverse(string workstation, string cur, DateTime datetime)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL
        {
            IQuery query = this.Session.CreateQuery("Select new transferreversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00079 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_withoutReverse(string workstation, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_home_reversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00080 as t where t.WORKSTATION =: workstation And  convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111) and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_withoutReverse(string workstation, string cur, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL
        {
            IQuery query = this.Session.CreateQuery("Select new transferreversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00079 as t where t.WORKSTATION =: workstation And convert(char(10),t.DATE_TIME,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur  and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_BySDate_withoutReverse(string workstation, DateTime datetime)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_home_reversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00080 as t where t.WORKSTATION =: workstation And  convert(char(10),t.SETTLEMENTDATE ,111) = convert(char(10), :datetime , 111) order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_BySDate_withoutReverse(string workstation, string cur, DateTime datetime)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL
        {
            IQuery query = this.Session.CreateQuery("Select new transferreversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00079 as t where t.WORKSTATION =: workstation And convert(char(10),t.SETTLEMENTDATE ,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_BySDate_withoutReverse(string workstation, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL_Home
        {
            IQuery query = this.Session.CreateQuery("Select new transfer_home_reversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00080 as t where t.WORKSTATION =: workstation And convert(char(10),t.SETTLEMENTDATE ,111) = convert(char(10), :datetime , 111) and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        public IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_BySDate_withoutReverse(string workstation, string cur, DateTime datetime, string sourcebr)  //VW_TRANSFERSCROLL_WITHOUT_REVERSAL
        {
            IQuery query = this.Session.CreateQuery("Select new transferreversedto (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,t.SOURCEBR,t.SETTLEMENTDATE) from MNMVIW00079 as t where t.WORKSTATION =: workstation And  convert(char(10),t.SETTLEMENTDATE ,111) = convert(char(10), :datetime , 111)  and t.SOURCECUR =: sourceCur  and t.SOURCEBR =:sourcebr order by t.DATE_TIME");
            query.SetString("workstation", workstation);
            query.SetDateTime("datetime", datetime);
            query.SetString("sourceCur", cur);
            query.SetString("sourcebr", sourcebr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00033> transferSrollDataList = query.List<MNMDTO00033>();
            return transferSrollDataList;
        }

        #endregion


        //public IList<PFMDTO00029> SelectLinkACAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<PFMDTO00029> SelectLinkACExcess()
        //{
        //    throw new NotImplementedException();
        //}

        //public PFMDTO00001 SelectCaofInfoByAcctno(string acctno)
        //{
        //    throw new NotImplementedException();
        //}

        //public PFMDTO00001 SelectSaofInfoByAcctno(string acctno)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<PFMDTO00042> SelectTrialSheetWithoutReversal(string cur, string workstation, string sourceBr)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<PFMDTO00042> SelectTrialSheetWithReversal(string cur, string workstation, string sourceBr)
        //{
        //    throw new NotImplementedException();
        //}

        #region TrialSheet
        public IList<PFMDTO00042> SelectTrialSheetWithoutReversal(string cur, string workstation, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00016.SelectTrialSheetWithoutReversal");
            query.SetString("cur", cur);
            query.SetString("workstation", workstation);
            query.SetString("sourceBr", sourceBr);
            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> SelectTrialSheetWithReversal(string cur, string workstation, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00016.SelectTrialSheetWithReversal");
            query.SetString("cur", cur);
            query.SetString("workstation", workstation);
            query.SetString("sourceBr", sourceBr);
            return query.List<PFMDTO00042>();
        }
        #endregion

        #region Monthly Bank Statement
        public IList<PFMDTO00001> SelectCurrentAC_AllByMonth(string month, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00018.SelectCustomerCurrentAC_AllByMonth");
            query.SetString("month", month);
            query.SetString("SourceBr", sourceBr);

            IList<PFMDTO00001> customerInfo = query.List<PFMDTO00001>();
            return customerInfo;
        }

        public IList<PFMDTO00001> SelectSavingAC_AllByMonth(string month, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00020.SelectCustomerSavingAC_AllByMonth");
            query.SetString("month", month);
            query.SetString("SourceBr", sourceBr);

            IList<PFMDTO00001> customerInfo = query.List<PFMDTO00001>();
            return customerInfo;
        }

        #endregion

        #region Sub_Ledger(Customer)
        public IList<PFMDTO00001> SelectCurrentAC_All(string sourceBr)  //VW_BANKSTATEMENT_CAOF
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00018.SelectCustomerCurrentAC_All");
            query.SetString("SourceBr", sourceBr);
            IList<PFMDTO00001> customerInfo = query.List<PFMDTO00001>();
            return customerInfo;
        }

        public IList<PFMDTO00001> SelectSavingAC_All(string sourceBr)  //VW_BANKSTATEMENT_SAOF
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00020.SelectCustomerSavingAC_All");
            query.SetString("SourceBr", sourceBr);
            IList<PFMDTO00001> customerInfo = query.List<PFMDTO00001>();
            return customerInfo;
        }

        public IList<PFMDTO00001> SelectBankStatementAll_ByAcctNo(string acctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr) //VW_BANKSTATEMENT_ALL
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00019.SelectBankStatementAll");
            //query.SetInt32("Workstation", workStation);
            query.SetString("AcctNo", acctNo);
            query.SetDateTime("StartPeriod", startPeriod);
            query.SetDateTime("EndPeriod", endPeriod);
            query.SetString("SourceBr", sourceBr);
            IList<PFMDTO00001> BankStatementList = query.List<PFMDTO00001>();
            return BankStatementList;
        }

        public PFMDTO00033 SelectBalance_ByAcctNoAndBudYear(string month, string acctNo, string Budget, string SourceBr)  //VW_BANK
        {
            IQuery query = this.Session.CreateQuery("Select new baldto(t.M" + month.ToString() + ") from TLMVIW00009 as t where t.AccountNo =: acctNo And t.Budget =: Budget  and t.SourceBr =: SourceBr and t.Active = true");
            query.SetString("acctNo", acctNo);
            query.SetString("SourceBr", SourceBr);
            query.SetString("Budget", Budget);
            string sqlQuery = this.GetSQLString(query.QueryString);
            PFMDTO00033 Balance = query.UniqueResult<PFMDTO00033>();
            return Balance;
        }

        public IList<PFMDTO00042> BankSatatementByWithdrawAmount(string workstation, string accountNo, int year, int month) //nnl
        {
            IQuery query = this.Session.CreateQuery("select new bankstatementdto(b.AccountNo, b.DateTime, b.Description, b.WithdrawAmount, b.DepositAmount, b.Cheque)from TLMVIW000A9 as b where b.WorkStation= :workstation and b.AccountNo= :accountNo and year(b.DateTime) = :year and Month(DateTime) = :month and b.WithdrawAmount <> 0");
            query.SetString("workstation", workstation);
            query.SetString("accountNo", accountNo);
            query.SetInt32("year", year);
            query.SetInt32("month", month);

            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> BankSatatementByDepositAmount(string workstation, string accountNo, int year, int month) //nnl
        {
            IQuery query = this.Session.CreateQuery("select new bankstatementdto(b.AccountNo, b.DateTime, b.Description, b.WithdrawAmount, b.DepositAmount, b.Cheque)from TLMVIW000A9 as b where b.WorkStation= :workstation and b.AccountNo= :accountNo and year(b.DateTime) = :year and Month(DateTime) = :month and b.DepositAmount <> 0");
            query.SetString("workstation", workstation);
            query.SetString("accountNo", accountNo);
            query.SetInt32("year", year);
            query.SetInt32("month", month);

            return query.List<PFMDTO00042>();
        }

        public IList<PFMDTO00042> BankSatatementByAllWithdrawDeposit(string workstation, string accountNo, int year, int month) //nnl
        {
            IQuery query = this.Session.CreateQuery("select new bankstatementdto(b.AccountNo, b.DateTime, b.Description, b.WithdrawAmount, b.DepositAmount, b.Cheque)from TLMVIW000A9 as b where b.WorkStation= :workstation and b.AccountNo= :accountNo and year(b.DateTime) = :year and Month(DateTime) = :month order by b.DateTime");
            query.SetString("workstation", workstation);
            query.SetString("accountNo", accountNo);
            query.SetInt32("year", year);
            query.SetInt32("month", month);

            return query.List<PFMDTO00042>();
        }

        public PFMDTO00033 VW_BAL_SelectMonth(string month, string accountNo, string budget) //nnl
        {
            IQuery query = this.Session.CreateQuery("select new baldto(" + month + ")from TLMVIW00009 as v where v.AccountNo = :accountNo and v.Budget = :budget and v.Active = true");
            query.SetString("accountNo", accountNo);
            query.SetString("budget", budget);

            return query.UniqueResult<PFMDTO00033>();
        }

        public IList<PFMDTO00042> SelectBankStatement_ByAcctNo(string acctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr) //VW_BANK_STATEMENT
        {
            IQuery query = this.Session.GetNamedQuery("TLMVIW00A10.SelectBankStatement");
            // query.SetInt32("Workstation", workStation);
            query.SetString("AcctNo", acctNo);
            query.SetDateTime("StartPeriod", startPeriod);
            query.SetDateTime("EndPeriod", endPeriod);
            query.SetString("SourceBr", sourceBr);
            IList<PFMDTO00042> BankStatementList = query.List<PFMDTO00042>();
            return BankStatementList;
        }
        #endregion

        #region CustomerCurrentA/C

        public IList<PFMDTO00017> SelectCurrentAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00026.SelectCurrentAccountAll");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign + "%");
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> CurrentAccountList = query.List<PFMDTO00017>();
            return CurrentAccountList;
        }

        public IList<PFMDTO00017> SelectCurrentAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00026.SelectCurrentAccountSpecific");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> CurrentAccountList = query.List<PFMDTO00017>();
            return CurrentAccountList;
        }

        #endregion

        #region Business Loan A/C // Added By HWKO (23-Jun-2017)
        // BLHPP means Business Loan + Hire Purchase + Personal
        // Can use the same select query because they have only different ACSign.
        public IList<PFMDTO00017> SelectBLHPPAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00026.SelectCurrentAccountAll");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign + "%");
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> CurrentAccountList = query.List<PFMDTO00017>();
            return CurrentAccountList;
        }

        public IList<PFMDTO00017> SelectBLHPPAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00026.SelectCurrentAccountSpecific");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> CurrentAccountList = query.List<PFMDTO00017>();
            return CurrentAccountList;
        }

        #endregion

        #region CustomerSavingA/C
        public IList<PFMDTO00017> SelectSavingAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00029.SelectSavingAccountAll");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign + "%");
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> SavingAccountList = query.List<PFMDTO00017>();
            return SavingAccountList;
        }
        public IList<PFMDTO00017> SelectSavingAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00029.SelectSavingAccountSpecific");
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("acSign", acSign);
            query.SetString("sourceBr", sourceBr);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<PFMDTO00017> SavingAccountList = query.List<PFMDTO00017>();
            return SavingAccountList;
        }
        #endregion

        #region Clearing Reversal Listing

        public IList<PFMDTO00042> SelectClearingDeliveredReversalListingReports(DateTime startDate, DateTime endDate, string workStation, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TCMVIW00011.VW_MOB18_ALL");
            query.SetString("startdate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("trancode", "RCLDELI");
            query.SetString("status", "LDR");
            query.SetString("workstation", workStation);
            query.SetString("sourcebr", sourcebr);
            IList<PFMDTO00042> ReportDTOList = query.List<PFMDTO00042>();
            return ReportDTOList;
        }

        public IList<PFMDTO00042> SelectClearingReceiptReversalListingReports(DateTime startDate, DateTime endDate, string workStation)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00030.VW_MOB19RL_All");
            query.SetString("startdate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("status", "LCD");
            query.SetString("workstation", workStation);
            IList<PFMDTO00042> ReportDTOList = query.List<PFMDTO00042>();
            return ReportDTOList;
        }

        public IList<MNMDTO00040> SelectNameByAccountNo(string acctno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectCustomerNameByAccountNo");
            query.SetString("acctno", acctno);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<MNMDTO00040> name = query.List<MNMDTO00040>();
            return name;
        }
        #endregion

        #region DailyDrawingAndEncashRemittanceListing(By Branch)

        public IList<TLMDTO00001> SelectDailyEncashRemittanceListing_ByTransactionDate(DateTime date, string eBank, string sourceBr)  //VW_MOB836
        {
            IQuery query = this.Session.GetNamedQuery("TLMVIW00C16.DailyEncashRemittanceListing_ByTransactionDate");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("eBank", eBank);
            query.SetString("SourceBr", sourceBr);
            IList<TLMDTO00001> EncashRemittanceListing = query.List<TLMDTO00001>();
            return EncashRemittanceListing;
        }

        public IList<TLMDTO00001> SelectDailyEncashRemittanceListing_BySettlementDate(DateTime date, string eBank, string sourceBr)  //VW_MOB836
        {
            IQuery query = this.Session.GetNamedQuery("TLMVIW00C16.DailyEncashRemittanceListing_BySettlementDate");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("eBank", eBank);
            query.SetString("SourceBr", sourceBr);
            IList<TLMDTO00001> EncashRemittanceListing = query.List<TLMDTO00001>();
            return EncashRemittanceListing;
        }

        public IList<TLMDTO00017> SelectDailyDrawingRemittanceListing_ByTransactionDate(DateTime date, string dBank, string sourceBr)  //VW_MOB831
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00031.DailyDrawingRemittanceListing_ByReceiptDate");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("dBank", dBank);
            query.SetString("SourceBr", sourceBr);
            IList<TLMDTO00017> DrawingRemittanceListing = query.List<TLMDTO00017>();
            return DrawingRemittanceListing;
        }

        public IList<TLMDTO00017> SelectDailyDrawingRemittanceListing_BySettlementDate(DateTime date, string dBank, string sourceBr)  //VW_MOB831
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00031.DailyDrawingRemittanceListing_BySettlementDate");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("dBank", dBank);
            query.SetString("SourceBr", sourceBr);
            IList<TLMDTO00017> DrawingRemittanceListing = query.List<TLMDTO00017>();
            return DrawingRemittanceListing;
        }

        #endregion

        public IList<MNMDTO00039> GetFAOFCustomerInfo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00032.FAOFCustomerInfo");
            query.SetString("accountNo", accountNo);
            return query.List<MNMDTO00039>();

        }

        #region PO And IR Listing
        //By ASDA

        public IList<PFMDTO00042> SelectPOAndIR_RegisterAndWithdrawalListing(DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate, string sourceBr)
        {
            IQuery query = null;
            if (IsTransactionDate)
            {
                switch (formName)
                {
                    case "Payment Order Register Listing By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterByCash_WithTransactionDate");
                        break;

                    case "Payment Order Register Listing By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterByTransfer_WithTransactionDate");
                        break;

                    case "Payment Order Register Listing All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterAll_WithTransactionDate");
                        break;

                    case "Payment Order Withdrawal By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalByCash_WithTransactionDate");
                        break;

                    case "Payment Order Withdrawal By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalByTransfer_WithTransactionDate");
                        break;

                    case "Payment Order Withdrawal All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalAll_WithTransactionDate");
                        break;

                    case "Internal Remittance Register":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRRegister_WithTransactionDate");
                        break;

                    case "Internal Remittance Withdrawal By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalByCash_WithTransactionDate");
                        break;

                    case "Internal Remittance Withdrawal By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalByTransfer_WithTransactionDate");
                        break;

                    case "Internal Remittance Withdrawal All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalAll_WithTransactionDate");
                        break;
                }
            }
            else
            {
                switch (formName)
                {
                    case "Payment Order Register Listing By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterByCash_WithSettlementDate");
                        break;

                    case "Payment Order Register Listing By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterByTransfer_WithSettlementDate");
                        break;

                    case "Payment Order Register Listing All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPORegisterAll_WithSettlementDate");
                        break;

                    case "Payment Order Withdrawal By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalByCash_WithSettlementDate");

                        break;

                    case "Payment Order Withdrawal By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalByTransfer_WithSettlementDate");
                        break;

                    case "Payment Order Withdrawal All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectPOWithdrawalAll_WithSettlementDate");

                        break;

                    case "Internal Remittance Register":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRRegister_WithSettlementDate");
                        break;

                    case "Internal Remittance Withdrawal By Cash":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalByCash_WithSettlementDate");
                        break;

                    case "Internal Remittance Withdrawal By Transfer":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalByTransfer_WithSettlementDate");
                        break;

                    case "Internal Remittance Withdrawal All":
                        query = this.Session.GetNamedQuery("MNMVEW00073.SelectIRWithdrawalAll_WithSettlementDate");
                        break;
                }
            }
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);

            query.SetString("sourceBranchCode", sourceBr);

            IList<PFMDTO00042> ReportDataList = query.List<PFMDTO00042>();
            return ReportDataList;
        }

        public IList<PFMDTO00042> SelectPOWithdrawalEncashListing(DateTime startDate, DateTime endDate, string formName, string sourceBr)
        {
            IQuery query = null;
            switch (formName)
            {
                case "PO Withdrawl(Encash) By Cash Listing":
                    query = this.Session.GetNamedQuery("MNMVEW00079.SelectPOWithdrawlEncashByCash");
                    break;

                case "PO Withdrawl(Encash) By Transfer Listing":
                    query = this.Session.GetNamedQuery("MNMVEW00079.SelectPOWithdrawlEncashByTransfer");
                    break;

                case "PO Withdrawl(Encash) All Listing":
                    query = this.Session.GetNamedQuery("MNMVEW00079.SelectPOWithdrawlEncashAll");
                    break;
            }

           
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);

            query.SetString("sourceBranchCode", sourceBr);

            IList<PFMDTO00042> ReportDataList = query.List<PFMDTO00042>();
            return ReportDataList;
           
        }
        public IList<PFMDTO00042> SelectIR_Outstanding(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVEW00073.SelectIROutstanding");
            query.SetString("sourceBranchCode", sourceBr);
            IList<PFMDTO00042> ReportDataList = query.List<PFMDTO00042>();
            return ReportDataList;
        }

        //SelectPORegisterEncashListing
        public IList<PFMDTO00042> SelectPORegisterEncashListing(DateTime startDate, DateTime endDate, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVEW00078.SelectPOEncashRegister");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBr);
      
            IList<PFMDTO00042> ReportDataList = query.List<PFMDTO00042>();
            return ReportDataList;
        }

        #endregion

        #region Fixed year end interest posting listing

        public IList<MNMDTO00043> SelectFixedYEInterestList(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("VW_FIxedYEinterestList");
            query.SetString("SourceBr", SourceBr);
            return query.List<MNMDTO00043>();


        }

        public IList<MNMDTO00044> SelectFixedYEInterestPrevList(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("VW_FIxedYEinterestPrevList");
            query.SetString("SourceBr", SourceBr);
            return query.List<MNMDTO00044>();


        }
        #endregion

        //public IList<TLMDTO00001> SelectEncashRegisterOutstanding(string sourceBr)
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMVIW00017.SelectEncashRegisterOutstanding");
        //    query.SetString("sourceBr", sourceBr);
        //    IList<TLMDTO00001> list = query.List<TLMDTO00001>();
        //    return list;
        //}


        public IList<LOMDTO00013> GetLegalCaseListByAccountNo(string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMVIW00001.GetLegalCaseListByAccountNo");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<LOMDTO00013>();
        }


        public IList<TLMDTO00017> SelectDrawingRemittanceListByMonthlyClosingByReceiptDate(string sourceBr, string budget)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectDrawingRemittanceListByMonthlyClosingByReceiptDate");          
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("year", DateTime.Now.Year);
            query.SetInt32("month", DateTime.Now.Month);
            query.SetString("budget", budget);
            return query.List<TLMDTO00017>();
        }
        public IList<TLMDTO00017> SelectDrawingRemittanceListByMonthlyClosingBySettlementDate(string sourceBr, string budget)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectDrawingRemittanceListByMonthlyClosingBySettlementDate");
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("year", DateTime.Now.Year);
            query.SetInt32("month", DateTime.Now.Month);
            query.SetString("budget", budget);
            return query.List<TLMDTO00017>();
        }
        //public IList<TLMDTO00017> SelectDrawingRemittanceListByMonthlyClosingBySettlementDate(string sourceBr, string budget)
        //{
        //    IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectDrawingRemittanceListByMonthlyClosingBySettlementDate");
        //    query.SetString("sourceBr", sourceBr);
        //    query.SetInt32("year", DateTime.Now.Year);
        //    query.SetInt32("month", DateTime.Now.Month);
        //    query.SetString("budget", budget);
        //    return query.List<TLMDTO00017>();
        //}
        public IList<TLMDTO00001> SelectEncashRemittanceListByMonthlyClosingByIssueDate(string sourceBr, string budget)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectEncashRemittanceListByMonthlyClosingByIssueDate");
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("year", DateTime.Now.Year);
            query.SetInt32("month", DateTime.Now.Month);
            query.SetString("budget", budget);
            return query.List<TLMDTO00001>();
        }
        public IList<TLMDTO00001> SelectEncashRemittanceListByMonthlyClosingBySettlementDate(string sourceBr, string budget)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectEncashRemittanceListByMonthlyClosingBySettlementDate");
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("year", DateTime.Now.Year);
            query.SetInt32("month", DateTime.Now.Month);
            query.SetString("budget", budget);
            return query.List<TLMDTO00001>();
        }


        //LOMSVE00016 (Legal Case Entry)
        public IList<PFMDTO00042> SelectDataFromReportTlf(string accountNo, DateTime startOfMonth, DateTime endOfMonth, int workStationId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMVIW00002.SelectDataFromReportTlf");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("startDate", startOfMonth);
            query.SetDateTime("endDate", endOfMonth);            
            return query.List<PFMDTO00042>();
        }

        //CXDAO00009.SAMVEW00031.SelectRateFileListByStatusActive
        public IList<SAMDTO00056> SelectRateFileListByStatusActive(string status)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectRateFileListByActive");
            query.SetString("status", status);
            return query.List<SAMDTO00056>();
        }
        //CXDAO00009.SAMVEW00031.SelectRateFileList
        public IList<SAMDTO00056> SelectRateFileList()
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectRateFileList");
            //query.SetString("status", status);
            return query.List<SAMDTO00056>();
        }
        //CXDAO00009.SAMVEW00031.SelectRateFileListByRate
        public IList<SAMDTO00056> SelectRateFileListByRate(string rate)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00009.SelectRateFileListByRate");
            query.SetString("rate", rate);
            return query.List<SAMDTO00056>();
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestAll()
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00071.SelectAll");
            return query.List<MNMDTO00071>();
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestBetweenStartDateandEndDate(DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00072.SelectAll");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            return query.List<MNMDTO00071>();
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestByCash(DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00072.SelectByCash");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            return query.List<MNMDTO00071>();
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestByTransfer(DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00072.SelectByTransfer");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            return query.List<MNMDTO00071>();
        }

        public IList<TLMDTO00019> SelectFixedInterestWithdrawListing(DateTime startDate, DateTime endDate,string datetype,string sourceBr)
        {
             IQuery query;
            if (datetype == "Transaction")
            {
                query = this.Session.GetNamedQuery("MNMVIW00085.SelectByTransactionDate");
            }
            else
            {
                query = this.Session.GetNamedQuery("MNMVIW00085.SelectBySettlementDate");
            }
           
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00019>();
        }

        public IList<PFMDTO00042> SelectDepositListingByAll_New(string sourceBr, string workstationId)
        {
            try
            {
                IList<PFMDTO00042> result;
                IQuery query = this.Session.GetNamedQuery("SP_Tran_Deposit_Listing_ALL");
                query.SetString("sourceBr", sourceBr);
                query.SetString("workstationId", workstationId);
                
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
                result = query.List<PFMDTO00042>();
                return result;
            }
            catch (Exception ex)
            { return null; }
        }
        //With HomeCurrency and TransactionDate -- Added By AAM (27-Feb-2018)
        public IList<MNMDTO00054> GetLedgerListingRptByTDate_ForCashInHands(string aCode,DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        {
            IList<MNMDTO00054> result;
            IQuery query = this.Session.GetNamedQuery("SP_SubLedgerDo_ForCashInHands");
            query.SetString("aCode", aCode);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", sourcebr);
            query.SetString("workstation", workstation);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00054)));
            result = query.List<MNMDTO00054>();
            return result;
        }
        //Added by JZT (06-Feb-2018)
        public IList<PFMDTO00042> SelectWithdrawalListingAllReport_New(string sourceBr, int workstationId)
        {
            try
            {
                IList<PFMDTO00042> result;
                IQuery query = this.Session.GetNamedQuery("SP_Tran_Withdrawl_Listing_ALLReport");
                //query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
                //query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
                query.SetString("sourceBr", sourceBr);
                query.SetInt32("workstationId", workstationId);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
                result = query.List<PFMDTO00042>();
                return result;
            }
            catch (Exception ex)
            { return null; }
        }
        public bool DeleteAll_from_ReportTlf_bySourceBr(string sourceBr)
        {
            IQuery query = Session.GetNamedQuery("PFMDAO00042.DeleteAllfromReportTlfbySourceBr");
            query.SetString("SourceBr", sourceBr);

            GC.GetTotalMemory(false);//To fix due to garbage collection error and execute fail

            return query.ExecuteUpdate() > 0;
        }

        //Added by HMW at 3-4-2020 (To fix "Server Header Data Receving Error" at PL Ledger Balance Listing)
        [Transaction(TransactionPropagation.Required)]
        public IList<TCMDTO00013> GetAccountLedgerbyAcSignWorkstation(string acSign, string workstationId, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AccountLedger");
            query.SetString("acSign", acSign);
            query.SetString("workstation", workstationId);
            query.SetString("sourceCur", cur);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TCMDTO00013)));            
            return query.List<TCMDTO00013>();            
        }
    }
}


