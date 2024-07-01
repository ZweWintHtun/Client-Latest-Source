//----------------------------------------------------------------------
// <copyright file="TLMCTL00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-05</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Center Table Deposit(Approve) Entry Controller
    /// </summary>
   public class TLMCTL00041:AbstractPresenter,ITLMCTL00041
   {
       #region "WireTo"
       private ITLMVEW00041 centerTableDepositApproveView;
        public ITLMVEW00041 CenterTableDepositApproveView
        {
            get { return this.centerTableDepositApproveView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00041 view)
        {
            if (this.centerTableDepositApproveView == null)
            {
                this.centerTableDepositApproveView = view;
                this.Initialize(this.centerTableDepositApproveView, CenterTableDepositApproveView);
            }
        }
       #endregion

       #region"Methods"

        public IList<TLMDTO00015> GetCashDenoList()        
        {
            IList<TLMDTO00015> CashDenoList = new List<TLMDTO00015>();
            string status=CXCOM00007.Instance.GetValueByKeyName("PaymentCashStatus");
            CashDenoList = CXClientWrapper.Instance.Invoke<ITLMSVE00041, TLMDTO00015>(x => x.GetCenterTableDepositDTOList(status, "NA",CurrentUserEntity.BranchCode));
            for (int i = 0; i < CashDenoList.Count; i++)
            {
                CashDenoList[i].DenostringForCenterTable = this.ReturnDenoString(CashDenoList[i].Currency, CashDenoList[i].DenoDetail);
                CashDenoList[i].Status = CXCOM00007.Instance.GetValueByKeyName("ReceiveCounterType");
                CashDenoList[i].AccountType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupCenterTable);
                //CashDenoList[0].IsCheck = true;
            }
            return CashDenoList;
        }
        private string ReturnDenoString(string currency,string denodetail)
        {
            int startPosition = 0;
            int endPosition;
            int times = 0;
            string stringReturn = string.Empty;
            string stringTemp;
            IList<TLMDTO00012> denolist = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode",new object[] {currency,true});
            while (startPosition < denodetail.Trim().Length)
            {
                endPosition = denodetail.IndexOf("*", startPosition);
                if (endPosition <= 0)
                {
                    endPosition = denodetail.Trim().Length;
                }
                if (times == 0)
                {
                    stringTemp = denodetail.Substring(startPosition, endPosition);
                }
                else
                {
                    stringTemp = denodetail.Substring(startPosition, endPosition - startPosition);
                }
                if (denolist.Count > 0)
                {
                    for (int i = 0; i < denolist.Count; i++)
                    {
                        if (denolist[i].Symbol == stringTemp.Substring(0, 1) && denolist[i].Currency==currency)
                        {
                            if (denolist[i].D1.ToString() != string.Empty)
                            {
                                stringReturn = stringReturn + denolist[i].D1 + "*" + (stringTemp.Substring(2, (stringTemp.Trim().Length - 2))) + ";";
                            }

                            else if (denolist[i].D2.ToString() != string.Empty)
                            {
                                stringReturn = stringReturn + denolist[i].D2 + "*" + (stringReturn.Substring(2, (stringReturn.Trim().Length - 2))) + ";";
                            }

                            startPosition = endPosition + 1;
                            times = times + 1;
                        }
                    }
                    stringReturn = stringReturn.Substring(0, stringReturn.Trim().Length-1);                   
                }
            }
            return stringReturn;
        }
        public void SaveCashDeno(IList<TLMDTO00015> CashDenoDTOsList)
        {
            for(int i=0;i <CashDenoDTOsList.Count;i++)
            {
                CXDTO00002 ExchangeRateStrings = CXCLE00011.Instance.GetDenoExchangeRateString(CashDenoDTOsList[i].Currency, CashDenoDTOsList[i].SourceBranchCode, CXCOM00007.Instance.GetValueByKeyName("CashRateType"));
                string HomeExchangeRate = ExchangeRateStrings.ExchangeRateString.ToString();
                CashDenoDTOsList[i].Rate=Convert.ToDecimal(HomeExchangeRate);
                CashDenoDTOsList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                CashDenoDTOsList[i].SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate),CurrentUserEntity.BranchCode,true });
            }
            IList<TLMDTO00015> registerNo = new List<TLMDTO00015>();
            registerNo = CXClientWrapper.Instance.Invoke<ITLMSVE00041, List<TLMDTO00015>>(x => x.SaveDTO(CashDenoDTOsList, CurrentUserEntity.CurrentUserID));
                #region Successful
            if (registerNo[registerNo.Count -1].Reverse == false)
                {
                    for (int i = 0; i < registerNo.Count; i++)
                    {
                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = registerNo[i].TlfEntryNo;//Tlf_Eno
                        logItemForDeno[1] = CashDenoDTOsList[i].AccountType;//AcType
                        logItemForDeno[2] = "Receive Counter " + "(" + CashDenoDTOsList[i].CounterNo + ")"; ;//FromType
                        logItemForDeno[3] = CashDenoDTOsList[i].Amount.ToString();//Amount
                        logItemForDeno[4] = string.Empty;//Cash_Date
                        logItemForDeno[5] = CashDenoDTOsList[i].DenoDetail;//Deno_Detail
                        logItemForDeno[6] = CashDenoDTOsList[i].DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = CashDenoDTOsList[i].Status;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = CashDenoDTOsList[i].SourceBranchCode;//sourcebr
                        logItemForDeno[10] = CashDenoDTOsList[i].Currency;//cur
                        logItemForDeno[11] = CashDenoDTOsList[i].DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CashDenoDTOsList[i].SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CashDenoDTOsList[i].Rate.ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Center Table Deposit(Approve) Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                        
                    }
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00045);
                    this.centerTableDepositApproveView.EnableNoOfCashierEntryNo();
                }
                #endregion

                #region ErrorOccurred
            else if (registerNo[registerNo.Count - 1].Reverse == true)
            {
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    for (int i = 0; i < registerNo.Count; i++)
                    {
                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = registerNo[i].TlfEntryNo;//Tlf_Eno
                        logItemForDeno[1] = CashDenoDTOsList[i].AccountType;//AcType
                        logItemForDeno[2] = "Receive Counter " + "(" + CashDenoDTOsList[i].CounterNo + ")"; ;//FromType
                        logItemForDeno[3] = CashDenoDTOsList[i].Amount.ToString();//Amount
                        logItemForDeno[4] = string.Empty;//Cash_Date
                        logItemForDeno[5] = CashDenoDTOsList[i].DenoDetail;//Deno_Detail
                        logItemForDeno[6] = CashDenoDTOsList[i].DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = CashDenoDTOsList[i].Status;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = CashDenoDTOsList[i].SourceBranchCode;//sourcebr
                        logItemForDeno[10] = CashDenoDTOsList[i].Currency;//cur
                        logItemForDeno[11] = CashDenoDTOsList[i].DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CashDenoDTOsList[i].SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CashDenoDTOsList[i].Rate.ToString();//Rate
                        if (registerNo[i].Reverse == false)
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Center Table Deposit(Approve) Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);   
                        else
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Center Table Deposit(Approve) Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);  

                    }
                    this.centerTableDepositApproveView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode, registerNo[registerNo.Count-1].TlfEntryNo);
                }
            }
            #endregion
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
