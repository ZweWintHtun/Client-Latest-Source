//----------------------------------------------------------------------
// <copyright file="CXSVE00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Ser.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Cx.Ser.Sve
{
    /// <summary>
    /// Data_Generate_InSQL
    /// Store Procedures of CBS
    /// </summary>
    public class CXSVE00010 : BaseService, ICXSVE00010
    {
        #region Private Variables
        private ICXDAO00010 dataGenerateDAO;
        #endregion

        #region Properties
        public ICXDAO00010 DataGenerateDAO
        {
            get { return this.dataGenerateDAO; }
            set { this.dataGenerateDAO = value; }
        }
        #endregion

        /// <summary>
        /// Check report parameters has contain the required parameter       
        /// </summary>
        /// <param name="reportParameters"></param>
        /// <returns>bool</returns>

        private bool HasContainRequiredParameter(CXDTO00006 reportParameters)
        {
            return (string.IsNullOrEmpty(reportParameters.BDateType) || reportParameters.StartDate.Equals(DateTime.MinValue) || reportParameters.EndDate.Equals(DateTime.MinValue) || reportParameters.ForCheck_Or_ForReturn.Equals(0) || reportParameters.CreatedUserId.Equals(0) || reportParameters.UserNo.Equals("0")) ? false : true;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 GetReportDataGenerateInSQL(CXDTO00006 reportParameters)
        {
            try
            {
                if (this.HasContainRequiredParameter(reportParameters))
                {
                    if (CXCOM00006.Instance.IsValidStartDateEndDate(reportParameters.StartDate, reportParameters.EndDate))
                    {
                        return this.DataGenerateDAO.GetReportByTransactionDate_Or_SettlementDate(reportParameters);
                    }
                    else
                    {
                        throw new Exception(CXMessage.MV00131); //Start Date must not be greater than End Date.
                    }
                }
                else
                {
                    throw new Exception(CXMessage.ME90018); //Invalid Parameter.
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool HasSavingAccountTransaction(string accountNo, int userid)
        {
            string code = this.DataGenerateDAO.IsCheckSavingDate(accountNo, userid);
            if (code == "1019")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00135; // Not Allow Saving Debit Transaction for more than one time in a week
                return true;
            }

            return false;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool AllUpdateForWithdraw(string eno, string acctno, decimal amount, decimal Oamount, bool wStatus, string chequeNo, string userId, string soruceBr, string channel, DateTime settlementDate,bool isAutoLink, string errorMessage, int createdUserId)
        {

            string code = this.dataGenerateDAO.AllUpdateForWithdrawal(eno, acctno, amount, Oamount, chequeNo, soruceBr, settlementDate, channel,isAutoLink, createdUserId);
             if (code == "ERROR IN TRANCODE (WITHDRAW)")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00190; //"ERROR IN TRANCODE (WITHDRAW)"
                return false;
            }
            else if (code == "AUTO LINK WITHDRAW PROCESS COMPLETE!...")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00191; //AUTO LINK WITHDRAW PROCESS COMPLETE!...
                return false;
            }
            else if (code == "INSUFFICIENT BALANCE")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00109; //INSUFFICIENT BALANCE...
                return true;

            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MV00192; //SUCCESSFULLY WITHDRAW TRANSACTION!...
                return true; 
            }
            

        }

        [Transaction(TransactionPropagation.Required)]
        public bool IBL_Withdrawal(string voucherNo, string accountNo, decimal amount, string isVIP, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
               string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel, string chequeNo, int createdUserId)
        {

            string code = this.DataGenerateDAO.IBL_Withdrawal(voucherNo, accountNo, amount, isVIP, forceCheck, minBalCheck, tempStatus, tempTranCode, reference, receiptNo, fromBranch, incomeAmount, faxCharges, takeIncome, IBSAC, incomeAC, faxAC, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate, channel, chequeNo, createdUserId);
            if (code == "1019")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00135; // Not Allow Saving Debit Transaction for more than one time in a week
                return false;
            }
            else if (code == "000" || code == "0")
            {
                this.ServiceResult.ErrorOccurred = false;
                return true; 
            }
            else if (code.Contains("System"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00018; // Transaction is not Success!
                return false;
            }
            else
            {
              code = this.TranslateToCXMessageCode(code);
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = code; 
              return false;
            }
       
        }

        [Transaction(TransactionPropagation.Required)]
        public bool IBL_Voucher(string eno, string acode, decimal amount, string status, string trancode, string type, string orgnTranCode, string orgnEno, decimal incomeAmount, decimal faxCharges, int takeincome, string incomeAc, string FaxAc, string userId, string curCode, string sourceCur, decimal exchangeRate, string soruceBr, DateTime settlementDate, string channel)
        {
            string code = this.DataGenerateDAO.IBL_Voucher(eno, acode, amount, status, trancode, type, orgnTranCode, orgnEno, incomeAmount, faxCharges, takeincome, incomeAc, FaxAc, userId, curCode, sourceCur, exchangeRate, soruceBr, settlementDate, channel);
            if (code == "1019")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00135; // Not Allow Saving Debit Transaction for more than one time in a week
                return false;
            }
            else
            {
                code = this.TranslateToCXMessageCode(code);
                if (!code.Contains("MI"))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = code; // Not Allow Saving Debit Transaction for more than one time in a week
                    return false;
                }
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public string UpdateForTransfer(string voucherNo, string accountNo, decimal amount, decimal oAmount, string chequeNo, string voucherStatus, bool status, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            string code = this.dataGenerateDAO.UpdateForTransfer(voucherNo, accountNo, amount, oAmount, chequeNo, voucherStatus, status, narration, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate, channel);

            code = this.TranslateToCXMessageCode(code);

            return code;
        }

        public bool AllUpdateForClearing(PFMORM00054 tlf, bool wStatus)
        {
            string code = this.dataGenerateDAO.AllUpdateForClearing(tlf, wStatus);
            bool returnType = false;
            switch (code.Trim())
            {
                case "ERROR IN TRANCODE (ATLDRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (ATLCRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                  
                    break;
                case "ERROR IN TRANCODE (ATLFEEAC)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (TRDEBIT)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.
                    break;

                case "ERROR IN TRANCODE (CLRECEIPT)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;

                case "INVALID LINK ACCOUNT":

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00174; //Invalid Link Account.                   
                    break;
                case "INSUFFICIENT BALANCE IN LINK PROCESS":

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI00058; //Insufficient Balance in Link Process.                  
                    break;
                case "INSUFFICIENT BALANCE":

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00109; //Insufficient Balance.                   
                    break;
                case "ERROR IN AUTOLINK UPDATING":

                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00051; //Error in AutoLink Updating.                   
                    break;
                case "AUTO LINK CLEARING PROCESS COMPLETE!...":

                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
            }
            return returnType;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool IsValidAmountCheck(CXDTO00004 parameters)
        {
            CXDTO00008 spReturn = this.DataGenerateDAO.IBL_AmountCheck(parameters);
            if (spReturn.ReturnType == 1)
            {
                this.ServiceResult.ErrorOccurred = false;
                return true;
            }
            else
            {
                //2003 Insufficient Amount                                                                                 
                //2002 Transaction Amount is less than the Minimum transaction amount                                      
                //2004 Invalid Transaction Amount     
                //2001 Transaction Amount cannot be divided by divider amount  
                string errorMessageCode = Convert.ToString(spReturn.ErrorNo);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = this.TranslateToCXMessageCode(errorMessageCode);
                return false;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool IsLinkOKForCurrentAccount(CXDTO00004 parameters)
        {
            CXDTO00008 spReturn = this.DataGenerateDAO.SP_ATL_AMOUNTCHECKING_CHECK_SAVAC_DATE(parameters);
            if (spReturn.ReturnValue == "3")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00109;
                return false;
            }

            else if (spReturn.ReturnValue == "1019")
            {
                //2003 Insufficient Amount
                //2002 Transaction Amount is less than the Minimum transaction amount                                      
                //2004 Invalid Transaction Amount     
                //2001 Transaction Amount cannot be divided by divider amount  
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.TranslateToCXMessageCode(Convert.ToString(spReturn.ReturnValue));
                return false;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                return true;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool EncashVou(TLMDTO00001 reDTO)
        {
            string code = this.dataGenerateDAO.EncashVou(reDTO);
            bool returnType = false;
            switch (code.Trim())
            {
                case "ERROR IN REMITBR (IRPOAC)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00190; //"ERROR IN TRANCODE (WITHDRAW)"
                    break;

                case "ERROR IN TRANCODE (EREMITCRTR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00190; //"ERROR IN TRANCODE (WITHDRAW)"
                    break;

                case "ERROR IN COASETUP (IBSIR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00190; //"ERROR IN TRANCODE (WITHDRAW)"
                    break;

                case "'ERROR FROM PO ENCASH VOUCHER STORE PROCEDURE!...' ":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00190; //"ERROR IN TRANCODE (WITHDRAW)"
                    break;

                case "ERROR IN COA FILE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00041"; //Client Data Not found.                   
                    break;
                case "ERROR IN LEDGER FILE(MAIN ACCTNO)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00042"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCURCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00043"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCALCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00044"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MSAVCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00045"; //Client Data Not found.                   
                    break;

                case "SAVING SUCCESSFUL":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
            }
            return returnType;
        }

        public string TranslateToCXMessageCode(string errorMessageCode)
        {
            if (string.IsNullOrEmpty(errorMessageCode))
            {
                throw new Exception(CXMessage.ME90018); //Invalid Parameter.
            }
            else
            {
                TLMDTO00055 dto = CXCOM00011.Instance.GetScalarObject<TLMDTO00055>("CXSVE00011.Server.CXMessageCode.Select", new object[] { errorMessageCode });
                return (dto != null) ? dto.CXMessageCode : string.Empty;
            }
        }

        public string IsCheckSavingDate(string accountNo, int userId)
        {
            return this.DataGenerateDAO.IsCheckSavingDate(accountNo, userId);
        }

        [Transaction(TransactionPropagation.Required)]
        public bool IBLRemit(TLMDTO00017 drawingRemitDTO)
        {
            string code = this.dataGenerateDAO.IBLRemit(drawingRemitDTO);
            bool returnType = false;
            switch (code.Trim())
            {
                case "ERROR IN REMITBRIBL FILE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00052"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (IBS)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00050"; //Client Data Not found.                   
                    break;
                case "DRAWING NO IS ALREADY PASSED."://register no need
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI00060"; //Client Data Not found.  
                    this.ServiceResult.OutputParameter = drawingRemitDTO.RegisterNo;
                    break;
                case "ERROR IN IBL REMIT STORE PROCEDURE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00053"; //Client Data Not found.                   
                    break;
                case "ERROR IN COA FILE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00041"; //Client Data Not found.                   
                    break;
                case "ERROR IN LEDGER FILE(MAIN ACCTNO)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00042"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCURCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00043"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCALCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00044"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MSAVCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00045"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (ATLDRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00046                   
                    break;
                case "ERROR IN TRANCODE (ATLCRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00047                  
                    break;
                case "ERROR IN TRANCODE (ATLFEEAC)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (TRDEBIT)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00048
                    break;

                case "ERROR IN TRANCODE (CLRECEIPT)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;

                case "INVALID LINK ACCOUNT":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00174; //Invalid Link Account. MV00182                  
                    break;
                case "INSUFFICIENT BALANCE IN LINK PROCESS":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI00058; //Insufficient Balance in Link Process.                  
                    break;
                case "INSUFFICIENT BALANCE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00109; //Insufficient Balance.                   
                    break;
                case "ERROR IN AUTOLINK UPDATING":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00051; //Error in AutoLink Updating.                   
                    break;
                case "SUCCESSFUL AUTOLINK UPDATING":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
                case "SAVING SUCCESSFUL.":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
            }
            return returnType;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool RemitVoucher(TLMDTO00017 drawingRemitDTO)
        {
            string code = this.dataGenerateDAO.RemitVoucher(drawingRemitDTO);
            bool returnType = false;
            switch (code.Trim())
            {
                case "ERROR IN REMITTANCE FILE(BRANCHCODE)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (DREMITDRTR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (IBSIR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (DREMITCRTR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "REMITTANCE VOUCHER UPDATE COMPLETE!":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
                case "ERROR FROM REMITTANCE VOUCHER STORE PROCEDURE!":
                    this.ServiceResult.ErrorOccurred = true;
                    //this.ServiceResult.MessageCode = "ME00050"; //Client Data Not found.                   
                    break;
                case "ERROR IN COA FILE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00041"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCURCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00043"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCALCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00044"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MSAVCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00045"; //Client Data Not found.                   
                    break;
            }
            return returnType;
        }


        [Transaction(TransactionPropagation.Required)]
        public bool AllUpdateRemit(TLMDTO00017 drawingRemitDTO)
        {
            string code = this.dataGenerateDAO.AllUpdateRemit(drawingRemitDTO);
            bool returnType = false;
            switch (code.Trim())
            {
                case "ERROR IN REMITTANCE FILE(BRANCHCODE)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "ERROR IN TRANCODE (DREMITCRTR)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00021"; //Client Data Not found.                   
                    break;
                case "AUTO LINK REMITTANCE PROCESS COMPLETE!":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
                case "AUTO LINK SPECIAL COLLECTION PROCESS COMPLETE!":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
                case "ERROR FROM NAME ENQUIRY STORE PROCEDURE!":
                    this.ServiceResult.ErrorOccurred = true;
                    //this.ServiceResult.MessageCode = "ME00050"; //Client Data Not found.                   
                    break;
                case "ERROR IN COA FILE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00041"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCURCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00043"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MCALCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00044"; //Client Data Not found.                   
                    break;
                case "ERROR IN COASP FILE (MSAVCON)":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME00045"; //Client Data Not found.                   
                    break;
                case "INSUFFICIENT BALANCE":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00109; //Insufficient Balance.                   
                    break;
                case "ERROR IN TRANCODE (ATLDRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00047                  
                    break;
                case "ERROR IN TRANCODE (ATLCRTR)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00047                  
                    break;
                case "ERROR IN TRANCODE (TRDEBIT)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.ME00048
                    break;
                case "ERROR IN TRANCODE (ATLFEEAC)"://ERROR FOR TRANTYPE ACCOUNT CODE NOT FOUND.
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                    break;
                case "ERROR IN AUTOLINK UPDATING":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00051; //Error in AutoLink Updating.                   
                    break;
                case "SUCCESSFUL AUTOLINK UPDATING":
                    this.ServiceResult.ErrorOccurred = false;
                    returnType = true;
                    break;
                case "INVALID LINK ACCOUNT":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00174; //Invalid Link Account. MV00182                  
                    break;
                case "INSUFFICIENT BALANCE IN LINK PROCESS":
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI00058; //Insufficient Balance in Link Process.                  
                    break;
            }
            return returnType;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool IBL_Deposit(string voucherNo, string accountNo, decimal amount, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
             string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string narTest, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            string code = this.DataGenerateDAO.IBL_Deposit(voucherNo, accountNo, amount, forceCheck, minBalCheck, tempStatus, tempTranCode, reference, receiptNo, fromBranch, incomeAmount, faxCharges, takeIncome, IBSAC, incomeAC, faxAC, narTest, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate.ToShortDateString(), channel);

            code = this.TranslateToCXMessageCode(code);
            if (!code.Contains("MI"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = code; // Not Allow Saving Debit Transaction for more than one time in a week
                return false;
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool TransferDebitVoucher(string voucherNo, string accountNo, string isVIP, decimal amount, string chequeNo, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string creditAccount, decimal comissionCharges, decimal communicationCharges, bool status, string iBSAC, string incomeAC, string faxAC, int takeIncome, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            string code = this.DataGenerateDAO.TransferDebitVoucher(voucherNo, accountNo, isVIP, amount, chequeNo, voucherStatus, transactionCode, reference, debitBranch, creditBranch, creditAccount, comissionCharges, communicationCharges, status, iBSAC, incomeAC, faxAC,takeIncome, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate, channel);
            code = this.TranslateToCXMessageCode(code);

            if (!code.Contains("MI"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = code;
                return false;
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool TransferCreditVoucher(string voucherNo, string accountNo, decimal amount, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string debitAccount, bool status, string iBSAC, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            string code = this.DataGenerateDAO.TransferCreditVoucher(voucherNo, accountNo, amount, voucherStatus, transactionCode, reference, debitBranch, creditBranch, debitAccount, status, iBSAC, narration, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate, channel);
            code = this.TranslateToCXMessageCode(code);
            if (!code.Contains("MI"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = code;
                return false;
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool TransferSameBarnchVoucher(string voucherNo, string creditAccountNo, string debitAccountNo, string chequeNo, string isVIP, decimal amount, decimal incomeAmount, decimal faxCharges, string debitBranch, string creditBranch, string fromBranch, bool status, string iBSAC, string faxAC, int takeIncome, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            string code = this.DataGenerateDAO.TransferSameBarnchVoucher(voucherNo, creditAccountNo, debitAccountNo, chequeNo, isVIP, amount, incomeAmount, faxCharges, debitBranch, creditBranch, fromBranch, status, iBSAC, faxAC,takeIncome, narration, userId, sourceCur, homeExchangeRate, sourceBr, settlementDate, channel);

            code = code == "1" ? "3004" : code;
            code = this.TranslateToCXMessageCode(code);
            if (!code.Contains("MI"))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = code;
                return false;
            }
            return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool EncashIBLPassing(int id, string eno, string acctno, decimal amount, string registerno, string pono, bool postatus, string encashNo, string userno, bool closestatus, string budgetyear, string narrationtext, string branchcode, string sourcecur, decimal homeexchangerate, string sourceBranch, DateTime settlementdate, string channel, int createdUserId)
        {
            string Message = this.DataGenerateDAO.IBLEncashPassing(id, eno, acctno, amount, registerno, pono, postatus, encashNo, userno, closestatus, budgetyear, narrationtext, branchcode, sourcecur, homeexchangerate, sourceBranch, settlementdate, channel, createdUserId);
            if (!String.IsNullOrEmpty(Message))
            {
                switch (Message.Trim())
                {
                    case "THIS ACCOUNT IS IN LEGAL CASE.":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                        break;

                    case "THIS ACCOUNT IS EXPIRED IN LOANS/OD":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00054;
                        break;

                    case "ERROR IN COASETUP (POR)":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                        break;

                    case "ERROR IN TRANCODE (EREMITCRTR)":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                        break;

                    case "ERROR IN COASETUP ( IBS )":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                        break;

                    case "ERROR FROM ENCASHMENT VOUCHER STORE PROCEDURE!...":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00062;
                        break;

                    case "ERROR IN PONO":
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME00063";
                        break;
                }

                return false;
            }
            else
                return true;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DepositAdjustment(string newEno, string eno, string mAcctno, string mAcode, string mName, decimal amount, decimal oAmount, string mAcSign, string currency, decimal homeExRate, string brCode, DateTime sattlementDate, int createduserId, string channel)
        {
            string code = this.dataGenerateDAO.DepositAdjustment(newEno, eno, mAcctno, mAcode, mName, amount, oAmount, mAcSign, currency, homeExRate, brCode, sattlementDate, createduserId, channel);
            if (code == "Error in TranCode (Reversal Deposit)")
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.
                return false;
            }
            else if (code == "Successfully Deposit Reversal Transaction!...")
            {
                this.ServiceResult.ErrorOccurred = false;
                return true;
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90039; // Database Error Occur.
                return false;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool ServiceCharges(CXDTO00010 servicechargedto)
        {
            this.DataGenerateDAO.ServiceCharges(servicechargedto);
            return true;
            
        }

        [Transaction(TransactionPropagation.Required)]
        public bool NPLServiceCharges(CXDTO00010 servicechargedto)
        {
            this.DataGenerateDAO.ServiceCharges(servicechargedto);
            return true;

        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollCALC(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId)
        {
            PFMDTO00042 BankCashDTO = this.DataGenerateDAO.BankCashScrollCALC(machineName, requestDate, rStatus, dStatus, currency, brCode, createduserId);
            return BankCashDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScroll(string machineName, DateTime requestDate, int rStatus, string dStatus, string brCode, int createduserId)
        {
            PFMDTO00042 BankCashDTO = this.DataGenerateDAO.BankCashScroll(machineName, requestDate, rStatus, dStatus, brCode, createduserId);
            return BankCashDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollBySourceCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, int createduserId)
        {
            PFMDTO00042 BankCashDTO = this.DataGenerateDAO.BankCashScrollBySourceCur(machineName, requestDate, rStatus, dStatus, currency, createduserId);
            return BankCashDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollByHomeCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId)
        {
            PFMDTO00042 BankCashDTO = this.DataGenerateDAO.BankCashScrollByHomeCur(machineName, requestDate, rStatus, dStatus, currency, brCode, createduserId);
            return BankCashDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceByHomeCurrencyAll(string machineName, DateTime requestDate, string parameter, int rStatus, string brCode, int createduserId)
        {
            PFMDTO00042 CleanCashDTO = this.DataGenerateDAO.ClosingBalanceByHomeCurrencyAll(machineName, requestDate, parameter, rStatus, brCode, createduserId);
            return CleanCashDTO;
        }


        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceBySourceCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, int createduserId)
        {
            PFMDTO00042 CleanCashDTO = this.DataGenerateDAO.ClosingBalanceBySourceCurrency(machineName, requestDate, parameter, rStatus, currency, createduserId);
            return CleanCashDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalance(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId)
        {
            PFMDTO00042 CleanCashDTO = this.DataGenerateDAO.ClosingBalance(machineName, requestDate, parameter, rStatus, currency, brCode, createduserId);
            return CleanCashDTO;
        }


        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceByHomeCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId)
        {
            PFMDTO00042 CleanCashDTO = this.DataGenerateDAO.ClosingBalanceByHomeCurrency(machineName, requestDate, parameter, rStatus, currency, brCode, createduserId);
            return CleanCashDTO;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public PFMDTO00042 BankCashScrollCALC(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId)
        //{
        //    PFMDTO00042 BankCashDTO = this.DataGenerateDAO.BankCashScrollCALC(machineName, requestDate, rStatus, dStatus, currency, brCode, createduserId);
        //    return BankCashDTO;
        //}


        [Transaction(TransactionPropagation.Required)]
        public bool Sp_ChangeTables(DateTime lastSettlementDate, DateTime nextSettlementDate)
        {
            this.DataGenerateDAO.SP_ChangeTables(lastSettlementDate,nextSettlementDate);
            return true;

        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 GetMatureDate(DateTime requiredDate, decimal duration, DateTime registerDate, int createduserId)
        {
            PFMDTO00042 DateDTO = this.DataGenerateDAO.GetMatureDate(requiredDate, duration, registerDate, createduserId);
            return DateDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 GetInterest(DateTime requiredDate, decimal amount, int createduserId)
        {
            PFMDTO00042 InterestDTO = this.DataGenerateDAO.GetInterest(requiredDate, amount, createduserId);
            return InterestDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<object> CashDenominationListing(string currency, string whereString, string orderString)
        {

            try
            {
                return this.dataGenerateDAO.CashDenominationListing(currency, whereString, orderString);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return null;
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public IList<object> CashControlRefundList(string currency, string whereString, string orderString)
        {

            try
            {
                return this.dataGenerateDAO.CashControlRefundListString(currency, whereString, orderString);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return null;
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public bool SavePOIssueEntry(TLMDTO00043 POIssueDTO)
        {            
               string message = this.dataGenerateDAO.POIssueByTransfer(POIssueDTO);
                 //message = "";
             if (!String.IsNullOrEmpty(message))
                {
                    switch (message.Trim())
                    {
                        case "ERROR IN TRANCODE (POIDRTR)":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                            break;

                        case "ERROR IN TRANCODE (POICRTR)":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.MV00054;
                            break;

                        case "AUTO LINK PO PROCESS COMPLETE!...":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                            break;

                        //case "PO TRANSACTION IS SUCCESSFULLY PROGRESS!...":
                        //    this.ServiceResult.ErrorOccurred = true;
                        //    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                        //    break;

                        case "ERROR FROM NAME ENQUIRY STORE PROCEDURE!...":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not found.                   
                            break;
                    }

                    return false;
                }
                else
                {
                    return true;
                }
        }



        public IList<object> CashControlTotalVaultList(string currency, string whereString, string orderString)
        {
            try
            {
                return this.dataGenerateDAO.CashControlTotalVault(currency, whereString, orderString);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return null;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00054 Sp_ALUpdate_Check(string accountno)
        {
            PFMDTO00054 tlfdto = this.DataGenerateDAO.Sp_ALUpdate_Check(accountno);
            return tlfdto;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Sp_ALUpdate_Int_TransferAdjust(string neweno, string eno, string accountno, decimal amount, string cheque, string userno,
           bool tstatus, string voustatus, string channel, string refvno, string reftype, string sourcebr, decimal rate, string cur, DateTime settlementdate)
        {
            string returnmessage = this.DataGenerateDAO.Sp_ALUpdate_Int_TransferAdjust(neweno,eno,accountno,amount,cheque,userno,tstatus,voustatus,channel,refvno,reftype,sourcebr,rate,cur,settlementdate);
            return returnmessage;
        }

        
    }
}
