using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Drawing;
using Ace.Cbs.Cx.Com.Dmd;


namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>Editing
    /// Current Account - Individual
    /// Current Account - PrivateFirm
    /// Saving Account - Individual
    /// Saving Account - Minor
    /// Fixed Account - Individual
    /// Fixed Account - Minor
    /// Controller
    /// </summary>
    public class MNMCTL00031 : AbstractPresenter, IMNMCTL00031
    {
        private bool isValidateForm = false;
        private bool savestatus = false;
        private decimal OVDLimit;
        private decimal CurrentBal;

        #region VIEW
        private IMNMVEW00031 view;
        public IMNMVEW00031 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00031 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetAccountEntity());
            }
        }
        #endregion

        #region Properties
        public bool SaveStaus
        {
            get { return this.savestatus; }
            set { savestatus = value; }
        }
        #endregion

        #region UI Logic

        public void ClearControls(bool isOnlyCustomer)
        {
            this.view.Customer = new PFMDTO00001();
            this.view.AccountNo = string.Empty;
            this.view.CustomerName = string.Empty;
            this.view.NameOfFirm = string.Empty;
            this.view.FatherName = string.Empty;
            this.view.GuardianshipName = string.Empty;
            this.view.GuardianshipNRC = string.Empty;
            this.view.NRC = string.Empty;
            this.view.DateOfBirth = null;
            this.view.OccupationCode = string.Empty;
            this.view.Email = string.Empty;
            this.view.Address = string.Empty;
            this.view.CityCode = string.Empty;
            this.view.Phone = string.Empty;
            this.view.Fax = string.Empty;
            this.view.TownshipCode = string.Empty;
            this.view.StateCode = string.Empty;
            this.view.OccupationCode = string.Empty;
            this.view.MinimumBalance = 0; 
            this.view.OccupationCode = string.Empty;
            this.view.FatherName = string.Empty;
            this.view.NRC = string.Empty;
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.DateOfBirth = null;

            if (isOnlyCustomer == false)
            {
                this.view.Business = string.Empty;
                this.view.CurrencyCode = string.Empty;
                this.view.CurrencSymbol = string.Empty;
                this.view.CustomerId = string.Empty;
                this.view.ReceiptNo = string.Empty;
               
                this.view.ChequeBookNo = string.Empty;
                this.view.ChequeStartNo = string.Empty;
                this.view.ChequeEndNo = string.Empty;
                this.view.DebitLinkAccount = string.Empty;
                this.view.DebitLimit = 0;
                this.view.LinkAccountName = string.Empty;
            }
        }             

        public bool AddCustomer()
        {
            object[] objects = null;
            if (this.view.TransactionStatus == "Fixed.Minor" || this.view.TransactionStatus == "Saving.Minor")
            {
                // Validate date of birth is less than 18.
                objects = new object[] { true, false };
            }
            else
            {
                // Validate date of birth is greater than 18.
                objects = new object[] { false, true };
            }

            if (CXUIScreenTransit.Transit("frmPFMVEW00005", objects) == System.Windows.Forms.DialogResult.OK)
            {
                PFMDTO00001 customer = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (customer != null)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);
                    this.view.Customer = customer;
                    return true;
                }
            }

            return false;
        }        

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.NameOfFirm = string.Empty;
            this.view.Email = string.Empty;
            this.view.Address = string.Empty;
            this.view.CityCode = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.Phone = string.Empty;
            this.view.CustomerId = string.Empty;
            this.view.CustomerName = string.Empty;
            this.view.Fax = string.Empty;
            this.view.TownshipCode = string.Empty;
            this.view.StateCode = string.Empty;
            this.view.Business = string.Empty;
            //this.view.NoOfPersonSign = 0;
            this.view.ReceiptNo = string.Empty;
            this.view.DateOfBirth = null;
           
            this.view.ChequeBookNo = string.Empty;
            this.view.ChequeStartNo = string.Empty;
            this.view.ChequeEndNo = string.Empty;
            this.view.DebitLinkAccount = string.Empty;
            this.view.LinkAccountName = string.Empty;
            this.view.DebitLimit = 0;
            this.view.NRC = string.Empty;
            this.view.FatherName = string.Empty;
            this.view.OccupationCode = string.Empty;
            this.view.MinimumBalance = 0;
            //this.view.CustomerDataSource = null;
            //this.view.BindCustomer();
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.SaveStatus = false;
        }

        #endregion

        #region Main Method

        public void Save()
        {
            //try
            //{
                // Get Input Data
                PFMDTO00001 Entity = this.GetAccountEntity();
                this.isValidateForm = true;
                if (this.ValidateForm(Entity))
                {
                    // Saving Logic 
                    CXClientWrapper.Instance.Invoke<IMNMSVE00031>(x => x.SaveIndividual(Entity));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.savestatus = true;
                        this.view.Successful("MI90002");
                        // Clear all controls
                        this.ClearControls();
                        this.View.SetEnable();
                    }

                }
                this.isValidateForm = false;
            //}
            //catch (Exception ex)
            //{
            //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            //}
        }       

        #endregion

        #region Validation Logic
        public void mtxtCustomerId_CustomValidate(object sender, ValidationEventArgs e)
         {

             if (this.view.Customer != null)
             {
                 if (this.view.Customer.CustomerId == this.view.CustomerId && (!string.IsNullOrEmpty(this.view.CustomerName)))
                 {
                     return;
                 }
             }

             if (e.HasXmlBaseError == false)
             {
                 if (string.IsNullOrEmpty(this.view.CustomerId))
                 {
                     if (this.isValidateForm == false)
                     {
                         this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);
                         this.ClearControls(true);
                         
                         return;
                     }
                     else
                     {
                         this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00016);
                         return;
                     }
                 }

                 this.view.Customer = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(this.view.CustomerId));
                 if (this.view.Customer == null)
                 {
                     // Invalid Customer Id.
                     this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00016);
                     string Account = this.view.AccountNo;
                     this.ClearControls(true);
                     this.view.AccountNo = Account;
                 }
                 else
                 {
                     if (this.view.TransactionStatus == "Fixed.Minor" || this.view.TransactionStatus == "Saving.Minor")
                     {
                         if (this.view.Customer.DateOfBirth < DateTime.Now.AddYears(-18))
                         {
                             // Date of Birth should not be greater than 18.
                             this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00024);
                             this.ClearControls(true);
                         }
                     }
                     else
                     {
                         if (this.view.Customer.DateOfBirth > DateTime.Now.AddYears(-18))
                         {
                             // Date of Birth should be greater than 18.
                             this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00079);
                             this.ClearControls(true);
                         }
                         else
                         {
                             this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);
                             this.view.BindCustomer();
                         }
                     }
                 }
             }
         }

         public void txtMinBal_CustomValidating(object sender, ValidationEventArgs e)
         {
             if (e.HasXmlBaseError)
             {
                 return;
             }

             #region Remove checking min bal not greater than ledger balance. Comment By AAM (31-Jan-2018) For Pristine Version
             //if (this.View.MinimumBalance > CurrentBal + OVDLimit)
             //{
             //    //Total minimum balance can't be greater than ledger balance.
             //    this.SetCustomErrorMessage(this.GetControl("txtMinBal"), CXMessage.MV00062, new object[] { this.view.AccountNo });
             //}
             //else
             //{
             //    this.SetCustomErrorMessage(this.GetControl("txtMinbal"), string.Empty);
             //    this.SetFocus("cxcliC0011");
             //} 
             #endregion 
         }

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
                         case "CI": AccountType = "Current.Individual." + this.View.CurrencyCode; break;
                         //Added by HWKO (26-Dec-2017)
                         case "BI": AccountType = "BUSINESSLOAN.Individual." + this.View.CurrencyCode; break;

                         case "PI": AccountType = "PERSONALLOAN.Individual." + this.View.CurrencyCode; break;

                         case "HI": AccountType = "HIREPURCHASELOAN.Individual." + this.View.CurrencyCode; break;

                         case "DI": AccountType = "DEALER.Individual." + this.View.CurrencyCode; break;
                         //End Region
                         case "CS": AccountType = "Current.PrivateFirm." + this.View.CurrencyCode; break;
                         case "SI": AccountType = "Saving.Individual." + this.View.CurrencyCode; break;
                         case "SM": AccountType = "Saving.Minor." + this.View.CurrencyCode; break;
                         case "FI": AccountType = "Fixed.Individual." + this.View.CurrencyCode; break;
                         case "FM": AccountType = "Fixed.Minor." + this.View.CurrencyCode; break;
                     }

                     PFMDTO00001 BindData = CXClientWrapper.Instance.Invoke<IMNMSVE00031, PFMDTO00001>(x => x.CheckingAccount(accountNo, AccountType, CurrentUserEntity.BranchCode));
                     
                     if (BindData != null)
                     {
                         OVDLimit = BindData.OVDLimit;
                         CurrentBal = BindData.CurrentBal;
                         if (BindData.SourceBranch != CurrentUserEntity.BranchCode && string.IsNullOrEmpty(BindData.Message))
                         {
                             // Invalid Branch Code
                             this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                             return;
                         }
                     }                    

                     if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                     {
                         if (BindData != null && !string.IsNullOrEmpty(BindData.Message))
                         {
                             this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { BindData.Message });
                         }
                         else
                         {
                             this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                             CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);                            
                         }
                     }

                     else if (BindData != null && BindData.CustomerId!=null)
                     {
                         this.View.EnableDisableInputControls(true);
                         if(!this.View.SaveStatus)
                            this.View.FillData(BindData);
                         this.View.SetDisable();
                        
                     }
                 }
             }
             catch(Exception ex)
             {
                 // Set Error Message to Control.
                 if (ex.Message == "MV00114")
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                 else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
             }
            

         }

         public void cboCurrency_CustomValidate(object sender, ValidationEventArgs e)
                {
             if (e.HasXmlBaseError)
                 return;
             
         }
                             
