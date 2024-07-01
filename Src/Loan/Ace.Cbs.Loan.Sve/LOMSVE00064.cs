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
    public class LOMSVE00064 : BaseService, ILOMSVE00064
    {
        public string checkStatus;
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

        private ILOMDAO00064 dealerRegistrationDAO;
        public ILOMDAO00064 DealerRegistrationDAO
        {
            get { return this.dealerRegistrationDAO; }
            set { this.dealerRegistrationDAO = value; }
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

        public string Save(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email, string nrc, string fax, string businessName, string city, string businessEmail, string address, decimal commission, string eventMode, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate)
        {
            try
            {
                if (eventMode == "SAVE")
                {
                    string dealerRegId = this.CodeGenerator.GetGenerateCode(CXCOM00009.DealerRegistrationCode, CXCOM00009.DealerRegistration, 1, sourceBr, new object[] { sourceBr });
                    this.dealerRegistrationDAO.AddDealerRegistration(dealerRegId, dealerAC, dName, dPhone, dAddress, email, nrc, fax, businessName, city, businessEmail, address, commission, eventMode, sourceBr, createdUserId, createdDate, updatedUserId, updatedDate);

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90107;
                    return dealerRegId;
                }
                else
                {
                    this.dealerRegistrationDAO.AddDealerRegistration(dealerNo, dealerAC, dName, dPhone, dAddress, email, nrc, fax, businessName, city, businessEmail, address, commission, eventMode, sourceBr, createdUserId, createdDate, updatedUserId, updatedDate);
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = CXMessage.MI90108;
                    return dealerNo;
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }

        }

        public void Delete(string dealerNo, int createdUserId, string sourceBr)
        {
            try
            {
                this.dealerRegistrationDAO.DeleteDealerRegistration(dealerNo, createdUserId,sourceBr);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90109;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
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

        public IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr)
        {
            return this.dealerRegistrationDAO.GetDealerAccountInfo(acctNo, sourceBr);
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
    }
}
