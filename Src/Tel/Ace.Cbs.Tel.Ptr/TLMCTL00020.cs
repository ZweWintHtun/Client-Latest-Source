//----------------------------------------------------------------------
// <copyright file="TLMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>7.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
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
using Ace.Cbs.Cx.Com.Dto;
using System.Linq;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00020 : AbstractPresenter, ITLMCTL00020
    {
        private ITLMVEW00020 view;
        public ITLMVEW00020 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00020 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        private TLMDTO00039 EncashData {get;set;}

        private TLMDTO00050 GetViewData()
        {
            TLMDTO00050 encashEntity = new TLMDTO00050();
            encashEntity.AccountNo = this.view.EncashAccount;
            encashEntity.Description = this.view.Description;
            encashEntity.Amount = this.view.Amount;
            encashEntity.Currency = this.view.Currency;
            encashEntity.ToAccountNo = this.view.ToAccountNo;
            encashEntity.ToName = this.view.ToName;
            encashEntity.AccountSign = this.view.AccountSign;
            encashEntity.Parameter = this.view.Parameter;
            encashEntity.EBank = this.view.EBank;
            encashEntity.RegisterNo = this.view.RegisterNo;
            encashEntity.SourceBranch = CurrentUserEntity.BranchCode;
            return encashEntity;
        }

        #region Helper Method
        public IList<TLMDTO00001> GetEncashData()
        {
            if(this.view.Parameter.Equals("T"))
                return CXClientWrapper.Instance.Invoke<ITLMSVE00020, IList<TLMDTO00001>>(service => service.GetEncashRemittanceData(CurrentUserEntity.BranchCode));
            else
                return CXClientWrapper.Instance.Invoke<ITLMSVE00020, IList<TLMDTO00001>>(service => service.GetEncashRemittanceDataCashType(CurrentUserEntity.BranchCode));
        }

        public string GetEncashAmount(string branchCode, string currency, string sourceBranchCode)
        {
            TLMDTO00028 dto = CXCLE00013.Instance.GetRemittanceAccountCode(branchCode, currency, sourceBranchCode, CXDMD00006.Encash);
            return dto.EncashAccount;
        }

        public string GetCOADescription(string acode, string currency, string sourceBranchCode)
        {
            ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { acode, sourceBranchCode });
            return dto.AccountName;
        }

        private string GetBranchList()
        {
           return CXCLE00002.Instance.GetScalarObject<string>("Branch.Client.Alias.Select", new object[] { this.View.EBank ,true});
           
        }

        private string GetCreditACode()
        {
            return CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.Currency, CurrentUserEntity.BranchCode, true });
        }

        private CXDTO00001 GetDenoString(decimal amount)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { amount, this.View.Currency, CXDMD00008.Received, this.View._Name }) == DialogResult.OK)
                return CXUIScreenTransit.GetData<CXDTO00001>(View._Name);
            else
                return null;
        }


        private TLMDTO00039 BindRawDTO() //<--------- To Bind TLMDTO00039 Data
        {
            EncashData = new TLMDTO00039();

            EncashData.Amount = this.View.Amount;
            EncashData.DebitAccountNo = View.AccountNo.Trim();
            EncashData.DebitDescription = this.View.Description;
            EncashData.Currency = this.View.Currency;
            EncashData.DebitAcode = this.View.AccountNo.Trim();
            EncashData.CreditAcode = this.GetCreditACode();
            EncashData.Narration = "Remit Transfer " + this.GetBranchList() + this.View.ToName;
            EncashData.UserNo = CurrentUserEntity.CurrentUserName;
            EncashData.SourceBranch = CurrentUserEntity.BranchCode;
            EncashData.RegisterNo = this.View.RegisterNo;
            EncashData.ReferenceVoucherNo = View.RegisterNo;
            EncashData.CreditAccountNo = this.View.ToAccountNo;
            EncashData.CreditDescription = this.View.ToName;
            EncashData.AccountSign = this.View.AccountSign;
            EncashData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            EncashData.CreatedDate = DateTime.Now;
            EncashData.UserNo = CurrentUserEntity.CurrentUserName;
            EncashData.RegisterNo = this.View.RegisterNo;
            return EncashData;
        }

        private IList<string[]> GetPrintingData(string accountCode)
        {
            IList<string[]> printingData = new List<string[]>();
            string printingHeading = "Current.Individual";//this.GetSubAccountTypeName(this.view.TransactionStatus);
            printingData.Add(new string[] { printingHeading });
            printingData.Add(new string[] { EncashData.CreditAccountNo+"(-)"});
            printingData.Add(new string[] { string.Empty });
            printingData.Add(new string[] { EncashData.Amount.ToString(), this.View.ToName });

            return printingData;
        }

        private string GetSubAccountTypeName(string transactionStatus)
        {
            switch (transactionStatus)
            {
                case "Current.PrivateFirm":
                    return "Private Firm";

                case "Current.Individual":
                case "Saving.Individual":
                case "Fixed.Individual":
                    return "Individual";

                case "Saving.Minor":
                case "Fixed.Minor":
                    return "Minor";

                default:
                    return string.Empty;
            }
        }

        public void ClearForm()
        {
            this.view.TempEncashList = this.GetEncashData();
            this.view.BindRegisterNoBoxes();
            this.view.tempEncashList = new List<TLMDTO00050>();
            this.view.BindGridView(this.view.tempEncashList);
        }

        public IList<TLMDTO00050> GetGridData(IList<TLMDTO00001> tempEncashList)
        {
            IList<TLMDTO00050> EncashList = new List<TLMDTO00050>();

            var getEncashData = (from value in tempEncashList
                                 where value.RegisterNo == this.View.RegisterNo
                                 select new
                                 {
                                     value.RegisterNo,
                                     value.Ebank,
                                     value.ToAccountNo,
                                     value.ToName,
                                     value.Amount,
                                     value.Currency,
                                     value.AccountSign,
                                     value.SourceBranchCode,
                                 }).First();

            this.view.RegisterNo = getEncashData.RegisterNo;
            this.view.Amount = getEncashData.Amount;
            this.view.Currency = getEncashData.Currency;
            this.view.AccountNo = this.GetEncashAmount(getEncashData.Ebank,getEncashData.Currency,getEncashData.SourceBranchCode);
            this.view.Description = this.GetCOADescription(this.View.AccountNo.Trim(), this.View.Currency, CXCOM00007.Instance.BranchCode);
            //this.view.Description = this.GetCOADescription("AAA001", "USD", CurrentUserEntity.BranchCode);
            this.view.EBank = getEncashData.Ebank;
            this.view.ToAccountNo = getEncashData.ToAccountNo;
            this.view.ToName = getEncashData.ToName;
            this.view.AccountSign = getEncashData.AccountSign;

            if (String.IsNullOrEmpty(this.view.ToAccountNo))
                this.view.Parameter = "C";
            else
                this.view.Parameter = "T";
            int count = (this.view.Parameter == "T") ? 2 : 1; //<----- To find row count to bind Data Grid (row count will be '1' if parameter is 'T' or row count '1' if parameter is 'C'.
            TLMDTO00050 tempEncashDTO;

            for (int i = 0; i < count; i++)
            {
                tempEncashDTO = new TLMDTO00050();
                tempEncashDTO.AccountNo = (i == 0) ? this.view.AccountNo : this.view.ToAccountNo;
                tempEncashDTO.Description = (i == 0) ? this.view.Description : this.view.ToName;
                tempEncashDTO.Currency = this.view.Currency;
                tempEncashDTO.Amount = this.view.Amount;
                tempEncashDTO.DebitCredit = (i == 0) ? "D" : "C";
                EncashList.Add(tempEncashDTO);
            }

            return EncashList;

        }

        #endregion
        public void Save()
        {
            this.BindRawDTO();
            string para = this.view.Parameter;
            string voucherNo = string.Empty;
            if (para.Equals("C"))//Cash
            {
                //CXDTO00001 dtostring = this.GetDenoString(EncashData.Amount);
                voucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00020, string>(x => x.SaveRemittanceEncashProcess(EncashData, para, null));
            }
            else//Transfer
            {
                voucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00020, string>(x => x.SaveRemittanceEncashProcess(EncashData,para,null));
            }
            #region ErrorOccurred
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                if (para.Equals("C"))//Cash
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = voucherNo;//EntryNo
                    logItemForTlf[2] = EncashData.DebitAccountNo;//AcctNo
                    logItemForTlf[3] = EncashData.DebitAcode;//ACode(from COASetUp)
                    logItemForTlf[4] = EncashData.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = EncashData.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), EncashData.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = EncashData.SourceBranch;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = EncashData.CreditAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = string.Empty;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Voucher(CashType) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                else
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = voucherNo;//EntryNo
                    logItemForTlf[2] = EncashData.DebitAccountNo;//AcctNo
                    logItemForTlf[3] = EncashData.DebitAcode;//ACode(from COASetUp)
                    logItemForTlf[4] = EncashData.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = EncashData.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), EncashData.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = EncashData.SourceBranch;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = EncashData.CreditAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = string.Empty;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Voucher(TransferType) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            #endregion

            #region Successful
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                if (para.Equals("C"))//Cash
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = voucherNo;//EntryNo
                    logItemForTlf[2] = EncashData.DebitAccountNo;//AcctNo
                    logItemForTlf[3] = EncashData.DebitAcode;//ACode(from COASetUp)
                    logItemForTlf[4] = EncashData.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = EncashData.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), EncashData.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = EncashData.SourceBranch;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = EncashData.CreditAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = string.Empty;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Voucher(CashType) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                else 
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = voucherNo;//EntryNo
                    logItemForTlf[2] = EncashData.DebitAccountNo;//AcctNo
                    logItemForTlf[3] = EncashData.DebitAcode;//ACode(from COASetUp)
                    logItemForTlf[4] = EncashData.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = EncashData.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), EncashData.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = EncashData.SourceBranch;//SourceBr
                    logItemForTlf[11] = string.Empty;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = EncashData.CreditAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = string.Empty;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Encash Voucher(TransferType) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
               this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode , voucherNo);

               //IList<string[]> printingData = this.GetPrintingData(EncashData.CreditAccountNo);

               //CXCLE00005.Instance.PrintingList(CXCOM00009.EncashRemitDirectPrinting, CXCOM00009.PrintingHeadingCode, printingData[0][0], printingData, false, false);
            }
            #endregion
        }

    }
}
