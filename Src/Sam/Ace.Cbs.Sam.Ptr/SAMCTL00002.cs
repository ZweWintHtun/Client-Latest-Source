//----------------------------------------------------------------------
// <copyright file="SAMCTL00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00002 : AbstractPresenter,ISAMCTL00002
    {
        #region Properties

        public SAMCTL00002() { }
        private ISAMVEW00002 view;
        public ISAMVEW00002 SubAccountTypeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00002 view)
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

        public void Save(PFMDTO00022 entity)
        {   
            if (!this.ValidateForm(entity))
            {
                if (entity.AccountTypeId == null)
                    this.SetFocus("cboAccountType");
                else if (entity.Code == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                else if (entity.AccountSignature == string.Empty)
                    this.SetFocus("txtAccountSign");
                else if (entity.Symbol == string.Empty)
                    this.SetFocus("txtSymbol");

                return;
            }
            
            
            if (this.SubAccountTypeView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00002>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.SubAccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.SubAccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.SubAccountTypeView.PreviousSubAccountType, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00002>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.SubAccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.SubAccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
          //  }
        }

        public void Delete(IList<PFMDTO00022> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00002>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.SubAccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.SubAccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00022> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00002, IList<PFMDTO00022>>(service => service.GetAll());
            //return CXCLE00001.Instance.SelectAllSubAccountType(); //nms        
        }

        public PFMDTO00022 SelectById(int id)
        {
            //return CXClientWrapper.Instance.Invoke<ISAMSVE00002, PFMDTO00022>(service => service.SelectById(id));
            return CXCLE00001.Instance.SelectByIdSubAccountType(id); //nms  
        }

        public IList<PFMDTO00015> SelectAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00001, IList<PFMDTO00015>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00015>("PFMORM00015.Client.SelectAll",new object[]{true}); //nms
        }

        #endregion

    }
}