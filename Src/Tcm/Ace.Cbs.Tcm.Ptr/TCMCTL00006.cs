using System;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00006 : AbstractPresenter, ITCMCTL00006
    {
        #region Form Initializer

        private ITCMVEW00006 view;
        public ITCMVEW00006 View
        {
            get
            {
                return this.view;
            }
            set
            {
                this.WireTo(value);
            }
        }

        private void WireTo(ITCMVEW00006 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.Entity);
            }
        }

        int printedLine;
        List<string[]> printingList;
        //public CXDTO00001 denoData { get; set; }

        #endregion

        #region Validating Methods

        public void mtxtDebitAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == true)
            {
                this.SetFocus("mtxtAccountNo");
                return;
            }
            else if (!string.IsNullOrEmpty(this.View.Status))
                return;
            try
            {
                Nullable<CXDMD00011> accountType;
                PFMDTO00021 FaofEntity;
                if (CXCLE00012.Instance.IsValidAccountNo(this.View.AccountNo, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV20054); // invalid Account Type
                    else
                    {
                        FaofEntity = CXClientWrapper.Instance.Invoke<ITCMSVE00006, PFMDTO00021>(x => x.SeletByDebitAccountNumber(this.View.AccountNo, this.View.SourceBranchCode));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals(CXMessage.MV00224))
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.AccountNo, CurrentUserEntity.BranchCode });
                            else
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.View.AccruedInterest = FaofEntity.AccuredInterest;
                            this.View.CurrencyCode = FaofEntity.CurrencyCode;
                            this.View.Name = FaofEntity.Name;
                            this.View.Nrc = FaofEntity.NRC;
                            this.View.DebitAccountSign = FaofEntity.AccountSignature;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void mtxtCreditAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError)
                return;
            else if(this.View.FormCaption.Contains("Withdrawal"))
                return;
            try
            {
                this.View.CledgerInfo = null;
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.View.CreditAccountNo, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXMessage.MV20054); // invalid Account Type
                    else
                    {
                        this.View.CledgerInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00006, PFMDTO00028>(x => x.SelectByCreditAccountNumber(this.View.CreditAccountNo, this.View.SourceBranchCode));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals(CXMessage.MV00224))
                                this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.CreditAccountNo, CurrentUserEntity.BranchCode });
                            //else if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals(CXMessage.MV00175))
                            //    this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //else if (this.View.CurrencyCode != this.View.CledgerInfo.CurrencyCode)
                            //    this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXMessage.MV00086, new object[] { this.View.CurrencyCode });
                            else
                                this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            if (this.View.CurrencyCode != this.View.CledgerInfo.CurrencyCode)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), CXMessage.MV00086, new object[] { this.View.CurrencyCode });
                            }
                            else
                            {
                                this.View.CreditName = this.View.CledgerInfo.Customer.Name;
                                this.View.CreditNrc = this.View.CledgerInfo.Customer.NRC;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtCreditAccountNo"), ex.Message);
            }
        }

        #endregion

        #region Main Methods

        public bool Save(PFMDTO00032 fReceiptEntity)
        {
            if (!this.ValidateForm(fReceiptEntity))
                return false;
            //try
            //{
            fReceiptEntity.CreatedDate = DateTime.Now;
                if (this.View.FormCaption.Contains("Withdrawal")) //&& CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.AccruedInterest, this.View.Entity.CurrencyCode, CXDMD00008.Payment, "frmTCMVEW00006" }) == DialogResult.OK)
                {
                    //if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.AccruedInterest, this.View.Entity.CurrencyCode, CXDMD00008.Payment, "frmTCMVEW00006" }) == DialogResult.OK)
                    //{
                    //    CXDTO00001 denoData = CXUIScreenTransit.GetData<CXDTO00001>("frmTCMVEW00006");
                    //    //denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                    //    if (denoData == null)
                    //    {

                    //        //Error Occur becoz user don't enter deno but close the form.
                    //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                    //        return false;
                           
                    //    }
                    //    else
                    //    {
                           this.View.VoucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00006, string>(x => x.Withdrawl(fReceiptEntity));
                    //    }
                    //}
                    //else return false;
                }
                else if (this.View.FormCaption.Contains("Transfer"))
                {
                    this.View.VoucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00006, string>(x => x.Transfer(fReceiptEntity, this.View.CledgerInfo));
                }



                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (this.View.FormCaption.Contains("Withdrawal"))
                    {
                        string[] logItemForTlf = new string[35];

                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf[2] = fReceiptEntity.AccountNo;//AcctNo
                        logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fReceiptEntity.CurrencyCode, fReceiptEntity.SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = "CDV";//Status
                        logItemForTlf[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "CS").ToString();//intRate
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByCash) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else if (this.View.FormCaption.Contains("Transfer"))
                    {
                        string[] logItemForTlf1 = new string[35];
                        string[] logItemForTlf2 = new string[35];
                        logItemForTlf1[0] = string.Empty;//GroupNo
                        logItemForTlf1[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf1[2] = fReceiptEntity.AccountNo;//AcctNo
                        logItemForTlf1[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fReceiptEntity.CurrencyCode, fReceiptEntity.SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf1[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf1[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf1[6] = string.Empty;//Cheque
                        logItemForTlf1[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf1[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf1[9] = "TCV";//Status
                        logItemForTlf1[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf1[11] = string.Empty;//Rno
                        logItemForTlf1[12] = string.Empty;//Duration
                        logItemForTlf1[13] = string.Empty;//LasintDate
                        logItemForTlf1[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "TT").ToString();//intRate
                        logItemForTlf1[15] = string.Empty;//Accured
                        logItemForTlf1[16] = string.Empty;//BudenAcc
                        logItemForTlf1[17] = string.Empty;//Draccured
                        logItemForTlf1[18] = string.Empty;//AccuredStatus
                        logItemForTlf1[19] = string.Empty;//ToAccountNo
                        logItemForTlf1[20] = string.Empty;//FirstRno
                        logItemForTlf1[21] = string.Empty;//PoNo
                        logItemForTlf1[22] = string.Empty;//ADate
                        logItemForTlf1[23] = string.Empty;//IDate
                        logItemForTlf1[24] = string.Empty;//ToAcctNo
                        logItemForTlf1[25] = string.Empty;//Income
                        logItemForTlf1[26] = string.Empty;//Budget
                        logItemForTlf1[27] = string.Empty;//FromBranch
                        logItemForTlf1[28] = string.Empty;//ToBranch
                        logItemForTlf1[29] = string.Empty;//Inout
                        logItemForTlf1[30] = string.Empty;//Success
                        logItemForTlf1[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf1[32] = string.Empty;//IncomeType
                        logItemForTlf1[33] = string.Empty;//OtherBank
                        logItemForTlf1[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf1);

                        logItemForTlf2[0] = string.Empty;//GroupNo
                        logItemForTlf2[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf2[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", fReceiptEntity.SourceBranchCode, fReceiptEntity.CurrencyCode);//AcctNo
                        logItemForTlf2[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", fReceiptEntity.SourceBranchCode, fReceiptEntity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf2[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf2[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf2[6] = string.Empty;//Cheque
                        logItemForTlf2[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf2[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf2[9] = "TDV";//Status
                        logItemForTlf2[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf2[11] = string.Empty;//Rno
                        logItemForTlf2[12] = string.Empty;//Duration
                        logItemForTlf2[13] = string.Empty;//LasintDate
                        logItemForTlf2[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "TT").ToString();//intRate
                        logItemForTlf2[15] = string.Empty;//Accured
                        logItemForTlf2[16] = string.Empty;//BudenAcc
                        logItemForTlf2[17] = string.Empty;//Draccured
                        logItemForTlf2[18] = string.Empty;//AccuredStatus
                        logItemForTlf2[19] = string.Empty;//ToAccountNo
                        logItemForTlf2[20] = string.Empty;//FirstRno
                        logItemForTlf2[21] = string.Empty;//PoNo
                        logItemForTlf2[22] = string.Empty;//ADate
                        logItemForTlf2[23] = string.Empty;//IDate
                        logItemForTlf2[24] = string.Empty;//ToAcctNo
                        logItemForTlf2[25] = string.Empty;//Income
                        logItemForTlf2[26] = string.Empty;//Budget
                        logItemForTlf2[27] = string.Empty;//FromBranch
                        logItemForTlf2[28] = string.Empty;//ToBranch
                        logItemForTlf2[29] = string.Empty;//Inout
                        logItemForTlf2[30] = string.Empty;//Success
                        logItemForTlf2[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf2[32] = string.Empty;//IncomeType
                        logItemForTlf2[33] = string.Empty;//OtherBank
                        logItemForTlf2[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf2);
                    }

                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else
                {

                    if (this.View.FormCaption.Contains("Withdrawal"))
                    {
                        string[] logItemForTlf = new string[35];

                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf[2] = fReceiptEntity.AccountNo;//AcctNo
                        logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fReceiptEntity.CurrencyCode, fReceiptEntity.SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = "CDV";//Status
                        logItemForTlf[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "CS").ToString();//intRate
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByCash) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else if (this.View.FormCaption.Contains("Transfer"))
                    {
                        string[] logItemForTlf1 = new string[35];
                        string[] logItemForTlf2 = new string[35];
                        logItemForTlf1[0] = string.Empty;//GroupNo
                        logItemForTlf1[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf1[2] = fReceiptEntity.AccountNo;//AcctNo
                        logItemForTlf1[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fReceiptEntity.CurrencyCode, fReceiptEntity.SourceBranchCode, true });//ACode(from COASetUp)
                        logItemForTlf1[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf1[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf1[6] = string.Empty;//Cheque
                        logItemForTlf1[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf1[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf1[9] = "TCV";//Status
                        logItemForTlf1[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf1[11] = string.Empty;//Rno
                        logItemForTlf1[12] = string.Empty;//Duration
                        logItemForTlf1[13] = string.Empty;//LasintDate
                        logItemForTlf1[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "TT").ToString();//intRate
                        logItemForTlf1[15] = string.Empty;//Accured
                        logItemForTlf1[16] = string.Empty;//BudenAcc
                        logItemForTlf1[17] = string.Empty;//Draccured
                        logItemForTlf1[18] = string.Empty;//AccuredStatus
                        logItemForTlf1[19] = string.Empty;//ToAccountNo
                        logItemForTlf1[20] = string.Empty;//FirstRno
                        logItemForTlf1[21] = string.Empty;//PoNo
                        logItemForTlf1[22] = string.Empty;//ADate
                        logItemForTlf1[23] = string.Empty;//IDate
                        logItemForTlf1[24] = string.Empty;//ToAcctNo
                        logItemForTlf1[25] = string.Empty;//Income
                        logItemForTlf1[26] = string.Empty;//Budget
                        logItemForTlf1[27] = string.Empty;//FromBranch
                        logItemForTlf1[28] = string.Empty;//ToBranch
                        logItemForTlf1[29] = string.Empty;//Inout
                        logItemForTlf1[30] = string.Empty;//Success
                        logItemForTlf1[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf1[32] = string.Empty;//IncomeType
                        logItemForTlf1[33] = string.Empty;//OtherBank
                        logItemForTlf1[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf1);

                        logItemForTlf2[0] = string.Empty;//GroupNo
                        logItemForTlf2[1] = this.View.VoucherNo;//EntryNo
                        logItemForTlf2[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", fReceiptEntity.SourceBranchCode, fReceiptEntity.CurrencyCode);//AcctNo
                        logItemForTlf2[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("FACCRUINT", fReceiptEntity.SourceBranchCode, fReceiptEntity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf2[4] = fReceiptEntity.AccuredInterest.ToString();//LocalAmount
                        logItemForTlf2[5] = fReceiptEntity.CurrencyCode;//SourceCur
                        logItemForTlf2[6] = string.Empty;//Cheque
                        logItemForTlf2[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf2[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fReceiptEntity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf2[9] = "TDV";//Status
                        logItemForTlf2[10] = fReceiptEntity.SourceBranchCode;//SourceBr
                        logItemForTlf2[11] = string.Empty;//Rno
                        logItemForTlf2[12] = string.Empty;//Duration
                        logItemForTlf2[13] = string.Empty;//LasintDate
                        logItemForTlf2[14] = CXCOM00010.Instance.GetExchangeRate(fReceiptEntity.CurrencyCode, "TT").ToString();//intRate
                        logItemForTlf2[15] = string.Empty;//Accured
                        logItemForTlf2[16] = string.Empty;//BudenAcc
                        logItemForTlf2[17] = string.Empty;//Draccured
                        logItemForTlf2[18] = string.Empty;//AccuredStatus
                        logItemForTlf2[19] = string.Empty;//ToAccountNo
                        logItemForTlf2[20] = string.Empty;//FirstRno
                        logItemForTlf2[21] = string.Empty;//PoNo
                        logItemForTlf2[22] = string.Empty;//ADate
                        logItemForTlf2[23] = string.Empty;//IDate
                        logItemForTlf2[24] = string.Empty;//ToAcctNo
                        logItemForTlf2[25] = string.Empty;//Income
                        logItemForTlf2[26] = string.Empty;//Budget
                        logItemForTlf2[27] = string.Empty;//FromBranch
                        logItemForTlf2[28] = string.Empty;//ToBranch
                        logItemForTlf2[29] = string.Empty;//Inout
                        logItemForTlf2[30] = string.Empty;//Success
                        logItemForTlf2[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf2[32] = string.Empty;//IncomeType
                        logItemForTlf2[33] = string.Empty;//OtherBank
                        logItemForTlf2[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Interest Withdrawl(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf2);
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00051, new object[] { "Voucher No", this.View.VoucherNo });
                    return true;
                }
            //}
            //catch (Exception ex)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
            //    return false;
            //}
        }

        public void PRN_FilePrinting(string accountNo)
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                printingList = new List<string[]>();
                string[] list;

                list = new string[] { accountNo };

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list);

                foreach (PFMDTO00043 prnFile in PintFileList)
                {
                    string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { accountNo });

                CXCLE00005.Instance.StartLineNo = PintFileList[0].PrintLineNo == 0 ? 1 : Convert.ToInt32(PintFileList[0].PrintLineNo);
                printedLine = CXCLE00005.Instance.StartLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(accountNo, printedLine,CurrentUserEntity.CurrentUserID))
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
            }
            catch
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        public void FPRN_FilePrinting(string accountNo)
        {
            try
            {
                IList<PFMDTO00058> PintFileList = new List<PFMDTO00058>();
                printingList = new List<string[]>();
                string[] list;

                list = new string[] { accountNo };

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForFixedAccounts(list);

                foreach (PFMDTO00058 prnFile in PintFileList)
                {
                    string[] prnFileStrArr = { prnFile.CreatedDate.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { accountNo });

                CXCLE00005.Instance.StartLineNo = PintFileList[0].lineNo == 0 ? 1 : PintFileList[0].lineNo;
                printedLine = CXCLE00005.Instance.StartLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true,out printedLine);

                if (!CXCLE00006.Instance.UpdateAfterPrintingForFixed(accountNo, printedLine,CurrentUserEntity.CurrentUserID))
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        #endregion

    }
}
