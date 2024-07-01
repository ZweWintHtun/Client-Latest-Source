//----------------------------------------------------------------------
// <copyright file="TLMSVE00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00019:BaseService,ITLMSVE00019
   {
       #region Properties
       public ITLMDAO00017 RDDAO { get; set; }
       public ICXSVE00006 CodeChecker { get; set; }
       public ICXSVE00002 CodeGenerator { get; set; }
       public IPFMDAO00054 TLFDAO { get; set; }
       public ITLMDAO00005 TranTypeDAO { get; set; }
       public ITLMDAO00015 CashDenoDAO { get; set; }
       
       public int remitStatus { get; set; }
       public string voucherNo { get; set; }
       public decimal rate { get; set; }
       public bool[] check { get; set; }
       public bool result { get; set; }
       public string referenceType { get; set; }
       public string tranCode { get; set; }
       public string status { get; set; }
       public TLMDTO00015 cashDenoData { get; set; }
       #endregion

       #region Methods
       public IList<TLMDTO00017> GetRegisterNoBySourceBranchCode(string sourceBranchCode, string type)
       {
           if (type == "IBL")
           {           
               return RDDAO.SelectAllRegisterNo(sourceBranchCode, type); 
           }
           else
           {
               return RDDAO.SelectAllRegisterNoForFX(sourceBranchCode, type); 
           }
       }

        [Transaction(TransactionPropagation.Required)]
       public TLMDTO00015 GetCashDenoData(string registerNo, string sourceBr)
       {
           try
           {
               cashDenoData = this.CashDenoDAO.SelectCashDenoInfoByACType(registerNo, sourceBr);
               if (cashDenoData == null)
               {
                   //**edited by ASDA***
                   IList<TLMDTO00015> cashDenoList = this.CashDenoDAO.GetDepoDenoAndCashDenoForDrawingVoucher(registerNo, sourceBr);
                   foreach (TLMDTO00015 cashDeno in cashDenoList)
                   {
                       if(string.IsNullOrEmpty(cashDeno.DenoEntryNo) || cashDeno.DenoEntryNo.StartsWith("I"))
                       {
                           cashDenoData = cashDeno; 
                       }
                   }
                   //**End-------------------
                   //cashDenoData = this.CashDenoDAO.GetDepoDenoAndCashDenoForDrawingVoucher(registerNo, sourceBr);
               }
              // this.ServiceResult.ErrorOccurred = cashDenoData == null  ?  true : false;
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = "MV00168"; //Invalid Register No.
           }
             return cashDenoData;
       }

       [Transaction(TransactionPropagation.Required)]
       public string SaveData(TLMDTO00017 drawingRemit)
       {
           try
           {
               drawingRemit.Type = "IBL";
               drawingRemit = this.GetNeedDataForTR(drawingRemit);
               CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.IBLRemit(drawingRemit));
               if (CXServiceWrapper.Instance.ServiceResult.ErrorOccurred)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                   return string.Empty;
               }
               else
               {
                   this.ServiceResult.ErrorOccurred = false;
                   this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
               }
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = ex.Message;
           }
           return voucherNo;
       }

       public int RemitStatusForIBL(string incomeType)
       {
           if (incomeType == "CS")
           {remitStatus = 1;}
           else if (incomeType == "TR")
           {remitStatus = 2;}
           else
           { remitStatus = 0; }
           return remitStatus;
       }

       public int RemitStatusForFX(string incomeType)
       {
           if (incomeType == "CS")
           { remitStatus = 1; }
           else if (incomeType == "TR")
           { remitStatus = 0; }
           else
           { remitStatus = 2; }
           return remitStatus;
       }

       public bool[] GetAccountNo(string accountNo,decimal amount,bool isVIP)
       {
           bool[] check = { false, false ,false};
           if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
               check[0] = false;
           }
           else
           {
               if (this.CodeChecker.IsFreezeAccount(accountNo))
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                   check[0] = false;
               }
               else
               {
                   if (this.CodeChecker.HasLoanAccount(accountNo))
                   {
                       this.ServiceResult.ErrorOccurred = true;
                       this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                       check[0] = false;
                   }
                   else
                   {
                       check[0] = true;
                       bool isLink = false;
                       string message = null;
                       if (accountNo.Length != 6)
                       {
                           this.CodeChecker.CheckAmount(accountNo, amount, true, isVIP, true, ref isLink, ref message);
                       }
                       if (!String.IsNullOrEmpty(message))
                       {
                           this.ServiceResult.ErrorOccurred = true;
                           this.ServiceResult.MessageCode = message;
                           check[1] = true;
                       }

                       if (isLink==true)
                       {
                           check[2] = true;
                       }
                   }
               }
           }
           return check;
       }

       [Transaction(TransactionPropagation.Required)]
       public string SaveDataForFX(TLMDTO00017 drawingRemit)
       {
           try
           {
               if (drawingRemit.RDType == "TR" & drawingRemit.IncomeType == "CS")//use sp,insert
               {
                   TLMDTO00017 drawingRemitTR = this.GetNeedDataForTR(drawingRemit);
                   CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.RemitVoucher(drawingRemitTR));

                   TLMDTO00017 drawingRemitCS = this.GetNeedDataForCS(drawingRemit);
                   this.SaveDataForCash(drawingRemitCS);

                   this.ServiceResult.ErrorOccurred = false;
                   this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
               }
               else if (drawingRemit.RDType == "TR")//use sp
               {
                   TLMDTO00017 drawingRemitTR = this.GetNeedDataForTR(drawingRemit);
                   CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.RemitVoucher(drawingRemitTR));

                   if (CXServiceWrapper.Instance.ServiceResult.ErrorOccurred)
                   {
                       this.ServiceResult.ErrorOccurred = true;
                       this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                       throw new Exception(this.ServiceResult.MessageCode);
                       //return string.Empty;
                   }
                   else
                   {
                       this.ServiceResult.ErrorOccurred = false;
                       this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
                   }
               }
               else if (drawingRemit.RDType == "CS")
               {
                   TLMDTO00017 drawingRemitCS = this.GetNeedDataForCS(drawingRemit);
                   this.SaveDataForCash(drawingRemitCS);
                 
                   this.ServiceResult.ErrorOccurred = false;
                   this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
               }
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = ex.Message;
               throw new Exception(this.ServiceResult.MessageCode);
           }
           return voucherNo;
       }

       private PFMORM00054 GetTLF(string eno, string acode, decimal amount, string narration, string transactionCode,string status, string currency, string sourceBranch, decimal rate, 
                                  DateTime settlementDate, string channel, int createdUserId, string registerNo,string referenceType)
       {
           PFMORM00054 tlf = new PFMORM00054();
           tlf.Id = this.TLFDAO.SelectMaxId() + 1;
           tlf.Eno = eno;
           tlf.AccountNo = acode;
           tlf.Amount = amount;
           tlf.Acode = acode;
           tlf.HomeAmt = tlf.Amount * rate;
           tlf.HomeOAmt = Convert.ToDecimal(0.00);
           tlf.HomeAmount = tlf.HomeAmt + tlf.HomeOAmt;
           tlf.LocalAmt = amount;
           tlf.LocalOAmt = Convert.ToDecimal(0.00);
           tlf.LocalAmount = tlf.LocalAmt + tlf.LocalOAmt;
           tlf.Description = this.GetCOA(tlf.Acode, sourceBranch);
           tlf.Narration = narration;//Drawing Remitt:
           tlf.CheckTime = DateTime.Now;
           tlf.DateTime = DateTime.Now;
           tlf.TransactionCode = transactionCode;//DREMITCS
           tlf.Status = status;//CCV
           tlf.UserNo = Convert.ToString(createdUserId);
           tlf.CurrencyCode = currency;
           tlf.SourceCurrency = currency;
           tlf.SourceBranchCode = sourceBranch;
           tlf.Rate = rate;
           tlf.SettlementDate = settlementDate;
           tlf.Channel = channel;
           tlf.CreatedDate = DateTime.Now;
           tlf.CreatedUserId = createdUserId;
           //tlf.DRegisterNo = registerNo;
           tlf.ReferenceVoucherNo = registerNo;
           tlf.ReferenceType = referenceType;
           tlf.Active = true;
           return tlf;
       }

       public string GetCOA(string code, string branch)
       {
           ChargeOfAccountDTO coa = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { code, branch, true });
           string accountName = coa.AccountName;
           return accountName;
       }

       public string GetTransactionStatus(string transactionCode)
       {
           TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(transactionCode);
           string status = transactionType.Status;
           return status;
       }


       public TLMDTO00017 GetNeedDataForTR(TLMDTO00017 drawingRemit)
       {
           DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), drawingRemit.SourceBranchCode ,true });
           string day = sys001.Day.ToString().PadLeft(2, '0');
           string month = sys001.Month.ToString().PadLeft(2, '0');
           string year = sys001.Year.ToString().Substring(2);
           rate = CXCOM00010.Instance.GetExchangeRate(drawingRemit.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
           if (drawingRemit.Type == "IBL")
           {
               voucherNo = CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, drawingRemit.CreatedUserId, drawingRemit.SourceBranchCode, new object[] { drawingRemit.SourceBranchCode });
               remitStatus = this.RemitStatusForIBL(drawingRemit.IncomeType);
           }
           else
           {
               voucherNo = CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, drawingRemit.CreatedUserId, drawingRemit.SourceBranchCode, new object[] { day, month, year });
               remitStatus = this.RemitStatusForFX(drawingRemit.IncomeType);
           }
           drawingRemit.VoucherNo = voucherNo;
           drawingRemit.Rate = rate;
           drawingRemit.RemitStatus = remitStatus;
           drawingRemit.SourceBranchCode = drawingRemit.SourceBranchCode;
           drawingRemit.CheckClose = false;
           drawingRemit.SettlementDate = sys001;
           drawingRemit.OverdraftAmount = 0;
           //if (drawingRemit.CheckLink == true & drawingRemit.Type!="IBL")//need check
           //{
           //    CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.AllUpdateRemit(drawingRemit));
           //}
           
           return drawingRemit;
       }

       public TLMDTO00017 GetNeedDataForCS(TLMDTO00017 drawingRemit)
       {
           referenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceDrawing);
           tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DrawingRemittanceCash);
           status = this.GetTransactionStatus(tranCode);

           DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), drawingRemit.SourceBranchCode,true });
           rate = CXCOM00010.Instance.GetExchangeRate(drawingRemit.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
           drawingRemit.Rate = rate;
           drawingRemit.SourceBranchCode = drawingRemit.SourceBranchCode;
           drawingRemit.SettlementDate = sys001;
           return drawingRemit;
       }

       public void SaveDataForCash(TLMDTO00017 drawingRemit)
       {
           if (drawingRemit.RDType == "CS")
           {
               voucherNo = CodeGenerator.GetGenerateCode("IBSVoucher", string.Empty, drawingRemit.CreatedUserId, drawingRemit.SourceBranchCode);
               PFMORM00054 tlf = this.GetTLF(voucherNo, drawingRemit.DrawingAccount, drawingRemit.DrawingAmount, "Drawing Remitt:", tranCode, status, drawingRemit.Currency,
                               drawingRemit.SourceBranchCode, drawingRemit.Rate, Convert.ToDateTime(drawingRemit.SettlementDate), drawingRemit.Channel, drawingRemit.CreatedUserId,
                               drawingRemit.RegisterNo, referenceType);
               this.TLFDAO.Save(tlf);
           }

           if (drawingRemit.IncomeType == "CS")
           {
               string IBSCommissionVoucher = CodeGenerator.GetGenerateCode("IBSCommissionVoucher", string.Empty, drawingRemit.CreatedUserId, drawingRemit.SourceBranchCode);
               PFMORM00054 tlfCommission = this.GetTLF(IBSCommissionVoucher, drawingRemit.IBSComAccount, drawingRemit.IBSComAmount, "D Remitt: Income", tranCode, status, drawingRemit.Currency,
                               drawingRemit.SourceBranchCode, drawingRemit.Rate, Convert.ToDateTime(drawingRemit.SettlementDate), drawingRemit.Channel, drawingRemit.CreatedUserId,
                               drawingRemit.RegisterNo, referenceType);
               this.TLFDAO.Save(tlfCommission);

               string IBSTelexVoucher = CodeGenerator.GetGenerateCode("IBSTelexVoucher", string.Empty, drawingRemit.CreatedUserId, drawingRemit.SourceBranchCode);
               PFMORM00054 tlfTelex = this.GetTLF(IBSTelexVoucher, drawingRemit.TelaxAccount, drawingRemit.TelaxAmount, "D Remitt: Telex Chg", tranCode, status, drawingRemit.Currency,
                               drawingRemit.SourceBranchCode, drawingRemit.Rate, Convert.ToDateTime(drawingRemit.SettlementDate), drawingRemit.Channel, drawingRemit.CreatedUserId,
                               drawingRemit.RegisterNo, referenceType);
               this.TLFDAO.Save(tlfTelex);
           }

           this.RDDAO.UpdateRDVoucher(DateTime.Now, DateTime.Now, Convert.ToDateTime(drawingRemit.SettlementDate), drawingRemit.RegisterNo, drawingRemit.SourceBranchCode, drawingRemit.CreatedUserId, DateTime.Now);
           this.TLFDAO.UpdateTlfByRefVno(drawingRemit.RegisterNo, drawingRemit.RegisterNo, referenceType, drawingRemit.SourceBranchCode, drawingRemit.CreatedUserId, DateTime.Now);
       }

       //public bool ValidAmount(string accountNo, decimal amount)
       //{
       //    decimal balance = this.CodeChecker.SelectCurrentBalanceByAccountNo(accountNo).CurrentBal;
       //    if (amount <= balance)
       //    {
       //       result = true;
       //    }
       //    else
       //    {
       //       result=false;
       //    }
       //    return result;
       //}
       #endregion
   }
}
