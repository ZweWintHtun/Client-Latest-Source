using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00092 : BaseService, ILOMSVE00092
    {
        private ILOMDAO00078 loanRepaymentDAO;
        public ILOMDAO00078 LoanRepaymentDAO
        {
            get { return this.loanRepaymentDAO; }
            set { this.loanRepaymentDAO = value; }
        }

        public LOMDTO00078 FarmLoanDataByLoanNo { get; set; }
        public LOMDTO00078 FarmLoanDTO { get; set; }
        public string rePayNo { get; set; }
        private ICXSVE00002 CodeGenerator { get; set; }

        /* Check Vr No is exist in FarmLoan or not*/
        public bool checkFarmLoan(string loanNo)
        {
            try { return this.LoanRepaymentDAO.checkFarmLoan(loanNo); }
            catch { return false; }
        }

        public LOMDTO00078 isValidLoanNo(string lno, string sourceBr)
        {
            LOMDTO00078 LoanDTO = LoanRepaymentDAO.GetLoansAccountInformationWithInterest(lno, sourceBr);
            FarmLoanDataByLoanNo = LoanDTO;

            return LoanDTO;
        }

        public LOMDTO00078 RepayFarmLoan(LOMDTO00078 farmLoanDTO, string lno, string accountNo, decimal repaymentAmount, decimal interest, decimal penalties, string userNo, int userId, string sourceBr, string accountCreditCode, string interestCode, string penaltiesCode)
        {
            string voucherNo="";
            try
            {                
                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), farmLoanDTO.SourceBr, true });
              
                string day = sys001.Day.ToString().PadLeft(2, '0');
                string month = sys001.Month.ToString().PadLeft(2, '0');
                string year = sys001.Year.ToString().Substring(2);
                int updatedUserId = farmLoanDTO.CreatedUserId;

                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, farmLoanDTO.SourceBr, new object[] { day, month, year });


                FarmLoanDTO = LoanRepaymentDAO.RepayFarmLoan(lno, accountNo, repaymentAmount, interest, penalties, userNo, userId, sourceBr, voucherNo, accountCreditCode, interestCode, penaltiesCode);

                if (FarmLoanDTO == null || FarmLoanDTO.ResultCode == "0001")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90055.ToString(); //Invalid Loan No.
                    return null;
                }

                else if (FarmLoanDTO.ResultCode == "0002")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90056; // Loans Account Only 
                    return null;
                }

                else if (FarmLoanDTO.ResultCode == "0003")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90056; // Not Vouchered Yet 
                    return null;
                }

                else if (FarmLoanDTO.ResultCode == "0004")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90056; // Loans Account Closed 
                    return null;
                }              
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI90026; //Invalid Loan No.
            }
            FarmLoanDTO.RepaymentNo = voucherNo;
            return FarmLoanDTO;
        }

        public IList<LOMDTO00078> getLoanAcctNo(string loanNo, string sourceBr, string type)
        {
            try
            {
                return this.LoanRepaymentDAO.getLoanAcctNo(loanNo, sourceBr, type);
            }
            catch { return null; }
        }

        public double GetInterestAmount(string LoanNo, string startDate, decimal repaymentAmount, string budgetYear)
        {
            return this.LoanRepaymentDAO.GetInterestAmount(LoanNo, startDate, repaymentAmount, budgetYear);
        }

        public double GetPenalFee(string LoanNo, decimal repaymentAmount, string sourceBr)
        {
            return this.LoanRepaymentDAO.GetPenalFee(LoanNo, repaymentAmount, sourceBr);
        }

        public double GetHomeAmount(string vrNo)
        {
            return this.LoanRepaymentDAO.GetHomeAmount(vrNo);
        }
    }
}
