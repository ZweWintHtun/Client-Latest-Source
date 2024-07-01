//----------------------------------------------------------------------
// <copyright file="TLMCTL00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-07-17 </CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Bankcash Scroll Controller
    /// </summary>
    public class TLMCTL00035 : AbstractPresenter, ITLMCTL00035
    {
        #region "Wire To"
        private ITLMVEW00035 bankCashScrollView;
        public ITLMVEW00035 BankCashScrollView
        {
            get { return this.bankCashScrollView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00035 view)
        {
            if (this.bankCashScrollView == null)
            {
                this.bankCashScrollView = view;
                this.Initialize(this.bankCashScrollView, this.GetViewData());
            }
        }
        #endregion

        #region "View Datas"
        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ReportTLFData = new PFMDTO00042();
            ReportTLFData.DateType = this.bankCashScrollView.DateType;
            ReportTLFData.CurrencyType = this.bankCashScrollView.CurrencyType;
            ReportTLFData.StartDate = this.bankCashScrollView.RequiredDate;          
            ReportTLFData.IsAllBranches = this.bankCashScrollView.IsAllBranch;
            ReportTLFData.IsHomeCurrency = this.bankCashScrollView.IsHomeCurrency;
            ReportTLFData.IsWithReversal = this.bankCashScrollView.IsWithReversal;
            ReportTLFData.BranchName = CurrentUserEntity.BranchDescription;
            ReportTLFData.CurCode = this.bankCashScrollView.Currency;
            ReportTLFData.WorkStation = CurrentUserEntity.WorkStationId.ToString();
            //*//
            string Branch = CurrentUserEntity.IsHOUser ? this.bankCashScrollView.IsAllBranch ? string.Empty : this.bankCashScrollView.BranchCode : CurrentUserEntity.BranchCode;
            ReportTLFData.SourceBranch = Branch;
            //*//
            //ReportTLFData.SourceBranch = CurrentUserEntity.BranchCode;
            ReportTLFData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            return ReportTLFData;
        }
        #endregion

        #region "Methods"
        public void Print()
        {
            PFMDTO00036 CS99DTO = new PFMDTO00036();
            if (this.ValidateForm(this.GetViewData()))
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.bankCashScrollView.RequiredDate))
                {                    
                    DateTime date = this.bankCashScrollView.RequiredDate.Date.AddDays(-1);
                    CS99DTO = this.bankCashScrollView.CurrencyType == "Source Currency" ? CS99DTO = CXClientWrapper.Instance.Invoke<ITLMSVE00035, PFMDTO00036>(x => x.GetSelectTopCS99(date, this.bankCashScrollView.Currency,CurrentUserEntity.BranchCode)) : CXClientWrapper.Instance.Invoke<ITLMSVE00035, PFMDTO00036>(x => x.GetSelectTopCS99WithoutCurrency(date,CurrentUserEntity.BranchCode));                                     
                    if (CS99DTO == null || CS99DTO.Balance <= 0)
                    {
                        
                        if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00014, this.bankCashScrollView.RequiredDate) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                    IList<PFMDTO00042> ReportTLFDTOList = new List<PFMDTO00042>();
                    PFMDTO00042 ReportTLFDTO = this.GetViewData();
                    ReportTLFDTO.SourceBranch = CurrentUserEntity.IsHOUser ? this.BankCashScrollView.IsAllBranch ? string.Empty : this.BankCashScrollView.BranchCode : CurrentUserEntity.BranchCode;
                    ReportTLFDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00035, PFMDTO00042>(x => x.GetReturnBalanceAndRCTLData(ReportTLFDTO));
                    if (ReportTLFDTOList.Count > 0)
                    {
                        if (ReportTLFDTO != null)
                        {
                            ReportTLFDTO.OrgnPoNo = "Bankcash Scroll Without Reversal By Home Currency";
                            // ReportTLFDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00035, PFMDTO00042>(x => x.GetReportDataForBankCashScroll(ReportTLFDTO));
                            // --> For With Reversal <--
                            if (this.bankCashScrollView.IsWithReversal == true)
                            {                              
                                if (this.bankCashScrollView.CurrencyType == "Home Currency")
                                {
                                    ReportTLFDTO.OrgnPoNo = "Bankcash Scroll With Reversal By Home Currency";
                                    /*For " With Reversal By Home Currency All" */
                                    CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList, ReportTLFDTO, "With Reversal By Home Currency By Date" });
                                }
                                else
                                {
                                    if (this.bankCashScrollView.IsHomeCurrency)
                                    {
                                        /* For " With Reversal By Home Currency"*/
                                        CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList, ReportTLFDTO, "With Reversal By Home Currency By Date" });
                                    }

                                    else
                                    {
                                        ReportTLFDTO.OrgnPoNo = "Bankcash Scroll Report With Reversal";
                                        /*For "With Reversal,For All Branch & Source Cur"*/
                                        CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList, ReportTLFDTO, "With Reversal By Date" });
                                    }
                                }
                            }
                            //--> For Without Reversal <--
                            else
                            {
                                if (this.bankCashScrollView.CurrencyType == "Home Currency")
                                {
                                    CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList, ReportTLFDTO, "Without Reversal By Home Currency By Date" });
                                }
                                else
                                {
                                    if (this.bankCashScrollView.IsHomeCurrency)
                                    {
                                        // For " With Reversal By Home Currency"
                                        CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList, ReportTLFDTO, "Without Reversal By Home Currency By Date" });
                                    }
                                    else
                                    {
                                        ReportTLFDTO.OrgnPoNo = "Bankcash Scroll Without Reversal";
                                        //For "Without Reversal"
                                        CXUIScreenTransit.Transit("frmTLMVEW00052WithReversalByDateHomeCurrency", true, new object[] { ReportTLFDTOList,ReportTLFDTO, "Without Reversal By Date" });
                                    }
                                }
                            }
                        }
                        else
                        {
                            //"No Data For Print" Message is shown.If it is null in SP_BANKING_BANKCASH_CALC_BYHOMECURALL.
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }
                        /*When Bank Cash Scroll DTo Lists <=0 */
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
                    /*When Required Date is greater than today Date */
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.bankCashScrollView.RequiredDate);
                    return;
                }
            }
        }
        #endregion
    }
}