#endregion

        #region Helper Methods

         private string GetSubAccountTypeName(string transactionStatus)
        {
            switch (transactionStatus)
            {
                case "Current.PrivateFirm":
                    return "Private Firm";

                case "Current.Individual":
                case "BUSINESSLOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "PERSONALLOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "HIREPURCHASELOAN.Individual": //Added by HWKO (26-Dec-2017)
                case "DEALER.Individual": //Added by HWKO (26-Dec-2017)
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

         private PFMDTO00001 GetAccountEntity()
         {
             PFMDTO00001 AccountEntity = new PFMDTO00001();

             AccountEntity.TransactionStatus = this.view.TransactionStatus;

             if (string.IsNullOrEmpty(this.view.TransactionStatus) == false)
             {
                 AccountEntity.AccountType = this.view.TransactionStatus.Substring(0, this.view.TransactionStatus.IndexOf("."));
                 AccountEntity.SubAccountType = this.view.TransactionStatus.Substring(this.view.TransactionStatus.IndexOf(".") + 1);
             }

             AccountEntity.BranchCode = CXCOM00007.Instance.BranchCode;
             AccountEntity.CurrencyCode = this.view.CurrencyCode;
             AccountEntity.AccountNo = this.view.AccountNo.Replace("-", "");
             AccountEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
             //added by ASDA**
             AccountEntity.CreatedDate = DateTime.Now; 
             AccountEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
             AccountEntity.UpdatedDate = DateTime.Now;
             //end**
             if (string.IsNullOrEmpty(this.view.CustomerId))
             {
                 AccountEntity.CustomerId = "0";
             }
             else
             {
                 AccountEntity.CustomerId = this.view.CustomerId;
             }
             AccountEntity.OldCustomerIds = this.view.oldCustomerID;
             AccountEntity.MinimumBalance = this.view.MinimumBalance;

             AccountEntity.NameofFirm = this.view.NameOfFirm;
             AccountEntity.Business = this.view.Business;

             return AccountEntity;
         }
                

        #endregion
    }
}
