//----------------------------------------------------------------------
// <copyright file="MNMDAO00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00017 : DataRepository<MNMORM00017>, IMNMDAO00017
    {

        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("LiDAO.SelectMaxId");
            LOMDTO00021 dto = query.UniqueResult<LOMDTO00021>();
            return dto.Id;
        }


        public IList<LOMDTO00021> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<LOMDTO00021>();
        }

        public IList<LOMDTO00021> SelectLiInfoForLoanInterest(string lno, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLiInfoForLoanInterest");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetString("lno", lno);
            return query.List<LOMDTO00021>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateQBal(int samt, string lno, string quater_month, string SourceBranchCode, int updatedUserId)
        {
            IQuery query;
            if (quater_month == "06")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQBal2");

            }
            else if (quater_month == "09")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQBal3");
            }
            else if (quater_month == "12")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQBal4");
            }
            else
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQBal1");
                
            }

            query.SetInt32("samt", samt);
            query.SetString("lno", lno);
            //query.SetString("quater_month", quater_month);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserID", updatedUserId);
            query.SetDateTime("updatedDate",DateTime.Now);
            
            return query.ExecuteUpdate() > 0;

        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLI(decimal month, string budget, string SourceBranchCode, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.UpdateLI");
            query.SetDecimal("month", month);
            query.SetString("budget", budget);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public LOMDTO00021 SelectByAccountNo(string accountNo)  //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<LOMDTO00021>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool Update_LI_InfoByLoanNoAndSourceBr(LOMDTO00021 liDto)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.Update_LI_InfoByLoanNoAndSourceBr");
            query.SetDecimal("rate",Convert.ToDecimal(liDto.IntRate));
            query.SetString("tno", liDto.TNo);
            query.SetString("lno", liDto.LNo);
            query.SetString("sourcebr", liDto.SourceBr);
            query.SetInt32("updatedUserId", liDto.CreatedUserId);
            query.SetDateTime("updatedDate", liDto.CreatedDate);
            return query.ExecuteUpdate() > 0;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public bool Update_LI_PrincipalAmount(string lno,decimal principalamount,string sourcebr,int userid,DateTime datetime)
        //{
        //    IQuery query = this.Session.GetNamedQuery("MNMDAO00017.Update_LI_PrincipalAmount");
        //    query.SetString("lno", lno);
        //    query.SetDecimal("principal", principalamount);
        //    query.SetString("sourcebr", sourcebr);
        //    query.SetInt32("updatedUserId", userid);
        //    query.SetDateTime("updatedDate", datetime);
        //    return query.ExecuteUpdate() > 0;
        //}

        public IList<LOMDTO00021> GetLiInfo(string lNo, string sourceBr) //HWH
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.SelectQ4ByLno");
            query.SetString("lno", lNo);
            query.SetString("sourceBr", sourceBr);
            object s =  query.List<LOMDTO00021>();
            return query.List<LOMDTO00021>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLoansInterest(string lNo,string sourceBr,decimal q4Amount,int updateUserId)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQ4ByLNo");
            query.SetString("lno", lNo);
            //query.SetString("budget", budget);
            query.SetString("sourceBr", sourceBr);
            query.SetDecimal("q4", q4Amount);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("UpdatedUserID", updateUserId);
            return query.ExecuteUpdate() > 0;
        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLoanInterestInLI(string loanNo, string currentQtr, decimal returnLaonInterest, string branchCode, int updatedUserId)  //ASDA
        {
            IQuery query;
            if (currentQtr == "Q1")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQ1ByLoanNo");

            }
            else if (currentQtr == "Q2")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQ2ByLoanNo");
            }
            else if (currentQtr == "Q3")
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQ3ByLoanNo");
            }
            else
            {
                query = this.Session.GetNamedQuery("MNMDAO00017.UpdateQ4ByLoanNo");
            }

            query.SetDecimal("returnLaonInterest", returnLaonInterest);
            query.SetString("lno", loanNo);
            query.SetString("SourceBranchCode", branchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);

            return query.ExecuteUpdate() > 0;
        }

        public IList<LOMDTO00021> SelectByAccountNoAndLoanNo(string accountNo, string loanNo, string sourceBr)  //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.SelectByAccountNoAndLoanNo");
            query.SetString("accountNo", accountNo);
            query.SetString("lno", loanNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<LOMDTO00021>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth)  //TAK
        {
            IQuery query = this.Session.GetNamedQuery("MNMORM00017.SelectLiAndLoan");
            query.SetString("year", year);
            //query.SetDateTime("smonth", Smonth);
            //query.SetDateTime("emonth", Emonth);
            return query.List<LOMDTO00021>();
        }
        //public IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth)  //TAK
        //{
        //    IQuery query = this.Session.GetNamedQuery("MNMORM00017.SelectLiAndLoan");
        //    query.SetString("year", year);
        //    query.SetDateTime("smonth", Smonth);
        //    query.SetDateTime("emonth", Emonth);
        //    return query.List<LOMDTO00021>();
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public string UpdateLoanInterest(LOMDTO00021 liList)
        //{
        //    try
        //    {
        //        IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST");
        //        query.SetString("LNO", liList.LNo);
        //        if(DateTime.IsLeapYear(DateTime.Now.Year))
        //            query.SetDecimal("DAYSINYEAR", (366));
        //        else
        //            query.SetDecimal("DAYSINYEAR", (365));
        //        query.SetDateTime("QTRSDATE", liList.StartDate);
        //        query.SetDateTime("QTREDATE", liList.EndDate);
        //        query.SetString("PERIOD", liList.TNo);
        //        query.SetDecimal("RINTEREST", 0);
        //        return query.UniqueResult().ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //}

        [Transaction(TransactionPropagation.Required)]
        public string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST_QUARTERLY");
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetDateTime("QTRSDATE", sDate);
                query.SetDateTime("QTREDATE", eDate);
                Int16 temp = Convert.ToInt16(period);
                query.SetInt16("PERIOD", temp);
                query.SetString("BRANCHCODE", branchCode);
                query.SetDecimal("MESSAGE", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        #region Business Loans
        [Transaction(TransactionPropagation.Required)]
        public string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode)
        {
            try
            {
                //IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST_MONTHLY");
                IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST");
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetDateTime("QTRSDATE", sDate);
                query.SetDateTime("QTREDATE", eDate);
                Int16 temp = Convert.ToInt16(period);
                query.SetInt16("PERIOD", temp);
                query.SetString("BRANCHCODE", branchCode);
                query.SetDecimal("MESSAGE", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string CalculateBusinessLoansInterestForDaily(DateTime sDate, DateTime eDate, string branchCode,int userid)
        {
            try
            {
                //IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST_MONTHLY");
                IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST_DAILY");
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetDateTime("QTRSDATE", sDate);
                query.SetDateTime("QTREDATE", eDate);
                query.SetString("BRANCHCODE", branchCode);
                query.SetString("USERID", branchCode);
                query.SetDecimal("MESSAGE", 0);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00021> SelectLoansInterestByQuater(string qno,string budget,string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_LI9900");
            //query.SetString("SQTRTOTAL", sqtrTotal);
            query.SetString("QNo", qno);
            query.SetString("BudgetYear", budget);
            query.SetString("SourceBr", sourceBr);
            query.SetString("Cur", cur);
            return query.List<LOMDTO00021>();           
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00054> SelectODInterestByQuater(string mno, string budget, string sourceBr, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_MOB3911");
            //query.SetString("SQTRTOTAL", sqtrTotal);
            query.SetString("MNo", mno);
            query.SetString("BudgetYear", budget);
            query.SetString("Cur", cur);
            query.SetString("SourceBr", sourceBr);
            return query.List<LOMDTO00054>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00021> SelectByLoanNo(string accountNo, string loanNo)  //TAK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00017.SelectByLoanNo");
            query.SetString("accountNo", accountNo);
            query.SetString("loanNo", loanNo);
            return query.List<LOMDTO00021>();
        }
    }
}