using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate;
using Ace.Cbs.Loan.Dmd;
using NHibernate.Transform;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00405 : DataRepository<LOMVIW00405>, ILOMDAO00405
    {
        //[Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00405> SelectBLInterestDuePrelistingByDueDate(DateTime startDate, DateTime endDate, string sourceBr, string currency)
        //{
        //    IQuery query = this.Session.GetNamedQuery("BLInterestDuePreListingDAO.SelectByDueDateForBLIntDuePreListing");
        //    query.SetDateTime("startDate", startDate);
        //    query.SetDateTime("endDate", endDate);
        //    query.SetString("sourceBranchCode", sourceBr);
        //    query.SetString("cur", currency);
        //    IList<LOMDTO00405> multilist = query.List<LOMDTO00405>();
        //    return multilist;
        //}
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> SelectBLInterestDuePrelistingByDueDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType,string interestPaidStatus)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BLInterestDuePreListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", currency);
            if (bLType == "")
            {
                string type = "All";
                query.SetString("blType", "All");
            }
            else
            {
                query.SetString("blType", bLType);
            }

            query.SetString("interestPaidStatus", interestPaidStatus);
            query.SetTimeout(72000);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00406)));
            IList<LOMDTO00406> multilist = query.List<LOMDTO00406>();
            return multilist;
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00405> SelectBLlistingbyGrade(DateTime startDate, DateTime endDate, string sourceBr, string currency, decimal minimumAmt, decimal maximumAmt,string blType)
        {
            //IQuery query = this.Session.GetNamedQuery("BLInterestDuePreListingDAO.SelectBLlistingbyGrade");
            //DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
            //query.SetDateTime("startDate", starttemp);
            //DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
            //query.SetDateTime("endDate", endtemp);
            //query.SetString("sourceBranchCode", sourceBr);
            //query.SetString("cur", currency);
            //query.SetDecimal("minimumAmt", minimumAmt);
            //query.SetDecimal("maximumAmt", maximumAmt);
            //IList<LOMDTO00405> multilist = query.List<LOMDTO00405>();
            //return multilist;

            IQuery query = this.Session.GetNamedQuery("SP_BLInfoByBLTypeAndGrade");
            DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
            query.SetDateTime("startDate", starttemp);
            DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
            query.SetDateTime("endDate", endtemp);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("cur", currency);
            query.SetDecimal("minimumAmt", minimumAmt);
            query.SetDecimal("maximumAmt", maximumAmt);
            query.SetString("blType", blType);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00405)));
            IList<LOMDTO00405> allLoanRecordList = query.List<LOMDTO00405>();
            return allLoanRecordList;
        }
         [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00405> SelectBLServiceChargeslistingByDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType)
        {
            //IQuery query = this.Session.GetNamedQuery("BLInterestDuePreListingDAO.SelectBLServiceChargeslistingByDate");
            //query.SetDateTime("startDate", startDate);
            //query.SetDateTime("endDate", endDate);
            //query.SetString("sourceBranchCode", sourceBr);
            //query.SetString("cur", currency);
            //query.SetString("bLType", bLType);
            //IList<LOMDTO00405> multilist = query.List<LOMDTO00405>();
            //return multilist;

            IQuery query = this.Session.GetNamedQuery("SP_BL_ServiceChargesListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetString("cur", currency);
             if (bLType == "")
             {
                string type = "All";
                query.SetString("blType", "All");
             }
            else
            {
                query.SetString("blType", bLType);
            }  
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00405)));
            IList<LOMDTO00405> allLoanRecordList = query.List<LOMDTO00405>();
            return allLoanRecordList;
        }
         //With old table OutstandingLoanBalance
         //[Transaction(TransactionPropagation.Required)]
         //public LOMDTO00405 SelectBLInfolistingByBLNo(string lno, string currency, string sourceBr)
         //{
         //    IQuery query = this.Session.GetNamedQuery("BLInterestDuePreListingDAO.SelectBLInfolistingByBLNo");
         //    query.SetString("lno", lno);
         //    query.SetString("cur", currency);
         //    query.SetString("sourceBranchCode", sourceBr);
         //    LOMDTO00405 multilist = query.UniqueResult<LOMDTO00405>();
         //    return multilist;
         //}

         //With old table Business_Loans_Details
         //Updated by HWKO (22-Nov-2017)
         [Transaction(TransactionPropagation.Required)]
         public IList<LOMDTO00406> SelectBLInfolistingByBLNo(string acctNo, string currency, string sourceBr)
         {
             IQuery query = this.Session.GetNamedQuery("SP_BL_ScheduleListingByBLno");
             query.SetString("acctNo", acctNo);
             query.SetString("cur", currency);
             query.SetString("sourceBranchCode", sourceBr);
             query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00406)));
             IList<LOMDTO00406> allLoanRecordList = query.List<LOMDTO00406>();
             return allLoanRecordList;
         }

         [Transaction(TransactionPropagation.Required)]
         public IList<LOMDTO00405> SelectBLRepaymentInfolistingByRepayDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType)
         {
             //IQuery query = this.Session.GetNamedQuery("LOMVIW00414.SelectBLRepayInfoByRepaymentDateListing");
             //DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
             //query.SetDateTime("startDate", starttemp);
             //DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
             //query.SetDateTime("endDate", endtemp);
             //query.SetString("sourceBranchCode", sourceBr);
             //query.SetString("cur", currency);
             //IList<LOMDTO00405> multilist = query.List<LOMDTO00405>();
             //return multilist;

             IQuery query = this.Session.GetNamedQuery("SP_BL_RepayListing");
             DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
             query.SetDateTime("startDate", starttemp);
             DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
             query.SetDateTime("endDate", endtemp);
             query.SetString("sourceBranchCode", sourceBr);
             query.SetString("cur", currency);
             if (bLType == "")
             {
                 string type = "All";
                 query.SetString("blType", type);
             }
             else
             {
                 query.SetString("blType", bLType);
             }
             query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00405)));
             IList<LOMDTO00405> allLoanRecordList = query.List<LOMDTO00405>();
             return allLoanRecordList;
         }
         //With old table OutstandingLoanBalance
         //[Transaction(TransactionPropagation.Required)]
         //public IList<LOMDTO00405> SelectBLNPLlistingByNPLDate(DateTime startDate, DateTime endDate, string sourceBr, string currency)
         //{
         //    IQuery query = this.Session.GetNamedQuery("BLInterestDuePreListingDAO.SelectBLNPLlistingbyNPLDate");
         //    DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
         //    query.SetDateTime("startDate", starttemp);
         //    DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
         //    query.SetDateTime("endDate", endtemp);
         //    query.SetString("sourceBranchCode", sourceBr);
         //    query.SetString("cur", currency);
         //    IList<LOMDTO00405> multilist = query.List<LOMDTO00405>();
         //    return multilist;
         //}

         //With new table Business_Loans_Details
         [Transaction(TransactionPropagation.Required)]
         public IList<LOMDTO00406> SelectBLNPLlistingByNPLDate(DateTime startDate, DateTime endDate, string sourceBr, string currency, string bLType)
         {
             try
             {
                 IQuery query = this.Session.GetNamedQuery("SP_BL_NPLListing");
                 DateTime starttemp = Convert.ToDateTime(startDate.ToString("yyyy/MM/dd"));
                 query.SetDateTime("StartDate", starttemp);
                 DateTime endtemp = Convert.ToDateTime(endDate.ToString("yyyy/MM/dd"));
                 query.SetDateTime("EndDate", endtemp);
                 query.SetString("sourceBranchCode", sourceBr);
                 query.SetString("cur", currency);
                 if (bLType == "")
                 {
                     string type = "All";
                     query.SetString("blType", type);
                 }
                 else
                 {
                     query.SetString("blType", bLType);
                 }                 
                 query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00406)));
                 IList<LOMDTO00406> allLoanRecordList = query.List<LOMDTO00406>();
                 return allLoanRecordList;
             }
             catch { return null; }
         }


         // For BL Daily Position Listing Added by ZMS [02-Jul-18]
        [Transaction(TransactionPropagation.Required)]
         public IList<LOMDTO00423> GetBLDailyPositionListing(string loanGroup, string sourceBr)
         {
             IQuery query = this.Session.GetNamedQuery("SP_BLDailyPositionListing");
             query.SetString("loanGroup", loanGroup);
             query.SetString("sourceBr", sourceBr);

             query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00423)));
             IList<LOMDTO00423> dailyPositionList = query.List<LOMDTO00423>();
             return dailyPositionList;
         }
        public IList<LOMDTO00001> SelectAllBLTypes()
        {
            IQuery query = this.Session.GetNamedQuery("LoanBTypeDAO.SelectAll");
            return query.List<LOMDTO00001>();
        }

        // For AC Info Enquiry Added by ZMS [04-Jul-18]
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00423> GetAllCustomerInformation(string name, string nrc, bool isNameExact, bool isNRCExact, string aCType, string sType)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AccountInformationEnquiry");
            query.SetString("name", name);
            query.SetString("nrc", nrc);
            query.SetString("isNameExact", isNameExact.ToString());
            query.SetString("isNRCExact", isNRCExact.ToString());
            query.SetString("aCType", aCType);
            query.SetString("searchType", sType);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00423)));
            IList<LOMDTO00423> dailyPositionList = query.List<LOMDTO00423>();
            return dailyPositionList;
        }

       
    }

}
