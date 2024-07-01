using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00096 : DataRepository<LOMORM00026>, ILOMDAO00096
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00096> GetAllHPRegisterLists(string sourceBr, string cur, DateTime startDate, DateTime endDate, string stockGroup)
        {
            IList<LOMDTO00096> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPRegistrationListing");
            query.SetString("sourceBr", sourceBr);
            query.SetString("currency", cur);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("stockGroup", stockGroup);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00096)));
            result = query.List<LOMDTO00096>();
            return result;
        }
        
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00100> GetHPPaymentSchedule(string sourceBr, string cur, string month,string year)
        {
            IList<LOMDTO00100> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPPaymentSchedule");
            query.SetString("sourceBr", sourceBr);
            query.SetString("currency", cur);
            query.SetString("month", month);
            query.SetString("year", year);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00100)));
            result = query.List<LOMDTO00100>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm,decimal totalRepayAmt,string eno, string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HPManualRepayment");
            query.SetString("hpno", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalRepayAmt", totalRepayAmt);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);

            string strResult = query.UniqueResult().ToString();
            string[] strval = strResult.Split(',');

            LOMDTO00200 dto = new LOMDTO00200();
            dto.hpCustAcctNo = Convert.ToString(strval[0]);
            dto.hpDOAcctno = Convert.ToString(strval[1]);
            dto.retMsg = Convert.ToString(strval[2]);
            
            return dto;
        }

        [Transaction(TransactionPropagation.Required)]
        public string HPManualRepayment_CheckPaidorUnpaid(string hpNo, int startTerm, int endTerm,string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HPManualRepayment_CheckPaidOrUnPaid");
            query.SetString("hpno", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetRepayAmountPerTerm(string hpno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetRepayAmountPerTerm");
            query.SetString("hpno", hpno);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetRepayAmountSTermToETerm");
            query.SetString("hpno", hpno);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string HPMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_Monthly_AutoPayment_ForAllHPAccount");            
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            query.SetTimeout(10000); // Added By AAM(15_Aug_2018)
            return query.UniqueResult().ToString();
        }

        // Added Date Filter By AAM (28-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00202> GetHPOverDraftListing(string sourceBr, string currency,DateTime startDate,DateTime endDate)
        {
            IList<LOMDTO00202> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPOverDrawnListing");
            query.SetString("sourceBr", sourceBr);
            query.SetString("currency", currency);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00202)));
            result = query.List<LOMDTO00202>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00203> GetHPInsufficientListing(string sourceBr, string cur, string month)
        {
            IList<LOMDTO00203> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPInsufficientListing");
            query.SetString("sourcebr", sourceBr);
            query.SetString("cur", cur);
            query.SetString("month", month);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00203)));
            result = query.List<LOMDTO00203>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string HPLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_GetLateFeesForAllHPAccount");
            query.SetString("sourcebr", sourceBr);
            query.SetInt32("createduserid", createdUserId);
            query.SetString("username", userName);
            return query.UniqueResult().ToString();
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00204> GetBLInfoListingByDateRange(DateTime startDate, DateTime endDate, string sourceBr, string blType)
        {
            IList<LOMDTO00204> result;
            IQuery query = this.Session.GetNamedQuery("SP_BLInfoListingByDateRange");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBr", sourceBr);
            query.SetString("blType", blType);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00204)));
            result = query.List<LOMDTO00204>();
            return result;
        }
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00205> GetPLInfoListing(DateTime startDate, DateTime endDate,string companyName, string sourceBr)
        {
            IList<LOMDTO00205> result;
            IQuery query = this.Session.GetNamedQuery("SP_PersonalLoanInfoListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("companyName", companyName);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00205)));
            result = query.List<LOMDTO00205>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00206> GetBLInterestListing(string month,string year,string sourceBr,int createdUserId)
        {
            IList<LOMDTO00206> result;
            IQuery query = this.Session.GetNamedQuery("SP_BusinessLoanInterestListing");
            query.SetString("month", month);
            query.SetString("year", year);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00206)));
            result = query.List<LOMDTO00206>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00207> GetPersonalLoanNPLCaseListing(DateTime startDate, DateTime endDate, string sourceBr)
        {
            IList<LOMDTO00207> result;
            IQuery query = this.Session.GetNamedQuery("SP_PersonalLoanNPLCaseListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00207)));
            result = query.List<LOMDTO00207>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_HPLateFeesRepayment_Amount");
            query.SetString("hpNo", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string HPAccountExistsOrValid(string hpNo,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckHPAccountExistsOrValid");
            query.SetString("hpNo", hpNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm,decimal totalLateFeesAmount ,string eno,string sourceBr,int createdUserId,string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_LateFees_Repayment");
            query.SetString("hpNo", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalLateFeesAmount", totalLateFeesAmount);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);

            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        //public IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode,DateTime startDate,DateTime endDate,string sourceBr)
        public IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, string sourceBr)
        {
            IList<LOMDTO00208> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPDailyPositionListing");
            query.SetString("stockGroupCode", stockGroupCode); // Modified By AAM (25-10-2017)
            //query.SetDateTime("startDate", startDate); // Added two date para; by AAM (01-Feb-2018)
            //query.SetDateTime("endDate", endDate);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00208)));
            result = query.List<LOMDTO00208>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00209> GetHPInformationListing(DateTime startDate, DateTime endDate, string stockGroup, string sourceBr)
        {
            IList<LOMDTO00209> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPInformationListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("stockGroup", stockGroup);// Modified By AAM (26-10-2017)
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00209)));
            result = query.List<LOMDTO00209>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00210> GetHPPaymentListing(DateTime startDate,DateTime endDate,string stockGroup,string cur,string sourceBr)
        {
            IList<LOMDTO00210> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPPaymentListing");
            query.SetDateTime("startDate", startDate);// Modified By AAM (27-10-2017)
            query.SetDateTime("endDate", endDate);
            query.SetString("stockGroup", stockGroup);
            query.SetString("currency", cur);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00210)));
            result = query.List<LOMDTO00210>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00211> GetHPRepaymentListing(DateTime startDate, DateTime endDate, string cur, string sourceBr, string stockGroup)
        {
            IList<LOMDTO00211> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPRepaymentListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", cur);
            query.SetString("sourceBr", sourceBr);
            query.SetString("stockGroup", stockGroup);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00211)));
            result = query.List<LOMDTO00211>();
            return result;
            
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00212> GetHPInterest_Due_PreListing(DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup, string interestPaidStatus)
        {
            IList<LOMDTO00212> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPInterest_Due_PreListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetString("stockGroup", stockGroup);
            query.SetString("interestPaidStatus", interestPaidStatus);
            query.SetTimeout(72000);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00212)));
            result = query.List<LOMDTO00212>();
            return result;
        }

        //Updated by HWKO (21-Nov-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00213> Get_HP_Repayment_Schedule_Listing(string acctNo,string currency, string sourceBr)
        {
            IList<LOMDTO00213> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPRepaymentScheduleListing");
            query.SetString("acctNo", acctNo);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetTimeout(72000);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00213)));
            result = query.List<LOMDTO00213>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_HP_PrepaymentInfo(string hpNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_HP_PrepaymentInfo");
            query.SetString("hpNo", hpNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();

        }

        [Transaction(TransactionPropagation.Required)]
        public string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                                         decimal rentalDiscountRate,string eno,string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_Manual_Prepayment_Process");
            query.SetString("hpNo", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalPaidPrepayAmt", totalPaidPrepayAmt);
            query.SetDecimal("totalPaidRentalChgAmt", totalPaidRentalChgAmt);
            query.SetDecimal("rentalDiscountRate", rentalDiscountRate);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);
            
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (14-Sep-2017) // For HP Interest Pre-Payment Voucher Entry
        [Transaction(TransactionPropagation.Required)]
        public string GetTotalIntAmtOfAllTermByAcctNo(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetTotalIntAmtOfAllTermByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (14-Sep-2017) // For HP Interest Pre-Payment Voucher Entry
        [Transaction(TransactionPropagation.Required)]
        public string UpdateRentalChargesInTermByAcctNo(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_UpdateRentalChargesInTermByAcctNo");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)] //Added-22-Sep-2017
        public string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                             decimal rentalDiscountRate, string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_Manual_Prepayment_Process_NewLogic");
            query.SetString("hpNo", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalPaidInstallmentAmt", totalPaidInstallmentAmt);
            query.SetDecimal("totalPaidPrincipleAmt", totalPaidPrincipleAmt);
            query.SetDecimal("totalPaidRentalChgAmt", totalPaidRentalChgAmt);
            query.SetDecimal("rentalDiscountRate", rentalDiscountRate);
            query.SetString("eno", "");
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);

            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_HP_PrepaymentInfo_NewLogic");
            query.SetString("hpNo", hpNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string CheckHPAccountandStartTerm(string hpNo,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckHPAccountandStartTerm");
            query.SetString("hpNo", hpNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //Added 29-09-2017
        [Transaction(TransactionPropagation.Required)]        
        //public string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName)
        //{
        //    IQuery query = this.Session.GetNamedQuery("SP_HP_LateFeesAutoPay_Voucher_ALLHPTOD");
        //    query.SetString("eno", eno);
        //    query.SetString("sourceBr", sourceBr);
        //    query.SetInt32("createdUserId", createdUserId);
        //    query.SetString("userName", userName);
        //    query.SetTimeout(10000); // set transaction timeout values,by AAM(16_July_2018).
        //    return query.UniqueResult().ToString();
        //}

        //Comment & Modified by HMW at (26-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
        public string HPLateFeesAutoPayVoucherProcess(string sourceBr, int createdUserId, string userName) 
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_LateFeesAutoPay_Voucher_ALLHPTOD");            
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);
            query.SetTimeout(10000); // set transaction timeout values,by AAM(16_July_2018).
            return query.UniqueResult().ToString();
        }

        //Added 20-10-2017
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00214> HPAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            IList<LOMDTO00214> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPAbsentHistoryListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00214)));
            result = query.List<LOMDTO00214>();
            return result;
        }

        //Added by AAM (23-Oct-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00215> PLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            IList<LOMDTO00215> result;
            IQuery query = this.Session.GetNamedQuery("SP_PLAbsentHistoryListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);
            query.SetTimeout(72000);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00215)));
            result = query.List<LOMDTO00215>();
            return result;
        }
        
        //Added By AAM(24-10-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00216> HPAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            IList<LOMDTO00216> result;
            IQuery query = this.Session.GetNamedQuery("SP_HPAbsentHistory_Enquiry");
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00216)));
            result = query.List<LOMDTO00216>();
            return result;
        }
        
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            IList<LOMDTO00217> result;
            IQuery query = this.Session.GetNamedQuery("SP_PLAbsentHistory_Enquiry");
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00217)));
            result = query.List<LOMDTO00217>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00218> HP_LateFees_Outstanding_Listing(string currency, string sourceBr, DateTime startDate, DateTime endDate, int searchBy)
        {
            IList<LOMDTO00218> result;
            IQuery query = this.Session.GetNamedQuery("SP_HP_LateFeesOutstanding_Listing");
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetInt32("searchBy", searchBy);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00218)));
            result = query.List<LOMDTO00218>();
            return result;
        }

        //Added by AAM (15-Nov-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00219> BL_LateFees_Outstanding_Listing(string currency, string sourceBr)
        {
            IList<LOMDTO00219> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_LateFeesOutstanding_Listing");
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00219)));
            result = query.List<LOMDTO00219>();
            return result;
        }
        //Updated by ZMS (18-06-2018)
        //Added by AAM (27-Nov-2017) 
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00220> HP_Installment_Listing(string currency, string sourceBr, string stockGroup, string SortType)
        {
            IList<LOMDTO00220> result;
            IQuery query = this.Session.GetNamedQuery("SP_HP_Installment_Listing");
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetString("stockGroup", stockGroup);
            query.SetString("sortType", SortType);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00220)));
            result = query.List<LOMDTO00220>();
            return result;
        }

        //Updated by ZMS (18-06-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00221> PL_Installment_Listing(string currency, string sourceBr, string companyName, string SortType)
        {
            IList<LOMDTO00221> result;
            IQuery query = this.Session.GetNamedQuery("SP_PL_Installment_Listing");
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetString("companyName", companyName);
            query.SetString("sortType", SortType);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00221)));
            result = query.List<LOMDTO00221>();
            return result;
        }

        //Updated by ZMS (18-06-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00222> BL_Installment_Listing(string currency, string sourceBr, string businessType, string SortType)
        {
            IList<LOMDTO00222> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_Installment_Listing");
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);
            query.SetString("businessType", businessType);
            query.SetString("sortType", SortType);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00222)));
            result = query.List<LOMDTO00222>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00223> PL_DailyPosition_Listing(string sourceBr, string companyName)
        {
            IList<LOMDTO00223> result;
            IQuery query = this.Session.GetNamedQuery("SP_PLDailyPositionListing");
            query.SetString("sourceBr", sourceBr);
            query.SetString("companyName", companyName);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00223)));
            result = query.List<LOMDTO00223>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00224> HP_AutoPay_Sufficient_Listing(DateTime startDate,DateTime endDate,string stockGroup, string currency, string sourceBr)
        {
            IList<LOMDTO00224> result;
            IQuery query = this.Session.GetNamedQuery("SP_HP_AutoPay_Sufficient_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("stockGroup", stockGroup);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00224)));
            result = query.List<LOMDTO00224>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00225> PL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string companyName, string currency, string sourceBr)
        {
            IList<LOMDTO00225> result;
            IQuery query = this.Session.GetNamedQuery("SP_PL_AutoPay_Sufficient_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("companyName", companyName);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00225)));
            result = query.List<LOMDTO00225>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00226> BL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string businessType, string currency, string sourceBr)
        {
            IList<LOMDTO00226> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_AutoPay_Sufficient_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("businessType", businessType);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00226)));
            result = query.List<LOMDTO00226>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00227> BL_Overdrawn_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00227> result;
            IQuery query = this.Session.GetNamedQuery("SP_BLOverDrawnListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00227)));
            result = query.List<LOMDTO00227>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00228> LOANS_SUMMARY_REPORT_ForBOM(DateTime Date,string currency, string sourceBr)
        {
            IList<LOMDTO00228> result;
            IQuery query = this.Session.GetNamedQuery("SP_LoansSummaryReportForBOM");
            query.SetDateTime("date", Date);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00228)));
            result = query.List<LOMDTO00228>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00229> LOANS_SUMMARY_REPORT_ForBOM_LiveUnLive(DateTime Date, string currency, string sourceBr)
        {
            IList<LOMDTO00229> result;
            IQuery query = this.Session.GetNamedQuery("SP_LoansSummaryReportForBOM_LiveUnLive");
            query.SetDateTime("date", Date);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00229)));
            result = query.List<LOMDTO00229>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00230> HP_TOD_Repayment_Listing(DateTime startDate,DateTime endDate,string currency, string sourceBr)
        {
            IList<LOMDTO00230> result;
            IQuery query = this.Session.GetNamedQuery("SP_HP_TOD_Repayment_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00230)));
            result = query.List<LOMDTO00230>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00230> PL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> result;
            IQuery query = this.Session.GetNamedQuery("SP_PL_TOD_Repayment_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00230)));
            result = query.List<LOMDTO00230>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00230> BL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_TOD_Repayment_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00230)));
            result = query.List<LOMDTO00230>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00231> HP_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> result;
            IQuery query = this.Session.GetNamedQuery("SP_HP_AccountClosed_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00231)));
            result = query.List<LOMDTO00231>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00231> PL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> result;
            IQuery query = this.Session.GetNamedQuery("SP_PL_AccountClosed_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00231)));
            result = query.List<LOMDTO00231>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00231> BL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_AccountClosed_Listing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00231)));
            result = query.List<LOMDTO00231>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00232> Transfer_Transaction_Listing(string dateOption,DateTime startDate, DateTime endDate,string voucherStatus,
                                                               string requiredType,int reverseStatus,string currency, string sourceBr)
        {
            IList<LOMDTO00232> result;
            IQuery query = this.Session.GetNamedQuery("SP_Transfer_Transaction_Listing");
            query.SetString("dateOption", dateOption);
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("voucherStatus", voucherStatus);
            query.SetString("requiredType", requiredType);
            query.SetInt32("reverseStatus", reverseStatus);
            query.SetString("currency", currency);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00232)));
            result = query.List<LOMDTO00232>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetDealerBusinessName_For_HPLimitVoucher_Printing(string dealerNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetDealerName_HPLimitVou_Printing");
            query.SetString("dealerNo", dealerNo);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00234> Get_HP_LimitVou_Lists(string eno)
        {
            IList<LOMDTO00234> result;
            IQuery query = this.Session.GetNamedQuery("SP_Get_LimitVou_Lists");
            query.SetString("eno", eno);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00234)));
            result = query.List<LOMDTO00234>();
            return result;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00235> Get_PL_LimitVou_Lists(string eno)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_LimitVou_Lists");
            query.SetString("eno", eno);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00235)));
            IList<LOMDTO00235> multilist = query.List<LOMDTO00235>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00236> Get_BL_LimitVou_Lists(string eno)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_LimitVou_Lists");
            query.SetString("eno", eno);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00236)));
            IList<LOMDTO00236> multilist = query.List<LOMDTO00236>();
            return multilist;
        }

        // Added By AAM (07-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00237> Get_HP_Information_For_Enquiry(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_HP_Information_For_Enquiry");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00237)));
            IList<LOMDTO00237> multilist = query.List<LOMDTO00237>();
            return multilist;
        }
        // Added By AAM (14-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public string HP_Registration_Reversal(string hpNo,string reversalEno,int createdUserId,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_Registration_Reversal");
            query.SetString("hpNo", hpNo);
            query.SetString("reversalEno", reversalEno);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        // Added By AAM (16-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public string Get_HPInfo_ByHPNo(string hpNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_HPCustomerInfo_By_HPNo");
            query.SetString("hpNo", hpNo);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        // Added By AAM (21-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00238> Get_COA_Lists(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_COA_Lists");
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00238)));
            IList<LOMDTO00238> multilist = query.List<LOMDTO00238>();
            return multilist;
        }

        // Added By AAM (26-Feb-2018)
        [Transaction(TransactionPropagation.Required)]
        public string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData, string eno, int createdUserId
                                                , string sourceBr, string narration)
        {
            string strLists = "";
            for (int i = 0; i < lstImportData.Count; i++)
            {
                strLists += "#" + lstImportData[i].AccountAndAmount;
            }
            strLists = strLists.Substring(1);

            IQuery query = this.Session.GetNamedQuery("SP_ImportingDeposit");
            query.SetString("acWithOtherBank", acWithOtherBnk);
            query.SetString("acctNoAndamount", strLists);
            query.SetString("eno", eno);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            query.SetString("narration", narration);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }
		
		//For Year End Income Voucher
        //Added by HMW (23-Sept-2019)
        [Transaction(TransactionPropagation.Required)]
        public string Check_AlreadyZerorizationForIncomeAC(string ProfitAndLossAc)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_AlreadyZerorizationForIncomeAC");
            query.SetString("plAC", ProfitAndLossAc);
            query.SetString("RetMsg", string.Empty);
            string strResult = query.UniqueResult().ToString();
            if (string.IsNullOrEmpty(strResult))
            {
                strResult = string.Empty;
            }
            return strResult;        
        }

        // Added By AAM (28-Mar-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_PNL_Zerorization_Income_Info");
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00239)));
            IList<LOMDTO00239> multilist = query.List<LOMDTO00239>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_Info_For_PNL_Zerorization_Income_ByPLAC");
            query.SetString("plAC", plAC);
            query.SetString("sourceBr", sourceBr);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }
        
        [Transaction(TransactionPropagation.Required)]
        public string PNL_Zerorization_Income_Voucher(string plAC,int createdUserId,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_For_PNL_Zerorization_Income_Voucher");
            query.SetString("plAC", plAC);            
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        //For Year End Expense Voucher
        //Added by HMW (23-Sept-2019)
        [Transaction(TransactionPropagation.Required)]
        public string Check_AlreadyZerorizationForExpenseAC(string ProfitAndLossAc)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_AlreadyZerorizationForExpenseAC");
            query.SetString("plAC", ProfitAndLossAc);
            query.SetString("RetMsg", string.Empty);
            string strResult = query.UniqueResult().ToString();
            if (string.IsNullOrEmpty(strResult))
            {
                strResult = string.Empty;
            }
            return strResult;           
        }

        // Added By AAM (28-Mar-2018) 
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_Expn_Zerorization_Expense_Info");
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00239)));
            IList<LOMDTO00239> multilist = query.List<LOMDTO00239>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_Info_For_Expn_Zerorization_Expense_ByExpnAC");
            query.SetString("expnAC", expnAC);
            query.SetString("sourceBr", sourceBr);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Expn_Zerorization_Expense_Voucher(string expnAC, int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_For_Expn_Zerorization_Expense_Voucher");
            query.SetString("expnAC", expnAC);            
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        // Personal Loan Manual Prepayment Process,added by AAM (05-Apr-2018)
        [Transaction(TransactionPropagation.Required)]
        public string PL_Manual_Pre_Payment_Process(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt
                                                            , decimal totalPaidPrincipleAmt, decimal totalPaidInterestAmt, decimal intDiscountRate, string sourceBr
                                                            , int createdUserId, string userName, string formatCode
                                                            , int valueCount, string valueStr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_Manual_Prepayment_Process");
            query.SetString("plNo", plNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetDecimal("totalPaidPrepayAmt", totalPaidInstallmentAmt);
            query.SetDecimal("totalPaidPrincipleAmt", totalPaidPrincipleAmt);
            query.SetDecimal("totalPaidInterestAmt", totalPaidInterestAmt);
            query.SetDecimal("interestDiscountRate", intDiscountRate);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);
            //query.SetString("formatCode", formatCode);
            //query.SetInt32("valueCount", valueCount);
            //query.SetString("valueStr", valueStr);

            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string Get_PL_PrepaymentInfo(string plNo, int startTerm, int endTerm, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_PL_PrepaymentInfo");
            query.SetString("plNo", plNo);
            query.SetInt32("startTerm", startTerm);
            query.SetInt32("endTerm", endTerm);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string CheckPLAccountandStartTerm(string plNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckPLAccountandStartTerm");
            query.SetString("plNo", plNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

        //HP Interest Pre-payment By Dealer,Added By AAM (06-Apr-2018)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00241> Get_HPList_For_Interest_Prepay_ByDealer(LOMDTO00241 hpListBydealer)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_DealerInfo_ByDealerAC");
            query.SetString("dealerAcctNo", hpListBydealer.DealerAcctNo);
            query.SetString("sourceBr", hpListBydealer.SourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00241)));
            IList<LOMDTO00241> lstDealerInfo = query.List<LOMDTO00241>();

            if (lstDealerInfo == null || lstDealerInfo.Count == 0) return lstDealerInfo;

            IQuery query2 = this.Session.GetNamedQuery("SP_Get_HP_Interest_Prepay_Info_ByDealer");
            query2.SetString("dealerAcctNo", hpListBydealer.DealerAcctNo);
            query2.SetDateTime("startDate", hpListBydealer.FromDate);
            query2.SetDateTime("endDate", hpListBydealer.ToDate);
            query2.SetString("currency", hpListBydealer.Currency);
            query2.SetString("sourceBr", hpListBydealer.SourceBr);

            query2.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00240)));
            IList<LOMDTO00240> multilist = query2.List<LOMDTO00240>();

            lstDealerInfo[0].HpList = (List<LOMDTO00240>)multilist;
            return lstDealerInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Dealer_Interest_Prepaid_ForHP(LOMDTO00241 hpListBydealer)
        {
            IQuery query = this.Session.GetNamedQuery("SP_HP_Interest_Prepay_Process_ByDealer");
            query.SetString("hpList", hpListBydealer.HPNoList);
            query.SetString("dealerAcctNo", hpListBydealer.DealerAcctNo);
            query.SetInt32("createdUserId", hpListBydealer.CreatedUserId);
            query.SetString("sourceBr", hpListBydealer.SourceBr);
            query.SetString("formatCode", hpListBydealer.FormatCode);
            query.SetInt32("valueCount", hpListBydealer.ValueCount);
            query.SetString("valueStr", hpListBydealer.ValueStr);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00242> HPInterestPrepaidByDealer_Listing(LOMDTO00242 hpIntPrepaidList)
        {
            if (hpIntPrepaidList.storedName == "0")
            {
                IQuery query = this.Session.GetNamedQuery("SP_HP_Interest_Prepaid_ALL_Listing");
                query.SetDateTime("startDate", hpIntPrepaidList.StartDate);
                query.SetDateTime("endDate", hpIntPrepaidList.EndDate);
                query.SetString("currency", hpIntPrepaidList.Currency);
                query.SetString("sourceBr", hpIntPrepaidList.SourceBr);
                query.SetString("stockGroupCode", hpIntPrepaidList.StockGroupCode);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00242)));
                IList<LOMDTO00242> multilist = query.List<LOMDTO00242>();
                return multilist;
            }
            else
            {
                IQuery query = this.Session.GetNamedQuery("SP_HP_Interest_Prepaid_Installment_Listing");
                query.SetDateTime("startDate", hpIntPrepaidList.StartDate);
                query.SetDateTime("endDate", hpIntPrepaidList.EndDate);
                query.SetString("currency", hpIntPrepaidList.Currency);
                query.SetString("sourceBr", hpIntPrepaidList.SourceBr);
                query.SetString("stockGroupCode", hpIntPrepaidList.StockGroupCode);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00242)));
                IList<LOMDTO00242> multilist = query.List<LOMDTO00242>();
                return multilist;
            }

        }

        // Added By AAM (22-Mar-2018)
        [Transaction(TransactionPropagation.Required)]
        public string PL_Registration_Reversal(string plNo, int createdUserId, string sourceBr, string formatCode
                                                , int valueCount, string valueStr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_PL_Registration_Reversal");
            query.SetString("plNo", plNo);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            query.SetString("formatCode", formatCode);
            query.SetInt32("valueCount", valueCount);
            query.SetString("valueStr", valueStr);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        // Added By AAM (22-Mar-2018)
        [Transaction(TransactionPropagation.Required)]
        public string Get_PLInfo_ByPLNo(string plNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_PLCustomerInfo_By_PLNo");
            query.SetString("plNo", plNo);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }


        // Added By AAM (28-Mar-2018)
        [Transaction(TransactionPropagation.Required)]
        public string BL_Registration_Reversal(string blNo, string formatCode, int createdUserId, string sourceBr)//Modify by HMW at 27-08-2019
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_Registration_Reversal");
            query.SetString("blNo", blNo);
            query.SetString("formatCode", formatCode);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        // Added By AAM (28-Mar-2018)
        [Transaction(TransactionPropagation.Required)]
        public string Get_BLInfo_ByBLNo(string blNo)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Get_BLCustomerInfo_By_BLNo");
            query.SetString("blNo", blNo);
            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        public IList<LOMDTO00240> Get_TotalInterestAndFirstInstallment(LOMDTO00084 dto)
        {
            //IQuery query = this.Session.GetNamedQuery("Sp_CalculateHPTotalInterestFirstInstallment");
            //query.SetDecimal("downPayPercent", dto.DownPayment);
            //query.SetDecimal("disburseAmt", dto.LoanAmount);
            //query.SetInt32("paymentDuration", dto.Term);
            //query.SetInt32("paymentOptionId", dto.RepayOption);
            //query.SetDecimal("rentalChgsPercent", dto.RentalCharges);
            IQuery query = this.Session.GetNamedQuery("SP_Get_HP_RepaymentInfo_PreCalculation");
            query.SetDecimal("DisburseAmt", dto.LoanAmount);
            query.SetDecimal("DownPayPercent", dto.DownPayment);
            query.SetDecimal("RentalChgsPercent", dto.RentalCharges);
            query.SetDecimal("DealerCommissionPercent", dto.Commission);
            query.SetInt32("paymentDuration", dto.Term);
            query.SetString("SourceBr", dto.SourceBr);

            //query.SetInt32("paymentOptionId", dto.RepayOption);
            

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00240)));
            IList<LOMDTO00240> multilist = query.List<LOMDTO00240>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00244> CheckAccountForAccountClosed(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckAccountForAccountClosed");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00244)));
            IList<LOMDTO00244> multilist = query.List<LOMDTO00244>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00244> GetAccountInfoForAccountClosed(string acctNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetAccountInfoForAccountClosed");
            query.SetString("acctNo", acctNo);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00244)));
            IList<LOMDTO00244> multilist = query.List<LOMDTO00244>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save_AccountClosed(LOMDTO00244 dto)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Save_AccountClosed");
            query.SetString("acctNo", dto.AcctNo);
            query.SetInt32("createdUserId", dto.CreatedUserId);
            query.SetString("sourceBr", dto.SourceBr);
            query.SetString("noOfName", dto.NoofName);
            query.SetString("noOfNRC", dto.NoofNRC);

            string strResult = query.UniqueResult().ToString();
            return strResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00244> AccountClosedListing(LOMDTO00244 dto)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AccountClosedListing");
            query.SetDateTime("startDate", dto.StartDate);
            query.SetDateTime("endDate", dto.EndDate);
            query.SetString("currency", dto.Currency);
            query.SetString("sourceBr", dto.SourceBr);
            query.SetString("acTypeFilter", dto.ACTypeFilter);
            query.SetString("sortBy", dto.SortBy);
            
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00244)));
            IList<LOMDTO00244> multilist = query.List<LOMDTO00244>();
            return multilist;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00245> TransactionListing(LOMDTO00245 dto)
        {
            IQuery query = this.Session.GetNamedQuery("SP_TransactionListing");
            query.SetString("startDate", dto.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", dto.EndDate.ToString("yyyy/MM/dd"));
            query.SetString("voucherType", dto.VoucherType);
            query.SetString("voucherStatus", dto.VoucherStatus);
            query.SetString("optFilter", dto.OptFilter);
            query.SetString("currency", dto.Currency);
            query.SetString("sourceBr", dto.SourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00245)));
            IList<LOMDTO00245> multilist = query.List<LOMDTO00245>();
            return multilist;
        }

        //Added by YMP for Late Fee Exception (15-May-2019)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00219> GetLateFeeInfoByACNo(string acctno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetInfoForLateFeeException");
            query.SetString("acctno", acctno);
            query.SetString("sourcebr", sourcebr);
            
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00219)));
            IList<LOMDTO00219> latefeeinfolist = query.List<LOMDTO00219>();
            return latefeeinfolist;
        }


        
        //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00219> GetLateFeeInfoAllForChecker()
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetInfoForLateFeeExceptionForChecker");

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00219)));
            IList<LOMDTO00219> latefeeinfolist = query.List<LOMDTO00219>();
            return latefeeinfolist;
        }


        //Added by YMP for Late Fee Exception (16-May-2019)
        [Transaction(TransactionPropagation.Required)]
        public string SaveLateFeeExceptionInfo(IList<LOMDTO00219> SaveLateFeeExceptionInfo)
        {
            string strResult = "";
            IQuery query;

            for (int i = 0; i < SaveLateFeeExceptionInfo.Count; i++)
            {
                //strLists += "#" + lstImportData[i].AccountAndAmount;
                query = this.Session.GetNamedQuery("SP_SaveToLateFeeException");
                query.SetString("lno", SaveLateFeeExceptionInfo[i].Lno);
                query.SetString("acctno", SaveLateFeeExceptionInfo[i].Acctno);
                query.SetString("termno", SaveLateFeeExceptionInfo[i].TermNo.ToString());
                query.SetString("cur", SaveLateFeeExceptionInfo[i].Cur);
                query.SetString("sourcebr", SaveLateFeeExceptionInfo[i].SourceBr);
                query.SetString("makerid", SaveLateFeeExceptionInfo[i].UpdatedUserId.ToString());

                query.SetBoolean("Interest_PTOD_Status", SaveLateFeeExceptionInfo[i].Interest_PTOD_Status);
                query.SetBoolean("LateFee_PTOD_Status", SaveLateFeeExceptionInfo[i].LateFee_PTOD_Status);
                query.SetBoolean("LateFee_ITOD_Status", SaveLateFeeExceptionInfo[i].LateFee_ITOD_Status);
                query.SetBoolean("TotalLateFee_Status", SaveLateFeeExceptionInfo[i].TotalLateFee_Status);

                strResult = query.UniqueResult().ToString();    
            }

            return strResult;
        }

        //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        [Transaction(TransactionPropagation.Required)]
        public string UpdateLateFeeExceptionInfo(IList<LOMDTO00219> latefeeinfo, string ApproveReject)
        {
            string strResult = "";
            IQuery query;

            for (int i = 0; i < latefeeinfo.Count; i++)
            {
                query = this.Session.GetNamedQuery("SP_UpdateLateFeeException");
                query.SetString("acctno", latefeeinfo[i].Acctno);
                query.SetString("termno", latefeeinfo[i].TermNo.ToString());
                query.SetString("checkerid", latefeeinfo[i].UpdatedUserId.ToString());
                query.SetString("approvereject", ApproveReject.ToString());
                
                strResult = query.UniqueResult().ToString();
            }

            return strResult;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00219> BL_OD_AND_LateFee_Outstanding_Listing_ByAccount(string accountno, string sourceBr)
        {
            IList<LOMDTO00219> result;
            IQuery query = this.Session.GetNamedQuery("SP_BL_OD_AND_LateFee_Outstanding_Listing_ByAccount");
            query.SetString("acctno", accountno);
            query.SetString("sourcebr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00219)));
            result = query.List<LOMDTO00219>();
            return result;
        }
    }


}
