using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;


namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// Current Account - Individual
    /// Current Account - PrivateFirm
    /// Saving Account - Individual
    /// Saving Account - Minor
    /// Fixed Account - Individual
    /// Fixed Account - Minor
    /// Controller
    /// </summary>
    public class PFMCTL00001 : AbstractPresenter, IPFMCTL00001
    {
        private bool isSaveValidate = false;
        private IPFMVEW00001 view;

        public IPFMVEW00001 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IPFMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetIndividualEntity());
            }
        }

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
            this.view.MatureDate = null;
            this.view.OccupationCode = string.Empty;
            this.view.Email = string.Empty;
            this.view.Address = string.Empty;
            this.view.CityCode = string.Empty;
            this.view.Phone = string.Empty;
            this.view.Fax = string.Empty;
            this.view.TownshipCode = string.Empty;
            this.view.StateCode = string.Empty;
            this.view.Photo = null;
            this.view.Signature = null;

            if (isOnlyCustomer == false)
            {
                this.view.Business = string.Empty;
                //this.view.CurrencyCode = string.Empty;
                //this.view.CurrencSymbol = string.Empty;
                this.view.CustomerId = string.Empty;
                this.view.ReceiptNo = string.Empty;
                this.view.FReceipt = new PFMDTO00032();
                this.view.ChequeBookNo = string.Empty;
                this.view.ChequeStartNo = string.Empty;
                this.view.ChequeEndNo = string.Empty;
                this.view.DebitLinkAccount = string.Empty;
                this.view.DebitLimit = 0;
                this.view.LinkAccountName = string.Empty;
            }
        }

        public void GetDebitLinkAccount()
        {
            PFMDTO00001 customer = null;
            string customerId = string.Empty;

            if (string.IsNullOrEmpty(this.view.DebitLinkAccount) == false)
            {
                PFMDTO00017 caofAccount = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00017>(x => x.GetCAOFByAccountNumberAndSerialOfCustomer(this.view.DebitLinkAccount, 1));
                if (caofAccount == null)
                {
                    PFMDTO00016 saofAccount = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00016>(x => x.GetSAOFByAccountNumberAndSerialOfCustomer(this.view.DebitLinkAccount, 1));
                    if (saofAccount != null)
                    {
                        customerId = saofAccount.Customer_Id;
                    }
                    else
                    {
                        // Invalid Debit Link AccountNo.
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00026);
                        return;
                    }
                }
                else
                {
                    customerId = caofAccount.CustomerID;
                }

                if (string.IsNullOrEmpty(customerId) == false)
                {
                    customer = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(customerId));
                    if (customer != null)
                    {
                        this.view.LinkAccountName = customer.Name;
                    }
                }
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
                    PFMDTO00080 response = CXClientWrapper.Instance.Invoke<IPFMSVE00001, PFMDTO00080>(x => x.CheckBlackListCustomerByCustId(customer.CustomerId, CurrentUserEntity.BranchCode));
                    if (response.ResCode == "0000")
                    {
                        customer.BlackList = response.ResDesp;
                    }
                    this.view.Customer = customer;                    
                    return true;
                }
            }

            return false;
        }

        public void AddReceipt()
        {
            if (CXUIScreenTransit.Transit("frmPFMVEW00027", true, new object[] { false, this.view.TransactionStatus }) == DialogResult.OK)
            {
                PFMDTO00032 receipt = CXUIScreenTransit.GetData<PFMDTO00032>(this.view.TransactionStatus);
                if (receipt != null)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);
                    this.view.FReceipt = receipt;
                    this.view.ReceiptNo = receipt.ReceiptNo;
                }
            }
        }

        public void Save()
        {
            this.isSaveValidate = true;
            string accountCode = string.Empty;
            // Get Input Data
            PFMDTO00050 individual = this.GetIndividualEntity();

            // Validation Logic
            if (this.ValidateForm(individual))
            {
                // Saving Logic  
                try
                {
                    accountCode = CXClientWrapper.Instance.Invoke<IPFMSVE00001, string>(x => x.SaveIndividual(individual));
                }
                catch (Exception ex) { }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.view.AccountNo = accountCode;

                    // Message
                    this.view.Successful(CXMessage.MI00003, CXCLE00007.GetFormatStringBy999(accountCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat)));

                    if (this.view.TransactionStatus.Contains("Fixed"))  //Added by ASDA
                    {
                        CXUIScreenTransit.Transit("frmPFMVEW00035",true,new object[] { accountCode });
                        string status = CXUIScreenTransit.GetData<string>("PFMVEW00035");
                        if (status == "0")
                        {
                            this.PrintingTransaction(accountCode);
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30055);  //Please go to Certificate Printing.  --MI30055
                            this.ClearControls(false);
                        }//end-------------------------------------
                    }
                    else if (!this.View.TransactionStatus.Contains("BusinessLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("HirePurchaseLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("PersonalLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("Dealer") //Added By HWKO (04-Aug-2017)
                        )
                    {
                        this.PrintingTransaction(accountCode);
                    }

                    this.ClearControls(false);
                    #region Old Code  //comment by ASDA
                    //// Printing Logic
                        //IList<string[]> printingData = this.GetPrintingData(accountCode);                   
                        //try
                        //{
                        //    // Print Data
                        //    if (!this.View.TransactionStatus.Contains("Current"))
                        //        CXCLE00005.Instance.PrintingList("AccountOpeningDirectPrinting", "Heading", printingData[0][0], printingData, false, false);
                        //}
                        //catch (Exception e)
                        //{
                        //    //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(e.Message);
                        //    this.view.Failure(CXMessage.ME00061);
                        //}
                        //finally
                        //{
                        //    // Clear all controls
                        //    this.ClearControls(false);
                    //}
                    #endregion
                }
            }
            this.isSaveValidate = false;
        }

        public void PrintingTransaction(string accountCode)
        { 
             // Printing Logic
            IList<string[]> printingData = this.GetPrintingData(accountCode);                   
            try
            {
                // Print Data
                if (!this.View.TransactionStatus.Contains("Current"))
                    CXCLE00005.Instance.PrintingList("AccountOpeningDirectPrinting", "Heading", printingData[0][0], printingData, false, false);
            }
            catch (Exception e)
            {
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(e.Message);
                this.view.Failure(CXMessage.ME00061);
            }
            finally
            {
                // Clear all controls
                this.ClearControls(false);
            }
        }

        public void InputData_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TransactionStatus == "Fixed.Individual" || this.view.TransactionStatus == "Fixed.Minor")
            {
                if (this.view.FReceipt.Amount == 0)
                {
                    // Invalid Receipt No.
                    this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), CXMessage.MV00022);
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);
                }
            }
            else
            {
 
            }
        }

        public void mtxtCustomerId_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.Customer != null)
            {
                if(this.view.Customer.CustomerId == this.view.CustomerId && (!string.IsNullOrEmpty(this.view.CustomerName)))
                {
                    return;
                }
            }

            if (e.HasXmlBaseError == false)
            {
                if (string.IsNullOrEmpty(this.view.CustomerId))
                {
                    if (this.isSaveValidate == false)
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
                    this.ClearControls(true);
                }
                else
                {
                    PFMDTO00080 response = CXClientWrapper.Instance.Invoke<IPFMSVE00001, PFMDTO00080>(x => x.CheckBlackListCustomerByCustId(this.view.CustomerId, CurrentUserEntity.BranchCode));
                    if (response.ResCode == "0000")
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV90229);
                        return;
                    }

                    if (this.view.TransactionStatus == "Fixed.Minor" || this.view.TransactionStatus == "Saving.Minor")
                    {
                        if (this.view.Customer.DateOfBirth < DateTime.Now.AddYears(-18))
                        {
                            // Date of Birth should not be greater than 18.
                            this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00024);
                            this.ClearControls(true);
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);
                            this.view.BindCustomer();
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
        #endregion

        #region Helper Methods
        private IList<string[]> GetPrintingData(string accountCode)
        {
            IList<string[]> printingData = new List<string[]>();
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            string printingHeading = this.GetSubAccountTypeName(this.view.TransactionStatus);

            printingData.Add(new string[] { printingHeading });
            printingData.Add(new string[] { string.Empty });
            printingData.Add(new string[] { accountCode +" "+ "("+this.view.CurrencyCode+")" + "("+Branch.Bank_Alias +"-"+ Branch.BranchDescription +")"});
            printingData.Add(new string[] { string.Empty });
            printingData.Add(new string[] { this.view.CustomerName, this.view.NRC });

            switch (this.view.TransactionStatus)
            {
                case "Saving.Minor":
                    printingData.Add(new string[] { this.view.GuardianshipName, this.view.GuardianshipNRC });
                    break;

                case "Fixed.Minor":
                    IList<string[]> minorData = new List<string[]>();
                    printingData[3] = new string[] { this.view.CustomerName };
                    printingData.Add(new string[] { this.view.GuardianshipName, this.view.GuardianshipNRC }); 
                    break;
            }

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
                case "BusinessLoan.Individual": // Added By HWKO (22-Jun-2017)
                case "HirePurchaseLoan.Individual": // Added By HWKO (22-Jun-2017)
                case "PersonalLoan.Individual": // Added By HWKO (22-Jun-2017)
                case "Dealer.Individual": // Added By HWKO (04-Aug-2017)
                    return "Individual";

                case "Saving.Minor":
                case "Fixed.Minor":
                    return "Minor";

                default:
                    return string.Empty;
            }
        }

        private PFMDTO00050 GetIndividualEntity()
        {
            PFMDTO00050 individualEntity = new PFMDTO00050();

            individualEntity.TransactionStatus = this.view.TransactionStatus;

            if (string.IsNullOrEmpty(this.view.TransactionStatus) == false)
            {
                individualEntity.AccountType = this.view.TransactionStatus.Substring(0, this.view.TransactionStatus.IndexOf("."));
                individualEntity.SubAccountType = this.view.TransactionStatus.Substring(this.view.TransactionStatus.IndexOf(".") + 1);
            }

            individualEntity.BranchCode = CXCOM00007.Instance.BranchCode.Trim();
            individualEntity.CurrencySymbol = this.view.CurrencSymbol;
            individualEntity.CurrencyCode = this.view.CurrencyCode;

            individualEntity.CustomerId = this.view.CustomerId;
            individualEntity.Name = this.view.CustomerName;
            individualEntity.DateOfBirth = this.view.DateOfBirth;            
            // OccupationCode
            individualEntity.Email = this.view.Email;
            individualEntity.Address = this.view.Address;
            individualEntity.GuardianshipName = this.view.GuardianshipName;
            individualEntity.GuardianshipNRC = this.view.GuardianshipNRC;
            individualEntity.NameOfFirm = string.IsNullOrEmpty(this.view.NameOfFirm)? null:this.view.NameOfFirm;
            // individualEntity.FatherName = this.view.FatherName;
            // individualEntity.NRC = this.view.NRC;
            individualEntity.Phone = this.view.Phone;
            individualEntity.Fax = this.view.Fax;
            individualEntity.TownshipCode = this.view.TownshipCode;
            individualEntity.StateCode = this.view.StateCode;
            individualEntity.CityCode = this.view.CityCode;
            individualEntity.Business = this.view.Business;
            individualEntity.FReceipt = this.view.FReceipt;
            individualEntity.ChequeBookNo = this.view.ChequeBookNo;
            individualEntity.ChequeStartNo = this.view.ChequeStartNo;
            individualEntity.ChequeEndNo = this.view.ChequeEndNo;
            individualEntity.DebitLinkAccount = this.view.DebitLinkAccount == string.Empty ? null : this.view.DebitLinkAccount;
            individualEntity.DebitLimit = this.view.DebitLimit;
            individualEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

            if (this.view.TransactionStatus == "Saving.Individual" || this.view.TransactionStatus == "Saving.Minor")
            {
                individualEntity.SavingInterestRate = Convert.ToDecimal(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingInterestRate));
            }

            return individualEntity;
        }
        #endregion
    }
}
