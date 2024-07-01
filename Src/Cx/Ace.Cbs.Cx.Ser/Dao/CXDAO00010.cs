//----------------------------------------------------------------------
// <copyright file="CXDAO00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Stereotype;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using NHibernate.Transform;
using System.Data.SqlClient;
using System.Data;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Data_Generate_DAO Class
    /// </summary>
    [Repository]
    public class CXDAO00010 : DataRepository<PFMORM00054>, ICXDAO00010
    {
        /// <summary>
        /// Get Report By Trasaction Date Or SettlementDate.
        /// </summary>
        /// <param name="reportParameters"></param>
        /// <returns></returns>
        public PFMDTO00042 GetReportByTransactionDate_Or_SettlementDate(CXDTO00006 reportParameters)
        {
            string storeProcedureName = string.Empty;
            switch (reportParameters.BDateType)
            {
                case "T":
                    if (string.IsNullOrEmpty(reportParameters.SpecialCondition) || !(reportParameters.SpecialCondition.ToLower().Contains("sourcebr")))
                        storeProcedureName = "SP_INSERT_REPORT_DATA_ALLBRANCH";
                    else
                        storeProcedureName = "SP_INSERT_REPORT_DATA";
                    break;
                case "S":
                    if (string.IsNullOrEmpty(reportParameters.SpecialCondition) || !(reportParameters.SpecialCondition.ToLower().Contains("sourcebr")))
                        storeProcedureName = "SP_INSERT_REPORT_DATA_SDATE_ALLBRANCH";
                    else
                        storeProcedureName = "SP_INSERT_REPORT_DATA_SDATE";
                    break;
            }
            IQuery query = this.Session.GetNamedQuery(storeProcedureName);
            #region Required Parameter
            query.SetString("startdate", reportParameters.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("enddate", reportParameters.EndDate.ToString("yyyy/MM/dd"));

            switch (reportParameters.ForCheck_Or_ForReturn)
            {
                case CXDMD00009.ForCheck:
                    query.SetString("c_r", "C");
                    break;
                case CXDMD00009.ForReturn:
                    query.SetString("c_r", "R");
                    break;
            }
            query.SetInt32("createduserId", reportParameters.CreatedUserId);
            #endregion

            #region Optional Parameter
            if (string.IsNullOrEmpty(reportParameters.AccountNo))
            {
                query.SetString("accountno", string.Empty);
            }
            else
            {
                query.SetString("accountno", reportParameters.AccountNo);
            }

            if (string.IsNullOrEmpty(reportParameters.ACode))
            {
                query.SetString("acode", string.Empty);
            }
            else
            {
                query.SetString("acode", reportParameters.ACode);
            }

            if (string.IsNullOrEmpty(reportParameters.ACSign))
            {
                query.SetString("acsign", string.Empty);
            }
            else
            {
                query.SetString("acsign", reportParameters.ACSign);
            }

            if (string.IsNullOrEmpty(reportParameters.CashClearTransaction))
            {
                query.SetString("cashcleartran", string.Empty);
            }
            else
            {
                query.SetString("cashcleartran", reportParameters.CashClearTransaction);
            }

            if (reportParameters.Debit_Or_Credit != null)
            {
                switch (reportParameters.Debit_Or_Credit)
                {
                    case CXDMD00002.Credit:
                        query.SetString("creditdebit", "C");
                        break;
                    case CXDMD00002.Debit:
                        query.SetString("creditdebit", "D");
                        break;
                }
            }
            else
            {
                query.SetString("creditdebit", string.Empty);
            }

            if (string.IsNullOrEmpty(reportParameters.OrginalENo))
            {
                query.SetString("orgneno", string.Empty);
            }
            else
            {
                query.SetString("orgneno", reportParameters.OrginalENo);
            }

            if (string.IsNullOrEmpty(reportParameters.UserNo))
            {
                query.SetString("userno", string.Empty);
            }
            else
            {
                query.SetString("userno", reportParameters.UserNo);
            }
            if (string.IsNullOrEmpty(reportParameters.TransactionCode))
            {
                query.SetString("trancode", string.Empty);
            }
            else
            {
                query.SetString("trancode", reportParameters.TransactionCode);
            }
            if (string.IsNullOrEmpty(reportParameters.SpecialCondition))
            {
                query.SetString("specialcond", string.Empty);
            }
            else
            {
                query.SetString("specialcond", reportParameters.SpecialCondition);
            }

            #endregion

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));

            query.SetTimeout(10000);
            PFMDTO00042 output = query.UniqueResult<PFMDTO00042>();
            return output;

        }      

        [Transaction(TransactionPropagation.Required)]
        public string IBL_Voucher(string eno, string acode, decimal amount, string status, string trancode, string type, string orgnTranCode, string orgnEno,
            decimal incomeAmount, decimal faxCharges, int takeincome, string incomeAc, string FaxAc, string userId, string curCode, string sourceCur, decimal exchangeRate, string soruceBr, DateTime settlementDate, string channel)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_IBLVoucher_IBD");
                query.SetString("eno", eno);
                query.SetString("acode", acode);
                query.SetDecimal("amount", amount);
                query.SetString("status", status);
                query.SetString("trancode", trancode);
                query.SetString("type", "1");
                query.SetString("orgnTranCode", orgnTranCode);
                query.SetString("orgnEno", orgnEno);
                query.SetDecimal("incomeAmount", incomeAmount);
                query.SetDecimal("faxCharges", faxCharges);
                query.SetInt32("takeIncome", takeincome);
                query.SetString("incomeAc", incomeAc);
                query.SetString("FaxAc", FaxAc);
                query.SetString("userId", userId);
                query.SetString("curCode", curCode);
                query.SetString("sourceCur", sourceCur);
                query.SetDecimal("homeExchaneRate", exchangeRate);
                query.SetString("sourceBr", soruceBr);
                query.SetString("Settlementdate", settlementDate.ToShortDateString());
                query.SetDateTime("createdDate", DateTime.Now);
                query.SetString("channel", channel);

                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            { return null; }
        }

        [Transaction(TransactionPropagation.Required)]
        public string IBL_Deposit(string voucherNo, string accountNo, decimal amount, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
            string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string narTest, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, string settlementDate, string channel)
        {
            IQuery query = this.Session.GetNamedQuery("SP_IBL_DEPOSIT_NAR_IBD");
            query.SetString("voucherNo", voucherNo);
            query.SetString("acctno", accountNo);
            query.SetDecimal("amount", amount);
            query.SetInt32("forceCheck", forceCheck);
            query.SetInt32("minBalCheck", minBalCheck);
            query.SetString("tempStatus", tempStatus);
            query.SetString("tempTranCode", tempTranCode);
            query.SetString("reference", reference);
            query.SetDecimal("receipt_No", receiptNo);
            query.SetString("fromBranch", fromBranch);
            query.SetDecimal("incomeAmount", incomeAmount);
            query.SetDecimal("faxCharges", faxCharges);
            query.SetInt32("takeIncome", takeIncome);
            query.SetString("IBSAC", IBSAC);
            query.SetString("incomeAC", incomeAC);
            query.SetString("faxAC", faxAC);
            query.SetString("narTest", narTest);
            query.SetString("userId", userId);
            query.SetString("sourceCur", sourceCur);
            query.SetDecimal("homeExchangeRate", homeExchangeRate);
            query.SetString("soruceBr", sourceBr);
            query.SetString("Settlementdate", settlementDate);
            query.SetString("channel", channel);
            query.SetDateTime("createdDate", DateTime.Now);

            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string IsCheckSavingDate(string accountNo, int userId)
        {
            #region oldData
            //IQuery query = this.Session.GetNamedQuery("IBL_CHECK_SAVAC_DATE_SP");
            //query.SetString("acctno", accountNo);
            //query.SetString("startDate", System.DateTime.Now.ToString("yyyy/MM/dd"));
            //query.SetString("endDate", System.DateTime.Now.ToString("yyyy/MM/dd"));
            //query.SetInt32("createdUserId", userId);
            //return query.UniqueResult().ToString();
            #endregion
            ITransaction transaction = this.Session.BeginTransaction();
            IDbConnection connection = this.Session.Connection;
            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.IBL_CHECK_SAVAC_DATE_SP";

            // Set the command to exeute using the NHibernate's transaction
            transaction.Enlist(command);

            //Set Input Parameter
            #region Input Parameter
            var ACCTNO = new SqlParameter("@ACCTNO", SqlDbType.VarChar);
            ACCTNO.Value = accountNo;
            ACCTNO.Size = 15;
            command.Parameters.Add(ACCTNO);

            var STARTDATE = new SqlParameter("@STARTDATE", SqlDbType.VarChar);
            //STARTDATE.Value = DateTime.Now.ToShortDateString();
            STARTDATE.Value = DateTime.Now.ToString("yyyy/MM/dd");         
            STARTDATE.Size = 10;
            command.Parameters.Add(STARTDATE);

            var ENDDATE = new SqlParameter("@ENDDATE", SqlDbType.VarChar);
            //ENDDATE.Value = DateTime.Now.ToShortDateString();
            ENDDATE.Value = DateTime.Now.ToString("yyyy/MM/dd");   
            ENDDATE.Size = 10;
            command.Parameters.Add(ENDDATE);

            var USERID = new SqlParameter("@USERID", SqlDbType.VarChar);
            USERID.Value = userId;
            USERID.Size = 5;
            command.Parameters.Add(USERID);
            #endregion

            // Set output parameter
            #region Output Parameter

            var RETURNVOUNO = new SqlParameter("@RETURNVOUNO", SqlDbType.VarChar);
            RETURNVOUNO.Direction = ParameterDirection.Output;
            RETURNVOUNO.Size = 11;
            command.Parameters.Add(RETURNVOUNO);

            #endregion

            command.ExecuteNonQuery();
            return RETURNVOUNO.Value.ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string AllUpdateForWithdrawal(string eno, string acctno, decimal amount, decimal Oamount, string chequeNo, string soruceBr, DateTime settlementDate, string channel, bool isAutoLink, int createdUserId, bool isLastWithdraw)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_WITHDRAW");
                query.SetString("ENO", eno);
                query.SetString("MACCTNO", acctno);
                query.SetDecimal("AMOUNT", amount);
                query.SetDecimal("OAMOUNT", Oamount);
                query.SetString("CHEQUE", chequeNo);
                query.SetString("USERNO", Convert.ToString(createdUserId));
                query.SetBoolean("WSTATUS", isAutoLink);
                query.SetString("SOURCEBR", soruceBr);
                query.SetString("CHANNEL", channel);
                query.SetDateTime("SETTLEMENTDATE", settlementDate);
                query.SetInt32("CreatedUserId", createdUserId);
                query.SetDateTime("CreatedDate", DateTime.Now);
                query.SetInt32("UpdatedUserId", createdUserId);
                query.SetBoolean("IsLastWithdraw", isLastWithdraw);
                query.SetString("ERRMESSAGE", string.Empty);
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            { return null; }
        }

        [Transaction(TransactionPropagation.Required)]
        public string IBL_Withdrawal(string voucherNo, string accountNo, decimal amount, string isVIP, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
            string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel, string chequeNo, int createdUserId)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_IBL_WITHDRAW_CHECK_SAVAC_DATE_IBD");
                query.SetString("VOUCHERNO", voucherNo);
                query.SetString("ACCTNO", accountNo);
                query.SetString("VIP", isVIP);
                query.SetDecimal("AMOUNT", amount);
                query.SetInt32("FORCECHECK", forceCheck);
                query.SetInt32("MINBALCHECK", minBalCheck);
                query.SetString("CHEQUENO", chequeNo);
                query.SetString("TEMPSTATUS", tempStatus);
                query.SetString("TEMPTRANCODE", tempTranCode);
                query.SetString("REFERENCE", reference);
                query.SetString("FROMBRANCH", fromBranch);
                query.SetDecimal("INCOMEAMOUNT", incomeAmount);
                query.SetDecimal("FAXCHARGES", faxCharges);
                query.SetInt32("TAKEINCOME", takeIncome);
                query.SetString("IBSAC", IBSAC);
                query.SetString("INCOMEAC", incomeAC);
                query.SetString("FAXAC", faxAC);
                query.SetString("USERID", Convert.ToString(createdUserId));
                query.SetDecimal("RECEIPT_NO", 0);
                query.SetString("SOURCECUR", sourceCur);
                query.SetDecimal("HOMEEXRATE", homeExchangeRate);
                query.SetString("SOURCEBR", sourceBr);
                query.SetString("SETTLEMENTDATE", settlementDate.ToShortDateString());
                query.SetString("CHANNEL", channel);
                query.SetInt32("CreatedUserId", createdUserId);
                query.SetDateTime("CreatedDate", DateTime.Now);

                return query.UniqueResult().ToString();                

            }
            catch (Exception ex)
            { return null; }
        }

        [Transaction(TransactionPropagation.Required)]
        public string UpdateForTransfer(string voucherNo, string accountNo, decimal amount, decimal oAmount, string chequeNo, string voucherStatus, bool status, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            
                IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_TRANSFER");
                query.SetString("eno", voucherNo);
                query.SetString("acctno", accountNo);
                query.SetDecimal("amount", amount);
                query.SetDecimal("Oamt", oAmount);
                query.SetString("chequeNo", chequeNo);
                query.SetString("voucherStatus", voucherStatus);
                query.SetBoolean("status", status);
                query.SetString("narration", narration);
                query.SetString("userId", userId);
                query.SetString("currency", sourceCur);
                query.SetDecimal("homeExchangeRate", homeExchangeRate);
                query.SetString("sourceBr", sourceBr);
                query.SetString("settlementDate", settlementDate.ToShortDateString());
                query.SetString("channel", channel);
                return query.UniqueResult().ToString();
          
        }

        //Added by HWKO (14-Sep-2017) // For HP Interest Prepayment Voucher Entry
        [Transaction(TransactionPropagation.Required)]
        public string UpdateForHPIntPrepaymentVoucher(string voucherNo, string accountNo, decimal amount, string narration, string userId, string sourceCur, string sourceBr, DateTime settlementDate, string channel)
        {

            IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_HPINTPREPAYMENTVOUCHER");
            query.SetString("eno", voucherNo);
            query.SetString("acctno", accountNo);
            query.SetDecimal("amount", amount);
            query.SetString("narration", narration);
            query.SetString("userId", userId);
            query.SetString("currency", sourceCur);
            query.SetString("sourceBr", sourceBr);
            query.SetString("settlementDate", settlementDate.ToShortDateString());
            query.SetString("channel", channel);
            return query.UniqueResult().ToString();

        }

        [Transaction(TransactionPropagation.Required)]
        public string AllUpdateForClearing(PFMORM00054 tlf, bool wStatus)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_CLEARING");
            query.SetString("eno", tlf.Eno);
            query.SetString("macctno", tlf.AccountNo);
            query.SetDecimal("amount", tlf.Amount);
            query.SetDecimal("oamount", tlf.LocalOAmt.Value);
            query.SetString("cheque", tlf.Cheque);
            query.SetString("otherbank", tlf.OtherBank);
            query.SetString("userno", tlf.UserNo);
            query.SetBoolean("wstatus", wStatus);
            query.SetString("cur", tlf.CurrencyCode);
            query.SetDecimal("homeexrate", tlf.Rate.Value);
            query.SetString("sourcebr", tlf.SourceBranchCode);
            query.SetDateTime("settlementdate", tlf.SettlementDate.Value);
            query.SetString("channel", tlf.Channel);
            query.SetInt32("createduserid", tlf.CreatedUserId);
            return query.UniqueResult().ToString();
        }

        public CXDTO00008 IBL_AmountCheck(CXDTO00004 parameters)
        {
            IQuery query = this.Session.GetNamedQuery("SP_IBL_CHECK_AMOUNT");
            query.SetString("accountno", parameters.AccountNo);
            query.SetDecimal("amount", parameters.Amount);
            if (parameters.DebitCreditTransaction.Equals(CXDMD00002.Debit))
            {
                query.SetString("action", "D");
            }
            else if (parameters.DebitCreditTransaction.Equals(CXDMD00002.Credit))
            {
                query.SetString("action", "C");
            }
            query.SetString("acsign", parameters.ACSign);
            query.SetInt32("force", parameters.Force);
            query.SetInt32("minbalcheck", parameters.MinBalCheck);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(CXDTO00008)));
            CXDTO00008 a = query.UniqueResult<CXDTO00008>();
            return a;
        }

        public CXDTO00008 SP_ATL_AMOUNTCHECKING_CHECK_SAVAC_DATE(CXDTO00004 parameters)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ATL_AMOUNTCHECKING_CHECK_SAVAC_DATE");
            query.SetString("accountno", parameters.AccountNo);
            query.SetDecimal("amount", parameters.Amount);
            if (parameters.IsVIP)
            {
                query.SetString("vip", "True");
            }
            else
            {
                query.SetString("vip", "False");
            }
            query.SetInt32("userId", parameters.CreatedUserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(CXDTO00008)));
            CXDTO00008 a = query.UniqueResult<CXDTO00008>();
            return a;
        }        

        [Transaction(TransactionPropagation.Required)]
        public string EncashVou(TLMDTO00001 reDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ENCASHVOU");
            query.SetString("eno", reDTO.ENO);
            query.SetString("mainAccountNo", reDTO.ToAccountNo);
            query.SetDecimal("amount", reDTO.Amount);
            query.SetString("cheque", reDTO.AccountSign);
            query.SetString("registerNo", reDTO.RegisterNo);
            query.SetString("poNo", reDTO.PONo);
            query.SetBoolean("poStatus", true);
            query.SetString("encashNo", reDTO.EncashNo);
            query.SetString("userNo", reDTO.CreatedUserId.ToString());
            query.SetBoolean("closeStatus", false);
            query.SetString("poAccountNo", reDTO.AccountNo);
            query.SetString("budget", reDTO.Budget);
            query.SetString("dBank", reDTO.Ebank);
            query.SetString("currency", reDTO.Currency);
            query.SetDecimal("homeExchangeRate", reDTO.HomeExchangeRate);
            query.SetString("sourceBr", reDTO.SourceBranchCode);
            query.SetDateTime("settlementDate", reDTO.SettlementDate.Value);
            query.SetString("channel", reDTO.Channel);
            query.SetInt32("createdUserId", reDTO.CreatedUserId);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string IBLRemit(TLMDTO00017 drawingRemitDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_IBL_REMIT");
            query.SetString("voucherNo", drawingRemitDTO.VoucherNo);
            query.SetString("accountNo", drawingRemitDTO.AccountNo);
            query.SetDecimal("amount", drawingRemitDTO.Amount.Value);
            query.SetString("cheque", drawingRemitDTO.CheckNo);
            query.SetDecimal("remitCharges", drawingRemitDTO.Commission.Value);
            query.SetString("branchCode", drawingRemitDTO.Dbank);
            query.SetString("registerNo", drawingRemitDTO.RegisterNo);
            query.SetInt32("remitStatus", drawingRemitDTO.RemitStatus);
            query.SetString("userNo", drawingRemitDTO.CreatedUserId.ToString());
            query.SetBoolean("closeStatus", drawingRemitDTO.CheckClose);
            query.SetInt32("linkStatus", Convert.ToInt32(drawingRemitDTO.CheckLink));
            query.SetString("sourceCurrency", drawingRemitDTO.Currency);
            query.SetDecimal("homeExRate", drawingRemitDTO.Rate);
            query.SetString("sourceBranch", drawingRemitDTO.SourceBranchCode);
            query.SetDateTime("settlementDate", drawingRemitDTO.SettlementDate.Value);
            query.SetString("channel", drawingRemitDTO.Channel);
            query.SetInt32("createdUserId", drawingRemitDTO.CreatedUserId);
            //string sql = this.GetSQLString(query.QueryString);
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string RemitVoucher(TLMDTO00017 drawingRemitDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_REMITTANCE_VOUCHER");
            query.SetString("voucherNo", drawingRemitDTO.VoucherNo);
            query.SetString("accountNo", drawingRemitDTO.AccountNo);
            query.SetDecimal("amount", drawingRemitDTO.Amount.Value);
            query.SetDecimal("overdraftAmount", drawingRemitDTO.OverdraftAmount);
            query.SetString("cheque", drawingRemitDTO.CheckNo);
            query.SetDecimal("remitCharges", drawingRemitDTO.Commission.Value);
            query.SetString("branchCode", drawingRemitDTO.Dbank);
            query.SetString("registerNo", drawingRemitDTO.RegisterNo);
            query.SetInt32("remitStatus", drawingRemitDTO.RemitStatus);
            query.SetString("userNo", drawingRemitDTO.CreatedUserId.ToString());
            query.SetBoolean("closeStatus", drawingRemitDTO.CheckClose);
            query.SetString("sourceCurrency", drawingRemitDTO.Currency);
            query.SetDecimal("homeExRate", drawingRemitDTO.Rate);
            query.SetString("sourceBranch", drawingRemitDTO.SourceBranchCode);
            query.SetDateTime("settlementDate", drawingRemitDTO.SettlementDate.Value);
            query.SetString("channel", drawingRemitDTO.Channel);
            query.SetInt32("createdUserId", drawingRemitDTO.CreatedUserId);
   
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string AllUpdateRemit(TLMDTO00017 drawingRemitDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ALUpdate_Remit");
            query.SetString("voucherNo", drawingRemitDTO.VoucherNo);
            query.SetString("accountNo", drawingRemitDTO.AccountNo);
            query.SetDecimal("amount", drawingRemitDTO.Amount.Value);
            query.SetString("cheque", drawingRemitDTO.CheckNo);
            query.SetDecimal("remitCharges", drawingRemitDTO.Commission.Value);
            query.SetString("branchCode", drawingRemitDTO.Dbank);
            query.SetString("registerNo", drawingRemitDTO.RegisterNo);
            query.SetInt32("remitStatus", drawingRemitDTO.RemitStatus);
            query.SetString("userNo", drawingRemitDTO.CreatedUserId.ToString());
            query.SetString("sourceCurrency", drawingRemitDTO.Currency);
            query.SetDecimal("homeExRate", drawingRemitDTO.Rate);
            query.SetString("sourceBranch", drawingRemitDTO.SourceBranchCode);
            query.SetDateTime("settlementDate", drawingRemitDTO.SettlementDate.Value);
            query.SetString("channel", drawingRemitDTO.Channel);
            query.SetInt32("createdUserId", drawingRemitDTO.CreatedUserId);

            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string TransferDebitVoucher(string voucherNo, string accountNo, string isVIP, decimal amount, string chequeNo, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string creditAccount, decimal comissionCharges, decimal communicationCharges, bool status, string iBSAC, string incomeAC, string faxAC, int takeIncome,string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            #region Old Code
            //IQuery query = this.Session.GetNamedQuery("SP_IBL_TRDEBIT_CHECK_SAVAC_DATE_IBD");
            //query.SetString("eno", voucherNo);
            //query.SetString("acctno", accountNo);
            //query.SetString("isVIP", isVIP);
            //query.SetDecimal("amount", amount);
            //query.SetInt32("forceCheck", 1);
            //query.SetInt32("minbalCheck", 1);
            //query.SetString("chequeNo", chequeNo);
            //query.SetString("status", voucherStatus);
            //query.SetString("transactionCode", transactionCode);
            //query.SetString("reference", reference);
            //query.SetString("fromBranch", debitBranch);
            //query.SetString("debitBranch", debitBranch);
            //query.SetString("creditBranch", creditBranch);
            //query.SetString("creditAccount", creditAccount);
            //query.SetDecimal("incomeAmount", comissionCharges);
            //query.SetDecimal("faxCharges", communicationCharges);
            //query.SetInt32("takeIncome", takeIncome);
            //query.SetString("iBSAC", iBSAC);
            //query.SetString("incomeAC", incomeAC);
            //query.SetString("faxAC", faxAC);
            //query.SetString("userId", userId);
            //query.SetString("currency", sourceCur);
            //query.SetDecimal("homeExchangeRate", homeExchangeRate);
            //query.SetString("sourceBr", sourceBr);
            //query.SetString("settlementDate", settlementDate.ToShortDateString());
            //query.SetString("channel", channel);

            //IList<object> result = query.List<object>();
            //return result[0].ToString();
            ////return query.UniqueResult().ToString();
            #endregion

            ITransaction transaction = this.Session.BeginTransaction();
            IDbConnection connection = this.Session.Connection;
            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.SP_IBL_TRDEBIT_CHECK_SAVAC_DATE_IBD";

            // Set the command to exeute using the NHibernate's transaction
            transaction.Enlist(command);

            //Set Input Parameter
            #region Input Parameter
            var VOUCHERNO = new SqlParameter("@VOUCHERNO", SqlDbType.VarChar);
            VOUCHERNO.Value = voucherNo;
            VOUCHERNO.Size = 13;
            command.Parameters.Add(VOUCHERNO);

            var ACCTNO = new SqlParameter("@ACCTNO", SqlDbType.VarChar);
            ACCTNO.Value = accountNo;
            ACCTNO.Size = 15;
            command.Parameters.Add(ACCTNO);

            var VIP = new SqlParameter("@VIP", SqlDbType.VarChar);
            VIP.Value = isVIP;
            VIP.Size = 5;
            command.Parameters.Add(VIP);

            var AMOUNT = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            AMOUNT.Value = amount;
            command.Parameters.Add(AMOUNT);

            var FORCECHECK = new SqlParameter("@FORCECHECK", SqlDbType.Int);
            FORCECHECK.Value = 1;
            command.Parameters.Add(FORCECHECK);

            var MINBALCHECK = new SqlParameter("@MINBALCHECK", SqlDbType.Int);
            MINBALCHECK.Value = 1;
            command.Parameters.Add(MINBALCHECK);

            var CHEQUENO = new SqlParameter("@CHEQUENO", SqlDbType.VarChar);
            CHEQUENO.Value = chequeNo;
            CHEQUENO.Size = 13;
            command.Parameters.Add(CHEQUENO);

            var STATUS = new SqlParameter("@STATUS", SqlDbType.VarChar);
            STATUS.Value = voucherStatus;
            STATUS.Size = 3;
            command.Parameters.Add(STATUS);

            var TRANCODE = new SqlParameter("@TRANCODE", SqlDbType.VarChar);
            TRANCODE.Value = transactionCode;
            TRANCODE.Size = 10;
            command.Parameters.Add(TRANCODE);

            var REFERENCE = new SqlParameter("@REFERENCE", SqlDbType.VarChar);
            REFERENCE.Value = reference;
            REFERENCE.Size = 5;
            command.Parameters.Add(REFERENCE);

            var FROMBRANCH = new SqlParameter("@FROMBRANCH", SqlDbType.VarChar);
            FROMBRANCH.Value = debitBranch;
            FROMBRANCH.Size = 3;
            command.Parameters.Add(FROMBRANCH);

            var ME = new SqlParameter("@ME", SqlDbType.VarChar);
            ME.Value = debitBranch;
            ME.Size = 3;
            command.Parameters.Add(ME);

            var CRBRANCH = new SqlParameter("@CRBRANCH", SqlDbType.VarChar);
            CRBRANCH.Value = creditBranch;
            CRBRANCH.Size = 3;
            command.Parameters.Add(CRBRANCH);

            var CRACCTNO = new SqlParameter("@CRACCTNO", SqlDbType.VarChar);
            CRACCTNO.Value = creditAccount;
            CRACCTNO.Size = 15;
            command.Parameters.Add(CRACCTNO);

            var INCOMEAMOUNT = new SqlParameter("@INCOMEAMOUNT", SqlDbType.Decimal);
            INCOMEAMOUNT.Value = comissionCharges;
            command.Parameters.Add(INCOMEAMOUNT);

            var FAXCHARGES = new SqlParameter("@FAXCHARGES", SqlDbType.Decimal);
            FAXCHARGES.Value = communicationCharges;
            command.Parameters.Add(FAXCHARGES);

            var TAKEINCOME = new SqlParameter("@TAKEINCOME", SqlDbType.Int);
            TAKEINCOME.Value = takeIncome;
            command.Parameters.Add(TAKEINCOME);

            var IBSAC = new SqlParameter("@IBSAC", SqlDbType.VarChar);
            IBSAC.Value = iBSAC;
            IBSAC.Size = 6;
            command.Parameters.Add(IBSAC);

            var INCOMEAC = new SqlParameter("@INCOMEAC", SqlDbType.VarChar);
            INCOMEAC.Value = incomeAC;
            INCOMEAC.Size = 6;
            command.Parameters.Add(INCOMEAC);

            var FAXAC = new SqlParameter("@FAXAC", SqlDbType.VarChar);
            FAXAC.Value = faxAC;
            FAXAC.Size = 6;
            command.Parameters.Add(FAXAC);

            //var NARRATION_FOR_TLF = new SqlParameter("@NARRATION_FOR_TLF", SqlDbType.VarChar);
            //NARRATION_FOR_TLF.Value = narration;
            //NARRATION_FOR_TLF.Size = 10;
            //command.Parameters.Add(NARRATION_FOR_TLF);

            var USERID = new SqlParameter("@USERID", SqlDbType.VarChar);
            USERID.Value = userId;
            USERID.Size = 5;
            command.Parameters.Add(USERID);

            var SOURCECUR = new SqlParameter("@SOURCECUR", SqlDbType.VarChar);
            SOURCECUR.Value = sourceCur;
            SOURCECUR.Size = 10;
            command.Parameters.Add(SOURCECUR);

            var HOMEEXRATE = new SqlParameter("@HOMEEXRATE", SqlDbType.Decimal);
            HOMEEXRATE.Value = homeExchangeRate;
            command.Parameters.Add(HOMEEXRATE);

            var SOURCEBR = new SqlParameter("@SOURCEBR", SqlDbType.VarChar);
            SOURCEBR.Value = sourceBr;
            SOURCEBR.Size = 10;
            command.Parameters.Add(SOURCEBR);

            var SETTLEMENTDATE = new SqlParameter("@SETTLEMENTDATE", SqlDbType.VarChar);
            SETTLEMENTDATE.Value = settlementDate.ToShortDateString();
            SETTLEMENTDATE.Size = 10;
            command.Parameters.Add(SETTLEMENTDATE);

            var CHANNEL = new SqlParameter("@CHANNEL", SqlDbType.VarChar);
            CHANNEL.Value = channel;
            CHANNEL.Size = 10;
            command.Parameters.Add(CHANNEL);

            #endregion

            // Set output parameter
            #region Output Parameter

            var RETURN_ERROR_NO = new SqlParameter("@RETURN_ERROR_NO", SqlDbType.Int);
            RETURN_ERROR_NO.Direction = ParameterDirection.Output;
            command.Parameters.Add(RETURN_ERROR_NO);
          
            #endregion

            command.ExecuteNonQuery();
            return RETURN_ERROR_NO.Value.ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string TransferCreditVoucher(string voucherNo, string accountNo, decimal amount, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string debitAccount, bool status, string iBSAC, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            #region Old Code
            //IQuery query = this.Session.GetNamedQuery("sp_Ibl_TrCredit_Nar_IBD");
            //query.SetString("eno", voucherNo);
            //query.SetString("acctno", accountNo);
            //query.SetString("iBSAC", iBSAC);
            //query.SetDecimal("amount", amount);
            //query.SetInt32("forceCheck", 1);
            //query.SetInt32("minbalCheck", 1);
            //query.SetString("status", voucherStatus);
            //query.SetString("transactionCode", transactionCode);
            //query.SetString("reference", reference);
            //query.SetString("fromBranch", creditBranch);
            //query.SetString("debitBranch", debitBranch);
            //query.SetString("creditBranch", creditBranch);
            //query.SetString("debitAccount", debitAccount);
            //query.SetString("narration", narration);
            //query.SetString("userId", userId);
            //query.SetString("currency", sourceCur);
            //query.SetDecimal("homeExchangeRate", homeExchangeRate);
            //query.SetString("sourceBr", sourceBr);
            //query.SetString("settlementDate", settlementDate.ToShortDateString());
            //query.SetString("channel", channel);

            ////return query.UniqueResult().ToString();
            //IList<object> result = query.List<object>();
            //return result[0].ToString();
            #endregion

            ITransaction transaction = this.Session.BeginTransaction();
            IDbConnection connection = this.Session.Connection;
            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.sp_Ibl_TrCredit_Nar_IBD";

            // Set the command to exeute using the NHibernate's transaction
            transaction.Enlist(command);

            //Set Input Parameter
            #region Input Parameter

            var VOUCHERNO = new SqlParameter("@VOUCHERNO", SqlDbType.VarChar);
            VOUCHERNO.Value = voucherNo;
            VOUCHERNO.Size = 13;
            command.Parameters.Add(VOUCHERNO);

            var ACCTNO = new SqlParameter("@ACCTNO", SqlDbType.VarChar);
            ACCTNO.Value = accountNo;
            ACCTNO.Size = 15;
            command.Parameters.Add(ACCTNO);

            var IBSAC = new SqlParameter("@IBSAC", SqlDbType.VarChar);
            IBSAC.Value = iBSAC;
            IBSAC.Size = 6;
            command.Parameters.Add(IBSAC);

            var AMOUNT = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            AMOUNT.Value = amount;
            command.Parameters.Add(AMOUNT);

            var FORCECHECK = new SqlParameter("@FORCECHECK", SqlDbType.Int);
            FORCECHECK.Value = 1;
            command.Parameters.Add(FORCECHECK);

            var MINBALCHECK = new SqlParameter("@MINBALCHECK", SqlDbType.Int);
            MINBALCHECK.Value = 1;
            command.Parameters.Add(MINBALCHECK);

            var STATUS = new SqlParameter("@STATUS", SqlDbType.VarChar);
            STATUS.Value = voucherStatus;
            STATUS.Size = 3;
            command.Parameters.Add(STATUS);

            var TRANCODE = new SqlParameter("@TRANCODE", SqlDbType.VarChar);
            TRANCODE.Value = transactionCode;
            TRANCODE.Size = 10;
            command.Parameters.Add(TRANCODE);

            var REFERENCE = new SqlParameter("@REFERENCE", SqlDbType.VarChar);
            REFERENCE.Value = reference;
            REFERENCE.Size = 5;
            command.Parameters.Add(REFERENCE);

            var RECEIPT_NO = new SqlParameter("@RECEIPT_NO", SqlDbType.Decimal);
            RECEIPT_NO.Value = 0;
            command.Parameters.Add(RECEIPT_NO);

            var FROMBRANCH = new SqlParameter("@FROMBRANCH", SqlDbType.VarChar);
            FROMBRANCH.Value = creditBranch;
            FROMBRANCH.Size = 3;
            command.Parameters.Add(FROMBRANCH);

            var DRBRANCH = new SqlParameter("@DRBRANCH", SqlDbType.VarChar);
            DRBRANCH.Value = debitBranch;
            DRBRANCH.Size = 3;
            command.Parameters.Add(DRBRANCH);

            var ME = new SqlParameter("@ME", SqlDbType.VarChar);
            ME.Value = creditBranch;
            ME.Size = 3;
            command.Parameters.Add(ME);

            var DRACCTNO = new SqlParameter("@DRACCTNO", SqlDbType.VarChar);
            DRACCTNO.Value = debitAccount;
            DRACCTNO.Size = 15;
            command.Parameters.Add(DRACCTNO);

            var NARTEST = new SqlParameter("@NARTEST", SqlDbType.VarChar);
            NARTEST.Value = narration;
            NARTEST.Size = 15;
            command.Parameters.Add(NARTEST);

            var USERID = new SqlParameter("@USERID", SqlDbType.VarChar);
            USERID.Value = userId;
            USERID.Size = 5;
            command.Parameters.Add(USERID);

            var SOURCECUR = new SqlParameter("@SOURCECUR", SqlDbType.VarChar);
            SOURCECUR.Value = sourceCur;
            SOURCECUR.Size = 10;
            command.Parameters.Add(SOURCECUR);

            var HOMEEXRATE = new SqlParameter("@HOMEEXRATE", SqlDbType.VarChar);
            HOMEEXRATE.Value = homeExchangeRate;
            HOMEEXRATE.Size = 10;
            command.Parameters.Add(HOMEEXRATE);

            var SOURCEBR = new SqlParameter("@SOURCEBR", SqlDbType.VarChar);
            SOURCEBR.Value = sourceBr;
            SOURCEBR.Size = 10;
            command.Parameters.Add(SOURCEBR);

            var SETTLEMENTDATE = new SqlParameter("@SETTLEMENTDATE", SqlDbType.VarChar);
            SETTLEMENTDATE.Value = settlementDate.ToShortDateString();
            SETTLEMENTDATE.Size = 10;
            command.Parameters.Add(SETTLEMENTDATE);

            var CHANNEL = new SqlParameter("@CHANNEL", SqlDbType.VarChar);
            CHANNEL.Value = channel;
            CHANNEL.Size = 10;
            command.Parameters.Add(CHANNEL);

            #endregion

            // Set output parameter
            #region Output Parameter

            var RETURN_NO = new SqlParameter("@RETURN_NO", SqlDbType.Int);
            RETURN_NO.Direction = ParameterDirection.Output;
            command.Parameters.Add(RETURN_NO);

            #endregion

            command.ExecuteNonQuery();
            return RETURN_NO.Value.ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public string TransferSameBarnchVoucher(string voucherNo, string creditAccountNo, string debitAccountNo, string chequeNo, string isVIP, decimal amount, decimal incomeAmount, decimal faxCharges, string debitBranch, string creditBranch, string fromBranch, bool status, string iBSAC, string faxAC, int takeIncome, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel)
        {
            #region Old Code
            //    IQuery query = this.Session.GetNamedQuery("SP_IBL_TRANSFER_CHECK_SAVAC_DATE_IBD");
            //    query.SetString("eno", voucherNo);
            //    query.SetString("CreditAccount", creditAccountNo);
            //    query.SetString("DebitAccount", debitAccountNo);
            //    query.SetString("isVIP", isVIP);
            //    query.SetString("chequeNo", chequeNo);
            //    query.SetDecimal("amount", amount);
            //    query.SetDecimal("incomeAmount", incomeAmount);
            //    query.SetDecimal("faxCharges", faxCharges);
            //    query.SetInt32("forceCheck", 1);
            //    query.SetInt32("minbalCheck", 1);
            //    query.SetString("fromBranch", fromBranch);
            //    query.SetString("iBSAC", iBSAC);
            //    query.SetString("faxAC", faxAC);
            //    query.SetInt32("takeIncome", takeIncome);
            //    query.SetString("userId", userId);
            //    query.SetString("currency", sourceCur);
            //    query.SetDecimal("homeExchangeRate", homeExchangeRate);
            //    query.SetString("sourceBr", sourceBr);
            //    query.SetString("settlementDate", settlementDate.ToShortDateString());
            //    query.SetString("channel", channel);

            //    //return query.UniqueResult().ToString();
            #endregion

            //using (var tx = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            //using (ITransaction transaction = this.Session.BeginTransaction())
            //{
            ITransaction transaction = this.Session.BeginTransaction();
            IDbConnection connection = this.Session.Connection;
            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.SP_IBL_TRANSFER_CHECK_SAVAC_DATE_IBD";

            // Set the command to exeute using the NHibernate's transaction
            transaction.Enlist(command);

            //Set Input Parameter
            #region Input Parameter

            var VOUCHERNO = new SqlParameter("@VOUCHERNO", SqlDbType.VarChar);
            VOUCHERNO.Value = voucherNo;
            VOUCHERNO.Size = 13;
            command.Parameters.Add(VOUCHERNO);

            var CRACCTNO = new SqlParameter("@CRACCTNO", SqlDbType.VarChar);
            CRACCTNO.Value = creditAccountNo;
            CRACCTNO.Size = 15;
            command.Parameters.Add(CRACCTNO);

            var DRACCTNO = new SqlParameter("@DRACCTNO", SqlDbType.VarChar);
            DRACCTNO.Value = debitAccountNo;
            DRACCTNO.Size = 15;
            command.Parameters.Add(DRACCTNO);

            var VIP = new SqlParameter("@VIP", SqlDbType.VarChar);
            VIP.Value = isVIP;
            VIP.Size = 5;
            command.Parameters.Add(VIP);

            var AMOUNT = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            AMOUNT.Value = amount;
            command.Parameters.Add(AMOUNT);

            var FORCECHECK = new SqlParameter("@FORCECHECK", SqlDbType.Int);
            FORCECHECK.Value = 1;
            command.Parameters.Add(FORCECHECK);

            var MINBALCHECK = new SqlParameter("@MINBALCHECK", SqlDbType.Int);
            MINBALCHECK.Value = 1;
            command.Parameters.Add(MINBALCHECK);

            var FROMBRANCH = new SqlParameter("@FROMBRANCH", SqlDbType.VarChar);
            FROMBRANCH.Value = fromBranch;
            FROMBRANCH.Size = 15;
            command.Parameters.Add(FROMBRANCH);

            var INCOMEAMOUNT = new SqlParameter("@INCOMEAMOUNT", SqlDbType.Decimal);
            INCOMEAMOUNT.Value = incomeAmount;
            command.Parameters.Add(INCOMEAMOUNT);

            var FAXCHARGES = new SqlParameter("@FAXCHARGES", SqlDbType.Decimal);
            FAXCHARGES.Value = faxCharges;
            command.Parameters.Add(FAXCHARGES);

            var TAKEINCOME = new SqlParameter("@TAKEINCOME", SqlDbType.Int);
            TAKEINCOME.Value = takeIncome;
            command.Parameters.Add(TAKEINCOME);

            var INCOMEAC = new SqlParameter("@INCOMEAC", SqlDbType.VarChar);
            INCOMEAC.Value = iBSAC;
            INCOMEAC.Size = 6;
            command.Parameters.Add(INCOMEAC);

            var FAXAC = new SqlParameter("@FAXAC", SqlDbType.VarChar);
            FAXAC.Value = faxAC;
            FAXAC.Size = 6;
            command.Parameters.Add(FAXAC);

            var USERID = new SqlParameter("@USERID", SqlDbType.VarChar);
            USERID.Value = userId;
            USERID.Size = 5;
            command.Parameters.Add(USERID);

            var CHEQUE = new SqlParameter("@CHEQUE", SqlDbType.VarChar);
            CHEQUE.Value = chequeNo;
            CHEQUE.Size = 13;
            command.Parameters.Add(CHEQUE);

            var SOURCECUR = new SqlParameter("@SOURCECUR", SqlDbType.VarChar);
            SOURCECUR.Value = sourceCur;
            SOURCECUR.Size = 10;
            command.Parameters.Add(SOURCECUR);

            var HOMEEXRATE = new SqlParameter("@HOMEEXRATE", SqlDbType.Decimal);
            HOMEEXRATE.Value = homeExchangeRate;
            command.Parameters.Add(HOMEEXRATE);

            var SOURCEBR = new SqlParameter("@SOURCEBR", SqlDbType.VarChar);
            SOURCEBR.Value = sourceBr;
            SOURCEBR.Size = 10;
            command.Parameters.Add(SOURCEBR);

            var SETTLEMENTDATE = new SqlParameter("@SETTLEMENTDATE", SqlDbType.VarChar);
            SETTLEMENTDATE.Value = settlementDate.ToShortDateString();
            SETTLEMENTDATE.Size = 10;
            command.Parameters.Add(SETTLEMENTDATE);

            var CHANNEL = new SqlParameter("@CHANNEL", SqlDbType.VarChar);
            CHANNEL.Value = channel;
            CHANNEL.Size = 10;
            command.Parameters.Add(CHANNEL);

            #endregion

            // Set output parameter
            #region Output Parameter

            var RETURN_NO = new SqlParameter("@RETURN_NO", SqlDbType.Int);
            RETURN_NO.Direction = ParameterDirection.Output;
            command.Parameters.Add(RETURN_NO);

            #endregion

            // Set a return value
            #region return parameter

            //var returnParameter = new SqlParameter("@@RETURN_NO", SqlDbType.Int);
            //returnParameter.Direction = ParameterDirection.;
            //command.Parameters.Add(returnParameter);

            #endregion

            // Execute the stored procedure
            #region Execute Stored Procedure

            //using (IDataReader dataReader = command.ExecuteReader())
            //{
            //    while (dataReader.Read())
            //    {
            //        c.Eno = Convert.ToString(dataReader["Eno"]);
            //        c.AcctNo = Convert.ToString(dataReader["AcctNo"]);
            //        c.Amount = Convert.ToDecimal(dataReader["Amount"]);
            //        c.ACode = Convert.ToString(dataReader["ACode"]);
            //        c.DATE_TIME = Convert.ToDateTime(dataReader["DATE_TIME"]);
            //    }
            //}

            command.ExecuteNonQuery();
            //transaction.Commit();
            //tx.Complete();
            return RETURN_NO.Value.ToString();

            // grab the return value casting it appropriately
            //c.RowCount = Convert.ToInt32(recordCount.Value);
            //c.ViewName = Convert.ToString(viewName.Value);
            #endregion

            //}
        }

        [Transaction(TransactionPropagation.Required)]
        public string IBLEncashPassing(int id, string eno, string acctno, decimal amount, string registerno, string pono, bool postatus, string encashNo, string userno, bool closestatus, string budgetyear, string narrationtext, string branchcode, string sourcecur, decimal homeexchangerate, string sourceBranch, DateTime settlementdate, string channel, int createdUserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_IBL_ENCASHVOU");
            query.SetString("ENO", eno);
            query.SetString("MACCTNO", acctno);
            query.SetDecimal("AMOUNT", amount);
            query.SetString("CHEQUE", "");
            query.SetString("REGISTERNO", registerno);
            query.SetString("PONO", pono);
            query.SetBoolean("POSTATUS", postatus);
            query.SetString("ENCASHNO", encashNo);
            query.SetString("USERNO", userno);
            query.SetBoolean("CLOSESTATUS", closestatus);
            query.SetString("BUDYEAR", budgetyear);
            query.SetString("NARTEXT", narrationtext);
            query.SetString("BRANCHCODE", branchcode);
            query.SetString("SOURCECUR", sourcecur);
            query.SetDecimal("HOMEEXRATE", homeexchangerate);
            query.SetString("SOURCEBR", sourceBranch);
            query.SetString("SETTLEMENTDATE", settlementdate.ToShortDateString());
            query.SetString("CHANNEL", channel);
            query.SetInt32("CREATEDUSERID", createdUserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(CXDTO00008)));
            CXDTO00008 a = query.UniqueResult<CXDTO00008>();
            return (a.ReturnValue != null) ? a.ReturnValue : string.Empty;
        }

        // SP_BANKING_BANKCASH_CALC_BYHOMECURALL For Bank Cash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScroll(string machineName, DateTime requestDate, int rStatus, string dStatus, string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BANKING_BANKCASH_CALC_BYHOMECURALL");
            query.SetString("machineName", machineName);
            query.SetString("requestDate", requestDate.ToString("yyyy/MM/dd"));
            query.SetInt32("rStatus", rStatus);
            query.SetString("dStatus", dStatus);
            query.SetString("brCode", brCode);
            //(brCode == null) ? string.Empty :
            query.SetInt32("createduserId", createduserId);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;
        }

        //sp_banking_bankcash_calc_byhomecur For BankCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollByHomeCur(string machineName, DateTime requestDate, int rStatus, string dStatus,string currency,string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BANKING_BANKCASH_CALC_BYHOMECUR");
            query.SetString("machineName", machineName);
            query.SetString("requestDate", requestDate.ToString("yyyy/MM/dd"));
            query.SetInt32("rStatus", rStatus);
            query.SetString("dStatus", dStatus);
            query.SetString("currency", currency);
            query.SetString("brCode", (brCode == null) ? string.Empty : brCode);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;           
        }

        //[SP_BANKING_BANKCASH_CALC_BYSourceCUR] For BankCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollBySourceCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency,int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BANKING_BANKCASH_CALC_BYSourceCUR");
            query.SetString("machineName", machineName);
            query.SetString("requestDate", requestDate.ToString("yyyy/MM/dd"));
            query.SetInt32("rStatus", rStatus);
            query.SetString("dStatus", dStatus);
            query.SetString("currency", currency);           
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;
        }

        //[SP_BANKING_BANKCASH_CALC] For BankCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 BankCashScrollCALC(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BANKING_BANKCASH_CALC");
            query.SetString("machineName", machineName);
            query.SetString("requestDate", requestDate.ToString("yyyy/MM/dd"));
            query.SetInt32("rStatus", rStatus);
            query.SetString("dStatus", dStatus);
            query.SetString("currency", currency);
            query.SetString("brCode", (brCode == null) ? string.Empty : brCode);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;            
        }

        [Transaction(TransactionPropagation.Required)]
        public string DepositAdjustment(string newEno, string eno, string mAcctno, string mAcode, string mName, decimal amount, decimal oAmount, string mAcSign, string currency, decimal homeExRate, string brCode, DateTime sattlementDate, int createduserId, string channel)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_DEPOSITADJUST");
            query.SetString("newEno", newEno);
            query.SetString("eno", eno);
            query.SetString("mAcctno", mAcctno);
            query.SetString("mAcode", mAcode);
            query.SetString("mName", mName);
            query.SetDecimal("amount", amount);
            query.SetDecimal("oAmount", oAmount);
            query.SetString("mAcSign", mAcSign);
            query.SetString("createduserId", createduserId.ToString());
            query.SetString("Currency", currency);
            query.SetDecimal("homeExchangeRate", homeExRate);
            query.SetString("soruceBr", brCode);
            query.SetString("settlementDate", sattlementDate.ToString("yyyy/MM/dd"));
            query.SetString("channel", channel);            
            return query.UniqueResult().ToString();
        }

        [Transaction(TransactionPropagation.Required)]
        public object ServiceCharges(CXDTO00010 servicechargesdto)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_BANKING_BANKCASH_CALC_BYHOMECUR");
                query.SetString("ENO", servicechargesdto.ENO);
                query.SetString("MACCTNO", servicechargesdto.MACCTNO);
                query.SetString("LNO", servicechargesdto.LNO);
                query.SetString("NAR", servicechargesdto.NAR);
                query.SetDecimal("AMOUNT", servicechargesdto.AMOUNT);
                query.SetDecimal("OAMOUNT", servicechargesdto.OAMOUNT);
                query.SetString("USERNO", servicechargesdto.USERNO);
                query.SetString("VOUSTATUS", servicechargesdto.VOUSTATUS);
                query.SetBoolean("TSTATUS", servicechargesdto.TSTATUS);
                query.SetString("CUR", servicechargesdto.CUR);
                query.SetDecimal("HOMEEXRATE", servicechargesdto.HOMEEXRATE);
                query.SetString("SOURCEBR", servicechargesdto.SOURCEBR);
                query.SetDateTime("SETTLEMENTDATE", servicechargesdto.SETTLEMENTDATE);
                query.SetString("CHANNEL", servicechargesdto.CHANNEL);
                query.SetBoolean("RETVALUE", servicechargesdto.RETVALUE);
                query.SetString("MESSAGE", servicechargesdto.MESSAGE);
                object qq = query.UniqueResult<object>();
                return qq;
            }
            catch 
            {
                return null;

            }
        }

        ////Get CD_Total By Daybook
        [Transaction(TransactionPropagation.Required)]
        public Nullable<decimal> GetCDTotalByDayBook(DateTime date, string crdr, string workstation, int createduserid, string brCode,string sourcecur)
        {
            IQuery query = this.Session.GetNamedQuery("DAYBOOK_SUMMARY_CDDATA_SP_FORBRANCH");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("crdr", crdr);
            query.SetString("workstation", workstation);            
            query.SetInt32("createduserId", createduserid);
            query.SetString("brCode", brCode);
            query.SetString("sourcecur", sourcecur);
            object sumtotal;
            sumtotal = query.UniqueResult();
            Nullable<decimal> CD_Total = Convert.ToDecimal(sumtotal);
            return CD_Total;
        }

         // SP_DAYBOOK_SUMMARYFORBRANCHNEW       
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string crdr, string workstation, int createduserid, string brCode, string sourcecur)
        {
            IQuery query = this.Session.GetNamedQuery("SP_DAYBOOK_SUMMARYFORBRANCHNEW");
            query.SetString("date", date.ToString("yyyy/MM/dd"));
            query.SetString("crdr", crdr);
            query.SetString("workstation", workstation);            
            query.SetInt32("createduserId", createduserid);
            query.SetString("brCode", brCode);
            query.SetString("sourcecur", sourcecur);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));            
            return query.List<PFMDTO00042>();            
        }
     
        //[SP_RETURN_CLOSINGBALANCE_BYHOMECURALL] For CleanCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceByHomeCurrencyAll(string machineName, DateTime requestDate, string parameter, int rStatus, string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_RETURN_CLOSINGBALANCE_BYHOMECURALL");
            query.SetString("machineName", machineName);
            query.SetDateTime("requestDate", requestDate);
            query.SetString("parameter", parameter);
            query.SetInt32("rStatus", rStatus);
            query.SetString("brCode", brCode);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;
        }

        //[SP_RETURN_CLOSINGBALANCE_BYSOURCECUR] For CleanCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceBySourceCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_RETURN_CLOSINGBALANCE_BYSOURCECUR");
            query.SetString("machineName", machineName);
            query.SetDateTime("requestDate", requestDate);
            query.SetString("parameter", parameter);
            query.SetInt32("rStatus", rStatus);
            query.SetString("currency", currency);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;

        }

        //[SP_RETURN_CLOSINGBALANCE] For CleanCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalance(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_RETURN_CLOSINGBALANCE");
            query.SetString("machineName", machineName);
            query.SetDateTime("requestDate", requestDate);
            query.SetString("parameter", parameter);
            query.SetInt32("rStatus", rStatus);
            query.SetString("currency", currency);
            query.SetString("brCode", brCode);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;

        }

        //[SP_RETURN_CLOSINGBALANCE_BYHOMECUR] For CleanCash Scroll
        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00042 ClosingBalanceByHomeCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_RETURN_CLOSINGBALANCE_BYHOMECUR");
            query.SetString("machineName", machineName);
            query.SetDateTime("requestDate", requestDate);
            query.SetString("parameter", parameter);
            query.SetInt32("rStatus", rStatus);
            query.SetString("currency", currency);
            query.SetString("brCode", brCode);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 ReturnBalance = query.UniqueResult<PFMDTO00042>();
            return ReturnBalance;

        }

        [Transaction(TransactionPropagation.Required)]
        public object NPLServiceCharges(CXDTO00010 servicechargesdto)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("NPLSERVICECHARGES_VOU_SP");
                query.SetString("ENO", servicechargesdto.ENO);
                query.SetString("MACCTNO", servicechargesdto.MACCTNO);
                query.SetString("LNO", servicechargesdto.LNO);
                query.SetString("NAR", servicechargesdto.NAR);
                query.SetDecimal("AMOUNT", servicechargesdto.AMOUNT);
                query.SetDecimal("OAMOUNT", servicechargesdto.OAMOUNT);
                query.SetString("USERNO", servicechargesdto.USERNO);
                query.SetString("VOUSTATUS", servicechargesdto.VOUSTATUS);
                query.SetBoolean("TSTATUS", servicechargesdto.TSTATUS);
                query.SetString("CUR", servicechargesdto.CUR);
                query.SetDecimal("HOMEEXRATE", servicechargesdto.HOMEEXRATE);
                query.SetString("SOURCEBR", servicechargesdto.SOURCEBR);
                query.SetDateTime("SETTLEMENTDATE", servicechargesdto.SETTLEMENTDATE);
                query.SetString("CHANNEL", servicechargesdto.CHANNEL);
                query.SetBoolean("RETVALUE", servicechargesdto.RETVALUE);
                query.SetString("MESSAGE", servicechargesdto.MESSAGE);
                object qq = query.UniqueResult<object>();
                return qq;
            }
            catch 
            {
                return null;

            }
            
        }   

        [Transaction(TransactionPropagation.Required)]
        public object SP_ChangeTables(DateTime lastSettlementDate, DateTime nextSettlementDate,string sourceBr)
        {
            try
            {
                string sdate = lastSettlementDate.ToString("yyyy/MM/dd");
                string nextdate = nextSettlementDate.ToString("yyyy/MM/dd");
                IQuery query = this.Session.GetNamedQuery("SP_CHANGE_TABLES");
                query.SetString("SDATE", sdate);
                query.SetString("NEXTSDATE", nextdate);
                query.SetString("sourceBr", sourceBr);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(object)));
                object qq = query.UniqueResult<object>();
                return qq;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        //Updated By HWKO (17-Mar-2017)
        [Transaction(TransactionPropagation.Required)]
        public object Sp_ChangeTables_AllCLedger(DateTime lastSettlementDate, DateTime nextSettlementDate, string sourceBr,string budget)
        {
            try
            {
                string sdate = lastSettlementDate.ToString("yyyy/MM/dd");
                string nextdate = nextSettlementDate.ToString("yyyy/MM/dd");
                IQuery query = this.Session.GetNamedQuery("SP_CHANGE_TABLES_CLedger");
                query.SetString("SDATE", sdate);
                query.SetString("NEXTSDATE", nextdate);
                query.SetString("sourceBr", sourceBr);
                query.SetString("budget", budget);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(object)));
                object qq = query.UniqueResult<object>();
                return qq;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public PFMDTO00042 GetMatureDate(DateTime requiredDate, decimal duration, DateTime registerDate, int createduserId)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GETNEXTDATE");
            query.SetDateTime("requiredDate", requiredDate);
            query.SetDecimal("duration", duration);
            query.SetDateTime("registerDate", registerDate);
            query.SetInt32("createduserId", createduserId);
            query.SetDateTime("retdate", DateTime.Now);
            query.SetInt32("diffdate", 0);
            query.SetString("message", string.Empty);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 returnData = query.UniqueResult<PFMDTO00042>();
            return returnData;
        }

        public PFMDTO00042 GetInterest(DateTime requiredDate, decimal amount, int createduserId)
        {
          //  string date = Convert.ToString(requiredDate);
            IQuery query = this.Session.GetNamedQuery("SP_FIXINTCAL");
          //   query.SetDateTime("requiredDate", date);
            query.SetDateTime("requiredDate", requiredDate);
            query.SetDecimal("amount", amount);
            query.SetInt32("createduserId", createduserId);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            PFMDTO00042 returnData = query.UniqueResult<PFMDTO00042>();
            return returnData;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<object> CashDenominationListing(string currency, string whereString, string orderString)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CASHCONTROLREPORT");
                query.SetString("CUR", currency);
                query.SetString("WHERESTRING", whereString);
                query.SetString("ORDERSTRING", orderString);

                IList<object> results = query.List<object>();

              

                return results;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00015> CashDenominationListing_ForMultiTrasaction(string currency, string whereString, string orderString)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CASHCONTROLREPORT");
                query.SetString("CUR", currency);
                query.SetString("WHERESTRING", whereString);
                query.SetString("ORDERSTRING", orderString);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00015)));
                IList<TLMDTO00015> returnData = query.List<TLMDTO00015>();
                return returnData;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<object> CashControlRefundListString(string currency, string whereString, string orderString)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CASHCONTROLREPORT_DENOREFUND");
                query.SetString("CUR", currency);
                query.SetString("WHERESTRING", whereString);
                query.SetString("ORDERSTRING", orderString);

                IList<object> results = query.List<object>();



                return results;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<object> CashControlTotalVault(string currency, string whereString, string orderString)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_CASHDENO_OPENING");
                query.SetString("CUR", currency);
                query.SetString("WHERESTRING", whereString);
                query.SetString("ORDERSTRING", orderString);

                IList<object> results = query.List<object>();



                return results;
            }
            catch (Exception ex)
            {
                return null;

            }
        }


       #region "SP_ALUPDATE_PO For PO Issue By Transfer"
        [Transaction(TransactionPropagation.Required)]
        public string POIssueByTransfer(TLMDTO00043 POIssueDTO)
        {
            IQuery query = this.Session.GetNamedQuery("SP_ALUPDATE_PO");           
            query.SetString("eno", POIssueDTO.ENo);
            query.SetString("mainaccountno", POIssueDTO.AccountNo);            
            query.SetDecimal("amount", POIssueDTO.Amount);
            query.SetDecimal("odamount", POIssueDTO.HomeAmt);
            query.SetString("cheque", POIssueDTO.CheckNo);
            query.SetDecimal("pocharges", POIssueDTO.Charges);
            query.SetString("userno", POIssueDTO.UserNo);
            query.SetString("postatus", POIssueDTO.POStatus);
            query.SetString("pono", POIssueDTO.PONo);
            query.SetString("budget", POIssueDTO.Budget);
            query.SetString("cur", POIssueDTO.Currency);
            query.SetDecimal("homeexrate", POIssueDTO.Rate);
            query.SetString("sourcebr", POIssueDTO.BranchCode);
            query.SetDateTime("settlementdate", POIssueDTO.SettlementDate);
            query.SetString("channel", POIssueDTO.Channel);
            //query.SetString("acsign", POIssueDTO.AccountSign);
            query.SetString("createduserId", POIssueDTO.CreatedUserId.ToString());
            return query.UniqueResult().ToString();
        }
        #endregion


        [Transaction(TransactionPropagation.Required)]
        public object TransferScroll(string sourceBr, string workstation, DateTime datetime, int Rstatus, char Dstatus, string Cur, decimal Cltot, decimal Totalcash)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_BANKING_TRANSFERSCROLL");
                query.SetString("sourceBr", sourceBr);
                query.SetString("workstation", workstation);
                query.SetDateTime("datetime", datetime);
                query.SetInt32("Rstatus", Rstatus);
                query.SetCharacter("Dstatus", Dstatus);
                query.SetString("Cur", Cur);

                object result = query.UniqueResult<object>();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialGroupByHomeAllBranch(string stramount, string cur, int ishome, string branch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_GROUPTRIALREPORT_SOURCECUR_TOTAL");
                query.SetString("STROPENINGFIELD", stramount);
                query.SetString("CUR", cur);
                query.SetInt32("ISSOURCECUR",ishome );
                query.SetString("SOURCEBR", branch);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();  
              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialGroupByHomeBranch(string stramount, string cur, int ishome, string branch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_GROUPTRIALREPORT_SOURCECUR");
                query.SetString("STROPENINGFIELD", stramount);
                query.SetString("CUR", cur);
                query.SetInt32("ISSOURCECUR", ishome);
                query.SetString("SOURCEBR", branch);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();  
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialGroupBySourceAllBranch(string stramount, string cur, int ishome, string branch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("sp_GroupTrialReport_TOTAL");
                query.SetString("STROPENINGFIELD", stramount);
                query.SetString("CUR", cur);
                query.SetInt32("ISSOURCECUR", ishome);
                query.SetString("SOURCEBR", branch);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();  
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTrialGroupBySourceBranch(string stramount, string cur, int ishome, string branch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("sp_GroupTrialReport");
                query.SetString("STROPENINGFIELD", stramount);
                query.SetString("CUR", cur);
                query.SetInt32("ISSOURCECUR", ishome);
                query.SetString("SOURCEBR", branch);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();  
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        //Added by HWKO (31-Aug-2017)
        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00010> SelectTriGroupForBackDate(string currency, string branchCode,DateTime selectedDate,string stropeningfield)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_GROUPTRIALREPORT_BACKDATE");
                query.SetString("cur", currency);
                query.SetString("sourceBr", branchCode);
                query.SetDateTime("selectedDate", selectedDate);
                query.SetString("STROPENINGFIELD", stropeningfield);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(MNMDTO00010)));
                return query.List<MNMDTO00010>();
            }
            catch (Exception ex)
            {
                return null;

            }
        }


        [Transaction(TransactionPropagation.Required)]
        public TCMDTO00052 SelectDailyClosing(string rDATE, string bUDMONTH, string cUR)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_PPDAY");
                query.SetString("RDATE", rDATE);
                query.SetString("BUDMONTH", bUDMONTH);
                query.SetString("CUR", cUR);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TCMDTO00052)));
                return query.UniqueResult<TCMDTO00052>();
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00013> SelectIncomeExpenditure(string budMonth, string year, int month)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_Income_Expenditure");
                query.SetString("BUDMonth", budMonth);
                query.SetString("year", year);
                query.SetInt32("month", month);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(GLMDTO00013)));
                return query.List<GLMDTO00013>();
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        //Auto Link Schedule Report
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00029> SelectAutoLinkListing(int workstationid, int reversal, string currency, string sourcebranch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Sp_AutoLink_Report");
                query.SetString("workstation", workstationid.ToString());
                query.SetInt32("reversal", reversal);
                query.SetString("cur", currency);
                query.SetString("sourcebr", sourcebranch);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00029)));
                return query.List<PFMDTO00029>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Auto Link Debit/Credit Listing Report
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00042> SelectAutoLinkListingReport(int workstationid, DateTime datetime, string accountSign, string voucherType, string sortedField, int reversal)
        {
            //:workstation,:datetime,:accountsign,:vouchertype,:sortedField,:reversal
            try
            {
                //string dt = datetime.ToShortDateString();
                int date = datetime.Day;
                string day = string.Empty;
                string mon = string.Empty;
                if (date.ToString().Length == 1)
                    day = "0" + date.ToString();
                else
                    day = date.ToString();

                int month = datetime.Month;
                if (month.ToString().Length == 1)
                    mon = "0" + month.ToString();
                else
                    mon = month.ToString();

                int year = datetime.Year;
                string dmy = year + "/" + mon + "/" + day;
                IQuery query = this.Session.GetNamedQuery("sp_autolink_voucher_report");
                query.SetString("workstation", workstationid.ToString());
                //query.SetString("datetime", datetime.ToString("dd/mm/yyyy"));
                query.SetString("datetime", dmy);
                query.SetString("accountsign", accountSign);
                query.SetString("vouchertype", voucherType);
                query.SetString("sortedField", sortedField);
                query.SetInt32("reversal", reversal);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
                return query.List<PFMDTO00042>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public PFMDTO00054 Sp_ALUpdate_Check(string accountno)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Sp_ALUpdate_Check");
                query.SetString("MACCTNO", accountno);
                query.SetString("LINKACCTNO", string.Empty);
                query.SetString("MNAME", string.Empty);
                query.SetString("LINKACNAME", string.Empty);
                query.SetString("MACODE", string.Empty);
                query.SetString("LINKACODE", string.Empty);
                query.SetString("MACSIGN", string.Empty);
                query.SetString("LINKACSIGN", string.Empty);
                query.SetInt32("LINKCHG", 0);
                query.SetString("RETVALUE", string.Empty);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00054)));
                return query.UniqueResult<PFMDTO00054>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string Sp_ALUpdate_Int_TransferAdjust(string neweno, string eno, string accountno, decimal amount, string cheque, string userno,
            bool tstatus, string voustatus, string channel, string refvno, string reftype, string sourcebr, decimal rate, string cur, DateTime settlementdate,int createdUserId)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Sp_ALUpdate_Int_TransferAdjust");
                query.SetString("NewEno", neweno);
                query.SetString("Eno", eno);
                query.SetString("MAcctno", accountno);
                query.SetDecimal("Amount", amount);
                query.SetString("Cheque", cheque);
                query.SetString("UserNo", userno);
                query.SetBoolean("TStatus", tstatus);
                query.SetString("VouStatus", voustatus);
                query.SetString("Channel", channel);
                query.SetString("RefVno", refvno);
                query.SetString("RefType", reftype);
                query.SetString("SourceBr", sourcebr);
                query.SetDecimal("Rate", rate);
                query.SetString("Cur", cur);
                query.SetDateTime("SettlementDate", settlementdate);
                //query.SetInt32("CreatedUserId",createdUserId);
                query.SetParameter("RetValue"," " );                

                //query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(object)));
                string returnValue = query.UniqueResult().ToString();
                return returnValue.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        //Fixed Deposit Renewal Voucher Listing              //ASDA
        public IList<PFMDTO00042> SelectRenewalVoucherListing(int workstationId, DateTime date, string currency, string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Sp_FixRenew_Voucher_Listing");
                query.SetString("workstation", workstationId.ToString());
                query.SetString("date", date.ToString("YYYY/MM/DD"));
                query.SetString("cur", currency);
                query.SetString("sourcebr", sourceBr);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
                return query.List<PFMDTO00042>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //for FixedYearend Interest Calculation
        public string ProcessFixedYearendInterest(DateTime processdate, DateTime yearendDate, string budSDate, string budendDate, int user, string sourcebr, int RetMsg)
        {
            try
            {
                IQuery query= this.Session.GetNamedQuery("Sp_FixRenewalNew");
                query.SetDateTime("processdate", processdate);
                query.SetDateTime("yearendDate", yearendDate);                
                query.SetString("budSDate", budSDate);
                query.SetString("budendDate", budendDate);
                query.SetInt32("user", user);
                query.SetString("sourcebr", sourcebr);
                query.SetInt32("RetMsg", RetMsg);
                string code = query.UniqueResult().ToString();
                if (string.IsNullOrEmpty(code))
                {
                    code = string.Empty;
                }
                return code;

            }
            catch (Exception)
            {
                return null;

            }
        }

        //for prev FixedYearend Interest Calculation
        public string ProcessFixedYearendPrevInterest(DateTime processdate, DateTime yearendDate, string budSDate, string budendDate, int user, string sourcebr, int RetMsg)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("Sp_PrevFixRenewalNew");
                //query.SetDateTime("processdate", processdate);
                //query.SetDateTime("yearendDate", processdate);
                query.SetString("processdate", processdate.ToString("yyyy/MM/dd"));
                query.SetString("yearendDate", yearendDate.ToString("yyyy/MM/dd"));
                query.SetString("budSDate", budSDate);
                query.SetString("budendDate", budendDate);
                query.SetInt32("user", user);
                query.SetString("sourcebr", sourcebr);
                query.SetInt32("RetMsg", RetMsg);
                string code = query.UniqueResult().ToString();
                if (string.IsNullOrEmpty(code))
                {
                    code = string.Empty;
                }
                return code;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //ASDA
        public string Sp_SERVICECHARGES_VOU(string eNO, string mAcctNo, string lno, string narration, decimal amount, decimal oAmount, string userNo, string vouStatus,
            bool tStatus,string cur,int homeExRate,string sourceBr,DateTime settlementDate,string channel,bool returnValue,string message)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_SERVICECHARGES_VOU");
                query.SetString("ENO", eNO);
                query.SetString("MACCTNO", mAcctNo);
                query.SetString("LNO", lno);
                query.SetString("NAR", narration);
                query.SetDecimal("AMOUNT", amount);
                query.SetDecimal("OAMOUNT", oAmount);
                query.SetString("USERNO", userNo);
                query.SetString("VOUSTATUS", vouStatus);
                query.SetBoolean("TSTATUS", tStatus);
                query.SetString("CUR", cur);
                query.SetInt32("HOMEEXRATE", homeExRate);
                query.SetString("SOURCEBR", sourceBr);
                query.SetDateTime("SETTLEMENTDATE", settlementDate);
                query.SetString("CHANNEL", channel);
                query.SetBoolean("RETVALUE", returnValue);
                query.SetString("MESSAGE", string.Empty);

                string code = query.UniqueResult().ToString();   //if transaction code successful, return  0 (false),
                                                                 //if transaction is not successful , retrun 1 (true),
                if (string.IsNullOrEmpty(code))
                {
                    code = string.Empty;
                }               
                return code;

            }
            catch (Exception)
            {
                return null;
            }
        }

        //ASDA
        //public Nullable<decimal> SP_LOANINTEREST_NewLogic(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, int period, decimal retInterest)
        public Nullable<decimal> SP_LOANINTEREST_NewLogic(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, string termNo, decimal retInterest, string sourceBr,int updatedUserId)
        {
            try
            {     
                IQuery query = this.Session.GetNamedQuery("SP_LOANINTEREST_NewLogic");
                query.SetString("LNO", lno);
                query.SetDecimal("DAYSINYEAR", daysInYear);
                query.SetDateTime("QTRSDATE", qtrSDate);
                query.SetDateTime("QTREDATE", qtrEDate);
                query.SetString("TERMNO", termNo);
                query.SetString("SourceBr", sourceBr);                
                query.SetInt32("UpdatedUserId", updatedUserId);
                query.SetParameter("RINTEREST", 0);
                                
                object returnInterest = query.UniqueResult();
                Nullable<decimal> CD_Total = Convert.ToDecimal(returnInterest);
                return CD_Total;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //ASDA
        //public Nullable<decimal> SP_LoanScharge(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, int period,int update, decimal retInterest)
        public Nullable<decimal> SP_LoanScharge_NewLogic(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, string termNo,int updatedUserId,string sourceBr, decimal retInterest)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_LoanScharge_NewLogic");
                query.SetString("LNO", lno);
                query.SetDecimal("DAYSINYEAR", daysInYear);
                query.SetDateTime("QTRSDATE", qtrSDate);
                query.SetDateTime("QTREDATE", qtrEDate);
                query.SetString("TERMNO", termNo);               
                query.SetInt32("UPDATE", updatedUserId);
                query.SetString("SourceBr", sourceBr);                
                query.SetParameter("RINTEREST", 0);

                object returnInterest = query.UniqueResult();
                Nullable<decimal> CD_Total = Convert.ToDecimal(returnInterest);
                return CD_Total;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Added by HMW at 05-06-2020 : Generating Budget Year (Oct - Sept)
        [Transaction(TransactionPropagation.Required)]
        public string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return)
        {
            IQuery query = this.Session.GetNamedQuery("sp_BudInfo");
            query.SetInt32("service", service);
            query.SetDateTime("pDate", pDate);
            query.SetString("branchCode", branchCode);
            query.SetString("Return", Return);
            //query.SetTimeout(10000);
            return query.UniqueResult().ToString();
        }
    
    
    }
}
