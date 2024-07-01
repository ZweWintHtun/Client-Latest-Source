using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00014 : AbstractPresenter, IMNMCTL00014
    {
        #region Properties
        private IMNMVEW00014 view;
        public IMNMVEW00014 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        public string sourceBranch = CurrentUserEntity.BranchCode;
        public decimal OldAmount = 0;
        public decimal OldCharges = 0;
        public TLMDTO00016 po = new TLMDTO00016();
        public decimal denoAmount = 0;
        public decimal groupAmount = 0;
        public decimal cashAmount = 0;
        public CXDTO00001 denoData { get; set; }

        #endregion

        #region Methods
        private void WireTo(IMNMVEW00014 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPOData());
            }
        }

        public void ClearControls()
        {
            this.view.GroupNo = string.Empty;
            this.view.PaymentOrderNo = string.Empty;
            this.view.BudgetYear = string.Empty;
            //this.view.Currency = string.Empty;
            this.view.Amount = 0;
            this.view.Charges = 0;
            this.view.Date = string.Empty;
            this.view.MultiCheck = false;
        }

        public TLMDTO00041 GetPOData()
        {
            TLMDTO00041 paymentOrderDTO = new TLMDTO00041();

            paymentOrderDTO.GroupNo = this.view.GroupNo;
            paymentOrderDTO.PaymentOrderNo = this.view.PaymentOrderNo;
            paymentOrderDTO.BudgetYear = this.view.BudgetYear;
            paymentOrderDTO.CurrencyCode = this.view.Currency;
            paymentOrderDTO.Amount = this.view.Amount;
            paymentOrderDTO.Charges = this.view.Charges;
            paymentOrderDTO.RegisterDate = this.view.Date;
            paymentOrderDTO.MultiCheck = this.view.MultiCheck;


            return paymentOrderDTO;
        }

        public bool Edit()
        {
            bool result = false;
            TLMDTO00041 data = this.GetPOData();

            po = this.CheckPO();
            if (po == null)
                return false; 
            //if (this.ValidateForm(data))
            //{
            if (CXUIMessageUtilities.ShowMessageByCode("MC90005") == DialogResult.Yes)//Are you sure you want to edit?
            {
                //po = this.CheckPO();

                if (!string.IsNullOrEmpty(po.Currency))
                {
                    this.view.Currency = po.Currency;
                    this.view.Amount = po.Amount;
                    this.OldAmount = po.Amount;
                    this.view.Status = po.Income;
                    if (this.view.Status == "Y")
                    {
                        this.view.Charges = Convert.ToDecimal(po.Charges);
                        this.OldCharges = Convert.ToDecimal(po.Charges);
                    }
                    DateTime Date = Convert.ToDateTime(po.ADate);
                    this.view.Date = CXCOM00006.Instance.GetDateFormat(Date).ToString();

                    result = true;
                }
            }
            else
            {
                result = false;
            }
            //}
            return result;
        }

        public TLMDTO00016 CheckPO()
        {
            TLMDTO00016 PODTO = new TLMDTO00016();
            if (string.IsNullOrEmpty(this.View.GroupNo))
            {
                PODTO = CXClientWrapper.Instance.Invoke<IMNMSVE00014, TLMDTO00016>(x => x.GetPOData(this.View.PaymentOrderNo, this.View.BudgetYear, this.sourceBranch));
            }
            else
            {
                PODTO = CXClientWrapper.Instance.Invoke<IMNMSVE00014, TLMDTO00016>(x => x.GetDepoDenoData(this.View.GroupNo, this.View.PaymentOrderNo, this.View.BudgetYear, this.sourceBranch));
            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV30023")
                //{
                //    //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00219", new object[] { "Refund" });//Refund PO No. for this Group No.  //already comment
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00219", new object[] { "Refund" });//Refund PO No. for this Group No.
                //}
                //else
                //{
                    //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                   // this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.View.Failure("MV00219");//PO No. Not Found.
                   // PODTO = new TLMDTO00016();
                    return null;
                //}
            }
            else if (PODTO == null)
            {
                //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00219");//PO No. Not Found.
                this.View.Failure("MV00219");//PO No. Not Found.
                //PODTO = new TLMDTO00016();                
            }
            else
            {
                DateTime Date = Convert.ToDateTime(PODTO.ADate);
                string date = CXCOM00006.Instance.GetDateFormat(Date).ToString();
                string todayDate = CXCOM00006.Instance.GetDateFormat(DateTime.Now).ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(PODTO.IDate)))
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MI30044");//This PO No is already Refund.
                    this.View.Failure("MI30044");//This PO No is already Refund.
                    PODTO = new TLMDTO00016();                    
                }
                else if (!string.IsNullOrEmpty(PODTO.AccountNo))
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MI30045");//P.O by Cash Only.
                    this.View.Failure("MI30045");//P.O by Cash Only.
                    PODTO = new TLMDTO00016();                    
                }
                else if (date != todayDate)
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MI30046");//Too late to edit.
                    this.View.Failure("MI30046");//Too late to edit.
                    PODTO = new TLMDTO00016();                    
                }

            }
            return PODTO;
        }

        public void Save()
        {
            IList<PFMDTO00054> POINfo = new List<PFMDTO00054>();
            if (this.view.Amount.Equals(0.00))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00037");//Invalid Amount.
            }
            else if (this.view.Amount == this.OldAmount)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30047");//PO Amount and Charges are the same. No need to edit.
            }
            else
            {
                TLMDTO00016 po = this.CollectPOData();
                if (string.IsNullOrEmpty(this.view.GroupNo))
                {
                    denoAmount = this.view.Amount + this.view.Charges;
                    denoData = this.CallDeno(denoAmount, this.view.Currency);
                    if (!string.IsNullOrEmpty(denoData.DenoString))
                    {
                        POINfo = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<PFMDTO00054>>(x => x.SaveSinglePO(po, denoData));
                    }
                    else return;
                }
                else
                {
                    groupAmount = po.CashDenoDTO.DepoDenoAmount;
                    denoAmount = groupAmount + this.view.Amount + this.view.Charges;
                    //denoAmount = this.view.Amount + this.view.Charges;
                    denoData = this.CallDeno(denoAmount, this.View.Currency);
                    if (!string.IsNullOrEmpty(denoData.DenoString))
                    {
                        POINfo = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<PFMDTO00054>>(x => x.SaveMultiPO(po, denoData));
                    }
                    else return;
                }
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                {
                    string[] logItemForDeno = new string[14];
                    string[] logItemForTlf_PO = new string[35];
                    if (string.IsNullOrEmpty(this.view.GroupNo))
                    {
                        //ClientLog For Deno
                        logItemForDeno[0] = POINfo[0].Eno;//Tlf_Eno
                        logItemForDeno[1] = po.PONo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = po.Currency;//cur
                        logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                        logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                    }
                    else
                    {
                        //ClientLog For Deno
                        logItemForDeno[0] = po.GroupNo;//Tlf_Eno
                        logItemForDeno[1] = string.Empty;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = po.Currency;//cur
                        logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                        logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
 
                    }
                    for (int i = 0; i < POINfo.Count; i++)
                    {
                        //ClientLog For Tlf
                        logItemForTlf_PO[0] = string.Empty;//GroupNo
                        logItemForTlf_PO[1] = POINfo[i].Eno;//EntryNo
                        logItemForTlf_PO[2] = POINfo[i].AccountNo;//AcctNo
                        logItemForTlf_PO[3] = POINfo[i].AccountNo;//ACode(from COASetUp)
                        logItemForTlf_PO[4] = POINfo[i].Amount.ToString();//LocalAmount
                        logItemForTlf_PO[5] = POINfo[i].Lno;//SourceCur
                        logItemForTlf_PO[6] = string.Empty;//Cheque
                        logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_PO[8] = POINfo[i].DateTime.ToString();//SettlementDate
                        logItemForTlf_PO[9] = string.Empty;//Status
                        logItemForTlf_PO[10] = po.SourceBranchCode;//SourceBr
                        logItemForTlf_PO[11] = POINfo[i].TransactionCode;//Rno
                        logItemForTlf_PO[12] = string.Empty;//Duration
                        logItemForTlf_PO[13] = string.Empty;//LasintDate
                        logItemForTlf_PO[14] = string.Empty;//intRate
                        logItemForTlf_PO[15] = string.Empty;//Accured
                        logItemForTlf_PO[16] = string.Empty;//BudenAcc
                        logItemForTlf_PO[17] = string.Empty;//Draccured
                        logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                        logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                        logItemForTlf_PO[20] = string.Empty;//FirstRno
                        logItemForTlf_PO[21] = po.PONo;//PoNo
                        logItemForTlf_PO[22] = string.Empty;//ADate
                        logItemForTlf_PO[23] = string.Empty;//IDate
                        logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                        logItemForTlf_PO[25] = POINfo[i].Cheque.ToString();//Income
                        logItemForTlf_PO[26] = string.Empty;//Budget
                        logItemForTlf_PO[27] = string.Empty;//FromBranch
                        logItemForTlf_PO[28] = string.Empty;//ToBranch
                        logItemForTlf_PO[29] = string.Empty;//Inout
                        logItemForTlf_PO[30] = string.Empty;//Success
                        logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_PO[32] = string.Empty;//IncomeType
                        logItemForTlf_PO[33] = string.Empty;//OtherBank
                        logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(ByCash) Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_PO);
                    }
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    string[] logItemForDeno = new string[14];
                    string[] logItemForTlf_PO = new string[35];
                    if (string.IsNullOrEmpty(this.view.GroupNo))
                    {
                        //ClientLog For Deno
                        logItemForDeno[0] = POINfo[0].Eno;//Tlf_Eno
                        logItemForDeno[1] = po.PONo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = po.Currency;//cur
                        logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                        logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                    }
                    else
                    {
                        //ClientLog For Deno
                        logItemForDeno[0] = po.GroupNo;//Tlf_Eno
                        logItemForDeno[1] = string.Empty;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = po.Currency;//cur
                        logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                        logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
 
                    }
                    for (int i = 0; i < POINfo.Count; i++)
                    {
                        //ClientLog For Tlf
                        logItemForTlf_PO[0] = string.Empty;//GroupNo
                        logItemForTlf_PO[1] = POINfo[i].Eno;//EntryNo
                        logItemForTlf_PO[2] = POINfo[i].AccountNo;//AcctNo
                        logItemForTlf_PO[3] = POINfo[i].AccountNo;//ACode(from COASetUp)
                        logItemForTlf_PO[4] = POINfo[i].Amount.ToString();//LocalAmount
                        logItemForTlf_PO[5] = POINfo[i].Lno;//SourceCur
                        logItemForTlf_PO[6] = string.Empty;//Cheque
                        logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf_PO[8] = POINfo[i].DateTime.ToString();//SettlementDate
                        logItemForTlf_PO[9] = string.Empty;//Status
                        logItemForTlf_PO[10] = po.SourceBranchCode;//SourceBr
                        logItemForTlf_PO[11] = POINfo[i].TransactionCode;//Rno
                        logItemForTlf_PO[12] = string.Empty;//Duration
                        logItemForTlf_PO[13] = string.Empty;//LasintDate
                        logItemForTlf_PO[14] = string.Empty;//intRate
                        logItemForTlf_PO[15] = string.Empty;//Accured
                        logItemForTlf_PO[16] = string.Empty;//BudenAcc
                        logItemForTlf_PO[17] = string.Empty;//Draccured
                        logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                        logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                        logItemForTlf_PO[20] = string.Empty;//FirstRno
                        logItemForTlf_PO[21] = po.PONo;//PoNo
                        logItemForTlf_PO[22] = string.Empty;//ADate
                        logItemForTlf_PO[23] = string.Empty;//IDate
                        logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                        logItemForTlf_PO[25] = POINfo[i].Cheque.ToString();//Income
                        logItemForTlf_PO[26] = string.Empty;//Budget
                        logItemForTlf_PO[27] = string.Empty;//FromBranch
                        logItemForTlf_PO[28] = string.Empty;//ToBranch
                        logItemForTlf_PO[29] = string.Empty;//Inout
                        logItemForTlf_PO[30] = string.Empty;//Success
                        logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf_PO[32] = string.Empty;//IncomeType
                        logItemForTlf_PO[33] = string.Empty;//OtherBank
                        logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(ByCash) Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf_PO);
                    }
                    this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.ClearControls();
                }
                #endregion
            }
        }

        public void Delete()
        {
            TLMDTO00016 po = this.CollectPOData();
            IList<PFMDTO00054> POINfo = new List<PFMDTO00054>();
            if (string.IsNullOrEmpty(this.View.GroupNo))
            {
                POINfo = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<PFMDTO00054>>(x => x.DeleteSinglePO(po));
            }
            else
            {
                groupAmount = po.CashDenoDTO.DepoDenoAmount;
                cashAmount = groupAmount + this.view.Amount + this.view.Charges;
                if (cashAmount > (this.view.Amount + this.view.Charges))
                {
                    denoAmount = cashAmount - (this.view.Amount + this.view.Charges);
                }
                denoData = this.CallDeno(denoAmount, this.View.Currency);
                if (!string.IsNullOrEmpty(denoData.DenoString))
                {
                    POINfo = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<PFMDTO00054>>(x => x.DeleteMultiPO(po, denoData));
                }
            }
            #region ErrorOccurred
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
            {
                string[] logItemForDeno = new string[14];
                string[] logItemForTlf_PO = new string[35];
                if (!string.IsNullOrEmpty(this.view.GroupNo))
                {
                    //ClientLog For Deno
                    logItemForDeno[0] = po.GroupNo;//Tlf_Eno
                    logItemForDeno[1] = string.Empty;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                    logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                    logItemForDeno[10] = po.Currency;//cur
                    logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                    logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                    logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Fail Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                }
                for (int i = 0; i < POINfo.Count; i++)
                {
                    //ClientLog For Tlf
                    logItemForTlf_PO[0] = string.Empty;//GroupNo
                    logItemForTlf_PO[1] = POINfo[i].Eno;//EntryNo
                    logItemForTlf_PO[2] = POINfo[i].AccountNo;//AcctNo
                    logItemForTlf_PO[3] = POINfo[i].AccountNo;//ACode(from COASetUp)
                    logItemForTlf_PO[4] = POINfo[i].Amount.ToString();//LocalAmount
                    logItemForTlf_PO[5] = POINfo[i].Narration;//SourceCur
                    logItemForTlf_PO[6] = string.Empty;//Cheque
                    logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf_PO[8] = POINfo[i].DateTime.ToString();//SettlementDate
                    logItemForTlf_PO[9] = string.Empty;//Status
                    logItemForTlf_PO[10] = po.SourceBranchCode;//SourceBr
                    logItemForTlf_PO[11] = POINfo[i].TransactionCode;//Rno
                    logItemForTlf_PO[12] = string.Empty;//Duration
                    logItemForTlf_PO[13] = string.Empty;//LasintDate
                    logItemForTlf_PO[14] = string.Empty;//intRate
                    logItemForTlf_PO[15] = string.Empty;//Accured
                    logItemForTlf_PO[16] = string.Empty;//BudenAcc
                    logItemForTlf_PO[17] = string.Empty;//Draccured
                    logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                    logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                    logItemForTlf_PO[20] = string.Empty;//FirstRno
                    logItemForTlf_PO[21] = po.PONo;//PoNo
                    logItemForTlf_PO[22] = string.Empty;//ADate
                    logItemForTlf_PO[23] = string.Empty;//IDate
                    logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                    logItemForTlf_PO[25] = POINfo[i].Cheque.ToString();//Income
                    logItemForTlf_PO[26] = string.Empty;//Budget
                    logItemForTlf_PO[27] = string.Empty;//FromBranch
                    logItemForTlf_PO[28] = string.Empty;//ToBranch
                    logItemForTlf_PO[29] = string.Empty;//Inout
                    logItemForTlf_PO[30] = string.Empty;//Success
                    logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf_PO[32] = string.Empty;//IncomeType
                    logItemForTlf_PO[33] = string.Empty;//OtherBank
                    logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(ByCash) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf_PO);
                }
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            #endregion

            #region Successful
            else
            {
                string[] logItemForDeno = new string[14];
                string[] logItemForTlf_PO = new string[35];
                if (!string.IsNullOrEmpty(this.view.GroupNo))
                {
                    //ClientLog For Deno
                    logItemForDeno[0] = po.GroupNo;//Tlf_Eno
                    logItemForDeno[1] = string.Empty;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = denoData.TotalAmount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = denoData.DenoString;//Deno_Detail
                    logItemForDeno[6] = denoData.RefundString;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = po.SourceBranchCode;//sourcebr
                    logItemForDeno[10] = po.Currency;//cur
                    logItemForDeno[11] = denoData.DenoRateString;//DenoRate
                    logItemForDeno[12] = POINfo[0].DateTime.ToString();//SettlementDate
                    logItemForDeno[13] = POINfo[0].Status.ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Edit(ByCash) Commit Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                }
                for (int i = 0; i < POINfo.Count; i++)
                {
                    //ClientLog For Tlf
                    logItemForTlf_PO[0] = string.Empty;//GroupNo
                    logItemForTlf_PO[1] = POINfo[i].Eno;//EntryNo
                    logItemForTlf_PO[2] = POINfo[i].AccountNo;//AcctNo
                    logItemForTlf_PO[3] = POINfo[i].AccountNo;//ACode(from COASetUp)
                    logItemForTlf_PO[4] = POINfo[i].Amount.ToString();//LocalAmount
                    logItemForTlf_PO[5] = POINfo[i].Lno;//SourceCur
                    logItemForTlf_PO[6] = string.Empty;//Cheque
                    logItemForTlf_PO[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf_PO[8] = POINfo[i].DateTime.ToString();//SettlementDate
                    logItemForTlf_PO[9] = string.Empty;//Status
                    logItemForTlf_PO[10] = po.SourceBranchCode;//SourceBr
                    logItemForTlf_PO[11] = POINfo[i].TransactionCode;//Rno
                    logItemForTlf_PO[12] = string.Empty;//Duration
                    logItemForTlf_PO[13] = string.Empty;//LasintDate
                    logItemForTlf_PO[14] = string.Empty;//intRate
                    logItemForTlf_PO[15] = string.Empty;//Accured
                    logItemForTlf_PO[16] = string.Empty;//BudenAcc
                    logItemForTlf_PO[17] = string.Empty;//Draccured
                    logItemForTlf_PO[18] = string.Empty;//AccuredStatus
                    logItemForTlf_PO[19] = string.Empty;//ToAccountNo
                    logItemForTlf_PO[20] = string.Empty;//FirstRno
                    logItemForTlf_PO[21] = po.PONo;//PoNo
                    logItemForTlf_PO[22] = string.Empty;//ADate
                    logItemForTlf_PO[23] = string.Empty;//IDate
                    logItemForTlf_PO[24] = string.Empty;//ToAcctNo
                    logItemForTlf_PO[25] = POINfo[i].Cheque.ToString();//Income
                    logItemForTlf_PO[26] = string.Empty;//Budget
                    logItemForTlf_PO[27] = string.Empty;//FromBranch
                    logItemForTlf_PO[28] = string.Empty;//ToBranch
                    logItemForTlf_PO[29] = string.Empty;//Inout
                    logItemForTlf_PO[30] = string.Empty;//Success
                    logItemForTlf_PO[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf_PO[32] = string.Empty;//IncomeType
                    logItemForTlf_PO[33] = string.Empty;//OtherBank
                    logItemForTlf_PO[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(ByCash) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf_PO);
                }
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.ClearControls();
            }
            #endregion
        }

        public TLMDTO00016 CollectPOData()
        {
            TLMDTO00041 DTO = this.GetPOData();
            po.Amount = DTO.Amount;
            po.Charges = DTO.Charges;
            po.CreatedUserId = CurrentUserEntity.CurrentUserID;
            po.SourceBranchCode = sourceBranch;
            po.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            po.GroupNo = DTO.GroupNo;
            po.OldAmount = OldAmount;
            po.OldCharges = OldCharges;
            po.Income = this.view.Status;
            return po;
        }

        public CXDTO00001 CallDeno(decimal amount, string currency)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { amount, currency, CXDMD00008.Received, View.ParentFormId }) == DialogResult.OK)
            {
                CXDTO00001 denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                if (denoDTO != null)
                {
                    return denoDTO;
                }
                else
                {
                    return new CXDTO00001();
                }
            }
            else
            {
                //Error Occur becoz user don't enter deno but close the form.
                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                return new CXDTO00001();
            }
        }

        #endregion



        #region Validation Logic
        public void txtGroupNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (!this.View.GroupNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GroupFormat))))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV30020");//Invalid Group No.
                }
                else
                {
                    IList<TLMDTO00015> cashDenoDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<TLMDTO00015>>(x => x.GetDepoDenoAndCashDeno(this.View.GroupNo, sourceBranch));
                    if (cashDenoDTO == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV30020");//Invalid Group No.
                    }
                }
            }
        }


        public void txtPaymentOrderNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (!this.View.PaymentOrderNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POFromat))))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");//Invalid Payment Order No.
                }

            }
        }
        #endregion

    }

}
