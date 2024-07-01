//----------------------------------------------------------------------
// <copyright file="MNMCTL00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// Controller
    /// Deliver and Receipt Reverse 
    /// </summary>
    public class MNMCTL00011 : AbstractPresenter, IMNMCTL00011
    {
        #region "Constructor"

        public MNMCTL00011()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #endregion

        #region "Property"

        private bool isSaveValidate = false;

        private string BranchCode { get; set; }
        private string Dtype { get; set; }
        private string Ctype { get; set; }
        public string slipno = string.Empty;
        public string acctno = string.Empty;
        public string tranCode = string.Empty;
        public bool deliverReturn = false;
        public decimal amount = 0;
        public decimal rate = 0;
        public string acsign = string.Empty;
        public string Acode = string.Empty;

        private IList<string> customerList = new List<string>();

        private IMNMVEW00011 view;
        public IMNMVEW00011 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion "Property"

        #region "WireTo"

        private void WireTo(IMNMVEW00011 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetTlfEntity());
            }
        }

        #endregion "WireTo"

        #region "Main Methods"       

        public void Save()
        {
            //if (view.StatusCheque == "N")
            //{
            //    this.view.OtherBankCheque = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.OtherBankCheque), CXCOM00009.ChequeNoDisplayFormat);
            //}
            //else
            //{
            //    this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);                
            //}
            PFMDTO00054 entity = this.GetTlfEntity();    // Get ViewData to save        
         
            if (this.ValidateForm(entity))               // Validation Logic
            {
                if (view.StatusCheque != "N")
                {
                    //this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);   
                    if (view.OCheque != View.ChequeNo)
                    {
                        try
                        {
                            //this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);                       
                            string branch = CurrentUserEntity.BranchCode;
                            bool result = CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.CheckingChequeNo(this.view.AccountNo, this.view.ChequeNo, branch));
                            {
                                if (result == false)
                                {
                                    //this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00059);
                                    this.view.SetFocus();
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
                        }
                    }
                }
                string payslipno = this.view.PayInSlipNo;  
                if (this.View.Status.Equals("Save"))
                {
                    // Saving Logic                
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)  // confirm to save
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        entity.SourceBranchCode = this.BranchCode;

                        string[] ReversalEno = CXClientWrapper.Instance.Invoke<IMNMSVE00011, string[]>(x => x.Save_DeliverandReceipt(entity)); // save to server
                        #region ErrorOccurred
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (entity.TransactionStatus == "Receipt Reverse")
                            {
                                string[] logItemForTlf = new string[35];
                                //ClientLog For Tlf
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = ReversalEno[1];//EntryNo
                                logItemForTlf[2] = entity.AccountNo;//AcctNo
                                logItemForTlf[3] = entity.Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                                logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                                logItemForTlf[6] = entity.Cheque;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = ReversalEno[0];//Status
                                logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                                logItemForTlf[11] = entity.Eno;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = entity.Rate.ToString();//intRate
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
                                logItemForTlf[34] = entity.OtherBankChq;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Receipt Reverse Fail Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            }
                            else
                            {
                                string[] logItemForTlf = new string[35];
                                //ClientLog For Tlf
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = ReversalEno[1];//EntryNo
                                logItemForTlf[2] = entity.AccountNo;//AcctNo
                                logItemForTlf[3] = entity.Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                                logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                                logItemForTlf[6] = entity.Cheque;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = ReversalEno[0];//Status
                                logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                                logItemForTlf[11] = entity.Eno;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = entity.Rate.ToString();//intRate
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
                                logItemForTlf[34] = entity.OtherBankChq;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Deliver Reverse Fail Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);

                            }
                            this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        #endregion

                        #region Successful
                        else
                        {
                            if (entity.TransactionStatus == "Receipt Reverse")
                            {
                                string[] logItemForTlf = new string[35];
                                //ClientLog For Tlf
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = ReversalEno[1];//EntryNo
                                logItemForTlf[2] = entity.AccountNo;//AcctNo
                                logItemForTlf[3] = entity.Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                                logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                                logItemForTlf[6] = entity.Cheque;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = ReversalEno[0];//Status
                                logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                                logItemForTlf[11] = entity.Eno;//RNo
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = entity.Rate.ToString();//intRate
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
                                logItemForTlf[34] = entity.OtherBankChq;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Receipt Reverse Commit Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            }
                            else
                            {
                                string[] logItemForTlf = new string[35];
                                //ClientLog For Tlf
                                logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = ReversalEno[1];//EntryNo
                                logItemForTlf[2] = entity.AccountNo;//AcctNo
                                logItemForTlf[3] = entity.Acode;//ACode(from COASetUp)
                                logItemForTlf[4] = entity.Amount.ToString();//LocalAmount
                                logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                                logItemForTlf[6] = entity.Cheque;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = ReversalEno[0];//Status
                                logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                                logItemForTlf[11] = entity.Eno;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = entity.Rate.ToString();//intRate
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
                                logItemForTlf[34] = entity.OtherBankChq;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Deliver Reverse Commit Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
 
                            }
                            this.View.Successful("MI30040", payslipno);                             //Successfully Reversal Transaction   
                            this.View.ClearControl();

                            if (entity.AccountNo.Length > 6 && entity.AccountSign.Substring(0, 1) == "S")                         //Printing 
                            {
                                PFMDTO00043 PrnfileDTO = new PFMDTO00043();
                                PrnfileDTO.AccountNo = entity.AccountNo;
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { entity.AccountNo });
                                if (CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.view.GetMenuIDPermission(), PrnfileDTO, entity.AccountSign, false }) == System.Windows.Forms.DialogResult.OK)
                                {
                                }     
                            }
                        }
                        #endregion
                    }
                }
                else   //Delivered Edit  
                {
                    // Saving Logic(need)               
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes) // confirm to update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        entity.HomeAmount = entity.Amount * CXCOM00010.Instance.GetExchangeRate(entity.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                        CXClientWrapper.Instance.Invoke<IMNMSVE00011>(x => x.Update(entity));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            this.View.Successful(CXMessage.MI90002, payslipno);         //Update Successful
                            this.View.ClearControl();
                        }
                        else
                        {
                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                }
            }

        }

        public void Delete()
        {
            PFMDTO00054 entity = this.GetTlfEntity();
            if (this.ValidateForm(entity))
            {                
                entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                CXClientWrapper.Instance.Invoke<IMNMSVE00011>(x => x.Delete_DeliverEdit(entity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    string payslipno = this.view.PayInSlipNo;
                    this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, payslipno);
                    this.View.ClearControl();
                }
                else
                {
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                
            }
        }        
        #endregion

        #region "Validation Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void txtAccountno_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.View.AccountNo == acctno)
            {
                if (this.View.CustomerList.Items.Count <= 0)
                {
                    int i = 0;
                    foreach (string customerName in this.customerList)
                    {
                        i++;
                        this.View.CustomerList.Items.Add(i.ToString() + ". " + customerName);
                    }
                }

                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);

            }

            else
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00231);     //Invalid AccountNo
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.View.TransactionStatus == "Deliver Reverse")
            {
                if (this.View.Amount == amount)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
                              
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV30038); //Invalid Amount
                }
            }
        }

        public void txtPaySlipNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    slipno = this.View.PayInSlipNo;
                    if (string.IsNullOrEmpty(slipno))
                    {

                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV30001");    //Invalid Entry No
                        return;
                    }
                    else
                    {

                        PFMDTO00054 tlfdto = this.GetTlfInformation();                                         //get data from server                        
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            return;
                        }


                        if (tlfdto == null)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "MV30001");    //Invalid Entry No
                            return;
                        }

                        else
                        {
                            this.View.OCheque = tlfdto.Cheque;
                            acctno = tlfdto.AccountNo;
                            acsign = tlfdto.AccountSign;
                            amount = tlfdto.Amount;
                            tranCode = tlfdto.TransactionCode;
                            deliverReturn = tlfdto.DeliverReturn;
                            this.customerList = tlfdto.CustomerNames;
                            this.rate = tlfdto.Rate.Value;
                            this.Acode = tlfdto.Acode;

                            //Check accountType 13 or 15
                            Nullable<CXDMD00011> accountType;
                            if (acctno.Length>6 && CXCLE00012.Instance.IsValidAccountNo(acctno, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                            {
                                switch (this.View.TransactionStatus)
                                {
                                    case "Deliver Edit":

                                        if (tlfdto.TransactionCode == this.Dtype)   //CLDELIVER
                                        {
                                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                                            this.ShowViewData(tlfdto, true);
                                            this.View.SetEnable(true);
                                            this.View.SetDisable(false, true);
                                        }

                                        else
                                        {
                                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "MV30001");
                                            return;
                                        }
                                        break;

                                    case "Deliver Reverse":

                                        if (tlfdto.TransactionCode == this.Dtype)    //CLDELIVER
                                        {
                                            if (this.CheckingDeliverReverse(tlfdto, true))
                                            {
                                                this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                                                this.View.SetEnable(true);
                                                if (tlfdto.DeliverReturn == true)
                                                    this.view.Note = "**Note : Returned Cheque**";
                                                else if (tlfdto.DeliverReturn == false)
                                                    this.view.Note = "**Note : Unreturned Cheque**";
                                            }
                                            else
                                                return;
                                        }

                                        else
                                        {
                                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "MV30001");
                                            return;
                                        }
                                        break;

                                    case "Receipt Reverse":

                                        if (tlfdto.TransactionCode == this.Ctype)   //CLRECEIPT
                                        {
                                            if (this.CheckingReceiptReverse(tlfdto, true))
                                            {
                                                this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                                                this.View.SetEnable(true);
                                                this.View.SetDisable(false, false);
                                            }
                                            else
                                                return;
                                        }
                                        else
                                        {
                                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "MV30001");
                                            return;
                                        }
                                        break;

                                }

                            }

                            //Check Domestic AccountType                                    
                            else if (CXCLE00012.Instance.CheckAccountNoType(acctno, CXDMD00011.DomesticAccountType))
                            {
                                switch (this.View.TransactionStatus)
                                {

                                    case "Deliver Reverse": this.CheckingDeliverReverse(tlfdto, true); break;
                                    case "Receipt Reverse": this.CheckingReceiptReverse(tlfdto, true); break;
                                }

                                if (this.View.TransactionStatus.Contains("Deliver"))
                                {
                                    IList<ChargeOfAccountDTO> coaList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountNameList", new object[] { acctno, this.BranchCode, true });
                                    if (this.View.CustomerList.Items.Count <= 0)
                                    {
                                        this.View.CustomerList.Items.Add(coaList[0].AccountName);
                                    }
                                    if (this.View.TransactionStatus == "Deliver Edit")
                                    {
                                        //this.View.SetEnable(true);
                                        this.View.SetDisable(false, false);
                                    }
                                    else
                                    {
                                        this.View.SetEnable(true,false);
                                    }
                                }
                                else if (this.View.TransactionStatus == "Receipt Reverse")
                                {

                                    if (tlfdto.TransactionCode == this.Ctype)   //CLRECEIPT
                                    {
                                        if (this.CheckingReceiptReverse(tlfdto, true))
                                        {
                                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                                            this.View.SetDisable(false, false);
                                            
                                        }
                                        else
                                            return;
                                    }
                                    else
                                    {
                                        this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "MV30001");
                                        return;
                                    }
                                }
                            }  //end of Domestic Checking

                        }  // end of 

                    }

                } // tlfdto not equal null
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), ex.Message);
                }
            }
        }

        public PFMDTO00054 GetTlfInformation()
        {
            try
            {
                Dtype = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditDeliver);
                Ctype = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitReceipt);
                return CXClientWrapper.Instance.Invoke<IMNMSVE00011, PFMDTO00054>(service => service.GetTlfInformation(this.slipno, Dtype, Ctype, this.BranchCode, this.view.TransactionStatus));
            }
            catch
            {
                throw new Exception();
            }
           
        }

        public string GetName(string entityacctno)
        {
            try
            {
                acctno = entityacctno;
                return CXClientWrapper.Instance.Invoke<IMNMSVE00011, string>(service => service.GetNameByAccount(this.acctno));
            }
            catch
            {
                throw new Exception();
            }
          
        }

        private PFMDTO00054 GetTlfEntity()                       // Viewdata to DTO
        {
            PFMDTO00054 tlfEntity = new PFMDTO00054();
            tlfEntity.Eno = this.View.PayInSlipNo;
            tlfEntity.AccountNo = this.View.AccountNo;
            tlfEntity.AccountSign = acsign;
            tlfEntity.CurrencyCode = this.View.Currency;
            tlfEntity.Amount = this.View.Amount;
            tlfEntity.Cheque = this.view.ChequeNo;          
            tlfEntity.OtherBankChq = this.View.OtherBankCheque;
            tlfEntity.ReceiptNo = this.View.ReceiptNo;
            tlfEntity.OtherBank = this.View.PaidBank;
            tlfEntity.TransactionStatus = this.View.TransactionStatus;
            tlfEntity.TransactionCode = tranCode;
            tlfEntity.DeliverReturn = deliverReturn;
            tlfEntity.Rate = this.rate;
            tlfEntity.Acode = this.Acode;
            return tlfEntity;
        }

        private void ShowViewData(PFMDTO00054 entity, bool flag)  //DTO to Viewdata
        {
            if (flag)
            {
                this.View.AccountNo = entity.AccountNo;
                this.View.Amount = entity.Amount;
                if (this.View.CustomerList.Items.Count <= 0)
                {
                    int i = 0;
                    foreach (string customerName in entity.CustomerNames)
                    {
                        i++;
                        this.View.CustomerList.Items.Add(i.ToString() + ". " + customerName);
                    }
                }
            }
            this.View.Currency = entity.SourceCurrency;
            this.View.OtherBankCheque = entity.OtherBankChq;
            this.View.PaidBank = entity.OtherBank;
            this.View.ReceiptNo = entity.ReceiptNo;
            this.View.ChequeNo = entity.Cheque;
            
        }

        private bool CheckingDeliverReverse(PFMDTO00054 tlfdto, bool IsShow)
        {
            //string deliverdate = Convert.ToDateTime(tlfdto.SettlementDate).ToShortDateString();
            string deliverdate = tlfdto.SettlementDate.Value.ToShortDateString();
            string todaydate = DateTime.Now.ToShortDateString();

            if (tlfdto.CLRPostStatus == "Y")            // deliver date must be today date       
            {
                if (deliverdate == todaydate)           // Check Deliver Posting status
                {
                    if (IsShow) this.ShowViewData(tlfdto, false);
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20023);  //Not Allow Back Date
                    this.View.SetFocus(false);
                    return false;
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30003);     //Please post balances for the year first.
                this.View.SetFocus(false);
                return false;
            }
            return true;
        }

        private bool CheckingReceiptReverse(PFMDTO00054 tlfdto, bool IsShow)
        {
            string receiptdate = Convert.ToDateTime(tlfdto.DateTime).ToShortDateString();
            string todaydate = DateTime.Now.ToShortDateString();

            if (receiptdate == todaydate)                               
            {
                if (IsShow) this.ShowViewData(tlfdto, true);
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20023);  //Not Allow Back Date
                this.View.SetFocus(false);
                return false;
            }
            return true;
        }

        #endregion "Validation Methods"

        #region "Helper Methods"
        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion
    }
}