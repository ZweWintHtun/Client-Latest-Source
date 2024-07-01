using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00004 : AbstractPresenter, IPFMCTL00004
    {
        #region Private Variables
        private bool isSaveValidate = false;


        private string SourceBranchCode = CXCOM00007.Instance.BranchCode;

        #endregion

        #region For Initializer
        private IPFMVEW00004 view;
        public IPFMVEW00004 CustomerIdView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IPFMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        #endregion

        #region Validation Logic

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        #region oldCode

        //public void txtNRCNo_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError == false)
        //    {
        //        if (!string.IsNullOrEmpty(this.view.NRCNo.ToString()))
        //        {
        //            if (this.view.NRCNo.Length < 6)
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
        //                return;

        //            }
        //        }
        //    }
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.NRCNo.ToString()))
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
        //        }
        //    }
        //}

        //public void txtNRC_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.NRC.ToString()))
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("txtNRC"),CXMessage.MV00004);
        //        } 
        //    }
        //}

        //public void cboStateCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (this.view.ViewData.NRCCheckStatus && this.view.StateCodeForNRC == null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboStateCode"), CXMessage.MV20004);
        //        }
        //    }
        //}

        //public void cboTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (this.view.ViewData.NRCCheckStatus && this.view.TownshipCodeForNRC == null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboTownshipCode"), CXMessage.MV20005);
        //        }
        //    }
        //}

        //public void cboNationalityCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (this.view.ViewData.NRCCheckStatus && this.view.NationalityCodeForNRC == null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboNationalityCode"), CXMessage.MV00003);
        //        }
        //    }
        //}

        //public void cboFatherStateCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (!this.view.ViewData.NRCCheckStatus && this.view.FatherStateCodeForNRC ==null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboFatherStateCode"), CXMessage.MV20004);
        //        }
        //    }
        //}
        //public void cboFatherTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (!this.view.ViewData.NRCCheckStatus && this.view.FatherTownshipCodeForNRC == null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboFatherTownshipCode"), CXMessage.MV20005);
        //        }
        //    }
        //}
        //public void cboFatherNationalityCode_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        if (!this.view.ViewData.NRCCheckStatus && this.view.FatherNationalityCodeForNRC == null)
        //        {
        //            this.ClearErrors();
        //            this.SetCustomErrorMessage(this.GetControl("cboFatherNationalityCode"), CXMessage.MV00003);
        //        }
        //    }
        //}

        //public void txtFatherNRCNo_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError == false)
        //    {

        //        if (!string.IsNullOrEmpty(this.view.FatherNRCNo.ToString()))
        //        {
        //            if (this.view.FatherNRCNo.Length < 6)
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), CXMessage.MV00004);
        //                return;

        //            }
        //            else if (this.view.ViewData.NRC.Equals(this.view.FatherStateCodeForNRC + this.view.FatherTownshipCodeForNRC + this.view.FatherNationalityCodeForNRC + this.view.FatherNRCNo))
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), "MV00015");    //Duplicated NRC No.
        //            }
        //        }
                
        //    }
        //    if (this.view.FormState == FormState.Edit)
        //    {
        //        this.ClearErrors();
        //        if (!this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.FatherNRCNo.ToString()))
        //        {
                    
        //            this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), CXMessage.MV00004);
        //        }
        //    }
        //}

        //public void txtFatherGuardianNRC_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError)
        //        return;
        //    string NRC = this.view.NRCCode().ToString();

        //    if (NRC.Equals(this.view.GuardianNRCNo))
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtFatherGuardianNRC"), "MV00015");    //Duplicated NRC No.
        //    }
        //    else
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtFatherGuardianNRC"), string.Empty);
        //    }
        //}
        #endregion

        #region CustNRC Validation
        public void txtNRCNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.NRCNo.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
            }
            else if (!string.IsNullOrEmpty(this.view.NRCNo.ToString()))
            {
                if (this.view.NRCNo.Length < 6)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV00004);
                    return;
                }
                else
                {
                    PFMDTO00080 response = CXClientWrapper.Instance.Invoke<IPFMSVE00004, PFMDTO00080>(x => x.CheckNRCForExternalBlackListCustomer(this.view.ViewData.NRC, CurrentUserEntity.BranchCode));
                    if (response.ResCode == "0000")
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtNRCNo"), CXMessage.MV90229);
                        this.view.ClearNRC();                  

                        return;
                    }
                }
            }
            
        }

        public void txtNRC_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.NRC.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtNRC"), CXMessage.MV00004);
            }
            else
            {
                PFMDTO00080 response = CXClientWrapper.Instance.Invoke<IPFMSVE00004, PFMDTO00080>(x => x.CheckNRCForExternalBlackListCustomer(this.view.ViewData.NRC, CurrentUserEntity.BranchCode));
                if (response.ResCode == "0000")
                {
                    this.SetCustomErrorMessage(this.GetControl("txtNRC"), CXMessage.MV90229);
                    this.view.ClearNRC();
                    return;
                }
            }
        }

        public void cboStateCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.StateCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboStateCode"), CXMessage.MV20004);
            }
        }

        public void cboTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.TownshipCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboTownshipCode"), CXMessage.MV20005);
            }
        }

        public void cboNationalityCode_CustomValidating(object sender, ValidationEventArgs e)
        {
           if (this.view.NationalityCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboNationalityCode"), CXMessage.MV00003);
            }
        }
        #endregion

        #region FatherNRC & Name Validation
        public void cboFatherStateCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.FatherStateCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboFatherStateCode"), CXMessage.MV20004);
            }
        }
        public void cboFatherTownshipCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.FatherTownshipCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboFatherTownshipCode"), CXMessage.MV20005);
            }
        }
        public void cboFatherNationalityCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.FatherNationalityCodeForNRC == null)
            {
                this.SetCustomErrorMessage(this.GetControl("cboFatherNationalityCode"), CXMessage.MV00003);
            }
        }
        
        public void txtFatherNRCNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrEmpty(this.view.FatherNRCNo.ToString()))
            {

                this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), CXMessage.MV00004);
            }
            else if (!string.IsNullOrEmpty(this.view.FatherNRCNo.ToString()))
            {
                if (this.view.FatherNRCNo.Length < 6)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), CXMessage.MV00004);
                    return;

                }
                else if (this.view.ViewData.NRC.Equals(this.view.FatherStateCodeForNRC + this.view.FatherTownshipCodeForNRC + this.view.FatherNationalityCodeForNRC + this.view.FatherNRCNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtFatherNRCNo"), "MV00015");    //Duplicated NRC No.
                }
            }           
        }

        public void txtFatherGuardianNRC_CustomValidating(object sender, ValidationEventArgs e)
        {
            string NRC = this.view.NRCCode().ToString();
            if (!this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.GuardianNRCNo.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtFatherGuardianNRC"), CXMessage.MV00013);
            }
            else if (NRC.Equals(this.view.GuardianNRCNo))
            {
                this.SetCustomErrorMessage(this.GetControl("txtFatherGuardianNRC"), "MV00015");    //Duplicated NRC No.
            }
        }

        public void txtGuardianshipName_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!this.view.ViewData.NRCCheckStatus && string.IsNullOrEmpty(this.view.GuardianName.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("txtGuardianshipName"), CXMessage.MV00014);
            }
        }
        #endregion

        public void CustomerId_CustomValidating(object sender, ValidationEventArgs e)
        {

            if (e.HasXmlBaseError == false)
            {
                if (this.CustomerIdView.FormState == FormState.Edit && string.IsNullOrEmpty(this.view.CustomerId))
                {
                    if (this.isSaveValidate == false)
                    {

                        this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), string.Empty);

                        return;
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00016);

                        return;
                    }
                }

                //PFMDTO00001 customerId = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(this.view.CustomerId));
                PFMDTO00001 customerId = this.SelectByCustomerId(this.CustomerIdView.CustomerId);
                if (customerId != null)
                {
                    this.CustomerIdView.IsInitialStateForNRC = true;
                    this.CustomerIdView.IsInitialStateForFatherNRC = true;
                    this.CustomerIdView.RebindCustomerInformation(customerId);
                    
                }
                else
                {
                    // Invalid Customer Id.
                    this.SetCustomErrorMessage(this.GetControl("mtxtCustomerID"), CXMessage.MV00016);
                }              

            }
        }


        public void DateOfBirthd_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            
            if (this.view.DateOfBirth.Date > DateTime.Now.Date)
            {
                this.SetCustomErrorMessage(this.GetControl("dtpDOB"), CXMessage.MV00225); // Date of Birth must not be greater than today date.
            }
            //else if (this.view.IsValidateGreaterThan18 && this.view.DateOfBirth > DateTime.Now.AddYears(-18))
            else if (this.view.DateOfBirth.Date > DateTime.Now.AddYears(-18).Date)
            {                    
                this.SetCustomErrorMessage(this.GetControl("dtpDOB"), CXMessage.MV00079);//Date of Birth should be greater than 18.
            }
            // Not use becasue Pristine has no Minor Account
            //else if (this.view.IsValidateLessThan18 && this.view.DateOfBirth < DateTime.Now.AddYears(-18))                
            //{
            //    // Date of Birth should not be greater than 18.
            //    this.SetCustomErrorMessage(this.GetControl("dtpDOB"), CXMessage.MV00024);//Date of Birth should not be greater than 18.
            //}
           
        }

        public override bool ValidateForm(object validationContext)
        {
            
            return base.ValidateForm(validationContext);
        }
        
      

        #endregion

        #region Public Methods

        public bool Save(PFMDTO00001 entity)
        {

            if (this.ValidateForm(entity))
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.SourceBranch = SourceBranchCode;
                entity.DATE_TIME = DateTime.Now;

                string custId = CXClientWrapper.Instance.Invoke<IPFMSVE00004, string>(x => x.Save(entity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.CustomerIdView.RebindCustomerId(custId);

                    this.CustomerIdView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, CXCLE00007.GetFormatStringBy999(custId, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CustomerNoDisplayFormat)));

                    return true;
                }
                else
                {
                    this.CustomerIdView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update(PFMDTO00001 custEntity, PFMDTO00010 custphotoEntity)
        {
            this.isSaveValidate = true;
            if (this.ValidateForm(custEntity))
            {
                // custEntity.SourceBranch = SourceBranchCode;
                custEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

                // custphotoEntity.SourceBranch = SourceBranchCode;
                custphotoEntity.UpdatedDate = DateTime.Now;
                custphotoEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                custphotoEntity.CustPhotos = custEntity.CustPhoto.CustPhotos;
                custphotoEntity.CustPhotoName = custEntity.CustPhoto.CustPhotoName;
                //custphotoEntity.SourceBranch = CurrentUserEntity.BranchCode;

                CXClientWrapper.Instance.Invoke<IPFMSVE00004>(x => x.Update(custEntity, custphotoEntity));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.CustomerIdView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, custEntity.CustomerId);
                    return true;
                }
                else
                {
                    this.CustomerIdView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
            }
            this.isSaveValidate = false;

            return false;


        }

        public PFMDTO00001 SelectByCustomerId(string customerid)
        {
            return CXClientWrapper.Instance.Invoke<IPFMSVE00004, PFMDTO00001>(service => service.SelectByCustomerId(customerid));
        }

        public void AddCustomer()
        {
            PFMDTO00001 customer = SelectByCustomerId(this.view.CustomerId);
            this.CustomerIdView.RebindCustomerInformation(customer);            
        }

        //public PFMDTO00080 CheckNRCForExternalBlackListCustomer(string NRC)
        //{
        //}
        #endregion
    }
}