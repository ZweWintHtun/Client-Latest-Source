using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00016 :  BaseService, ILOMSVE00016
    {
        public ICXSVE00006 CodeChecker { get; set; }
        public IMNMDAO00012 LegalIntDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public ITLMDAO00018 LoansDAO { get; set; }
        public ICXDAO00010 DatagenerateDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        public IMNMDAO00027 SChargeDAO { get; set; }
        public ILOMDAO00013 LegalDAO { get; set; }
        public IMNMDAO00017 LIDAO { get; set; }
        public IMNMDAO00008 OIDAO { get; set; }

        
        #region LegalCase Method

        public IList<PFMDTO00072> CheckCustomerInformation(string accountNo, string sourceBr)
        {
            IList<PFMDTO00072> GetCustomerInfo = CodeChecker.GetCurrentAccountInfoByAccountNumber(accountNo);
            return GetCustomerInfo;
        }

        public IList<MNMDTO00012> GetLegalIntList(string[] typelist,string loanNo, string branchCode)
        {
            IList<MNMDTO00012> LegalIntList = LegalIntDAO.SelectLegalIntList(typelist, loanNo, branchCode);
            return LegalIntList;
        }

        public PFMDTO00033 GetAccountInfoFromCledgerAndBal(string BudYear, DateTime EndOfMonth, string accountNo, string sourceBr)
        {
            PFMDTO00033 LoanAccountBalance = CledgerDAO.SelectAccountInfoFromCledgerAndBal(BudYear, EndOfMonth, accountNo, sourceBr);
            return LoanAccountBalance;
        }

        public IList<TLMDTO00018> GetLoansAccountInfoByAccountNo(string accountNo, string sourceBr)
        {
            IList<TLMDTO00018> LoansAccountInfoByAccountNo = LoansDAO.SelectLoansAccountInfoByAccountNo(accountNo, sourceBr);
            return LoansAccountInfoByAccountNo;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool GetLoanInterestAndUpdateLI(string loanNo, int daysInYear, DateTime qStartDate, DateTime qEndDate, int period, decimal amount, string curQtr , string sourceBr, int updatedUserId)
        {
            try
            {
                IList<LOMDTO00021> LI_Info = this.LIDAO.SelectLiInfoForLoanInterest(loanNo, sourceBr);
                
                if (LI_Info.Count == 0 || LI_Info == null)
                    throw new Exception(CXMessage.MV90070); //Require A/C No. is not available in Loans Int. file
                
                var query = from LOMDTO00021 li in LI_Info
                            orderby li.TNo descending
                            select li;
                LOMDTO00021 topLiInfo = query.First();

                Nullable<decimal> loanInterest = DatagenerateDAO.SP_LOANINTEREST_NewLogic(loanNo, daysInYear, qStartDate, qEndDate,topLiInfo.TNo,0,sourceBr,updatedUserId);
                if (loanInterest != null)
                {
                    this.ServiceResult.ErrorOccurred = false;
                    //LIDAO.UpdateLoanInterestInLI(loanNo, curQtr, loanInterest.Value, sourceBr, updatedUserId); //("Update Li Set " & CurQtr & " = " & Format(MInterest, "############.#0")                                                       
                    //LIDAO.UpdateLoanInterestInLI(loanNo, topLiInfo.TNo, loanInterest.Value, sourceBr, updatedUserId); //("Update Li Set " & CurQtr & " = " & Format(MInterest, "############.#0")                                                       
                    return true;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90070;  //Require A/C No. is not available in Loans Int. file
                    return false;
                }                
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                return false;
                throw new Exception(ex.Message);
            }            
        }

        public IList<LOMDTO00021> GetLI_Info(string accountNo, string loanNo, string sourceBr)
        {
            IList<LOMDTO00021> LiInfo = LIDAO.SelectByAccountNoAndLoanNo(accountNo, loanNo, sourceBr);
            return LiInfo;
        }

        public MNMDTO00008 GetOI_Info(string accountNo, string loanNo, string mMonth, string sourceBr)
        {
            MNMDTO00008 oiInfo = OIDAO.SelectByAccountNoAndLoanNo(accountNo, loanNo, sourceBr);
            if (oiInfo != null)
            {
                string[] mMonthArray = mMonth.Split('+');
                if (mMonthArray.Count() == 0)
                {
                    switch (mMonth)
                    {
                        case "M1": oiInfo.Total_Interest = oiInfo.M1; break;
                        case "M2": oiInfo.Total_Interest = oiInfo.M2; break;
                        case "M3": oiInfo.Total_Interest = oiInfo.M3; break;
                        case "M4": oiInfo.Total_Interest = oiInfo.M4; break;
                        case "M5": oiInfo.Total_Interest = oiInfo.M5; break;
                        case "M6": oiInfo.Total_Interest = oiInfo.M6; break;
                        case "M7": oiInfo.Total_Interest = oiInfo.M7; break;
                        case "M8": oiInfo.Total_Interest = oiInfo.M8; break;
                        case "M9": oiInfo.Total_Interest = oiInfo.M9; break;
                        case "M10": oiInfo.Total_Interest = oiInfo.M10; break;
                        case "M11": oiInfo.Total_Interest = oiInfo.M11; break;
                        case "M12": oiInfo.Total_Interest = oiInfo.M12; break;
                    }
                }
                else if (mMonthArray.Count() == 2)
                {
                    decimal firstMonth = 0;
                    decimal secondMonth = 0;

                    switch (mMonthArray[0].ToString())
                    {
                        case "M1": firstMonth = oiInfo.M1; break;
                        case "M2": firstMonth = oiInfo.M2; break;
                        case "M3": firstMonth = oiInfo.M3; break;
                        case "M4": firstMonth = oiInfo.M4; break;
                        case "M5": firstMonth = oiInfo.M5; break;
                        case "M6": firstMonth = oiInfo.M6; break;
                        case "M7": firstMonth = oiInfo.M7; break;
                        case "M8": firstMonth = oiInfo.M8; break;
                        case "M9": firstMonth = oiInfo.M9; break;
                        case "M10": firstMonth = oiInfo.M10; break;
                        case "M11": firstMonth = oiInfo.M11; break;
                        case "M12": firstMonth = oiInfo.M12; break;
                    }
                    switch (mMonthArray[1].ToString())
                    {
                        case "M1": secondMonth = oiInfo.M1; break;
                        case "M2": secondMonth = oiInfo.M2; break;
                        case "M3": secondMonth = oiInfo.M3; break;
                        case "M4": secondMonth = oiInfo.M4; break;
                        case "M5": secondMonth = oiInfo.M5; break;
                        case "M6": secondMonth = oiInfo.M6; break;
                        case "M7": secondMonth = oiInfo.M7; break;
                        case "M8": secondMonth = oiInfo.M8; break;
                        case "M9": secondMonth = oiInfo.M9; break;
                        case "M10": secondMonth = oiInfo.M10; break;
                        case "M11": secondMonth = oiInfo.M11; break;
                        case "M12": secondMonth = oiInfo.M12; break;
                    }
                    oiInfo.Total_Interest = firstMonth + secondMonth;
                }

                else if (mMonthArray.Count() == 2)
                {
                    decimal firstMonth = 0;
                    decimal secondMonth = 0;
                    decimal thirdMonth = 0;

                    switch (mMonthArray[0].ToString())
                    {
                        case "M1": firstMonth = oiInfo.M1; break;
                        case "M2": firstMonth = oiInfo.M2; break;
                        case "M3": firstMonth = oiInfo.M3; break;
                        case "M4": firstMonth = oiInfo.M4; break;
                        case "M5": firstMonth = oiInfo.M5; break;
                        case "M6": firstMonth = oiInfo.M6; break;
                        case "M7": firstMonth = oiInfo.M7; break;
                        case "M8": firstMonth = oiInfo.M8; break;
                        case "M9": firstMonth = oiInfo.M9; break;
                        case "M10": firstMonth = oiInfo.M10; break;
                        case "M11": firstMonth = oiInfo.M11; break;
                        case "M12": firstMonth = oiInfo.M12; break;
                    }
                    switch (mMonthArray[1].ToString())
                    {
                        case "M1": secondMonth = oiInfo.M1; break;
                        case "M2": secondMonth = oiInfo.M2; break;
                        case "M3": secondMonth = oiInfo.M3; break;
                        case "M4": secondMonth = oiInfo.M4; break;
                        case "M5": secondMonth = oiInfo.M5; break;
                        case "M6": secondMonth = oiInfo.M6; break;
                        case "M7": secondMonth = oiInfo.M7; break;
                        case "M8": secondMonth = oiInfo.M8; break;
                        case "M9": secondMonth = oiInfo.M9; break;
                        case "M10": secondMonth = oiInfo.M10; break;
                        case "M11": secondMonth = oiInfo.M11; break;
                        case "M12": secondMonth = oiInfo.M12; break;
                    }
                    switch (mMonthArray[2].ToString())
                    {
                        case "M1": thirdMonth = oiInfo.M1; break;
                        case "M2": thirdMonth = oiInfo.M2; break;
                        case "M3": thirdMonth = oiInfo.M3; break;
                        case "M4": thirdMonth = oiInfo.M4; break;
                        case "M5": thirdMonth = oiInfo.M5; break;
                        case "M6": thirdMonth = oiInfo.M6; break;
                        case "M7": thirdMonth = oiInfo.M7; break;
                        case "M8": thirdMonth = oiInfo.M8; break;
                        case "M9": thirdMonth = oiInfo.M9; break;
                        case "M10": thirdMonth = oiInfo.M10; break;
                        case "M11": thirdMonth = oiInfo.M11; break;
                        case "M12": thirdMonth = oiInfo.M12; break;
                    }
                    oiInfo.Total_Interest = firstMonth + secondMonth + thirdMonth;
                }
                return oiInfo;
            }
            else { return null; }                       
        }

        [Transaction(TransactionPropagation.Required)]
        public LOMDTO00021 CalculateLoanScharge(string loanNo, int daysInYear, DateTime startDate, DateTime endDate, string termNo,string sourceBr, int updatedUserId)
        {
            Nullable<decimal> loanScharge = this.DatagenerateDAO.SP_LoanScharge_NewLogic(loanNo, daysInYear, startDate, endDate, termNo, updatedUserId,sourceBr, 0);            
            LOMDTO00021 serviceCharges = new LOMDTO00021();
            serviceCharges.InterestAmount = loanScharge == null ? 0 : loanScharge.Value;
            return serviceCharges;
        }

        public IList<PFMDTO00042> GetDataFromReportTlf(string accountNo, DateTime startOfMonth, DateTime endOfMonth, int workStationId, string sourceBr)
        {
            IList<PFMDTO00042> LoansAccountInfoByAccountNo = ViewDAO.SelectDataFromReportTlf(accountNo, startOfMonth, endOfMonth, workStationId, sourceBr);
            return LoansAccountInfoByAccountNo;
        }

        public MNMDTO00027 GetSCharge(string InterestMonths, string budmth, string accountNo, string lno, string sourceBr)
        {
            MNMDTO00027 SchargeDTO = SChargeDAO.SelectSCharge(InterestMonths, budmth, accountNo,lno,sourceBr);
            return SchargeDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveLegalCase(LOMDTO00013 Legaldto, string markLegalUser, string legalCaseLawyer)
        {
            //Save Legal
            LOMORM00013 legalORM = this.ConvertToLegalORM(Legaldto);
            LegalDAO.Save(legalORM);

            //'Update to know,Who Make Legal case
            LoansDAO.UpdateLoansForLegalCase(Legaldto.Lno,Legaldto.SourceBr, markLegalUser, legalCaseLawyer, Legaldto.CreatedUserId);
            //Update Loans with (rowlock) Set LegalCase=1, LegalDate=''01/15/2015 6:49:34 PM'', LegaLawer=''U BAR BAR'' , NPLCASE=0 , NPLDATE=Null, MarkLegalUser=''ADMIN''  Where Lno=''L001'''
        }

        public LOMORM00013 ConvertToLegalORM(LOMDTO00013 Legaldto)
        {
            LOMORM00013 LegalORM = new LOMORM00013();
            LegalORM.Lno = Legaldto.Lno;
            LegalORM.AcctNo = Legaldto.AcctNo;
            LegalORM.AcType = Legaldto.AcType;
            LegalORM.LegalDate = DateTime.Now;            
            LegalORM.Bal = Legaldto.Bal;
            LegalORM.NewBal = Legaldto.NewBal;
            LegalORM.OldInt = Legaldto.OldInt;
            LegalORM.OldScharge = Legaldto.OldScharge;
            LegalORM.OldExtra = Legaldto.OldExtra;
            LegalORM.IntRate = Legaldto.IntRate;
            LegalORM.AcceptDate = Legaldto.AcceptDate;
            LegalORM.SourceBr = Legaldto.SourceBr;
            LegalORM.Cur = Legaldto.Cur;
            LegalORM.CreatedDate = DateTime.Now;
            LegalORM.CreatedUserId = Legaldto.CreatedUserId;
            return LegalORM;
        }

        #endregion

        #region LegalRelease Method
        public IList<LOMDTO00013> isLegalLoanNo(string loanNo, string sourceBr)
        {
            IList<LOMDTO00013> LegalDTO = LegalDAO.SelectAllByLoanNo(loanNo, sourceBr);
            if (LegalDTO == null || LegalDTO.Count < 1)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90075; //This loan No has not Legal Case.!
                return null;
            }
            else  //LegalDTO.count > 0
            {
                if(LegalDTO[0].CloseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90073; //This legal case loan is already closed.
                    return null;
                }
                else if (LegalDTO[0].ReleaseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90074; //This legal case loan is already released.
                    return null;
                }
                else
                {
                    TLMDTO00018 LoanDTO = LoansDAO.GetLoansAccountInformation(loanNo, sourceBr);
                    if(LoanDTO != null)
                        LegalDTO[0].LegalLawyer = string.IsNullOrEmpty(LoanDTO.LegaLawer) ? "" : LoanDTO.LegaLawer;
                    
                    this.ServiceResult.ErrorOccurred = false;
                    return LegalDTO;
                }
            }
        }

         [Transaction(TransactionPropagation.Required)]
        public void ReleaseLegalSueCase(string loanNo, string sourceBr, string currentUserName, int currentUserId)
        {
            try
            {   //Update Loan Table
                LoansDAO.UpdateLoansForLegalReleaseCase(loanNo, sourceBr, currentUserId);
                //Update Legal Table
                LegalDAO.UpdateLegalForReleaseCase(loanNo, sourceBr, currentUserId);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;                
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
