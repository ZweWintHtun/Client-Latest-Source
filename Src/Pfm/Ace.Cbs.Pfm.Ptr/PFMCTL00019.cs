using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// Current Company
    /// Saving Company
    /// </summary>
    public class PFMCTL00019 : AbstractPresenter, IPFMCTL00019
    {
        #region Properties
        private bool isValidateForm = false;
        private IPFMVEW00019 view;
        public IPFMVEW00019 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        #endregion        

        #region UI Logic
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

        public void gvCustomer_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (this.view.CustomerDataSource.Count < 2)
                {
                    // This Account must at least two persons.
                    this.SetCustomErrorMessage(this.GetControl("gvCustomer"), CXMessage.MV00032);
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("gvCustomer"), string.Empty);
                }
            }
        }

        public void PrintData()
        {
            PFMDTO00061 companyPrinting = this.GetCompanyEntity();
            this.isValidateForm = true;

            if (this.ValidateForm(companyPrinting))
            {
                if (this.view.TransactionStatus == "Current Account (Company)")
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { companyPrinting, "Current Account Company Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00033", new object[] { companyPrinting, "Current Account Company Report 2" });
                }
                else if (this.view.TransactionStatus == "Saving Account (Co./Organization)")
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { companyPrinting, "Saving Company Account Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00034", new object[] { companyPrinting, "Saving Company Account Report 2" });
                }

                this.SetFocus("cboCurrency");
                this.ClearControls();
            }

            this.isValidateForm = false;
        }

        public void ClearControls()
        {
            this.view.Address = string.Empty;
            this.view.CityCode = string.Empty;
            this.view.CustomerDataSource = new List<PFMDTO00001>();
            this.view.BindCustomer();
            this.view.Email = string.Empty;
            this.view.Fax = string.Empty;
            this.view.IntroducedBy = string.Empty;
            this.view.NameOfFirm = string.Empty;
            this.view.NoOfPersonSign = 0;
            this.view.Phone = string.Empty;
            this.view.StateCode = string.Empty;
            this.view.TownshipCode = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.Signature = null;
            this.view.Photo = null;
            this.SetEnableDisable("butAddCustomer", true);
        }

        public bool AddCustomer()
        {
            if (CXUIScreenTransit.Transit("frmPFMVEW00005", new object[] { false, true }) == System.Windows.Forms.DialogResult.OK)
            {
                PFMDTO00001 customer = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (customer != null)
                {
                    if (this.view.CustomerDataSource == null)
                    {
                        this.view.CustomerDataSource = new List<PFMDTO00001>();
                    }

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
                    SAMDTO00053 nationality = CXCLE00002.Instance.GetScalarObject<SAMDTO00053>("SAMORM00053.Client.SelectByNationalityCode", customer.Nationality, true);
                    customer.Nationality = nationality.Description;
                    this.view.CustomerDataSource.Add(customer);
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Helper Methods
        private PFMDTO00061 GetCompanyEntity()
        {
            PFMDTO00061 companyEntity = new PFMDTO00061();

            companyEntity.TypeOfAccount = this.view.TransactionStatus + " (" + this.view.NoOfPersonSign + " person will be sign.)";
            companyEntity.CurrencyCode = this.view.CurrencyCode;
            companyEntity.NameOfFirm = this.view.NameOfFirm;
            companyEntity.Email = this.view.Email;
            companyEntity.Address = this.view.Address + ", " + this.view.TownshipCode + ", " + this.view.CityCode + ", " + this.view.StateCode;
            companyEntity.IntroducedBy = this.view.IntroducedBy;
            companyEntity.Phone = this.view.Phone;
            companyEntity.Fax = this.view.Fax;
            companyEntity.NoOfPersonSign = this.view.NoOfPersonSign;
            companyEntity.Logo = CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo);
            companyEntity.BankName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BankName);
            companyEntity.BranchName = CurrentUserEntity.BranchDescription;
            companyEntity.CityCode = this.view.CityCode;
            companyEntity.StateCode = this.view.StateCode;
            companyEntity.TownshipCode = this.view.TownshipCode;
            companyEntity.Customers = this.view.CustomerDataSource;
            companyEntity.TransactionStatus = this.view.TransactionStatus;

            return companyEntity;
        }

        private void WireTo(IPFMVEW00019 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetCompanyEntity());
            }
        }
        #endregion
    }
}