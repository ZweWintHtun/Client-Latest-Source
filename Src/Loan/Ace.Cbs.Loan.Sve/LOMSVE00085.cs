using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00085 : BaseService, ILOMSVE00085
    {
        #region Properties

        string Edate, Sdate;
        string mth, qmth;
        IList<string> MessageList = new List<string>();

        ILOMDAO00085 FarmLiDAO { get; set; }
        ILOMDAO00078 FarmLoanDAO { get; set; }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public void CalculateInterestMonthly(string budgetyear, DateTime startDate, DateTime endDate)
        {
            //IList<LOMDTO00085> farmliList = this.FarmLoanDAO.CheckIntCalculateDate(budgetyear, startDate, endDate);
            IList<LOMDTO00085> FarmLIList = this.FarmLiDAO.SelectAcctNoWhoseCloseDateIsNullAndBudgetYear(CurrentUserEntity.BranchCode,budgetyear);//Get Account No from Farm_LI where closedate is NULL and budget year is between selected budget year
            if (FarmLIList.Count > 0)
            {
                for (int i = 0; i < FarmLIList.Count; i++)
                {
                    int MCount = 0;
                    DateTime NextMonthDate;
                    DateTime PrevMonthDate;
                    int DayCount = 0;
                    decimal FirstIntAmu = 0;
                    decimal SecIntAmu = 0;
                    decimal TotalIntAmu = 0;
                    decimal LastIntAmu = 0;
                    int IntDay = 0;

                    IList<LOMDTO00078> FarmLoanList = this.FarmLoanDAO.SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(FarmLIList[i].AcctNo, FarmLIList[i].LNo,endDate);
                    if (FarmLoanList.Count > 0)
                    {
                        DateTime withdrawDate = Convert.ToDateTime(FarmLoanList[0].WithdrawDate);
                        DateTime WithdrawStartDate = withdrawDate.AddDays(-1);
                        //For Same Month Withdraw and Interest Calculate Month
                        if (withdrawDate.Month == endDate.Month)
                        {
                            MCount = 1;
                        }
                        //Loop For Interest Duration
                        while (WithdrawStartDate < endDate)
                        {
                            NextMonthDate = WithdrawStartDate.AddMonths(1);

                            //Calculte Int for pre_months
                            if (NextMonthDate >= endDate)
                            {
                                DayCount = (int)((NextMonthDate - endDate).TotalDays);
                                //This is for within one month repayment case less than equal 15 days
                                if (withdrawDate.Month == endDate.Month && DayCount < 15)
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 2400);
                                }
                                //This is for within one month repayment case greater than 15 days (take one month interest)
                                else
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt * MCount) * (decimal)(13.00 / 1200);
                                }
                            }
                            MCount = MCount + 1;
                            WithdrawStartDate = NextMonthDate;
                        }//end of while loop

                        //Calculate For Last Days Interest
                        if (withdrawDate.Month != endDate.Month)
                        {
                            PrevMonthDate = WithdrawStartDate.AddMonths(-1);
                            IntDay = (int)(endDate - PrevMonthDate).TotalDays;
                            if (IntDay > 15)
                            {
                                SecIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 1200);
                            }
                            else
                            {
                                SecIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 2400);
                            }
                        }
                        TotalIntAmu = FirstIntAmu + SecIntAmu;
                        int TotalDays = (int)(endDate.AddDays(1) - FarmLoanList[0].WithdrawDate.Value.AddDays(-1)).TotalDays;
                        LastIntAmu = (TotalIntAmu / TotalDays);

                        LOMDTO00085 farmLiDtoForUpdate = FarmLIList[i];
                        int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(farmLiDtoForUpdate.Budget, endDate));
                        string intMonth = "M" + Convert.ToString(initialMonth);
                        int daysInMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month);
                        switch (intMonth)
                        {
                            case "M1":
                                farmLiDtoForUpdate.M1 = LastIntAmu * daysInMonth;
                                break;
                            case "M2":
                                farmLiDtoForUpdate.M2 = LastIntAmu * daysInMonth;
                                break;
                            case "M3":
                                farmLiDtoForUpdate.M3 = LastIntAmu * daysInMonth;
                                break;
                            case "M4":
                                farmLiDtoForUpdate.M4 = LastIntAmu * daysInMonth;
                                break;
                            case "M5":
                                farmLiDtoForUpdate.M5 = LastIntAmu * daysInMonth;
                                break;
                            case "M6":
                                farmLiDtoForUpdate.M6 = LastIntAmu * daysInMonth;
                                break;
                            case "M7":
                                farmLiDtoForUpdate.M7 = LastIntAmu * daysInMonth;
                                break;
                            case "M8":
                                farmLiDtoForUpdate.M8 = LastIntAmu * daysInMonth;
                                break;
                            case "M9":
                                farmLiDtoForUpdate.M9 = LastIntAmu * daysInMonth;
                                break;
                            case "M10":
                                farmLiDtoForUpdate.M10 = LastIntAmu * daysInMonth;
                                break;
                            case "M11":
                                farmLiDtoForUpdate.M11 = LastIntAmu * daysInMonth;
                                break;
                            case "M12":
                                farmLiDtoForUpdate.M12 = LastIntAmu * daysInMonth;
                                break;
                        }
                        if (!this.FarmLiDAO.UpdateFarmLoanInterest((decimal)farmLiDtoForUpdate.TotalInt, (decimal)farmLiDtoForUpdate.LastInt, (decimal)farmLiDtoForUpdate.M1, (decimal)farmLiDtoForUpdate.M2,
                            (decimal)farmLiDtoForUpdate.M3, (decimal)farmLiDtoForUpdate.M4, (decimal)farmLiDtoForUpdate.M5, (decimal)farmLiDtoForUpdate.M6, (decimal)farmLiDtoForUpdate.M7,
                            (decimal)farmLiDtoForUpdate.M8, (decimal)farmLiDtoForUpdate.M9, (decimal)farmLiDtoForUpdate.M10, (decimal)farmLiDtoForUpdate.M11, (decimal)farmLiDtoForUpdate.M12,
                            DateTime.Now, CurrentUserEntity.CurrentUserID, farmLiDtoForUpdate.LNo, farmLiDtoForUpdate.AcctNo, farmLiDtoForUpdate.SourceBr) ||
                            !this.FarmLoanDAO.UpdateLastIntDate(DateTime.Now, DateTime.Now, CurrentUserEntity.CurrentUserID, farmLiDtoForUpdate.LNo, farmLiDtoForUpdate.AcctNo, farmLiDtoForUpdate.SourceBr))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30006";//Saving Interest Fail.
                        }
                    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                }//end of for loop
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI90076"; //No Record to Calculate Interest.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void CalculateInterestFromMonthToMonth(string budgetyear, DateTime startDate, DateTime endDate)
        {
            IList<LOMDTO00085> FarmLIList = this.FarmLiDAO.SelectAcctNoWhoseCloseDateIsNullAndBudgetYear(CurrentUserEntity.BranchCode, budgetyear);//Get Account No from Farm_LI where closedate is NULL and budget year is between selected budget year
            if (FarmLIList.Count > 0)
            {
                for (int i = 0; i < FarmLIList.Count; i++)
                {
                    int MCount = 0;
                    DateTime NextMonthDate;
                    DateTime PrevMonthDate;
                    int DayCount = 0;
                    decimal FirstIntAmu = 0;
                    decimal SecIntAmu = 0;
                    decimal TotalIntAmu = 0;
                    decimal LastIntAmu = 0;
                    int IntDay = 0;

                    IList<LOMDTO00078> FarmLoanList = this.FarmLoanDAO.SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(FarmLIList[i].AcctNo, FarmLIList[i].LNo, endDate);
                    if (FarmLoanList.Count > 0)
                    {
                        DateTime withdrawDate = Convert.ToDateTime(FarmLoanList[0].WithdrawDate);
                        DateTime WithdrawStartDate = withdrawDate.AddDays(-1);
                        //For Same Month Withdraw and Interest Calculate Month
                        if (withdrawDate.Month == endDate.Month)
                        {
                            MCount = 1;
                        }
                        //Loop For Interest Duration
                        while (WithdrawStartDate < endDate)
                        {
                            NextMonthDate = WithdrawStartDate.AddMonths(1);

                            //Calculte Int for pre_months
                            if (NextMonthDate >= endDate)
                            {
                                DayCount = (int)((NextMonthDate - endDate).TotalDays);
                                //This is for within one month repayment case less than equal 15 days
                                if (withdrawDate.Month == endDate.Month && DayCount < 15)
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 2400);
                                }
                                //This is for within one month repayment case greater than 15 days (take one month interest)
                                else
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt * MCount) * (decimal)(13.00 / 1200);
                                }
                            }
                            MCount = MCount + 1;
                            WithdrawStartDate = NextMonthDate;
                        }//end of while loop

                        //Calculate For Last Days Interest
                        if (withdrawDate.Month != endDate.Month)
                        {
                            PrevMonthDate = WithdrawStartDate.AddMonths(-1);
                            IntDay = (int)(endDate.AddDays(1) - PrevMonthDate).TotalDays;
                            if (IntDay > 15)
                            {
                                SecIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 1200);
                            }
                            else
                            {
                                SecIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 2400);
                            }
                        }

                        TotalIntAmu = FirstIntAmu + SecIntAmu;
                        int TotalDays = (int)(endDate.AddDays(2) - FarmLoanList[0].WithdrawDate.Value.AddDays(-1)).TotalDays;
                        LastIntAmu = (TotalIntAmu / TotalDays);

                        int MonthCount = 0;
                        DateTime tempDate;
                        DateTime tempDate2;
                        if (FarmLoanList[0].WithdrawDate.Value > startDate)
                        {
                            tempDate = FarmLoanList[0].WithdrawDate.Value.AddDays(-1);
                            tempDate2 = FarmLoanList[0].WithdrawDate.Value.AddDays(-1);
                        }
                        else
                        {
                            tempDate = startDate;
                            tempDate2 = startDate;
                        }
                        
                        while(tempDate < endDate)
                        {
                            MonthCount++;
                            tempDate = tempDate.AddMonths(1);
                        }

                        
                        LOMDTO00085 farmLiDtoForUpdate = FarmLIList[i];
                        for (int j = 0; j < MonthCount; j++)
                        {
                            int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(farmLiDtoForUpdate.Budget, tempDate2));
                            string intMonth = "M" + Convert.ToString(initialMonth);
                            int daysInMonth = 0;

                            if (tempDate2.Day > 1)
                            {
                                int edtDate = DateTime.DaysInMonth(tempDate2.Year, tempDate2.Month);
                                daysInMonth = edtDate - tempDate2.Day;
                                tempDate2 = Convert.ToDateTime(tempDate2.Month + "/01/" + tempDate2.Year);
                            }
                            else if(tempDate2.Day == 1)
                            {
                                daysInMonth = DateTime.DaysInMonth(tempDate2.Year, tempDate2.Month);
                            }
                            
                            switch (intMonth)
                            {
                                case "M1":
                                    farmLiDtoForUpdate.M1 = LastIntAmu * daysInMonth;
                                    break;
                                case "M2":
                                    farmLiDtoForUpdate.M2 = LastIntAmu * daysInMonth;
                                    break;
                                case "M3":
                                    farmLiDtoForUpdate.M3 = LastIntAmu * daysInMonth;
                                    break;
                                case "M4":
                                    farmLiDtoForUpdate.M4 = LastIntAmu * daysInMonth;
                                    break;
                                case "M5":
                                    farmLiDtoForUpdate.M5 = LastIntAmu * daysInMonth;
                                    break;
                                case "M6":
                                    farmLiDtoForUpdate.M6 = LastIntAmu * daysInMonth;
                                    break;
                                case "M7":
                                    farmLiDtoForUpdate.M7 = LastIntAmu * daysInMonth;
                                    break;
                                case "M8":
                                    farmLiDtoForUpdate.M8 = LastIntAmu * daysInMonth;
                                    break;
                                case "M9":
                                    farmLiDtoForUpdate.M9 = LastIntAmu * daysInMonth;
                                    break;
                                case "M10":
                                    farmLiDtoForUpdate.M10 = LastIntAmu * daysInMonth;
                                    break;
                                case "M11":
                                    farmLiDtoForUpdate.M11 = LastIntAmu * daysInMonth;
                                    break;
                                case "M12":
                                    farmLiDtoForUpdate.M12 = LastIntAmu * daysInMonth;
                                    break;
                            }
                            tempDate2 = tempDate2.AddMonths(1);
                        }                        
                        if (!this.FarmLiDAO.UpdateFarmLoanInterest((decimal)farmLiDtoForUpdate.TotalInt, (decimal)farmLiDtoForUpdate.LastInt, (decimal)farmLiDtoForUpdate.M1, (decimal)farmLiDtoForUpdate.M2,
                            (decimal)farmLiDtoForUpdate.M3, (decimal)farmLiDtoForUpdate.M4, (decimal)farmLiDtoForUpdate.M5, (decimal)farmLiDtoForUpdate.M6, (decimal)farmLiDtoForUpdate.M7,
                            (decimal)farmLiDtoForUpdate.M8, (decimal)farmLiDtoForUpdate.M9, (decimal)farmLiDtoForUpdate.M10, (decimal)farmLiDtoForUpdate.M11, (decimal)farmLiDtoForUpdate.M12,
                            DateTime.Now, CurrentUserEntity.CurrentUserID, farmLiDtoForUpdate.LNo, farmLiDtoForUpdate.AcctNo, farmLiDtoForUpdate.SourceBr) ||
                            !this.FarmLoanDAO.UpdateLastIntDate(DateTime.Now, DateTime.Now, CurrentUserEntity.CurrentUserID, farmLiDtoForUpdate.LNo, farmLiDtoForUpdate.AcctNo, farmLiDtoForUpdate.SourceBr))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30006";//Saving Interest Fail.
                        }
                    }
                }//end of for loop
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI90076"; //No Record to Calculate Interest.
            }
        }

        //New Logic (Updated Date - 23/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestMonthly(IList<LOMDTO00085> farmLiList,DateTime startDate, DateTime endDate,string butgetyear)
        {
            int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(butgetyear, endDate));
            string intMonth = "M" + Convert.ToString(initialMonth);
            string sMonthDate = startDate.ToString("yyyy/MM/dd");
            string eMonthDate = endDate.ToString("yyyy/MM/dd");
            for (int i = 0; i < farmLiList.Count; i++)
            {
                this.FarmLiDAO.CalculateFarmLoanInterestMonthly(farmLiList[i].LNo, sMonthDate, eMonthDate, intMonth);
            }
            return true;
        }

        //New Logic (Updated Date - 27/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestByMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate)
        {
            string sMonthDate = startDate.ToString("yyyy/MM/dd");
            string eMonthDate = endDate.ToString("yyyy/MM/dd");
            for (int i = 0; i < farmLiList.Count; i++)
            {
                this.FarmLiDAO.CalculateFarmLoanInterestByMonth(farmLiList[i].LNo, sMonthDate, eMonthDate);
            }
            return true;
        }

        //New Logic (Updated Date - 27/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestByDate(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate)
        {
            string sMonthDate = startDate.ToString("yyyy/MM/dd");
            string eMonthDate = endDate.ToString("yyyy/MM/dd");
            for (int i = 0; i < farmLiList.Count; i++)
            {
                this.FarmLiDAO.CalculateFarmLoanInterestByDate(farmLiList[i].LNo, sMonthDate, eMonthDate);
            }
            return true;
        }

        public IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear)
        {
            IList<LOMDTO00085> liList = this.FarmLiDAO.SelectAcctNoWhoseCloseDateIsNullAndBudgetYear(sourceBr,budgetYear);
            return liList;
        }

        public IList<LOMDTO00085> SelectFarmLiInfoByLnoAndSourceBr(string lno, string sourceBr)
        {
            IList<LOMDTO00085> liList = this.FarmLiDAO.SelectFarmLiInfoByLnoAndSourceBr(lno, sourceBr);
            return liList;
        }

    }
}
