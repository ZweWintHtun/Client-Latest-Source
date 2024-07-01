//----------------------------------------------------------------------
// <copyright file="SAMCTL00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00004 : AbstractPresenter, ISAMCTL00004
    {
        #region Properties

        public SAMCTL00004() { }
        private ISAMVEW00004 view;
        public ISAMVEW00004 BCodeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00004 view)
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

        public void Save(TLMDTO00040 entity)
        {
            IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
           
            if (!this.ValidateForm(entity))
            {
                if (entity.BCode == string.Empty)
                    this.SetFocus("txtBankCode");
                else if (entity.BDesp == string.Empty)
                    this.SetFocus("txtBankName");
                else if (entity.BAccountNo == string.Empty)
                    this.SetFocus("txtAccountNo");
                return;
            }
                    if (this.BCodeView.Status.Equals("Save"))
                    {
                        entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
 						entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;

                        IList<TLMDTO00040> BcodeInfo = CXClientWrapper.Instance.Invoke<ISAMSVE00004, IList<TLMDTO00040>>(x => x.CheckExist2(entity.BCode, entity.BDesp));
                        if (BcodeInfo.Count > 0)
                        {
                            TLMDTO00040 bcodeActive = BcodeInfo.Where<TLMDTO00040>(x => x.Active == false).FirstOrDefault();                                                        
                            if (bcodeActive != null)   //Data exist with active 0 , deleted , so data will be save with update nature
                            {
                                if (bcodeActive.BCode == entity.BCode)
                                {
                                    entity.TS = bcodeActive.TS;
                                    //cityActive.Active = true;  //to save with active when changingValueOfObject   
                                    dvcvList = GetChangedValueOfObject.GetChangedValueList(bcodeActive, entity);
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
						// CXClientWrapper.Instance.Invoke<ISAMSVE00004>(x => x.SaveServerAndServerClient(entity));
                        CXClientWrapper.Instance.Invoke<ISAMSVE00004>(x => x.SaveServerAndServerClient(entity,dvcvList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            this.BCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.BCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }

                    else   //Update
                    {
                        entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
						dvcvList = GetChangedValueOfObject.GetChangedValueList(this.BCodeView.PreviousBCodeDto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00004>(x => x.Update(entity, dvcvList,"Update"));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        {
                            string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            this.BCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.BCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                    }
              //  }
           
        }

        public void Delete(IList<TLMDTO00040> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00004>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.BCodeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.BCodeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00040> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00004, IList<TLMDTO00040>>(service => service.GetAll());
            //return CXCLE00002.Instance.GetListObject<TLMDTO00040>("TLMORM00040.Client.SelectAll",new object[] {true}); //nms
        }

        public TLMDTO00040 SelectByBCode(string bCode)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00004, TLMDTO00040>(service => service.SelectByBCode(bCode));
           // return CXCLE00002.Instance.GetScalarObject<TLMDTO00040>("TLMORM00040.Client.SelectByBCode", new object[] { bCode,true}); //nms
        }

        #endregion

    }
}