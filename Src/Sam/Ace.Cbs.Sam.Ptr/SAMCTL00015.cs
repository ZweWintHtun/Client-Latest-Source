//----------------------------------------------------------------------
// <copyright file="SAMCTL00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    public class SAMCTL00015 : AbstractPresenter, ISAMCTL00015
    {
        #region Properties

        public SAMCTL00015() { }
        private ISAMVEW00015 view;
        public ISAMVEW00015 FixRateView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00015 view)
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

        public void Save(PFMDTO00007 entity)
        {
             if (!this.ValidateForm(entity))
             {
                 if (entity.Duration == null && entity.Description == string.Empty)
                     this.SetFocus("txtDuration");
                 else if (entity.Duration != null && entity.Description != string.Empty)
                     this.SetFocus("txtRate");
                 else if (entity.Duration == null && entity.Description != string.Empty)
                     this.SetFocus("txtDescription");
                 else if (entity.Duration != null && entity.Description == string.Empty)
                     this.SetFocus("txtDescription");
                 return;
             }
              
                if (this.FixRateView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00015>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.FixRateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.FixRateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.FixRateView.PreviousFixedRateDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00015>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.FixRateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.FixRateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
          //  }
        }

        public void Delete(IList<PFMDTO00007> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00015>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.FixRateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.FixRateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00007> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00015, IList<PFMDTO00007>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00007>("PFMORM00007.Client.SelectAll",new object[] {true}); //nms
        }

        public PFMDTO00007 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00015, PFMDTO00007>(service => service.SelectById(id));
           // return CXCLE00002.Instance.GetScalarObject<PFMDTO00007>("PFMORM00007.Client.SelectById",new object[] {id,true}); //nms
        }

        #endregion

    }
}