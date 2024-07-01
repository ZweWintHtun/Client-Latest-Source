//----------------------------------------------------------------------
// <copyright file="SAMCTL00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
    /// <summary>
    /// Holiday Setup
    /// </summary>
    public class SAMCTL00007 : AbstractPresenter, ISAMCTL00007
    {
        #region Properties

        public SAMCTL00007() { }
        private ISAMVEW00007 view;
        public ISAMVEW00007 HOLIDAYView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00007 view)
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

        public void Save(SAMDTO00003 entity)
        {     
            if (!this.ValidateForm(entity))
            {
                if (entity.DATE == null)
                    this.SetFocus("dtpDate");
                else if (entity.DATE != null)
                    this.SetFocus("txtDescription");
                return;
            }
                if (this.HOLIDAYView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.CreatedDate = DateTime.Now;

                    CXClientWrapper.Instance.Invoke<ISAMSVE00007>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.HOLIDAYView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.HOLIDAYView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.HOLIDAYView.PreviousHolidayDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00007>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.HOLIDAYView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.HOLIDAYView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }
        
        public void Delete(IList<SAMDTO00003> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00007>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.HOLIDAYView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.HOLIDAYView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<SAMDTO00003> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00007, IList<SAMDTO00003>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<SAMDTO00003>("SAMORM00003.Client.SelectAll",new object[] {true}); //nms
        }

        public SAMDTO00003 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00007, SAMDTO00003>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<SAMDTO00003>("SAMORM00003.Client.SelectById",new object[] {id,true}); //nms
        }

        #endregion

    }
}
