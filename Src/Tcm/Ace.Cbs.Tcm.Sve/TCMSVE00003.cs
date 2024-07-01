//----------------------------------------------------------------------
// <copyright file="TCMSVE00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;


namespace Ace.Cbs.Tcm.Sve
{
   public class TCMSVE00003:BaseService,ITCMSVE00003
   {
       #region "DAO & Service"
       private ICXSVE00006 CodeChecker { get; set; }
       private ICXSVE00002 GetCodeGenerator { get; set; }
       private ICXSVE00010 DataGenerateSerice { get; set; }
       private ICXSVE00004 AmtOamtService { get; set; } 
       private ICXDAO00009 ViewsDAO { get; set; }
       private IPFMDAO00006 ChequeDAO { get; set; }
       private ICXSVE00003 PrintService { get; set; }
       private ITLMDAO00016 PODAO { get; set; }
       private DateTime SettlementDate { get; set; }
       private decimal Rate { get; set; }
       private string Channel { get; set; }
       #endregion       

       #region "Private Variables"
       PFMDTO00017 POEntity = new PFMDTO00017();
       private decimal cbal = 0;
       private string currentacSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign);       
       private string savingacSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign);
       #endregion

       #region "Public Methods"
       public TLMDTO00016 CheckAccountNo(string accountNo, bool isVIP,bool isWithIncome,string workStation,int createdUserId,string sourceBr)
       {
           TLMDTO00016 PODTO = new TLMDTO00016();      
          bool isfaof= this.CodeChecker.isFAOFAccountNo(accountNo);         
          if (isfaof == true)
          {
              //Show Invalid Current, Saving and Chart of Account(MV00197)
              this.ServiceResult.ErrorOccurred = true;
              this.ServiceResult.MessageCode = CXMessage.MV00197;
              return null;
          }
          else
          {
              if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
              {
                  this.ServiceResult.ErrorOccurred = true;
                  this.ServiceResult.MessageCode = CXMessage.MV00044;
                  return null;
              }
              else
              {
                  if (this.CodeChecker.IsFreezeAccount(accountNo))
                  {
                      this.ServiceResult.ErrorOccurred = true;
                      this.ServiceResult.MessageCode = CXMessage.MV00057;
                      return null;
                  }
                  else
                  {
                      PFMDTO00028 cledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);                   
                      if (cledgerDTO.AccountSign != null)
                      {
                          string acSign=cledgerDTO.AccountSign.Substring(0,1);
                          switch (acSign)
                          {
                              case "S": if (isVIP == false)
                                  {
                                      CXDTO00006 reportparameters = new CXDTO00006();
                                      reportparameters.AccountNo = accountNo;                                       
                                      reportparameters.StartDate = DateTime.Now;
                                      reportparameters.EndDate = DateTime.Now;
                                      reportparameters.BDateType = "T";
                                      reportparameters.SpecialCondition = "Substring(Status,2,1) = 'D' and sourceBr = '"+sourceBr+"'";
                                      reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForCheck;
                                      reportparameters.UserNo = workStation;
                                      reportparameters.CreatedUserId = createdUserId;
                                      //reportparameters.UserNo = CurrentUserEntity.WorkStationId.ToString();
                                      //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;

                                      PFMDTO00042 DataGenerateDTO = this.DataGenerateSerice.GetReportDataGenerateInSQL(reportparameters);                                    
                                      if (DataGenerateDTO!=null)
                                      {
                                          this.ServiceResult.ErrorOccurred = true;
                                          this.ServiceResult.MessageCode = CXMessage.MV00135; //Not Allow Saving debit transaction for more than one time in a week.
                                          return null;
                                      }
                                      //else
                                      //{
                                      //    PODTO.Currency = this.SelectCurrencyByAccNo(accountNo);
                                      //    PODTO.AcSign = acSign;
                                      //    PODTO.AccountNo = accountNo;
                                      //}
                                    
                                  }
                                          PODTO.Currency = this.SelectCurrencyByAccNo(accountNo);
                                          PODTO.AcSign = acSign;
                                          PODTO.AccountNo = accountNo;
                                  break;
                              case "C":
                                  {
                                      if (accountNo.Length != 6)
                                      {
                                         IList<PFMDTO00006> ChequeDTOList= this.ChequeDAO.SelectListByChequeBookNoByAccountNo(accountNo);
                                         if (ChequeDTOList.Count > 0)
                                         {
                                             if (ChequeDTOList.Count == 3)
                                             {
                                                 PODTO.ChequeThree = "3." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                                 PODTO.ChequeTwo = "2." + "[" + ChequeDTOList[ChequeDTOList.Count - 2].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 2].EndNo + "]";
                                                 PODTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 3].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 3].EndNo + "]";
                                             }
                                             else if (ChequeDTOList.Count == 2)
                                             {
                                                 PODTO.ChequeThree = string.Empty;
                                                 PODTO.ChequeTwo = "2." + "[" + ChequeDTOList[ChequeDTOList.Count - 2].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 2].EndNo + "]";
                                                 PODTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                             }
                                             else
                                             {
                                                 PODTO.ChequeThree = string.Empty;
                                                 PODTO.ChequeTwo = string.Empty;
                                                 PODTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                             }
                                         }
                                         else
                                         {
                                             PODTO.ChequeOne = string.Empty;
                                             PODTO.ChequeTwo = string.Empty;
                                             PODTO.ChequeThree = string.Empty;
                                         }
                                         PODTO.Currency = this.SelectCurrencyByAccNo(accountNo);
                                         PODTO.AcSign = acSign;
                                      }                                
                                      //SELECT * FROM dbo.COASETUP WHERE ACNONAME='PO'
                                      //Select Information using account no
                                      // select Top * from Bal where accountNo=''
                                  }
                                  break;                                
                          }                       

                      }
                     
                  }
              }
          }
          return PODTO;
          
       }

       public IList<TLMDTO00016> CheckForPO(string acctno,string branchno)
       {
           IList<TLMDTO00016> poInfoList = this.PODAO.SelectPOInfoByAcctno(acctno,branchno);
           return poInfoList;
       }

       public CXDTO00009 CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit, string branchCode)
       {
           bool IsPO = false;
           string messageNo = string.Empty;
           bool isLink = false;
           if (!chequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(accountNo,chequeNo,branchCode))
           {
               
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                   return new CXDTO00009(this.ServiceResult.MessageCode, isLink);
            }
           else
           {               
                if (!this.CodeChecker.CheckAmount(accountNo, amount, isMinBalCheck, isVIP, isDebit, ref isLink,ref messageNo)== true)
               {
                  this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = messageNo;
                return new CXDTO00009(this.ServiceResult.MessageCode, isLink);             
               }
              
           }

           return new CXDTO00009(this.ServiceResult.MessageCode, isLink); ;
       }

       [Transaction(TransactionPropagation.Required)]
       public string[] SavePOIssueEntry(IList<TLMDTO00043> PoIssueList)
       { 
           TLMDTO00043 PODTO = new TLMDTO00043();
           PODTO.SettlementDate=CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PoIssueList[0].SourceBranch , true });
           PODTO.Rate=CXCOM00010.Instance.GetExchangeRate(PoIssueList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
           PODTO.Channel=CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
           PODTO.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
           PODTO.BranchCode = PoIssueList[0].SourceBranch;
           //PODTO.BranchCode = CurrentUserEntity.BranchCode;
           PODTO.AccountNo = PoIssueList[PoIssueList.Count - 1].AccountNo;
           PODTO.AccountSign = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(PoIssueList[PoIssueList.Count-1].AccountNo).AccountSign;
           try
           {
               if (PODTO.SettlementDate == null || PODTO.Channel == null || PODTO.Budget == null)
               {
                   this.ServiceResult.ErrorOccurred = true;
                   this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                   return null;
               }
               else
               {
                   string[] PONoArray = new string[PoIssueList.Count + PoIssueList.Count];
                   for (int i = 0; i < PoIssueList.Count; i++)
                   {
                       PODTO.ENo = this.GetENo(PODTO.SettlementDate, PoIssueList[i].SourceBranch,PoIssueList[i].CreatedUserId);
                       PODTO.PONo = this.GetPONo(PODTO.SettlementDate, PoIssueList[i].SourceBranch, PoIssueList[i].CreatedUserId);
                       decimal debit = PoIssueList[i].AdjustmentAmount;
                       PFMDTO00054 AmtOamt= this.GetAmountAndOverDraftAmountAndBalance(PODTO.AccountNo, PoIssueList[i].AdjustmentAmount);
                       PODTO.Amount = AmtOamt.LocalAmt.Value;
                       PODTO.AdjustmentAmount = AmtOamt.Amount;
                       PODTO.HomeAmt = AmtOamt.LocalOAmt.Value;
                       PODTO.Charges = PoIssueList[i].Charges;
                       PODTO.CheckNo = PoIssueList[i].CheckNo;
                       PODTO.UserNo =PoIssueList[i].CreatedUserId.ToString();
                       PODTO.SourceBranch = PoIssueList[i].SourceBranch;
                       PODTO.CreatedUserId = PoIssueList[i].CreatedUserId;
                       PODTO.Currency = PoIssueList[i].Currency;                      
                       PODTO.POStatus = "0";
                                             
                      bool isSave= this.DataGenerateSerice.SavePOIssueEntry(PODTO);
                       if(!isSave)
                       {                          
                         PONoArray[i] = PODTO.PONo;
                         PONoArray[PoIssueList.Count + i] = PODTO.ENo;
                         if (PODTO.AccountSign.Substring(0, 1) == savingacSign)
                         {
                             PFMDTO00043 PrnFileDTO = new PFMDTO00043();
                             //PrnFileDTO.Reference = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POEncash) }).PBReference;
                             PrnFileDTO.Reference = "TRW";
                             PrnFileDTO.AccountNo = PODTO.AccountNo;
                             PrnFileDTO.DATE_TIME = DateTime.Now;
                             PrnFileDTO.Credit = 0;
                             PrnFileDTO.Debit = debit;
                             PrnFileDTO.Balance = PODTO.AdjustmentAmount;
                             PrnFileDTO.SourceBranchCode = PODTO.SourceBranch;
                             //PrnFileDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                             PrnFileDTO.UserNo = PODTO.CreatedUserId.ToString();
                             PrnFileDTO.CreatedDate = DateTime.Now;
                             PrnFileDTO.CreatedUserId = PODTO.CreatedUserId;
                             PrnFileDTO.CurrencyCode = PODTO.Currency;
                             this.InsertPRNFile(PrnFileDTO);
                         }
        
                         this.ServiceResult.ErrorOccurred = false;
                         this.ServiceResult.MessageCode = "MI90001";//"MI30043" PO TRANSACTION IS SUCCESSFULLY PROGRESS!...                         
                       }
                       else
                       {
                         this.ServiceResult.ErrorOccurred = true;
                         this.ServiceResult.MessageCode =this.DataGenerateSerice.ServiceResult.MessageCode;
                         throw new Exception(this.ServiceResult.MessageCode);
                       }
                   }
                   return PONoArray;
               }
               
           }
           catch(Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = ex.Message;
               throw new Exception(this.ServiceResult.MessageCode);
               //return null;
           }
           
       }
       #endregion

       #region "Private Methods"
       private string SelectCurrencyByAccNo(string accountno)
       {
           string currency = this.CodeChecker.SelectTopCurrencyCodeByAccountNo(accountno);
           POEntity.CurrencyCode = currency;
           return POEntity.CurrencyCode;
       }
       private string GetPONo(DateTime settlementDate,string sourceBranch,int createdUserId)
       {
           //return "PO" + CurrentUserEntity.BranchCode + "/" + this.GetCodeGenerator.GetGenerateCode("PONO.Code", string.Empty, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
           return "PO" + sourceBranch + "/" + this.GetCodeGenerator.GetGenerateCode("PONO.Code", string.Empty, createdUserId, sourceBranch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
       }
       private   string GetENo(DateTime settlementDate,string sourceBranch,int createdUserId)
       {
           //return this.GetCodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
           return this.GetCodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, createdUserId, sourceBranch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
       }
       private PFMDTO00054 GetAmountAndOverDraftAmountAndBalance(string accountNo,decimal totalamount)
       {
           PFMDTO00054 AmtOAmtDTO = this.AmtOamtService.AmtOamtParameterCheck(accountNo, totalamount, CXDMD00002.Debit);
           AmtOAmtDTO.Amount = this.CodeChecker.SelectCurrentBalanceByAccountNo(accountNo).CurrentBal-totalamount;
           return AmtOAmtDTO;
       }

       [Transaction(TransactionPropagation.Required)]
       private void InsertPRNFile(PFMDTO00043 prnFileDTO)
       {
           try
           {
               this.PrintService.PRNFile_Save(prnFileDTO);
           }
           catch
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.ME00061;
           }
       }
       #endregion

       public string GetDescriptionByAccountNo(string accountNo)
       {
           string customerDescription=string.Empty;
          IList<PFMDTO00001> customerList = this.CodeChecker.GetCustomerInfomationByAccountNo(accountNo, false);
          if (customerList.Count > 0)
          {
              customerDescription = customerList[0].Name; 
          }
          return customerDescription;
       }

       public bool CheckingChequeNo(string accountNo, string chequeNo, string branch)
       {
           if (!chequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(accountNo, chequeNo, branch))
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
               return false;
           }
           return true;
       }
   }
}
