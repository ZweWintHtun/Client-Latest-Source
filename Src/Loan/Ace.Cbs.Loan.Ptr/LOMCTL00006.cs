//----------------------------------------------------------------------
// <copyright file="LOMCTL00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KKM</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
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
    public class LOMCTL00006 : AbstractPresenter, ILOMCTL00006
    {
        #region Properties

        public LOMCTL00006() { }
        private ILOMVEW00006 view;
        public ILOMVEW00006 INSURANView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ILOMVEW00006 view)
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

        public void Save(LOMDTO00004 entity)
        {
             if (!this.ValidateForm(entity))
                {
                    if (entity.INSUCODE == string.Empty)
                        this.SetFocus("txtCode");
                    else if (entity.INSUCODE != string.Empty)
                        this.SetFocus("txtDescription");

                    return;
                }
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();                    
                if (this.INSURANView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                    IList<LOMDTO00004> InsuranceInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00006, IList<LOMDTO00004>>(x => x.CheckExist2(entity.INSUCODE, entity.INSUDESP));
                    if (InsuranceInfo.Count > 0)
                    {
                        LOMDTO00004 InsuranceActive = InsuranceInfo.Where<LOMDTO00004>(x => x.Active == false).FirstOrDefault();
                        if (InsuranceActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                        {
                            if (InsuranceActive.INSUCODE == entity.INSUCODE)
                            {
                                entity.TS = InsuranceActive.TS;
                                //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                dvcvList = GetChangedValueOfObject.GetChangedValueList(InsuranceActive, entity);
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
                    //CXClientWrapper.Instance.Invoke<ILOMSVE00006>(x => x.SaveServerAndServerClient(entity));
                    CXClientWrapper.Instance.Invoke<ILOMSVE00006>(x => x.SaveServerAndServerClient(entity,dvcvList));
                    this.SaveClient(entity);
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.INSURANView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("INSURAN.Enable", true);
                        this.view.INSUCODE = string.Empty;
                        this.view.INSUDESP = string.Empty;
                        this.SetFocus("txtCode");
                    }
                    else
                    {
                        this.INSURANView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);                        
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.INSURANView.PreviousInsuranceDto, entity);
                    CXClientWrapper.Instance.Invoke<ILOMSVE00006>(x => x.Update(entity, dvcvList,"Update"));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.INSURANView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.view.ControlSetting("INSURAN.Enable", true);
                        this.SetFocus("txtCode");
                    }
                    else
                    {
                        this.INSURANView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtDescription");
                    }
                }
            
        }
        public void SaveClient(LOMDTO00004 entity)
        {
            try
            {
                Dictionary<string, object> insuranKeyPair = new Dictionary<string, object> { 
                { "INSUCODE", entity.INSUCODE },
                { "INSUDESP", entity.INSUDESP } };
                ClientSQLiteDataHandler.Instance.InsertClient("INSURAN", insuranKeyPair, entity.TS, entity.CreatedUserId, entity.CreatedDate);
                this.INSURANView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            catch (Exception)
            {
                this.INSURANView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Delete(IList<LOMDTO00004> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ILOMSVE00006>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.INSURANView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.ControlSetting("INSURAN.Enable", true);
            }
            else
            {
                this.INSURANView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<LOMDTO00004> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00006, IList<LOMDTO00004>>(service => service.GetAll());
        }

        public LOMDTO00004 SelectByINSUCODE(string iNSUCODE)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00006, LOMDTO00004>(service => service.SelectByINSUCODE(iNSUCODE));
        }

        #endregion

    }
}