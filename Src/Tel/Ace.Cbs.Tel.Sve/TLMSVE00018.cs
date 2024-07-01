//----------------------------------------------------------------------
// <copyright file="TLMSVE00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00018 : BaseService, ITLMSVE00018
    {
        #region"Properties"
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00010 SavingAccountCheck { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00017 RDDAO { get; set; }
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ITLMDAO00009 DepoDenoDAO { get; set; }
        public ITLMDAO00029 RemitBrIBLDAO { get; set; }
        public ITLMDAO00028 RemitBrDAO { get; set; }
        public IPFMDAO00002 CloseBalanceDAO { get; set; }
        public IPFMDAO00020 UCheckDAO { get; set; }
        public ILOMDAO00011 LMT9900Dao { get; set; }

        IList<PFMDTO00017> caofList = new List<PFMDTO00017>();
        IList<MNMDTO00012> legalIntList = new List<MNMDTO00012>();
        IList<MNMDTO00011> commitList = new List<MNMDTO00011>();
        IList<LOMDTO00021> liList = new List<LOMDTO00021>();
        IList<MNMDTO00027> schargeList = new List<MNMDTO00027>();


        public ITLMDAO00021 DrawingPrintingDAO;
        private ChargeOfAccountDTO CoaDTO { get; set; }
        private string _CounterNo { get; set; }
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private string FiscalYear { get; set; }
        private string InterBranchLinking { get; set; }
        private string Budget { get; set; }
        private string DenoStatus { get; set; }
        private string CashStatus { get; set; }
        private string IbLSerial { get; set; }
        private int serial { get; set; }
        private string groupNo_or_rdNo { get; set; }
        private string accountType { get; set; }
        public string cashType;
        private IPFMDAO00028 CLedgerDAO { get; set; }
      
        private ITLMDAO00018 loansDAO;
        public ITLMDAO00018 LoansDAO
        {
            set { this.loansDAO = value; }
            get { return this.loansDAO; }
        }

        private IPFMDAO00017 caofDAO;
        public IPFMDAO00017 CaofDAO
        {
            set { this.caofDAO = value; }
            get { return this.caofDAO; }
        }

        private IMNMDAO00012 legalIntDAO;
        public IMNMDAO00012 LegalIntDAO
        {
            set { this.legalIntDAO = value; }
            get { return this.legalIntDAO; }
        }

        //private IPFMDAO00054 oiDAO;
        //public IPFMDAO00054 OiDAO
        //{
        //    get { return this.oiDAO; }
        //    set { this.oiDAO = value; }
        //}
        private IMNMDAO00011 commitDAO;
        public IMNMDAO00011 CommitDAO
        {
            set { this.commitDAO = value; }
            get { return this.commitDAO; }
        }

        private IMNMDAO00017 liDAO;
        public IMNMDAO00017 LIDAO
        {
            set { this.liDAO = value; }
            get { return this.liDAO; }
        }

        private IMNMDAO00027 schargeDAO;
        public IMNMDAO00027 SChargeDAO
        {
            set { this.schargeDAO = value; }
            get { return this.schargeDAO; }
        }

        private IPFMDAO00054 tlfDAO;
        public IPFMDAO00054 TLFDAO
        {
            set { this.tlfDAO = value; }
            get { return this.tlfDAO; }
        }

        #endregion

        #region "Public Methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        public PFMDTO00001 GetCustomerByAccountNumber(string accountNo,DateTime todaydate)
        {
            if (this.IsAccountValid(accountNo))
            {
                PFMDTO00001 customerInformation = new PFMDTO00001();
                IList<PFMDTO00017> currentAccountList = this.CodeChecker.GetCAOFsByAccountNumber(accountNo);
                if (currentAccountList.Count > 0)
                {
                    if (this.IsValidCurrentAccount(accountNo,todaydate))
                    {
                        var customerId = (from value in currentAccountList

                                          where value.CustomerID != null
                                          select value.CustomerID).ToList();


                        customerInformation = this.CodeChecker.GetCustomerByCustomerId(customerId[0]);
                        customerInformation.AccountSign = currentAccountList[0].AccountSign;
                        customerInformation.CurrencyCode = currentAccountList[0].CurrencyCode;
                    }
                    return customerInformation;
                }
                else
                {
                    IList<PFMDTO00016> savingAccountList = this.CodeChecker.GetSAOFsByAccountNumber(accountNo);
                    if (savingAccountList.Count > 0)
                    {
                        var customerId = (from value in savingAccountList
                                          where value.Customer_Id != null
                                          select value.Customer_Id).ToList();

                        customerInformation = this.CodeChecker.GetCustomerByCustomerId(customerId[0]);
                        customerInformation.AccountSign = currentAccountList[0].AccountSign;
                        customerInformation.CurrencyCode = currentAccountList[0].CurrencyCode;
                    }
                    return customerInformation;

                }

            }
            return null;
        }

        /// <summary>
        /// check total amount is between currentbalance and Mininmum balance
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public bool IsValidTotalAmount(string accountNo, decimal totalAmount, string accountSign)
        {
            PFMDTO00028 cledgerInfo = this.CodeChecker.SelectCurrentAndMinimumBalanceByAccountNo(accountNo);
            if (cledgerInfo != null)
            {
                decimal balance = cledgerInfo.CurrentBal - cledgerInfo.MinimumBalance;
                if (totalAmount < balance)
                {
                    return true;
                }
                else
                {
                    string linkaccountNo = this.CodeChecker.GetLinkAccountNo(accountNo, accountSign);
                    if (linkaccountNo != string.Empty)
                    {
                        PFMDTO00028 linkaccountInfo = this.CodeChecker.SelectCurrentAndMinimumBalanceByAccountNo(linkaccountNo);
                        decimal linkbalance = linkaccountInfo.CurrentBal - linkaccountInfo.MinimumBalance;
                        string status = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.AtltStatus);
                        if (status == "0")
                        {
                            decimal leftbalance = totalAmount - (balance);

                            if (leftbalance < linkbalance)
                                return true;
                            else
                                return false;
                        }
                        else if (status == "1")
                        {
                            if (totalAmount < linkbalance)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        public bool IsValidChequeNo(string accountNo, string chequeNo, string branchCode)
        {
            if (this.CodeChecker.IsValidChequeBookIssueNoForAccountClose(accountNo, chequeNo, branchCode))

                return true;
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }
        }

        public bool HasSavingAccountTransaction(string accountNo, int userid)
        {
            if (this.SavingAccountCheck.HasSavingAccountTransaction(accountNo, userid))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.SavingAccountCheck.ServiceResult.MessageCode;
                return true;
            }
            return false;
        }


        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00054> Save(TLMDTO00054 remit, IList<TLMDTO00054> drawing)
        {
            TLMORM00017 RD = new TLMORM00017();
            this._CounterNo = remit.CounterNo;
            try
            {
                this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", 
                                                                                    new object[] 
                                                                                    { 
                                                                                        CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), 
                                                                                        remit.SourceBranchCode, 
                                                                                        true 
                                                                                    });

                if (this.SettlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }
                this.Rate = CXCOM00010.Instance.GetExchangeRate(remit.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                if (this.Rate == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }

                this.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                this.FiscalYear = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.FixcalculationYear);
                this.InterBranchLinking = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.InterBranchLinking);
                // this.DenoStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DenoStatus);
                this.DenoStatus = null;
                this.CashStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);

                groupNo_or_rdNo = drawing.Count > 1 ? 
                                    this.CodeGenerator.GetGenerateCode("GroupVoucher", 
                                                                        string.Empty, 
                                                                        remit.CreatedUserId, 
                                                                        remit.SourceBranchCode, 
                                                                        new object[] 
                                                                        { 
                                                                            this.SettlementDate.Day.ToString().PadLeft(2, '0'), 
                                                                            this.SettlementDate.Month.ToString().PadLeft(2, '0'), 
                                                                            this.SettlementDate.Year.ToString().Substring(2) 
                                                                        }) : 
                                    this.CodeGenerator.GetGenerateCode("RDNo", 
                                                                        string.Empty, 
                                                                        drawing[0].CreatedUserId, 
                                                                        remit.SourceBranchCode);
                //groupNo_or_rdNo = drawing.Count > 1 ? this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, drawing[0].CreatedUserId, CurrentUserEntity.BranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) }) : this.CodeGenerator.GetGenerateCode("RDNo", string.Empty, drawing[0].CreatedUserId, CurrentUserEntity.BranchCode);
                decimal amountForCashDeno = 0;

                if (remit.IncomeType != null || !string.IsNullOrEmpty(remit.IncomeType))
                {
                    cashType = remit.IncomeType.Contains("CS") ?
                    String.IsNullOrEmpty(remit.AccountNo) ? "allcash" : "twocash" : string.Empty;
                }
                else
                {
                    cashType = remit.IncomeType;
                }
                for (int i = 0; i < drawing.Count; i++)
                {
                    TLMORM00017 remittancedrawing = this.GetRD(remit, drawing[i]);

                    #region "For CashDeno"
                    //if (cashType.Contains("allcash"))
                    //amountForCashDeno +=  drawing[i].RemitAmount;
                    //else if (cashType.Contains("twocash"))
                    //    amountForCashDeno += drawing[i].TelexCharges + drawing[i].Commission;
                    if (cashType != null || !string.IsNullOrEmpty(cashType))
                    {
                        if (cashType.Contains("allcash"))
                        {
                            if (remit.IsTakeIncome)
                                amountForCashDeno += drawing[i].RemitAmount + drawing[i].TelexCharges + drawing[i].Commission;
                            else
                                amountForCashDeno += drawing[i].RemitAmount;
                        }
                        else if (cashType.Contains("twocash"))
                        {
                            amountForCashDeno += drawing[i].TelexCharges + drawing[i].Commission;
                        }
                    }
                    else if (cashType == null || string.IsNullOrEmpty(cashType))
                    {
                        if (remit.IsTakeIncome)
                        {
                            remittancedrawing.IncomeDate = System.DateTime.Now;
                            amountForCashDeno += drawing[i].RemitAmount + drawing[i].TelexCharges + drawing[i].Commission;
                        }
                        else
                        {
                            remittancedrawing.IncomeDate = System.DateTime.Now;
                            amountForCashDeno += drawing[i].RemitAmount;
                        }
                    }
                    #endregion

                    TLMORM00017 registerno = this.RDDAO.Save(remittancedrawing);

                    drawing[i].RegisterNo = registerno.RegisterNo;
                    if (remit.TransactionStatus == "IBL")
                    {
                        this.RemitBrIBLDAO.UpdateIBL(remit.CurrencyCode, serial, drawing[i].Dbank, remit.SourceBranchCode, remit.CreatedUserId);
                    }
                    else
                    {
                        this.RemitBrDAO.TTSerialUpdate(remit.CurrencyCode, serial, drawing[i].Dbank, remit.SourceBranchCode, remit.CreatedUserId);
                    }

                    if (drawing.Count > 1)
                    {
                        TLMORM00009 depoDenoEntity = new TLMORM00009();
                        decimal zeroAmount = 0;
                        depoDenoEntity.GroupNo = this.groupNo_or_rdNo;
                        depoDenoEntity.AccountType = drawing[i].RegisterNo;
                        depoDenoEntity.Amount = drawing[i].ToAmount + drawing[i].Commission + drawing[i].TelexCharges;
                        depoDenoEntity.Reverse_Status = false;

                        depoDenoEntity.Income = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
                        depoDenoEntity.Communicationcharge = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
                        //depoDenoEntity.SourceBranchCode = remittancedrawing.Dbank;
                        depoDenoEntity.SourceBranchCode = remittancedrawing.SourceBranchCode;
                        depoDenoEntity.Currency = remittancedrawing.Currency;
                        depoDenoEntity.CreatedDate = DateTime.Now;
                        depoDenoEntity.CreatedUserId = remittancedrawing.CreatedUserId;
                        this.DepoDenoDAO.Save(depoDenoEntity);
                        drawing[i].GroupNo = this.groupNo_or_rdNo;
                    }
                }


                accountType = drawing.Count > 1 ? null : drawing[0].RegisterNo;
                // if income is cash, insert to cashdeno. 

                if (!String.IsNullOrEmpty(cashType))
                {
                    TLMORM00015 cashDeno = this.GetCashDeno(remit, amountForCashDeno);
                    this.CashDenoDAO.Save(cashDeno);
                    drawing[0].GroupNo = this.groupNo_or_rdNo;
                }

                if (!String.IsNullOrEmpty(remit.ChequeNo))
                {
                    PFMORM00020 ucheck = this.GetUCheck(remit);
                    this.UCheckDAO.Save(ucheck);
                }

                return drawing;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"D:\Update.txt", ex.Message + ex.StackTrace.ToString());
                //System.IO.File.WriteAllText(@"D:\LogFile.txt",ex.Message);

                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public void Save_DrawingPrinting(IList<TLMDTO00021> drawingPrintingDtoList)
        {
            try
            {
                foreach (TLMDTO00021 drawingPrintingDto in drawingPrintingDtoList)
                {
                    this.DrawingPrintingDAO.Save(this.GetDrawingPrinting(drawingPrintingDto));
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }

        #endregion

        #region"Private Method"
        private bool IsAccountValid(string accountNo)
        {

            // Check Freeze Account No
            if (this.CodeChecker.IsFreezeAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }

            //Check Fixed Account No
            if (this.IsFixedAccount(accountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
                return false;
            }


            return true;

        }

        public PFMDTO00002 CloseAccountValue(string accountNo, bool isIncome)
        {
            PFMDTO00002 closebalancedto = new PFMDTO00002();
            if (isIncome)
            {
                // Check saving & current account no is already closed or not.
                if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    return null;
                }
                else
                {
                    return closebalancedto;

                }
            }
            else
            {
                if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                {
                    //select CloseBalance from Close Bal
                    closebalancedto = this.CloseBalanceDAO.SelectCloseBalanceByAccountNo(accountNo);
                    if (closebalancedto == null)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00044;
                        return null;
                    }
                    else
                    {
                        return closebalancedto;

                    }
                }
            }

            return closebalancedto;
        }

        private bool IsFixedAccount(string accountNo)
        {
            IList<PFMDTO00021> fixedaccount = this.CodeChecker.GetFAOFsByAccountNumber(accountNo);
            if (fixedaccount.Count > 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00055;//wrong Message;
                return true;
            }
            return false;

        }

        private bool IsValidCurrentAccount(string accountNo,DateTime todaydate)
        {
            // Check Loan Account No
            if (this.CodeChecker.HasLoanAccount(accountNo))//need to check message 
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }

            //Check Expired Loan Account No
            if (this.CodeChecker.IsExpiredLoansAccount(accountNo,todaydate))// no hql //need to check message 
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }

            //Check Legal Case Account No
            if (this.CodeChecker.HasLegalCaseAccount(accountNo))// no hql //need to check message 
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }



            return true;
        }

        public CXDTO00009 AmountInformationChecking(string accountno, decimal amount, bool isVIP)
        {
            string messageNo = string.Empty;
            bool isLink = false;

            //Check Amount
            if (!this.CodeChecker.CheckAmount(accountno, amount, true, isVIP, true, ref isLink, ref messageNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return new CXDTO00009(messageNo, isLink);
            }
            return new CXDTO00009(messageNo, isLink);
        }

        #endregion

        private string GetRegisterNo(   string currencyCode, 
                                        string transactionstatus, 
                                        string drawerbank, 
                                        int userid, 
                                        string sourceBranch)
        {
            string registerno = string.Empty;


            switch (transactionstatus)
            {
                case "IBL":
                    string ibl = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.InterBranchLinkingTransfer);
                    decimal remitbriblserial = this.RemitBrIBLDAO.SelectIblSerialByDrawerBankAndCurrencyCode(drawerbank, sourceBranch, currencyCode);
                    this.serial = Convert.ToInt32(remitbriblserial) + 1;
                    //registerno = this.CodeGenerator.GetGenerateCode("DrawingRegisterNo", string.Empty, userid, CurrentUserEntity.BranchCode, new object[] { FiscalYear, drawerbank, ibl});
                    registerno = this.CodeGenerator.GetGenerateCode("DrawingRegisterNo", 
                                                                    string.Empty, 
                                                                    userid, 
                                                                    sourceBranch, 
                                                                    new object[] 
                                                                    { 
                                                                        FiscalYear, 
                                                                        drawerbank, 
                                                                        ibl 
                                                                    });
                    break;

                case "IBS":
                    string ibs = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.TelaxTransfer);
                    decimal remitbr = this.RemitBrDAO.SelectTTSerialByDrawerBankAndSourceBrachCode(drawerbank, sourceBranch, currencyCode);
                    this.serial = Convert.ToInt32(remitbr) + 1;
                    //registerno = this.CodeGenerator.GetGenerateCode("DrawingRegisterNoIBS", string.Empty, userid, CurrentUserEntity.BranchCode, new object[] { FiscalYear, drawerbank, ibs });
                    registerno = this.CodeGenerator.GetGenerateCode("DrawingRegisterNoIBS", 
                                                                    string.Empty, 
                                                                    userid, 
                                                                    sourceBranch, 
                                                                    new object[] 
                                                                    { 
                                                                        FiscalYear, drawerbank, ibs 
                                                                    });

                    break;
            }
            return registerno;

        }

        #region"DTO From ORM"

        public TLMORM00017 GetRD(TLMDTO00054 remit, TLMDTO00054 drawing)
        {
            TLMORM00017 remitDrawing = new TLMORM00017();
            remitDrawing.UniqueId = string.Empty;
            remitDrawing.DrawingNo = this.CodeGenerator.GetGenerateCode("drawingNo", 
                                                                        string.Empty, 
                                                                        remit.CreatedUserId, 
                                                                        remit.SourceBranchCode, 
                                                                        new object[] { });
            remitDrawing.Dbank = drawing.Dbank;
            remitDrawing.RegisterNo = this.GetRegisterNo(remit.CurrencyCode, 
                                                            remit.TransactionStatus, 
                                                            remitDrawing.Dbank, 
                                                            remit.CreatedUserId, 
                                                            remit.SourceBranchCode);
            remitDrawing.Br_Alias = drawing.BranchAlias;
            remitDrawing.Type = (remit.TransactionStatus.Contains("IBL")) ? 
                                    CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.InterBranchLinking) : 
                                    CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OtherBankLinking);
            remitDrawing.AccountNo = remit.AccountNo;
            remitDrawing.Name = remit.Name;
            remitDrawing.Address = remit.Address;
            remitDrawing.NRC = remit.NRC;
            remitDrawing.CheckNo = remit.ChequeNo;
            remitDrawing.ToAccountNo = drawing.ToAccountNo;
            remitDrawing.ToName = drawing.ToName;
            remitDrawing.ToAddress = drawing.ToAddress;
            remitDrawing.ToNRC = drawing.ToNRC;
            //remitDrawing.ToPhoneNo = drawing.ToPhoneNo;
            //remitDrawing.Amount = drawing.ToAmount;

            //For solve Drawing,Encash different amount.
            if (remit.IsTakeIncome)
            {
                remitDrawing.Amount = drawing.RemitAmount;
            }
            else
            {
                remitDrawing.Amount = drawing.ToAmount;
            }
            remitDrawing.TlxCharges = drawing.TelexCharges;
            remitDrawing.Commission = drawing.Commission;
            remitDrawing.DateTime = DateTime.Now;
            remitDrawing.RDType = remit.RDType;
            remitDrawing.IncomeType = remit.IncomeType;
            remitDrawing.AccountSign = remit.AccountSign;
            remitDrawing.UserNo = remit.ToName;
            remitDrawing.Budget = this.Budget;
            remitDrawing.Deno_Status = this.DenoStatus;
            remitDrawing.PhoneNo = remit.PhoneNo;
            remitDrawing.ToPhoneNo = drawing.ToPhoneNo;
            remitDrawing.Narration = remit.Narration;
            remitDrawing.SourceBranchCode = remit.SourceBranchCode;
            remitDrawing.Currency = remit.CurrencyCode;
            remitDrawing.Channel = this.Channel;
            remitDrawing.SettlementDate = this.SettlementDate;
            remitDrawing.CreatedUserId = remit.CreatedUserId;
            remitDrawing.CreatedDate = DateTime.Now;
            remitDrawing.TestKey = drawing.TestKey;

            return remitDrawing;
        }
        /*Modified by HWH.*/
        private TLMORM00015 GetCashDeno(TLMDTO00054 remit, decimal amount)
        {
            TLMORM00015 cashDeno = new TLMORM00015();
            cashDeno.TlfEntryNo = this.groupNo_or_rdNo;
            cashDeno.DenoEntryNo = string.Empty;
            cashDeno.AccountType = this.accountType;
            cashDeno.FromType = string.Empty;
            cashDeno.BranchCode = string.Empty;
            cashDeno.ReceiptNo = string.Empty;
            cashDeno.AdjustAmount = remit.AdjustAmount;
            cashDeno.Amount = amount;
            // cashDeno.CashDate = DateTime.Now;
            //cashDeno.DenoDetail = denostring.DenoString;           
            // cashDeno.DenoRefundDetail = denostring.RefundString;
            cashDeno.UserNo = remit.ToName;
            cashDeno.CounterNo = this._CounterNo;
            cashDeno.Status = this.CashStatus;
            cashDeno.Reverse = false;
            cashDeno.SourceBranchCode = remit.SourceBranchCode;
            cashDeno.Currency = remit.CurrencyCode;
            // cashDeno.DenoRate = denostring.DenoRateString;
            // cashDeno.DenoRefundRate = denostring.RefundRateString;
            //cashDeno.SettlementDate = this.SettlementDate;
            cashDeno.SettlementDate = null;
            //cashDeno.Rate = this.Rate;
            cashDeno.CreatedUserId = remit.CreatedUserId;
            cashDeno.CreatedDate = DateTime.Now;
            cashDeno.Active = true;

            return cashDeno;
        }

        public TLMORM00009 GetDepoDeno(TLMDTO00054 remit)
        {
            TLMORM00009 depodeno = new TLMORM00009();
         //   decimal zeroAmount = 0;
            depodeno.SourceBranchCode = remit.SourceBranchCode;
            depodeno.Currency = remit.CurrencyCode;
            depodeno.CreatedUserId = remit.CreatedUserId;
            depodeno.CreatedDate = remit.CreatedDate;
        //    depodeno.Income = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
        //    depodeno.Communicationcharge = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            return depodeno;

        }

        public PFMORM00020 GetUCheck(TLMDTO00054 remit)
        {
            PFMORM00020 ucheck = new PFMORM00020();
            ucheck.ChequeNo = remit.ChequeNo;
            ucheck.AccountNo = remit.AccountNo;
            ucheck.AccountSignature = remit.AccountSign;
            ucheck.Channel = "CBS";
            ucheck.DATE_TIME = DateTime.Now;
            ucheck.USERNO = remit.CreatedUserId.ToString();
            ucheck.SourceBranchCode = remit.SourceBranchCode;
            ucheck.CreatedUserId = remit.CreatedUserId;
            ucheck.CreatedDate = remit.CreatedDate;
            ucheck.Active = true;

            return ucheck;
        }

        private TLMORM00021 GetDrawingPrinting(TLMDTO00021 drawingPrintingDto)
        {
            TLMORM00021 DrawingPrinting = new TLMORM00021();

            DrawingPrinting.Id = this.DrawingPrintingDAO.SelectMaxId() + 1;
            DrawingPrinting.RegisterNo = drawingPrintingDto.RegisterNo;
            DrawingPrinting.RAmount = drawingPrintingDto.RAmount;
            DrawingPrinting.WorkStation = drawingPrintingDto.WorkStation;
            DrawingPrinting.SourceBranchCode = drawingPrintingDto.SourceBranchCode;
            DrawingPrinting.CreatedDate = drawingPrintingDto.CreatedDate;
            DrawingPrinting.CreatedUserId = drawingPrintingDto.CreatedUserId;
            return DrawingPrinting;
        }

        #endregion


        public TLMDTO00018 SelectByLoanNo(string loanNo, string sourceBr)
        {
            TLMDTO00018 loanList = new TLMDTO00018();
            try
            {
                 loanList = this.LoansDAO.SelectByLoanNo(loanNo, sourceBr);
                if (loanList != null)
                {
                    caofList = SelectCAOFData(loanList.AccountNo);
                    if (caofList.Count == 0)
                        throw new Exception(CXMessage.ME00054);     //AccountNo not found in Cledger Table.
                    else
                        loanList.CaofList = caofList;
                    legalIntList = SelectlegalIntData(loanList.Lno);
                    commitList = SelectCommitFeeByLoanNo(loanList.AccountNo, loanList.Lno);
                    liList = SelectLIByLoanNo(loanList.AccountNo, loanList.Lno);
                    schargeList = SelectSChargeByLoanNo(loanList.AccountNo, loanList.Lno);
                    if (!legalIntList.Equals(null) && !legalIntList.Count.Equals(0))
                    {
                        loanList.OutstandingInt = legalIntList.Where(x => x.Type == "INTEREST" && x.LNo == loanList.Lno).Sum(x => x.Amount);
                        loanList.OutstandingChg = legalIntList.Where(x => x.Type == "CHARGES" && x.LNo == loanList.Lno).Sum(x => x.Amount);
                        loanList.PenlityFees = loanList.OutstandingInt * 13 / 100 / 366 * (DateTime.Now.Subtract(legalIntList[0].Date_Time).Days);
                        loanList.SAmount = Convert.ToDecimal("0") +         //Where 0 for ODInt
                                             Convert.ToDecimal("0") +         //Where 0 for LoanInt                                                            
                                             loanList.OutstandingInt +
                                             loanList.OutstandingChg +
                                             loanList.PenlityFees +
                                             loanList.ServiceCharges +
                                             loanList.CommitmentFees;
                    }
                    else
                    {
                        loanList.OutstandingChg = 0;
                        loanList.OutstandingInt = 0;
                        loanList.PenlityFees = 0;
                        loanList.ServiceCharges = 0;
                    }

                    if (!commitList.Equals(null) && !commitList.Count.Equals(0))
                    {
                        loanList.CommitmentFees = commitList.Where(x => x.LNo == loanList.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12);
                    }
                    else
                    {
                        loanList.CommitmentFees = 0;
                    }

                    if (!liList.Equals(null) && !liList.Count.Equals(0))
                    {
                        loanList.Interest = liList.Where(x => x.LNo == loanList.Lno).Sum(x => Convert.ToDecimal(x.Q1 + x.Q2 + x.Q3 + x.Q4));
                    }
                    else
                    {
                        loanList.Interest = 0;
                    }

                    if (!schargeList.Equals(null) && !schargeList.Count.Equals(0))
                    {
                        loanList.ServiceCharges = schargeList.Where(x => x.LNo == loanList.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12);
                    }
                    else
                    {
                        loanList.ServiceCharges = 0;
                    }
                }
                return loanList;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.ToString(); 
            }
            return loanList;
        }

        public IList<PFMDTO00017> SelectCAOFData(string acctNo)
        {
            IList<PFMDTO00017> caofList = this.CaofDAO.SelectCAOFData(acctNo);

            return caofList;
        }

        public IList<MNMDTO00012> SelectlegalIntData(string loanNo)
        {
            IList<MNMDTO00012> legalIntList = this.LegalIntDAO.SelectByLoanNo(loanNo);

            return legalIntList;
        }

        public IList<MNMDTO00011> SelectCommitFeeByLoanNo(string accountNo, string loanNo)
        {
            IList<MNMDTO00011> commitList = this.CommitDAO.SelectByAccountNo(accountNo);

           return commitList;
        }

        public IList<LOMDTO00021> SelectLIByLoanNo(string accountNo, string loanNo)
        {
            IList<LOMDTO00021> liList = this.LIDAO.SelectByLoanNo(accountNo, loanNo);

            return liList;
        }

        public IList<MNMDTO00027> SelectSChargeByLoanNo(string accountNo, string loanNo)
        {
            IList<MNMDTO00027> schargeList = this.SChargeDAO.SelectByLoanNo(accountNo, loanNo);
            return schargeList;
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveCloseAC(TLMDTO00018 loan,
                                    IList<PFMDTO00017> caof,
                                    IList<MNMDTO00012> legal,
                                    IList<MNMDTO00011> commit,
                                    IList<LOMDTO00021> li,
                                    IList<MNMDTO00027> scharge,
                                    string cur,
                                    DateTime SettlementDate,
                                    ChargeOfAccountDTO CoaACName,
                                    string creditVoucher,
                                    string debitVoucher,
                                    string creditTranCode,
                                    string debitTranCode,
                                    bool isOverDraft,
                                    decimal reqAmount
                                )
        {
            try
            {
                if (isOverDraft)
                {
                    string messageNo = string.Empty;
                    bool isLink = false;
                    if (this.LMT9900Dao.HasInLMT9900(loan.Lno, loan.SourceBranchCode))
                        tlfDAO.UpdateCloseDateForLMT9900(loan.Lno);
                    tlfDAO.UpdateCloseDateForOI(loan.Lno);
                    if (!this.CodeChecker.CheckAmount(caof[0].CledgerAccountNo, reqAmount, true, false, true, ref isLink, ref messageNo))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = messageNo;
                        return;
                    }
                }
                else 
                
                {

                    tlfDAO.UpdateCloseDateForLI(loan.Lno);
                    tlfDAO.UpdateCloseDateForLMT9900(loan.Lno);
                }
                if (!tlfDAO.UpdateCloseDateByLoanType(loan.Loans_Type, loan.Lno) ||
                    !tlfDAO.UpdateCloseDateForLoan(loan.Lno) ||
               
                   // !tlfDAO.UpdateCloseDateForLI(loan.Lno) ||
                   // !tlfDAO.UpdateCloseDateForLMT9900(loan.Lno) ||
                    !CLedgerDAO.UpdateLoansCountForCledger(loan.SourceBranchCode,loan.AccountNo,loan.UpdatedUserId.Value,loan.UpdatedDate.Value))
                {
                    throw new Exception(CXMessage.ME90001);   //Updating Error.
                }

                IList<PFMORM00054> tlfORMList = GetTLFORM(loan,
                                                            caof,
                                                            legal,
                                                            commit,
                                                            li,
                                                            scharge,
                                                            cur,
                                                            SettlementDate,
                                                            CoaACName,
                                                            creditVoucher,
                                                            debitVoucher,
                                                            creditTranCode,
                                                            debitTranCode
                                                            );
                for (int i = 0; i < tlfORMList.Count; i++)
                {
                    tlfDAO.Save(tlfORMList[i]);
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = CXMessage.MI90001; //Saving Successful

            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MI00025; //No Data to Save
            }
        }

        public IList<PFMORM00054> GetTLFORM(TLMDTO00018 loan,
                                                IList<PFMDTO00017> caof,
                                                IList<MNMDTO00012> legal,
                                                IList<MNMDTO00011> commit,
                                                IList<LOMDTO00021> li,
                                                IList<MNMDTO00027> scharge,
                                                string cur,
                                                DateTime SettlementDate,
                                                ChargeOfAccountDTO CoaACName,
                                                string creditVoucher,
                                                string debitVoucher,
                                                string creditTranCode,
                                                string debitTranCode
                                            )
        {
            IList<PFMORM00054> tlfORMList = new List<PFMORM00054>();
            for (int i = 0; i < caof.Count; i++)
            {
                PFMORM00054 tlfORM = new PFMORM00054();
                tlfORM.Id = this.tlfDAO.SelectMaxId() + 1;
                tlfORM.Acode = CoaACName.ACode;
                tlfORM.Eno = this.GetEno(CurrentUserEntity.CurrentUserID, caof[i].SourceBranchCode);
                tlfORM.AccountNo = caof[i].CledgerAccountNo;
                tlfORM.Amount = loan.SAmount ?? 0;
                tlfORM.HomeAmount = loan.SAmount ?? 0;
                tlfORM.HomeAmt = loan.SAmount ?? 0;
                tlfORM.LocalAmount = loan.SAmount ?? 0;
                tlfORM.LocalAmt = loan.SAmount ?? 0;
                tlfORM.Description = CoaACName.ACName;
                tlfORM.Narration = "Loans Close : " + caof[i].CledgerAccountNo;
                tlfORM.CreatedUserId = CurrentUserEntity.CurrentUserID;
                tlfORM.DateTime = DateTime.Now;

                if (i == 0)
                {
                    tlfORM.Status = creditVoucher;
                    tlfORM.TransactionCode = creditTranCode;
                }
                else
                {
                    tlfORM.Status = debitVoucher;
                    tlfORM.TransactionCode = debitTranCode;
                }

                tlfORM.AccountSign = caof[i].AccountSign;
                tlfORM.UserNo = caof[i].USERNO;
                tlfORM.SourceCurrency = cur;
                tlfORM.Rate = 1;
                tlfORM.SourceBranchCode = caof[i].SourceBranchCode;
                tlfORM.SettlementDate = SettlementDate;
                tlfORM.Channel = "CBS";
                tlfORM.ReferenceType = null;

                tlfORMList.Add(tlfORM);
            }

            return tlfORMList;
        }

        public string GetEno(int CreatedUserId, string SourceBranchCode)
        {
            try
            {
                string payInSlipNo = this.CodeGenerator.GetGenerateCode("SavingCloseVoucher",
                                                                        string.Empty,
                                                                        CreatedUserId,
                                                                        SourceBranchCode,
                                                                        new object[] 
                                                                        { 
                                                                            DateTime.Now.Day.ToString().PadLeft(2, '0'), 
                                                                            DateTime.Now.Month.ToString().PadLeft(2, '0'), 
                                                                            DateTime.Now.Year.ToString().Substring(2) 
                                                                        });
                return payInSlipNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}