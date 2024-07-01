//----------------------------------------------------------------------
// <copyright file="SAMCTL00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00024 : AbstractPresenter, ISAMCTL00024
    {
        #region Properties

        public SAMCTL00024() { }
        private ISAMVEW00024 view;
        public ISAMVEW00024 DenoView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00024 view)
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

        public void Save(TLMDTO00012 entity)
        {
          if (!this.ValidateForm(entity))
            {
                if (entity.Currency == string.Empty)
                    this.SetFocus("cboCurrency");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                else if (entity.Symbol == string.Empty)
                    this.SetFocus("txtSymbol");

                return;
            }
                if (this.DenoView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00024>(x => x.SaveServerAndServerClient(entity));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.DenoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.DenoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.view.PreviousDenoInfoDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00024>(x => x.Update(entity, dvcvList));                    
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.DenoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.DenoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }
        public void SaveClient(TLMDTO00012 entity)
        {
            try
            {
                Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> {
                { "Id", entity.Id },
                { "Desp", entity.Description },
                { "D1", entity.D1 }, 
                { "D2", entity.D2 },
                { "Cur", entity.Currency },
                { "Symbol", entity.Symbol } };
                ClientSQLiteDataHandler.Instance.InsertClient("Deno", accounttypeKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.DenoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.DenoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<TLMDTO00012> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00024>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.DenoView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.DenoView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00012> GetAll()
        {
           return CXClientWrapper.Instance.Invoke<ISAMSVE00024, IList<TLMDTO00012>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<TLMDTO00012>("TLMORM00012.Client.SelectAll",new object[]{true}); //nms
        }

        public TLMDTO00012 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00024, TLMDTO00012>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<TLMDTO00012>("TLMORM00012.Client.SelectById",new object[] {id,true}); //nms
        }

        public IList<CurrencyDTO> GetCur()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00022, IList<CurrencyDTO>>(service => service.GetCurrency());
           // return CXCLE00002.Instance.GetListObject<CurrencyDTO>("Currency.Client.SelectCur",new object[] {true}); //nms
        }

        public void txtD1_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.D1 == "0" || this.view.D1 == "0.00")
            {
                this.view.D1= "0";
            }
           
        }

        public void txtD2_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.D2 == "0" || this.view.D2 == "0.00")
            {
                this.view.D2 = "0";
            }
        }

        #endregion

    }
}