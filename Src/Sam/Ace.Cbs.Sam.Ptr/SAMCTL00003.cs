//----------------------------------------------------------------------
// <copyright file="SAMCTL00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
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
using System.Linq;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00003 : AbstractPresenter, ISAMCTL00003
    {
        #region Properties

        public SAMCTL00003() { }
        private ISAMVEW00003 view;
        public ISAMVEW00003 OccupationCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00003 view)
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

        public void Save(PFMDTO00004 entity)
        {
           // try
           // {
             if (!this.ValidateForm(entity))
            {
                if (entity.Occupation_Code == string.Empty)
                    this.SetFocus("txtOccupationCode");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
                    IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                    if (this.OccupationCodeView.Status.Equals("Save"))
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        IList<PFMDTO00004> OccupationInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00003, IList<PFMDTO00004>>(x => x.CheckExist2(entity.Occupation_Code, entity.Description));
                        if (OccupationInfo.Count > 0)
                        {
                            PFMDTO00004 OccupationActive = OccupationInfo.Where<PFMDTO00004>(x => x.Active == false).FirstOrDefault();
                            if (OccupationActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                            {
                                if (OccupationActive.Occupation_Code == entity.Occupation_Code)
                                {
                                    entity.TS = OccupationActive.TS;
                                    //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                    dvcvList = GetChangedValueOfObject.GetChangedValueList(OccupationActive, entity);
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
                        CXClientWrapper.Instance.Invoke<ISAMSVE00003>(x => x.SaveServerAndServerClient(entity, dvcvList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.OccupationCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.OccupationCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else  //Update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.OccupationCodeView.PreviousOccupationDto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00003>(x => x.Update(entity, dvcvList, "Update"));

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            this.OccupationCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.OccupationCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
              // }
          //  }
           // catch (Exception ex)
           // { }
        }

        public void Delete(IList<PFMDTO00004> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00003>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.OccupationCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.OccupationCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00004> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00003, IList<PFMDTO00004>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<PFMDTO00004>("PFMORM00004.Client.SelectAll",new object[] {true}); //nms
        }

        public PFMDTO00004 SelectByOccupationCode(string occupationCode)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00003, PFMDTO00004>(service => service.SelectByOccupationCode(occupationCode));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00004>("PFMORM00004.Client.SelectByOccupationCode", new object[] { occupationCode,true }); //nms
        }

        #endregion

    }
}