using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00027 : AbstractPresenter,IMNMCTL00027
    {
        #region Properties
        private IMNMVEW00027 view;
        public IMNMVEW00027 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        #endregion Properties

        #region Wire To
        private void WireTo(IMNMVEW00027 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.Drawingremittancedto);
            }
        }
        #endregion Wire To

        #region Methods
        public void ClearControls()
        {
            this.View.Listdrawingremittancedto.Clear();
            this.View.GridDataSource = null;
            this.View.DrawingRegisterNo = string.Empty;
            this.View.GroupNo = string.Empty;
            this.View.SaveStatus = false;
        }

  public void Save()
        {
            CXDTO00001 _denoInfo = new CXDTO00001();
            try
            {
                if (this.ValidateForm())
                {
                    decimal? RemainingAmount = 0;
                    IList<TLMDTO00015> ListCashDeno = new List<TLMDTO00015>();
                    //group
                    if (!string.IsNullOrEmpty(this.View.GroupNo))
                    {
                        RemainingAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00027, TLMDTO00017>(x => x.GetOtherGroupAmount(this.View.GroupNo, this.View.DrawingRegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                        if (RemainingAmount > 0)
                        {
                            if (CXClientWrapper.Instance.Invoke<IMNMSVE00027, bool>(x => x.CheckDenoStatus(this.View.DrawingRegisterNo, CurrentUserEntity.BranchCode)))  //For Check deno status for this voucher no.
                            {
                                if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { RemainingAmount, this.View.CurrencyCode, CXDMD00008.Received, "frmTLMVEW00011" }) == DialogResult.OK)
                                {
                                    _denoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00011");
                                    this.View.Drawingremittancedto.CashAmount = RemainingAmount.Value;
                                    IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00027, IList<PFMDTO00054>>(x => x.Save(this.View.Drawingremittancedto, _denoInfo, this.View.IsVoucher));
                                    #region ErrorOccurred
                                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                                    {
                                        if (this.View.IsVoucher)
                                        {
                                            if (_denoInfo != null)
                                            {
                                                string[] logItemForDeno = new string[14];
                                                if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                    logItemForDeno[0] = this.View.Drawingremittancedto.GroupNo.ToString();//Tlf_Eno
                                                else
                                                    logItemForDeno[0] = string.Empty;
                                                logItemForDeno[1] = string.IsNullOrEmpty(this.View.Drawingremittancedto.GroupNo) ? this.View.Drawingremittancedto.RegisterNo : string.Empty;//AcType
                                                logItemForDeno[2] = string.Empty;//FromType
                                                logItemForDeno[3] = this.View.Drawingremittancedto.CashAmount.ToString();//Amount
                                                logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                                                logItemForDeno[5] = _denoInfo.DenoString;//Deno_Detail
                                                logItemForDeno[6] = _denoInfo.RefundString;//DenoRefund_Detail
                                                logItemForDeno[7] = "R";//Status
                                                logItemForDeno[8] = "0";//REVERSE
                                                logItemForDeno[9] = this.View.Drawingremittancedto.SourceBranchCode;//sourcebr
                                                logItemForDeno[10] = this.View.Drawingremittancedto.Currency;//cur
                                                logItemForDeno[11] = _denoInfo.DenoRateString;//DenoRate
                                                logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.Drawingremittancedto.SourceBranchCode).ToString();//SettlementDate
                                                logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Drawingremittancedto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Drawing Adjustment Fail Deno", CurrentUserEntity.BranchCode,
                                                logItemForDeno);
                                            }
                                        }

                                        if (Tlf_List.Count > 0)
                                        {
                                            string[] logItemForTlf = new string[35];
                                            //ClientLog For Tlf
                                            for (int i = 0; i < Tlf_List.Count; i++)
                                            {
                                                if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                    logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                                else
                                                    logItemForTlf[0] = string.Empty;//GroupNo
                                                logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                                logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                                logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                                logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                                logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                                logItemForTlf[6] = string.Empty;//Cheque
                                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                                logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                                logItemForTlf[9] = Tlf_List[i].Status;//Status
                                                logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                                logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                                logItemForTlf[12] = string.Empty;//Duration
                                                logItemForTlf[13] = string.Empty;//LasintDate
                                                logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Fail Transaction", CurrentUserEntity.BranchCode,
                                                logItemForTlf);
                                            }
                                        }
                                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                    }
                                    #endregion

                                    #region Successful
                                    else
                                    {
                                        if (this.View.IsVoucher)
                                        {
                                            if (_denoInfo != null)
                                            {
                                                string[] logItemForDeno = new string[14];
                                                if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                    logItemForDeno[0] = this.View.Drawingremittancedto.GroupNo.ToString();//Tlf_Eno
                                                else
                                                    logItemForDeno[0] = string.Empty;
                                                logItemForDeno[1] = string.IsNullOrEmpty(this.View.Drawingremittancedto.GroupNo) ? this.View.Drawingremittancedto.RegisterNo : string.Empty ;//AcType
                                                logItemForDeno[2] = string.Empty;//FromType
                                                logItemForDeno[3] = this.View.Drawingremittancedto.CashAmount.ToString();//Amount
                                                logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                                                logItemForDeno[5] = _denoInfo.DenoString;//Deno_Detail
                                                logItemForDeno[6] = _denoInfo.RefundString;//DenoRefund_Detail
                                                logItemForDeno[7] = "R";//Status
                                                logItemForDeno[8] = "0";//REVERSE
                                                logItemForDeno[9] = this.View.Drawingremittancedto.SourceBranchCode;//sourcebr
                                                logItemForDeno[10] = this.View.Drawingremittancedto.Currency;//cur
                                                logItemForDeno[11] = _denoInfo.DenoRateString;//DenoRate
                                                logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.Drawingremittancedto.SourceBranchCode).ToString();//SettlementDate
                                                logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Drawingremittancedto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Drawing Adjustment Commit Deno", CurrentUserEntity.BranchCode,
                                                logItemForDeno);
                                            }
                                        }

                                        if (Tlf_List.Count > 0)
                                        {
                                            string[] logItemForTlf = new string[35];
                                            //ClientLog For Tlf
                                            for (int i = 0; i < Tlf_List.Count; i++)
                                            {
                                                if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                    logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                                else
                                                    logItemForTlf[0] = string.Empty;//GroupNo
                                                logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                                logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                                logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                                logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                                logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                                logItemForTlf[6] = string.Empty;//Cheque
                                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                                logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                                logItemForTlf[9] = Tlf_List[i].Status;//Status
                                                logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                                logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                                logItemForTlf[12] = string.Empty;//Duration
                                                logItemForTlf[13] = string.Empty;//LasintDate
                                                logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                                logItemForTlf);
                                            }
                                        }
                                        CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                                        this.ClearControls();
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00027, IList<PFMDTO00054>>(x => x.Save(this.View.Drawingremittancedto, null, this.View.IsVoucher));
                                #region ErrorOccurred
                                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                                {
                                    if (Tlf_List.Count > 0)
                                    {
                                        string[] logItemForTlf = new string[35];
                                        //ClientLog For Tlf
                                        for (int i = 0; i < Tlf_List.Count; i++)
                                        {
                                            if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                            else
                                                logItemForTlf[0] = string.Empty;//GroupNo
                                            logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                            logItemForTlf[6] = string.Empty;//Cheque
                                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                            logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                            logItemForTlf[12] = string.Empty;//Duration
                                            logItemForTlf[13] = string.Empty;//LasintDate
                                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Fail Transaction", CurrentUserEntity.BranchCode,
                                            logItemForTlf);
                                        }
                                    }
                                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                }
                                #endregion

                                #region Successful
                                else
                                {
                                    if (Tlf_List.Count > 0)
                                    {
                                        string[] logItemForTlf = new string[35];
                                        //ClientLog For Tlf
                                        for (int i = 0; i < Tlf_List.Count; i++)
                                        {
                                            if (!string.IsNullOrEmpty(this.View.GroupNo))
                                                logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                            else
                                                logItemForTlf[0] = string.Empty;//GroupNo
                                            logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                            logItemForTlf[6] = string.Empty;//Cheque
                                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                            logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                            logItemForTlf[12] = string.Empty;//Duration
                                            logItemForTlf[13] = string.Empty;//LasintDate
                                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                            logItemForTlf);
                                        }
                                    }
                                    CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                                    this.ClearControls();
                                }
                                #endregion
                            }

                        }
                        else
                        {
                            IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00027,IList<PFMDTO00054>>(x => x.Save(this.View.Drawingremittancedto, null, this.View.IsVoucher));
                            #region ErrorOccurred
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                if (Tlf_List.Count > 0)
                                {
                                    string[] logItemForTlf = new string[35];
                                    //ClientLog For Tlf
                                    for (int i = 0; i < Tlf_List.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(this.View.GroupNo))
                                            logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                        else
                                            logItemForTlf[0] = string.Empty;//GroupNo
                                        logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                        logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                        logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                        logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                        logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                        logItemForTlf[6] = string.Empty;//Cheque
                                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                        logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                        logItemForTlf[9] = Tlf_List[i].Status;//Status
                                        logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                        logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                        logItemForTlf[12] = string.Empty;//Duration
                                        logItemForTlf[13] = string.Empty;//LasintDate
                                        logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Fail Transaction", CurrentUserEntity.BranchCode,
                                        logItemForTlf);
                                    }
                                }
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            }
                            #endregion

                            #region Successful
                            else
                            {
                                if (Tlf_List.Count > 0)
                                {
                                    string[] logItemForTlf = new string[35];
                                    //ClientLog For Tlf
                                    for (int i = 0; i < Tlf_List.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(this.View.GroupNo))
                                            logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                        else
                                            logItemForTlf[0] = string.Empty;//GroupNo
                                        logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                        logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                        logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                        logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                        logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                        logItemForTlf[6] = string.Empty;//Cheque
                                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                        logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                        logItemForTlf[9] = Tlf_List[i].Status;//Status
                                        logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                        logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                        logItemForTlf[12] = string.Empty;//Duration
                                        logItemForTlf[13] = string.Empty;//LasintDate
                                        logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                        logItemForTlf);
                                    }
                                }
                                CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                                this.ClearControls();
                            }
                            #endregion

                        }
                        

                    }
                    //single
                    else
                    {
                        decimal? Amount = 0;
                        Amount = CXClientWrapper.Instance.Invoke<IMNMSVE00027, TLMDTO00015>(x => x.GetAmountByAcType(this.View.DrawingRegisterNo, CurrentUserEntity.BranchCode)).Amount;
                        {
                            //No Need to insert deno for SingleRD
                            //if (CXClientWrapper.Instance.Invoke<IMNMSVE00027, bool>(x => x.CheckDenoStatus(this.View.DrawingRegisterNo, CurrentUserEntity.BranchCode)))//For Check deno status for this voucher no.
                            //{
                            //    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { Amount, this.View.CurrencyCode, CXDMD00008.Received, "frmTLMVEW00011" }) == DialogResult.OK)
                            //    {
                            //        _denoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00011");
                            //        this.View.Drawingremittancedto.CashAmount = Amount.Value;
                            //        CXClientWrapper.Instance.Invoke<IMNMSVE00027>(x => x.Save(this.View.Drawingremittancedto, null, this.View.IsVoucher));
                            //        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            //            CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //        else
                            //        {
                            //            CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                            //            this.ClearControls();
                            //        } 
                            //    }                               

                            //}
                            //else
                            //{
                               IList<PFMDTO00054> Tlf_List =  CXClientWrapper.Instance.Invoke<IMNMSVE00027,IList<PFMDTO00054>>(x => x.Save(this.View.Drawingremittancedto, null, this.View.IsVoucher));
                               #region ErrorOccurred
                               if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                               {
                                   if (Tlf_List.Count > 0)
                                   {
                                       string[] logItemForTlf = new string[35];
                                       //ClientLog For Tlf
                                       for (int i = 0; i < Tlf_List.Count; i++)
                                       {
                                           if (!string.IsNullOrEmpty(this.View.GroupNo))
                                               logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                           else
                                               logItemForTlf[0] = string.Empty;//GroupNo
                                           logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                           logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                           logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                           logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                           logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                           logItemForTlf[6] = string.Empty;//Cheque
                                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                           logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                           logItemForTlf[9] = Tlf_List[i].Status;//Status
                                           logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                           logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                           logItemForTlf[12] = string.Empty;//Duration
                                           logItemForTlf[13] = string.Empty;//LasintDate
                                           logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Fail Transaction", CurrentUserEntity.BranchCode,
                                           logItemForTlf);
                                       }
                                   }
                                   CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                               }
                               #endregion

                               #region Successful
                               else
                               {
                                   if (Tlf_List.Count > 0)
                                   {
                                       string[] logItemForTlf = new string[35];
                                       //ClientLog For Tlf
                                       for (int i = 0; i < Tlf_List.Count; i++)
                                       {
                                           if (!string.IsNullOrEmpty(this.View.GroupNo))
                                               logItemForTlf[0] = this.View.Drawingremittancedto.GroupNo.ToString();//GroupNo
                                           else
                                               logItemForTlf[0] = string.Empty;//GroupNo
                                           logItemForTlf[1] = Tlf_List[0].Eno;//EntryNo
                                           logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                                           logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                                           logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                                           logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                                           logItemForTlf[6] = string.Empty;//Cheque
                                           logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                           logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                                           logItemForTlf[9] = Tlf_List[i].Status;//Status
                                           logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                                           logItemForTlf[11] = Tlf_List[0].OrgnEno;//Rno
                                           logItemForTlf[12] = string.Empty;//Duration
                                           logItemForTlf[13] = string.Empty;//LasintDate
                                           logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                           TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Drawing Adjustment Commit Transaction", CurrentUserEntity.BranchCode,
                                           logItemForTlf);
                                       }
                                   }
                                   CXUIMessageUtilities.ShowMessageByCode("MI30040"); //Successfully Reversal Transaction.
                                   this.ClearControls();
                               }
                               #endregion
                            //}
                            
                        }
                        
                    }

                    #region Coding nolonger needed
                    //if (CXClientWrapper.Instance.Invoke<IMNMSVE00027, bool>(x => x.SelectForDenoForm(this.View.Drawingremittancedto, out ListCashDeno, out RemainingAmount)))
                    //{
                    //    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { RemainingAmount, this.View.Drawingremittancedto.Currency, CXDMD00008.Received, "frmTLMVEW00011" }) == DialogResult.OK)
                    //    {
                    //        CXDTO00002 rateinfo = CXCLE00011.Instance.GetDenoExchangeRateString(this.View.Drawingremittancedto.Currency, CurrentUserEntity.BranchCode, "CS");
                    //        CXDTO00001 DenoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00011");
                    //        if (DenoInfo == null)
                    //            _denoInfo = null;
                    //        else
                    //            _denoInfo = DenoInfo;
                    //        this.View.Drawingremittancedto.CashAmount = RemainingAmount.Value;
                    //    }
                    //}
                    //CXClientWrapper.Instance.Invoke<IMNMSVE00027>(x => x.Save(this.View.Drawingremittancedto, _denoInfo));
                    //if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    //    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    //else
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode("MI90003"); //Delete Successful
                    //    this.ClearControls();
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), ex.Message);
            }
        }

        #endregion Methods
        
        #region Custom Validating
        public void txtDrawingRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                try
                {
                    if (this.View.Listdrawingremittancedto != null)
                        this.View.Listdrawingremittancedto.Clear();
                    TLMDTO00017 drawingremittancedto = CXClientWrapper.Instance.Invoke<IMNMSVE00027, TLMDTO00017>(x => x.DrawingRegisterNoValidate(this.View.DrawingRegisterNo, CurrentUserEntity.BranchCode));
                   
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        if (drawingremittancedto != null)
                        {
                            if (drawingremittancedto.DateTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                            {
                                this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), "MV30010");    //Not Allow Back Date Transaction
                                return;
                            }
                            this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), string.Empty);
                            if (drawingremittancedto.ReceiptDate == null && drawingremittancedto.IncomeDate == null)
                            {
                                View.IsVoucher = false;
                            }
                            else if (drawingremittancedto.ReceiptDate == null && drawingremittancedto.IncomeDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() && drawingremittancedto.IncomeType == null)
                            {
                                View.IsVoucher = false;
                            }
                            else
                            {
                                View.IsVoucher = true;
                            }

                            if (!string.IsNullOrEmpty(drawingremittancedto.GroupNo))
                            {
                                this.View.GroupNo = drawingremittancedto.GroupNo;
                            }
                           drawingremittancedto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                            this.View.CurrencyCode = drawingremittancedto.Currency;
                            this.View.SourceBranchCode = CurrentUserEntity.BranchCode;
                            this.View.updatedUserId = CurrentUserEntity.CurrentUserID;
                            this.View.Listdrawingremittancedto.Add(drawingremittancedto);
                            if (!this.View.SaveStatus)
                            {
                                
                                this.View.GridDataBind();
                            }
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), "MV00168");    //Invalid RegisterNo
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtDrawingRegisterNo"), ex.Message);
                }
            }
        }
        #endregion Custom Validating

    }
}
