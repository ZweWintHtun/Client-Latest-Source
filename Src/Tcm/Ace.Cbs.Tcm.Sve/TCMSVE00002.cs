//----------------------------------------------------------------------
// <copyright file="TCMSVE00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// PO Refund By Transfer Service
    /// </summary>
    public class TCMSVE00002 : BaseService, ITCMSVE00002
    {
        #region DAO
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITLMDAO00016 PODAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public ITLMDAO00005 TrantypeDAO { get; set; }
        public ICXSVE00003 PrintingDAO { get; set; }

        private ICXDAO00014 bLFDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.bLFDAO; }
            set { this.bLFDAO = value; }
        }
        #endregion

        # region Helper Method

        //Added by ZMS For Budget end Flexible 2018/09/21
        public string GetBudYear(int service, DateTime reqDate, string sourceBr)
        {
            string Return = string.Empty;
            string budYear = BLFDAO.GetBudget_Month_Year_Quarter(service, reqDate, sourceBr, Return);  // For 2018/09/17 => active budget from BLF as 2018/2019
            return budYear;
        }

        public TLMDTO00016 CheckPOAndBudget(string pono, string budgetyear,string sourceBr)
        {
            TLMDTO00016 podto = this.PODAO.SelectPOByPONoandBudgetYear(pono, budgetyear, sourceBr);

            if (podto == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00219;//"P.O No. not found."
                return null;
            }

            else
            {
                if (podto.IDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00143;//"This P.O No. {0}  is already received." 
                    return null;
                }
            }

            return podto;
        }

        public IList<PFMDTO00001> CheckCusomer(string accountno, string sourceBr)
        {
            #region Check Close Account
            if (this.CodeChecker.IsClosedAccountForCLedger(accountno))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            #endregion

            #region  Check Freesze Account No
            if (this.CodeChecker.IsFreezeAccount(accountno))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }
            #endregion

            #region Check Source Branch
            PFMDTO00028 account = this.CledgerDAO.SelectACSignByAccountNo(accountno);
            if (account == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00046";    //Invalid Account No.
                return null;
            }
            if (account.SourceBranchCode != sourceBr)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00091"; //Invalid Account No for Branch {0}.
                return null;
            }
            #endregion

            #region GetCustomerInfomationByAccountNo
            IList<PFMDTO00001> customerLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(accountno, false));

            #endregion

            return customerLists;

        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveDebitTLF(TLMDTO00016 po)
        {

            try
            {

                PFMDTO00075 rate = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { po.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true, po.Currency, true });
                System.Nullable<DateTime> settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate",
                    new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), po.SourceBranchCode, true });
                po.SettlementDate = settlementdate;
                string voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, po.CreatedUserId, po.SourceBranchCode, new object[] { settlementdate.Value.Day.ToString().PadLeft(2, '0'), settlementdate.Value.Month.ToString().PadLeft(2, '0'), settlementdate.Value.Year.ToString().Substring(2) });

                #region Debit

                PFMORM00054 tlf = new PFMORM00054();

                tlf.Eno = voucherNo;
                tlf.AccountNo = po.ACode;
                tlf.Acode = po.ACode;
                tlf.Amount = po.Amount;
                tlf.HomeAmount = po.Amount * rate.Rate;
                tlf.HomeAmt = tlf.HomeAmount * rate.Rate;
                tlf.HomeOAmt = 0;
                tlf.LocalAmount = po.Amount;
                tlf.LocalAmt = po.Amount;
                tlf.LocalOAmt = 0;
                tlf.SourceCurrency = po.Currency;
                tlf.PaymentOrderNo = po.PONo;
                ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { po.ACode, po.SourceBranchCode, true });
                tlf.Description = coa.AccountName;
                //tlf.Acode = po.ACode;             
                tlf.Narration = "Ref: " + po.ACode + "Cr: " + po.AccountNo;
                tlf.DateTime = DateTime.Now;
                tlf.TransactionCode = "PORDRTR";
                TLMDTO00005 trantype = this.TrantypeDAO.SelectByTranCode(tlf.TransactionCode);
                tlf.Status = trantype.Status;
                tlf.AccountSign = string.Empty;
                tlf.DeliverReturn = false;
                tlf.SourceBranchCode = po.SourceBranchCode;
                tlf.Rate = rate.Rate;
                tlf.SettlementDate = settlementdate;
                tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                tlf.ReferenceVoucherNo = po.PONo;
                tlf.ReferenceType = "PO";
                tlf.UserNo = po.UserNo;
             //   po.UserNo = CurrentUserEntity.CurrentUserID.ToString();
                tlf.CreatedUserId = po.CreatedUserId;
                tlf.CreatedDate = DateTime.Now;
                tlf.Id = this.TLFDAO.SelectMaxId() + 1;
                this.TLFDAO.Save(tlf);
                #endregion

                return voucherNo;

            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;

                throw new Exception(ex.Message);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveCreditTLF(TLMDTO00016 po)
        {

            try
            {
              

                PFMDTO00075 rate = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { po.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true, po.Currency,true });
                System.Nullable<DateTime> settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), po.SourceBranchCode, true });
                po.SettlementDate = settlementdate;
                //  string voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, po.CreatedUserId, po.SourceBranchCode, new object[] { settlementdate.Value.Day.ToString().PadLeft(2, '0'), settlementdate.Value.Month.ToString().PadLeft(2, '0'), settlementdate.Value.Year.ToString().Substring(2) });

                #region Credit
                PFMORM00054 tlf = new PFMORM00054();

                tlf.Eno = po.VoucherNo;
                tlf.AccountNo = po.ToAccountNo;
                tlf.Acode = po.CreditAcode;
                tlf.Amount = po.Amount;               
                tlf.HomeAmount = po.Amount * rate.Rate;
                tlf.HomeAmt = tlf.HomeAmount * rate.Rate;
                tlf.Rate = rate.Rate;
                tlf.HomeOAmt = 0;
                tlf.LocalAmount = po.Amount;
                tlf.LocalAmt = po.Amount;
                tlf.LocalOAmt = 0;
                tlf.SourceCurrency = po.Currency;
                tlf.PaymentOrderNo = po.PONo;
                tlf.Description = po.CustomerName;
                tlf.Narration = "Dr: PO Ref: " + po.PONo;
                tlf.DateTime = DateTime.Now;
                tlf.TransactionCode = "PORCRTR";
                TLMDTO00005 trantypedto = this.TrantypeDAO.SelectByTranCode(tlf.TransactionCode);
                tlf.Status = trantypedto.Status;
                tlf.AccountSign = po.AcSign;
                tlf.DeliverReturn = false;
                tlf.SourceBranchCode = po.SourceBranchCode;
                tlf.SettlementDate = settlementdate;
                tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                tlf.ReferenceVoucherNo = po.PONo;
                tlf.ReferenceType = "PO";
                tlf.UserNo = po.UserNo;
                tlf.CreatedUserId = po.CreatedUserId;
                tlf.CreatedDate = DateTime.Now;
                tlf.Id = this.TLFDAO.SelectMaxId() + 1;
                this.TLFDAO.Save(tlf);
                #endregion

            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;

                throw new Exception(ex.Message);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void SavePrnFile(TLMDTO00016 po)
        {
            try
            {

                PFMDTO00028 cledger = this.CledgerDAO.SelectMinimumBalanceByAccountNo(po.ToAccountNo);
                TLMDTO00005 trantypedto = this.TrantypeDAO.SelectByTranCode("PORCRTR");
                PFMDTO00043 prnfile = new PFMDTO00043();
                prnfile.AccountNo = po.ToAccountNo;
                prnfile.DATE_TIME = DateTime.Now;
                prnfile.Credit = po.Amount;
                prnfile.Balance = cledger.CurrentBal;
                prnfile.Reference = trantypedto.PBReference;
                prnfile.UserNo = Convert.ToString(po.CreatedUserId);
                prnfile.SourceBranchCode = po.SourceBranchCode;
                prnfile.CurrencyCode = po.Currency;
                prnfile.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                prnfile.CreatedUserId = po.CreatedUserId;
                prnfile.CreatedDate = DateTime.Now;

                this.PrintingDAO.PRNFile_Save(prnfile);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception(ex.Message);
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateCledger(TLMDTO00016 po)
        {
            try
            {
                PFMDTO00028 cledger = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(po.ToAccountNo);
                po.UpdatedUserId = po.CreatedUserId;
                string updateduserno = Convert.ToString(po.CreatedUserId);

                this.CledgerDAO.UpdateCurrentBalance(po.ToAccountNo, cledger.CurrentBal + po.Amount, cledger.TransactionCount + 1, po.CreatedUserId, updateduserno);
            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;

                throw new Exception(ex.Message);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdatePO(TLMDTO00016 po)
        {
            try
            {
                po.UpdatedUserId = po.CreatedUserId;
                this.PODAO.UpdatePORefundByPONoAndBudgetYear(DateTime.Now, po.SettlementDate.Value, "J", po.Budget, po.PONo, po.ToAccountNo,po.UpdatedUserId.Value);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public string Save(TLMDTO00016 po)
        {
            try
            {
                System.Nullable<DateTime> settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), po.SourceBranchCode, true });
                po.SettlementDate = settlementdate;

                if (!po.IsCOAAccount)
                { this.UpdateCledger(po); }

                this.UpdatePO(po);

                po.VoucherNo = this.SaveDebitTLF(po);
                this.SaveCreditTLF(po);

                if (po.AcSign.StartsWith(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign)))
                {
                    this.SavePrnFile(po);
                }
                return po.VoucherNo;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public IList<PFMDTO00043> GetPrint(string accountno)
        {
             #region Select Prnfile

            IList<PFMDTO00043> prnFileDTOLsit = this.PrintingDAO.PRNFile_SelecByAccountNo(accountno);
                        prnFileDTOLsit[0].LedgerPrintLineNo = prnFileDTOLsit.Count;
                        prnFileDTOLsit[0].IsCledgerAccountStatus = true;                    
                        return prnFileDTOLsit;                  
                    #endregion
        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateAndDeleteByAccountNo(string accountNo, IList<PFMDTO00043> prnFileList,  int ledgerPrintLineNo, int updatedUserId)
        {
           
            try
            {
                this.CledgerDAO.UpdatePrintLine(accountNo, ledgerPrintLineNo,updatedUserId);
                this.PrintingDAO.DeletePrnFileByAccountNo(accountNo);
                return true;
            }
            catch
            {
           
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00062;
                throw new Exception(this.ServiceResult.MessageCode);
            }

            
        }

        public PFMDTO00028 GetAccountBalance(string account)
        {
            return this.CledgerDAO.SelectACSignByAccountNo(account);
        }

        #endregion
    }
}
