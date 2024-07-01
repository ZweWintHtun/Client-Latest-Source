//----------------------------------------------------------------------
// <copyright file="SAMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
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
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Service;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00020 : AbstractPresenter,ISAMCTL00020
    {
		#region Properties
		
		public SAMCTL00020() { }
        private ISAMVEW00020 view;
        public ISAMVEW00020 SERVERLOGView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00020 view)
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

        public void Save(TLMDTO00027 entity)
        {
           
            if (!this.ValidateForm(entity))
            {
                if (entity.BRANCHNO == string.Empty)
                    this.SetFocus("cboBranchCode");
                else if (entity.SERVERNAME == string.Empty)
                    this.SetFocus("txtServerName");
                else if (entity.IPADDRESS == string.Empty)
                    this.SetFocus("txtIPAddress");
                else if (entity.DBNAME ==  string.Empty)
                    this.SetFocus("txtDBName");
                return;
            }
                if (this.SERVERLOGView.Status.Equals("Save"))
                {
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00020>(x => x.Save(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.SERVERLOGView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
						
                    }
                    else
                    {
                        this.SERVERLOGView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    CXClientWrapper.Instance.Invoke<ISAMSVE00020>(x => x.Update(entity));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.SERVERLOGView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
						
                    }
                    else
                    {
                        this.SERVERLOGView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }

        public void Delete(IList<TLMDTO00027> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00020>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.SERVERLOGView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
				
            }
            else
            {
                this.SERVERLOGView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<TLMDTO00027> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00020, IList<TLMDTO00027>>(service => service.GetAll());
        }

        public IList<BranchDTO> GetAllBranchCode()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00026, IList<BranchDTO>>(service => service.SelectAllBranch());
        }

        public TLMDTO00027 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00020, TLMDTO00027>(service => service.SelectById(id));
        }
		
		#endregion
		
	}
}
