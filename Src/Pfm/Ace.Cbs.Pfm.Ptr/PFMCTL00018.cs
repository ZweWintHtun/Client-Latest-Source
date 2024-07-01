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
    /// Current Joint
    /// Saving Joint
    /// </summary>
    public class PFMCTL00018:AbstractPresenter,IPFMCTL00018
    {
        private bool isValidateForm = false;

        private IPFMVEW00018 view;
        public IPFMVEW00018 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IPFMVEW00018 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetJointEntity(false));
            }
        }

        #region UI Logic
        public void ClearControls()
        {
            //this.view.CurrencyCode = string.Empty;
            this.view.NoOfPersonSign = 0;
            this.view.IntroducedBy = string.Empty;
            this.view.CustomerDataSource = new List<PFMDTO00001>();
            this.view.BindCustomer();
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.JoinType = "A";
            this.SetFocus("cboCurrency");
            this.SetEnableDisable("butAddCustomers", true);
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

        public void txtNoOfPersonSign_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.CustomerDataSource != null)
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
        }

        public void Print()
        {
            PFMDTO00061 jointPrinting = this.GetJointEntity(true);
            this.isValidateForm = true;
            if (this.ValidateForm(jointPrinting))
            {
                if (view.TransactionStatus.Contains("Current Account (Joint)"))
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { jointPrinting, "Current Account Joint Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00006", new object[] { jointPrinting, "Current Account Joint Report 2" });
                    CXUIScreenTransit.Transit("frmPFMVEW00028", new object[] { jointPrinting.Customers, "Current Account Joint Report 3" });
                }

                else
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { jointPrinting, "Saving Account Joint Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00030", new object[] { jointPrinting, "Saving Account Joint Report 2" });
                }

                          
            }
            this.ClearControls();
            this.isValidateForm = false;
        }
        #endregion

        #region Helper Methods
        private PFMDTO00061 GetJointEntity(bool isPrint)
        {
            PFMDTO00061 joint = new PFMDTO00061();
            joint.IntroducedBy = this.view.IntroducedBy;
            joint.CurrencyCode = this.view.CurrencyCode;
            joint.NoOfPersonSign = this.view.NoOfPersonSign;
            joint.JoinType = this.view.JoinType;

            if (isPrint)
            {
                joint.Logo = CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo);
                joint.BankName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BankName);
                joint.BranchName = CurrentUserEntity.BranchDescription;
                joint.Customers = this.view.CustomerDataSource;
            }

            joint.TypeOfAccount = this.view.TransactionStatus + " Type " + this.view.JoinType + " (" + this.view.NoOfPersonSign + " person will be sign.)";
            joint.TransactionStatus = this.view.TransactionStatus;

            return joint;
        }        
        #endregion
    }
}