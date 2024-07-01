using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00063 : AbstractPresenter, ITCMCTL00063
    {
        #region Prorerties
        
        private ITCMVEW00063 view;
        public ITCMVEW00063 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        public PFMDTO00028 cledgerinfo { get; set; }

        private void WireTo(ITCMVEW00063 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.Dep_TlFEntity);
            }
        }

        #endregion

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.CurrencyCode))
                return;
            else
                this.View.DisableControlsforView("CurrenyCode.Disable");
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.View.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2 || accountType == CXDMD00011.DomesticAccountType))
                {
                    if (accountType != CXDMD00011.DomesticAccountType)
                    {                        
                        cledgerinfo = CXClientWrapper.Instance.Invoke<ITCMSVE00063, PFMDTO00028>(x => x.AccountCheck(this.View.AccountNo, this.View.CurrencyCode));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            switch (message)
                            {
                                case "MV00086": this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.CurrencyCode }); //Currency of this account should be {0}.
                                    break;
                                case "MV00201": this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.AccountNo }); //Account No {0} has been closed.
                                    break;
                                default:
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                                    break;
                            }
                        }
                        else
                        {
                            this.View.AccountName = this.View.AccountName+ "  " +cledgerinfo.Customer.Name;
                            this.View.DisableControlsforView("AccountNo.Disable");
                            this.View.SourceBranchCode = CurrentUserEntity.BranchCode;
                        }
                    }
                    else //for DomesticAccountType
                    {
                        string coaSetupName = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.SelectByAccountNo", new object[] { this.view.AccountNo,this.view.CurrencyCode, CXCOM00007.Instance.BranchCode, true });                       
                        this.View.AccountName = this.View.AccountName+ "  " +coaSetupName;
                        this.View.DisableControlsforView("AccountNo.Disable");
                        this.View.SourceBranchCode = CurrentUserEntity.BranchCode;
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            
            if (e.HasXmlBaseError)
                return;
            else
            {
                if(this.View.Status == "Update")
                {
                    this.view.TotalAccumulateAmount = this.View.initialAmount + this.View.Amount;
                    this.View.AccumulateAmount = this.View.TotalAccumulateAmount;

                }
                else
                {
                    this.view.TotalAccumulateAmount = this.view.initialAmount;
                    this.View.TotalAccumulateAmount = this.View.TotalAccumulateAmount + this.View.Amount;
                    this.View.AccumulateAmount = this.View.TotalAccumulateAmount;
                }
            }
            //this.view.initialAmount = this.view.TotalAccumulateAmount;
        }

        public bool ValidateAdd()
        {
            return this.ValidateForm(this.View.Dep_TlFEntity);
        }

        public bool Save()
        {
            if (this.View.Status != "Add")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170);
                return false;
            }
            else if (this.View.Dep_TLFCollection.Count == 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);
                return false;
            }
            else
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.TotalAccumulateAmount, this.View.CurrencyCode, CXDMD00008.Received, "frmTLMVEW00011" }) == DialogResult.OK)
                {
                    string VoucherNo = string.Empty;
                    CXDTO00002 rateinfo = CXCLE00011.Instance.GetDenoExchangeRateString(this.View.CurrencyCode, CurrentUserEntity.BranchCode, "CS");

                    this.View.DenoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00011");
                    TLMDTO00038 depositentity=GetDepositInfo(rateinfo);
                    if (depositentity == null) return false;
                    
                    VoucherNo = CXClientWrapper.Instance.Invoke<ITCMSVE00063, string>(x => x.Save(this.View.Dep_TLFCollection, depositentity));
                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForDeno = new string[14];
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Deno
                        logItemForDeno[0] = VoucherNo;//Tlf_Eno
                        logItemForDeno[1] = depositentity.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = depositentity.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = depositentity.DenoString;//Deno_Detail
                        logItemForDeno[6] = depositentity.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = depositentity.FromBranchCode;//sourcebr
                        logItemForDeno[10] = depositentity.Currency;//cur
                        logItemForDeno[11] = depositentity.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositentity.FromBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = depositentity.HomeExchangeRate.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Group Cash Deposit Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);

                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = VoucherNo;//EntryNo
                        logItemForTlf[2] = depositentity.AccountNo;//AcctNo
                        if (depositentity.AccountSign != null)
                        {
                            if (depositentity.AccountSign.Length > 0)
                            {
                                switch (depositentity.AccountSign[0])
                                {
                                    case 'C':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'S':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'L':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'F':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;
                                }
                            }
                            //}
                        }
                        else
                        {
                            logItemForTlf[3] = depositentity.AccountNo;//ACode(from COASetUp)
                        }
                        logItemForTlf[4] = depositentity.Amount.ToString();//LocalAmount
                        logItemForTlf[5] = depositentity.Currency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositentity.FromBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = "CCD";//Status
                        logItemForTlf[10] = depositentity.FromBranchCode;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = depositentity.HomeExchangeRate.ToString();//intRate
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Group Cash Deposit Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return false;
                    }
                    #endregion

                    #region Successful
                    else
                    {
                        string[] logItemForDeno = new string[14];
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Deno
                        logItemForDeno[0] = VoucherNo;//Tlf_Eno
                        logItemForDeno[1] = depositentity.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = depositentity.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = depositentity.DenoString;//Deno_Detail
                        logItemForDeno[6] = depositentity.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = depositentity.FromBranchCode;//sourcebr
                        logItemForDeno[10] = depositentity.Currency;//cur
                        logItemForDeno[11] = depositentity.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositentity.FromBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = depositentity.HomeExchangeRate.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Group Cash Deposit Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);

                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = VoucherNo;//EntryNo
                        logItemForTlf[2] = depositentity.AccountNo;//AcctNo
                        if (depositentity.AccountSign != null)
                        {
                            if (depositentity.AccountSign.Length > 0)
                            {
                                switch (depositentity.AccountSign[0])
                                {
                                    case 'C':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'S':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'L':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;

                                    case 'F':
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), depositentity.BranchCode, depositentity.Currency);//ACode(from COASetUp)
                                        break;
                                }
                            }
                            //}
                        }
                        else
                        {
                            logItemForTlf[3] = depositentity.AccountNo;//ACode(from COASetUp)
                        }
                        logItemForTlf[4] = depositentity.Amount.ToString();//LocalAmount
                        logItemForTlf[5] = depositentity.Currency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), depositentity.FromBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = depositentity.FromBranchCode;//SourceBr
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
                        logItemForTlf[33] = string.Empty;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Group Cash Deposit Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.view.Successful(CXMessage.MI00051, "Voucher No", VoucherNo);
                        return true;
                    }
                    #endregion

                }
            }
            return false;
        }

        public void ClearControls(bool isGird)
        {
            if (isGird)
            {
                //this.View.CurrencyCode = string.Empty;
                this.View.Dep_TLFCollection.Clear();
                this.View.BindData();
                this.View.AccountNo = string.Empty;                
                this.View.AccountName = "AccountName : ";
                this.View.EnableControlsforView("AccountNo.Enable");
                this.View.EnableControlsforView("Curreny.Enable");
                this.View.TotalAccumulateAmount = 0;
                View.SetCursor("CurrencyCode");    
            }
            this.View.CustomerName = string.Empty;        
            this.View.Quota = 0;
            this.View.Quantity = 0;
            this.View.Amount = 0;
            this.View.AccumulateAmount = 0;            
            this.View.DepositCode = string.Empty;
            this.View.DepositCodeDesp=string.Empty;
            this.View.Status = "Add";
            
            this.ClearErrors();
        }

        private TLMDTO00038 GetDepositInfo(CXDTO00002 rateinfo)
        {
            TLMDTO00038 depositentity = new TLMDTO00038();
            depositentity.AccountNo = this.View.AccountNo;
            if (cledgerinfo != null)
                depositentity.AccountSign = cledgerinfo.AccountSign;
            else
                depositentity.AccountSign = null;
            depositentity.Amount = this.View.TotalAccumulateAmount;
            depositentity.Name = string.Empty;
            depositentity.AdjustAmount = this.View.DenoInfo.AdjustAmount;
            depositentity.CounterNo = this.View.DenoInfo.CounterNo;
            depositentity.BranchCode = CurrentUserEntity.BranchCode;
            depositentity.Currency = this.View.CurrencyCode;
            depositentity.HomeExchangeRate = Convert.ToDecimal(rateinfo.ExchangeRateString);
            depositentity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel); ;
            depositentity.FromBranchCode = CurrentUserEntity.BranchCode;
            depositentity.DenoRate = this.View.DenoInfo.DenoRateString;
            depositentity.DenoString = this.View.DenoInfo.DenoString;
            depositentity.RefundRate = this.View.DenoInfo.RefundRateString;
            depositentity.RefundString = this.View.DenoInfo.RefundString;          
            depositentity.CreatedDate = System.DateTime.Now;
            depositentity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            depositentity.UpdatedDate = System.DateTime.Now;
            depositentity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            return depositentity;
        }
    }
}
