//----------------------------------------------------------------------
// <copyright file="SAMCTL00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
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
    public class SAMCTL00017 : AbstractPresenter, ISAMCTL00017
    {
        #region Properties

        public SAMCTL00017() { }
        private ISAMVEW00017 view;
        public ISAMVEW00017 ZoneView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00017 view)
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

        public void Save(TLMDTO00031 entity)
        {
            if (this.ValidateForm(entity))
            {
                if (this.ZoneView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00017>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.ZoneView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.ZoneView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.ZoneView.PreviousZoneDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00017>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.ZoneView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

                    }
                    else
                    {
                        this.ZoneView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            else
            { 
                if(string.IsNullOrEmpty(entity.ZoneType.ToString()))
                {
                    this.SetFocus("cboZoneType");
                }
                else if (string.IsNullOrEmpty(entity.BranchCode.ToString()))
                {
                    this.SetFocus("cboBranchCode");
                }
                else if(string.IsNullOrEmpty(entity.AccountCode.ToString()))
                {
                    this.SetFocus("txtAccountCode");
                }
            }
        }

        public void Delete(IList<TLMDTO00031> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00017>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.ZoneView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);

            }
            else
            {
                this.ZoneView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
      
        public IList<TLMDTO00031> GetAll()
        {

            return CXClientWrapper.Instance.Invoke<ISAMSVE00017, IList<TLMDTO00031>>(service => service.GetAll(CurrentUserEntity.BranchCode));
            //return CXCLE00002.Instance.GetListObject<TLMDTO00031>("TLMORM00031.Client.SelectAll", new object[] { CurrentUserEntity.BranchCode, true }); //nms

        }

        public TLMDTO00031 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00017, TLMDTO00031>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<TLMDTO00031>("TLMORM00031.Client.SelectById",new object[] {id,true}); //nms
        }

        public IList<TLMDTO00031> GetAllByDistinct()   //(not use method)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00017, IList<TLMDTO00031>>(service => service.GetAllByDistinct());//
           // return CXCLE00002.Instance.GetListObject<TLMDTO00031>("TLMORM00031.Client.SelectAllByDistinct"); //nms
        }

        public IList<BranchDTO> GetBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00026, IList<BranchDTO>>(service => service.SelectAllBranch());
            //return CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectAllBranchCodes",new object[] {true}); //nms
        }

        #endregion

        public void cboZoneType_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
        }
        public void cboBranchCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
        }
        public void txtAccountCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
        }

    }
}