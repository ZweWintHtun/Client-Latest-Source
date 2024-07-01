using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00024 : BaseService, ILOMSVE00024
    {
        #region Properties
        private ILOMDAO00406 bLDetailsDAO;
        public ILOMDAO00406 BLDetailsDAO
        {
            get { return this.bLDetailsDAO; }
            set { this.bLDetailsDAO = value; }
        }
        private ILOMDAO00401 outstandLoanBalanceDAO;
        public ILOMDAO00401 OutstandLoanBalanceDAO
        {
            get { return this.outstandLoanBalanceDAO; }
            set { this.outstandLoanBalanceDAO = value; }
        }

        public ICXSVE00002 CodeGenerator { get; set; }
        private IPFMDAO00056 SysDAO { get; set; }
        private IPFMDAO00028 CLedgerDAO { get; set; }
        private IPFMDAO00054 TlfDAO { get; set; }
        private ITLMDAO00018 LoanVoucherDAO { get; set; }
        private ILOMDAO00023 Partial_LoanDAO { get; set; }
        private ILOMSVE00014 LoanDAO { get; set; }
        private ILOMSVE00011 AcctnoDAO { get; set; }
        private IMNMDAO00017 LIDAO { get; set; }

        private string isServieCharges = "false";
        private decimal serviceRate = 0;
        int dayForOneMonth = 30; // for bank requrirement one month = 30days
        public bool ServiceCharge;
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00018 SelectLoanByloanNoandSourcebr(string lno, string sourcebr)
        {
            TLMDTO00018 loanDto = this.LoanDAO.isValidLoanNo(lno, sourcebr);
            return loanDto;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00072> SelectLoanInfoByloanNoandSourcebr(string lno, string sourcebr)
        {
            IList<PFMDTO00072> acctNoInfoList = new List<PFMDTO00072>();
            string companyName  = "";
            try
            {

                TLMDTO00018 loanDto = this.LoanDAO.isValidLoanNo(lno, sourcebr);
                if (loanDto == null) throw new Exception("MV90055"); //Invalid Loan No.
                else if (loanDto.Vouchered == true)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90080";//This loan no has already vouchered!
                }
                else if (loanDto.CloseDate != null && !loanDto.CloseDate.Equals(System.DateTime.MinValue))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90057";//Loans No. Already Closed!
                }
                else if (loanDto.AType.Contains("OVER"))
                {
                    this.ServiceResult.MessageCode = "MV90081";//Not Allow Overdraft Transaction…
                    this.ServiceResult.ErrorOccurred = true;
                }
                else if (loanDto.Vouchered == true && loanDto.SAmount == loanDto.FirstSAmount)
                {
                    this.ServiceResult.MessageCode = "MV90080";//This LoanNo. Is already vouchered…
                    this.ServiceResult.ErrorOccurred = true;
                }
                else if (loanDto.NPLCase || loanDto.NPLDate != null)
                {
                    this.ServiceResult.MessageCode = "MV90064";//NPL Case Is Already Exist.
                    this.ServiceResult.ErrorOccurred = true;
                }
                else
                {
                    if (loanDto.AccountNo.Substring(5, 1) == "3") // Added by ZMS to show company name in BL Voucher of pristine requirements
                    {
                        companyName = this.AcctnoDAO.GetCompanyName(loanDto.AccountNo);

                    }

                    acctNoInfoList = this.AcctnoDAO.IsValidForLoanAcctno(loanDto.AccountNo);
                    if (acctNoInfoList.Count == 0) throw new Exception("MV90055"); //Invalid Loan No.

                    else
                    {
                        acctNoInfoList[0].AccountNo = loanDto.AccountNo;
                        acctNoInfoList[0].CreditAmount1 = Convert.ToDecimal(loanDto.FirstSAmount) - Convert.ToDecimal(loanDto.SAmount); // For Sanction amount in UI
                        acctNoInfoList[0].CurrencyCode = loanDto.Currency;
                        acctNoInfoList[0].AccountSignature = loanDto.Loans_Type;
                        //acctNoInfoList[0].Active = loanDto.isScharge;
                        acctNoInfoList[0].DebitAmount2 = Convert.ToDecimal(loanDto.DocFee);
                        acctNoInfoList[0].isScharge = loanDto.isScharge;
                        acctNoInfoList[0].companyName = companyName;
                        acctNoInfoList[0].LoanCOAAccountNo = loanDto.RelatedGLACode;
                        acctNoInfoList[0].BType = loanDto.BType;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;     //Invalid Loan No.
                this.ServiceResult.ErrorOccurred = true;
            }

            return acctNoInfoList;
        }

        [Transaction(TransactionPropagation.Required)]
        public string LoanVoucher(TLMDTO00018 loanDto, IList<PFMDTO00072> acctnoInfoList, string sourcebr, string AccountNo, string description, bool isSCharge)
        {
            string voucherNo = string.Empty;
            ServiceCharge = isSCharge;
            if (isSCharge == true)
            {
                loanDto.ServiceCharges = (Convert.ToDecimal(loanDto.SAmount) * Convert.ToDecimal(loanDto.serviceChargesRate)) / 100;
            }
            else
            {
                loanDto.ServiceCharges = 0;
            }
            try
            {
                //Update Sys001
                if (!this.SysDAO.UpdateStatusByNameForLoanVoucher(Convert.ToInt32(loanDto.UpdatedUserId), "N", Convert.ToDateTime(loanDto.UpdatedDate), sourcebr))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90001";     //Updating Error.
                }
                //Update Loans

                else if (!this.LoanVoucherDAO.UpdateLoanForLoanVoucherByLoanNoAndSourceBr(loanDto))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90001";     //Updating Error.
                }

                //Update Partial_Loans
                if (Convert.ToBoolean(loanDto.Partial)) // Partial is for partial or full loan amount , 1 is partial amount
                {
                    this.Partial_LoanDAO.Save(this.GetPartial_LoansORM(loanDto));
                }

                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourcebr, true });
                decimal rate = CXCOM00010.Instance.GetExchangeRate(loanDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));

                string day = sys001.Day.ToString().PadLeft(2, '0');
                string month = sys001.Month.ToString().PadLeft(2, '0');
                string year = sys001.Year.ToString().Substring(2);
                int updatedUserId = loanDto.CreatedUserId;

                voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, sourcebr, new object[] { day, month, year });

                PFMORM00054 debitTransactionLog = this.GetTransactionLogFile(loanDto, acctnoInfoList[0].BankAccountNo, voucherNo, acctnoInfoList[1].CreditAccountNo1, acctnoInfoList[1].BankAccountDescription,
                     "TCV", rate, sys001, "TRCREDIT", acctnoInfoList[0].CreditDescription2, 0);
                //Insert Tlf
                this.TlfDAO.Save(debitTransactionLog);

                PFMORM00054 creditTransactionLog = this.GetTransactionLogFile(loanDto, acctnoInfoList[0].CreditAccountNo1, voucherNo, acctnoInfoList[0].CreditAccountNo1, acctnoInfoList[0].BankAccountDescription,
                    "TDV", rate, sys001, "TRDEBIT", acctnoInfoList[0].CreditDescription2, 0);
                //Insert Tlf
                this.TlfDAO.Save(creditTransactionLog);

                #region For Documentation Fee
                debitTransactionLog = this.GetTransactionLogFile(loanDto, acctnoInfoList[3].CreditAccountNo1, voucherNo, acctnoInfoList[3].CreditAccountNo1, acctnoInfoList[3].BankAccountDescription,
                     "TCV", rate, sys001, "TRCREDIT", acctnoInfoList[0].CreditDescription2, 1);
                this.TlfDAO.Save(debitTransactionLog);

                creditTransactionLog = this.GetTransactionLogFile(loanDto, acctnoInfoList[2].BankAccountNo, voucherNo, acctnoInfoList[1].CreditAccountNo1, acctnoInfoList[2].BankAccountDescription,
                    "TDV", rate, sys001, "TRDEBIT", acctnoInfoList[0].CreditDescription2, 1);
                this.TlfDAO.Save(creditTransactionLog);
                #endregion

                if (isSCharge == true)
                {
                    isServieCharges = "true";
                    ///IF0010
                    //string AccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "SCHARGENEW", loanDto.Currency, sourcebr, true });

                    ///SERVICE CHG: ON LOANS AND OD
                    //string description = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { AccountNo, sourcebr, true });

                    //serviceRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "SCHARGENEW", true });
                    PFMORM00054 debitTransactionLogForScharge = this.GetTransactionLogFile(loanDto, AccountNo, voucherNo, AccountNo, description,
                     "TCV", rate, sys001, "TRCREDIT", acctnoInfoList[0].CreditDescription2, 0);
                    //Insert Tlf
                    this.TlfDAO.Save(debitTransactionLogForScharge);

                    PFMORM00054 creditTransactionLogForScharge = this.GetTransactionLogFile(loanDto, acctnoInfoList[0].BankAccountNo, voucherNo, acctnoInfoList[1].CreditAccountNo1, acctnoInfoList[1].BankAccountDescription,
                    "TDV", rate, sys001, "TRDEBIT", acctnoInfoList[0].CreditDescription2, 0);
                    //Insert Tlf
                    this.TlfDAO.Save(creditTransactionLogForScharge);
                }
                //Update Li 
                //this.LIDAO.Update_LI_PrincipalAmount(loanDto.Lno, Convert.ToDecimal(loanDto.SAmount), sourcebr, Convert.ToInt32(loanDto.UpdatedUserId), Convert.ToDateTime(loanDto.UpdatedDate));

                //Update Cledger
                PFMDTO00028 cledger = CXServiceWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.GetAccountInfoOfCledgerByAccountNo(acctnoInfoList[1].CreditAccountNo1));
                if (isSCharge) cledger.CurrentBal = Convert.ToDecimal(loanDto.SAmount) - (Convert.ToDecimal(loanDto.SAmount) * Convert.ToDecimal(loanDto.serviceChargesRate) / 100) + cledger.CurrentBal - Convert.ToDecimal(loanDto.DocFee);
                else cledger.CurrentBal = Convert.ToDecimal(loanDto.SAmount) + cledger.CurrentBal - Convert.ToDecimal(loanDto.DocFee);

                //this.CLedgerDAO.UpdateCurrentBalance(acctnoInfoList[1].CreditAccountNo1, Convert.ToDecimal(loanDto.SAmount) + cledger.CurrentBal, Convert.ToDecimal(1), loanDto.CreatedUserId, loanDto.CreatedUserId.ToString());
                this.CLedgerDAO.UpdateCurrentBalance(acctnoInfoList[1].CreditAccountNo1, cledger.CurrentBal, ++cledger.TransactionCount, loanDto.CreatedUserId, loanDto.CreatedUserId.ToString());

                //DateTime firstDate =DateTime.Now.AddMonths(1);// 20/06/2017 => 20/07/2017
                //firstDate = firstDate.AddDays(-1);// 20/06/2017 => 19/07/2017

                DateTime firstDate = DateTime.Now.AddDays(dayForOneMonth);// 22/09/2017 => 22/10/2017 

                this.OutstandLoanBalanceDAO.UpdateFirstDueDate(loanDto.Lno, loanDto.SourceBranchCode, Convert.ToDecimal(loanDto.SAmount), DateTime.Now, firstDate, DateTime.Now, CurrentUserEntity.CurrentUserID);

                int Dayinyear = 337 + (Convert.ToInt32(Convert.ToDateTime("03/01/" + (DateTime.Now.Year)).Day - 1));    //number of days in 1 year   
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    Dayinyear = 366;
                else
                    Dayinyear = 365;

                string output = this.BLDetailsDAO.SaveBLDetailsVoucher(loanDto.Lno, acctnoInfoList[1].CreditAccountNo1, Convert.ToDecimal(loanDto.SAmount), firstDate, Dayinyear, loanDto.CreatedUserId, loanDto.UserNo, loanDto.SourceBranchCode);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90001";

            }

            return voucherNo;

        }

        #region Helper Method

        private LOMORM00023 GetPartial_LoansORM(TLMDTO00018 LoansDto)
        {
            LOMORM00023 partial_LoansORM = new LOMORM00023();

            partial_LoansORM.Lno = LoansDto.Lno;
            partial_LoansORM.Acctno = LoansDto.AccountNo;
            partial_LoansORM.Amount = LoansDto.SAmount;
            partial_LoansORM.Date_Time = LoansDto.CreatedDate;
            partial_LoansORM.SourceBr = LoansDto.SourceBranchCode;
            partial_LoansORM.Cur = LoansDto.Currency;
            partial_LoansORM.CreatedDate = LoansDto.CreatedDate;
            partial_LoansORM.CreatedUserId = LoansDto.CreatedUserId;
            return partial_LoansORM;
        }

        private PFMORM00054 GetTransactionLogFile(TLMDTO00018 LoansDto, string acode, string voucherno, string acctno, string desp, string status, decimal rate, DateTime settlementdate, string trancode, string channel, int forDOC)
        {
            decimal srate = 0;
            PFMORM00054 tlfORM = new PFMORM00054();
            tlfORM.Id = this.TlfDAO.SelectMaxId() + 1;
            tlfORM.Eno = voucherno;
            tlfORM.AccountNo = acctno;
            tlfORM.Acode = acode;
            if (isServieCharges == "true")
            {
                srate = (Convert.ToDecimal(LoansDto.SAmount) * Convert.ToDecimal(LoansDto.serviceChargesRate)) / 100;
                tlfORM.Amount = srate;                //Partial Amount/Full Amount
                tlfORM.HomeAmount = srate;//Partial Amount/Full Amount
                tlfORM.HomeAmt = srate;
            }
            else if (forDOC == 1)
            {
                tlfORM.Amount = Convert.ToDecimal(LoansDto.DocFee);
                tlfORM.HomeAmount = Convert.ToDecimal(LoansDto.DocFee);
                tlfORM.HomeAmt = Convert.ToDecimal(LoansDto.DocFee);
            }
            else
            {
                tlfORM.Amount = Convert.ToDecimal(LoansDto.SAmount); //Partial Amount/Full Amount
                tlfORM.HomeAmount = LoansDto.SAmount == null ? 0 : LoansDto.SAmount;                //Partial Amount/Full Amount
                tlfORM.HomeAmt = LoansDto.SAmount == null ? 0 : LoansDto.SAmount;
            }
            tlfORM.HomeOAmt = 0;
            if (isServieCharges == "true")
            {
                tlfORM.LocalAmt = srate;                  //Partial Amount/Full Amount
                tlfORM.LocalAmount = srate;               //Partial Amount/Full Amount
            }
            else if (forDOC == 1)
            {
                tlfORM.LocalAmt = LoansDto.DocFee == null ? 0 : LoansDto.DocFee;
                tlfORM.LocalAmount = LoansDto.DocFee == null ? 0 : LoansDto.DocFee;
            }
            else
            {
                tlfORM.LocalAmt = LoansDto.SAmount == null ? 0 : LoansDto.SAmount;                  //Partial Amount/Full Amount
                tlfORM.LocalAmount = LoansDto.SAmount == null ? 0 : LoansDto.SAmount;               //Partial Amount/Full Amount
            }
            tlfORM.LocalOAmt = 0;
            tlfORM.Description = desp;
            if (isServieCharges == "true")
            {
                tlfORM.Narration = "1 Year Service Charges:" + LoansDto.Lno;
            }
            else if (forDOC == 1)
            {
                tlfORM.Narration = "Documentation Fee:" + LoansDto.Lno;
            }
            else
            {
                tlfORM.Narration = "LoansVouEnt:" + LoansDto.Lno;
            }
            tlfORM.DateTime = LoansDto.CreatedDate;
            tlfORM.Status = status;
            tlfORM.TransactionCode = trancode;
            //Updated by HWKO (12-Oct-2017)
            PFMDTO00028 DtoForAcsign = this.CLedgerDAO.SelectACSignByAccountNo(acctno);
            if (DtoForAcsign == null) tlfORM.AccountSign = null;
            else tlfORM.AccountSign = DtoForAcsign.AccountSign;
            //Endregion
            tlfORM.UserNo = LoansDto.CreatedUserId.ToString();
            tlfORM.SourceCurrency = LoansDto.Currency;
            tlfORM.Rate = rate;
            tlfORM.SourceBranchCode = LoansDto.SourceBranchCode;
            tlfORM.SettlementDate = settlementdate;
            tlfORM.Channel = channel;
            if (isServieCharges == "true")
            {
                tlfORM.ReferenceType = "LOANS";
            }
            else
            {
                tlfORM.ReferenceType = "LOANS";
            }
            tlfORM.ReferenceVoucherNo = LoansDto.Lno;
            tlfORM.GChequeNo = "1";
            tlfORM.CreatedDate = LoansDto.CreatedDate;
            tlfORM.CreatedUserId = LoansDto.CreatedUserId;
            return tlfORM;
        }

        #endregion

    }
}
