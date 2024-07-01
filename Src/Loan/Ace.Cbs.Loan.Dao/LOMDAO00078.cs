using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao; 
using NHibernate;   
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00078 : DataRepository<LOMORM00078>, ILOMDAO00078
    {
        public IList<LOMDTO00078> SelectByGroupNo(string groupNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.SelectFarmLoanByGroupNo");
                query.SetString("groupNo", groupNo);
                return query.List<LOMDTO00078>();
            }
            catch { throw; }
        }

        public IList<LOMDTO00078> SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(string acctNo,string lno, DateTime withdrawDate, DateTime repaymentDate)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.SelectFarmLoanByAcctNoAndLNoAndWithdrawDate");
                query.SetString("acctNo", acctNo);
                query.SetString("lNo", lno);
                query.SetDateTime("withdrawDate", withdrawDate);
                query.SetDateTime("repaymentDate", repaymentDate);
                return query.List<LOMDTO00078>();
            }
            catch { throw; }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLastIntDate(DateTime lastIntDate,DateTime updatedDate, int updatedUserId, string lno, string acctno, string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.UpdateLastIntDate");
                query.SetDateTime("lastIntDate", lastIntDate);
                query.SetDateTime("updatedDate", updatedDate);
                query.SetInt32("updatedUserId", updatedUserId);
                query.SetString("lno", lno);
                query.SetString("acctNo", acctno);
                query.SetString("sourceBr", sourceBr);
                return query.ExecuteUpdate() > 0;
            }
            catch { throw; }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00085> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.SelectFarmLIAndFarmLoanForIntCalMonthly");
            query.SetString("year", year);
            query.SetDateTime("smonth", Smonth);
            query.SetDateTime("emonth", Emonth);
            return query.List<LOMDTO00085>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00078> SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(string acctNo, string lno,DateTime emonth)  
        {
            try
            { 
                IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.SelectByLnoAndAcctNoAndWithdrawDate");
                query.SetDateTime("emonth", emonth);
                query.SetString("lno", lno);
                query.SetString("acctNo", acctNo);
                return query.List<LOMDTO00078>();
            }
            catch { throw; }
        }


        #region LoanRepayment Methods
        public IList<LOMDTO00078> getLoanAcctNo(string loanNo, string sourceBr, string type)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Proc_GetAcctNoForLoanRepayment");//StoreProcedure
                query.SetString("LoanNo", loanNo);
                query.SetString("SourceBr", sourceBr);
                query.SetString("type", type);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
                IList<LOMDTO00078> acctNoList = query.List<LOMDTO00078>();
                return acctNoList;
            }
            catch { return null; }
        }

        public bool checkFarmLoan(string loanNo)//Check Loan No is exist in FarmLoan tbl or not
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CheckFarmLoanNo");
                query.SetString("loanNo", loanNo);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
                LOMDTO00078 loanNoResult = query.UniqueResult<LOMDTO00078>();
                if (loanNoResult != null)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public LOMDTO00078 GetLoansAccountInformationWithInterest(string loanNo, string sourceBr)//Get FarmLoan data by LoanNo
        {
            IQuery query = this.Session.GetNamedQuery("SpGetFarmLoanInformationWithInterest");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
            return query.UniqueResult<LOMDTO00078>();
        }

        public LOMDTO00078 RepayFarmLoan(string lno, string accountNo, decimal repaymentAmount, decimal interest, decimal penalties, string userNo, int userId, string sourceBr, string vouno, string accountCreditCode, string interestCode, string penaltiesCode)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_FARMLOAN_REPAYMENT");
                query.SetString("LoanNo", lno);
                query.SetString("AccountNo", accountNo);
                query.SetDecimal("RepayAmount", repaymentAmount);
                query.SetDecimal("Interest", interest);
                query.SetDecimal("Penalties", penalties);
                query.SetString("UserNo", userNo);
                query.SetInt32("UserId", userId);
                query.SetString("BranchCode", sourceBr);
                query.SetString("VoucherNo", vouno);
                query.SetString("AcctCreditCode", accountCreditCode);
                query.SetString("InterestCode", interestCode);
                query.SetString("PenaltiesCode", penaltiesCode);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
                return query.UniqueResult<LOMDTO00078>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public double GetInterestAmount(string LoanNo, string startDate, decimal repaymentAmount, string budgetYear)
        {
            IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_GetInterestCalculationByDate");
            query.SetString("LNO", LoanNo);
            query.SetDecimal("REPAYAMU", repaymentAmount);
            query.SetString("SDate", startDate);
            query.SetString("Endate", DateTime.Now.ToString("yyyy/MM/dd"));
            query.SetString("CurBudYear", budgetYear);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
            LOMDTO00078 result = query.UniqueResult<LOMDTO00078>();
            return Convert.ToDouble(result.InterestAmount);
        }

        public double GetPenalFee(string LoanNo, decimal repaymentAmount, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_FarmLoan_GetPenalFee");
            query.SetString("LNO", LoanNo);
            query.SetDecimal("REPAYAMU", repaymentAmount);
            query.SetString("SourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
            LOMDTO00078 result = query.UniqueResult<LOMDTO00078>();
            return Convert.ToDouble(result.InterestAmount);
        }

        public double GetHomeAmount(string vrNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_GetHomeAmountByVrNo");
                query.SetString("vrNo", vrNo);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00078)));
                LOMDTO00078 result = query.UniqueResult<LOMDTO00078>();
                return Convert.ToDouble(result.InterestAmount);
            }
            catch { throw; }
        }
        #endregion


        public LOMDTO00078 GetFarmLoansByLnoAndSourceBr(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.GetFarmLoansByLnoAndSourceBr");
            query.SetString("lno", loanNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<LOMDTO00078>();
        }

        public bool UpdateFarmLoanByLnoAndSourceBr(LOMDTO00078 loanDto)
        {
            IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.UpdateFarmLoanByLnoAndSourceBr");
            query.SetString("name", loanDto.Name);
            query.SetString("fatherName", loanDto.FatherName);
            query.SetString("nrc", loanDto.NRC);
            query.SetString("village", loanDto.Village);
            query.SetString("township", loanDto.Township);
            query.SetString("address", loanDto.Address);
            query.SetString("farmName", loanDto.FarmName);
            query.SetString("landNo", loanDto.LandNo);
            query.SetString("landType", loanDto.LandType);
            query.SetString("seasonType", loanDto.SeasonType);
            query.SetString("businessType", loanDto.BusinessType);
            query.SetString("loanProductType", loanDto.LoanProductType);
            query.SetString("groupNo", loanDto.GroupNo);
            query.SetDecimal("intRate", String.IsNullOrEmpty(loanDto.IntRate.ToString()) ? 0 : Convert.ToDecimal(loanDto.IntRate));
            query.SetDecimal("penalties", String.IsNullOrEmpty(loanDto.Penalties.ToString()) ? 0 : Convert.ToDecimal(loanDto.Penalties));
            query.SetString("startPeriod", loanDto.StartPeriod); 
            query.SetString("endPeriod", loanDto.EndPeriod);
            query.SetDateTime("withdrawDate", Convert.ToDateTime(loanDto.WithdrawDate));
            query.SetDateTime("expireDate", Convert.ToDateTime(loanDto.ExpireDate));
            query.SetDecimal("loanAmtPerAcre", String.IsNullOrEmpty(loanDto.LoanAmtPerAcre.ToString()) ? 0 : Convert.ToDecimal(loanDto.LoanAmtPerAcre));
            query.SetDecimal("totalAcre", String.IsNullOrEmpty(loanDto.TotalAcre.ToString()) ? 0 : Convert.ToDecimal(loanDto.TotalAcre));
            query.SetDecimal("sAmt", String.IsNullOrEmpty(loanDto.SAmt.ToString()) ? 0 : Convert.ToDecimal(loanDto.SAmt));
            query.SetString("lno", loanDto.Lno);
            query.SetString("sourceBr", loanDto.SourceBr);
            query.SetBinary("farmSign", (System.Byte[])loanDto.FarmSignature);
            query.SetBinary("cusSign", (System.Byte[])loanDto.Signature);
            query.SetDateTime("updatedDate", (DateTime)loanDto.UpdatedDate);
            query.SetInt32("updatedUserId", (int)loanDto.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public IList<LOMDTO00078> CheckDataForDeleteLSProductType(string landType,string businessType)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("FarmLoanDAO.SelectFarmLoanByLandTypeAndBusinessType");
                query.SetString("landType", landType);
                query.SetString("businessType", businessType);
                return query.List<LOMDTO00078>();
            }
            catch { throw; }
        }

    }
}
