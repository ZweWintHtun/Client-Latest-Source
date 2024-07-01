//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary> Editing
    /// Current Account - Company
    /// Current Account - Partnership
    /// Current Account - Association
    /// Saving Account - Company / Organization
    /// Fixed Account - Company / Organization
    /// Controller
    /// </summary>

    class MNMCTL00033 : AbstractPresenter, IMNMCTL00033
    {
        PFMDTO00050 BindData;
        private bool isValidateForm = false;
        private IMNMVEW00033 view;
        public IMNMVEW00033 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00033 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCompanyEntity());
            }
        }

        DateTime openDate;
        DateTime createdDate;
        int createdUserId;

        #region UI Logic

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.NameOfFirm = string.Empty;
            this.view.Email = string.Empty;
            this.view.Address = string.Empty;
            this.view.CityCode = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.Phone = string.Empty;
            this.view.Fax = string.Empty;
            this.view.TownshipCode = string.Empty;
            this.view.StateCode = string.Empty;
            this.view.Business = string.Empty;
            this.view.NoOfPersonSign = 0;
            this.view.ReceiptNo = string.Empty;
            this.view.FReceipt = new PFMDTO00032();
            this.view.ChequeBookNo = string.Empty;
            this.view.ChequeStartNo = string.Empty;
            this.view.ChequeEndNo = string.Empty;
            this.view.DebitLinkAccount = string.Empty;
            this.view.LinkAccountName = string.Empty;
            this.view.DebitLimit = 0;
            this.view.CustomerDataSource = null;
            this.view.BindCustomer();
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.SaveStatus = false;
            this.ClearAllCustomErrorMessage();

            this.View.EnableDisableControls();
            this.view.OldCustomers.Clear();
        }

        public bool AddCustomer()
        {
            // Validate date of birth is greater than 18.
            if (CXUIScreenTransit.Transit("frmPFMVEW00005", new object[] { false, true }) == System.Windows.Forms.DialogResult.OK)
            {
                PFMDTO00001 customer = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (customer != null)
                {
                    if (this.view.CustomerDataSource.Count > 0)
                    {
                        var duplicateRecord = this.view.CustomerDataSource.Where(x => x.CustomerId == customer.CustomerId).ToList<PFMDTO00001>();
                        if (duplicateRecord.Count() > 0)
                        {
                            // Duplicated Customer Id.
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00029);
                            return false;
                        }
                    }

                    this.view.CustomerDataSource.Add(customer);
                    return true;
                }
            }

            return false;
        }

        public void Save()
        {
            // Get Input Data
            PFMDTO00050 company = this.GetCompanyEntity();
            this.isValidateForm = true;

            company.AcceptedDate = openDate;
            company.CreatedDate = createdDate;
            company.CreatedUserId = createdUserId;            

            // Validation Logic
            if (this.ValidateForm(company))
            {
                // Saving Logic                
                CXClientWrapper.Instance.Invoke<IMNMSVE00033>(x => x.SaveCompany(company));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.View.SaveStatus = false;
                    this.View.Successful("MI90002");
                    //CXUIMessageUtilities.ShowMessageByCode("MI90002");
                        // Clear all controls
                        this.ClearControls();
                        this.View.SetEnable();
                }
            }

            this.isValidateForm = false;
        }
        #endregion

        #region Helper Methods

        public void mtxtAccountNo_CustomValidate(object sender, ValidationEventArgs e)
        {
            //if (e.HasXmlBaseError)
            //{
            //    return;
            //}
            Nullable<CXDMD00011> accountType;
            string accountNo = this.View.AccountNo.Replace("-", "");
            try
            {
                if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    string AccountType = string.Empty;
                    switch (this.View.AcSign)
                    {
                        case "CC": AccountType = "Current.Company." + this.View.CurrencyCode; break;

                        //Added by HWKO (28-Dec-2017)
                        case "BC": AccountType = "BUSINESSLOAN.Company." + this.View.CurrencyCode; break;

                        case "HC": AccountType = "HIREPURCHASELOAN.Company." + this.View.CurrencyCode; break;

                        case "PC": AccountType = "PERSONALLOAN.Company." + this.View.CurrencyCode; break;

                        case "DC": AccountType = "DEALER.Company." + this.View.CurrencyCode; break;
                        //End Region

                        case "CP": AccountType = "Current.PartnerShip." + this.View.CurrencyCode; break;
                        case "CA": AccountType = "Current.Association." + this.View.CurrencyCode; break;
                        case "SO": AccountType = "Saving.Company." + this.View.CurrencyCode; break;
                        case "FC": AccountType = "Fixed.Company." + this.View.CurrencyCode; break;
                    }

                    BindData = CXClientWrapper.Instance.Invoke<IMNMSVE00033, PFMDTO00050>(x => x.CheckingAccount(accountNo, AccountType, CurrentUserEntity.BranchCode));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (BindData != null && !string.IsNullOrEmpty(BindData.Message))
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { BindData.Message });
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                    else if (BindData != null)
                    {
                        this.View.EnableDisableInputControls(true);
                        if (!this.View.SaveStatus)
                        {
                            if (BindData.BranchCode != CurrentUserEntity.BranchCode)
                            {
                                // Invalid Branch Code
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                                return;
                            }
                            openDate = BindData.CustomerDTOs[0].DATE_TIME;
                            createdDate = BindData.CustomerDTOs[0].CreatedDate;
                            createdUserId = BindData.CustomerDTOs[0].CreatedUserId;
                            this.View.FillData(BindData);
                            this.View.SetDisable();
                           // this.View.SetFocus();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                if (ex.Message == "MV00114")
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void txtMinBal_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (this.View.MinBal > BindData.CurrentBal+BindData.OvdLimit)
            {
                //Total minimum balance can't be greater than ledger balance.
                this.SetCustomErrorMessage(this.GetControl("txtMinbal"), CXMessage.MV00062,new object[]{this.view.AccountNo});
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtMinbal"), string.Empty);
            }
        }

        private string GetPersonSignatureString()
        {
            string returnValue = string.Empty;

            returnValue += this.view.NoOfPersonSign + " Person";

            if (this.view.NoOfPersonSign > 1)
            {
                returnValue += "s";
            }

            return returnValue + " will assign.";
        }

        private string GetSubAccountTypeName(string transactionStatus)
        {
            switch (transactionStatus)
            {
                case "Current.Company":
                case "BUSINESSLOAN.Company": //Added by HWKO (28-Dec-2017)
                case "HIREPURCHASELOAN.Company": //Added by HWKO (28-Dec-2017)
                case "PERSONALLOAN.Company": //Added by HWKO (28-Dec-2017)
                case "DEALER.Company": //Added by HWKO (28-Dec-2017)
                case "Saving.Company":
                case "Fixed.Company":
                    return "Company / Organization";

                case "Current.Partnership":
                    return "Partnership";

                case "Current.Association":
                    return "Association";

                default:
                    return string.Empty;
            }
        }

        public void gvCustomer_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (this.view.CustomerDataSource.Count < 1)
                {
                    // This Account must at least two persons.
                    this.SetCustomErrorMessage(this.GetControl("gvCustomer"), CXMessage.MV00032);
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("gvCustomer"), string.Empty);
                }

                if (this.view.TransactionStatus == "Fixed.Company")
                {
                    
                        this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);

                }
            }
        }

        public void txtBusiness_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TransactionStatus == "Current.Partnership" && string.IsNullOrEmpty(this.view.Business))
            {
                this.SetCustomErrorMessage(this.GetControl("txtBusiness"), CXMessage.MV00021);
                return;
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtBusiness"), string.Empty);
            }
        }

        public void txtReceiptNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TransactionStatus == "Fixed.Company" && string.IsNullOrEmpty(this.view.ReceiptNo))
            {
                this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), CXMessage.MV00022);
                return;
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);
            }
        }

        public void txtNoOfPersonSign_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (this.isValidateForm == false && this.view.CustomerDataSource.Count == 0)
            {
                return;
            }

            if (this.view.NoOfPersonSign > this.view.CustomerDataSource.Count)
            {
                // Invalid No of Person to Sign.
                this.SetCustomErrorMessage(this.GetControl("txtNoPersonSign"), CXMessage.MV00028);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtNoPersonSign"), string.Empty);
            }
        }

        private PFMDTO00050 GetCompanyEntity()
        {
            PFMDTO00050 companyEntity = new PFMDTO00050();

            companyEntity.TransactionStatus = this.view.TransactionStatus;

            if (string.IsNullOrEmpty(this.view.TransactionStatus) == false)
            {
                companyEntity.AccountType = this.view.TransactionStatus.Substring(0, this.view.TransactionStatus.IndexOf("."));
                companyEntity.SubAccountType = this.view.TransactionStatus.Substring(this.view.TransactionStatus.IndexOf(".") + 1);
            }

            companyEntity.BranchCode = CXCOM00007.Instance.BranchCode;
            companyEntity.CurrencySymbol = this.view.CurrencSymbol;
            companyEntity.AccountNo = this.view.AccountNo.Replace("-", "");
            companyEntity.NameOfFirm = this.view.NameOfFirm;
            companyEntity.Email = this.view.Email;
            companyEntity.Address = this.view.Address;
            companyEntity.CityCode = this.view.CityCode;
            companyEntity.CurrencyCode = this.view.CurrencyCode;
            companyEntity.Phone = this.view.Phone;
            companyEntity.Fax = this.view.Fax;
            companyEntity.TownshipCode = this.view.TownshipCode;
            companyEntity.StateCode = this.view.StateCode;
            companyEntity.Business = this.view.Business;
            companyEntity.NoOfPersonSign = this.view.NoOfPersonSign;
            companyEntity.FReceipt = this.view.FReceipt;
            companyEntity.ChequeBookNo = this.view.ChequeBookNo;
            companyEntity.ChequeStartNo = this.view.ChequeStartNo;
            companyEntity.ChequeEndNo = this.view.ChequeEndNo;
            companyEntity.DebitLinkAccount = this.view.DebitLinkAccount == string.Empty ? null : this.view.DebitLinkAccount;
            companyEntity.DebitLimit = this.view.DebitLimit;
            //companyEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;            
            //companyEntity.CreatedDate = DateTime.Now;

            //added by ASDA**
            companyEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            companyEntity.UpdatedDate = DateTime.Now;
            //end**
            companyEntity.OldCustomerIds = this.view.OldCustomers;
            companyEntity.MinBal = this.view.MinBal;
            companyEntity.BranchCode = CurrentUserEntity.BranchCode;

            if (this.view.CustomerDataSource.Count > 0)
            {
                companyEntity.CustomerIds = this.view.CustomerDataSource.Select(x => x.CustomerId).ToArray<string>();
            }

            if (this.view.TransactionStatus == "Saving.Company")
            {
                companyEntity.SavingInterestRate = Convert.ToDecimal(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingInterestRate));
            }

            return companyEntity;
        }
        #endregion
    }
}
