//----------------------------------------------------------------------
// <copyright file="MNMSVE00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>12/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXServer;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Mnm.Sve
{
    internal enum Transaction { Credit = 0, Debit = 1 }
    internal enum LedgerType { balCash = 0, balJournal = 1 }

    //MonthlyClosing_Before
    class MNMSVE00001 : BaseService, IMNMSVE00001
    {
        public MNMSVE00001() { }

        #region DAOs

        IPFMDAO00056 Sys001DAO { get; set; }
        IPFMDAO00057 NewSetupDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00040 SiDAO { get; set; }
        IPFMDAO00009 RateFileDAO { get; set; }
        IMNMDAO00001 SysPostDAO { get; set; }
        //IChargeOfAccountSetupDAO CoaSetupDAO { get; set; }
        IMNMDAO00008 OiDAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        ITLMDAO00005 TrantypeDAO { get; set; }
        IPFMDAO00043 PrnFileDAO { get; set; }
        IMNMDAO00021 InTlfDAO { get; set; }
        IPFMDAO00075 RateInfoDAO { get; set; }
        IPFMDAO00054 TlfDAO { get; set; }
        IPFMDAO00024 CoaDAO { get; set; }

        IPFMDAO00032 FreceiptDAO { get; set; }
        IMNMDAO00026 FixIntPostingBeforeDAO { get; set; }
        ITLMDAO00018 LoansDAO { get; set; }
        IMNMDAO00012 LegalIntDAO { get; set; }
        ITCMDAO00003 NplIntDAO { get; set; }
        IMNMDAO00017 LIDAO { get; set; }
        IMNMDAO00011 CommitFeesDAO { get; set; }

        #endregion

        #region private variables

        int savPostMonth;
        string lastRunDate;
        int monthClose;
        int yearClose;
        string sourceBranch;
        int updatedUserId;
        IList<MNMDTO00001> sysPostList;
        IList<PFMDTO00056> sys001List;
        IList<PFMDTO00028> cledgerTotalBalList;
        string controlAccount = string.Empty;
        string curControlAccount = string.Empty;
        string savControlAccount = string.Empty;
        string calCantrolAccount = string.Empty;
        string sControlAccount = string.Empty;
        string voucherNo;
        DateTime EndOfMonth;
        bool LoansPostingPassed = false;
        bool OverdraftPostingPassed = false;
        bool SavingPostingPassed = false;
        bool CommitFeesPostingPassed = false;
        bool FixedPostingPassed = false;

        bool Loan_OD_Com_Process_Done = false;
        bool Sav_Process_Done = false;
        bool Fix_Process_Done = false;

        DateTime nextSettlementDate;
        IList<MNMDTO00001> PostingStatusDTOs = new List<MNMDTO00001>();

        #endregion

        #region Main Method

        public IList<MNMDTO00001> Posting(string sourceBr, int updatedUserID)
        {
            this.sourceBranch = sourceBr;
            this.updatedUserId = updatedUserID;

            this.NewSetupDAO.UpdateValueOfRunTrigger("Disable", this.updatedUserId);        //Set RunTrigger of newSetup Disable

            if (this.CheckClosing(sourceBr))
            {
                this.sysPostList = this.SysPostDAO.SelectPostDateByPostName(this.sourceBranch);                 //Get PostDate List for all Posting

                if (this.checkInterest())
                {

                    if (monthClose == 3 || monthClose == 6 || monthClose == 9 || monthClose == 12)
                    {
                        //this.LoansPosting();
                        //this.OverDraftPostion();
                        //this.CommitmentFeesPosting();
                        //this.Loan_OD_Com_Process_Done = true;
                    }

                    //if (monthClose == 3 || monthClose == 9 || ((monthClose == 6 || monthClose == 12) && savPostMonth == 3))
                    //{
                    //    this.SavingPosting();
                    //    this.Sav_Process_Done = true;
                    //} // Modified By AAM (28-08-2017)

                    //if (monthClose == 3 || monthClose == 9)
                    //{
                        //this.FixedPosting();
                        //this.Fix_Process_Done = true; // Modified By AAM (28-08-2017)
                    //}

                    //Status='1' => Finished
                    //Status='0' => Error {Message Code}
                    //Status='2' => Error Occur in {0} Posting

                    #region Assign For Status of Postings
                    if (!this.LoansPostingPassed && this.Loan_OD_Com_Process_Done)
                    {
                        MNMDTO00001 postingStatus = new MNMDTO00001();
                        postingStatus.PostingName = "LOANSPOST";
                        postingStatus.Status = "2";

                        this.PostingStatusDTOs.Add(postingStatus);
                    }
                    //if (!this.OverdraftPostingPassed && this.Loan_OD_Com_Process_Done)
                    //{
                    //    MNMDTO00001 postingStatus = new MNMDTO00001();
                    //    postingStatus.PostingName = "ODPOST";
                    //    postingStatus.Status = "2";

                    //    this.PostingStatusDTOs.Add(postingStatus);
                    //}
                    //if (!this.CommitFeesPostingPassed && this.Loan_OD_Com_Process_Done)
                    //{
                    //    MNMDTO00001 postingStatus = new MNMDTO00001();
                    //    postingStatus.PostingName = "COMFEEPOST";
                    //    postingStatus.Status = "2";

                    //    this.PostingStatusDTOs.Add(postingStatus);
                    //}
                    //if (!this.SavingPostingPassed && this.Sav_Process_Done)
                    //{
                    //    MNMDTO00001 postingStatus = new MNMDTO00001();
                    //    postingStatus.PostingName = "SAVINGPOST";
                    //    postingStatus.Status = "2";

                    //    this.PostingStatusDTOs.Add(postingStatus);
                    //}
                    //if (!this.FixedPostingPassed && this.Fix_Process_Done)
                    //{
                    //    MNMDTO00001 postingStatus = new MNMDTO00001();
                    //    postingStatus.PostingName = "FIXEDPOST";
                    //    postingStatus.Status = "2";

                    //    this.PostingStatusDTOs.Add(postingStatus);
                    //} // Modified By AAM (28-08-2017)
                    #endregion

                    //Update Sys001
                    string sysmonyear = string.Empty;
                    DateTime sysmonYear = new DateTime(yearClose, monthClose, 1);
                    sysmonyear = sysmonYear.ToString("MM/yyyy");

                    //this.Sys001DAO.UpdateStatusAndSysMonYear("B", sysmonyear, DateTime.Now, this.updatedUserId, "MONTH_CLOSE", this.sourceBranch);
                    TCMDTO00001 systemStartInfo = CXServiceWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
                    DateTime systemDate = DateTime.Parse(systemStartInfo.Date.ToShortDateString());
                    this.Sys001DAO.UpdateStatusAndSysMonYear("B", sysmonyear, systemDate, this.updatedUserId, "MONTH_CLOSE", this.sourceBranch);
                }
            }

            this.NewSetupDAO.UpdateValueOfRunTrigger("Enable", this.updatedUserId);        //Set RunTrigger of newSetup Enable

            return this.PostingStatusDTOs;
        }

        #endregion

        #region Posting Methods

        [Transaction(TransactionPropagation.Required)]
        private void SavingPosting()
        {
            try
            {
                this.ServiceResult.ErrorOccurred = false;
                decimal Mamt = 0;
                decimal Accrued_Total = 0;
                decimal TotalAmt = 0;
                decimal Taxamt = 0;
                decimal TotalTax = 0;
                decimal AfterTax = 0;
                decimal TaAfterTax = 0;
                decimal cBal = 0;
                string acSign;
                string narration = "Saving Interest Posting";
                string pbReference;
                string status;
                string tranCode;
                decimal taxRate;

                if (this.GetStatus("SAVINGPOST", "Saving Posting "))
                {
                    //this.cledgerTotalBalList = this.CledgerDAO.SelectTotalBalanceByCurrency(this.sourceBranch);

                    PFMDTO00009 rateFileDTO = this.RateFileDAO.SelectByCode("TAXRATE");     //Get Rate
                    taxRate = rateFileDTO.Rate;

                    IList<string> CurList = this.SiDAO.SelectCurrency(this.sourceBranch);   //Get Currency From SI

                    foreach (string cur in CurList)         //Loop as list of Currency
                    {
                        this.GetVoucherNo();    //Get VoucherNo

                        IList<decimal> exRate = this.RateInfoDAO.SelectRate(cur, "CS");   //get Exchange Rate
                        if (exRate.Count <= 0)
                            throw new Exception("ME00037"); //Exchange Rate not found in table.
                        IList<PFMDTO00040> siList = new List<PFMDTO00040>();

                        siList = this.SiDAO.SelectByCloseDate(this.sourceBranch, cur);           //Get Accounts in SI
                        if (siList.Count == 0)
                            continue;

                        foreach (PFMDTO00040 si in siList)
                        {

                            if (savPostMonth == 3)          //Interest Post is 3 Months
                            {
                                switch (monthClose)
                                {
                                    case 3: Mamt = si.Month10 + si.Month11 + si.Month12 + si.AccruedInt.Value; break;
                                    case 6: Mamt = si.Month1 + si.Month2 + si.Month3; break;
                                    case 9: Mamt = si.Month4 + si.Month5 + si.Month6; break;
                                    case 12: Mamt = si.Month7 + si.Month8 + si.Month9; break;
                                }
                            }
                            else                            //Interest post is 6 Months
                            {
                                switch (monthClose)
                                {
                                    case 9: Mamt = si.Month1 + si.Month2 + si.Month3 + si.Month4 + si.Month5 + si.Month6; break;
                                    case 3: Mamt = si.Month7 + si.Month8 + si.Month9 + si.Month10 + si.Month11 + si.Month12; break;
                                }
                            }

                            //if (monthClose == 3)        //Budget End
                            //{
                            TotalAmt = TotalAmt + Mamt;
                            Taxamt = (Mamt * taxRate) / 100;
                            TotalTax = TotalTax + Taxamt;
                            AfterTax = Mamt - Taxamt;
                            TaAfterTax = TaAfterTax + AfterTax;

                            PFMDTO00028 cledgerDTO = this.CledgerDAO.SelectACSignByAccountNo(si.AccountNo);     //To Get Parameter for Insert PrnFile

                           // this.CledgerDAO.UpdateCBal(cledgerDTO.CurrentBal + AfterTax, si.AccountNo, this.updatedUserId);            //Update Current Balance in Cledger
                            this.CledgerDAO.UpdateCBal(cledgerDTO.CurrentBal + Mamt, si.AccountNo, this.updatedUserId); 
                            #region Inserting PrnFile

                            //cBal = cledgerDTO.CurrentBal;
                            cBal = cledgerDTO.CurrentBal + AfterTax;
                            acSign = cledgerDTO.AccountSign;

                            TLMDTO00005 tranTypeDTO = this.TrantypeDAO.SelectByTranCode("INTCREDIT");        //To Get Parameter for Insert PrnFile
                            if (tranTypeDTO == null)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = "MI30026";     //TranCode Not Found
                                throw new Exception(this.ServiceResult.MessageCode);
                            }
                            pbReference = tranTypeDTO.PBReference;
                            status = tranTypeDTO.Status;
                            tranCode = tranTypeDTO.TransactionCode;

                            if (Mamt > 0)
                            {
                                //Insert To PrnFile
                                this.PrnFileDAO.Save(this.ConvertToPrnFileORM(si.AccountNo, DateTime.Now, Mamt, cBal, pbReference, cur, this.sourceBranch));
                            }

                            #endregion

                            if (AfterTax > 0)
                            {
                                //Insert To InTLF


                               // this.InTlfDAO.Save(this.ConvertToInTlfORM(voucherNo, si.AccountNo, AfterTax, 0, cur, "Saving Interest of " + si.AccountNo, narration, status, tranCode, acSign, exRate[0], this.nextSettlementDate));
                               // this.InTlfDAO.Save(this.ConvertToInTlfORM(voucherNo, si.AccountNo, Mamt, 0, cur, "Saving Interest of " + si.AccountNo, narration, status, tranCode, acSign, exRate[0], this.nextSettlementDate));

                               MNMDTO00001 dto = new MNMDTO00001();
                                this.InTlfDAO.Save(this.ConvertToInTlfORM(voucherNo, si.AccountNo, Mamt, 0, cur, "Saving Interest of " + si.AccountNo, narration, status, tranCode, acSign, exRate[0], this.nextSettlementDate,dto.UID));
              }

                            #region "Wrong Requirement Backwork Version"
                            //}
                            //else                //not Budget End
                            //{
                            //    this.SiDAO.UpdateAccruedInt(Mamt, si.AccountNo, this.updatedUserId);                //Update AccreuedInt in SI
                            //    Accrued_Total += Mamt;
                            //}
                        }           //End of Account Loop


                        //if (monthClose == 3)       //Budget End
                        //{
                        //    this.SiDAO.UpdateAccruedIntTo0(this.updatedUserId);     //Update Si Set AccruedInt=0
                        //    if (TotalAmt > 0)
                        //    {
                        //        #region Get_Control_Account
                        //        this.controlAccount = string.Empty;
                        //        this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SAVCONTROL", this.sourceBranch, cur);   //Get Coa Account
                        //        if (this.controlAccount == null || this.controlAccount == string.Empty)
                        //        {
                        //            this.ServiceResult.ErrorOccurred = true;
                        //            this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                        //            throw new Exception(this.ServiceResult.MessageCode);
                        //        }
                        //        #endregion

                        //        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt, "", narration, "TRCREDIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving "))
                        //        {
                        //            if (this.ServiceResult.ErrorOccurred)
                        //                throw new Exception(this.ServiceResult.MessageCode);
                        //        }

                        //        if (TotalTax > 0)
                        //        {
                        //            #region Get_Control_Account
                        //            this.controlAccount = string.Empty;
                        //            this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SAVINGTAX", this.sourceBranch, cur);   //Get Coa Account
                        //            if (this.controlAccount == null || this.controlAccount == string.Empty)
                        //            {
                        //                this.ServiceResult.ErrorOccurred = true;
                        //                this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                        //                throw new Exception(this.ServiceResult.MessageCode);
                        //            }
                        //            #endregion

                        //            if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalTax, "", narration, "TRCREDIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving "))
                        //            {
                        //                if (this.ServiceResult.ErrorOccurred)
                        //                    throw new Exception(this.ServiceResult.MessageCode);
                        //            }

                        //        }

                        //        #region Get_Control_Account
                        //        this.controlAccount = string.Empty;
                        //        this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("INTDEPOSIT", this.sourceBranch, cur); //Get Coa Account
                        //        if (this.controlAccount == null || this.controlAccount == string.Empty)
                        //        {
                        //            this.ServiceResult.ErrorOccurred = true;
                        //            this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                        //            throw new Exception(this.ServiceResult.MessageCode);
                        //        }
                        //        #endregion

                        //        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt, "", narration, "TRDEBIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving "))
                        //        {
                        //            if (this.ServiceResult.ErrorOccurred)
                        //                throw new Exception(this.ServiceResult.MessageCode);
                        //        }
                        //    }
                        //}

                        //else                    //not BudgetEnd
                        //{
                        ////if ( Mamt > 0)
                        ////{
                        ////    #region Get_Control_Account
                        ////    this.controlAccount = string.Empty;
                        ////    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("INTDEPOSIT", this.sourceBranch, cur); //Get Coa Account
                        ////    if (this.controlAccount == null || this.controlAccount == string.Empty)
                        ////    {
                        ////        this.ServiceResult.ErrorOccurred = true;
                        ////        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                        ////        throw new Exception(this.ServiceResult.MessageCode);
                        ////    }
                        ////    #endregion

                        // }

                        //if (Accrued_Total > 0)
                        //{
                        //    #region Get_Control_Account
                        //    this.controlAccount = string.Empty;
                        //    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", this.sourceBranch, cur); //Get Coa Account
                        //    if (this.controlAccount == null || this.controlAccount == string.Empty)
                        //    {
                        //        this.ServiceResult.ErrorOccurred = true;
                        //        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                        //        throw new Exception(this.ServiceResult.MessageCode);
                        //    }
                        //    #endregion

                            #endregion

                        if (TotalAmt > 0)
                        {
                            //Vouchering Saving Interest for Saving A/C
                            this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("INTDEPOSIT", this.sourceBranch, cur); //Get Coa Account

                            if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt, "", narration, "TRDEBIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving "))
                            {
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(this.ServiceResult.MessageCode);
                            }

                            this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SAVCONTROL", this.sourceBranch, cur);   //Get Coa Account        

                            //   if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TaAfterTax, "", narration, "TRCREDIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving ")) error with calcluate amt(TaAfterTax)
                            if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt, "", narration, "TRCREDIT", voucherNo, LedgerType.balJournal, cur, exRate[0], "Saving "))
                            {
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(this.ServiceResult.MessageCode);
                            }
                        }
                        //}
                    }   //End of Currency Loop
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        if (this.SysPostDAO.UpdateStatusByBranchCode(DateTime.Now, "SAVINGPOST", this.sourceBranch, this.updatedUserId))           //Set Post Date to Today from sysPost
                        {
                            //Saving Posting Complete
                            this.SavingPostingPassed = true;
                            MNMDTO00001 postingStatus = new MNMDTO00001();
                            postingStatus.PostingName = "SAVINGPOST";
                            postingStatus.Status = "1";

                            this.PostingStatusDTOs.Add(postingStatus);
                        }
                    }
                }
                //Ststus Checking Incorrect
                else
                {
                    this.SavingPostingPassed = true;
                    MNMDTO00001 postingStatus = new MNMDTO00001();
                    postingStatus.PostingName = "SAVINGPOST";
                    postingStatus.Status = "0";
                    postingStatus.MessageCode = this.ServiceResult.MessageCode;

                    this.PostingStatusDTOs.Add(postingStatus);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //[Transaction(TransactionPropagation.Required)]
        //private void LoansPosting()
        //{
        //    try
        //    {
        //        this.ServiceResult.ErrorOccurred = false;
        //        decimal TotalAmt = 0;
        //        decimal Totaloamt = 0;
        //        decimal Mamt = 0;
        //        decimal MCamt = 0;
        //        decimal Moamt = 0;
        //        decimal MLiamt = 0;
        //        decimal Mcbal = 0;
        //        decimal Tot_Legamt = 0;
        //        decimal SundryTAmt = 0;
        //        decimal SundryTLoAmt = 0;
        //        string RFields = string.Empty;
        //        string narration = "Loans Int Posting";

        //        if (this.GetStatus("LOANSPOST","Loans Posting "))
        //        {
        //            IList<TLMDTO00018> LoanList = this.LoansDAO.SelectLoansByCloseDate(this.sourceBranch);  //Get Loans List
        //            if (LoanList == null || LoanList.Count <= 0)
        //                goto Loan_Posting_Passed;   //Go TO End of Process

        //            var CurList = from l in LoanList group l by new { l.Currency } into lo select new { lo.Key.Currency };
        //            foreach (var varCurrency in CurList.ToList())
        //            {
        //                bool LoanAcccountByCurrencyFound = false;
        //                string cur = varCurrency.Currency;
        //                this.GetVoucherNo();

        //                IList<decimal> exRate = this.RateInfoDAO.SelectRate(cur, "CS");   //get Exchange Rate
        //                if (exRate.Count <= 0)
        //                    throw new Exception("ME00037"); //Exchange Rate not found in table.

        //                switch (this.monthClose)
        //                {
        //                    case 3: RFields = "Q4"; break;
        //                    case 6: RFields = "Q1"; break;
        //                    case 9: RFields = "Q2"; break;
        //                    case 12: RFields = "Q3"; break;
        //                }

        //                var list = from l in LoanList where l.Currency == cur select l; //Get Loan list filter with currency
        //                IList<TLMDTO00018> loanListByCur = list.ToList();
        //                if (loanListByCur == null || loanListByCur.Count <= 0)
        //                    continue;

        //                if (!this.GetControlAccounts(cur))  //Get COA Accounts
        //                    throw new Exception(this.ServiceResult.MessageCode);

        //                foreach (TLMDTO00018 loanDTO in loanListByCur)
        //                {
        //                    LOMDTO00021 liDTO = this.LIDAO.SelectByAccountNo(loanDTO.AccountNo);
        //                    if (liDTO == null)
        //                        continue;

        //                    LoanAcccountByCurrencyFound = true; //Flag

        //                    Mamt = 0; Moamt = 0; MCamt = 0; MLiamt = 0;

        //                    switch (RFields)
        //                    {
        //                        case "Q1": Mamt = liDTO.Q1.Value; break;
        //                        case "Q2": Mamt = liDTO.Q2.Value; break;
        //                        case "Q3": Mamt = liDTO.Q3.Value; break;
        //                        case "Q4": Mamt = liDTO.Q4.Value; break;
        //                        default: Mamt = 0; break;
        //                    }

        //                    string AccountNo = liDTO.Acctno;
        //                    string AcSign = liDTO.ACSign;
        //                    int NplCase = (loanDTO.NPLCase == false) ? 0 : 1;
        //                    int LegalCase = (loanDTO.LegalCase == false) ? 0 : 1;

        //                    this.LoansDAO.UpdateLastIntDate(loanDTO.Lno, this.updatedUserId);   //Update Loans Set LastIntDate = today
        //                    string LoanNo = loanDTO.Lno;

        //                    if (LegalCase == 1)
        //                    {
        //                        #region Get_Control_Account
        //                        this.controlAccount = string.Empty;
        //                        this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LSINCOME", this.sourceBranch, cur);   //Get Coa Account
        //                        if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                        {
        //                            this.ServiceResult.ErrorOccurred = true;
        //                            this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                        #endregion

        //                        //Insert Into LegalInt
        //                        this.LegalIntDAO.Save(this.ConvertToLegalIntORM(loanDTO.Lno, AccountNo, "L", Mamt, "Loans Interest for Expired", this.controlAccount, "", cur));
        //                    }
        //                    else
        //                    {
        //                        decimal currentBal = this.CledgerDAO.SelectACSignByAccountNo(AccountNo).CurrentBal;

        //                        #region Amt_OAmt
        //                        if (currentBal <= 0)
        //                        {
        //                            MCamt = 0;
        //                            Moamt = Mamt;
        //                        }
        //                        else
        //                        {
        //                            if (currentBal >= Mamt)
        //                            {
        //                                MCamt = Mamt;
        //                                Moamt = 0;
        //                            }
        //                            else
        //                            {
        //                                if (currentBal < Mamt)
        //                                {
        //                                    MCamt = currentBal;
        //                                    Moamt = Mamt - currentBal;
        //                                }
        //                            }
        //                        }
        //                        #endregion

        //                        //update Current Balance
        //                        this.CledgerDAO.UpdateCBal(currentBal - Mamt, AccountNo, this.updatedUserId);

        //                        if (NplCase == 1)
        //                        {
        //                            SundryTAmt = SundryTAmt + MCamt;
        //                            SundryTLoAmt = SundryTLoAmt + Moamt;
        //                        }
        //                        else
        //                        {
        //                            TotalAmt = TotalAmt + MCamt;
        //                            Totaloamt = Totaloamt + Moamt;
        //                        }

        //                        if (MCamt != 0 || Moamt != 0)
        //                        {
        //                            switch (AcSign[0])
        //                            {
        //                                case 'C': this.controlAccount = this.curControlAccount; break;
        //                                case 'S': this.controlAccount = this.savControlAccount; break;
        //                                case 'L': this.controlAccount = this.calCantrolAccount; break;
        //                            }

        //                            //Insert int IntTlf
        //                            this.InTlfDAO.Save(this.ConvertToInTlfORM(this.voucherNo, AccountNo, MCamt + Moamt, this.controlAccount, MCamt + Moamt, MCamt, Moamt, MCamt + Moamt, MCamt, Moamt, cur, "Loan Interest of " + AccountNo, narration, DateTime.Now, "TDV", "INTDEBIT", AcSign, exRate[0], this.nextSettlementDate));

        //                            if (NplCase == 1)
        //                            {
        //                                #region Get_Control_Account
        //                                this.controlAccount = string.Empty;
        //                                this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LSINCOME", this.sourceBranch, cur);   //Get Coa Account
        //                                if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                                {
        //                                    this.ServiceResult.ErrorOccurred = true;
        //                                    this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                                    throw new Exception(this.ServiceResult.MessageCode);
        //                                }
        //                                #endregion

        //                                //Insert int NPLInt
        //                                this.NplIntDAO.Save(this.ConvertToNplORM(liDTO.LNo, AccountNo, "L", Mamt, this.controlAccount, "Loans Interest for Expired"));
        //                            }
        //                        }
        //                    }
        //                }//End of Accounts Loop

        //                if (!LoanAcccountByCurrencyFound)
        //                    continue;   //Skip One Step of Currency Loop

        //                //DR Voucher for Current Control.
        //                if ((TotalAmt + SundryTAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("CURCONTROL", this.sourceBranch, cur);   //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt + SundryTAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Loans "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                //DR Voucher for O/D Control.
        //                if ((Totaloamt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", this.sourceBranch, cur);   //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, Totaloamt + SundryTLoAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Loans "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                //CR voucher for InCome Account
        //                if ((TotalAmt + Totaloamt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LSINCOME", this.sourceBranch, cur);   //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if ((SundryTAmt + SundryTLoAmt) <= 0)
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + Totaloamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Loans "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + Totaloamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Loans "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                }

        //                if ((SundryTAmt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SUNDRYOD", this.sourceBranch, cur);   //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, SundryTAmt + SundryTLoAmt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Loans "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }
        //            }//End of Currency Loop

        //            Loan_Posting_Passed:
        //            if (!this.ServiceResult.ErrorOccurred)
        //            {                       
        //                if (this.SysPostDAO.UpdateStatusByBranchCode(DateTime.Now, "LOANSPOST", this.sourceBranch, this.updatedUserId))           //Set Post Date to Today from sysPost
        //                {
        //                    //Loans Posting Complete
        //                    this.LoansPostingPassed = true;
        //                    MNMDTO00001 postingStatus = new MNMDTO00001();
        //                    postingStatus.PostingName = "LOANSPOST";
        //                    postingStatus.Status = "1";

        //                    this.PostingStatusDTOs.Add(postingStatus);
        //                }
        //            }
        //        }
        //        //Status Checking Incorrect
        //        else
        //        {
        //            this.LoansPostingPassed = true;
        //            MNMDTO00001 postingStatus = new MNMDTO00001();
        //            postingStatus.PostingName = "LOANSPOST";
        //            postingStatus.Status = "0";
        //            postingStatus.MessageCode = this.ServiceResult.MessageCode;

        //            this.PostingStatusDTOs.Add(postingStatus);
        //        }
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //private void OverDraftPostion()
        //{
        //    try
        //    {
        //        this.ServiceResult.ErrorOccurred = false;
        //        string narration = "OD Int: Posting";
        //        decimal TotalAmt = 0;
        //        decimal TotalOamt = 0;
        //        decimal Mamt = 0;
        //        decimal MCamt = 0;
        //        decimal Moamt = 0;
        //        decimal Total_Legamt = 0;
        //        decimal SundryTAmt = 0;
        //        decimal SundryTLoAmt = 0;

        //        #region Get Current Month

        //        string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
        //        int month = Convert.ToInt32(value.ToString());
        //        int currentMonth = DateTime.Today.Month;
        //        string curMth = "M" + (((currentMonth < month ? currentMonth + 12 : currentMonth) + 1) - month).ToString();

        //        #endregion

        //        if (this.GetStatus("ODPOST","Overdraft Posting "))
        //        {
        //            IList<PFMDTO00028> CledgerList = this.CledgerDAO.SelectForOverDraftPosting(this.sourceBranch);
        //            if (CledgerList == null || CledgerList.Count <= 0)
        //                goto OD_Posting_Passed;     //Go To End of Process

        //            var CurList = from c in CledgerList group c by new { c.CurrencyCode } into cl select new { cl.Key.CurrencyCode };

        //            foreach (var varCurrency in CurList.ToList())
        //            {
        //                bool ODAccountByCurrencyFound = false;
        //                string cur = varCurrency.CurrencyCode;
        //                this.GetVoucherNo();
        //                IList<decimal> exRate = this.RateInfoDAO.SelectRate(cur, "CS");   //get Exchange Rate
        //                if (exRate.Count <= 0)
        //                    throw new Exception("ME00037"); //Exchange Rate not found in table.

        //                var list = from c in CledgerList where c.CurrencyCode == cur select c;  //Get Cledger List Filter with Currency
        //                IList<PFMDTO00028> cledgerListByCur = list.ToList();
        //                if (cledgerListByCur == null || cledgerListByCur.Count <= 0)
        //                    continue;

        //                if (!this.GetControlAccounts(cur))  //Get COA Accounts
        //                    throw new Exception(this.ServiceResult.MessageCode);

        //                foreach (PFMDTO00028 cledgerDTO in cledgerListByCur)
        //                {
        //                    TLMDTO00018 loanDTO = this.LoansDAO.SelectForOverDraftPosting(cledgerDTO.AccountNo);
        //                    if (loanDTO == null)
        //                        continue;
        //                    MNMDTO00008 oiDTO = this.OiDAO.SelectByAccountNo(cledgerDTO.AccountNo);
        //                    if (oiDTO == null)
        //                        continue;

        //                    ODAccountByCurrencyFound = true;    //Flag

        //                    DateTime IntLastDate = oiDTO.LastDate == null ? DateTime.Now : oiDTO.LastDate.Value;
        //                    decimal LastIntAmount = oiDTO.LastInt;
        //                    decimal LastCalculateInt = this.EndOfMonth.CompareTo(IntLastDate) > 0 ? LastIntAmount * this.EndOfMonth.CompareTo(IntLastDate) : 0;
        //                    DateTime IntDate = this.EndOfMonth.CompareTo(IntLastDate) > 0 ? EndOfMonth : IntLastDate;
        //                    string AccountNo = oiDTO.AcctNo;
        //                    int NPLCase = loanDTO.NPLCase ? 1 : 0;
        //                    string Acsign = oiDTO.ACSign;

        //                    this.OiDAO.UpdateOI(LastCalculateInt, IntDate, AccountNo, curMth, this.updatedUserId);  //Update OI

        //                    switch (this.monthClose)
        //                    {
        //                        case 3: Mamt = oiDTO.M10 + oiDTO.M11 + oiDTO.M12 + LastCalculateInt; break;
        //                        case 6: Mamt = oiDTO.M1 + oiDTO.M2 + oiDTO.M3 + LastCalculateInt; break;
        //                        case 9: Mamt = oiDTO.M4 + oiDTO.M5 + oiDTO.M6 + LastCalculateInt; break;
        //                        case 12: Mamt = oiDTO.M7 + oiDTO.M8 + oiDTO.M9 + LastCalculateInt; break;
        //                    }

        //                    if (loanDTO.LegalCase)
        //                    {
        //                        //Total_Legamt = Total_Legamt + Mamt;           

        //                        #region Get_Control_Account
        //                        this.controlAccount = string.Empty;
        //                        this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ODINTAC", this.sourceBranch, cur);   //Get Coa Account
        //                        if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                        {
        //                            this.ServiceResult.ErrorOccurred = true;
        //                            this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                        #endregion

        //                        //Insert To LegalInt
        //                        this.LegalIntDAO.Save(this.ConvertToLegalIntORM(oiDTO.LNo, AccountNo, "O", Mamt, "Overdraft Interest for Expired", this.controlAccount, "", cur));
        //                    }
        //                    else
        //                    {
        //                        #region Amt_OAmt
        //                        if (cledgerDTO.CurrentBal <= 0)
        //                        {
        //                            MCamt = 0;
        //                            Moamt = Mamt;
        //                        }
        //                        else
        //                        {
        //                            if (cledgerDTO.CurrentBal >= Mamt)
        //                            {
        //                                MCamt = Mamt;
        //                                Moamt = 0;
        //                            }
        //                            else
        //                            {
        //                                if (cledgerDTO.CurrentBal < Mamt)
        //                                {
        //                                    MCamt = cledgerDTO.CurrentBal;
        //                                    Moamt = Mamt - cledgerDTO.CurrentBal;
        //                                }
        //                            }
        //                        }
        //                        #endregion

        //                        //Update Current Balance
        //                        this.CledgerDAO.UpdateCBal(cledgerDTO.CurrentBal - Mamt, AccountNo, this.updatedUserId);

        //                        if (NPLCase == 1)
        //                        {
        //                            SundryTAmt = SundryTAmt + MCamt;
        //                            SundryTLoAmt = SundryTLoAmt + Moamt;
        //                        }
        //                        else
        //                        {
        //                            TotalAmt = TotalAmt + MCamt;
        //                            TotalOamt = TotalOamt + Moamt;
        //                        }

        //                        if (MCamt != 0 || Moamt != 0)
        //                        {
        //                            if (NPLCase == 1)
        //                            {
        //                                #region Get_Control_Account
        //                                this.controlAccount = string.Empty;
        //                                this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ODINTAC", this.sourceBranch, cur);   //Get Coa Account
        //                                if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                                {
        //                                    this.ServiceResult.ErrorOccurred = true;
        //                                    this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                                    throw new Exception(this.ServiceResult.MessageCode);
        //                                }
        //                                #endregion

        //                                this.NplIntDAO.Save(this.ConvertToNplORM(oiDTO.LNo, AccountNo, loanDTO.AType.Substring(0, 1), Mamt, this.controlAccount, "Overdraft Interest for Expired"));
        //                            }

        //                            switch (Acsign[0])
        //                            {
        //                                case 'C': this.controlAccount = this.curControlAccount; break;
        //                                case 'S': this.controlAccount = this.savControlAccount; break;
        //                                case 'L': this.controlAccount = this.calCantrolAccount; break;
        //                            }

        //                            //Insert Into IntTlf
        //                            this.InTlfDAO.Save(this.ConvertToInTlfORM(this.voucherNo, AccountNo, MCamt + Moamt, this.controlAccount, exRate[0] * (MCamt + Moamt), exRate[0] * MCamt, Moamt, MCamt + Moamt, MCamt, Moamt, cur, "OD Interest of " + AccountNo, narration, DateTime.Now, "TDV", "INTDEBIT", Acsign, exRate[0], this.nextSettlementDate));
        //                        }
        //                    }
        //                }//End of Accounts Loop

        //                if (!ODAccountByCurrencyFound)
        //                    continue;   //Skip One Step of CurrencyLoop

        //                if ((TotalAmt + SundryTAmt) > 0)
        //                {
        //                    this.controlAccount = this.curControlAccount;
        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt + SundryTAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balCash, cur, exRate[0], "Over Draft "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                if ((TotalOamt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalOamt + SundryTLoAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                if ((TotalAmt + TotalOamt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ODINTAC", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if ((SundryTAmt + SundryTLoAmt) <= 0)
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + TotalOamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + TotalOamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                }

        //                if ((SundryTAmt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SUNDRYOD", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, SundryTAmt + SundryTLoAmt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                if (Total_Legamt > 0)
        //                {
        //                    //Dr Voucher for Legal Control
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LEGALACCU", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, Total_Legamt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }

        //                    //CR voucher file for legalint
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LEGALSUNDY", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, Total_Legamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Over Draft "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }
        //            }//End of Currency Loop

        //            OD_Posting_Passed:
        //            if (!this.ServiceResult.ErrorOccurred)
        //            {
        //                if (this.SysPostDAO.UpdateStatusByBranchCode(DateTime.Now, "ODPOST", this.sourceBranch, this.updatedUserId))           //Set Post Date to Today from sysPost
        //                {
        //                    //Overdraft Posting Complete
        //                    this.OverdraftPostingPassed = true;
        //                    MNMDTO00001 postingStatus = new MNMDTO00001();
        //                    postingStatus.PostingName = "ODPOST";
        //                    postingStatus.Status = "1";

        //                    this.PostingStatusDTOs.Add(postingStatus);
        //                }
        //            }
        //        }
        //        //Status Checking Incorrect
        //        else
        //        {
        //            this.OverdraftPostingPassed = true;
        //            MNMDTO00001 postingStatus = new MNMDTO00001();
        //            postingStatus.PostingName = "ODPOST";
        //            postingStatus.Status = "0";
        //            postingStatus.MessageCode = this.ServiceResult.MessageCode;

        //            this.PostingStatusDTOs.Add(postingStatus);
        //        }
        //    }
        //    catch (Exception ex)
        //    { throw new Exception(ex.Message); }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //private void CommitmentFeesPosting()
        //{
        //    try
        //    {
        //        this.ServiceResult.ErrorOccurred = false;
        //        decimal TotalAmt = 0;
        //        decimal Totaloamt = 0;
        //        decimal Mamt = 0;
        //        decimal MCamt = 0;
        //        decimal Moamt = 0;
        //        decimal Tot_Legamt = 0;
        //        decimal SundryTAmt = 0;
        //        decimal SundryTLoAmt = 0;
        //        string narration = "Commitment Fees Posting";

        //        #region Get Current Month

        //        string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
        //        int month = Convert.ToInt32(value.ToString());
        //        int currentMonth = DateTime.Today.Month;
        //        string curMth = "M" + (((currentMonth < month ? currentMonth + 12 : currentMonth) + 1) - month).ToString();

        //        #endregion

        //        if (this.GetStatus("COMFEEPOST", "Commitment Fee Posting "))
        //        {
        //            IList<PFMDTO00028> CledgerList = this.CledgerDAO.SelectForOverDraftPosting(this.sourceBranch);
        //            if (CledgerList == null || CledgerList.Count <= 0)
        //                goto Com_Posting_Passed;    //Go To End of Process

        //            var CurList = from c in CledgerList group c by new { c.CurrencyCode } into cl select new { cl.Key.CurrencyCode };

        //            foreach (var varCurrency in CurList.ToList())
        //            {
        //                bool CommitAccountByCurrencyFound = false;
        //                string cur = varCurrency.CurrencyCode;
        //                var List = from c in CledgerList where c.CurrencyCode == cur select c;
        //                IList<PFMDTO00028> CledgerListByCur = List.ToList();
        //                IList<decimal> exRate = this.RateInfoDAO.SelectRate(cur, "CS");   //get Exchange Rate
        //                if (exRate.Count <= 0)
        //                    throw new Exception("ME00037"); //Exchange Rate not found in table.

        //                if (CledgerListByCur == null || CledgerListByCur.Count <= 0)
        //                    continue;

        //                if (!this.GetControlAccounts(cur))  //Get COA Accounts
        //                    throw new Exception(this.ServiceResult.MessageCode);

        //                this.GetVoucherNo();

        //                foreach (PFMDTO00028 cledgerDTO in CledgerListByCur)
        //                {
        //                    TLMDTO00018 loanDTO = this.LoansDAO.SelectForOverDraftPosting(cledgerDTO.AccountNo);
        //                    if (loanDTO == null)
        //                        continue;
        //                    MNMDTO00011 commitFeesDTO = this.CommitFeesDAO.SelectByAccountNo(cledgerDTO.AccountNo);
        //                    if (commitFeesDTO == null)
        //                        continue;

        //                    CommitAccountByCurrencyFound = true;    //Flag

        //                    Mamt = 0; Moamt = 0;
        //                    DateTime IntLastDate = commitFeesDTO.LastDate == null ? DateTime.Now : commitFeesDTO.LastDate.Value;
        //                    decimal LastIntAmount = commitFeesDTO.LastInt == null ? 0 : commitFeesDTO.LastInt.Value;
        //                    decimal LastCalculateInt = this.EndOfMonth.CompareTo(IntLastDate) > 0 ? LastIntAmount * this.EndOfMonth.CompareTo(IntLastDate) : 0;
        //                    DateTime IntDate = this.EndOfMonth.CompareTo(IntLastDate) > 0 ? this.EndOfMonth : IntLastDate;
        //                    string AccountNo = commitFeesDTO.Acctno;
        //                    int NPLCase = loanDTO.NPLCase ? 1 : 0;
        //                    string AcSign = loanDTO.ACSign;

        //                    this.OiDAO.UpdateOI(LastCalculateInt, IntDate, AccountNo, curMth, this.updatedUserId);  //Update OI

        //                    switch (this.monthClose)
        //                    {
        //                        case 3: Mamt = commitFeesDTO.M10 + commitFeesDTO.M11 + commitFeesDTO.M12; break;
        //                        case 6: Mamt = commitFeesDTO.M1 + commitFeesDTO.M2 + commitFeesDTO.M3; break;
        //                        case 9: Mamt = commitFeesDTO.M4 + commitFeesDTO.M5 + commitFeesDTO.M6; break;
        //                        case 12: Mamt = commitFeesDTO.M7 + commitFeesDTO.M8 + commitFeesDTO.M9; break;
        //                    }

        //                    if (loanDTO.LegalCase)
        //                    {
        //                        //Tot_Legamt = Tot_Legamt + Mamt;
        //                        #region Get_Control_Account
        //                        this.controlAccount = string.Empty;
        //                        this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("CommitNew", this.sourceBranch, cur); //Get Coa Account
        //                        if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                        {
        //                            this.ServiceResult.ErrorOccurred = true;
        //                            this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                        #endregion

        //                        //Insert Into LegalInt
        //                        this.LegalIntDAO.Save(this.ConvertToLegalIntORM(commitFeesDTO.LNo, AccountNo, "O", Mamt, "Overdraft Interest for Expired", this.controlAccount, "", cur));
        //                    }
        //                    else
        //                    {
        //                        MCamt = 0; Moamt = 0;
        //                        #region Amt_OAmt

        //                        if (cledgerDTO.CurrentBal <= 0)
        //                        {
        //                            MCamt = 0;
        //                            Moamt = Mamt;
        //                        }
        //                        else
        //                        {
        //                            if (cledgerDTO.CurrentBal >= Mamt)
        //                            {
        //                                MCamt = Mamt;
        //                                Moamt = 0;
        //                            }
        //                            else
        //                            {
        //                                if (cledgerDTO.CurrentBal < Mamt)
        //                                {
        //                                    MCamt = cledgerDTO.CurrentBal;
        //                                    Moamt = Mamt - cledgerDTO.CurrentBal;
        //                                }
        //                            }
        //                        }

        //                        #endregion

        //                        //Update Current Balance
        //                        this.CledgerDAO.UpdateCBal(cledgerDTO.CurrentBal - Mamt, AccountNo, this.updatedUserId);

        //                        if (NPLCase == 1)
        //                        {
        //                            SundryTAmt = SundryTAmt + MCamt;
        //                            SundryTLoAmt = SundryTLoAmt + Moamt;
        //                        }
        //                        else
        //                        {
        //                            TotalAmt = TotalAmt + MCamt;
        //                            Totaloamt = Totaloamt + Moamt;
        //                        }

        //                        if (MCamt != 0 || Moamt != 0)
        //                        {
        //                            if (NPLCase == 1)
        //                            {
        //                                #region Get_Control_Account
        //                                this.controlAccount = string.Empty;
        //                                this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("ODINTAC", this.sourceBranch, cur); //Get Coa Account
        //                                if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                                {
        //                                    this.ServiceResult.ErrorOccurred = true;
        //                                    this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                                    throw new Exception(this.ServiceResult.MessageCode);
        //                                }
        //                                #endregion

        //                                //Insert Into NplInt
        //                                this.NplIntDAO.Save(this.ConvertToNplORM(commitFeesDTO.LNo, AccountNo, "C", Mamt, this.controlAccount, "Commitment Fees for Expired"));
        //                            }

        //                            switch (AcSign[0])
        //                            {
        //                                case 'C': this.controlAccount = this.curControlAccount; break;
        //                                case 'S': this.controlAccount = this.savControlAccount; break;
        //                                case 'L': this.controlAccount = this.calCantrolAccount; break;
        //                            }

        //                            //Insert Into IntTlf
        //                            this.InTlfDAO.Save(this.ConvertToInTlfORM(this.voucherNo, AccountNo, MCamt + Moamt, this.controlAccount, exRate[0] * (MCamt + Moamt), exRate[0] * MCamt, Moamt, MCamt + Moamt, MCamt, Moamt, cur, "Commitment Interest of " + AccountNo, narration, DateTime.Now, "TDV", "INTDEBIT", AcSign, exRate[0], this.nextSettlementDate));
        //                        }
        //                    }
        //                }//End of Accounts Loop

        //                if (!CommitAccountByCurrencyFound)
        //                    continue;   //Skip One Step of Currency Loop

        //                //Updating Debit Voucher For Current Control Account
        //                if ((TotalAmt + SundryTAmt) > 0)
        //                {
        //                    this.controlAccount = this.curControlAccount;
        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt + SundryTAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balCash, cur, exRate[0], "Commitment Fees "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                //Updating Debit Voucher For Overdraft Control Account
        //                if ((Totaloamt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, (Totaloamt + SundryTLoAmt), "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commitment Fees "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                //Updating Credit Voucher For Overdraft & Current  Control Account
        //                if ((TotalAmt + Totaloamt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("CommitNew", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if ((SundryTAmt + SundryTLoAmt) <= 0)
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + Totaloamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commitment Fees "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt + Totaloamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commitment Fees "))
        //                        {
        //                            if (this.ServiceResult.ErrorOccurred)
        //                                throw new Exception(this.ServiceResult.MessageCode);
        //                        }
        //                    }
        //                }

        //                //Updating Credit Voucher For Overdraft & Current  Control Account
        //                if ((SundryTAmt + SundryTLoAmt) > 0)
        //                {
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SUNDRYOD", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, SundryTAmt + SundryTLoAmt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commitment Fees "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }

        //                if (Tot_Legamt > 0)
        //                {
        //                    //Updating Debit Voucher For Legal Control Account
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LEGALACCU", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, Tot_Legamt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commitment Fees "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }


        //                    //Updating Credit Voucher For Legal Case Control Account
        //                    #region Get_Control_Account
        //                    this.controlAccount = string.Empty;
        //                    this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("LEGALSUNDY", this.sourceBranch, cur); //Get Coa Account
        //                    if (this.controlAccount == null || this.controlAccount == string.Empty)
        //                    {
        //                        this.ServiceResult.ErrorOccurred = true;
        //                        this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
        //                        throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                    #endregion

        //                    if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, Tot_Legamt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Commintment Fees "))
        //                    {
        //                        if (this.ServiceResult.ErrorOccurred)
        //                            throw new Exception(this.ServiceResult.MessageCode);
        //                    }
        //                }
        //            }//End of currency Loop

        //        Com_Posting_Passed:
        //            if (!this.ServiceResult.ErrorOccurred)
        //            {
        //                if (this.SysPostDAO.UpdateStatusByBranchCode(DateTime.Now, "COMFEEPOST", this.sourceBranch, this.updatedUserId))           //Set Post Date to Today from sysPost
        //                {
        //                    //CommitFees Posting Complete
        //                    this.CommitFeesPostingPassed = true;
        //                    MNMDTO00001 postingStatus = new MNMDTO00001();
        //                    postingStatus.PostingName = "COMFEEPOST";
        //                    postingStatus.Status = "1";

        //                    this.PostingStatusDTOs.Add(postingStatus);
        //                }
        //            }
        //        }
        //        //Status Checking Incorrect
        //        else
        //        {
        //            this.CommitFeesPostingPassed = true;
        //            MNMDTO00001 postingStatus = new MNMDTO00001();
        //            postingStatus.PostingName = "COMFEEPOST";
        //            postingStatus.Status = "0";
        //            postingStatus.MessageCode = this.ServiceResult.MessageCode;

        //            this.PostingStatusDTOs.Add(postingStatus);
        //        }
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}

        [Transaction(TransactionPropagation.Required)]
        private void FixedPosting()
        {
            try
            {
                this.ServiceResult.ErrorOccurred = false;
                string narration = "Fixed Interest Posting";
                decimal AccruedAmt = 0;
                decimal TotalAmt = 0;
                string Rno;
                string CurrentBudYear;

                if (this.GetStatus("FIXEDPOST", "Fixed Posting "))
                {
                    this.GetVoucherNo();

                    #region Get Current BudgetYear

                    string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
                    int month = Convert.ToInt32(value.ToString());
                    if (DateTime.Today.Month < month)
                    {
                        CurrentBudYear = (DateTime.Today.Year - 1).ToString() + "/" + DateTime.Today.Year.ToString();    //Get inputed Budget Year
                    }
                    else
                    {
                        CurrentBudYear = DateTime.Today.Year.ToString() + "/" + (DateTime.Today.Year + 1).ToString();    //Get inputed Budget Year
                    }

                    #endregion

                    IList<PFMDTO00032> fReceiptList = this.FreceiptDAO.SelectFReceiptByWdateIsNull(this.sourceBranch);
                    if (fReceiptList == null || fReceiptList.Count <= 0)
                        goto Fixed_Posting_Passed;  //Go To End Of Process

                    var CurList = from f in fReceiptList group f by new { f.CurrencyCode } into fl select new { fl.Key.CurrencyCode };
                    foreach (var varCurrency in CurList.ToList())
                    {
                        string cur = varCurrency.CurrencyCode;
                        IList<decimal> exRate = this.RateInfoDAO.SelectRate(cur, "CS");   //get Exchange Rate
                        if (exRate.Count <= 0)
                            throw new Exception("ME00037"); //Exchange Rate not found in table.

                        var FList = from f in fReceiptList where f.CurrencyCode == cur select f;    //Get Freceipt List filter with Currency
                        IList<PFMDTO00032> fReceiptListByCur = FList.ToList();

                        if (fReceiptListByCur == null || fReceiptListByCur.Count == 0)
                            continue;

                        foreach (PFMDTO00032 fReceipt in fReceiptListByCur)
                        {
                            string AccountNo = fReceipt.AccountNo;
                            Rno = fReceipt.ReceiptNo;
                            AccruedAmt = fReceipt.DebitAccrued;

                            if (AccruedAmt > 0)
                            {
                                TotalAmt = TotalAmt + AccruedAmt;
                                this.FreceiptDAO.UpdateBudgetEndAcAndDrAccrued(AccruedAmt, this.updatedUserId, AccountNo, Rno);     //Update Freceipt
                                this.FixIntPostingBeforeDAO.Save(this.ConvertToFixIntPostingBeforeORM(AccountNo, Rno, AccruedAmt, CurrentBudYear, cur));  //Insert To FixIntPostingBefore
                            }
                        }//End of Accounts Loop

                        if (TotalAmt > 0)
                        {
                            #region Get_Control_Account
                            this.controlAccount = string.Empty;
                            this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", this.sourceBranch, cur); //Get Coa Account
                            if (this.controlAccount == null || this.controlAccount == string.Empty)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                                throw new Exception(this.ServiceResult.MessageCode);
                            }
                            #endregion

                            if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Credit, TotalAmt, "", narration, "TRCREDIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Fixed "))
                            {
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(this.ServiceResult.MessageCode);
                            }

                            #region Get_Control_Account
                            this.controlAccount = string.Empty;
                            this.controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("FINTDEPO", this.sourceBranch, cur); //Get Coa Account
                            if (this.controlAccount == null || this.controlAccount == string.Empty)
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                                throw new Exception(this.ServiceResult.MessageCode);
                            }
                            #endregion

                            if (!this.Voucher_Updating_Switch(this.controlAccount, Transaction.Debit, TotalAmt, "", narration, "TRDEBIT", this.voucherNo, LedgerType.balJournal, cur, exRate[0], "Fixed "))
                            {
                                if (this.ServiceResult.ErrorOccurred)
                                    throw new Exception(this.ServiceResult.MessageCode);
                            }
                        }
                    }//End of Cur Loop

                    Fixed_Posting_Passed:
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        if (this.SysPostDAO.UpdateStatusByBranchCode(DateTime.Now, "FIXEDPOST", this.sourceBranch, this.updatedUserId))           //Set Post Date to Today from sysPost
                        {
                            //Fixed Posting Complete
                            this.FixedPostingPassed = true;
                            MNMDTO00001 postingStatus = new MNMDTO00001();
                            postingStatus.PostingName = "FIXEDPOST";
                            postingStatus.Status = "1";

                            this.PostingStatusDTOs.Add(postingStatus);
                        }
                    }
                }
                //Status Checking Incorrect
                else
                {
                    this.FixedPostingPassed = true;
                    MNMDTO00001 postingStatus = new MNMDTO00001();
                    postingStatus.PostingName = "FIXEDPOST";
                    postingStatus.Status = "0";
                    postingStatus.MessageCode = this.ServiceResult.MessageCode;

                    this.PostingStatusDTOs.Add(postingStatus);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        #endregion

        #region Helper Methods

        public bool CheckClosing(string sourcebr)
        {
            this.sys001List = this.Sys001DAO.SelectSys001ForMonthBefore(sourcebr);   //Get sys001 Data

            PFMDTO00056 sys001DTO = this.GetSys001ByName("MONTH_CLOSE");
            if (sys001DTO == null || sys001List.Count < 1)
                return false;

            lastRunDate = sys001DTO.SysMonYear;                                                  //Get sysMonYear
            string[] tempLastRunDate = lastRunDate.Split("/".ToCharArray());
            monthClose = Convert.ToInt32(tempLastRunDate[0]) == 12 ? 1 : Convert.ToInt32(tempLastRunDate[0]) + 1;
            yearClose = monthClose == 1 ? Convert.ToInt32(tempLastRunDate[1]) + 1 : Convert.ToInt32(tempLastRunDate[1]);

            //PFMDTO00057 newSetupDTO = this.NewSetupDAO.SelectByVariable("SAVPOST");
            //this.savPostMonth = Convert.ToInt32(newSetupDTO.Value);

            EndOfMonth = monthClose == 12 ? Convert.ToDateTime("01/01/" + (yearClose + 1).ToString()) : Convert.ToDateTime((monthClose + 1).ToString() + "/01/" + yearClose.ToString());
            EndOfMonth = EndOfMonth.AddDays(-1);

            /*
            //Old Logic
            if (Convert.ToInt32(monthClose) != DateTime.Today.Month || Convert.ToInt32(yearClose) != DateTime.Today.Year)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30038";     //No Need to Run Monthly Closing
                return false;
            }           
            */

            #region Back_EOD_Logic (Added by HMW at 16-10-2019)
            TCMDTO00001 systemStartInfo = CXServiceWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourcebr));
            DateTime systemDate = systemStartInfo.Date;

            if (Convert.ToInt32(monthClose) != systemDate.Month || Convert.ToInt32(yearClose) != systemDate.Year)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30038";     //No Need to Run Monthly Closing
                return false;
            }
            #endregion

            #region Get NextSettlementDate
            this.nextSettlementDate = this.Sys001DAO.SelectSysDate("NEXT_SETTLEMENT_DATE", this.sourceBranch); 

            if (this.nextSettlementDate == null || this.nextSettlementDate.ToString() == string.Empty)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30027";     //NextSettlementDate Not Found
                return false;
            }
            #endregion
            

            return true;
        }

        private bool checkInterest()
        {
            PFMDTO00056 sys001DTO;
            DateTime sysDate = default(DateTime);

            #region CheckingForOD
            //sys001DTO = this.GetSys001ByName("OVD_INT_CAL");
            //if (sys001DTO == null)
            //    return false;

            //sysDate = sys001DTO.SysDate.Value;                                          //Get sysDate

            //if (sysDate.ToShortDateString() != DateTime.Today.ToShortDateString())      //Checking For OverDraft
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MI30018";     //Please Calculate O/D and Commitment Interest First.
            //    return false;
            //}
            #endregion

            #region CheckingForCommitFees
            //sys001DTO = this.GetSys001ByName("COMMITFEES");
            //if (sys001DTO == null)
            //    return false;

            //sysDate = sys001DTO.SysDate.Value;                                             //Get sysDate

            //if (sysDate.ToShortDateString() != DateTime.Today.ToShortDateString())         //Checking For Commit
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MI30019";     //"Please Calculate Commitment Interest First."
            //    return false;
            //}
            #endregion

            #region CheckingForSaving
            //if ((this.monthClose == 3 || this.monthClose == 6 || this.monthClose == 9 || this.monthClose == 12) && this.savPostMonth == 3)      //Checking For Saving
            //{
            //    sys001DTO = this.GetSys001ByName("SAV_INT_CAL");
            //    if (sys001DTO == null)
            //        return false;

            //    string sysMonthYear = sys001DTO.SysMonYear;                                 //Get sysMonYear
            //    string[] tempSysMonthYear = sysMonthYear.Split("/".ToCharArray());
            //    if (Convert.ToInt32(tempSysMonthYear[0]) != DateTime.Today.Month || Convert.ToInt32(tempSysMonthYear[1]) != DateTime.Today.Year)
            //    {
            //        this.ServiceResult.ErrorOccurred = true;
            //        this.ServiceResult.MessageCode = "MI30017";       //Please Calculate Saving Interest First.
            //        return false;
            //    }
            //} //Modified By AAM(28-08-2017)
            #endregion

            #region CheckingForLoan
            //sys001DTO = this.GetSys001ByName("LOAN_INT_CAL");
            //if (sys001DTO == null)
            //    return false;

            //string sysQtr = sys001DTO.SysQty;                                               //Get sysQtr
            //string currentQtr = this.GetBudgetInfo();

            //if (sysQtr != currentQtr)                                                       //Checking For Loans
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MI30020";    //Please Calculate Loans Interest First.
            //    return false;
            //}
            #endregion

            #region CheckingForCommitCharges
            //if (this.monthClose == 3 || this.monthClose == 6 || this.monthClose == 9 || this.monthClose == 12)      //Checking For Commit Charges
            //{
            //    sys001DTO = this.GetSys001ByName("COMMIT_CHARGES");
            //    if (sys001DTO == null)
            //        return false;

            //    sysQtr = sys001DTO.SysQty;                                                  //Get sysQtr
            //    currentQtr = this.GetBudgetInfo();

            //    if (sysQtr != currentQtr)
            //    {
            //        this.ServiceResult.ErrorOccurred = true;
            //        this.ServiceResult.MessageCode = "MI30021";    //Please Calculate Commit Charges First.
            //        return false;
            //    }
            //}
            #endregion

            return true;
        }

        private string GetBudgetInfo()
        {
            string CurrentBudYear;
            int CurrentMonth = DateTime.Today.Month;
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            int month = Convert.ToInt32(value.ToString());
            if (DateTime.Today.Month < month)
            {
                CurrentBudYear = (DateTime.Today.Year - 1).ToString() + "/" + DateTime.Today.Year.ToString();    //Get inputed Budget Year
            }
            else
            {
                CurrentBudYear = DateTime.Today.Year.ToString() + "/" + (DateTime.Today.Year + 1).ToString();    //Get inputed Budget Year
            }

            //Get month Quarter
            if (CurrentMonth >= 4 && CurrentMonth <= 6)
                return "1/" + CurrentBudYear;
            else if (CurrentMonth >= 7 && CurrentMonth <= 9)
                return "2/" + CurrentBudYear;
            else if (CurrentMonth >= 10 && CurrentMonth <= 12)
                return "3/" + CurrentBudYear;
            else if (CurrentMonth >= 1 && CurrentMonth <= 3)
                return "4/" + CurrentBudYear;
            else
                return "";
        }

        private bool GetStatus(string postName, string postingProcessName)
        {
            IList<MNMDTO00001> PostDateList = sysPostList.Where<MNMDTO00001>(x => x.PostingName.ToLower() == postName.ToLower()).ToList();
            if (PostDateList == null || PostDateList.Count <= 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30011," + "for " + postingProcessName;         //Data Not Found in SysPost
                return false;
            }
            DateTime postDate = PostDateList[0].Date_time == null ? default(DateTime) : PostDateList[0].Date_time.Value;                //Get Post Date by postName

            if (postDate == default(DateTime))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30023";         //Posting Status is Not Avaliable
                return false;
            }
            else if (postDate.Month == DateTime.Today.Month)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30022," + postingProcessName;         //{0} Already Process
                return false;
            }
            return true;
        }

        private PFMDTO00056 GetSys001ByName(string name)
        {
            IList<PFMDTO00056> tempSys001List = this.sys001List.Where<PFMDTO00056>(x => x.Name.ToLower() == name.ToLower()).ToList();
            if (tempSys001List.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30028"; //Data not found in Sys001
                return null;
            }
            else
                return tempSys001List[0];
        }

        [Transaction(TransactionPropagation.Required)]
        private bool Voucher_Updating_Switch(string controlAccount, Transaction debit_credit, decimal totalAmt, string cheque, string narration, string transaction, string voucherNo, LedgerType ledgerType, string cur, decimal exRate, string postingName)
        {

            try
            {
                TLMDTO00005 tranTypeDTO = this.TrantypeDAO.SelectByTranCode(transaction);
                string status = tranTypeDTO.Status;
                string trancode = tranTypeDTO.TransactionCode;
                ChargeOfAccountDTO coaDTO = this.CoaDAO.SelectByCode(controlAccount, this.sourceBranch);
                string desp = coaDTO.COASetUpAccountName;  //Get Coa Account's Name

                this.TlfDAO.Save(this.ConvertToTlfORM(controlAccount, voucherNo, controlAccount, totalAmt, totalAmt * exRate, totalAmt * exRate, 0, totalAmt, totalAmt, 0, status, trancode, cur, exRate, this.nextSettlementDate, "CBS", desp, narration));

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30025," + postingName;     //Error Occur in {0} Posting
                return false;
            }
            return true;
        }

        private void GetVoucherNo()
        {
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), this.sourceBranch ,true});
            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, this.updatedUserId, this.sourceBranch, new object[] { day, month, year });
        }

        private bool GetControlAccounts(string cur)
        {
            this.curControlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("CURCONTROL", this.sourceBranch, cur);   //Get Coa Account
            this.savControlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SAVCONTROL", this.sourceBranch, cur);   //Get Coa Account
            this.calCantrolAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("CALCONTROL", this.sourceBranch, cur);   //Get Coa Account
            this.sControlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("SUNDRYOD", this.sourceBranch, cur);   //Get Coa Account
            if (this.curControlAccount == string.Empty || this.savControlAccount == string.Empty || this.calCantrolAccount == string.Empty || this.sControlAccount == string.Empty)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                return false;
            }
            return true;
        }

        #endregion

        #region Conver To ORM

        private PFMORM00043 ConvertToPrnFileORM(string accountNo, DateTime date_time, decimal credit, decimal balance, string reference, string cur, string sourceBr)
        {
            PFMORM00043 prnFileORM = new PFMORM00043();

            prnFileORM.AccountNo = accountNo;
            prnFileORM.DATE_TIME = date_time;
            prnFileORM.Credit = credit;
            prnFileORM.Balance = balance;
            prnFileORM.Reference = reference;
            prnFileORM.CurrencyCode = cur;
            prnFileORM.SourceBranchCode = sourceBr;

            return prnFileORM;
        }

        private MNMORM00021 ConvertToInTlfORM(string Eno, string AccountNo, decimal Amount, string ACode, decimal HomeAmount, decimal HomeAmt, decimal HomeOAmt, decimal LocalAmount, decimal LocalAmt, decimal LocalOAmt, string cur, string Desp, string Narration, DateTime Date_Time, string Status, string TranCode, string AcSign, decimal rate, DateTime nextSettlementDate)
        {
            MNMORM00021 inTlfORM = new MNMORM00021();

            inTlfORM.ENO = Eno;
            inTlfORM.ACCTNO = AccountNo;
            inTlfORM.AMOUNT = Amount;
            inTlfORM.ACODE = ACode;
            inTlfORM.HOMEAMOUNT = HomeAmount;
            inTlfORM.HOMEAMT = HomeAmt;
            inTlfORM.HOMEOAMT = HomeOAmt;
            inTlfORM.LOCALAMOUNT = LocalAmount;
            inTlfORM.LOCALAMT = LocalAmt;
            inTlfORM.LOCALOAMT = LocalOAmt;
            inTlfORM.DESP = Desp;
            inTlfORM.NARRATION = Narration;
            inTlfORM.DATE_TIME = Date_Time;
            inTlfORM.STATUS = Status;
            inTlfORM.TRANCODE = TranCode;
            inTlfORM.ACSIGN = AcSign;
            inTlfORM.USERNO = this.updatedUserId.ToString();
            inTlfORM.SOURCECUR = cur;
            inTlfORM.Active = true;
            inTlfORM.CreatedDate = DateTime.Now;
            inTlfORM.CreatedUserId = this.updatedUserId;
            inTlfORM.SOURCEBR = this.sourceBranch;
            inTlfORM.RATE = rate;
            inTlfORM.SETTLEMENTDATE = nextSettlementDate;

            return inTlfORM;
        }

        private MNMORM00021 ConvertToInTlfORM(string voucherNo, string accountNo, decimal afterTax, decimal odAmount, string cur, string description, string narration, string status, string tranCode, string acsign, decimal rate, DateTime nextSettlementDate,string uid)
        {
            MNMORM00021 inTlfORM = new MNMORM00021();

            inTlfORM.ENO = voucherNo;
            inTlfORM.ACCTNO = accountNo;
            inTlfORM.AMOUNT = afterTax + odAmount;
            inTlfORM.ACODE = this.controlAccount;
            inTlfORM.HOMEAMOUNT = rate * (afterTax + odAmount);
            inTlfORM.HOMEAMT = rate * afterTax;
            inTlfORM.SOURCECUR = cur;
            inTlfORM.HOMEOAMT = odAmount;
            inTlfORM.LOCALAMOUNT = afterTax + odAmount;
            inTlfORM.LOCALAMT = afterTax;
            inTlfORM.LOCALOAMT = odAmount;
            inTlfORM.DESP = description;
            inTlfORM.NARRATION = narration;
            inTlfORM.DATE_TIME = DateTime.Now;
            inTlfORM.STATUS = status;
            inTlfORM.TRANCODE = tranCode;
            inTlfORM.ACSIGN = acsign;
            inTlfORM.USERNO = this.updatedUserId.ToString();
            inTlfORM.CURCODE = cur;
            inTlfORM.Active = true;
            inTlfORM.CreatedDate = DateTime.Now;
            inTlfORM.CreatedUserId = this.updatedUserId;
            inTlfORM.SOURCEBR = this.sourceBranch;
            inTlfORM.RATE = rate;
            inTlfORM.SETTLEMENTDATE = nextSettlementDate;
            inTlfORM.UID = uid;


            return inTlfORM;
        }

        private PFMORM00054 ConvertToTlfORM(string ACode, string Eno, string AccountNo, decimal Amount, decimal HomeAmount, decimal HomeAmt,
            decimal HomeOAmt, decimal LocalAmount, decimal LocalAmt, decimal LocalOAmt, string Status, string TranCode, string SourceCur,
            decimal Rate, DateTime SettlementDate, string Channel, string desp, string narration)
        {
            PFMORM00054 tlfORM = new PFMORM00054();

            tlfORM.Id = this.TlfDAO.SelectMaxId() + 1;
            tlfORM.Acode = ACode;
            tlfORM.Eno = Eno;
            tlfORM.AccountNo = AccountNo;
            tlfORM.Amount = Amount;
            tlfORM.HomeAmount = HomeAmount;
            tlfORM.HomeAmt = HomeAmt;
            tlfORM.HomeOAmt = HomeOAmt;
            tlfORM.LocalAmount = LocalAmount;
            tlfORM.LocalAmt = LocalAmt;
            tlfORM.LocalOAmt = LocalOAmt;
            tlfORM.DateTime = DateTime.Now;
            tlfORM.Status = Status;
            tlfORM.TransactionCode = TranCode;
            tlfORM.UserNo = this.updatedUserId.ToString();
            tlfORM.SourceCurrency = SourceCur;
            tlfORM.Rate = Rate;
            tlfORM.SourceBranchCode = this.sourceBranch;
            tlfORM.SettlementDate = SettlementDate;
            tlfORM.Channel = Channel;
            tlfORM.Description = desp;
            tlfORM.Narration = narration;

            tlfORM.CreatedDate = DateTime.Now;
            tlfORM.CreatedUserId = this.updatedUserId;
            tlfORM.Active = true;

            return tlfORM;
        }

        private MNMORM00026 ConvertToFixIntPostingBeforeORM(string acctNo, string rNo, decimal amount, string budget, string cur)
        {
            MNMORM00026 fixIntPostingBeforeORM = new MNMORM00026();
            fixIntPostingBeforeORM.AcctNo = acctNo;
            fixIntPostingBeforeORM.RNo = rNo;
            fixIntPostingBeforeORM.Amount = amount;
            fixIntPostingBeforeORM.Date_Time = DateTime.Now;
            fixIntPostingBeforeORM.Budget = budget;
            fixIntPostingBeforeORM.UserNo = this.updatedUserId.ToString();
            fixIntPostingBeforeORM.SourceBr = this.sourceBranch;
            fixIntPostingBeforeORM.Cur = cur;
            fixIntPostingBeforeORM.Active = true;
            fixIntPostingBeforeORM.CreatedDate = DateTime.Now;
            fixIntPostingBeforeORM.CreatedUserId = this.updatedUserId;

            return fixIntPostingBeforeORM;
        }

        private MNMORM00012 ConvertToLegalIntORM(string lno, string accountNo, string aType, decimal amount, string narration, string type, string crAccountNo, string cur)
        {
            MNMORM00012 legalIntORM = new MNMORM00012();

            legalIntORM.LNo = lno;
            legalIntORM.AcctNo = accountNo;
            legalIntORM.AType = aType;
            legalIntORM.Amount = amount;
            legalIntORM.Type = type;
            legalIntORM.Narration = narration;
            legalIntORM.CRAcctno = crAccountNo;
            legalIntORM.SourceBr = this.sourceBranch;
            legalIntORM.Cur = cur;
            legalIntORM.UserNo = this.updatedUserId.ToString();
            legalIntORM.Active = true;
            legalIntORM.CreatedDate = DateTime.Now;
            legalIntORM.CreatedUserId = this.updatedUserId;

            return legalIntORM;
        }

        private TCMORM00003 ConvertToNplORM(string lno, string accountNo, string aType, decimal amount, string type, string narration)
        {
            TCMORM00003 NplORM = new TCMORM00003();

            NplORM.LNo = lno;
            NplORM.AcctNo = accountNo;
            NplORM.AType = aType;
            NplORM.Date_Time = DateTime.Now;
            NplORM.Amount = amount;
            NplORM.Type = type;
            NplORM.Narration = narration;
            NplORM.SourceBr = this.sourceBranch;
            NplORM.UserNo = this.updatedUserId.ToString();
            NplORM.Active = true;
            NplORM.CreatedDate = DateTime.Now;
            NplORM.CreatedUserId = this.updatedUserId;

            return NplORM;
        }

        #endregion
    }
}
