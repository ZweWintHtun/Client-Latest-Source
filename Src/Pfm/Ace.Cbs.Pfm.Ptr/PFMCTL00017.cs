using System;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Sam.Dmd;


namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00017 : AbstractPresenter, IPFMCTL00017
    {
        #region "Properties"

        private bool IsValid;
        private IPFMVEW00017 view;
        public IPFMVEW00017 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region "CustomValidation"

        public void mtxtCustomerId_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.view.CustomerId))
            {
                this.ClearControls();
                return;
            }

            PFMDTO00001 custIdDTO = this.SearchCustomerId(this.view.CustomerId);
            if (custIdDTO != null)
            {
                if (this.view.TransactionStatus == "Saving Account (Minor)")
                {
                    if (custIdDTO.DateOfBirth < DateTime.Now.AddYears(-18))
                    {
                        // Date of Birth should not be greater than 18.
                        this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00024);
                        return;
                    }
                }
                else if (custIdDTO.DateOfBirth > DateTime.Now.AddYears(-18)) 
                {
                    // Date of Birth should be greater than 18.
                    this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00079);
                    return;
                }

                this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);
                this.BindToControls(custIdDTO);
                this.IsValid = true;
                this.view.CheckValidCustomer(true);
            }
            else
            {
                // Invalid Customer Id.
                this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00016);
                this.view.CheckValidCustomer(false);
            }
        }

        public void txtIntroducedBy_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.IntroducedBy) && this.view.TransactionStatus != "Saving Account (Minor)")
            {
                this.SetCustomErrorMessage(this.GetControl("txtIntroducedBy"), CXMessage.MV00074);
            }
            else
                this.SetCustomErrorMessage(this.GetControl("txtIntroducedBy"), string.Empty);
        }
        #endregion

        #region "UI Logic"

        public void PrintData(string parameter)
        {
            PFMDTO00060 IndividualDTO = this.GetPrintingEntity();
            IndividualDTO.TypeOfAccount = parameter;
            if (this.ValidateForm(IndividualDTO) && IsValid)
            {
                if (parameter == "Current Account (Individual)")
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { IndividualDTO, "Current Individual Account Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00026", new object[] { IndividualDTO, "Current Individual Account Report 2" });
                }
                if (parameter == "Saving Account (Individual)")
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { IndividualDTO, "Saving Individual Account Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00029", new object[] { IndividualDTO, "Saving Individual Account Report 2" });
                }   
                if (parameter == "Saving Account (Minor)")
                {
                    CXUIScreenTransit.Transit("frmPFMVEW00025", new object[] { IndividualDTO, "Saving Minor Account Report 1" });
                    CXUIScreenTransit.Transit("frmPFMVEW00031", new object[] { IndividualDTO, "Saving Minor Account Report 2" });
                }
                this.SetFocus("mtxtCustomerID");
                this.ClearControls();                
            }
        }

        public void ClearControls()
        {
            this.view.CustomerId = "";
            this.view.NameofFirm = "";
            this.view.Occupation = "";
            this.view.EMail = "";
            this.view.Address = "";
            this.view.city = "";
            this.view.Nationality = "";
            this.view.IntroducedBy = "";
            this.view.FatherName = "";
            this.view.NRC = "";
            this.view.Phone = "";
            this.view.Fax = "";
            this.view.state = "";
            this.view.townshipcode = "";
            this.view.GuardianName = "";
            this.view.GuardianNRC = "";
            this.view.DateOfBirth = DateTime.Now;
            this.view.Photo = null;
            this.view.Signature = null;
            //this.view.Currency = null;
            this.ClearAllCustomErrorMessage();
        }

        private void BindToControls(PFMDTO00001 custId)
        {
            this.view.CustomerId = custId.CustomerId;
            this.view.NameofFirm = custId.Name;
            this.view.DateOfBirth = custId.DateOfBirth;            
            this.view.EMail = custId.Email;
            this.view.Address = custId.Address;
            SAMDTO00053 nationality = CXCLE00002.Instance.GetScalarObject<SAMDTO00053>("SAMORM00053.Client.SelectByNationalityCode", custId.Nationality, true);
            this.view.Nationality = nationality.Description;
            this.view.FatherName = custId.FatherName;
            this.view.NRC = custId.NRC;
            this.view.Phone = custId.PhoneNo;
            this.view.Fax = custId.FaxNo;
            
            if (custId.OccupationDesp == null)
            {
                this.view.Occupation = CXCLE00002.Instance.GetScalarObject<string>("OccupationCode.SelectByCode", custId.OccupationCode,true);
            }
            else
            {
                this.view.Occupation = custId.OccupationDesp;
            }

            if (custId.TownshipDesp == null)
            {
                this.view.townshipcode = CXCLE00002.Instance.GetScalarObject<string>("TownshipCode.SelectByCode", custId.TownshipCode);
            }
            else
            {
                this.view.townshipcode = custId.TownshipDesp;
            }

            if (custId.StateDesp == null)
            {
                this.view.state = CXCLE00002.Instance.GetScalarObject<string>("StateCode.SelectByCode", custId.StateCode);
            }
            else
            {
                this.view.state = custId.StateDesp;
            }

            if (custId.CityDesp == null)
            {
                this.view.city = CXCLE00002.Instance.GetScalarObject<string>("CityCode.SelectByCode", custId.CityCode);
            }
            else
            {
                this.view.city = custId.CityDesp;
            }

            this.view.FullAddress = custId.Address + " , " + this.view.townshipcode + " , " + this.view.city + " , " + this.view.state;

            PFMDTO00001 customerResult = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(custId.CustomerId));
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
            }

            this.view.GuardianName = custId.GuardianName;
            this.view.GuardianNRC = custId.GuardianNRCNo;
        }

        #endregion

        #region "Helper Methods"

        public PFMDTO00001 SearchCustomerId(string custId)
        {
            PFMDTO00001 result = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(custId));
            return result;
        }

        public PFMDTO00001 GetCustomerData()
        {
            object[] objects = null;
            if (this.view.TransactionStatus == "Saving Account (Minor)")
            {
                // Validate date of birth is less than 18.
                objects = new object[] { true, false };
            }
            else
            {
                // Validate date of birth is greater than 18.
                objects = new object[] { false, true };
            }

            //CXUIScreenTransit.Transit("frmPFMVEW00005", new object[] { this.MenuIdForPermission, "Go To Search Screen." });
            if (CXUIScreenTransit.Transit("frmPFMVEW00005", objects) == DialogResult.OK)
            {
                PFMDTO00001 resultDTO = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (resultDTO != null)
                {
                    BindToControls(resultDTO);
                    this.IsValid = true;
                    return resultDTO;
                }
            }
            return null;
        }

        private PFMDTO00060 GetPrintingEntity()
        {
            PFMDTO00060 entity = new PFMDTO00060();
            entity.CustomerId = this.view.CustomerId;
            entity.Name = this.view.NameofFirm;
            entity.DateOfBirth = this.view.DateOfBirth;
            entity.Occupation = this.view.Occupation;
            entity.EMail = this.view.EMail;
            entity.Address = this.view.FullAddress;
            entity.Nationality = this.view.Nationality;
            entity.IntroducedBy = this.view.IntroducedBy;
            if (this.view.Photo != null) { entity.Photo = CXClientGlobal.ImageToByteArray(this.view.Photo); }
            entity.Currency = this.view.CurrencyCode;
            entity.FatherName = this.view.FatherName;
            entity.NRC = this.view.NRC;
            entity.Phone = this.view.Phone;
            entity.Fax = this.view.Fax;
            if (this.view.Signature != null) { entity.Signature = CXClientGlobal.ImageToByteArray(this.view.Signature); }
            entity.MatureDate = this.view.DateOfBirth.AddYears(18);
            entity.Logo = CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo);
            entity.BankName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BankName);
            entity.BranchName = CurrentUserEntity.BranchDescription;
            return entity;
        }

        #endregion

        private void WireTo(IPFMVEW00017 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.IndividualDTO);
            }
        }
    }
}