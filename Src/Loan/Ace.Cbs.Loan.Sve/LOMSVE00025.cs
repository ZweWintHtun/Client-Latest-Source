using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using System.Data;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00025 : BaseService, ILOMSVE00025
    {
        private ITLMDAO00018 LoansDAO { get; set; }
        private IPFMDAO00054 TlfDAO { get; set; }
        private ICXSVE00002 CodeGenerator { get; set; }
        private IPFMDAO00056 SysDAO { get; set; }
        public TLMDTO00018 LoanDTO { get; set; }
        public TLMDTO00018 LoanDataByLoanNo { get; set; }
        public string rePayNo { get; set; }
        public ILOMDAO00401 OutstandLoanBalanceDAO { get; set; }
        private IPFMDAO00028 CledgerDAO { get; set; }
        private PFMDTO00028 CbalAmount { get; set; }
        public ILOMDAO00402 LRP9900DAO { get; set; }
        public ILOMDAO00406 BLDetailsDAO { get; set; }
        private string UserNo;


        public TLMDTO00018 RepayDecreaseAmount(TLMDTO00018 loanDto, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo,
                                                IList<PFMDTO00072> acctInfoList, int userId, string sourceBr, decimal cBalLatest, DateTime curSamtDate, int termNo)
        {            
            try
            {
                //Added by HMW (29-Aug-2019) : For Seperating EOD (2 Times EOD ==> At Current Day EOD, At Tomorrow Morning BOD) 
                string voucherNo;
                DateTime nextSettlementDate, lastSettlementDate;
                Nullable<DateTime> systemDate = null; //To solve Un-assigned Local Variable Error occured
                Nullable<DateTime> settlementDate = null; //To solve Un-assigned Local Variable Error occured
                Nullable<DateTime> transactionDate = null; //To solve Un-assigned Local Variable Error occured

                //Getting System Startup Date
                TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                if (startDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                    return new TLMDTO00018();
                }
                else
                {
                    if (startDTO.Status == "C")
                    {
                        systemDate = startDTO.Date;
                    }
                }

                //Getting Last Settlement Date            
                string lastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
                PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(lastSDate, sourceBr));
                lastSettlementDate = Convert.ToDateTime(sysDTO.SysDate);
                string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", lastSettlementDate);
                lastSettlementDate = Convert.ToDateTime(dateOnly + " " + "23:59:00.000"); //Getting the format (2019-03-28 11:59:00.000)                

                //Getting Next Settlement Date
                nextSettlementDate=CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                //Getting Settlement Date
                if ((string.Format("{0:MM/dd/yyyy}", systemDate) == string.Format("{0:MM/dd/yyyy}", lastSettlementDate)))//After Cut Off
                {
                    //Case-1 : TXN at Tomorrow BOD 
                    if (Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", lastSettlementDate)) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                    {
                        settlementDate = lastSettlementDate;   //2019-03-22 23:59:00.000
                        transactionDate = Convert.ToDateTime(dateOnly + " " + "23:59:07.000"); //Getting the format (2019-03-28 23:59:07.000)                               
                    }
                    //Case-2 : TXN at Current Day EOD (After Cut Off)
                    else if (string.Format("{0:MM/dd/yyyy}", lastSettlementDate) == DateTime.Now.ToString("MM/dd/yyyy"))
                    {
                        settlementDate = lastSettlementDate; //2019-03-22 23:59:00.000
                        transactionDate = DateTime.Now;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
                    }
                }
                //Case-3 : TXN at Current Day EOD (Before Cut Off)
                else if ((string.Format("{0:MM/dd/yyyy}", systemDate) == string.Format("{0:MM/dd/yyyy}", nextSettlementDate)))
                {
                    settlementDate = nextSettlementDate;
                    transactionDate = DateTime.Now;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
                }


                //DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), loanDto.SourceBranchCode, true });
                decimal rate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                string day = settlementDate.Value.Day.ToString().PadLeft(2, '0');
                string month = settlementDate.Value.Month.ToString().PadLeft(2, '0');
                string year = settlementDate.Value.Year.ToString().Substring(2);
                int updatedUserId = loanDto.CreatedUserId;
                UserNo = loanDto.CreatedUserId.ToString();
                int interOnSamtExist = 0;
                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, userId, loanDto.SourceBranchCode, new object[] { day, month, year });

                int count = acctInfoList.Count;//for number of voucher line

                #region old
                //LoanDTO = LoansDAO.RepayLoan(fullSettlement, lno, accountNo, repaymentAmount, interest, userNo, userId, sourceBr,voucherNo);
              
                //if (LoanDTO == null || LoanDTO.ResultCode == "0001")
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = CXMessage.MV90055.ToString(); //Invalid Loan No.
                //    return null;
                //}

                //else if (LoanDTO.ResultCode == "0002")
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = CXMessage.MV90056; // Loans Account Only 
                //    return null;
                //}

                //else if (LoanDTO.ResultCode == "0003")
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = CXMessage.MV90056; // Not Vouchered Yet 
                //    return null;
                //}

                //else if (LoanDTO.ResultCode == "0004")
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = CXMessage.MV90056; // Loans Account Closed 
                //    return null;
                //}
                //else
                //    rePayNo = LoanDTO.LastRepaymentNo;

                //string voucherNo;
                //DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), loanDto.SourceBranchCode, true });
                //decimal rate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                //string day = sys001.Day.ToString().PadLeft(2, '0');
                //string month = sys001.Month.ToString().PadLeft(2, '0');
                //string year = sys001.Year.ToString().Substring(2);
                //int updatedUserId = loanDto.CreatedUserId;

                //voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, loanDto.SourceBranchCode, new object[] { day, month, year });
                #endregion

                // Customer AC
                PFMORM00054 creditTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.CreditAccountCode, voucherNo, loanDto.AccountNo,
                     loanDto.CreditAccountDesp,"TDV", rate, Convert.ToDateTime(settlementDate), "TRDEBIT", loanDto.Assessor, acctInfoList[1].CreditAmount1, "Capital", userId);
                //Insert Tlf
                this.TlfDAO.Save(creditTransactionLog);

                // AAG Account
                PFMORM00054 debitTransactionLog = this.GetTransactionLogFile(loanDto, acctInfoList[1].CreditAccountNo1, voucherNo, acctInfoList[1].CreditAccountNo1, 
                         acctInfoList[1].BankAccountDescription,
                        "TCV", rate, Convert.ToDateTime(settlementDate), "TRCREDIT", loanDto.Assessor, acctInfoList[1].CreditAmount1, "", userId);
                //Insert Tlf
                this.TlfDAO.Save(debitTransactionLog);

                //3.Interest On Samt
                if (count >=3)
                {
                    if (acctInfoList[2].CreditAmount1 != 0 || acctInfoList[2].CreditAmount1.ToString() != "") //Total Interest
                    {
                        debitTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.CreditAccountCode, voucherNo, loanDto.AccountNo, loanDto.CreditAccountDesp,
                        "TDV", rate, Convert.ToDateTime(settlementDate), "TRDEBIT", loanDto.Assessor, acctInfoList[2].CreditAmount1, "Interest", userId);
                        //Insert Tlf
                        this.TlfDAO.Save(debitTransactionLog);

                        interOnSamtExist = 1;
                        creditTransactionLog = this.GetTransactionLogFile(loanDto, acctInfoList[2].CreditAccountNo1, voucherNo, acctInfoList[2].CreditAccountNo1, 
                        acctInfoList[2].BankAccountDescription,
                        "TCV", rate, Convert.ToDateTime(settlementDate), "TRCREDIT", loanDto.Assessor, acctInfoList[2].CreditAmount1, "", userId);
                        this.TlfDAO.Save(creditTransactionLog);
                    }
                }

                //4.TOD
                if (count >=4)
                {
                    if (acctInfoList[3].CreditAmount1 != 0 || acctInfoList[3].CreditAmount1.ToString() != "")
                    {
                        creditTransactionLog = this.GetTransactionLogFile(loanDto, acctInfoList[3].CreditAccountNo1, voucherNo, acctInfoList[3].CreditAccountNo1, acctInfoList[3].BankAccountDescription,
                        "TCV", rate, Convert.ToDateTime(settlementDate), "TRCREDIT", loanDto.Assessor, acctInfoList[3].CreditAmount1, "", userId);
                        this.TlfDAO.Save(creditTransactionLog);
                    }
                }

                //Late Fee on TOD
                if (count == 5)
                {
                    if (acctInfoList[4].CreditAmount1 != 0 || acctInfoList[4].CreditAmount1.ToString() != "") 
                    {
                        creditTransactionLog = this.GetTransactionLogFile(loanDto, acctInfoList[4].CreditAccountNo1, voucherNo, acctInfoList[4].CreditAccountNo1, acctInfoList[4].BankAccountDescription,
                        "TCV", rate, Convert.ToDateTime(settlementDate), "TRCREDIT", loanDto.Assessor, acctInfoList[4].CreditAmount1, "", userId);
                        this.TlfDAO.Save(creditTransactionLog);
                    }
                }

                #region updating

                //*** Update on Cledger(CBAL)***
                decimal cbal = cBalLatest - acctInfoList[0].DebitAmount1;
                CledgerDAO.UpdateCledgerCBalByAccountNo(loanDto.AccountNo, cbal, loanDto.SourceBranchCode, CurrentUserEntity.WorkStationId, userId);

                //'*** Update on Loans (SAMT)***
                bool result = LoansDAO.UpdateSamtByLnoAndAcctno_Decrease(acctInfoList[1].CreditAmount1, loanDto.Lno, loanDto.SourceBranchCode, loanDto.AccountNo, loanDto.LastRepaymentNo, userId);
                string tempInterest ="0";
                //'*** Insert into LRP99#00 ***
                if (interOnSamtExist==0)
                {
                    tempInterest = "0";
                }
                else
                {
                    tempInterest = acctInfoList[2].CreditAmount1.ToString();
                }
                LOMORM00402 entity = this.ConvertToORMLRP99(loanDto, Convert.ToDateTime(settlementDate), acctInfoList[1].CreditAmount1.ToString(), tempInterest, userId, "D");
                this.LRP9900DAO.Save(entity);

                //'*** Update on Outs ***
                //Comment and Modified by HMW at 30-Aug-2019 : To remove no need updating fields
                /*
                OutstandLoanBalanceDAO.UpdateOutstandingBalByRepaymentAmt(loanDto.Lno, loanDto.AccountNo, loanDto.SourceBranchCode, Convert.ToDecimal(loanDto.SAmount) - acctInfoList[1].CreditAmount1,
                                                                         DateTime.Now, 0, DateTime.Now, 0, DateTime.Now, 0, DateTime.Now, DateTime.Now.AddMonths(1).AddDays(-1), DateTime.Now,
                                                                         userId); 
                */
                OutstandLoanBalanceDAO.UpdateOutstandingBalByRepaymentAmt(loanDto.Lno, loanDto.AccountNo, loanDto.SourceBranchCode, Convert.ToDecimal(loanDto.SAmount) - acctInfoList[1].CreditAmount1,
                                                                         interest, Convert.ToDateTime(transactionDate), Convert.ToDateTime(transactionDate), userId); 

                //Updating Business_Loans_Detail Table
                decimal interestForBeforeLC =0;
                if (interOnSamtExist != 0)
                {
                    interestForBeforeLC = acctInfoList[2].CreditAmount1;
                }
                else interestForBeforeLC = 0;
                string outresult = BLDetailsDAO.UpdateBLDetailsLCDecrease(loanDto.Lno, loanDto.AccountNo, acctInfoList[1].CreditAmount1, false, termNo, interestForBeforeLC, userId, loanDto.UserNo, loanDto.SourceBranchCode);
                #endregion
                //loanDto.ResultCode = "0000";
                loanDto.ResultCode = outresult;
                loanDto.voucherNo = voucherNo;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI90026; //Loan Repayment Failed                
            }
            return loanDto;           
        }

        public TLMDTO00018 RepayIncreaseAmount(TLMDTO00018 loanDto, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo,
                                                 decimal interestOnSamt, decimal repayAmt,int userId, string sourceBr, decimal cBalLatest, DateTime curSamtDate, int termNo, decimal SCharge, decimal rate, decimal docFee)
        {            
            try
            {
                //Added by HMW (29-Aug-2019) : For Seperating EOD (2 Times EOD ==> At Current Day EOD, At Tomorrow Morning BOD)
                string voucherNo;
                decimal intOnSamt = 0;
                decimal OD = 0;
                decimal lateFee = 0;
                DateTime nextSettlementDate, lastSettlementDate;
                Nullable<DateTime> systemDate = null; //To solve Un-assigned Local Variable Error occured               
                Nullable<DateTime> settlementDate = null; //To solve Un-assigned Local Variable Error occured
                Nullable<DateTime> transactionDate = null; //To solve Un-assigned Local Variable Error occured

                //Getting System Startup Date
                TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                if (startDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                    return new TLMDTO00018();
                }
                else
                {
                    if (startDTO.Status == "C")
                    {
                        systemDate = startDTO.Date;
                    }
                }

                //Getting Last Settlement Date            
                string lastSDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate);
                PFMDTO00056 sysDTO = CXServiceWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(lastSDate, sourceBr));
                lastSettlementDate = Convert.ToDateTime(sysDTO.SysDate);
                string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", lastSettlementDate);
                lastSettlementDate = Convert.ToDateTime(dateOnly + " " + "23:59:00.000"); //Getting the format (2019-03-28 11:59:00.000)                

                //Getting Next Settlement Date
                nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });

                //Getting Settlement Date
                if ((string.Format("{0:MM/dd/yyyy}", systemDate) == string.Format("{0:MM/dd/yyyy}", lastSettlementDate)))//After Cut Off
                {
                    //Case-1 : TXN at Tomorrow BOD 
                    if (Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", lastSettlementDate)) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
                    {
                        settlementDate = lastSettlementDate;   //2019-03-22 23:59:00.000
                        transactionDate = Convert.ToDateTime(dateOnly + " " + "23:59:07.000"); //Getting the format (2019-03-28 23:59:07.000)                               
                    }
                    //Case-2 : TXN at Current Day EOD (After Cut Off)
                    else if (string.Format("{0:MM/dd/yyyy}", lastSettlementDate) == DateTime.Now.ToString("MM/dd/yyyy"))
                    {
                        settlementDate = lastSettlementDate; //2019-03-22 23:59:00.000
                        transactionDate = DateTime.Now;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
                    }
                }
                //Case-3 : TXN at Current Day EOD (Before Cut Off)
                else if ((string.Format("{0:MM/dd/yyyy}", systemDate) == string.Format("{0:MM/dd/yyyy}", nextSettlementDate)))
                {
                    settlementDate = nextSettlementDate;
                    transactionDate = DateTime.Now;
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
                }

                //DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
                decimal intrate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                string day = settlementDate.Value.Day.ToString().PadLeft(2, '0');
                string month = settlementDate.Value.Month.ToString().PadLeft(2, '0');
                string year = settlementDate.Value.Year.ToString().Substring(2);
                int updatedUserId = loanDto.CreatedUserId;
                UserNo = userNo;

                int interOnSamtExist = 0;
                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, userId, sourceBr, new object[] { day, month, year });
                
                //int count = acctInfoList.Count;//for number of voucher line

                //PFMORM00054 debitTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.AType, voucherNo, loanDto.AType, loanDto.BType,
                //"TDV", rate, sys001, "TRDEBIT", loanDto.Assessor, acctInfoList[0].DebitAmount1);
                ////Insert Tlf
                //this.TlfDAO.Save(debitTransactionLog);


                //PFMORM00054 creditTransactionLog = this.GetTransactionLogFile(loanDto, loanDto.CreditAccountCode, voucherNo, loanDto.AccountNo, loanDto.CreditAccountDesp,
                //     "TCV", rate, sys001, "TRCREDIT", loanDto.Assessor, acctInfoList[1].CreditAmount1);
                ////Insert Tlf
                //this.TlfDAO.Save(creditTransactionLog);

                #region updating

                //*** Update on Cledger(CBAL)***
                decimal cbal = cBalLatest + repayAmt;
                CledgerDAO.UpdateCledgerCBalByAccountNo(loanDto.AccountNo, cbal, loanDto.SourceBranchCode, CurrentUserEntity.WorkStationId, userId);

                //'*** Update on Loans (SAMT)***
                //(Comment by HMW)
                //bool result = LoansDAO.UpdateSamtByLnoAndAcctno_Increase(repayAmt, loanDto.Lno, loanDto.SourceBranchCode, loanDto.AccountNo, loanDto.LastRepaymentNo, userId);
                bool result = LoansDAO.UpdateSamtByLnoAndAcctno_Increase(repayAmt, loanDto.Lno, loanDto.SourceBranchCode, loanDto.AccountNo, Convert.ToString(Convert.ToInt32(loanDto.LastRepaymentNo)-1), userId);

                intOnSamt = 0;
                //'*** Insert into LRP99#00 ***
                if (interestOnSamt != 0 || interestOnSamt.ToString() != "") //Total Interest
                {
                    intOnSamt = interestOnSamt;
                }
                else intOnSamt = 0;

                loanDto.SourceBranchCode = sourceBr;

                decimal interestForBeforeLC = intOnSamt;
                LOMORM00402 entity = this.ConvertToORMLRP99(loanDto,Convert.ToDateTime(settlementDate), repayAmt.ToString(), interestForBeforeLC.ToString(), updatedUserId, "I");
                this.LRP9900DAO.Save(entity);

                //'*** Update on Outs ***              
                //OutstandLoanBalanceDAO.UpdateOutstandingBalByRepaymentAmt(loanDto.Lno, loanDto.AccountNo, loanDto.SourceBranchCode, Convert.ToDecimal(loanDto.SAmount) +repayAmt,
                //                                                         DateTime.Now, 0, DateTime.Now, 0, DateTime.Now, 0, DateTime.Now, DateTime.Now.AddMonths(1).AddDays(-1), DateTime.Now,
                //                                                         userId);
                OutstandLoanBalanceDAO.UpdateOutstandingBalByRepaymentAmt(loanDto.Lno, loanDto.AccountNo, loanDto.SourceBranchCode, Convert.ToDecimal(loanDto.SAmount) + repayAmt, 0, Convert.ToDateTime(transactionDate), Convert.ToDateTime(transactionDate), userId);
                //Updating Business_Loans_Detail Table
                if (interestOnSamt != 0 || interestOnSamt.ToString() != "") //Total Interest
                {
                    intOnSamt = interestOnSamt;
                }
                else intOnSamt = 0;
                string outresult = BLDetailsDAO.UpdateBLDetailsLCIncrease(loanDto.Lno, loanDto.AccountNo, voucherNo, repayAmt, true, termNo, SCharge, rate, docFee, interestForBeforeLC, userId, userId.ToString(), loanDto.SourceBranchCode);

                #endregion
                loanDto.ResultCode = outresult;
                loanDto.voucherNo = voucherNo;
            }
            catch (Exception ex)
            {
                if (this.ServiceResult.MessageCode != null)
                {
                    this.ServiceResult.ErrorOccurred = true;//this.ServiceResult.MessageCode = CXMessage.ME00070;//Please check the "System Date" and "Settlement Date" First!
                }
                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI90026; //Loan Repayment Failed                
                }
            }
            return loanDto;
        }


        public TLMDTO00018 isValidLoanNo(string lno, string sourceBr)
        {
            TLMDTO00018 LoanDTO = LoansDAO.GetLoansAccountInformationWithInterest(lno, sourceBr);
            LoanDataByLoanNo = LoanDTO;

            return LoanDTO;
        }

        //Comment by HMW at 18-05-2023 (No Use. I replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling)
        /*        
        public TLMDTO00018 GetNewInterestForNewRateLCIncrease(string intRate, string Lno, decimal RepayAmt, string sourceBr)
        {
            TLMDTO00018 LoanDTO = LoansDAO.GetNewInterestForNewRateLCIncrease(intRate, Lno,RepayAmt,sourceBr);
            return LoanDTO;
        }
         */

        //added by SHO [22-Nov-21] for Project loan type separate
        public LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string lno, decimal repayAmt,string sourceBr)
        {
            LOMDTO00401 outLoansDto = OutstandLoanBalanceDAO.GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(lno,repayAmt,sourceBr);
            return outLoansDto;
        }
        public LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(string lno, decimal repayAmt, decimal rate, string sourceBr)
        {
            LOMDTO00401 outLoansDto = OutstandLoanBalanceDAO.GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(lno, repayAmt, rate, sourceBr);
            return outLoansDto;
        }
        public PFMDTO00028 CheckCBalMinBalAmoutByAcctno(string acctno)
        {
            CbalAmount = CledgerDAO.SelectACSignByAccountNo(acctno);
            return CbalAmount;
        }

        private PFMORM00054 GetTransactionLogFile(TLMDTO00018 LoansDto, object acode, string voucherno, string acctno, object desp, string status, decimal rate, DateTime settlementdate, string trancode, string channel,decimal Amount,string narrationType,int userid)
        {
            #region Added and modified by HMW (30-Aug-2019) : For backdate Limit Change after late fee auto pay run)
            DateTime systemDate, lastSettlementDate, transactionDate;

            //Getting "System Date"
            TCMDTO00001 systemStartInfo = CXServiceWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(LoansDto.SourceBranchCode));
            systemDate = systemStartInfo.Date;

            //Getting "Last Settlement Date"
            lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), LoansDto.SourceBranchCode);

            if (systemDate.Date == lastSettlementDate.Date) //For Back Date Transaction
            {
                string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", lastSettlementDate);
                transactionDate = Convert.ToDateTime(dateOnly + " " + "23:59:07.000");
            }
            else //For Normal Transaction
            {
                transactionDate = DateTime.Now;
            }
            #endregion

            PFMORM00054 tlfORM = new PFMORM00054();
            tlfORM.Id = this.TlfDAO.SelectMaxId() + 1;
            tlfORM.Eno = voucherno;
            tlfORM.AccountNo = acctno;
            tlfORM.Acode = acode.ToString();
            tlfORM.Lno = LoansDto.Lno;
            tlfORM.Amount = Amount;
            tlfORM.HomeAmount = Amount;
            tlfORM.LocalAmt = Amount;
            tlfORM.LocalAmount = Amount;
            tlfORM.HomeAmt = Amount;
            tlfORM.HomeOAmt = 0;
            tlfORM.LocalOAmt = 0;
            tlfORM.Description = desp.ToString();
            if (narrationType == "")
            {
                tlfORM.Narration = "BL Limit Decrease: " + LoansDto.AccountNo ;
            }
            else  /// Capital or Interest for CustID
            {
                tlfORM.Narration = "BL Limit Decrease: " + LoansDto.AccountNo + " (" + narrationType + ")";
            }
            tlfORM.DateTime = transactionDate;//LoansDto.CreatedDate;
            tlfORM.Status = status;
            tlfORM.TransactionCode = trancode;
            if (acctno.Length > 6 )
            {
                tlfORM.AccountSign = LoansDto.ACSign;
            }
            tlfORM.UserNo = userid.ToString();
            tlfORM.SourceCurrency = LoansDto.Currency;
            tlfORM.Rate = rate;
            tlfORM.SourceBranchCode = LoansDto.SourceBranchCode;
            tlfORM.SettlementDate = settlementdate;
            tlfORM.Channel = channel;
            tlfORM.ReferenceType = "LOANS";
            tlfORM.ReferenceVoucherNo = LoansDto.Lno;
            tlfORM.GChequeNo = "1";
            tlfORM.LgNo = LoansDto.LastRepaymentNo;
            tlfORM.CreatedDate = transactionDate;
            tlfORM.CreatedUserId = userid;
            return tlfORM;
        }

        private LOMORM00402 ConvertToORMLRP99(TLMDTO00018 loanDto, DateTime settlementDate, string amount, string interest, int userid, string limitChangeState)
        {
            LOMORM00402 LrpORM = new LOMORM00402();
            LrpORM.Id = this.LRP9900DAO.SelectMaxId() + 1;
            LrpORM.LNO = loanDto.Lno;
            
            #region Added and modified by HMW (30-Aug-2019) : For backdate Limit Change after late fee auto pay run)
            DateTime systemDate, lastSettlementDate, transactionDate;

            //Getting "System Date"
            TCMDTO00001 systemStartInfo = CXServiceWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(loanDto.SourceBranchCode));
            systemDate = systemStartInfo.Date;

            //Getting "Last Settlement Date"
            lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), loanDto.SourceBranchCode);

            if (systemDate.Date == lastSettlementDate.Date) //For Back Date Transaction
            {
                string dateOnly = string.Format("{0:yyyy'-'MM'-'dd}", settlementDate);
                transactionDate = Convert.ToDateTime(dateOnly + " " + "23:59:07.000");
            }
            else //For Normal Transaction
            {
                transactionDate = DateTime.Now;
            }            

            //Condition added by HMW
            if (limitChangeState == "D")
            {
                LrpORM.RepayNo = loanDto.LastRepaymentNo;
            }
            else if (limitChangeState == "I")
            {
                LrpORM.RepayNo = null;
            }
            LrpORM.Interest = Convert.ToDecimal(interest);
            LrpORM.AcctNo = loanDto.AccountNo;
            LrpORM.Date_Time = transactionDate;
            LrpORM.Amount = Convert.ToDecimal(amount);//RepayAmt
            LrpORM.UserNo = CurrentUserEntity.CurrentUserID.ToString();
            LrpORM.SourceBr = loanDto.SourceBranchCode;
            LrpORM.Cur = loanDto.Currency;
            LrpORM.SettlementDate = settlementDate;
            LrpORM.Active = true;
            LrpORM.CreatedDate = transactionDate;
            LrpORM.CreatedUserId = userid;
            LrpORM.LCState = limitChangeState;
            LrpORM.Old_IntRate = loanDto.OldIntRate;//Added by HMW (24-04-2022) >> To insert in LRP99#00's Old_IntRate col
            LrpORM.New_IntRate = loanDto.NewIntRate;//Added by HMW (24-04-2022) >> To insert in LRP99#00's New_IntRate col                     
            
            return LrpORM;
            #endregion
        }

        public string CheckingCasesBLLimitChange(string blNo, string sourceBr)
        {
            return this.BLDetailsDAO.CheckingCasesBLLimitChange(blNo, sourceBr);
        }

        //[Transaction(TransactionPropagation.Required)]
        //public void SaveODLimitChangeData(TLMDTO00018 odLimitChangeEntity)
        //{
        //    try
        //    {
        //        Rate = CXCOM00010.Instance.GetExchangeRate(odLimitChangeEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
        //        if (Rate == 0)
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
        //            return;
        //        }
        //        SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), odLimitChangeEntity.SourceBranchCode, true });
        //        if (SettlementDate == null)
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
        //            return;
        //        }
        //        if (odLimitChangeEntity.NewTotalODLimit > odLimitChangeEntity.TotalODLimit)  //IF New Limit >Old Limit then
        //        {
        //            if (!this.ODOnly(odLimitChangeEntity))
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return;
        //            }
        //        }
        //            //else
        //            //{
        //                NewSetupDAO.UpdateValueOfRunTrigger("Enable", odLimitChangeEntity.UpdatedUserId.Value);

        //                //*** Update on Cledger ***
        //                decimal oVDLimit = odLimitChangeEntity.TotalODLimit + (odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit);
        //                CledgerDAO.UpdateOVDLimitInCledger(oVDLimit, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

        //                //'*** Update on Loans ***
        //                LoansDAO.UpdateSamtAndFirstSamt(odLimitChangeEntity.NewODLimit, odLimitChangeEntity.Lno, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

        //                //'*** Insert into LMT99#00 ***
        //                LMT99DAO.Save(this.ConvertToLimitFileORM(odLimitChangeEntity));
        //            //}
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public bool ODOnly(TLMDTO00018 odLimitChangeEntity)
        //{
        //    int restofdays = 0;
        //    bool autolink = true;
        //    string commissionCode;
        //    int Dayinyear=0;

        //    if (odLimitChangeEntity != null)
        //    {
        //        restofdays = (Convert.ToDateTime(odLimitChangeEntity.ExpireDate)-DateTime.Now).Days + 2;
        //    }

        //    PFMDTO00009 SCharges = RateFileDAO.SelectByRateCode("SchargeNew");            
        //   // int Dayinyear = 337 + (Convert.ToInt32(Convert.ToDateTime("03/01/" + (DateTime.Now.Year)).Day-1));    //number of days in 1 year           
            
        //    if(DateTime.IsLeapYear(DateTime.Now.Year))
        //        Dayinyear=366;
        //    else
        //        Dayinyear=365;

        //    douAmt = (((odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit) * (SCharges.Rate / 100)) / Dayinyear) * Convert.ToDecimal(restofdays);  //' 1% amount

        //    this.ServiceResult.MessageCode = CXMessage.MV90063 + "."+douAmt.ToString();  //Service Charges {0} will be deducted from Account no.: {1}            

        //    commissionCode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NewServiceCharge), odLimitChangeEntity.Currency, odLimitChangeEntity.SourceBranchCode, true });   // a/c code for Commssion

        //    //update Chargesstatus of Loan file when this a/c is OD
        //    LoansDAO.UpdateChargesstatus("Y", odLimitChangeEntity.Lno, Convert.ToInt32(odLimitChangeEntity.UpdatedUserId));

        //    string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, odLimitChangeEntity.UpdatedUserId.Value, odLimitChangeEntity.SourceBranchCode, new object[] { SettlementDate.Day.ToString().PadLeft(2, '0'), SettlementDate.Month.ToString().PadLeft(2, '0'), SettlementDate.Year.ToString().Substring(2) });  //Transaction Voucher

        //    if (douAmt < odLimitChangeEntity.OverdraftAmount) //ouAmt Begin
        //    {
        //        autolink = false ;   // 1 - Autolink(true) , 0 - Normal(false)
        //    }

        //    string[] vouType = new string[] {"D","C"};    
        //    string[] accountNo = new string[] {odLimitChangeEntity.AccountNo,commissionCode};
        //    string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

        //    for(int i=0; i < vouType.Count() ; i++)
        //    {
        //        string account =accountNo[i].ToString();
        //        string voucherType = vouType[i].ToString();                
        //        ///*** Insert into tlf ***   (2 transaction will save. one with customerAcc and one with acode)
        //        if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.Sp_SERVICECHARGES_VOU(voucherNumber, account, odLimitChangeEntity.Lno, "Service Charges for Limit Change", douAmt, 0, odLimitChangeEntity.UserNo, voucherType,
        //        false,odLimitChangeEntity.Currency,Convert.ToInt32(Rate),odLimitChangeEntity.SourceBranchCode, SettlementDate,channel,true, string.Empty)))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = CXMessage.ME00018;   //Transaction is not Success!
        //            //throw new Exception(this.ServiceResult.MessageCode);                   
        //        }
        //    }
        //    ///*** Insert into Services_Charges ***
        //    this.ServiceChargesDAO.Save(this.ConvertToService_ChargesORM(odLimitChangeEntity));
        //    return true;
        //}

        //public TCMORM00002 ConvertToService_ChargesORM(TLMDTO00018 odLimitChangeEntity)
        //{
        //    TCMORM00002 ServiceChargesORM = new TCMORM00002();
        //    ServiceChargesORM.LNo = odLimitChangeEntity.Lno;
        //    ServiceChargesORM.AcctNo = odLimitChangeEntity.AccountNo;
        //    ServiceChargesORM.Desp = "OD Limit Change";
        //    ServiceChargesORM.GetColo = string.Empty;
        //    ServiceChargesORM.VouDate = DateTime.Now;
        //    ServiceChargesORM.Amount = douAmt;
        //    ServiceChargesORM.SourceBr = odLimitChangeEntity.SourceBranchCode;
        //    ServiceChargesORM.Cur = odLimitChangeEntity.Currency;
        //    ServiceChargesORM.Active = true;
        //    ServiceChargesORM.CreatedDate = DateTime.Now;
        //    ServiceChargesORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
        //    return ServiceChargesORM;
        //}

        //public LOMORM00011 ConvertToLimitFileORM(TLMDTO00018 odLimitChangeEntity)
        //{
        //    LOMORM00011 LimitFileORM = new LOMORM00011();
        //    LimitFileORM.AcctNo = odLimitChangeEntity.AccountNo;
        //    LimitFileORM.CloseDate = odLimitChangeEntity.CloseDate ;
        //    LimitFileORM.Cur = odLimitChangeEntity.Currency ;
        //    LimitFileORM.Date_Time = DateTime.Now ;
        //    LimitFileORM.LoanNo = odLimitChangeEntity.Lno ;
        //    LimitFileORM.OLDLimit = odLimitChangeEntity.TotalODLimit ;
        //    LimitFileORM.OVDLimit = odLimitChangeEntity.NewODLimit ;
        //    LimitFileORM.SourceBr = odLimitChangeEntity.SourceBranchCode ;
        //    LimitFileORM.UserNo = odLimitChangeEntity.UserNo ;
        //    LimitFileORM.Active = true ;
        //    LimitFileORM.CreatedDate = DateTime.Now;
        //    LimitFileORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
        //    return LimitFileORM;
        //}
        
    }
}
