//----------------------------------------------------------------------
// <copyright file="SAMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00001 : AbstractPresenter,ISAMCTL00001
    {
		#region Properties		
		public SAMCTL00001() { }
        private ISAMVEW00001 view;
        public ISAMVEW00001 AccountTypeView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }						
		#endregion

        #region Variables
        
        PFMDTO00015 _previousAccountTypeDto;
        public PFMDTO00015 PreviousAccountTypeDto
        {
            get
            {
                if (_previousAccountTypeDto == null)
                    return new PFMDTO00015();
                return _previousAccountTypeDto;
            }
            set { _previousAccountTypeDto = value; }
        }

        #endregion
		
		#region Methods
		
        //public override bool ValidateForm(object validationContext)
        //{
        //    return base.ValidateForm(validationContext);
        //}

        public void Save(PFMDTO00015 entity)
        {
             if (!this.ValidateForm(entity))
            {
                if (entity.Code == string.Empty)
                    this.SetFocus("txtCode");
                else if (entity.Description == string.Empty)
                    this.SetFocus("txtDescription");
                else if (entity.Symbol == string.Empty)
                    this.SetFocus("txtSymbol");
                return;
            }
                if (this.AccountTypeView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;

                    #region old //Updated By ZMS
                    //IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                    ////IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(new Object(), entity);
                    #endregion

                    //IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(new Object(), entity);

                    CXClientWrapper.Instance.Invoke<ISAMSVE00001>(x => x.SaveServerAndServerClient(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.AccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.AccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(this.PreviousAccountTypeDto, entity);
                    CXClientWrapper.Instance.Invoke<ISAMSVE00001>(x => x.Update(entity, dvcvList));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        string s = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        this.AccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.AccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }

        public void Delete(IList<PFMDTO00015> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00001>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.AccountTypeView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.AccountTypeView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00015> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00001, IList<PFMDTO00015>>(service => service.GetAll());
           // return CXCOM00011.Instance.GetListObject<PFMDTO00015>("PFMORM00015.Client.SelectAll",new object[] {true});//nms       
         }

        public PFMDTO00015 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00001, PFMDTO00015>(service => service.SelectById(id));
            //return CXCLE00002.Instance.GetScalarObject<PFMDTO00015>("PFMORM00015.Client.SelectById",new object[] {id,true}); //nms   
        }
		
		#endregion
		
	}
}