using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{

    public class MNMCTL00010 : AbstractPresenter, IMNMCTL00010
    {
        #region Properties

        private bool isValidateForm = false;
        public CXDTO00001 denoDTO { get; set; }
        public string transactionCode { get; set; }
       // public MNMDTO00024 tlfCashDenoDTO { get; set; }
        public string status { get; set; }
        public TLMDTO00015 CashDenoDTO=new TLMDTO00015();
        decimal TotalAmount{ get; set; }
        string SourceCurrency{ get; set; }
        private bool ValidationStatus = true;

        private string accountNo { get; set; }
        private string acSign { get; set; }
        public IList<PFMDTO00054> AcType { get; set; }
        public IList<TLMDTO00004> ListIBLTLFDTO { get; set; }
        public string accountName { get; set; }
        
        
        #endregion

        #region VIEW
        private IMNMVEW00010 view;
        public IMNMVEW00010 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00010 view)
        {
            this.view = view;
            this.Initialize(this.view, this.getEntity());
        }

        private PFMDTO00054 getEntity()
        {
            PFMDTO00054 tlfEntity = new PFMDTO00054();
            
            tlfEntity.Eno = this.view.EntryNo;
            tlfEntity.GroupNo = this.view.GroupNo;
            tlfEntity.Narration = this.view.Narration;                  

            return tlfEntity;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        #endregion

        #region Validation Logic

        public void txtEntryNo_CustomValidate(object sender, ValidationEventArgs e)
        {
            //if (!e.HasXmlBaseError && ValidationStatus)
            //{
            //    string EntryNo = this.View.EntryNo;
            //    try
            //    {
            //        //Check Entry no from Tlf
            //         IList<PFMDTO00054> ListTlfDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00010,PFMDTO00054>(x => x.Check_EntryNo_Valid(EntryNo, CurrentUserEntity.BranchCode));
                     
            //        if (ListTlfDTO != null)
            //        {
            //            //added by ASDA***
            //            foreach (PFMDTO00054 dto in ListTlfDTO)
            //            {
            //                if (!string.IsNullOrEmpty(dto.AccountNo) && dto.AccountNo.Length == 15)
            //                {
            //                    this.accountNo = dto.AccountNo;                                
            //                }
            //            }
            //            //end****
            //            if (this.accountNo == null || this.accountNo == "NULL")
            //            {
            //            }
            //            else
            //            {

            //                IList<PFMDTO00001> customerInformation = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.accountNo, false));
            //                this.acSign = customerInformation[0].AccountSign;
            //            }
            //            TotalAmount = ListTlfDTO[0].DenoAmount;
            //            SourceCurrency = ListTlfDTO[0].SourceCurrency;  //added by ASDA
            //            this.AcType = ListTlfDTO;
            //        }

            //        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            //        {
            //            this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);                       
            //        }
            //        else //If Entry NO. Exist,Fill Data
            //        {
            //            this.View.FillData(ListTlfDTO);                        
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Set Error Message to Control.               
            //        CXUIMessageUtilities.ShowMessageByCode(ex.Message.ToString());
            //        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), ex.Message.ToString());
            //    }
            //}
            //ValidationStatus = true;
        }

        #endregion

        #region Main Method

        public void Save()
        {
          
           PFMDTO00054 reversal = this.getEntity();
            ValidationStatus = false;
            this.isValidateForm = true;
            status = string.Empty;
            CashDenoDTO = null;
            
            if (this.ValidateForm(reversal))            
            {
                if (this.view.GroupNo != string.Empty)
                {
                    if (View.Status.ToUpper() == "DEPOSIT" || View.Status == "CSCREDIT")
                    {
                        transactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashCreditType);
                        status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
                    }
                    else if (View.Status.ToUpper() == "WITHDRAW" || View.Status == "CSDEBIT")
                    {
                        transactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitType);
                        status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                    }

                    CXDMD00008 transactionStatus = (status == "P") ? CXDMD00008.Payment : CXDMD00008.Received;

                    if (!string.IsNullOrEmpty(status) && TotalAmount != 0)
                    {
                        if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { TotalAmount, SourceCurrency, transactionStatus, View.ParentFormId }) == DialogResult.OK)
                        {
                            CashDenoDTO = new TLMDTO00015();
                            denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                            if (denoDTO != null)
                            {
                                CashDenoDTO.DenoDetail = denoDTO.DenoString;
                                CashDenoDTO.DenoRate = denoDTO.DenoRateString;
                                CashDenoDTO.DenoRefundDetail = denoDTO.RefundString;
                                CashDenoDTO.DenoRefundRate = denoDTO.RefundRateString;
                                CashDenoDTO.AdjustAmount = denoDTO.AdjustAmount;
                                CashDenoDTO.Amount = TotalAmount;
                                CashDenoDTO.CounterNo = denoDTO.CounterNo;
                                CashDenoDTO.Currency = SourceCurrency;
                                CashDenoDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                                CashDenoDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
                                CashDenoDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                            }
                            else
                            {
                                //Error Occur becoz user don't enter deno but close the form.
                                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                                return;
                            }
                        }
                        else
                            return; // Failure of deno form
                    }
                    string voucherNo = CXClientWrapper.Instance.Invoke<IMNMSVE00010, string>(x => x.Save_Reversal(this.View.EntryNo, this.view.GroupNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, CashDenoDTO));
                    CXClientWrapper.Instance.Invoke<IMNMSVE00010>(x => x.Save_Reversal(this.view.EntryNo, this.view.GroupNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, CashDenoDTO));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = this.view.GroupNo;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                        // logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), AcType[0].CurrencyCode, AcType[0].SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[3] = this.AcType[0].Acode;
                        logItemForTlf[4] = this.AcType[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.AcType[0].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), AcType[0].SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = this.AcType[0].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = voucherNo;//Rno
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
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Fail Online Transaction Reversal ", CurrentUserEntity.BranchCode,
                        logItemForTlf);




                        
                        
                        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = this.view.GroupNo;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                        // logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), AcType[0].CurrencyCode, AcType[0].SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[3] = this.AcType[0].Acode;
                        logItemForTlf[4] = this.AcType[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.AcType[0].CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), AcType[0].SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = this.AcType[0].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = voucherNo;//Rno
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
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Successful Online Transaction Reversal ", CurrentUserEntity.BranchCode,
                        logItemForTlf);




                        
                        
                        //Show Reversal Transaction Successfull
                        this.View.Successful("MI30040");

                    }
                }
                else
                {
                    
                    string voucherNo =  CXClientWrapper.Instance.Invoke<IMNMSVE00010, string>(x => x.Save_Reversal(this.View.EntryNo, this.view.GroupNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, CashDenoDTO));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = this.view.GroupNo;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                        // logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), AcType[0].CurrencyCode, AcType[0].SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[3] = this.AcType[0].Acode;
                        logItemForTlf[4] = this.AcType[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.AcType[0].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), AcType[0].SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = this.AcType[0].Status;//Status
                        logItemForTlf[10] = this.AcType[0].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = voucherNo;//Rno
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
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Fail Local Transaction Reversal", CurrentUserEntity.BranchCode,
                        logItemForTlf);


                        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                   
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = this.view.GroupNo;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                       // logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), AcType[0].CurrencyCode, AcType[0].SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[3] = this.AcType[0].Acode;                   
                        logItemForTlf[4] = this.AcType[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.AcType[0].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), AcType[0].SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = this.AcType[0].Status;//Status
                        logItemForTlf[10] = this.AcType[0].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = voucherNo;//Rno
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
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Successful Local Transaction Reversal", CurrentUserEntity.BranchCode,
                        logItemForTlf);

                        //Show Reversal Transaction Successfull
                        this.View.Successful("MI30040");
                    }
                }
                if (this.AcType[0].AccountNo.Length==6)
                {
                }
                else
                {
                    if (this.acSign.StartsWith("S"))
                    {
                        if (CXUIMessageUtilities.ShowMessageByCode("MC00016") == DialogResult.Yes)   //do you want to print Transaction?
                        {
                            this.Printing(this.accountNo);
                        }
                    }
                }
            }
            this.isValidateForm = false;
        }

        public void Printing(string accountNo)
        {            
            IList<PFMDTO00043> GetPrnFileList = CXClientWrapper.Instance.Invoke<IMNMSVE00010, IList<PFMDTO00043>>(x => x.SelectPrnFileByAccountNo(accountNo));            
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                List<string[]> printingList;
                
                var query = from z in GetPrnFileList where z.AccountNo == GetPrnFileList[0].AccountNo orderby z.CreatedDate select z;
                    printingList = new List<string[]>();

                    for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                    {
                        PFMDTO00043 prnFile = query.ElementAt(i);
                        string date = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                        string[] prnFileStrArr = { date, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };                        

                        printingList.Add(prnFileStrArr);
                    }
                    if (query.Count<PFMDTO00043>() > 0)
                    {
                        CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
                        int prnLineNo = 0;
                        prnLineNo = CXCLE00005.Instance.StartLineNo;
                        CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out prnLineNo);

                        //if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                        //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                        int lineNo = printingList.Count;
                        if (!CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.UpdateCleadgerPrintLineNoandDeletePrnFile(GetPrnFileList[0].AccountNo, CurrentUserEntity.CurrentUserID, lineNo)))
                        { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); }
                    }                
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);  //Printing Error Occur.
            }
            finally
            {

            }
        } 

        #endregion

        #region Helper Method 

        //Added by ZMS 
        public void GetInfoByEntryNo()
        {
            string EntryNo = this.View.EntryNo;
            try
            {
                //Check Entry no from Tlf
                IList<PFMDTO00054> ListTlfDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00010, PFMDTO00054>(x => x.Check_EntryNo_Valid(EntryNo, CurrentUserEntity.BranchCode));

                if (ListTlfDTO != null)
                {
                    //Check Info before Reversal
                    DateTime txnSettlementDate;                    
                    txnSettlementDate = DateTime.Parse(ListTlfDTO[0].SettlementDate.ToString());

                    foreach (PFMDTO00054 dto in ListTlfDTO)
                    {
                        if (!string.IsNullOrEmpty(dto.AccountNo) && dto.AccountNo.Length == 15)
                        {
                            this.accountNo = dto.AccountNo;
                        }
                    }
                    if (this.accountNo == null || this.accountNo == "NULL")
                    {
                    }
                    else
                    {

                        IList<PFMDTO00001> customerInformation = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.accountNo, false));
                        this.acSign = customerInformation[0].AccountSign;                        
                    }
                    TotalAmount = ListTlfDTO[0].DenoAmount;
                    SourceCurrency = ListTlfDTO[0].SourceCurrency; 
                    this.AcType = ListTlfDTO;
                }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else //If Entry NO. Exist,Fill Data
                {
                    this.View.FillData(ListTlfDTO);
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.               
                CXUIMessageUtilities.ShowMessageByCode(ex.Message.ToString());
                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), ex.Message.ToString());
            }
            ValidationStatus = true;
        }

        //Added by HMW at 20-08-2019 : [Seperating EOD Process] To show system date (not PC date)
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
#endregion

    }
}
    
 
               
                                                          
                


               
                        
          
           
                         
         
        
        

      

      
   

