//----------------------------------------------------------------------
// <copyright file="TLMCTL00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>01/08/2013</CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate>2013/10/21</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry Controller
    /// </summary>
   public class TLMCTL00006:AbstractPresenter,ITLMCTL00006
    {
       private ITLMVEW00006 view;
       public ITLMVEW00006 View
       {
           get { return this.view; }
           set { this.WireTo(value); }
       }

       private void WireTo(ITLMVEW00006 view)
       {
           if (this.view == null)
           {
               this.view = view;
              this.Initialize(this.view, this.GetClearingDeliveredReceiptEntity());
           }
       }
       public TLMCTL00006() 
       {
           this.BranchCode = CXCOM00007.Instance.BranchCode;
       }

       #region Variable
       private string BranchCode { get; set; }
       private string AccountSign { get; set; }
       private CXDMD00011 AccountType { get; set; }
       private bool IsLinkTransaction { get; set; }
       private bool IsVIP { get; set; }
       private bool _IsInsufficient { get; set; }
       private bool _IsSave { get; set; }
       private ICXSVE00006 customerAccount { get; set; }
       #endregion

       #region Validation Logic

       public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
       {
           if (e.HasXmlBaseError == false)
           {
               if (CXCLE00012.Instance.CheckAccountNoType(this.view.AccountNo, CXDMD00011.DomesticAccountType))
                // And validate checkdigit of account code by account checkdigit formula
               //IList<PFMDTO00001> customerList = new List<PFMDTO00001>();
               //Nullable<CXDMD00011> accountType;
               //if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))       
               {
                   IList<ChargeOfAccountDTO> coaList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountNameList", new object[] { this.View.AccountNo, this.BranchCode, true });
                   if (coaList.Count < 1)
                   {
                       //Account No. Not Found.
                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00175);
                       
                      //customerList = this.customerAccount.GetCustomerInfomationByAccountNoAndSourceBranchCode(this.view.AccountNo,false,CurrentUserEntity.BranchCode);
                      //this.View.AccountName = customerList[0].Name;
                   }
                   else if (this.View.AccountNo.Substring(3, 3) == "000")
                   {
                       //Group COA Code is not allowed.
                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00132);
                   }
                   else
                   {
                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                       this.view.IsDomestic(true);
                       this.View.AccountName = coaList[0].AccountName;
                       this.AccountType = CXDMD00011.DomesticAccountType;
                       if (this.View.TransactionStatus == "Clearing.Receipt")
                       {
                           if (this._IsSave.Equals(false))
                                this.View.IsDomestic(false);

                           this.View.EnableDisableControlForDomesticReceipt(true);
                       }
                       else if (this.View.isDeliver)
                       {
                           if (this._IsSave.Equals(false))
                               this.View.DeliverDomesticFormCleaning();

                           this.View.EnableDisableControls(true);
                       }
                       else
                           this.View.EnableDisableControls(true);
                   }

               } 
               else if (CXCLE00012.Instance.CheckAccountNoType(this.View.AccountNo, CXDMD00011.AccountNoType2))
               {
                   if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                   {
                       IList<PFMDTO00001> customerInformation = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.View.AccountNo,false));
                       if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                       {
                           this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                       }
                       else if (customerInformation == null || customerInformation.Count < 1)
                       {
                           //Invalid Account No.
                           this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), (this.view.isDeliver) ? "MV00197" : "MV00198");
                       }
                       else
                       {
                           if (customerInformation[0].AccountSign.Substring(0, 1).Equals("S") && !this.view.isDeliver)
                           {
                               //Invalid Account No.
                               this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00198);
                           }
                           else
                           {
                               this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                               if (this.BranchCode == customerInformation[0].SourceBranch)
                               {
                                   this.View.CurrencyCode = customerInformation[0].CurrencyCode;
                                   this.IsVIP = customerInformation[0].IsVIP;
                                   this.View.EnableDisableCurrencyCombo(false);
                                   this.AccountSign = customerInformation[0].AccountSign;
                                   this.View.AccountName = customerInformation[0].Name;
                                   this.View.EnableDisableControls(true);
                                   this.AccountType = CXDMD00011.AccountNoType2;
                                   if (this._IsSave.Equals(false))
                                   {
                                       if (customerInformation[0].AccountSign.Substring(0, 1).Equals("S") && this.view.isDeliver)
                                       {
                                           this.SetEnableDisable("txtChequeNo",true);
                                       }
                                       this.View.FoucsCursorOnChequeNo();
                                       this.View.ChequeNo = string.Empty;
                                       this.View.OtherBank = string.Empty;
                                       this.View.BankDescriptionLabel = string.Empty;
                                       this.View.Amount = 0;
                                   }

                               }
                               else
                               {
                                   //Invalid Account No.
                                   this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00070);
                               }
                           }
                       }
                   }
                   else
                   {
                       //Invalid Account No.
                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                   }
               }
               else
               {
                   //Incompleted Account No.
                   this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00199);
               }
           }
       }

       public void txtChequeNo_CustomValidating(object sender, ValidationEventArgs e)
       {
           if (e.HasXmlBaseError == false)
           {
               if (this.View.TransactionStatus == "Clearing.Receipt")
               {
                   if ((this.AccountType != CXDMD00011.DomesticAccountType) && string.IsNullOrEmpty(this.View.ChequeNo))
                   {
                       this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXMessage.MV00059);//Invalid Cheque No.
                   }
                   else if (this.AccountType != CXDMD00011.DomesticAccountType)
                   {
                       this.View.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.View.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                       CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsValidChequeBookIssueNoForAccountClose(this.View.AccountNo, this.View.ChequeNo, this.BranchCode));
                       if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                       {
                           this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.ChequeNo });
                       }
                       else
                       {
                           this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), string.Empty);
                       }
                   }
               }
               else
               {                  
                   if(string.IsNullOrEmpty(this.View.ChequeNo))
                       this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXMessage.MV00100);//Invalid Other Bank Cheque No.
                   else
                       this.View.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.View.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
               }
           }
       }
       public void mtxtReceiptAccountNo_CustomValidating(object sender, ValidationEventArgs e)
       {
           if (e.HasXmlBaseError == false)
           {
               if (this.View.TransactionStatus == "Clearing.Receipt" && (this.AccountType != CXDMD00011.DomesticAccountType) && string.IsNullOrEmpty(this.View.ReceiptAccountNo))
               {
                   this.SetCustomErrorMessage(this.GetControl("mtxtReceiptAccountNo"), CXMessage.MV00101);
               }
               else
               {
                   this.SetCustomErrorMessage(this.GetControl("mtxtReceiptAccountNo"), string.Empty);
               }
           }
       }
       public void cboOtherBank_CustomValidating(object sender, ValidationEventArgs e)
       {
           if (e.HasXmlBaseError == false)
           {
               if (string.IsNullOrEmpty(this.View.OtherBank))
               {
                   if (this.View.TransactionStatus == "Clearing.Delivered")
                   {
                       this.SetCustomErrorMessage(this.GetControl("cboOtherBank"), CXMessage.MV00099);
                   }
                   else if (this.View.TransactionStatus == "Clearing.Receipt")
                   {
                       this.SetCustomErrorMessage(this.GetControl("cboOtherBank"), CXMessage.MV00176);
                   }
               }
               else
               {
                   var desp = (from value in this.View.BCodeList where value.BCode == this.View.OtherBank select value.BDesp).Single();
                   this.View.BankDescriptionLabel = Convert.ToString(desp);
               }
           }
       }

       private CXDTO00004 GetAmountCheckParameter()
       {
           CXDTO00004 parameters = new CXDTO00004();
           parameters.AccountNo = this.View.AccountNo;
           parameters.ACSign = this.AccountSign;
           parameters.Amount = this.View.Amount;
           parameters.DebitCreditTransaction = CXDMD00002.Debit;
           parameters.Force = 1;
           parameters.MinBalCheck = 1;
           parameters.IsVIP = true;
           parameters.CreatedUserId = CurrentUserEntity.CurrentUserID;
           return parameters;
       }
       public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
       {
           this.IsLinkTransaction = false;
           string messageCode = string.Empty;
           if (e.HasXmlBaseError == false)
           {
               if ((this.AccountType != CXDMD00011.DomesticAccountType) && (this.View.TransactionStatus == "Clearing.Receipt"))
               {
                   TLMDTO00053 receiptDto = this.GetClearingDeliveredReceiptEntity();
                   CXDTO00009 dto = CXClientWrapper.Instance.Invoke<ITLMSVE00006, CXDTO00009>(x => x.DebitInformationChecking(receiptDto));
                   if (!String.IsNullOrEmpty(dto.MessageCode))
                   {
                       Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(dto.MessageCode);
                       this._IsInsufficient = true;
                       return;
                   }
                   else
                       this.IsLinkTransaction = dto.IsLink;
               }
               else
               {
                   if (0 >= this.View.Amount)
                   {
                       this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00037);
                   }
                   else
                   {
                       this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
                   }
               }
           }
       }
       #endregion

       #region UI Logic

       public void ClearControls()
       {          
           this.View.PayInSlipNo = string.Empty;
           this.View.BankDescriptionLabel = string.Empty;
           this.View.AccountNo = string.Empty;
           this.View.ReceiptAccountNo = string.Empty;
           //this.View.CurrencyCode = string.Empty;
           this.View.OtherBank = string.Empty;
           this.View.Amount = 0;
           this.View.ChequeNo = string.Empty;
           this.View.AccountName = string.Empty;
           this.AccountType = 0;
           this.AccountSign = string.Empty;
           this.ClearAllCustomErrorMessage();
       }

       public void Save()
       {
           this._IsSave = true;
           if (this.ValidateForm(this.GetClearingDeliveredReceiptEntity()))
           {
               if (!this._IsInsufficient)
               {
                   string paySlipNo = string.Empty;
                   TLMDTO00053 entity = this.GetClearingDeliveredReceiptEntity();
                   if (this.IsLinkTransaction)
                   {
                       if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00009) == DialogResult.No)
                       {
                           Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109); // Insufficient Amount.
                           return;
                       }
                   }
                   paySlipNo = CXClientWrapper.Instance.Invoke<ITLMSVE00006, string>(x => x.Save(entity));

                   #region ErrorOccurred
                   if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                   {
                       if (entity.TransactionStatus == "Clearing.Receipt")
                       {
                           string[] logItemForTlf = new string[35];
                           //ClientLog For Tlf
                           logItemForTlf[0] = string.Empty;//GroupNo
                           logItemForTlf[1] = paySlipNo;//EntryNo
                           logItemForTlf[2] = entity.AccountNo;//AcctNo
                           if (entity.IsDomesticAccountType)
                           {
                               logItemForTlf[3] = entity.AccountNo;//ACode(from COASetUp)                               
                           }
                           else
                           {
                               if (entity.AccountSign.StartsWith("C"))
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                               else if (entity.AccountSign.StartsWith("S") /*&& (entity.TransactionStatus == "Clearing.Receipt")*/)
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                           }
                           logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                           if (entity.IsLinkTransaction)
                           {
                               logItemForTlf[5] = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true }).Cur;//SourceCur
                           }
                           else
                           {
                               logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                           }
                           logItemForTlf[6] = entity.ChequeNo;//Cheque
                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                           logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                           logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitReceipt) }).Status;//Status
                           logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
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
                           logItemForTlf[32] = string.Empty;//IncomeType
                           logItemForTlf[33] = entity.OtherBank;//OtherBank
                           logItemForTlf[34] = string.Empty;//OtherBankChq
                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Receipt Entry Fail Transaction", CurrentUserEntity.BranchCode,
                           logItemForTlf);
                       }
                       else if (entity.TransactionStatus == "Clearing.Delivered")
                       {
                           string[] logItemForTlf = new string[35];
                           //ClientLog For Tlf
                           logItemForTlf[0] = string.Empty;//GroupNo
                           logItemForTlf[1] = paySlipNo;//EntryNo
                           logItemForTlf[2] = entity.AccountNo;//AcctNo
                           if (entity.IsDomesticAccountType)
                           {
                               logItemForTlf[3] = entity.AccountNo;//ACode(from COASetUp)
                           }
                           else
                           {
                               if (entity.AccountSign.StartsWith("C"))
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                               else if (entity.AccountSign.StartsWith("S") /*&& (entity.TransactionStatus == "Clearing.Receipt")*/)
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                           }
                           logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                           logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                           logItemForTlf[6] = string.Empty;//Cheque
                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                           logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                           logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditDeliver) }).Status;//Status
                           logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
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
                           logItemForTlf[32] = string.Empty;//IncomeType
                           logItemForTlf[33] = entity.OtherBank;//OtherBank
                           logItemForTlf[34] = entity.ChequeNo;//OtherBankChq
                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Delivered Entry Fail Transaction", CurrentUserEntity.BranchCode,
                           logItemForTlf);
                       }
                       this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                   }
                   #endregion

                   #region Successful
                   else
                   {
                       if (entity.TransactionStatus == "Clearing.Receipt")
                       {
                           string[] logItemForTlf = new string[35];
                           //ClientLog For Tlf
                           logItemForTlf[0] = string.Empty;//GroupNo
                           logItemForTlf[1] = paySlipNo;//EntryNo
                           logItemForTlf[2] = entity.AccountNo;//AcctNo
                           if (entity.IsDomesticAccountType)
                           {
                               logItemForTlf[3] = entity.AccountNo;//ACode(from COASetUp)                               
                           }
                           else
                           {
                               if (entity.AccountSign.StartsWith("C"))
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                               else if (entity.AccountSign.StartsWith("S") /*&& (entity.TransactionStatus == "Clearing.Receipt")*/)
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                           }
                           logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                           if (entity.IsLinkTransaction)
                           {
                               logItemForTlf[5] = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true }).Cur;//SourceCur
                           }
                           else
                           {
                               logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                           }
                           logItemForTlf[6] = entity.ChequeNo;//Cheque
                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                           logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                           logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitReceipt) }).Status;//Status
                           logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
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
                           logItemForTlf[32] = string.Empty;//IncomeType
                           logItemForTlf[33] = entity.OtherBank;//OtherBank
                           logItemForTlf[34] = string.Empty;//OtherBankChq
                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Receipt Entry Commit Transaction", CurrentUserEntity.BranchCode,
                           logItemForTlf);
                       }
                       else if (entity.TransactionStatus == "Clearing.Delivered")
                       {
                           string[] logItemForTlf = new string[35];
                           //ClientLog For Tlf
                           logItemForTlf[0] = string.Empty;//GroupNo
                           logItemForTlf[1] = paySlipNo;//EntryNo
                           logItemForTlf[2] = entity.AccountNo;//AcctNo
                           if (entity.IsDomesticAccountType)
                           {
                               logItemForTlf[3] = entity.AccountNo;//ACode(from COASetUp)
                           }
                           else
                           {
                               if (entity.AccountSign.StartsWith("C"))
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                               else if (entity.AccountSign.StartsWith("S") /*&& (entity.TransactionStatus == "Clearing.Receipt")*/)
                               {
                                   logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.CurrencyCode, entity.SourceBranchCode, true });//ACode(from COASetUp)
                               }
                           }
                           logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                           logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                           logItemForTlf[6] = string.Empty;//Cheque
                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                           logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                           logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditDeliver) }).Status;//Status
                           logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
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
                           logItemForTlf[32] = string.Empty;//IncomeType
                           logItemForTlf[33] = entity.OtherBank;//OtherBank
                           logItemForTlf[34] = entity.ChequeNo;//OtherBankChq
                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Delivered Entry Commit Transaction", CurrentUserEntity.BranchCode,
                           logItemForTlf);
                       }
                       this.View.PayInSlipNo = paySlipNo;

                       //Pay Slip No. is -->XXXXXXXXXXXX.
                       this.View.Successful(CXMessage.MI00051, paySlipNo);

                       // Clear all controls
                       this.ClearControls();
                   }
                   #endregion
               }
               this._IsInsufficient = false;
           }
           this._IsSave = false;
       }

       #endregion

       #region Helper Methods
       private TLMDTO00053 GetClearingDeliveredReceiptEntity()
       {
           TLMDTO00053 clearingDeliveredReceiptEntity = new TLMDTO00053();          
           clearingDeliveredReceiptEntity.TransactionStatus = this.View.TransactionStatus;          
           clearingDeliveredReceiptEntity.AccountNo = this.View.AccountNo;
           clearingDeliveredReceiptEntity.CurrencyCode = this.View.CurrencyCode;
           clearingDeliveredReceiptEntity.ReceiptAccountNo = this.View.ReceiptAccountNo;
           clearingDeliveredReceiptEntity.Amount = this.View.Amount;
           clearingDeliveredReceiptEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
           clearingDeliveredReceiptEntity.CreatedDate = DateTime.Now;
           clearingDeliveredReceiptEntity.ChequeNo = this.View.ChequeNo;
           clearingDeliveredReceiptEntity.OtherBank = this.View.OtherBank;
           clearingDeliveredReceiptEntity.SourceBranchCode = this.BranchCode;
           clearingDeliveredReceiptEntity.AccountName = this.View.AccountName;
           clearingDeliveredReceiptEntity.AccountSign = this.AccountSign;
           clearingDeliveredReceiptEntity.IsDomesticAccountType =(this.View.AccountNo.Count().Equals(6))?true:this.AccountType.Equals(CXDMD00011.DomesticAccountType) ? true : false;
           clearingDeliveredReceiptEntity.IsLinkTransaction = this.IsLinkTransaction;
           clearingDeliveredReceiptEntity.IsVIP = this.IsVIP;
           if (clearingDeliveredReceiptEntity.TransactionStatus == "Clearing.Receipt")
           {
               if (clearingDeliveredReceiptEntity.IsDomesticAccountType)
               {
                   clearingDeliveredReceiptEntity.LocalAmt = clearingDeliveredReceiptEntity.Amount;
                   clearingDeliveredReceiptEntity.LocalOamt = 0;
               }
               else
               {
                   if (!String.IsNullOrEmpty(clearingDeliveredReceiptEntity.AccountNo))
                   {
                       PFMDTO00054 tlf = CXCLE00012.Instance.AmtOamtParameterCheck(clearingDeliveredReceiptEntity.AccountNo, clearingDeliveredReceiptEntity.Amount, CXDMD00002.Debit);
                       clearingDeliveredReceiptEntity.LocalAmt = tlf.LocalAmt.Value;
                       clearingDeliveredReceiptEntity.LocalOamt = tlf.LocalOAmt.Value;
                   }
               }
           }
           return clearingDeliveredReceiptEntity;
       }

        #endregion
    }
}
