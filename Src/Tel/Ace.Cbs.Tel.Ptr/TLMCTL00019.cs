//----------------------------------------------------------------------
// <copyright file="TLMCTL00019.cs" company="ACE Data Systems">
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
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
   public class TLMCTL00019:AbstractPresenter,ITLMCTL00019
   {
       #region Properties
       private ITLMVEW00019 view;
       public ITLMVEW00019 View
       {
           set { this.WireTo(value); }
           get { return this.view; }
       }

       //added by ASDA
       private string _sourceBr = CurrentUserEntity.BranchCode+"( "+CurrentUserEntity.BranchDescription+" )"; 
       public string SourceBr
       {
           get { return _sourceBr; }
           set { _sourceBr = value; }
       }
       //end------------------------
       IList<TLMDTO00050> registerList { get; set; }
       IList<TLMDTO00050> registerInformationList { get; set; }
       IList<TLMDTO00017> registerNoList { get; set; }
       TLMDTO00029 remitBrIblDTO { get; set; }
       TLMDTO00028 remitBrDTO { get; set; }
       ChargeOfAccountDTO coa { get; set; }       
       
       public TLMDTO00017 rdData { get; set; }
       public bool result { get; set; }
       public bool checkSaving { get; set; }
       public decimal amount { get; set; }
       #endregion

       #region Methods
       private void WireTo(ITLMVEW00019 view)
       {
           if (this.view == null)
           {
               this.view = view;
               this.Initialize(this.view, View);
           }
       }
       
       public IList<TLMDTO00017> GetRegisterNo(string type)
       {
           this.registerNoList = CXClientWrapper.Instance.Invoke<ITLMSVE00019, IList<TLMDTO00017>>(x => x.GetRegisterNoBySourceBranchCode(CurrentUserEntity.BranchCode, type));
           return registerNoList;
       }

       //public void cboRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
       //{
       //    if (!e.HasXmlBaseError)
       //    {
       //        this.view.gvDrawingRemitt_DataBind();
       //        if (this.registerList != null)
       //        { this.SetEnableDisable("cboRegisterNo", false); }
       //        this.view.SetFocus();
       //    }
       //}

       public IList<TLMDTO00050> BindRegisterNoInformation(string Drawing_Type)
       {
           IList<TLMDTO00050> registerInformationList = new List<TLMDTO00050>();

           TLMDTO00015 cashdenodto = CXClientWrapper.Instance.Invoke<ITLMSVE00019, TLMDTO00015>(x => x.GetCashDenoData(this.view.RegisterNo,CurrentUserEntity.BranchCode));
           if (cashdenodto != null)
           {
               //if ((cashdenodto.CashDate == null || cashdenodto.CashDate.ToString() == "01/01/0001 12:00:00 AM") && (cashdenodto.SettlementDate == null || cashdenodto.SettlementDate.ToString() == "01/01/0001 12:00:00 AM"))
               if ((cashdenodto.CashDate == null || cashdenodto.CashDate.Value.Equals(System.DateTime.MinValue)) && (cashdenodto.SettlementDate == null || cashdenodto.SettlementDate.Value.Equals(System.DateTime.MinValue)))
               {
                   CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90050);//First ,Please Entry Drawing Remittance Denomination Entry
                   this.registerList = null;
                   return new List<TLMDTO00050>();
               }
           }
           var registerInfo = from value in registerNoList
                              where value.RegisterNo == view.RegisterNo
                              select value;         
           
           foreach (var item in registerInfo)
           {
               rdData = new TLMDTO00017();
               rdData.RegisterNo = item.RegisterNo;
               rdData.Dbank = item.Dbank;
               rdData.AccountNo = item.AccountNo;
               rdData.Amount = item.Amount;
               rdData.Commission = item.Commission;
               rdData.TlxCharges = item.TlxCharges;
               rdData.Name = item.Name;
               rdData.IncomeType = item.IncomeType;
               rdData.TestKey = item.TestKey;
               rdData.CheckNo = item.CheckNo;
               rdData.RDType = item.RDType;
               rdData.AccountSign = item.AccountSign;
               rdData.LoanSerial = item.LoanSerial;
               rdData.Currency = item.Currency;
               if (Drawing_Type == "IBL") 
               {
                   remitBrIblDTO = this.GetRemittanceAccount_ForIBL(rdData.Dbank, rdData.Currency);
                   if (remitBrIblDTO == null)
                   {
                       this.view.Failure(CXMessage.ME00021, string.Empty);
                   }
               }
               else if (Drawing_Type == "IBS")
               {
                   remitBrDTO = this.GetRemittanceAccount_ForIBS(rdData.Dbank, rdData.Currency);
                   if (remitBrDTO == null)
                   {
                       this.view.Failure(CXMessage.ME00021, string.Empty);
                   }
               }
               //remitBrIblDTO = this.GetRemittanceAccount(rdData.Dbank, rdData.Currency);
               //remitBrDTO = this.GetRemittanceAccount(rdData.Dbank, rdData.Currency);
               //if (remitBrDTO == null)
               //{
               //    this.view.Failure(CXMessage.ME00021,string.Empty);
               //}
               string value = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingOneTime);
               if (value != null)
               {
                   result = true;
               }
               else
               {
                   result = false;
               }
               
               //Drawing from Account
               if (!string.IsNullOrEmpty(rdData.AccountNo))
               {
                   TLMDTO00050 drawingDTO = new TLMDTO00050();
                   drawingDTO.AccountNo = rdData.AccountNo;
                   drawingDTO.Description = rdData.Name;
                   if (rdData.IncomeType != null)
                   {
                       if (rdData.IncomeType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate))
                       {
                           drawingDTO.Amount = Convert.ToDecimal(rdData.Amount + rdData.Commission + rdData.TlxCharges);
                           amount = drawingDTO.Amount;
                       }
                       else
                       {
                           drawingDTO.Amount = Convert.ToDecimal(rdData.Amount);
                           amount = drawingDTO.Amount;
                       }
                   }
                   else
                   {
                       drawingDTO.Amount = Convert.ToDecimal(rdData.Amount);
                       amount = drawingDTO.Amount;
                   }
                   drawingDTO.Currency = rdData.Currency;
                   drawingDTO.DebitCredit = "DR";
                   registerInformationList.Add(drawingDTO);
               }

               //Drawing with income
               if (rdData.IncomeType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate) || rdData.IncomeType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType))
               {
                   string[] array = new string[3];
                   if (Drawing_Type == "IBL")
                   {
                       array[0] =remitBrIblDTO.DrawingAccount;
                       array[1]=remitBrIblDTO.IBSComAccount;
                       array[2] =remitBrIblDTO.TelaxAccount;                        
                   }
                   else if (Drawing_Type == "IBS")
                   {
                       array[0] = remitBrDTO.DrawingAccount;
                       array[1] = remitBrDTO.IBSComAccount;
                       array[2] = remitBrDTO.TelaxAccount; 
                       //string[] array = {remitBrDTO.DrawingAccount, remitBrDTO.IBSComAccount, remitBrDTO.TelaxAccount };
                   }
                   //string[] array = { remitBrDTO.DrawingAccount, remitBrDTO.IBSComAccount, remitBrDTO.TelaxAccount };
                   for (int i = 0; i < array.Length; i++)
                   {                      
                       TLMDTO00050 drawingDTO = new TLMDTO00050();
                       drawingDTO.AccountNo = array[i];
                       coa = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { drawingDTO.AccountNo, CurrentUserEntity.BranchCode, true });
                       if (coa == null)
                       {
                           this.view.Failure(CXMessage.ME00021,string.Empty);
                       }
                       //coa = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { drawingDTO.AccountNo, CurrentUserEntity.BranchCode });
                       drawingDTO.Description = coa.AccountName;

                       if (array[i] == array[0])
                       {
                           drawingDTO.Amount = Convert.ToDecimal(rdData.Amount);
                       }
                       else if (array[i] == array[1])
                       {
                           drawingDTO.Amount = Convert.ToDecimal(rdData.Commission);
                       }
                       else
                       {
                           drawingDTO.Amount = Convert.ToDecimal(rdData.TlxCharges);
                       }
                       drawingDTO.Currency = rdData.Currency;
                       drawingDTO.DebitCredit = "CR";

                       registerInformationList.Add(drawingDTO);
                   }
               }
               else
               {                  
                   TLMDTO00050 drawingDTO = new TLMDTO00050();
                   //drawingDTO.AccountNo = remitBrIblDTO.DrawingAccount;
                   drawingDTO.AccountNo = remitBrDTO.DrawingAccount;
                   coa = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { remitBrDTO.DrawingAccount, CurrentUserEntity.BranchCode ,true});
                   if (coa == null)
                   {
                       this.view.Failure(CXMessage.ME00021,string.Empty);
                   }
                   drawingDTO.Description = coa.AccountName;
                   drawingDTO.Amount = Convert.ToDecimal(rdData.Amount);
                   drawingDTO.Currency = rdData.Currency;
                   drawingDTO.DebitCredit = "CR";
                   registerInformationList.Add(drawingDTO);
               }

           }
           this.registerList = registerInformationList;
           return registerInformationList;
         }

       public TLMDTO00028 GetRemittanceAccount_ForIBS(string branchCode, string currency)
       {
           //remitBrDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBrIbl.Client.Select", new object[] { branchCode, currency, CurrentUserEntity.BranchCode });
           //remitBrDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("RemitBr.Client.Select", new object[] { branchCode, currency, CurrentUserEntity.BranchCode });
           remitBrDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("RemitBr.SelectDrawingAccountCode", new object[] { branchCode, currency, CurrentUserEntity.BranchCode });
           return remitBrDTO;
       }
       public TLMDTO00029 GetRemittanceAccount_ForIBL(string branchCode, string currency)
       {
           remitBrIblDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBrIbl.Client.Select", new object[] { branchCode, currency, CurrentUserEntity.BranchCode }); 
           return remitBrIblDTO;
       }
      
       public TLMDTO00017 GetSaveData()
       {          
          TLMDTO00017 drawingRemit = rdData;
          drawingRemit.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);          
          drawingRemit.SourceBranchCode = CurrentUserEntity.BranchCode;
          drawingRemit.CreatedUserId = CurrentUserEntity.CurrentUserID;
          drawingRemit.IsChecked = this.view.VIP;
          return drawingRemit;
       }
       
       //public bool[] ValidAmount(string accountNo,string accountSign)
       //{
       //   bool[] check = {false,false};
       //   string accountType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoType2Length);
       //   if (accountNo.Length == Convert.ToInt32(CXCOM00007.Instance.GetValueByVariable(accountType)))
       //   {
       //       if (result == true)
       //           {
       //               if (this.view.VIP != true)
       //               {
       //                   if (Convert.ToChar(accountSign.Substring(0, 1)) == 'S')
       //                   {
       //                       //checkSaving = this.CheckSavingAccountNo();
       //                   }
       //                   else
       //                   {
       //                       checkSaving = false;
       //                   }
       //               }
       //               checkSaving = false;
       //           }
       //       }
       //   if (checkSaving == false)
       //   {
       //       bool[] checkAccount = CXClientWrapper.Instance.Invoke<ITLMSVE00019, bool[]>(x => x.GetAccountNo(accountNo,accountSign, amount));
       //       if (checkAccount[0] == false)
       //       {
       //           this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
       //           check[0] = false;
       //       }
       //       else
       //       {
       //           if (checkAccount[1] == false)
       //           {
       //               check[1] = false;
       //               if (checkAccount[2] == false)
       //               {
       //                   Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);//Insufficient Balance.
       //                   check[0] = false;
       //               }
       //               else
       //               {
       //                   check[0] = true;
       //               }
       //           }
       //           else
       //           {
       //               check[1] = true;
       //           }
       //       }
       //   }
       //   return check;
       //}

       //public bool CheckSavingAccountNo()
       //{
       //    if (CXClientWrapper.Instance.Invoke<ITLMSVE00018, bool>(x => x.HasSavingAccountTransaction(rdData.AccountNo, CurrentUserEntity.CurrentUserID)))
       //    {
       //        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { rdData.AccountNo });
       //        result = true;//Not Allow Saving debit transaction for more than one time in a week.
       //    }
       //    else
       //    {
       //        //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
       //        result = false;
       //    }
       //    return result;
       //}
          
       public void Save()
       {
           TLMDTO00017 drawingRemit = this.GetSaveData();       

           if (!string.IsNullOrEmpty(drawingRemit.AccountNo))
           {
               bool[] checkAccount = CXClientWrapper.Instance.Invoke<ITLMSVE00019, bool[]>(x => x.GetAccountNo(drawingRemit.AccountNo,amount,drawingRemit.IsChecked));
               if (checkAccount[0] == false)
               {
                   this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,drawingRemit.AccountNo);
               }
               else
               {
                   if (checkAccount[1] == true)
                   {
                       this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,string.Empty);
                   }
                   else
                   {
                       if (checkAccount[2] == false)
                       {
                           drawingRemit.CheckLink = false;
                       }
                       else
                       {
                           drawingRemit.CheckLink = true;
                       }
                       this.SaveData(drawingRemit);
                   }                  
               }              
           }
           else
           {
               this.SaveData(drawingRemit);
           }
       }

       public void SaveData(TLMDTO00017 drawingRemit)
       {
           if (this.view.type == "IBL")
           {
               this.ApproveData(drawingRemit);
           }
           else
           {
               TLMDTO00017 drawingData = this.GetDataForRDType(drawingRemit);
               if (drawingRemit.RDType == "TR")
               {
                   drawingRemit.AccountNo = drawingData.AccountNo;
                   drawingRemit.Amount = drawingData.Amount;
               }
               drawingRemit.DrawingAccount = drawingData.DrawingAccount;
               drawingRemit.DrawingAmount = drawingData.DrawingAmount;
               drawingRemit.IBSComAccount = drawingData.IBSComAccount;
               drawingRemit.IBSComAmount = drawingData.IBSComAmount;
               drawingRemit.TelaxAccount = drawingData.TelaxAccount;
               drawingRemit.TelaxAmount = drawingData.TelaxAmount;

               string voucher = CXClientWrapper.Instance.Invoke<ITLMSVE00019, string>(x => x.SaveDataForFX(drawingRemit));
               #region ErrorOccurred
               if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
               {
                   string[] logItemForTlf = new string[35];
                   //ClientLog For Tlf
                   logItemForTlf[0] = string.Empty;//GroupNo
                   logItemForTlf[1] = voucher;//EntryNo
                   if (drawingRemit.RDType == "TR")//use sp
                   {
                       logItemForTlf[2] = drawingRemit.AccountNo;//AcctNo
                       logItemForTlf[3] = string.Empty;
                   }
                   else if (drawingRemit.RDType == "CS")
                   {
                       logItemForTlf[2] = drawingRemit.DrawingAccount;//AcctNo
                       logItemForTlf[3] = drawingRemit.DrawingAccount;//ACode(from COASetUp)
                   }

                   if (drawingRemit.RDType == "TR")
                       logItemForTlf[4] = drawingRemit.Amount.ToString();//LocalAmount
                   else
                       logItemForTlf[4] = drawingRemit.DrawingAmount.ToString();//LocalAmount
                   logItemForTlf[5] = drawingRemit.Currency;//SourceCur
                   logItemForTlf[6] = string.Empty;//Cheque
                   logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                   logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), drawingRemit.SourceBranchCode).ToString();//SettlementDate
                   logItemForTlf[9] = string.Empty;//Status
                   logItemForTlf[10] = drawingRemit.SourceBranchCode;//SourceBr
                   logItemForTlf[11] = string.Empty;//Rno
                   logItemForTlf[12] = string.Empty;//Duration
                   logItemForTlf[13] = string.Empty;//LasintDate
                   logItemForTlf[14] = string.Empty;//intRate
                   logItemForTlf[15] = string.Empty;//Accured
                   logItemForTlf[16] = string.Empty;//BudenAcc
                   logItemForTlf[17] = string.Empty;//Draccured
                   logItemForTlf[18] = string.Empty;//AccuredStatus
                   logItemForTlf[19] = string.Empty;//ToAccountNo
                   logItemForTlf[20] = string.Empty;//FirstRno
                   logItemForTlf[21] = string.Empty;//PoNo
                   logItemForTlf[22] = string.Empty;//ADate
                   logItemForTlf[23] = string.Empty;//IDate
                   logItemForTlf[24] = string.Empty;//ToAcctNo
                   logItemForTlf[25] = string.Empty;//Income
                   logItemForTlf[26] = string.Empty;//Budget
                   logItemForTlf[27] = string.Empty;//FromBranch
                   logItemForTlf[28] = string.Empty;//ToBranch
                   logItemForTlf[29] = string.Empty;//Inout
                   logItemForTlf[30] = string.Empty;//Success
                   logItemForTlf[31] = string.Empty;//COMMUCHARGE
                   logItemForTlf[32] = drawingRemit.IncomeType;//IncomeType
                   logItemForTlf[33] = string.Empty;//OtherBank
                   logItemForTlf[34] = string.Empty;//OtherBankChq
                   TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Voucher(IBS) Fail Transaction", CurrentUserEntity.BranchCode,
                   logItemForTlf);
                   this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode, string.Empty);
               }
               #endregion

               #region Successful
               else
               {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = voucher;//EntryNo
                    if (drawingRemit.RDType == "TR")//use sp
                    {
                        logItemForTlf[2] = drawingRemit.AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                    }
                    else if (drawingRemit.RDType == "CS")
                    {
                        logItemForTlf[2] = drawingRemit.DrawingAccount;//AcctNo
                        logItemForTlf[3] = drawingRemit.DrawingAccount;//ACode(from COASetUp)
                    }

                    if (drawingRemit.RDType == "TR")
                        logItemForTlf[4] = drawingRemit.Amount.ToString();//LocalAmount
                    else
                        logItemForTlf[4] = drawingRemit.DrawingAmount.ToString();//LocalAmount
                    logItemForTlf[5] = drawingRemit.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), drawingRemit.SourceBranchCode).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = drawingRemit.SourceBranchCode;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = string.Empty;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = string.Empty;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = string.Empty;//Income
                    logItemForTlf[26] = string.Empty;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = drawingRemit.IncomeType;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Voucher(IBS) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);

                   this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, voucher);
                   //Added by ASDA----------------------------
                   if (drawingRemit.AccountSign != null && drawingRemit.AccountSign != string.Empty)
                   {
                       if (drawingRemit.AccountSign.Contains("S"))
                       {
                           //MC00016
                           if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)   //Do you want to print transaction
                           {
                               IList<TLMDTO00017> printData = new List<TLMDTO00017>();
                               drawingRemit.IsPrintTransaction = true;
                               printData.Add(drawingRemit);                               
                               this.Printing(printData);
                           }
                       }
                   } //end ----------------------------------------------------------                   
               }
               #endregion
           }
       }

       public void Printing(IList<TLMDTO00017> printData)
       {
           try
           {
               IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
               List<string[]> printingList;

               var list = from x in printData where x.IsPrintTransaction == true select x.AccountNo;

               if (list.Count<string>() == 0)
                   return;

               PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list.ToArray<string>());
               foreach (TLMDTO00017 info in printData)
               {
                   var query = from z in PintFileList where z.AccountNo == info.AccountNo orderby z.CreatedDate select z;
                   printingList = new List<string[]>();

                   for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                   {
                       PFMDTO00043 prnFile = query.ElementAt(i);
                       string date = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                       string[] prnFileStrArr = { date, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };
                       //string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("dd/MM/yyyy"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                       printingList.Add(prnFileStrArr);
                   }

                   if (query.Count<PFMDTO00043>() > 0)
                   {
                       Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { info.AccountNo });
                       
                       CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
                       int prnLineNo = 0;
                       prnLineNo = CXCLE00005.Instance.StartLineNo;
                       CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out prnLineNo);

                       //if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                       //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                       int lineNo = printingList.Count;
                       if (!CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.UpdateCleadgerPrintLineNoandDeletePrnFile(info.AccountNo, CurrentUserEntity.CurrentUserID, lineNo)))
                       { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); }
                   }
               }
           }
           catch (Exception ex)
           {
               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
           }       
       }  

       #region Add Code
       //public void SaveData(TLMDTO00017 drawingRemit)
       //{
       //    if (this.view.type == "IBL")
       //    {
       //        this.ApproveData(drawingRemit);
       //    }
       //    else
       //    {
       //        TLMDTO00017 drawingData = this.GetDataForRDType(drawingRemit);
       //        if (drawingRemit.RDType == "TR")
       //        {
       //            drawingRemit.AccountNo = drawingData.AccountNo;
       //            drawingRemit.Amount = drawingData.Amount;
       //        }
       //        drawingRemit.DrawingAccount = drawingData.DrawingAccount;
       //        drawingRemit.DrawingAmount = drawingData.DrawingAmount;
       //        drawingRemit.IBSComAccount = drawingData.IBSComAccount;
       //        drawingRemit.IBSComAmount = drawingData.IBSComAmount;
       //        drawingRemit.TelaxAccount = drawingData.TelaxAccount;
       //        drawingRemit.TelaxAmount = drawingData.TelaxAmount;

       //        string voucher = CXClientWrapper.Instance.Invoke<ITLMSVE00019, string>(x => x.SaveDataForFX(drawingRemit));

       //        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
       //        {
       //            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,string.Empty);
       //        }
       //        else
       //        {
       //            this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, voucher);
       //            //Added by ASDA----------------------------
       //            if(drawingRemit.AccountSign!=null && drawingRemit.AccountSign!=string.Empty)
       //            {
       //                if (drawingRemit.AccountSign.Contains("S"))
       //                {
       //                    //MC00016
       //                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)   //Do you want to print transaction
       //                    {
       //                        TLMDTO00017 returndata = CXClientWrapper.Instance.Invoke<ITLMSVE00019, TLMDTO00017>(x => x.GetDrawingDataByRegisterNo(drawingRemit.RegisterNo, CurrentUserEntity.BranchCode));
       //                        IList<TLMDTO00054> printList = new List<TLMDTO00054>();
       //                        TLMDTO00054 printData = new TLMDTO00054();
       //                        printData.RegisterNo = returndata.RegisterNo;
       //                        printData.Dbank = returndata.Dbank;
       //                        printData.AccountNo = returndata.AccountNo;
       //                        printData.Commission = Convert.ToDecimal(returndata.Commission);
       //                        printData.TelexCharges = Convert.ToDecimal(returndata.TlxCharges);
       //                        printData.Name = returndata.Name;
       //                        printData.IncomeType = returndata.IncomeType;
       //                        printData.TestKey = Convert.ToDecimal(returndata.TestKey);
       //                        //printData.CheckNo = item.CheckNo;
       //                        printData.RDType = returndata.RDType;
       //                        printData.AccountSign = returndata.AccountSign;
       //                        //printData.LoanSerial = item.LoanSerial;
       //                        printData.CurrencyCode = returndata.Currency;
       //                        printData.ToName = returndata.ToName;
       //                        printData.ToNRC = returndata.ToNRC;
       //                        printData.ToAddress = returndata.ToAddress;
       //                        printData.ToPhoneNo = returndata.ToPhoneNo;
       //                        printData.Narration = returndata.Narration;
       //                        printData.RemitAmount = Convert.ToDecimal(returndata.Amount);
       //                        printData.Type = returndata.IncomeType;
       //                        printData.Name = returndata.Name;
       //                        printData.Narration = returndata.Narration;
       //                        printData.Address = returndata.Address;
       //                        printData.PhoneNo = returndata.PhoneNo;
       //                        if (printData.IncomeType != null)
       //                        {
       //                            if (printData.IncomeType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate))
       //                            {
       //                                printData.Amount = Convert.ToDecimal(printData.Amount + printData.Commission + printData.TelexCharges);
       //                            }
       //                            else
       //                            {
       //                                printData.Amount = Convert.ToDecimal(returndata.Amount);
       //                            }
       //                        }
       //                        else
       //                        {
       //                            printData.Amount = Convert.ToDecimal(returndata.Amount);
       //                        }
       //                        printList.Add(printData);
       //                        this.PrintMethod(printList);                              
       //                    }
       //                }
       //            } //end ----------------------------------------------------------
       //        }
       //    }
       //}

       //private void PrintMethod(IList<TLMDTO00054> printList)
       //{
       //    foreach (TLMDTO00054 dto in printList)
       //    {
       //        BranchDTO banch = this.GetBankTownName(dto.Dbank);
       //        dto.CashAmountInWord = this.CashInWord(dto.RemitAmount);
       //        dto.AmountInZawGyiFont = this.CashInZawGyiFont(dto.RemitAmount + dto.TelexCharges + dto.Commission);
       //        dto.BankDescription = banch.BranchDescription;
       //        dto.BankTown = banch.BranchCode;
       //        dto.Amount = dto.RemitAmount + dto.TelexCharges + dto.Commission;
       //        dto.Type = dto.CreatedDate.ToShortDateString();               
       //    }

       //    CXUIScreenTransit.Transit("frmTLMVEW00074.DrawingRemittanceRegisterEntry", true, new object[] { (printList[0].IncomeType == "") ? "No Income" : "Income", printList });
       //}

       //private string CashInWord(decimal amount)
       //{
       //    return this.NumberToText((int)amount);
       //}

       //private string CashInZawGyiFont(decimal amount)
       //{
       //    //int stringCount = (amount.ToString().Length);
       //    string keyword = string.Empty;
       //    //for (int i = 0; i < stringCount; i++)
       //    //{
       //    //    keyword += (amount.ToString()).;
       //    //}
       //    //return keyword;

       //    char[] keys = (amount.ToString().Remove(amount.ToString().Length - 3,3).ToCharArray());
       //    foreach (char item in keys)
       //    {
       //        keyword += GetZawGyiFont(item);
       //    }
       //    return keyword;
       //}

       //private string GetZawGyiFont(char key)
       //{
       //    switch (key)
       //    {
       //        case '1':
       //            return "၁";
       //        case '2':
       //            return "၂";
       //        case '3':
       //            return "၃";
       //        case '4':
       //            return "၄";
       //        case '5':
       //            return "၅";
       //        case '6':
       //            return "၆";
       //        case '7':
       //            return "၇";
       //        case '8':
       //            return "၈";
       //        case '9':
       //            return "၉";
       //        default:
       //            return "၀";
       //    }
       //}

       //private BranchDTO GetBankTownName(string bank)
       //{
       //    return CXCLE00002.Instance.GetObjectByCustomHQL<BranchDTO>("SelectBankCityandBranchDescription", new Dictionary<string, object>() { { "branchcode", bank } });
       //}

       //private string NumberToText(int n)
       //{
       //    if (n < 0)
       //        return "Minus " + NumberToText(-n);
       //    else if (n == 0)
       //        return "";
       //    else if (n <= 19)
       //        return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", 
       //  "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
       //  "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
       //    else if (n <= 99)
       //        return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", 
       //  "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
       //    else if (n <= 199)
       //        return "One Hundred " + NumberToText(n % 100);
       //    else if (n <= 999)
       //        return NumberToText(n / 100) + "Hundreds " + NumberToText(n % 100);
       //    else if (n <= 1999)
       //        return "One Thousand " + NumberToText(n % 1000);
       //    else if (n <= 999999)
       //        return NumberToText(n / 1000) + "Thousands " + NumberToText(n % 1000);
       //    else if (n <= 1999999)
       //        return "One Million " + NumberToText(n % 1000000);
       //    else if (n <= 999999999)
       //        return NumberToText(n / 1000000) + "Millions " + NumberToText(n % 1000000);
       //    else if (n <= 1999999999)
       //        return "One Billion " + NumberToText(n % 1000000000);
       //    else
       //        return NumberToText(n / 1000000000) + "Billions " + NumberToText(n % 1000000000);
       //}

       #endregion 

       public TLMDTO00017 GetDataForRDType(TLMDTO00017 drawingRemit)
       {
           TLMDTO00017 drawing = new TLMDTO00017();
       
            if (drawingRemit.RDType == "TR" & drawingRemit.IncomeType == "CS")
            {
               for (int i = 0; i < registerList.Count; i++)
               {
                   if (i == 0)
                   {
                       drawing.AccountNo = registerList[i].AccountNo;
                       drawing.Amount = registerList[i].Amount;
                   }
                   else if (i == 1)
                   {
                       drawing.TelaxAccount = registerList[i].AccountNo;
                       drawing.TelaxAmount = registerList[i].Amount;
                   }
                   else if (i == 2)
                   {
                       drawing.IBSComAccount = registerList[i].AccountNo;
                       drawing.IBSComAmount = registerList[i].Amount;
                   }
                   else if (i == 3)
                   {
                       drawing.TelaxAccount = registerList[i].AccountNo;
                       drawing.TelaxAmount = registerList[i].Amount;
                   }
               }
           }
           else if (drawingRemit.RDType == "CS")
           {
               for (int i = 0; i < registerList.Count; i++)
                {
                    if (i == 0)
                    {
                        drawing.DrawingAccount = registerList[i].AccountNo;
                        drawing.DrawingAmount = registerList[i].Amount;
                    }
                    else if (i == 1)
                    {
                        drawing.IBSComAccount = registerList[i].AccountNo;
                        drawing.IBSComAmount = registerList[i].Amount;
                    }
                    else if (i == 2)
                    {
                        drawing.TelaxAccount = registerList[i].AccountNo;
                        drawing.TelaxAmount = registerList[i].Amount;
                    }
                }
            }
            else if (drawingRemit.RDType == "TR")
            {
                for (int i = 0; i < registerList.Count; i++)
                {
                    if (i == 0)
                    {
                        drawing.AccountNo = registerList[i].AccountNo;
                        drawing.Amount = registerList[i].Amount;
                    }
                }
            }
           return drawing;           
       }

       public void ApproveData(TLMDTO00017 drawingRemit)
       {
            if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { this.View.ParentFormId, rdData.TestKey, CXDMD00006.Drawing, this.view.CurrentFormPermissionEntity }) == DialogResult.OK)
            {
                CXDMD00010 permission = CXUIScreenTransit.GetData<CXDMD00010>(View.ParentFormId);
                this.view.CurrentFormPermissionEntity = permission;
                if (permission.IsValidFormPermission == true)
                {
                   
                    drawingRemit.CreatedUserId = permission.UserId;
                    //drawingRemit.UserNo = "admin";
                    //drawingRemit.CreatedUserId = 1;
                    string voucher = CXClientWrapper.Instance.Invoke<ITLMSVE00019, string>(x => x.SaveData(drawingRemit));
                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        if (drawingRemit.RDType == "TR")//use sp
                        {
                            logItemForTlf[2] = drawingRemit.AccountNo;//AcctNo
                            logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        }
                        else if (drawingRemit.RDType == "CS")
                        {
                            logItemForTlf[2] = drawingRemit.DrawingAccount;//AcctNo
                            logItemForTlf[3] = drawingRemit.DrawingAccount;//ACode(from COASetUp)
                        }

                        if (drawingRemit.RDType == "TR")
                            logItemForTlf[4] = drawingRemit.Amount.ToString();//LocalAmount
                        else
                            logItemForTlf[4] = drawingRemit.DrawingAmount.ToString();//LocalAmount
                        logItemForTlf[5] = drawingRemit.Currency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), drawingRemit.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = drawingRemit.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = string.Empty;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = string.Empty;//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = drawingRemit.IncomeType;//IncomeType
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Voucher(IBL) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,string.Empty);
                    }
                    #endregion

                    #region Successful
                    else
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        if (drawingRemit.RDType == "TR")//use sp
                        {
                            logItemForTlf[2] = drawingRemit.AccountNo;//AcctNo
                            logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        }
                        else if (drawingRemit.RDType == "CS")
                        {
                            logItemForTlf[2] = drawingRemit.DrawingAccount;//AcctNo
                            logItemForTlf[3] = drawingRemit.DrawingAccount;//ACode(from COASetUp)
                        }

                        if (drawingRemit.RDType == "TR")
                            logItemForTlf[4] = drawingRemit.Amount.ToString();//LocalAmount
                        else
                            logItemForTlf[4] = drawingRemit.DrawingAmount.ToString();//LocalAmount
                        logItemForTlf[5] = drawingRemit.Currency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), drawingRemit.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = drawingRemit.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = string.Empty;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = string.Empty;//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = drawingRemit.IncomeType;//IncomeType
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Voucher(IBL) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        
                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, voucher);

                    }
                    #endregion
                }
                else
                {
                    //show message
                }
            }
       }
       #endregion
   }
}
