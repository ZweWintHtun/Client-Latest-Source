//----------------------------------------------------------------------
// <copyright file="SAMCTL00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Ix.Core.DataModel;
using System.Linq;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00052 : AbstractPresenter,ISAMCTL00052
    {
		#region Properties
		
		public SAMCTL00052() { }
        private ISAMVEW00052 view;
        public ISAMVEW00052 TranTypeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00052 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
						
		#endregion       
		
		#region Methods
		
        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}
    
        public void Save(TLMDTO00005 entity)
        {
             if (!this.ValidateForm(entity))
            {
                if (entity.TransactionCode == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                else if (entity.Narration == string.Empty)
                    this.SetFocus("txtNarration");
                else if (entity.Status == string.Empty)
                    this.SetFocus("txtStatus");
                else if (entity.PBReference == string.Empty)
                    this.SetFocus("txtPBReference");
                else if(entity.RVReference == string.Empty)
                    this.SetFocus("txtRVReference");
                return;
            }  
            
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                    if (this.TranTypeView.Status.Equals("Save"))
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        IList<TLMDTO00005> TranTypeInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00052, IList<TLMDTO00005>>(x => x.CheckExist2(entity.TransactionCode, entity.Description));
                        if (TranTypeInfo.Count > 0)
                        {
                            TLMDTO00005 TranTypeActive = TranTypeInfo.Where<TLMDTO00005>(x => x.Active == false).FirstOrDefault();
                            if (TranTypeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                            {
                                if (TranTypeActive.TransactionCode == entity.TransactionCode)
                                {
                                    entity.TS = TranTypeActive.TS;
                                    //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                    dvcvList = GetChangedValueOfObject.GetChangedValueList(TranTypeActive, entity);
                                    entity.Active = false;  //to check status in service
                                }
                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                                return;
                            }
                        }
                        else entity.Active = true;    //active = 1 , new data , so data will be save with insert nature 
                        CXClientWrapper.Instance.Invoke<ISAMSVE00052>(x => x.SaveServerAndServerClient(entity, dvcvList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.TranTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.view.ControlSetting("TranType.Enable", true);
                        }
                        else
                        {
                            this.TranTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else  //Update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.TranTypeView.PreviousTranTypeDto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00052>(x => x.Update(entity, dvcvList, "Update"));

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.TranTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.view.ControlSetting("TranType.Enable", true);
                        }
                        else
                        {
                            this.TranTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
              //  }
           
        }

        public void Delete(IList<TLMDTO00005> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00052>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.TranTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
				this.view.ControlSetting("TranType.Enable", true);
            }
            else
            {
                this.TranTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00005> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00052, IList<TLMDTO00005>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<TLMDTO00005>("TLMORM00005.Client.SelectAll",new object[]{true});
        }

        public TLMDTO00005 SelectByTranCode(string tranCode)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00052, TLMDTO00005>(service => service.SelectByTranCode(tranCode));
            //return CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("TLMORM00005.Client.SelectByTranCode",new object[] {tranCode,true});
        }
		
		#endregion
		
	}
}

