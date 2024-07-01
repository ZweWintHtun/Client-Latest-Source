//----------------------------------------------------------------------
// <copyright file="SAMCTL00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
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
	public class SAMCTL00016 : AbstractPresenter,ISAMCTL00016
    {
		#region Properties
		
		public SAMCTL00016() { }
        private ISAMVEW00016 view;
        public ISAMVEW00016 NewSetupView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00016 view)
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

        public void Save(PFMDTO00057 entity)
        {
            if (this.ValidateForm(entity))
            {
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                if (this.NewSetupView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<PFMDTO00057> NewSetUpInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00016, IList<PFMDTO00057>>(x => x.CheckExist2(entity.Variable, entity.Value));
                    if (NewSetUpInfo.Count > 0)
                    {
                        PFMDTO00057 NewSetUpActive = NewSetUpInfo.Where<PFMDTO00057>(x => x.Active == false).FirstOrDefault();
                        if (NewSetUpActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (NewSetUpActive.Variable == entity.Variable)
                            {
                                entity.TS = NewSetUpActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(NewSetUpActive, entity);
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
                    CXClientWrapper.Instance.Invoke<ISAMSVE00016>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.NewSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("NewSetup.Enable", true);
                    }
                    else
                    {
                        this.NewSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else  //Update
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.NewSetupView.PreviousNewSetupDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00016>(x => x.Update(entity, dvcvList, "Update"));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.NewSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("NewSetup.Enable", true);
                    }
                    else
                    {
                        this.NewSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            else
            {
                if (entity.Variable.ToString() == string.Empty)
                    this.SetFocus("txtVariable");
                else if (entity.Value.ToString() == string.Empty)
                    this.SetFocus("txtValue");
                return;
            }
        }

        public void Delete(IList<PFMDTO00057> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00016>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.NewSetupView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
				this.view.ControlSetting("NewSetup.Enable", true);
            }
            else
            {
                this.NewSetupView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00057> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00016, IList<PFMDTO00057>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00057>("PFMORM00057.Client.SelectAll",new object[] {true}); //nms
        }

        public PFMDTO00057 SelectByVariable(string variable)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00016, PFMDTO00057>(service => service.SelectByVariable(variable));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00057>("PFMORM00057.Client.SelectByVariable",new object[] {variable,true}); //nms
        }
		
		#endregion
		
	}
}
