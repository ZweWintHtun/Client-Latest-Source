using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00005 : AbstractPresenter, ITCMCTL00005
    {
        #region Form Initializer

        private ITCMVEW00005 view;
        public ITCMVEW00005 View
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

        private void WireTo(ITCMVEW00005 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.Entity);
            }
        }

        int printedLine;
        List<string[]> printingList;
        string voucherNo;
        PFMDTO00016 saofEntity;

        #endregion
        
        #region Main Methods

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError)
                return;
            try
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.View.AccountNo, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV20054); // invalid Account Type
                    else
                    {
                        saofEntity = CXClientWrapper.Instance.Invoke<ITCMSVE00005, PFMDTO00016>(x => x.SelectByAccountNumber(this.View.AccountNo,CurrentUserEntity.BranchCode,DateTime.Now));

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00091")
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { CurrentUserEntity.BranchCode });
                            else
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.View.Amount = saofEntity.AccruedInterest;
                            this.View.Entity = saofEntity;
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

        public bool Save(PFMDTO00016 entity)
        {
            if (!this.ValidateForm(entity))
                return false;
            //try
            //{
            entity.CreatedDate = DateTime.Now;
                if (this.View.FormCaption.Contains("Withdrawal"))
                {
                    //CXDTO00001 denoData = CXUIScreenTransit.GetData<CXDTO00001>("frmTCMVEW00005");
                    //entity = this.GetDenoData(denoData, entity);
                    voucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00005, string>(x => x.Withdrawal(entity));
                }
                else if (this.View.FormCaption.Contains("Transfer"))
                {
                    voucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00005, string>(x => x.Transfer(entity));
                }
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred || string.IsNullOrEmpty(voucherNo))
                {
                    if (this.View.FormCaption.Contains("Withdrawal"))
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucherNo;//EntryNo
                        logItemForTlf[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//AcctNo
                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = "CDV";//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = "C";//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = string.Empty;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = string.Empty;//IncomeType
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Cash) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else if (this.View.FormCaption.Contains("Transfer"))
                    {
                        string[] logItemForTlf_Debit = new string[35];
                        //ClientLog For Tlf_Debit
                        logItemForTlf_Debit[0] = string.Empty;//GroupNo
                        logItemForTlf_Debit[1] = voucherNo;//EntryNo
                        logItemForTlf_Debit[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//AcctNo
                        logItemForTlf_Debit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf_Debit[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf_Debit[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf_Debit[6] = string.Empty;//Cheque
                        logItemForTlf_Debit[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_Debit[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf_Debit[9] = "TDV";//Status
                        logItemForTlf_Debit[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf_Debit[11] = string.Empty;//Rno
                        logItemForTlf_Debit[12] = string.Empty;//Duration
                        logItemForTlf_Debit[13] = string.Empty;//LasintDate
                        logItemForTlf_Debit[14] = string.Empty;//intRate
                        logItemForTlf_Debit[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf_Debit[16] = string.Empty;//BudenAcc
                        logItemForTlf_Debit[17] = string.Empty;//Draccured
                        logItemForTlf_Debit[18] = "C";//AccuredStatus
                        logItemForTlf_Debit[19] = string.Empty;//ToAccountNo
                        logItemForTlf_Debit[20] = string.Empty;//FirstRno
                        logItemForTlf_Debit[21] = string.Empty;//PoNo
                        logItemForTlf_Debit[22] = string.Empty;//ADate
                        logItemForTlf_Debit[23] = string.Empty;//IDate
                        logItemForTlf_Debit[24] = string.Empty;//ToAcctNo
                        logItemForTlf_Debit[25] = string.Empty;//Income
                        logItemForTlf_Debit[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf_Debit[27] = string.Empty;//FromBranch
                        logItemForTlf_Debit[28] = string.Empty;//ToBranch
                        logItemForTlf_Debit[29] = string.Empty;//Inout
                        logItemForTlf_Debit[30] = string.Empty;//Success
                        logItemForTlf_Debit[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_Debit[32] = string.Empty;//IncomeType
                        logItemForTlf_Debit[33] = string.Empty;//OtherBank
                        logItemForTlf_Debit[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_Debit);

                        string[] logItemForTlf_Credit = new string[35];
                        //ClientLog For Tlf_Credit
                        logItemForTlf_Credit[0] = string.Empty;//GroupNo
                        logItemForTlf_Credit[1] = voucherNo;//EntryNo
                        logItemForTlf_Credit[2] = entity.AccountNo;//AcctNo
                        switch (entity.AccountSign[0])
                        {
                            case 'C':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'S':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'L':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'F':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;
                        }
                        logItemForTlf_Credit[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf_Credit[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf_Credit[6] = string.Empty;//Cheque
                        logItemForTlf_Credit[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_Credit[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf_Credit[9] = "TCV";//Status
                        logItemForTlf_Credit[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf_Credit[11] = string.Empty;//Rno
                        logItemForTlf_Credit[12] = string.Empty;//Duration
                        logItemForTlf_Credit[13] = string.Empty;//LasintDate
                        logItemForTlf_Credit[14] = string.Empty;//intRate
                        logItemForTlf_Credit[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf_Credit[16] = string.Empty;//BudenAcc
                        logItemForTlf_Credit[17] = string.Empty;//Draccured
                        logItemForTlf_Credit[18] = "C";//AccuredStatus
                        logItemForTlf_Credit[19] = string.Empty;//ToAccountNo
                        logItemForTlf_Credit[20] = string.Empty;//FirstRno
                        logItemForTlf_Credit[21] = string.Empty;//PoNo
                        logItemForTlf_Credit[22] = string.Empty;//ADate
                        logItemForTlf_Credit[23] = string.Empty;//IDate
                        logItemForTlf_Credit[24] = string.Empty;//ToAcctNo
                        logItemForTlf_Credit[25] = string.Empty;//Income
                        logItemForTlf_Credit[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf_Credit[27] = string.Empty;//FromBranch
                        logItemForTlf_Credit[28] = string.Empty;//ToBranch
                        logItemForTlf_Credit[29] = string.Empty;//Inout
                        logItemForTlf_Credit[30] = string.Empty;//Success
                        logItemForTlf_Credit[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_Credit[32] = string.Empty;//IncomeType
                        logItemForTlf_Credit[33] = string.Empty;//OtherBank
                        logItemForTlf_Credit[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_Credit);
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                #endregion

                #region Successful
                else
                {
                    if (this.View.FormCaption.Contains("Withdrawal"))
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucherNo;//EntryNo
                        logItemForTlf[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//AcctNo
                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = "CDV";//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = "C";//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = string.Empty;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = string.Empty;//IncomeType
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Cash) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else if (this.View.FormCaption.Contains("Transfer"))
                    {
                        string[] logItemForTlf_Debit= new string[35];
                        //ClientLog For Tlf_Debit
                        logItemForTlf_Debit[0] = string.Empty;//GroupNo
                        logItemForTlf_Debit[1] = voucherNo;//EntryNo
                        logItemForTlf_Debit[2] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//AcctNo
                        logItemForTlf_Debit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo("ACCRUEDINT", entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                        logItemForTlf_Debit[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf_Debit[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf_Debit[6] = string.Empty;//Cheque
                        logItemForTlf_Debit[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_Debit[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf_Debit[9] = "TDV";//Status
                        logItemForTlf_Debit[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf_Debit[11] = string.Empty;//Rno
                        logItemForTlf_Debit[12] = string.Empty;//Duration
                        logItemForTlf_Debit[13] = string.Empty;//LasintDate
                        logItemForTlf_Debit[14] = string.Empty;//intRate
                        logItemForTlf_Debit[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf_Debit[16] = string.Empty;//BudenAcc
                        logItemForTlf_Debit[17] = string.Empty;//Draccured
                        logItemForTlf_Debit[18] = "C";//AccuredStatus
                        logItemForTlf_Debit[19] = string.Empty;//ToAccountNo
                        logItemForTlf_Debit[20] = string.Empty;//FirstRno
                        logItemForTlf_Debit[21] = string.Empty;//PoNo
                        logItemForTlf_Debit[22] = string.Empty;//ADate
                        logItemForTlf_Debit[23] = string.Empty;//IDate
                        logItemForTlf_Debit[24] = string.Empty;//ToAcctNo
                        logItemForTlf_Debit[25] = string.Empty;//Income
                        logItemForTlf_Debit[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf_Debit[27] = string.Empty;//FromBranch
                        logItemForTlf_Debit[28] = string.Empty;//ToBranch
                        logItemForTlf_Debit[29] = string.Empty;//Inout
                        logItemForTlf_Debit[30] = string.Empty;//Success
                        logItemForTlf_Debit[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_Debit[32] = string.Empty;//IncomeType
                        logItemForTlf_Debit[33] = string.Empty;//OtherBank
                        logItemForTlf_Debit[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_Debit);

                        string[] logItemForTlf_Credit = new string[35];
                        //ClientLog For Tlf_Credit
                        logItemForTlf_Credit[0] = string.Empty;//GroupNo
                        logItemForTlf_Credit[1] = voucherNo;//EntryNo
                        logItemForTlf_Credit[2] = entity.AccountNo;//AcctNo
                        switch (entity.AccountSign[0])
                        {
                            case 'C':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'S':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'L':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;

                            case 'F':
                                logItemForTlf_Credit[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), entity.SourceBranchCode, entity.CurrencyCode);//ACode(from COASetUp)
                                break;
                        }
                        logItemForTlf_Credit[4] = entity.AccruedInterest.ToString();//LocalAmount
                        logItemForTlf_Credit[5] = entity.CurrencyCode;//SourceCur
                        logItemForTlf_Credit[6] = string.Empty;//Cheque
                        logItemForTlf_Credit[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_Credit[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf_Credit[9] = "TCV";//Status
                        logItemForTlf_Credit[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf_Credit[11] = string.Empty;//Rno
                        logItemForTlf_Credit[12] = string.Empty;//Duration
                        logItemForTlf_Credit[13] = string.Empty;//LasintDate
                        logItemForTlf_Credit[14] = string.Empty;//intRate
                        logItemForTlf_Credit[15] = entity.AccruedInterest.ToString();//Accured
                        logItemForTlf_Credit[16] = string.Empty;//BudenAcc
                        logItemForTlf_Credit[17] = string.Empty;//Draccured
                        logItemForTlf_Credit[18] = "C";//AccuredStatus
                        logItemForTlf_Credit[19] = string.Empty;//ToAccountNo
                        logItemForTlf_Credit[20] = string.Empty;//FirstRno
                        logItemForTlf_Credit[21] = string.Empty;//PoNo
                        logItemForTlf_Credit[22] = string.Empty;//ADate
                        logItemForTlf_Credit[23] = string.Empty;//IDate
                        logItemForTlf_Credit[24] = string.Empty;//ToAcctNo
                        logItemForTlf_Credit[25] = string.Empty;//Income
                        logItemForTlf_Credit[26] = CXCOM00010.Instance.GetBudgetYear1("BUDSMTH");//Budget
                        logItemForTlf_Credit[27] = string.Empty;//FromBranch
                        logItemForTlf_Credit[28] = string.Empty;//ToBranch
                        logItemForTlf_Credit[29] = string.Empty;//Inout
                        logItemForTlf_Credit[30] = string.Empty;//Success
                        logItemForTlf_Credit[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_Credit[32] = string.Empty;//IncomeType
                        logItemForTlf_Credit[33] = string.Empty;//OtherBank
                        logItemForTlf_Credit[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_Credit);
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00051, new object[] { "Voucher No", voucherNo });
                }
                #endregion
                //}
            //catch (Exception ex)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
            //}
            return true;
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
                    string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("dd/MM/yyyy").Replace('/','-'), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { accountNo });

                CXCLE00005.Instance.StartLineNo = PintFileList[0].PrintLineNo == 0 ? 1 : Convert.ToInt32(PintFileList[0].PrintLineNo);
                printedLine = CXCLE00005.Instance.StartLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(accountNo, printedLine,CurrentUserEntity.CurrentUserID))
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
            }
            catch(Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        #endregion

        #region Helper Methods

        private PFMDTO00016 GetDenoData(CXDTO00001 info, PFMDTO00016 savingData)
        {
            savingData.CounterNo = info.CounterNo;            
            savingData.DenoString = info.DenoString;
            savingData.AdjustAmount = info.AdjustAmount;
            savingData.RefundString = info.RefundString;
            savingData.RefundRate = info.RefundRateString;

            return savingData;
        }

        #endregion

    }
}
