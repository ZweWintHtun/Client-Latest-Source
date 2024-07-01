//----------------------------------------------------------------------
// <copyright file="TLMCTL00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-04</CreatedDate>
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
    /// Withdrawal Listing By All Controller
    /// </summary>
   public class TLMCTL00027:AbstractPresenter,ITLMCTL00027
   {
       #region "Private Variables"
        private bool isValidateForm = false;
        private const string withDrawalAll = "Withdrawal.All";
        private const string withDrawalCurrent = "Withdrawal.Current";
        private const string withDrawalSaving = "Withdrawal.Saving";
        private const string withDrawalFixed = "Withdrawal.Fixed";
        private const string withDrawalAccountNo = "Withdrawal.AccountNo";
        private const string withDrawalCounter = "Withdrawal.Counter";
        private string withDrawalListingByAllReport = "Withdrawal Listing By All Report";
        private string withDrawalListingByAcctTypeCurrentReport = "Withdrawal Listing By Account Type (Current) Report";
        private string withDrawalListingByAcctTypeSavingReport = "Withdrawal Listing By Account Type (Saving) Report";
        private string withDrawalListingByAcctTypeFixedDepositReport = "Withdrawal Listing By Account Type (Fixed) Report";
        private string withDrawalListingByAcctNoReport = "Withdrawal Listing By Account NO Report";
        private string withDrawalListingByCounterNoReport = "Withdrawal Listing By Counter No Report";

        // updated by ZMS (For Pristine)
        private const string withDrawalBL = "Withdrawal.BL";
        private const string withDrawalHP= "Withdrawal.HP";
        private const string withDrawalPL = "Withdrawal.PL";
        private const string withDrawalDL = "Withdrawal.DL";


        private string withDrawalListingByAcctTypeBLReport = "Withdrawal Listing By Account Type (Business Loans) Report";
        private string withDrawalListingByAcctTypeHPReport = "Withdrawal Listing By Account Type (HirePurchase) Report";
        private string withDrawalListingByAcctTypePLReport = "Withdrawal Listing By Account Type (Personal Loans) Report";
        private string withDrawalListingByAcctTypeDLReport = "Withdrawal Listing By Account Type (Dealer) Report";
        #endregion

       #region "For Initializer"
       private ITLMVEW00027 withdrawalListingByAllview;
        public ITLMVEW00027 WithdrawalListingByAllView
        {
            get { return this.withdrawalListingByAllview; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00027 view)
        {
            if (this.withdrawalListingByAllview == null)
            {
                this.withdrawalListingByAllview = view;
                this.Initialize(this.withdrawalListingByAllview, this.Print());
            }
        }
       #endregion

        #region "Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        private PFMDTO00042 Print()
        {
            try
            {
                PFMDTO00042 WithdrawalListingEntity = new PFMDTO00042();
                if (WithdrawalListingEntity != null)
                {
                    WithdrawalListingEntity.AcctNo = this.withdrawalListingByAllview.AccountNo;
                    WithdrawalListingEntity.CounterNo = this.withdrawalListingByAllview.EnterTellerNo;
                    WithdrawalListingEntity.TransactionStatus = this.withdrawalListingByAllview.TransactionStatus;
                }
                return WithdrawalListingEntity;
            }
            catch (Exception)
            {
                throw new Exception(CXMessage.ME00021);
            } 
        }


        public void MainPrint()
        {
            //string workstation = CurrentUserEntity.WorkStationId.ToString();
            int workstationId = CurrentUserEntity.WorkStationId;
            if (this.ValidateForm(this.Print()))
            {
                IList<PFMDTO00042> WithdrwalAllByTypeDTOList = new List<PFMDTO00042>();
                switch (this.withdrawalListingByAllview.TransactionStatus)
                {
                    case withDrawalAll:
                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, CurrentUserEntity.BranchCode, workstationId, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAllReport });
                        }
                        break;

                    case withDrawalCurrent:

                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "C%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeCurrentReport });
                        }
                        break;

                    // updated by ZMS (For Pristine)
                    case withDrawalBL:

                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "B%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeBLReport });
                        }
                        break;
                    case withDrawalHP:

                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "H%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeHPReport });
                        }
                        break;
                    case withDrawalPL:

                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "P%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypePLReport });
                        }
                        break;
                    case withDrawalDL:

                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "D%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeDLReport });
                        }
                        break;
                    // updated by ZMS (For Pristine)

                    case withDrawalSaving:
                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "S%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeSavingReport });
                        }
                        break;
                    case withDrawalFixed:
                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountTypeList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, "F%", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00066", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, withDrawalListingByAcctTypeFixedDepositReport });
                        }
                        break;
                    case withDrawalAccountNo:
                        WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByAccountNoList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, this.withdrawalListingByAllview.AccountNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, workstationId));
                        if (WithdrwalAllByTypeDTOList.Count <= 0)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                        else
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00068", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, this.withdrawalListingByAllview.AccountNo, withDrawalListingByAcctNoReport });
                        }
                        break;
                    case withDrawalCounter:  //Withdrawal by User No
                        if (CXClientWrapper.Instance.Invoke<ITLMSVE00027, bool>(x => x.IsValidUserNo(this.withdrawalListingByAllview.EnterTellerNo, CurrentUserEntity.BranchCode)))
                        {
                            WithdrwalAllByTypeDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00027, PFMDTO00042>(x => x.GetWithdrawalListingByCounterNoList(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, workstationId, this.withdrawalListingByAllview.EnterTellerNo, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                            if (WithdrwalAllByTypeDTOList.Count <= 0)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                            else
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00067", true, new object[] { WithdrwalAllByTypeDTOList, this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate, this.withdrawalListingByAllview.EnterTellerNo, withDrawalListingByCounterNoReport });
                            }
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90021");//Invalid User.
                        }
                        
                        break;
                }
                this.isValidateForm = false;
            }
        }

        public bool CheckDate()
        { 
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.withdrawalListingByAllview.StartDate, this.withdrawalListingByAllview.EndDate);
            return date;
        }


        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == true)
            {
                return;
            }
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.withdrawalListingByAllview.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    if (this.withdrawalListingByAllview.AccountNo.Substring(0, 3) != CurrentUserEntity.BranchCode)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                    }
                    else
                    {
                        //bool isFAOFORCledger = CXClientWrapper.Instance.Invoke<ITLMSVE00027, bool>(x => x.IsInFAOFAccountNoOrInCledgerAcNo(this.withdrawalListingByAllview.AccountNo));
                        //if (!isFAOFORCledger)
                        //{
                        //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        //    return;
                        //}
                        if (CXCLE00012.Instance.CheckAccountNoType(withdrawalListingByAllview.AccountNo, CXDMD00011.DomesticAccountType))
                        {
                            if (this.withdrawalListingByAllview.AccountNo.Substring(3) != "000")
                            {
                                string coa = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.Select", new object[] { this.withdrawalListingByAllview.AccountNo, CurrentUserEntity.BranchCode, true });
                                if (coa != null)
                                {
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                                }
                                else
                                {
                                    // Invalid Account No.
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                                }
                            }

                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00132);
                                return;
                            }
                        }                      
                    }
                }        
        }  
        #endregion
   }
}
