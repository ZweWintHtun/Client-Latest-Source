using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00139:AbstractPresenter,IMNMCTL00139
    {
        #region View 
        private IMNMVEW00139 view;
        public IMNMVEW00139 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00139 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCashDenoData());
            }
        }

        #endregion

        #region Variable
        private MNMDTO00055 RawInformationList { get; set; }
        #endregion
        #region Methods

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }        


        private TLMDTO00015 GetCashDenoData()
        {
            TLMDTO00015 cashdenodto = new TLMDTO00015();
            cashdenodto.TlfEntryNo = this.view.TlfEntryNo;
            return cashdenodto;
        }
         
        private MNMDTO00055 GetCustomerInformation(string eno, bool isMulti)
        {
            MNMDTO00055 InformationData = new MNMDTO00055();
            InformationData = CXClientWrapper.Instance.Invoke<IMNMSVE00139, MNMDTO00055>(x => x.GetInformationList(eno, CurrentUserEntity.BranchCode, isMulti));
            
            return InformationData;
        }        

        public void Update()
        {
            //if (this.ValidateForm(this.view.TlfEntryNo))
            //{
                if (CXUIScreenTransit.Transit("frmTLMVEW00011", new object[] { this.RawInformationList.CashDenoDto.Amount, this.RawInformationList.CashDenoDto.Currency, (this.RawInformationList.CashDenoDto.Status.Equals("R")) ? CXDMD00008.Received : CXDMD00008.Payment, (this.View.IsMulti) ? "frmCashDenoEdit.Multi" : "frmCashDenoEdit.Indi" }) == DialogResult.OK)
                {
                    CXDTO00001 denostringDto = CXUIScreenTransit.GetData<CXDTO00001>((this.View.IsMulti) ? "frmCashDenoEdit.Multi" : "frmCashDenoEdit.Indi");
                    this.RawInformationList.CashDenoDto.DenoDetail = denostringDto.DenoString;
                    this.RawInformationList.CashDenoDto.DenoRate = denostringDto.DenoRateString;
                    this.RawInformationList.CashDenoDto.DenoRefundDetail = denostringDto.RefundString;
                    this.RawInformationList.CashDenoDto.DenoRefundRate = denostringDto.RefundRateString;
                    this.RawInformationList.CashDenoDto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    this.RawInformationList.CashDenoDto.AdjustAmount = denostringDto.AdjustAmount;
                    string Tlf_Eno = CXClientWrapper.Instance.Invoke<IMNMSVE00139, string>(x => x.SaveCashDenoEdit(this.View.TlfEntryNo, this.RawInformationList.CashDenoDto));
                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = Tlf_Eno;//Tlf_Eno
                        logItemForDeno[1] = this.RawInformationList.CashDenoDto.AccountType;//AcType
                        logItemForDeno[2] = this.RawInformationList.CashDenoDto.FromType;//FromType
                        logItemForDeno[3] = this.RawInformationList.CashDenoDto.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = this.RawInformationList.CashDenoDto.DenoDetail;//Deno_Detail
                        logItemForDeno[6] = this.RawInformationList.CashDenoDto.DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = this.RawInformationList.CashDenoDto.Status;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = this.RawInformationList.CashDenoDto.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = this.RawInformationList.CashDenoDto.Currency;//cur
                        logItemForDeno[11] = this.RawInformationList.CashDenoDto.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.RawInformationList.CashDenoDto.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.RawInformationList.CashDenoDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        if ((this.View.IsMulti))
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Cash Denomination Edit(Multiple) Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                        else
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Cash Denomination Edit(Individual) Fail Deno", CurrentUserEntity.BranchCode,
                       logItemForDeno);
                        this.view.MessageShow(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion

                    #region Successful
                    else
                    {
                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = Tlf_Eno;//Tlf_Eno
                        logItemForDeno[1] = this.RawInformationList.CashDenoDto.AccountType;//AcType
                        logItemForDeno[2] = this.RawInformationList.CashDenoDto.FromType;//FromType
                        logItemForDeno[3] = this.RawInformationList.CashDenoDto.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = this.RawInformationList.CashDenoDto.DenoDetail;//Deno_Detail
                        logItemForDeno[6] = this.RawInformationList.CashDenoDto.DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = this.RawInformationList.CashDenoDto.Status;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = this.RawInformationList.CashDenoDto.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = this.RawInformationList.CashDenoDto.Currency;//cur
                        logItemForDeno[11] = this.RawInformationList.CashDenoDto.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.RawInformationList.CashDenoDto.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.RawInformationList.CashDenoDto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        if ((this.View.IsMulti))
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Cash Denomination Edit(Multiple) Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                        else
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Cash Denomination Edit(Individual) Commit Deno", CurrentUserEntity.BranchCode,
                       logItemForDeno);
                        this.view.MessageShow(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion
                    this.CleanUIControlData();
                    this.View.FocusTlfEntryTextBox();
                    this.SetEnableDisable("txtEntryNo", true);
                }
            //}
            //else
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027);   //Invalid Entry No
            //}
        }

        //Added by HMW at 13-08-2019 : [Seperating EOD Process] To show system date (not PC date) at UI
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        #endregion

        #region UIControlValidation

        public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                RawInformationList = this.GetCustomerInformation(this.View.TlfEntryNo, this.View.IsMulti);   //  TLFEntryNo
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.TlfEntryNo });
                    return;
                }
                if (this.View.IsMulti)
                {
                    if (RawInformationList.InformationList.Count == 0)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027);   //Invalid Entry No
                        return;
                    }
                    this.View.MultiAmount = RawInformationList.CashDenoDto.Amount;
                    
                    if (!RawInformationList.InformationList[0].AccountNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerAccountTypeLength))))
                        this.View.MultiNonCustomerGridChange(false);
                    else
                        this.View.MultiNonCustomerGridChange(true);
                    
                    this.View.BindGridView(RawInformationList.InformationList);
                }
                else
                {
                    this.View.IndividualAmount = RawInformationList.CashDenoDto.Amount;
                    this.View.CustomerName = RawInformationList.InformationList[0].Name;
                    this.View.Narration = RawInformationList.InformationList[0].Narration;
                    this.View.NRC = RawInformationList.InformationList[0].NRC;
                    this.View.AccountType = RawInformationList.InformationList[0].AccountNo;
                    this.SetEnableDisable("txtEntryNo",false);
                }
            }
        }
       
        #endregion

        #region UI Control Logic
        public void CleanUIControlData()
        {
            this.View.TlfEntryNo = string.Empty;
            this.View.MultiAmount = 0;
            this.View.AccountType = string.Empty;
            this.View.CustomerName = string.Empty;
            this.View.NRC = string.Empty;
            this.View.Narration = string.Empty;
            this.View.IndividualAmount = 0;
            this.View.BindGridView(null);
        }
        #endregion
    }
}
