//----------------------------------------------------------------------
// <copyright file="SAMCTL00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NL</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
    /// <summary>
    /// Initial Setup Controller
    /// </summary>
    public class SAMCTL00021 : AbstractPresenter, ISAMCTL00021
    {
        #region Properties

        public SAMCTL00021() { }
        private ISAMVEW00021 view;
        public ISAMVEW00021 InitialView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00021 view)
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

        public void Save(PFMDTO00003 entity)
        {
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
               
             if (!this.ValidateForm(entity))
            {
                if (entity.Initial == string.Empty)
                    this.SetFocus("txtOccupationCode");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
              
                    if (this.InitialView.Status.Equals("Save"))
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
						entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                        IList<PFMDTO00003> InitialInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00021, IList<PFMDTO00003>>(x => x.CheckExist2(entity.Initial, entity.Description));
                        if (InitialInfo.Count > 0)
                        {
                            PFMDTO00003 initialActive = InitialInfo.Where<PFMDTO00003>(x => x.Active == false).FirstOrDefault();
                            if (initialActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                            {
                                if (initialActive.Initial == entity.Initial)
                                {
                                    entity.TS = initialActive.TS;
                                    //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                    dvcvList = GetChangedValueOfObject.GetChangedValueList(initialActive, entity);
                                    entity.Active = false;  //to check status in service
                                }
                            }
                            else  
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MV90001");//data already exists      
                                return;
                            }
                        }
                        else entity.Active = true;  //active = 1 , new data , so data will be save with insert nature 
                        //CXClientWrapper.Instance.Invoke<ISAMSVE00021>(x => x.SaveServerAndServerClient(entity));
                        
						CXClientWrapper.Instance.Invoke<ISAMSVE00021>(x => x.SaveServerAndServerClient(entity, dvcvList));
                        this.SaveClient(entity);
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.InitialView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.InitialView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else //Update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                       dvcvList = GetChangedValueOfObject.GetChangedValueList(this.InitialView.PreviousInitialDto, entity);
                       CXClientWrapper.Instance.Invoke<ISAMSVE00021>(x => x.Update(entity, dvcvList,"Update"));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            this.InitialView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.InitialView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
               // }
            
        }
        public void SaveClient(PFMDTO00003 entity)
        {
            try
            {
                Dictionary<string, object> initalKeyPair = new Dictionary<string, object> {
	            { "Initial", entity.Initial }, 
	            { "Description", entity.Description }                    
	            };
                ClientSQLiteDataHandler.Instance.InsertClient("Initial", initalKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.InitialView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.InitialView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<PFMDTO00003> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00021>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.InitialView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.InitialView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00003> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00021, IList<PFMDTO00003>>(service => service.GetAll());
           // return CXCLE00002.Instance.GetListObject<PFMDTO00003>("PFMORM00003.Client.SelectAll",new object[]{true}); //nms
        }

        public PFMDTO00003 SelectByInitial(string initial)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00021, PFMDTO00003>(service => service.SelectByInitial(initial));
          //  return CXCLE00002.Instance.GetScalarObject<PFMDTO00003>("PFMORM00003.Client.SelectByInitial",new object[] {initial,true}); //nms
        }

        #endregion

    }
}