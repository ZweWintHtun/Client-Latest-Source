using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00089 : BaseService,ILOMSVE00089
    {
        #region Properties

        ILOMDAO00085 FarmLiDAO { get; set; }
        ILOMDAO00078 FarmLoanDAO { get; set; }

        #endregion

        #region Methods

        [Transaction(TransactionPropagation.Required)]
        public void CalculateInterest(DateTime withdrawDate, DateTime repaymentDate)
        {
            IList<LOMDTO00085> FarmLIList = this.FarmLiDAO.SelectAcctNoWhoseCloseDateIsNull(CurrentUserEntity.BranchCode);//Get Account No from Farm_LI where closedate is NULL
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

                    DateTime WithdrawStartDate = withdrawDate.AddDays(-1);

                    IList<LOMDTO00078> FarmLoanList = this.FarmLoanDAO.SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(FarmLIList[i].AcctNo, FarmLIList[i].LNo,
                        WithdrawStartDate, repaymentDate);
                    if (FarmLoanList.Count > 0)
                    {                        
                        //For Same Month Withdraw and Repayment Date
                        if(withdrawDate.Month == repaymentDate.Month)
                        {
                            MCount = 1;
                        }
                        //Loop For Interest Duration
                        while (WithdrawStartDate < repaymentDate)
                        {
                            NextMonthDate = WithdrawStartDate.AddMonths(1);

                            //Calculte Int for pre_months
                            if (NextMonthDate >= repaymentDate)
                            {
                                DayCount = (int)((NextMonthDate - repaymentDate).TotalDays);
                                //This is for within one month repayment case less than equal 15 days
                                if (withdrawDate.Month == repaymentDate.Month && DayCount < 15)
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt) * (decimal)(13.00 / 2400);
                                }
                                //This is for within one month repayment case greater than 15 days (take one month interest)
                                else
                                {
                                    FirstIntAmu = (decimal)(FarmLoanList[0].SAmt * MCount) * (decimal)(13.00 / 1200);
                                }
                            }
                            MCount =MCount + 1;
                            WithdrawStartDate = NextMonthDate;
                        }//end of while loop

                        //Calculate For Last Days Interest
                        if (withdrawDate.Month != repaymentDate.Month)
                        {
                            PrevMonthDate = WithdrawStartDate.AddMonths(-1);
                            IntDay = (int)(repaymentDate - PrevMonthDate).TotalDays;
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
                        int TotalDays = (int)(repaymentDate.AddDays(1)  - FarmLoanList[0].WithdrawDate.Value.AddDays(-1)).TotalDays;
                        LastIntAmu = (TotalIntAmu / TotalDays);

                        LOMDTO00085 farmLiDtoForUpdate = FarmLIList[i];
                        farmLiDtoForUpdate.TotalInt = TotalIntAmu;
                        farmLiDtoForUpdate.LastInt = LastIntAmu;
                      
                        //int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, WithdrawStartDate));
                        
                        //string currentMonth = "M" + Convert.ToString(initialMonth);

                        if (!this.FarmLiDAO.UpdateFarmLoanInterest((decimal)farmLiDtoForUpdate.TotalInt, (decimal)farmLiDtoForUpdate.LastInt, (decimal)farmLiDtoForUpdate.M1, (decimal)farmLiDtoForUpdate.M2,
                            (decimal)farmLiDtoForUpdate.M3, (decimal)farmLiDtoForUpdate.M4, (decimal)farmLiDtoForUpdate.M5, (decimal)farmLiDtoForUpdate.M6, (decimal)farmLiDtoForUpdate.M7,
                            (decimal)farmLiDtoForUpdate.M8, (decimal)farmLiDtoForUpdate.M9, (decimal)farmLiDtoForUpdate.M10, (decimal)farmLiDtoForUpdate.M11, (decimal)farmLiDtoForUpdate.M12,
                            DateTime.Now,CurrentUserEntity.CurrentUserID, farmLiDtoForUpdate.LNo, farmLiDtoForUpdate.AcctNo, farmLiDtoForUpdate.SourceBr) ||
                            !this.FarmLoanDAO.UpdateLastIntDate(DateTime.Now,DateTime.Now,CurrentUserEntity.CurrentUserID,farmLiDtoForUpdate.LNo,farmLiDtoForUpdate.AcctNo,farmLiDtoForUpdate.SourceBr))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30006";//Saving Interest Fail.
                        }
                    }
                }//end of for loop
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI30005";//Saving Interest Successful
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI90076"; //No Record to Calculate Interest.
            }
        }

        #endregion
    }
}
