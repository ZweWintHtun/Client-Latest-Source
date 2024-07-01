//----------------------------------------------------------------------
// <copyright file="SAMCTL00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00010 : AbstractPresenter, ISAMCTL00010
    {
        #region Properties

        public SAMCTL00010() { }
        private ISAMVEW00010 view;
        public ISAMVEW00010 AppSettingsView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00010 view)
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

        public void Save(PFMDTO00053 entity)
        {
            if (this.ValidateForm(entity))
            {
                if (entity.BinaryValue != null && entity.BinaryValue.Length > 30000)
                {
                            CXUIMessageUtilities.ShowMessageByCode("MV20071");  //Image size is too large. 
                            return;
                }
                    if (this.AppSettingsView.Status.Equals("Save"))
                    {
                            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                            CXClientWrapper.Instance.Invoke<ISAMSVE00010>(x => x.SaveServerAndServerClient(entity));
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                            {
                                this.AppSettingsView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                            }
                            else
                            {
                                this.AppSettingsView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            }
                    }
                    else
                    {
                            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.view.PreviousAppSettingDto, entity);
                            CXClientWrapper.Instance.Invoke<ISAMSVE00010>(x => x.Update(entity, dvcvList));
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                            {
                                this.AppSettingsView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                            }
                            else
                            {
                                this.AppSettingsView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            }
                    }
                    
                  
                }
            else
            {
                if (string.IsNullOrEmpty(entity.KeyName.ToString()))
                {
                    this.SetFocus("txtKeyName");
                }
                else if (string.IsNullOrEmpty(entity.KeyValue.ToString()))
                {
                    this.SetFocus("txtKeyValue");
                }
                else if (string.IsNullOrEmpty(entity.Description.ToString()))
                {
                    this.SetFocus("txtDescription");
                }
                else if (string.IsNullOrEmpty(entity.Location.ToString()))
                {
                    this.SetFocus("txtLocation");
                }
                else if (string.IsNullOrEmpty(entity.Type.ToString()))
                {
                    this.SetFocus("txtType");
                }
            }
            
        }

        public void Delete(IList<PFMDTO00053> itemList)
        {
            
                for (int i = 0; i < itemList.Count; i++)
                {
                    itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                }
                CXClientWrapper.Instance.Invoke<ISAMSVE00010>(x => x.Delete(itemList));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.AppSettingsView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                }
                else
                {
                    this.AppSettingsView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
           
        }

        public IList<PFMDTO00053> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00010, IList<PFMDTO00053>>(service => service.GetAll());
           // return CXCLE00002.Instance.GetListObject<PFMDTO00053>("PFMORM00053.Client.SelectAll",new object[] {true}); //nms
        }

        public PFMDTO00053 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00010, PFMDTO00053>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00053>("PFMORM00053.Client.SelectById",new object[] {id,true}); //nms
        }

        #endregion

    }
}