using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00080 : BaseService, ILOMSVE00080
    {
        public string checkStatus;
        public string balance;
        public string dealerStatus;
        public string accountNo;
        public string dealerNo;
        public LOMDTO00084 dto;
        public LOMDTO00092 dto1;
        public IList<LOMDTO00080> lstDealer;
        public IList<LOMDTO00084> lst;
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00006 GetAccountInfomation { get; set; }

        private ITLMDAO00018 loansDAO;
        public ITLMDAO00018 LoansDAO
        {
            get { return this.loansDAO; }
            set { this.loansDAO = value; }
        }

        private ILOMDAO00080 dealerInformationDAO;
        public ILOMDAO00080 DealerInformationDAO
        {
            get { return this.dealerInformationDAO; }
            set { this.dealerInformationDAO = value; }
        }

        public IList<PFMDTO00001> SelectByAccountNumber(string accountNo, DateTime todaydate)
        {
            IList<PFMDTO00001> customer = null;

            // Check saving account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check LegalCase Account No
            if (this.CodeChecker.HasLegalCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check NPLCase Account No
            if (this.CodeChecker.HasNPLCaseAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Check ExpiredLoans Account No
            if (this.CodeChecker.IsExpiredLoansAccount(accountNo, todaydate))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            bool isFAOF = CXServiceWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.isFAOFAccountNo(accountNo));
            if (isFAOF)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90045"; //Current,Saving,Chart of Account Only.
                return null;
            }

            customer = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountNo, false));

            if (customer == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175; // Account Not found.
            }
            return customer;
        }

        public IList<LOMDTO00080> GetAllDealerInformation(string sourceBr)
        {
            lstDealer = this.dealerInformationDAO.GetAllDealerInformation(sourceBr);
            if (lstDealer.Count<1)
            {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MI90113; 
            }
            return lstDealer;
        }

        public IList<LOMDTO00081> GetAllStockItem()
        {
            return this.dealerInformationDAO.GetAllStockItem();
        }

        public IList<LOMDTO00082> GetAllStockGroup()
        {
            return this.dealerInformationDAO.GetAllStockGroup();
        }

        public IList<LOMDTO00083> GetAllInstallmentTypes()
        {
            return this.dealerInformationDAO.GetAllInstallmentTypes();
        }

        public PFMDTO00028 GetCustomerLedgerDataByAccountNo(string accountNo) // To get CLedger Data by AccountNo
        {
            //return this.GetAccountInfomation.GetAccountInfoOfCledgerByAccountNo(accountNo);
            return this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
        }

        public IList<PFMDTO00001> GetCustomerInfomationBySaoforCaof(string accountNo, string accountType)
        {
            //return this.GetAccountInfomation.GetCustomerInfomationByCaofOrSaof(accountNo, accountType);
            return this.CodeChecker.GetCustomerInfomationByCaofOrSaof(accountNo, accountType);
        }

        public IList<PFMDTO00006> GetChequeInfo(string accountNo)
        {
            //return this.GetAccountInfomation.GetStartNoandEndNo(accountNo);
            return this.CodeChecker.GetStartNoandEndNo(accountNo);
        }

        public TLMDTO00018 GetExpireAmount(string accountNo)
        {
            //return this.loansDAO.GetExpireAmount(accountNo);            
            return this.CodeChecker.GetExpireAmount(accountNo);
        }

        public string GetLinkAccount(string accountNo, string accountType)
        {
            //return this.GetAccountInfomation.GetLinkAccountNo(accountNo, accountType);
            return this.CodeChecker.GetLinkAccountNo(accountNo, accountType);
        }

        public PFMDTO00067 ConvertDTODataToRawDTO(string accountNo)
        {
            PFMDTO00067 rawdto = new PFMDTO00067();
            rawdto.AccountNo = accountNo;

            PFMDTO00028 cledgerDto = new PFMDTO00028();
            cledgerDto = this.GetCustomerLedgerDataByAccountNo(accountNo);
            if (cledgerDto != null)
            {
                rawdto.Amount = cledgerDto.CurrentBal;
                rawdto.AccountSign = cledgerDto.AccountSign;
                rawdto.ClosedDate = cledgerDto.CloseDate;
                rawdto.OverDraftAmount = cledgerDto.OverdraftLimit;
                rawdto.LinkAccountNo = this.GetLinkAccount(accountNo, rawdto.AccountSign);
                rawdto.NoOfLoan = cledgerDto.LoansCount;
                rawdto.MiniumBalance = cledgerDto.MinimumBalance;

                TLMDTO00018 loandto = new TLMDTO00018();
                loandto = this.GetExpireAmount(accountNo);
                rawdto.ExpireAmount = (loandto != null) ? ((loandto.ExpireDate < DateTime.Now) ? loandto.SAmount.Value : 0) : 0;
                string accountType = cledgerDto.AccountSign.Substring(0, cledgerDto.AccountSign.Length - 1);
                rawdto.CustomerInfo = this.GetCustomerInfomationBySaoforCaof(accountNo, accountType);
                rawdto.NoOfPersonToSign = (rawdto.CustomerInfo.Count >= 1) ? rawdto.CustomerInfo[0].NoOfPersonSign : 0;
                rawdto.JointType = (rawdto.CustomerInfo.Count > 1) ? rawdto.CustomerInfo[0].JoinType : string.Empty;


                if (rawdto.LinkAccountNo != string.Empty)
                {
                    cledgerDto = this.GetCustomerLedgerDataByAccountNo(rawdto.LinkAccountNo);
                    rawdto.LinkAmount = cledgerDto.CurrentBal;
                }
                rawdto.Photo = rawdto.CustomerInfo[0].CustPhotos;
                rawdto.Signature = rawdto.CustomerInfo[0].Signature;

                if (accountType.Equals("C"))
                    rawdto.ChequeInfo = this.GetChequeInfo(accountNo);

                return rawdto;
            }
            else
            {
                return rawdto = null;
            }
        }

        public PFMDTO00067 GetAccountInformation(string accountNo)
        {
            try
            {
                return this.ConvertDTODataToRawDTO(accountNo);
            }
            catch
            {
                throw new Exception();
            }
        }

        public LOMDTO00084 AddHirePurchaseRegistration(string hpno, string caccount, string dealerAC, string dealerStatus, string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent,// decimal sChgsPercent,
                                                       decimal nextYrRChgsPercent, decimal disAmt, decimal docFees, int gapPeriod, decimal commPercent, string stockGCode, string stockISubCode, string relatedGLACode, decimal productValue, int payDuration, int payOptionId,
                                                       DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string userName)
        {
            try
            {
                string acctNo = this.dealerInformationDAO.CheckDealerAccountExists(dealerAC, sourceBr);

                string HPNo = this.CodeGenerator.GetGenerateCode(CXCOM00009.HPRegistrationCode, CXCOM00009.HirePurchaseRegistration, 1, sourceBr, new object[] { sourceBr });
                //string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.HPRegisterVoucher, CXCOM00009.HirePurchaseVoucher, 1, sourceBr, new object[] { DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
                
                //Modifed By AAM (04-Aug-2017)
                DateTime nextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBr, true });
                //string Eno = this.CodeGenerator.GetGenerateCode(CXCOM00009.NormalVoucher, CXCOM00009.NormalVoucher, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                string Eno = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, 1, sourceBr, new object[] { nextSettlementDate.ToString("dd"), nextSettlementDate.ToString("MM"), nextSettlementDate.ToString("yy") });

                if (acctNo==null||acctNo=="0"|| acctNo=="")
                {
                    string PONo = this.CodeGenerator.GetGenerateCode(CXCOM00009.POCode, CXCOM00009.PaymentOrder, 1, sourceBr, new object[] { sourceBr, DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy") });
                    dealerStatus = PONo;
                }
                else dealerStatus = acctNo;       

                dto = this.dealerInformationDAO.AddHirePurchaseRegistration(HPNo, caccount, dealerAC,dealerStatus, guanteeAcctNo, downPayPercent, rChgsPercent,// sChgsPercent,
                  nextYrRChgsPercent, disAmt, docFees, gapPeriod, commPercent, stockGCode, stockISubCode, relatedGLACode, productValue, payDuration, payOptionId,
                  repaySDate, repayExpDate, sourceBr, remarks, createdUserId, Eno, userName);
                
                if (dto != null && dto.RetMsg == "0")
                {
                    dto.HPNo = HPNo;

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90110;
                    return dto;
                }
               else 
               {
                   if (dto != null)
                   {
                       dto.CloseDate = DateTime.Now;
                       dto.CreatedDate = DateTime.Now;
                       dto.ExpiredDate = DateTime.Now;
                       dto.LastPaiddate = DateTime.Now;
                       dto.RepaySDate = DateTime.Now;
                       dto.UpdatedDate = DateTime.Now;
                   }
             
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV90158;
                   
                }
                return dto;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public string CheckBalance(string caccount,string sourceBr)
        {
            balance = this.dealerInformationDAO.CheckBalance(caccount, sourceBr);
            return balance;
        }

        public IList<LOMDTO00092> GetHPVoucherDetails(LOMDTO00092 d)
        {
            LOMDTO00092 dto = new LOMDTO00092();
            dto.eno = d.eno;
            return this.dealerInformationDAO.GetHPVoucherDetails(dto);
        }

        public string CheckAccountExistsOrValid(string accountNo, string sourceBr)
        {
            if (accountNo.Length < 15)
            {
                checkStatus = "2";
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00199;
                return checkStatus;
            }
            else
            {
                checkStatus = this.dealerInformationDAO.CheckAccountExistsOrValid(accountNo, sourceBr);
                if (checkStatus == "1")
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MV00046;
                    return checkStatus;
                }
                else
                {
                    checkStatus = "0";
                    return checkStatus;
                }
            }
        }

        public string GetInstallmentAmt(decimal netAmt, int noOfTerms)
        {
            string installAmt = this.dealerInformationDAO.GetInstallmentAmt(netAmt,noOfTerms);
            return installAmt;
        }

        ////////////////
        //public IList<decimal> GetRateForHPReg()
        //{
        //    return this.dealerInformationDAO.GetRateForHPReg();
        //}
        public IList<string> GetAllPersonalLoansCompanyName(string sourceBr)
        {
            return this.dealerInformationDAO.GetAllCompanyNameFromPersonalLoans(sourceBr);
        }

        public string GetDealerCommission_ByDealerNo(string dealerNo, string sourceBr)
        {
            return this.dealerInformationDAO.GetDealerCommission_ByDealerNo(dealerNo, sourceBr);
        }
    }   
}
