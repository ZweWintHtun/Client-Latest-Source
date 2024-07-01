//----------------------------------------------------------------------
// <copyright file="LOMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00009 : AbstractPresenter, ILOMCTL00009
    {
        #region Properties

        public LOMCTL00009() { }
        private ILOMVEW00009 view;
        public ILOMVEW00009 GJTCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00009 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetGJTDto());
            }
        }

        private LOMDTO00007 GetGJTDto()
        {
            return new LOMDTO00007
            {
                Code = this.view.Code,
                Description = this.view.Description
            };
        }
        #endregion

        #region Implementation

        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}

        public void Save(LOMDTO00007 entity)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.Code == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Code != string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                if (this.GJTCodeView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    IList<LOMDTO00007> GJTCodeInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00009, IList<LOMDTO00007>>(x => x.CheckExist2(entity.Code, entity.Description));
                    if (GJTCodeInfo.Count > 0)
                    {
                        LOMDTO00007 gJTCodeActive = GJTCodeInfo.Where<LOMDTO00007>(x => x.Active == false).FirstOrDefault();
                        if (gJTCodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (gJTCodeActive.Code == entity.Code)
                            {
                                entity.TS = gJTCodeActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(gJTCodeActive, entity);
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
                    //CXClientWrapper.Instance.Invoke<ILOMSVE00009>(x => x.SaveServerAndServerClient(entity));
                    CXClientWrapper.Instance.Invoke<ILOMSVE00009>(x => x.SaveServerAndServerClient(entity,dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        //this.GJTCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("GJT.Enable", true);
                        this.SetFocus("txtCode");
                    }
                    else
                    {
                        this.GJTCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else  //Update
                {
                    //try
                    //{
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.GJTCodeView.PreviousGJTDto, entity);
                        CXClientWrapper.Instance.Invoke<ILOMSVE00009>(x => x.Update(entity, dvcvList,"Update"));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.GJTCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.view.ControlSetting("GJT.Enable", true);
                            this.SetFocus("txtCode");
                        }
                        else
                        {
                            this.GJTCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            this.SetFocus("txtDescription");
                        }
                    //}
                    //catch (Exception)
                    //{ }
                }
            
        }
        public void SaveClient(LOMDTO00007 entity)
        {
            try
        {
            Dictionary<string, object> keyPair = new Dictionary<string, object>
            {
                {"Gjtype", entity.Code},
                {"Desp", entity.Description}
            };
            ClientSQLiteDataHandler.Instance.InsertClient("GJTCode", keyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
            this.GJTCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.GJTCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00007> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00009>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.GJTCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.GJTCodeView.ControlSetting("GJT.Enable", true);
            }
            else
            {
                this.GJTCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public LOMDTO00007 SelectByGjtype(string gjtype)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00009, LOMDTO00007>(service => service.SelectByGJTCode(gjtype));
        }

        public IList<LOMDTO00007> SelectAll()
        {
            IList<LOMDTO00007> list = new List<LOMDTO00007>();
            try
            { list = CXClientWrapper.Instance.Invoke<ILOMSVE00009, LOMDTO00007>(x => x.SelectAll()); }
            catch (Exception) { }
            return list;
        }

        #endregion               
    }
}