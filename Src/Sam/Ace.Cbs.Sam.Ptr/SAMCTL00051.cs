//----------------------------------------------------------------------
// <copyright file="SAMCTL00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
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
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.Contracts.Service;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Sam.Sve;

namespace Ace.Cbs.Sam.Ptr
{
    /// <summary>
    /// RateInfo Controller
    /// </summary>
    public class SAMCTL00051 : AbstractPresenter, ISAMCTL00051
    {
        #region Properties

        public SAMCTL00051() { }
        private ISAMVEW00051 view;
        public ISAMVEW00051 RateInfoView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00051 view)
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

        public void Save(PFMDTO00075 entity)
        {
            if (this.ValidateForm(entity))
            {
                if (this.RateInfoView.Status.Equals("Save"))
                {
                    entity.Status = "Save";
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00051>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.RateInfoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.RateInfoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.Status = "Update";
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.RateInfoView.PreviousRateInfoDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00051>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.RateInfoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.RateInfoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
        }

        public void Delete(IList<PFMDTO00075> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].Status = "Delete";
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00051>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.RateInfoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.RateInfoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00075> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00051, IList<PFMDTO00075>>(service => service.GetAll());
           // return CXCLE00002.Instance.GetListObject<PFMDTO00075>("PFMORM00074.Client.SelectAll", new object[] { true, true }); //nms
        }

        public PFMDTO00075 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00051, PFMDTO00075>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00075>("PFMORM00074.Client.SelectById",new object[] {id,true}); //nms
        }

        public IList<CurrencyDTO> GetCurrency()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00051, IList<CurrencyDTO>>(service => service.GetCurrency());
           // return CXCLE00002.Instance.GetListObject<CurrencyDTO>("Currency.Client.SelectCur",new object[]{true}); //nms
        }


        #endregion

    }
}