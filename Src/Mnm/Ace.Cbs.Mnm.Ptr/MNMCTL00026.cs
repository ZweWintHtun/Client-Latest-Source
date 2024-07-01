using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00026:AbstractPresenter,IMNMCTL00026
    {
        #region View
        private IMNMVEW00026 view;
        public IMNMVEW00026 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00026 view)
        {
            if (this.view == null)
            {
                this.view = view;
                TLMDTO00001 entity = this.GetEntity();
                this.Initialize(this.view, entity);
            }
        }
        string currency = string.Empty;
        string ACsign = string.Empty;
        public IList<PFMDTO00054> TLFList { get; set; }
        #endregion

        public void Save()
        {
            TLMDTO00001 entity = this.GetEntity();
            if (this.ValidateForm(entity))
            {
                entity.CreatedDate = DateTime.Now;
                if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty && entity.ToAccountNo.Substring(0, 2) == "IR")
                {
                    entity.DebitACode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "IBSIR", entity.Currency, entity.SourceBranchCode, true });
                    entity.DebitACodeName = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(entity.DebitACode, entity.SourceBranchCode);
                    entity.CreditACode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "POR", entity.Currency, entity.SourceBranchCode, true });
                    entity.CreditACodeName = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(entity.CreditACode, entity.SourceBranchCode);
                 
                }
                else if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty && entity.ToAccountNo.Substring(0, 2) != "IR")
                {
                    entity.DebitACode = CXCLE00013.Instance.GetRemittanceAccountCode(entity.Ebank, entity.Currency, entity.SourceBranchCode, CXDMD00006.Encash).EncashAccount;
                    entity.DebitACodeName = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { entity.DebitACode, entity.SourceBranchCode }).AccountName;
                    entity.CreditACode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), entity.Currency, CurrentUserEntity.BranchCode, true });
                    entity.CreditACodeName = entity.ToName;
                    entity.BankName = CXCLE00002.Instance.GetScalarObject<string>("Branch.Client.Alias.Select", new object[] { entity.Ebank, true });
                    entity.UserNo = CurrentUserEntity.CurrentUserName;

                }
                  // CXClientWrapper.Instance.Invoke<IMNMSVE00026>(x => x.Save(entity));
                TLFList = CXClientWrapper.Instance.Invoke<IMNMSVE00026, IList<PFMDTO00054>>(x => x.Save(entity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {

                    for (int i = 0; i < TLFList.Count(); i++)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.view.RegisterNo;//EntryNo
                        logItemForTlf[2] = TLFList[i].AccountNo;//AcctNo
                        logItemForTlf[3] = TLFList[i].Acode; //Acode
                        logItemForTlf[4] = TLFList[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = TLFList[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = TLFList[i].Status;//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = TLFList[i].Eno;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = TLFList[i].PaymentOrderNo;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = entity.ToAccountNo;//ToAcctNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RE Important Data Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);

                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    for (int i = 0; i < TLFList.Count(); i++)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.view.RegisterNo;//EntryNo
                        logItemForTlf[2] = TLFList[i].AccountNo;//AcctNo
                        logItemForTlf[3] = TLFList[i].Acode; //Acode
                        logItemForTlf[4] = TLFList[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = TLFList[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = TLFList[i].Status;//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = TLFList[i].Eno;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = TLFList[i].PaymentOrderNo;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = string.Empty;//IDate
                        logItemForTlf[24] = entity.ToAccountNo;//ToAcctNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RE Important Data Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);


                    }

                    CXUIMessageUtilities.ShowMessageByCode("MI90002");  //Update Successful
                    this.View.ClearControls();
                }
            }
        }

        public void Delete()
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)
            {
                TLMDTO00001 entity = this.GetEntity();
                CXClientWrapper.Instance.Invoke<IMNMSVE00026>(x => x.Delete(entity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90003");  //Delete Successful
                    this.View.ClearControls();
                }
            }
        }

        public void mtxtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                TLMDTO00001 reInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00026, TLMDTO00001>(x => x.GetReInfo(View.RegisterNo, CurrentUserEntity.BranchCode));
                 if  (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.view.SetFocus();                                      
                }                      
                else
                {
                    if (reInfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), "MV00168");    //Invalid Register No.
                        this.view.SetFocus(); 
                    }
                    else if (reInfo.Date_Time.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30017);
                        this.view.SetFocus();
                        return;
                    } 
                    else
                    {
                            currency = reInfo.Currency;
                            ACsign = reInfo.AccountSign;
                        this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), string.Empty);
                        //this.view.EnableControl(true);
                        if (!this.View.SaveStatus)
                            this.ShowData(reInfo);
                        this.view.disablecontrol();
                        //this.view.ReadOnlyControl();
                        
                    }
                }

            }
        }

        private TLMDTO00001 GetEntity()
        {
            TLMDTO00001 entity = new TLMDTO00001();
            entity.RegisterNo = View.RegisterNo;
            entity.Ebank = View.DraweeBank;
            entity.ToAccountNo = View.PayeeAccountNo;
            entity.ToName = View.PayeeName;
            entity.ToNRC = View.PayeeNRC;
            entity.ToAddress = View.PayeeAddress;
            entity.ToPhoneNo = View.PayeePhoneNo;
            entity.Name = View.RemitterName;
            entity.NRC = View.RemitterNRC;
            entity.PhoneNo = View.RemitterPhoneNo;
            entity.Amount = View.Amount;
            entity.Currency = currency;
            entity.AccountSign = ACsign;
            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            return entity;
        }

        private void ShowData(TLMDTO00001 reInfo)
        {
            View.DraweeBank = reInfo.Ebank;
            View.PayeeAccountNo = reInfo.ToAccountNo;
            View.PayeeName = reInfo.ToName;
            View.PayeeNRC = reInfo.ToNRC;
            View.PayeeAddress = reInfo.ToAddress;
            View.PayeePhoneNo = reInfo.ToPhoneNo;
            View.RemitterName = reInfo.Name;
            View.RemitterNRC = reInfo.NRC;
            View.RemitterPhoneNo = reInfo.PhoneNo;
            View.Amount = reInfo.Amount;
            View.OldAmount = reInfo.Amount;
            if (reInfo.ToAccountNo != null && reInfo.ToAccountNo.ToString() != string.Empty && reInfo.ToAccountNo.Substring(0, 2) == "IR")
            {
                if (((reInfo.IssueDate == null || reInfo.IssueDate == default(DateTime)) || (reInfo.IssueDate.Value.ToShortDateString() == DateTime.Today.ToShortDateString())) && (reInfo.IsNullPOIDate))
                {
                    View.SaveDeleteButtonEnableDisable(true);
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90071);  //PO is already refund."\n" Sorry,it is not allowed to edit."\n" Please PO Refund Reversal first.
                    View.SaveDeleteButtonEnableDisable(false);
                }
            }
            else
            {
                View.SaveDeleteButtonEnableDisable(true);
            }

        }
    }
}
