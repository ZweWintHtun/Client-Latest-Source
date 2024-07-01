//----------------------------------------------------------------------
// <copyright file="SAMCTL00022.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00022 : AbstractPresenter, ISAMCTL00022
    {
        #region Properties

        public SAMCTL00022() { }
        private ISAMVEW00022 view;
        public ISAMVEW00022 PORateView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00022 view)
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

        public void Save(TLMDTO00003 entity)
        {
            try
            {
                if (this.ValidateForm(entity))
                {
                    if (this.PORateView.Status.Equals("Save"))
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        CXClientWrapper.Instance.Invoke<ISAMSVE00022>(x => x.SaveServerAndServerClient(entity));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.PORateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                        }
                        else
                        {
                            this.PORateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.PORateView.PreviousPORateDto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00022>(x => x.Update(entity, dvcvList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.PORateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                        }
                        else
                        {
                            this.PORateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
                }
            }
            catch
            { }
        }

        public void Delete(IList<TLMDTO00003> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00022>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.PORateView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.PORateView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00003> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, IList<TLMDTO00003>>(service => service.GetAll());
           // return CXCLE00002.Instance.GetListObject<TLMDTO00003>("TLMORM00003.Client.SelectAll",new object[]{true}); //nms
        }

        public TLMDTO00003 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, TLMDTO00003>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<TLMDTO00003>("TLMORM00003.Client.SelectById",new object[] {id,true}); //nms
        }

        public IList<CurrencyDTO> GetCurrency()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, IList<CurrencyDTO>>(service => service.GetCurrency()); //nms
            //return CXCLE00002.Instance.GetListObject<CurrencyDTO>("Currency.Client.SelectCur",new object[] {true});
        }

        #endregion

    }
}