//----------------------------------------------------------------------
// <copyright file="SAMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    public class SAMCTL00023 : AbstractPresenter, ISAMCTL00023
    {
        #region Properties

        public SAMCTL00023() { }
        private ISAMVEW00023 view;
        public ISAMVEW00023 RateFileView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00023 view)
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

        public void Save(PFMDTO00009 entity)
        {
              if (!this.ValidateForm(entity))
            {
                if (entity.Code == string.Empty && entity.Description == string.Empty)
                    this.SetFocus("txtCurrency");
                else if (entity.Code!= string.Empty && entity.Description!= string.Empty)
                    this.SetFocus("txtRate");
                else if (entity.Code == string.Empty && entity.Description!= string.Empty)
                    this.SetFocus("txtDescription");
                else if (entity.Code!= string.Empty && entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
        
            if (this.RateFileView.Status.Equals("Save"))
                {
                    PFMDTO00009 previousEntity = this.SelectByRateCode(entity.Code);
                    PFMDTO00009 newEntity = new PFMDTO00009();
                     IList<DataVersionChangedValueDTO> dvcvList= new List<DataVersionChangedValueDTO>();
                    if (previousEntity !=null)
                    {
                        newEntity = this.SelectByRateCode(entity.Code);
                        newEntity.LASTMODIFY = false;                      
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(previousEntity, newEntity);
                    }
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.USERNO = CurrentUserEntity.CurrentUserID.ToString();
                    CXClientWrapper.Instance.Invoke<ISAMSVE00023>(x => x.SaveServerAndServerClient(entity, dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.RateFileView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("RateFile.Enable", true);
                    }
                    else
                    {
                        this.RateFileView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.USERNO = CurrentUserEntity.CurrentUserID.ToString();
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.RateFileView.PreviousRateDto,entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00023>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.RateFileView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("RateFile.Enable", true);
                    }
                    else
                    {
                        this.RateFileView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }

        public void SaveClient(PFMDTO00009 entity)  //1
        {
            try
            {
                int lastModify = 0;
                if (entity.LASTMODIFY)
                { lastModify = 1; }
                Dictionary<string, object> occupationKeyPair = new Dictionary<string, object> { { "Code", entity.Code }, { "Desp", entity.Description }, { "DATE_TIME", entity.DATE_TIME }, { "LASTMODIFY", lastModify }, { "USERNO", entity.USERNO }, { "Rate", entity.Rate }, { "Duration", entity.Duration } };
                ClientSQLiteDataHandler.Instance.InsertClient("RateFile", occupationKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.RateFileView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.RateFileView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public void Delete(IList<PFMDTO00009> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].USERNO = CurrentUserEntity.CurrentUserID.ToString();
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00023>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.RateFileView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.ControlSetting("RateFile.Enable", true);
            }
            else
            {
                this.RateFileView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00009> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00023, IList<PFMDTO00009>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00009>("PFMORM00009.Client.SelectAll", new object[] { true, true }); //nms
        }

        public PFMDTO00009 SelectByCode(string code)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00023, PFMDTO00009>(service => service.SelectByCode(code));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCode", new object[] { code,true }); //nms
        }

 public PFMDTO00009 SelectByRateCode(string code)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ISAMSVE00023, PFMDTO00009>(service => service.SelectByRateCode(code));
                //return CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByRateCode", new object[] { code, true, true }); //nms
            }
            catch (Exception ex)
            {
                return new PFMDTO00009();
            }
        }
        #endregion

    }
}