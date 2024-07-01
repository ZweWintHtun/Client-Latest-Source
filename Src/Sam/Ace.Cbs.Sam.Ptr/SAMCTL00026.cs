//----------------------------------------------------------------------
// <copyright file="SAMCTL00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
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
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Service;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00026 : AbstractPresenter,ISAMCTL00026
    {
		#region Properties
		
		public SAMCTL00026() { }
        private ISAMVEW00026 view;
        public ISAMVEW00026 RemitBrView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00026 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
        private TLMDTO00028 _previousRemittanceDto;
        public TLMDTO00028 PreviousRemittanceDto
        {
            get
            {
                if (_previousRemittanceDto == null)
                    return new TLMDTO00028();
                return _previousRemittanceDto;
            }
            set { this._previousRemittanceDto = value; }
        }

						
		#endregion
		
		#region Methods

        public void BindContorls()
        {
            TLMDTO00028 dto = this.SelectByCode();
            this.PreviousRemittanceDto = new TLMDTO00028();
            if (dto != null)
            {
                this.view.Id = this.PreviousRemittanceDto.Id = dto.Id;
                this.view.DrawAc = this.PreviousRemittanceDto.DrawingAccount = dto.DrawingAccount;
                this.view.EncashAc = this.PreviousRemittanceDto.EncashAccount = dto.EncashAccount;
                this.view.IBSComAc = this.PreviousRemittanceDto.IBSComAccount = dto.IBSComAccount;
                this.view.IRPOAC = this.PreviousRemittanceDto.IRPOAccount = dto.IRPOAccount;
                this.view.TlxCharges = this.PreviousRemittanceDto.TelaxCharges = dto.TelaxCharges;
                this.view.TelexAc = this.PreviousRemittanceDto.TelaxAccount = dto.TelaxAccount;
                //this.RemitBrView.PreviousRemittanceDto.Currency = this.view.Currency;
                this.view.RmitRates = this.PreviousRemittanceDto.RemitRates = this.SelectListById(dto.Id);
                this.view.dgVRemitBr_DataBind();
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
                this.view.RmitRates = null;
                this.view.dgVRemitBr_DataBind();
                this.view.Status = "Save";
            }
        }

		public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
    
        public void Save(TLMDTO00028 entity,IList<TLMDTO00032> itemList)
        {
            if (this.ValidateForm(entity))
            {
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.RemitBrView.PreviousRemittanceDto, entity);
                CXClientWrapper.Instance.Invoke<ISAMSVE00026>(x => x.SaveServerAndServerClient(entity,itemList,dvcvList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.RemitBrView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    this.RemitBrView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
        }

        public void Delete(TLMDTO00028 itemList)
        {
            CXClientWrapper.Instance.Invoke<ISAMSVE00026>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.RemitBrView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.Status = "Save";
            }
            else
            {
                this.RemitBrView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        private TLMDTO00028 SelectByCode()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ISAMSVE00026, TLMDTO00028>(service => service.SelectById(this.view.Currency, this.view.BranchCode, this.view.SourceBranch));
                //return CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("TLMORM00028.Client.SelectByCode", new object[] { this.view.BranchCode, this.view.SourceBranch, this.view.Currency, true }); //nms
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private IList<TLMDTO00032> SelectListById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00026, IList<TLMDTO00032>>(service => service.SelectItemlistById(id)); 
            //return CXCLE00002.Instance.GetListObject<TLMDTO00032>("TLMORM00032.Client.SelectById",new object[] {id,true}); //nms
        }

        public IList<BranchDTO> SelectBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00026, IList<BranchDTO>>(service => service.SelectAllBranch());
            //return CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectAllBranchCodes",new object[]{true}); //nms

        }

        public IList<CurrencyDTO> GetCurrency()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, IList<CurrencyDTO>>(service => service.GetCurrency());
            //return CXCLE00002.Instance.GetListObject<CurrencyDTO>("Currency.Client.SelectCur",new object[]{true}); //nms
        }


        public void gvIBLRate_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if ((this.view.RmitRates = this.view.GetItemCollection()) == null)
                {
                    this.SetCustomErrorMessage(this.GetControl("gvIBLRate"), CXMessage.MV00037);
                }
                else if(this.view.RmitRates.Count < 1)
                {
                    this.SetCustomErrorMessage(this.GetControl("gvIBLRate"), CXMessage.MV00037);
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
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                this.SetCustomErrorMessage(this.GetControl("txtDrawingAccount"), CXMessage.MV20061);  //Invalid  Drawing Account. 
            }           
        }
        public void txtEashaccount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                ChargeOfAccountDTO dto = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.Select.AccountName", new object[] { this.view.EncashAc, this.view.SourceBranch });
            }

            catch(Exception ex)
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
            catch(Exception ex)
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
            catch(Exception ex)
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
            catch (Exception ex)
            {
                if (ex.Message == CXMessage.ME00021 || ex.Message == CXMessage.ME90003)
                this.SetCustomErrorMessage(this.GetControl("txtIRpoaccount"), CXMessage.MV20064);  //Invalid IR PO Account.
            }
        }
		#endregion
		
	}
}