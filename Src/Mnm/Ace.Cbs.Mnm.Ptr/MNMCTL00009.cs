//----------------------------------------------------------------------
// <copyright file="MNMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00009 : AbstractPresenter, IMNMCTL00009
    {
        #region "Property"
        DateTime dateInTlf { get; set; }
        private IMNMVEW00009 view;
        public IMNMVEW00009 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private bool isValidateForm = false;
        public IList<PFMDTO00054> TLFActype { get; set; }
        #endregion "Property"     

        #region UI Validation Logic

        private void WireTo(IMNMVEW00009 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetTlfEntity());
            }
        }

        public void mtxtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            if (this.View.Eno == string.Empty)
            {
                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXMessage.MV90027);   //Invalid Entry No
                return;
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), string.Empty);
            }

            IList<PFMDTO00054> tlfData = this.SelectForClrVoucherReversal(this.View.Eno);
            if (tlfData == null || tlfData.Count <= 0)
                return;
            else
            {
                string tlfdate = Convert.ToDateTime(tlfData[0].SettlementDate).ToShortDateString();
                dateInTlf = Convert.ToDateTime(tlfData[0].SettlementDate);
                string todaydate = DateTime.Now.ToShortDateString();
                if (tlfdate == todaydate)
                {
                    this.View.FillData(tlfData);
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("ME30002"); //Not Allowed Back Date Transaction
                    this.ClearControls();
                }
            }
        }

        #endregion

        #region Business Logic

        //Select data for Viewdata by Entry No
        public IList<PFMDTO00054> SelectForClrVoucherReversal(string eno)
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            IList<PFMDTO00054> tlfData = CXClientWrapper.Instance.Invoke<IMNMSVE00009, IList<PFMDTO00054>>(x => x.SelectForClrVoucherReversal(eno, sourceBr));
            this.TLFActype = tlfData;
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                return null;
            }
            else if (tlfData.Count <= 0)
                return null;
            else
                return tlfData;
        }       

        public void Reverse()
        {
            // Get Input Data
            PFMDTO00054 tlfdto = this.GetTlfEntity();
            tlfdto.DateTime = dateInTlf;
            this.isValidateForm = true;
            if (this.ValidateForm(tlfdto))
            {
              //  CXClientWrapper.Instance.Invoke<IMNMSVE00009>(x => x.Reverse(tlfdto));
                string vouncherNo = CXClientWrapper.Instance.Invoke<IMNMSVE00009, string>(x => x.Reverse(tlfdto)); //save to server

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    for (int i = 0; i < this.view.gridData.Count; i++)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = vouncherNo;//EntryNo 
                        logItemForTlf[2] = this.TLFActype[i].AccountNo;//AcctNo
                        logItemForTlf[3] = this.TLFActype[i].AccountNo;//Acode
                        logItemForTlf[4] = this.TLFActype[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.TLFActype[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), tlfdto.SourceBranchCode).ToString();//SettlementDate
                        if(this.TLFActype[i].TransactionCode == "Debit")
                        logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitVoucher) }).Status;//Status
                        else if (this.TLFActype[i].TransactionCode == "Credit")
                        logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditVoucher) }).Status;//Status
                        logItemForTlf[10] = tlfdto.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = this.view.Eno;//Rno
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Clearing Voucher Reversal Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                #region Successful
                else
                {
                    for (int i = 0; i < this.view.gridData.Count; i++)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = vouncherNo;//EntryNo
                        logItemForTlf[2] = this.TLFActype[i].AccountNo;//AcctNo
                        logItemForTlf[3] = this.TLFActype[i].AccountNo;//Acode
                        logItemForTlf[4] = this.TLFActype[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.TLFActype[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), tlfdto.SourceBranchCode).ToString();//SettlementDate
                        if (this.TLFActype[i].TransactionCode == "Debit")
                            logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitVoucher) }).Status;//Status
                        else if (this.TLFActype[i].TransactionCode == "Credit")
                            logItemForTlf[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditVoucher) }).Status;//Status
                        logItemForTlf[10] = tlfdto.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = this.view.Eno;//Rno
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Clearing Voucher Reversal Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);

                    }

                    this.View.Successful(CXMessage.MI30040); //Successfully Reversal Transaction.
                    this.ClearControls();
                }
                #endregion
            }
            this.isValidateForm = false;
        }
        #endregion "UI Logic"

        #region helper Mothod
        //get viewdata for reversal process
        private PFMDTO00054 GetTlfEntity()
        {
            PFMDTO00054 tlfdto = new PFMDTO00054();
            tlfdto.Eno = this.View.Eno;
            tlfdto.SourceBranchCode = CurrentUserEntity.BranchCode;
            tlfdto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            return tlfdto;
        }

        public void ClearControls()
        {
            this.View.Eno = string.Empty;
            this.View.Narration = string.Empty;
        }

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
