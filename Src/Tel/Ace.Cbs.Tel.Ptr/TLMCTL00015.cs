using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;
namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00015 : AbstractPresenter, ITLMCTL00015
    {

        private ITLMVEW00015 view;
        public ITLMVEW00015 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00015 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        private decimal AdjustAmount { get; set; }


        private TLMDTO00042 GetViewData()
        {
            TLMDTO00042 poEntity = new TLMDTO00042();
            poEntity.Amount = this.view.Amount;
            poEntity.Charges = this.view.Charges;
            poEntity.Currency = this.view.Currency;
            poEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            poEntity.SourceBranch = CurrentUserEntity.BranchCode;
            poEntity.AdjustAmount = this.AdjustAmount;
            //poEntity.CounterNo = CurrentUserEntity.CounterList[0].CounterNo;
            return poEntity;
        }

       
        public IList<TLMDTO00043> POIssueList { get; set; }

        public TLMDTO00043 POIssue;

        private string[] PoNo { get; set; }
        public string CounterType { get; set; }
        public string CounterNo { get; set; }


        #region Main Method


        public void Save(IList<TLMDTO00042> ViewDataList)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.CalculateNetAmount(), this.View.Currency, CXDMD00008.Received, this.View._Name }) == DialogResult.OK)
            {
                CXDTO00001 denoString = CXUIScreenTransit.GetData<CXDTO00001>(View._Name);
                CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType);
                foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
                {
                    if (Info.CounterType == CounterType)
                    {
                        denoString.CounterNo = Info.CounterNo;
                    }
                }
                this.AdjustAmount = denoString.AdjustAmount;
                bool isWithMultiple = (this.View.ViewDataList.Count < 2) ? false : true;

                IList<PFMDTO00054> TLF_List = CXClientWrapper.Instance.Invoke<ITLMSVE00015, IList<PFMDTO00054>>(x => x.SavePOIssueEntry(this.View.ViewDataList, View.isWithIncome, isWithMultiple, denoString));

                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] logItemForDeno = new string[14];
                    string[] logItemForTlf_PO = new string[35];
                    string[] logItemForTlf_Income = new string[35];
                    //ClientLog For Deno
                    if (isWithMultiple)
                        logItemForDeno[0] = TLF_List[0].ReferenceVoucherNo;//Tlf_Eno
                    else
                        logItemForDeno[0] = TLF_List[0].Eno;//Tlf_Eno
                    logItemForDeno[1] = string.Empty;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = denoString.TotalAmount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = denoString.DenoString;//Deno_Detail
                    logItemForDeno[6] = denoString.RefundString;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = this.View.ViewDataList[0].SourceBranch;//sourcebr
                    logItemForDeno[10] = this.View.ViewDataList[0].Currency;//cur
                    logItemForDeno[11] = denoString.DenoRateString;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.ViewDataList[0].SourceBranch).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.ViewDataList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Issue(ByCash) Fail Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                    for (int i = 0; i < TLF_List.Count; i++)
                    {
                        //ClientLog For Tlf
                        if (isWithMultiple)
                        {
                            logItemForTlf_PO[0] = TLF_List[0].ReferenceVoucherNo;//GroupNo                                
                        }
                        else
                        {
                            logItemForTlf_PO[0] = string.Empty;//GroupNo
                        }
                        logItemForTlf_PO[1] = TLF_List[i].Eno;//EntryNo
                        logItemForTlf_PO[2] = TLF_List[i].AccountNo;//AcctNo
                        logItemForTlf_PO[3] = TLF_List[i].TransactionCode;//ACode(from COASetUp)
                        logItemForTlf_PO[4] = TLF_List[i].Amount.ToString();//LocalAmount
                        logItemForTlf_PO[5] = TLF_List[i].Narration;//SourceCur
                        logItemForTlf_PO[6] = string.Empty;//Cheque
                        logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_PO[8] = TLF_List[i].DateTime.ToString();//SettlementDate
                        logItemForTlf_PO[9] = TLF_List[i].Status;//Status
                        logItemForTlf_PO[10] = TLF_List[i].OtherBank;//SourceBr
                        logItemForTlf_PO[11] = string.Empty;//Rno
                        logItemForTlf_PO[12] = string.Empty;//Duration
                        logItemForTlf_PO[13] = string.Empty;//LasintDate
                        logItemForTlf_PO[14] = TLF_List[i].OrgnEno;//intRate
                        logItemForTlf_PO[15] = string.Empty;//Accured
                        logItemForTlf_PO[16] = string.Empty;//BudenAcc
                        logItemForTlf_PO[17] = string.Empty;//Draccured
                        logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                        logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                        logItemForTlf_PO[20] = string.Empty;//FirstRno
                        logItemForTlf_PO[21] = TLF_List[i].PaymentOrderNo;//PoNo
                        logItemForTlf_PO[22] = System.DateTime.Now.ToString();//ADate
                        logItemForTlf_PO[23] = string.Empty;//IDate
                        logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                        logItemForTlf_PO[25] = string.Empty;//Income
                        logItemForTlf_PO[26] = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode).ToString();//Budget
                        logItemForTlf_PO[27] = string.Empty;//FromBranch
                        logItemForTlf_PO[28] = string.Empty;//ToBranch
                        logItemForTlf_PO[29] = string.Empty;//Inout
                        logItemForTlf_PO[30] = string.Empty;//Success
                        logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_PO[32] = string.Empty;//IncomeType
                        logItemForTlf_PO[33] = string.Empty;//OtherBank
                        logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ByCash) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_PO);                     
                    }

                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    string[] logItemForDeno = new string[14];
                    string[] logItemForTlf_PO = new string[35];
                    string[] logItemForTlf_Income = new string[35];
                     //ClientLog For Deno
                    if (isWithMultiple)
                        logItemForDeno[0] = TLF_List[0].ReferenceVoucherNo;//Tlf_Eno
                    else
                        logItemForDeno[0] = TLF_List[0].Eno;//Tlf_Eno
                    logItemForDeno[1] = string.Empty;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = denoString.TotalAmount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = denoString.DenoString;//Deno_Detail
                    logItemForDeno[6] = denoString.RefundString;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = this.View.ViewDataList[0].SourceBranch;//sourcebr
                    logItemForDeno[10] = this.View.ViewDataList[0].Currency;//cur
                    logItemForDeno[11] = denoString.DenoRateString;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.ViewDataList[0].SourceBranch).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.ViewDataList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Issue(ByCash) Commit Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                    for (int i = 0; i < TLF_List.Count; i++)
                    {
                        //ClientLog For Tlf
                        if (isWithMultiple)
                        {
                            logItemForTlf_PO[0] = TLF_List[0].ReferenceVoucherNo;//GroupNo                                
                        }
                        else
                        {
                            logItemForTlf_PO[0] = string.Empty;//GroupNo
                        }
                        logItemForTlf_PO[1] = TLF_List[i].Eno;//EntryNo
                        logItemForTlf_PO[2] = TLF_List[i].AccountNo;//AcctNo
                        logItemForTlf_PO[3] = TLF_List[i].TransactionCode;//ACode(from COASetUp)
                        logItemForTlf_PO[4] = TLF_List[i].Amount.ToString();//LocalAmount
                        logItemForTlf_PO[5] = TLF_List[i].Narration;//SourceCur
                        logItemForTlf_PO[6] = string.Empty;//Cheque
                        logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_PO[8] = TLF_List[i].DateTime.ToString();//SettlementDate
                        logItemForTlf_PO[9] = TLF_List[i].Status;//Status
                        logItemForTlf_PO[10] = TLF_List[i].OtherBank;//SourceBr
                        logItemForTlf_PO[11] = string.Empty;//Rno
                        logItemForTlf_PO[12] = string.Empty;//Duration
                        logItemForTlf_PO[13] = string.Empty;//LasintDate
                        logItemForTlf_PO[14] = TLF_List[i].OrgnEno;//intRate
                        logItemForTlf_PO[15] = string.Empty;//Accured
                        logItemForTlf_PO[16] = string.Empty;//BudenAcc
                        logItemForTlf_PO[17] = string.Empty;//Draccured
                        logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                        logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                        logItemForTlf_PO[20] = string.Empty;//FirstRno
                        logItemForTlf_PO[21] = TLF_List[i].PaymentOrderNo;//PoNo
                        logItemForTlf_PO[22] = System.DateTime.Now.ToString();//ADate
                        logItemForTlf_PO[23] = string.Empty;//IDate
                        logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                        logItemForTlf_PO[25] = string.Empty;//Income
                        logItemForTlf_PO[26] = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode).ToString();//Budget
                        logItemForTlf_PO[27] = string.Empty;//FromBranch
                        logItemForTlf_PO[28] = string.Empty;//ToBranch
                        logItemForTlf_PO[29] = string.Empty;//Inout
                        logItemForTlf_PO[30] = string.Empty;//Success
                        logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_PO[32] = string.Empty;//IncomeType
                        logItemForTlf_PO[33] = string.Empty;//OtherBank
                        logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ByCash) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_PO);                     
                    }
                    if (isWithMultiple)
                    {
                        for (int i = 0; i < this.View.ViewDataList.Count; i++)
                        {
                            string AcctNo = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "PO", this.View.ViewDataList[0].Currency, this.View.ViewDataList[0].SourceBranch, true });
                            List<PFMDTO00054> PO_List = (from x in TLF_List where x.AccountNo == AcctNo select x).ToList();
                            this.View.ViewDataList[i].PONo = PO_List[i].PaymentOrderNo;
                        }
                        this.BindPONotoGridView();
                        View.GroupNo = TLF_List[0].ReferenceVoucherNo;
                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.ClearTextBoxControls();
                    }
                    else
                    {
                        this.View.ViewDataList[0].PONo = TLF_List[0].PaymentOrderNo;
                        this.BindPONotoGridView();
                        this.View.PONo = TLF_List[0].PaymentOrderNo;
                        this.View.ChangeControlName(true);
                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.ClearTextBoxControls();
                    }
                }
                #endregion
            }
        }

        #endregion


        #region Helper Methods

        private CXDTO00001 GetStrings(IList<TLMDTO00012> denoList, bool IsCashEnable, string branchCode)
        {
            CXDTO00001 getStrings = CXCLE00009.Instance.GetDenoString(denoList, IsCashEnable, branchCode);
            return getStrings;
        }               

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
       

        public decimal CalculateNetAmount()
        {
            decimal netAmount = 0;
            for (int i = 0; i < this.view.ViewDataList.Count; i++)
                netAmount += (view.ViewDataList[i].Amount+view.ViewDataList[i].Charges);
            return netAmount;
        }

        private void UpdatePOIssueDataSource(int index , TLMDTO00042 poIssueData)
        {
            this.View.ViewDataList[index].Amount = poIssueData.Amount;
            this.View.ViewDataList[index].Charges = poIssueData.Charges;
        }
        
        private void BindPONotoGridView()
        {
            for (int i = 0; i < this.View.ViewDataList.Count; i++)
            {
                //this.View.ViewDataList[i].PONo = this.PoNo[i];
            }
            this.View.BindTempDataListToGridview();
        }
