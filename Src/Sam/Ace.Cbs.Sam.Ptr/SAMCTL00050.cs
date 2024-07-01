//----------------------------------------------------------------------
// <copyright file="SAMCTL00050.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using System.Linq;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00050 : AbstractPresenter,ISAMCTL00050
    {
		#region Properties
		
		public SAMCTL00050() { }
        private ISAMVEW00050 view;
        public ISAMVEW00050 MessageView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00050 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }
						
		#endregion
		
		#region Methods
		
		public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        public void Save(PFMDTO00048 entity)
        {
            if (this.ValidateForm(entity))
            {
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                if (this.MessageView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<PFMDTO00048> MessageInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00050, IList<PFMDTO00048>>(x => x.CheckExist2(entity.Code, entity.Description));
                    if (MessageInfo.Count > 0)
                    {
                        PFMDTO00048 MessageActive = MessageInfo.Where<PFMDTO00048>(x => x.Active == false).FirstOrDefault();
                        if (MessageActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (MessageActive.Code == entity.Code)
                            {
                                entity.TS = MessageActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(MessageActive, entity);
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
                    CXClientWrapper.Instance.Invoke<ISAMSVE00050>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.MessageView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
						this.view.ControlSetting("Message.Enable", true);
                    }
                    else
                    {
                        this.MessageView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else  //Update
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.MessageView.PreviousMessageDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00050>(x => x.Update(entity, dvcvList, "Update"));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.MessageView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
						this.view.ControlSetting("Message.Enable", true);
                    }
                    else
                    {
                        this.MessageView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(entity.Code.ToString()))
                {
                    this.SetFocus("txtCode");
                }
                else if (string.IsNullOrEmpty(entity.Description.ToString()))
                {
                    this.SetFocus("txtDescription");
                }
            }
        }

        public void Delete(IList<PFMDTO00048> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00050>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.MessageView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
				this.view.ControlSetting("Message.Enable", true);
            }
            else
            {
                this.MessageView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00048> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00050, IList<PFMDTO00048>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00048>("PFMORM00048.Client.SelectAll",new object[]{true});
        }

        public PFMDTO00048 SelectByCode(string code)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00050, PFMDTO00048>(service => service.SelectByCode(code));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00048>("PFMORM00048.Client.SelectByCode",new object[] {code,true});
        }
		
		#endregion
		
	}
}

