//----------------------------------------------------------------------
// <copyright file="TLMCTL00002" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// ENCASH REMIT REGISTRATION CONTROLLER
    /// </summary>
    public class TLMCTL00002 : AbstractPresenter, ITLMCTL00002
    {
        #region VIEW

        private ITLVEW00002 view;

        public ITLVEW00002 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLVEW00002 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEncashRegistrationEntity());
            }
        }

        #endregion

        #region PROPERTIES

        public string transactionType { get; set; }
        public string poNo = string.Empty;
        public string printRegisterNo { get; set; }
        public string printIRNo { get; set; }
   
        #endregion

        #region HELPER METHODS

        public TLMDTO00001 GetEncashRegistrationEntity()
        {
            string poNo = string.Empty;
            TLMDTO00001 encashDTO = new TLMDTO00001();
            encashDTO.Ebank = this.view.BranchCode;
            encashDTO.Currency = this.view.Currency;
            encashDTO.RegisterNo = this.view.FixRegisterNo + this.view.RegisterNo;
            encashDTO.Amount = this.view.Amount;
            encashDTO.ToAccountNo = this.view.AccountNo;
            encashDTO.ToName = this.view.PayeeName;
            encashDTO.ToNRC = this.view.PayeeNRC;
            encashDTO.ToAddress = this.view.PayeeAddress;
            encashDTO.ToPhoneNo = this.view.PayeePhoneNo;
            encashDTO.Name = this.view.RemitterName;
            encashDTO.NRC = this.view.RemitterNRC;
            encashDTO.PhoneNo = this.view.RemitterPhoneNo;
            printRegisterNo = encashDTO.RegisterNo;
            return encashDTO;
        }

        public void GetFixRegisterNo()
        {
            string fiscalYear = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.FixcalculationYear);
            string telaxTransfer = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.TelaxTransfer);
            string iblTransfer = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.InterBranchLinkingTransfer);
            if (this.view.TransactionStatus == "IBL")
            {
                this.view.FixRegisterNo = fiscalYear + this.view.BranchCode + iblTransfer;
            }
            else
            {
                this.view.FixRegisterNo = fiscalYear + this.view.BranchCode + telaxTransfer;
            }
            this.transactionType = this.view.TransactionStatus;
        }

        public bool GetCustomerByAccountNo()
        {
            try
            {
                if (!String.IsNullOrEmpty(this.view.AccountNo.Trim()))
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        IList<PFMDTO00001> customer = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.view.AccountNo, true));
                        if (customer != null)
                        {
                            if (this.view.Currency != customer[0].CurrencyCode)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00086, new object[] { this.View.Currency });

                            }
                            else
                            {

                                this.view.PayeeName = customer[0].Name;
                                this.view.PayeeNRC = customer[0].NRC;
                                this.view.PayeeAddress = customer[0].Address + ", " + customer[0].TownshipDesp + ", " +
                                                    customer[0].CityDesp + ", " + customer[0].StateDesp;
                                this.view.AccountSign = customer[0].AccountSign;
                                this.view.PayeePhoneNo = customer[0].PhoneNo;
                                this.view.ReadOnlyControls(true);
                            }
                        }
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00175");//Account No Not Found.
                        this.SetFocus("mtxtAccountNo");
                    }

                }
                else
                {
                    this.view.Shows();
                }
                return true;
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00046");//Invalid Account No
                return false;

            }
        }

        #endregion        

        #region UI LOGIC

        public string Save()
        {
            
            TLMDTO00001 reDTO = GetEncashRegistrationEntity();
             if (this.Validate())
             {
                 
                 if (this.view.POStatus == false)
                 {

                     if (!String.IsNullOrEmpty(this.view.FixRegisterNo))
                     {

                         reDTO.Type = this.view.FixRegisterNo.Substring(4);
                     }
                     reDTO.AccountSign = this.view.AccountSign;
                     reDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                     reDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;

                     poNo = CXClientWrapper.Instance.Invoke<ITLMSVE00002, string>(x => x.SaveRE(reDTO));
                    // poNo = string.Empty;

                     //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                     //{
                     //    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                     //}

                     //else
                     //{
                     //    this.View.PONo = poNo;
                     //    this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, poNo);
                     //    this.ClearControls();
                     //}

                 }
                 else
                 {
                     if (!String.IsNullOrEmpty(this.view.FixRegisterNo))
                     {
                         reDTO.Type = this.view.FixRegisterNo.Substring(4);
                     }
                     reDTO.AccountSign = this.view.AccountSign;
                     reDTO.Budget = this.view.BudgetYear;
                     reDTO.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                     reDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                     reDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;

                     poNo = CXClientWrapper.Instance.Invoke<ITLMSVE00002, string>(x => x.SaveREandPO(reDTO));

                 }
                 #region ErrorOccurred
                 if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                 {
                     string[] logItemForDrawing = new string[26];
                     if (this.view.POStatus == false)
                         logItemForDrawing[0] = poNo;//Registerno
                     logItemForDrawing[1] = string.Empty;//Dbank
                     logItemForDrawing[2] = reDTO.Type;//Type
                     logItemForDrawing[3] = reDTO.Name;//Name
                     if (!String.IsNullOrEmpty(reDTO.ToAccountNo.Trim()))
                     {
                         logItemForDrawing[4] = reDTO.ToAccountNo.ToString();//ToAcctno
                     }
                     else
                     {
                         if (this.view.POStatus == false)
                         {
                             logItemForDrawing[4] = reDTO.ToAccountNo.ToString();//ToAcctno
                         }
                         else
                         {
                             logItemForDrawing[4] = poNo;//ToAcctno 
                         }
                     }
                     logItemForDrawing[5] = reDTO.ToName;//ToName
                     logItemForDrawing[6] = reDTO.Amount.ToString();//Amount
                     logItemForDrawing[7] = System.DateTime.Now.ToString();//Date_time
                     logItemForDrawing[8] = string.Empty;//ReceiptDate
                     logItemForDrawing[9] = string.Empty;//IncomeDate
                     logItemForDrawing[10] = string.Empty;//SendDate
                     logItemForDrawing[11] = string.Empty;//Deno_Status
                     logItemForDrawing[12] = reDTO.SourceBranchCode;//SourceBr
                     logItemForDrawing[13] = reDTO.Currency;//SourceCur
                     logItemForDrawing[14] = string.Empty;//GroupNo
                     logItemForDrawing[15] = string.Empty;//Eno
                     logItemForDrawing[16] = string.Empty;//AcctNo
                     logItemForDrawing[17] = string.Empty;//ACode
                     logItemForDrawing[18] = string.Empty;//LocalAmount
                     logItemForDrawing[19] = reDTO.Currency;//SourceCur
                     logItemForDrawing[20] = string.Empty;//Cheque
                     logItemForDrawing[21] = System.DateTime.Now.ToString();//DATE_TIME
                     logItemForDrawing[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), reDTO.SourceBranchCode).ToString();//SettlementDate
                     logItemForDrawing[23] = string.Empty;//Status
                     if (this.view.POStatus == false)
                     {
                         logItemForDrawing[24] = string.Empty;//IssueDate
                     }
                     else
                     {
                         logItemForDrawing[24] = System.DateTime.Now.ToString();//IssueDate
                     }
                     logItemForDrawing[25] = reDTO.Ebank;//Ebank
                     TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Encash Fail Transaction", CurrentUserEntity.BranchCode,
                                 logItemForDrawing);
                     this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                 }
                 #endregion
                 #region Successful
                 else
                 {
                     this.View.PONo = poNo;
                     this.printIRNo = poNo;

                     string[] logItemForEncash = new string[26];
                     if (this.view.POStatus == false)
                     logItemForEncash[0] = poNo;//Registerno
                     logItemForEncash[1] = string.Empty;//Dbank
                     logItemForEncash[2] = reDTO.Type;//Type
                     logItemForEncash[3] = reDTO.Name;//Name
                     if (!String.IsNullOrEmpty(reDTO.ToAccountNo.Trim()))
                     {
                         logItemForEncash[4] = reDTO.ToAccountNo.ToString();//ToAcctno
                     }
                     else
                     {
                         if (this.view.POStatus == false)
                         {
                             logItemForEncash[4] = reDTO.ToAccountNo.ToString();//ToAcctno
                         }
                         else
                         {
                             logItemForEncash[4] = poNo;//ToAcctno 
                         }
                     }
                     logItemForEncash[5] = reDTO.ToName;//ToName
                     logItemForEncash[6] = reDTO.Amount.ToString();//Amount
                     logItemForEncash[7] = System.DateTime.Now.ToString();//Date_time
                     logItemForEncash[8] = string.Empty;//ReceiptDate
                     logItemForEncash[9] = string.Empty;//IncomeDate
                     logItemForEncash[10] = string.Empty;//SendDate
                     logItemForEncash[11] = string.Empty;//Deno_Status
                     logItemForEncash[12] = reDTO.SourceBranchCode;//SourceBr
                     logItemForEncash[13] = reDTO.Currency;//SourceCur
                     logItemForEncash[14] = string.Empty;//GroupNo
                     logItemForEncash[15] = string.Empty;//Eno
                     logItemForEncash[16] = string.Empty;//AcctNo
                     logItemForEncash[17] = string.Empty;//ACode
                     logItemForEncash[18] = string.Empty;//LocalAmount
                     logItemForEncash[19] = reDTO.Currency;//SourceCur
                     logItemForEncash[20] = string.Empty;//Cheque
                     logItemForEncash[21] = System.DateTime.Now.ToString();//DATE_TIME
                     logItemForEncash[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), reDTO.SourceBranchCode).ToString();//SettlementDate
                     logItemForEncash[23] = string.Empty;//Status
                     if (this.view.POStatus == false)
                     {
                         logItemForEncash[24] = string.Empty;//IssueDate
                     }
                     else
                     {
                         logItemForEncash[24] = System.DateTime.Now.ToString();//IssueDate
                     }
                     logItemForEncash[25] = reDTO.Ebank;//Ebank
                     TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Encash Commit Transaction", CurrentUserEntity.BranchCode,
                                 logItemForEncash);
                     this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, poNo);
                     //this.ClearControls();
                 }
                 #endregion
             }
             return poNo;
        }


        public void Printing()
        {
            //TLMDTO00001 dto = this.GetEncashRegistrationEntity();
            TLMDTO00001 printPO = CXClientWrapper.Instance.Invoke<ITLMSVE00002, TLMDTO00001>(x => x.PrintPOData(printRegisterNo,CurrentUserEntity.BranchCode));
            printPO.PONo = printIRNo;
            IList<TLMDTO00001> REDTOList = new List<TLMDTO00001>();
            REDTOList.Add(printPO);
            CXUIScreenTransit.Transit("frmTCMVEW00061", true, new object[] { REDTOList, "Encashment Printing for (PO / AC)" });
        }

        public void ClearControls()
        {
            this.view.BranchCode = string.Empty;
            //this.view.Currency = string.Empty;
            this.view.FixRegisterNo = string.Empty;
            this.view.RegisterNo = string.Empty;
            this.view.Amount = 0;
            this.view.AccountNo = string.Empty;
            this.view.PayeeName = string.Empty;
            this.view.PayeeNRC = string.Empty;
            this.view.PayeeAddress = string.Empty;
            this.view.PayeePhoneNo = string.Empty;
            this.view.RemitterName = string.Empty;
            this.view.RemitterNRC = string.Empty;
            this.view.RemitterPhoneNo = string.Empty;
            this.view.PONo = string.Empty;
            this.view.BudgetYear = string.Empty;
            this.view.POStatus = false;
        }

        #endregion

        #region  VALIDATION LOGIC

        public void cboPaidBank_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            //if (e.HasXmlBaseError == false)
            //{
            //    this.view.ComboValidate("Paid Bank");
            //}
            //else
            //{
            //    this.SetCustomErrorMessage(this.GetControl("cboPaidBank"), "MV00089");//Invalid Paid Bank.
            //}
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            //if (e.HasXmlBaseError == false)
            //{
            //    this.view.ComboValidate("Currency");
            //}
            //else
            //{
            //    this.SetCustomErrorMessage(this.GetControl("cboCurrency"), "MV00020");//Invalid Currency.
            //}
        }

        public void txtEncashAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }                  

            if (this.view.Amount != 0)
            {
                this.view.Disable();
                this.GetFixRegisterNo();
                this.view.RegisterNoFocus();
                this.SetCustomErrorMessage(this.GetControl("txtEncashAmount"), string.Empty);//Invalid Amount.
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtEncashAmount"), CXMessage.MV00037);//Invalid Amount.
            } 
        }

        public void txtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            try
            {
                string reNo = this.view.FixRegisterNo + this.view.RegisterNo;

                bool result = CXClientWrapper.Instance.Invoke<ITLMSVE00002, bool>(x => x.CheckDuplicateRegisterNo(reNo));
                if (result != false)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), CXMessage.MV00108);//Duplicate Register.                    
                }

            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), CXMessage.MV00168);//Invalid  Register No.
 
            }
            

           
            
        }        

        public bool Validate()
        {
            TLMDTO00001 encashDTO = new TLMDTO00001();
            encashDTO.Currency = this.view.Currency;
            encashDTO.RegisterNo = this.view.RegisterNo;
            encashDTO.Amount = this.view.Amount;
            encashDTO.ToAccountNo = this.view.AccountNo;
            encashDTO.ToName = this.view.PayeeName;
            encashDTO.ToNRC = this.view.PayeeNRC;
            encashDTO.ToAddress = this.view.PayeeAddress;
            encashDTO.ToPhoneNo = this.view.PayeePhoneNo;
            encashDTO.Name = this.view.RemitterName;
            encashDTO.NRC = this.view.RemitterNRC;
            encashDTO.PhoneNo = this.view.RemitterPhoneNo;

            return this.ValidateForm(encashDTO);           
         
        }

        #endregion

        
    }
}

