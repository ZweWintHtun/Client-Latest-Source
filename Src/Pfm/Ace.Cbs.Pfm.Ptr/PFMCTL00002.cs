using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;

namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// Current Account - Company
    /// Current Account - Partnership
    /// Current Account - Association
    /// Saving Account - Company / Organization
    /// Fixed Account - Company / Organization
    /// Controller
    /// </summary>
    public class PFMCTL00002 : AbstractPresenter, IPFMCTL00002
    {
        private bool isValidateForm = false;
        private IPFMVEW00002 view;
        public IPFMVEW00002 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IPFMVEW00002 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCompanyEntity());
            }
        }

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
            //Added by HWKO (15-Aug-2017)
            this.view.CompanyRegNo = string.Empty ;
            this.view.CompanyRegDate = DateTime.Now;
            this.view.CompanyRegExpDate = DateTime.Now;
            //End Region
            this.ClearAllCustomErrorMessage();
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

                    PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(customer.CustomerId));
                    if (customerResult != null)
                    {
                        if (customerResult.CustPhoto.CustPhotos != null)
                        {
                            this.view.Photo = CXClientGlobal.GetImage(customerResult.CustPhoto.CustPhotos);
                        }
                        else
                        {
                            this.view.Photo = null;
                        }

                        if (customerResult.Signature != null)
                        {
                            this.view.Signature = CXClientGlobal.GetImage(customerResult.Signature);
                        }
                        else
                        {
                            this.view.Signature = null;
                        }
                        PFMDTO00080 response = CXClientWrapper.Instance.Invoke<IPFMSVE00002, PFMDTO00080>(x => x.CheckBlackListCustomerByCustId(customer.CustomerId, CurrentUserEntity.BranchCode));
                        if (response.ResCode == "0000")
                        {
                            customer.BlackList = response.ResDesp;
                        }
                    }

                    this.view.CustomerDataSource.Add(customer);
                    return true;
                }
            }

            return false;
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

        public void Save()
        {
            // Get Input Data
            PFMDTO00050 company = this.GetCompanyEntity();
            this.isValidateForm = true;
            string accountCode = string.Empty;

            // Validation Logic
            if (this.ValidateForm(company))
            {
                // Saving Logic
                try
                {
                    accountCode = CXClientWrapper.Instance.Invoke<IPFMSVE00002, string>(x => x.SaveCompany(company));
                }
                catch { }

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.view.AccountNo = accountCode;

                    // Generated Account No is {0}.
                    this.view.Successful(CXMessage.MI00003, CXCLE00007.GetFormatStringBy999(accountCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat)));
                    this.SetEnableDisable("txtNoPersonSign", false);

                    // Printing Data
                    IList<string[]> printingData = this.GetPrintingData(accountCode);

                    try
                    {
                        // Printing Logic
                        if (!this.View.TransactionStatus.Contains("Current")
                            && !this.View.TransactionStatus.Contains("BusinessLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("HirePurchaseLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("PersonalLoan") //Added By HWKO (22-Jun-2017)
                            && !this.View.TransactionStatus.Contains("Dealer") //Added By HWKO (04-Aug-2017)
                            )
                        {
                            string formname = this.view.GetFormNameString("Information");
                            if (formname.Contains("Organization"))
                                if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.No)
                                    return;
                            if (this.view.TransactionStatus.Contains("Fixed")) // For Fixed Joint Account 
                            {
                                CXUIScreenTransit.Transit("frmPFMVEW00035", true, new object[] { accountCode });//added by ASDA
                                string status = CXUIScreenTransit.GetData<string>("PFMVEW00035");
                                if (status == "0")
                                {
                                    CXCLE00005.Instance.PrintingList(CXCOM00009.AccountOpeningDirectPrinting, CXCOM00009.PrintingHeadingCode, printingData[0][0], printingData, false, false);
                                }

                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30055);  //Please go to Certificate Printing.  --MI30055                                
                                }
                            }
                            else                            
                                CXCLE00005.Instance.PrintingList(CXCOM00009.AccountOpeningDirectPrinting, CXCOM00009.PrintingHeadingCode, printingData[0][0], printingData, false, false);
                            
                        }
                    }
                    catch (Exception)
                    {
                        this.view.Failure(CXMessage.ME00061);
                    }
                    finally
                    {
                        // Clear all controls
                        this.ClearControls();
                    }  
                }
            }

            this.isValidateForm = false;
        }
        #endregion

        #region Helper Methods
        private IList<string[]> GetPrintingData(string accountCode)
        {
            IList<string[]> printingData = new List<string[]>();
            string printingHeading = this.GetSubAccountTypeName(this.view.TransactionStatus);
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            printingData.Add(new string[] { printingHeading });
            printingData.Add(new string[] { this.GetPersonSignatureString() });
            printingData.Add(new string[] { accountCode + "(" + this.view.CurrencyCode + ")" + "(" + Branch.Bank_Alias + "-" + Branch.BranchDescription + ")" });
 
            printingData.Add(new string[] { this.view.NameOfFirm  });


            foreach (PFMDTO00001 customer in this.view.CustomerDataSource)
            {
                printingData.Add(new string[] { customer.Name, customer.NRC });
            }

            return printingData;
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
                case "Saving.Company":
                case "Fixed.Company":
                case "BusinessLoan.Company": //Added By HWKO (22-Jun-2017)
                case "HirePurchaseLoan.Company": //Added By HWKO (22-Jun-2017)
                case "PersonalLoan.Company": //Added By HWKO (22-Jun-2017)
                case "Dealer.Company": //Added By HWKO (04-Aug-2017)
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
            //if (e.HasXmlBaseError == false)
            //{
                if (this.view.CustomerDataSource.Count < 2)
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
                    if (this.view.FReceipt.Amount == 0)
                    {
                        // Invalid Receipt No.
                        this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), CXMessage.MV00022);
                        this.SetFocus("butReceipt");
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);
                    }
                }
            //}
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
            companyEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

            //Added by HWKO (15-Aug-2017)
            companyEntity.CpnyRegNo = this.view.CompanyRegNo;
            companyEntity.CpnyRegDate = this.view.CompanyRegDate;
            companyEntity.CpnyRegExpDate = this.view.CompanyRegExpDate;
            companyEntity.JoinType = this.view.JointType; // Added By AAM (05-Feb-2018) 
            //End Region

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