#endregion

        #region UI Logic

        public void ClearTextBoxControls()
        {
            decimal zeroAmount =0;
            this.view.Amount = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            this.view.Charges = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            this.view.TotalAmount = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
        }


        public TLMDTO00042 BindDataToTemp()
        {
            this.view.TempData = new TLMDTO00042();
            this.view.TempData.Amount = this.view.Amount;
            this.view.TempData.Charges = this.view.Charges;

            return this.view.TempData;
        }

        public void FormCleaning()
        {
            this.ClearTextBoxControls();
            this.view.ViewDataList = new List<TLMDTO00042>();
            this.view.TempData = new TLMDTO00042();
            this.view.BindTempDataListToGridview();
            this.view.GroupNo = string.Empty;
            this.view.Currency = string.Empty;
            this.view.ChangeControlName(false);
            this.ClearAllCustomErrorMessage();
        }

        public bool AddPOIssue()
        {
            TLMDTO00042 poIssueEntity = this.GetViewData();

            if (this.ValidateForm(poIssueEntity))
            {
                this.View.ViewDataList.Add(poIssueEntity);
                return true;
            }
            else
                return false;
        }

        public bool EditPOIssue(int editRowIndex)
        {
            TLMDTO00042 poIssueEntity = this.GetViewData();
            if(this.ValidateForm(poIssueEntity))
            {
                this.UpdatePOIssueDataSource(editRowIndex,poIssueEntity);
                return true;
            }
            else
                return false;
        }
        #endregion

        
    }
}
