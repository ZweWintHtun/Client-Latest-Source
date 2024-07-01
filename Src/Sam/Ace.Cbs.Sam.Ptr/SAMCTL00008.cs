//----------------------------------------------------------------------
// <copyright file="SAMCTL00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Ctr.Ptr;
using Ace.Cbs.Sam.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using System.Linq;
namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00008 : AbstractPresenter, ISAMCTL00008
    {
		#region Properties
		
		public SAMCTL00008() { }

        private ISAMVEW00008 view;
        public ISAMVEW00008 DEPOSITCODEView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00008 view)
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

        #region Old Save Method
        //public void Save(TLMDTO00020 entity)
        //{
        //    if (this.ValidateForm(entity))
        //    {
        //        if (this.DEPOSITCODEView.Status.Equals("Save"))
        //        {
        //            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
        //            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
        //            CXClientWrapper.Instance.Invoke<ISAMSVE00008>(x => x.SaveServerAndServerClient(entity));
        //            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
        //            {
        //                this.DEPOSITCODEView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //                this.view.ControlSetting("DEPOSITCODE.Enable", true);
        //            }
        //            else
        //            {
        //                this.DEPOSITCODEView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //            }
        //        }

        //        else
        //        {
        //            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
        //            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
        //            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.DEPOSITCODEView.PreviousDepositCodeDto, entity);
        //            CXClientWrapper.Instance.Invoke<ISAMSVE00008>(x => x.Update(entity, dvcvList));
        //            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
        //            {
        //                string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
        //                this.DEPOSITCODEView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //                this.view.ControlSetting("DEPOSITCODE.Enable", true);
        //            }
        //            else
        //            {
        //                this.DEPOSITCODEView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //            }
        //        }
        //    }
        //}

        #endregion

        #region New Save Method
        public void Save(TLMDTO00020 entity)
        {
           // try
           // {
                if (!this.ValidateForm(entity))
            {
                if (entity.DepositCode == string.Empty)
                    this.SetFocus("txtDepositCode");
                else if (entity.DepositCode!= string.Empty)
                    this.SetFocus("txtDescription");
                return;
            }
              
                    IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                    if (this.DEPOSITCODEView.Status.Equals("Save"))
                    {
                        entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        IList<TLMDTO00020> DepositInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00008, IList<TLMDTO00020>>(x => x.CheckExist2(entity.DepositCode, entity.SourceBranchCode));
                        if (DepositInfo.Count > 0)
                        {
                            TLMDTO00020 DepositActive = DepositInfo.Where<TLMDTO00020>(x => x.Active == false).FirstOrDefault();
                            if (DepositActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                            {
                                if (DepositActive.DepositCode == entity.DepositCode)
                                {
                                    entity.TS = DepositActive.TS;
                                    //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                    dvcvList = GetChangedValueOfObject.GetChangedValueList(DepositActive, entity);
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
                        CXClientWrapper.Instance.Invoke<ISAMSVE00008>(x => x.SaveServerAndServerClient(entity, dvcvList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.DEPOSITCODEView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.DEPOSITCODEView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else  //Update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.DEPOSITCODEView.PreviousDepositCodeDto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00008>(x => x.Update(entity, dvcvList, "Update"));

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            this.DEPOSITCODEView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.DEPOSITCODEView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
              //  }
           // }
            //catch (Exception ex)
            //{ }
        }
        #endregion

        public void Delete(IList<TLMDTO00020> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00008>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.DEPOSITCODEView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.ControlSetting("DEPOSITCODE.Enable", true);
            }
            else
            {
                this.DEPOSITCODEView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00020> GetAll(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00008, IList<TLMDTO00020>>(service => service.GetAll(sourceBr));
            //return CXCLE00002.Instance.GetListObject<TLMDTO00020>("TLMORM00020.Client.SelectAll",new object[] {true, CurrentUserEntity.BranchCode}); //nms
        }

        public TLMDTO00020 SelectByDEPCODE(string dEPCODE)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00008, TLMDTO00020>(service => service.SelectById(dEPCODE));
           // return CXCLE00002.Instance.GetScalarObject<TLMDTO00020>("TLMORM00020.Client.SelectByDepositcode",new object[] {dEPCODE,true}); //nms
        }
		
		#endregion
		
	}
}
