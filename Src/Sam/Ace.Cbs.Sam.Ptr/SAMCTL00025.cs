// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.Contracts.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00025 : AbstractPresenter,ISAMCTL00025
    {
        #region Properties
		
		public SAMCTL00025() { }
        private ISAMVEW00025 view;
        public ISAMVEW00025 RemitBrIblView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00025 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

    
        

        private TLMDTO00029 _previousIBLRemitBrDto;
        public TLMDTO00029 PreviousIBLRemitBrDto
        {
            get 
            {
                if (_previousIBLRemitBrDto == null)
                    return new TLMDTO00029();
                return _previousIBLRemitBrDto;
            }
            set { this._previousIBLRemitBrDto = value; }
        }
						
		#endregion

        #region Methods

        public void BindContorls()
            {
            TLMDTO00029 dto = this.SelectByCode();
            this.PreviousIBLRemitBrDto = new TLMDTO00029();
            if (dto != null)
            {
                this.view.Id = this._previousIBLRemitBrDto.Id = dto.Id;
                this.view.DrawAc = this._previousIBLRemitBrDto.DrawingAccount = dto.DrawingAccount;
                this.view.EncashAc = this._previousIBLRemitBrDto.EncashAccount = dto.EncashAccount;
                this.view.IBSComAc = this._previousIBLRemitBrDto.IBSComAccount = dto.IBSComAccount;
                this.view.IRPOAC = this._previousIBLRemitBrDto.IRPOAccount = dto.IRPOAccount;
                this.view.TlxCharges = this._previousIBLRemitBrDto.TelaxCharges = dto.TelaxCharges;
                this.view.TelexAc  = this._previousIBLRemitBrDto.TelaxAccount = dto.TelaxAccount;
                this.view.RmitIblRates = this.PreviousIBLRemitBrDto.RmitIblRates = this.SelectListById(dto.Id);
                this.view.dgVRemitIblBr_DataBind();
                this.view.Status = "Update";
            }
            else
            {
                this.view.Id = 0;
                this.view.DrawAc = string.Empty;
                this.view.EncashAc = string.Empty;
                this.view.IBSComAc = string.Empty;
                this.view.IRPOAC = string.Empty;
                this.view.TlxCharges = 0;
                this.view.TelexAc = string.Empty;
                this.view.RmitIblRates = null;
                this.view.dgVRemitIblBr_DataBind();
                this.view.Status = "Save";
            }
        }

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        public void Save(TLMDTO00029 entity, IList<TLMDTO00030> itemList)
        {
            if (this.ValidateForm(entity))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.PreviousIBLRemitBrDto, entity);
                CXClientWrapper.Instance.Invoke<ISAMSVE00025>(x => x.SaveServerAndServerClient(entity, itemList,dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.RemitBrIblView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.RemitBrIblView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
        }

        public void Delete(TLMDTO00029 itemList)
        {
            CXClientWrapper.Instance.Invoke<ISAMSVE00025>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.RemitBrIblView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.Status = "Save";
            }
            else
            {
                this.RemitBrIblView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        private TLMDTO00029 SelectByCode()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ISAMSVE00025, TLMDTO00029>(service => service.SelectById(this.view.Currency, this.view.BranchCode, this.view.SourceBranch));
                //return CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("TLMORM00029.Client.SelectByCode", new object[] { this.view.BranchCode, this.view.SourceBranch, this.view.Currency, true }); //nms
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private IList<TLMDTO00030> SelectListById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00025, IList<TLMDTO00030>>(service => service.SelectItemlistById(id));
            //return CXCLE00002.Instance.GetListObject<TLMDTO00030>("TLMORM00030.Client.SelectById", new object[] { id,true }); //nms

        }

        public IList<BranchDTO> SelectBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00026, IList<BranchDTO>>(service => service.SelectAllBranch());
            //return CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectAllBranchCodes",new object[]{true}); //nms
        }

        //public IList<BranchDTO> SelectBranchCode()
        //{
        //    return CXClientWrapper.Instance.Invoke<IBranchService, IList<BranchDTO>>(service => service.GetAll());
        //}

        public IList<CurrencyDTO> GetCurrency()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, IList<CurrencyDTO>>(service => service.GetCurrency());
        }

        public void gvRemittanceBranchAndRate_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if ((this.view.RmitIblRates = this.view.GetItemCollection())== null)
                {
                    this.SetCustomErrorMessage(this.GetControl("gvRemittanceBranchAndRate"), CXMessage.MV00037);
                }
                else if (this.view.RmitIblRates.Count < 1)
                {
                    this.SetCustomErrorMessage(this.GetControl("gvRemittanceBranchAndRate"), CXMessage.MV00037);
                }
            }
        }

        public void txtDrawingAccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.DrawAc, this.view.SourceBranch });
            }
            catch(Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)    //Client Data Not Fount // Scalar Value Selecting
                this.SetCustomErrorMessage(this.GetControl("txtDrawingAccount"), CXMessage.MV20061);  //Invalid  Drawing Account.               
            }
        }
        public void txtEashaccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.EncashAc, this.view.SourceBranch });
            }
            catch (Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                    this.SetCustomErrorMessage(this.GetControl("txtEashaccount"), CXMessage.MV20062);   //Invalid Encash Account.
            }
        }
        public void txComssAccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.IBSComAc, this.view.SourceBranch });
            }
            catch (Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                    this.SetCustomErrorMessage(this.GetControl("txComssAccount"), CXMessage.MV20063);   //Invalid Commission Account.
            }
        }
        public void txttelexAccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.TelexAc, this.view.SourceBranch });
            }
            catch (Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                    this.SetCustomErrorMessage(this.GetControl("txttelexAccount"), CXMessage.MV20065);   //Invalid Telex Account.
            }
        }
        public void txtIRpoaccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.IRPOAC, this.view.SourceBranch });
            }
            catch(Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                this.SetCustomErrorMessage(this.GetControl("txtIRpoaccount"), CXMessage.MV20064);  //Invalid IR PO Account.
            }
        }
        #endregion
    }
}
