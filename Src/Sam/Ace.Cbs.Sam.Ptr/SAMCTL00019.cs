//----------------------------------------------------------------------
// <copyright file="SAMCTL00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;


namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00019 : AbstractPresenter, ISAMCTL00019
    {
        #region Properties

        public SAMCTL00019() { }
        private ISAMVEW00019 view;
        public ISAMVEW00019 DayKeyView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00019 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        #endregion

        #region Variables

        TLMDTO00034 _previousTestKeyDto;
        public TLMDTO00034 PreviousTestKeyDto
        {
            get
            {
                if (_previousTestKeyDto == null)
                    return new TLMDTO00034();
                return _previousTestKeyDto;
            }
            set { _previousTestKeyDto = value; }
        }

        #endregion

        #region Methods

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
        

        public void Save(TLMDTO00034 entity, string keyType)
        {
            if (this.ValidateForm(entity))
            {
                if (this.DayKeyView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00019>(x => x.SaveServerAndServerClient(entity, keyType));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.DayKeyView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.DayKeyView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.PreviousTestKeyDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00019>(x => x.Update(entity, keyType, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.DayKeyView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.DayKeyView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
            }
            else 
            {
                if (string.IsNullOrEmpty(entity.Code.ToString()))
                {
                    this.SetFocus("txtCode");
                }
                else if (string.IsNullOrEmpty(entity.Value.ToString()) || entity.Value.Value.ToString() == decimal.Zero.ToString())
                {
                    this.SetFocus("txtValue");
                }
            }
        }

        public void Delete(IList<TLMDTO00034> itemList, string keyType)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            }
            CXClientWrapper.Instance.Invoke<ISAMSVE00019>(x => x.Delete(itemList,keyType));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.DayKeyView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.DayKeyView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00034> GetAll(string keyType)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00019, IList<TLMDTO00034>>(service => service.GetAll(keyType));
           
            // Client Data Changed by nms
            //IList<TLMDTO00034> keyDTOList = new List<TLMDTO00034>();

            //if (keyType == "Day Key")
            //{
            //    keyDTOList =  CXCLE00002.Instance.GetListObject<TLMDTO00034>("TLMORM00034.Client.SelectAll",new object[] {true});                
            //}

            //if (keyType == "Month Key")
            //{
            //    keyDTOList = CXCLE00002.Instance.GetListObject<TLMDTO00034>("TLMORM00035.Client.SelectAll",new object[] {true});
            //}

            //if (keyType == "Amount Key")
            //{
            //    keyDTOList = CXCLE00002.Instance.GetListObject<TLMDTO00034>("TLMORM00036.Client.SelectAll",new object[] {true});
            //}

            //if (keyType == "Branch Key")
            //{
            //    keyDTOList = CXCLE00002.Instance.GetListObject<TLMDTO00034>("TLMORM00037.Client.SelectAll",new object[]{true});
            //}
            //return keyDTOList;
        }

        public TLMDTO00034 SelectById(int id) // Not Use Method
        {
          return CXClientWrapper.Instance.Invoke<ISAMSVE00019, TLMDTO00034>(service => service.SelectById(id));
        }

        #endregion

        public void txtCode_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
        }
        public void txtValue_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
        }
    }
}