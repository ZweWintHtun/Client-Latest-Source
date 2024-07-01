//----------------------------------------------------------------------
// <copyright file="TLMCTL00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// CLEARING VOUCHER CONTROLLER
    /// </summary>
    public class TLMCTL00021 : AbstractPresenter, ITLMCTL00021
    {
        #region INITIALIZE VIEW
        private ITLMVEW00021 view;
        public ITLMVEW00021 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00021 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetClearingVoucherEntity());
            }
        }
        #endregion

        #region PROPERTIES
        IList<ChargeOfAccountDTO> coaDTOList { get; set; }
        public IList<PFMDTO00054> tlfList { get; set; }
        #endregion

        #region HELPER METHODS

        public PFMDTO00054 GetClearingVoucherEntity()
        {
            PFMDTO00054 clearingVoucherEntity = new PFMDTO00054();
            clearingVoucherEntity.ReferenceVoucherNo = this.view.VoucherNo;
            clearingVoucherEntity.AccountNo = this.view.AccountNo;
            clearingVoucherEntity.Description = this.view.Description;
            clearingVoucherEntity.VoucherType = this.view.VoucherType;
            clearingVoucherEntity.CurrencyCode = this.view.CurrencyCode;
            clearingVoucherEntity.Amount = this.view.Amount;
            clearingVoucherEntity.Narration = this.view.Narration;
            clearingVoucherEntity.TransactionCode = this.view.TransactionCode;
            return clearingVoucherEntity;
        }

        public IList<ChargeOfAccountDTO> SelectCOAData()
        {
            this.coaDTOList = CXCLE00001.Instance.COASelectAccountNoAndAccountName(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CLHAccount), CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CBMAccount), this.view.CurrencyCode, CurrentUserEntity.BranchCode);
            return this.coaDTOList;
        }

        public IList<PFMDTO00054> InsertClearingVoucher()
        {
            IList<PFMDTO00054> tlfListDTO = new List<PFMDTO00054>();
            if (this.Validate())
            {                
                if (this.coaDTOList.Count > 0)
                {
                    PFMDTO00054 tlfdto = new PFMDTO00054();
                    tlfdto.AccountNo = this.view.AccountNo;
                    tlfdto.Amount = this.view.Amount;
                    tlfdto.CurrencyCode = this.view.CurrencyCode;
                    tlfdto.Description = this.view.Description;
                    tlfdto.Narration = this.view.Narration;
                    tlfdto.VoucherType = this.view.VoucherType;
                    tlfdto.TransactionCode = this.view.TransactionCode;
                    tlfdto.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                    tlfdto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    tlfdto.SourceBranchCode = CurrentUserEntity.BranchCode;
                    tlfListDTO.Add(tlfdto);
                    PFMDTO00054 tlfdto2 = new PFMDTO00054();
                    string acctno = (from value in this.coaDTOList where value.AccountName != this.view.AccountNo select value.AccountName).Single();
                    tlfdto2.AccountNo = acctno;
                    tlfdto2.Amount = this.view.Amount;
                    tlfdto2.CurrencyCode = this.view.CurrencyCode;
                    string accountName = (from value in this.coaDTOList where value.COASetUpAccountName != this.view.Description select value.COASetUpAccountName).Single();
                    tlfdto2.Description = accountName;
                    tlfdto2.Narration = tlfdto.Narration;
                    tlfdto2.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                    if (this.view.VoucherType == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DebitVoucherType))
                    {
                        tlfdto2.VoucherType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CreditVoucherType);
                        tlfdto2.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditVoucher);
                    }
                    else
                    {
                        tlfdto2.VoucherType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DebitVoucherType);
                        tlfdto2.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitVoucher);
                    }
                    tlfListDTO.Add(tlfdto2);
                    this.view.gv_ClearingVoucherDataBind(tlfListDTO);
                }

            }
                return tlfListDTO;            
        }

        #endregion

        #region UI LOGIC

        public void ClearControls()
        {
            this.view.VoucherNo = string.Empty;
            this.view.AccountNo = string.Empty;
            this.view.Description = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.Amount = 0;
            this.view.Narration = string.Empty;
        }

        public void SaveClearingVoucher()
        {
            if (this.Validate())
            {
                IList<PFMDTO00054> tlfListDTO = this.InsertClearingVoucher();
                tlfList = CXClientWrapper.Instance.Invoke<ITLMSVE00021,IList<PFMDTO00054>>(x => x.SaveClearingVoucher(tlfListDTO));
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {

                    string vouno = tlfList[0].Eno;
                    for (int i = 0; i < tlfList.Count; i++)
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = tlfList[i].Eno;//EntryNo
                        logItemForTlf[2] = tlfList[i].AccountNo;//AcctNo
                        logItemForTlf[3] = tlfList[i].AccountNo;//ACode(from COASetUp)
                        logItemForTlf[4] = tlfList[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.view.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), tlfList[0].SourceBranchCode, true }).ToString();//SettlementDate
                        logItemForTlf[9] = tlfList[i].Status;//Status
                        logItemForTlf[10] = tlfList[0].SourceBranchCode;//SourceBr
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Clearing Voucher Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                 
                #region Successful
                else
                {

                    string vouno = tlfList[0].Eno;
                    for (int i = 0; i < tlfList.Count; i++)
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = tlfList[i].Eno;//EntryNo
                        logItemForTlf[2] = tlfList[i].AccountNo;//AcctNo
                        logItemForTlf[3] = tlfList[i].AccountNo;//ACode(from COASetUp)
                        logItemForTlf[4] = tlfList[i].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = this.view.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), tlfList[0].SourceBranchCode, true }).ToString();//SettlementDate
                        logItemForTlf[9] = tlfList[i].Status;//Status
                        logItemForTlf[10] = tlfList[0].SourceBranchCode;//SourceBr
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Clearing Voucher Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    this.view.VoucherNo = vouno;
                    this.view.Successful("MI00051", this.view.VoucherNo);
                    this.ClearControls();
                    this.view.gvClearing_DataSourceNull();

                }
                #endregion
            }
        }
        #endregion

        #region VALIDATION LOGIC
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            else
            {
                try
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.DomesticAccountType))
                    {
                        if (this.SelectCOAData().Count > 0)
                        {
                            if (this.view.AccountNo == this.coaDTOList[0].AccountName || this.view.AccountNo == this.coaDTOList[1].AccountName)
                            {
                                string description = (from value in this.coaDTOList where value.AccountName == this.view.AccountNo select value.COASetUpAccountName).SingleOrDefault();
                                this.view.Description = description;
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00126);//Please  Re_Enter Clearing Account Only!
                            }

                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
        }

        public bool Validate()
        {            
            return this.ValidateForm(this.GetClearingVoucherEntity());

        }
        #endregion
    }
}
