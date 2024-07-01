//----------------------------------------------------------------------
// <copyright file="SAMCTL00049.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ptr
{
	public class SAMCTL00049 : AbstractPresenter,ISAMCTL00049
    {
		#region Properties
		
		public SAMCTL00049() { }
        private ISAMVEW00049 view;
        public ISAMVEW00049 Sys001View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00049 view)
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

        public void Save(PFMDTO00056 entity, IList<BranchDTO> BranchList)
        {
            if (!this.ValidateForm(entity))
            {
                if (entity.Name == string.Empty)
                    this.SetFocus("txtName");
                else if (entity.BranchCode == null)

                    this.SetFocus("cboBranchNo");
                else if (entity.checkStatus == null)
                    this.SetFocus("cboBranchNo");

              
                return;
            }
                if (this.Sys001View.Status.Equals("Save"))
                {
                    //entity.BranchCode = CurrentUserEntity.BranchCode;                    
                    entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    if (entity.BranchCode == null)  //AllBranch
                    {                        
                        //foreach (BranchDTO branchDto in BranchList)
                        //{
                        //    entity.BranchCode = branchDto.BranchCode;
                        //    CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.SaveServerAndServerClient(entity));
                        //    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                        //        break;
                        //}
                        entity.checkStatus = "First";
                        for (int i = 0; i < BranchList.Count; i++)
                        {
                            //if (i != 0)
                            //    entity.checkStatus = "Second";

                            entity.BranchCode = BranchList[i].BranchCode;
                            entity.Count = BranchList.Count;
                            CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.SaveServerAndServerClient(entity));
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                                break;                            
                        }
                    }
                    else
                    {
                        entity.checkStatus = "third";
                        CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.SaveServerAndServerClient(entity));
                    }
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.Sys001View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);						
                    }
                    else
                    {
                        this.Sys001View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }

                else
                {
                    IList<DataVersionChangedValueDTO> dvcvList;
                    //entity.BranchCode = CurrentUserEntity.BranchCode;
                    entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    if (entity.BranchCode == null)
                    {
                        entity.checkStatus = "First";
                        //foreach (BranchDTO branchDto in BranchList)
                        //{
                        //    entity.BranchCode = branchDto.BranchCode;
                        //    dvcvList = GetChangedValueOfObject.GetChangedValueList(this.Sys001View.PreviousSys001Dto, entity);
                        //    CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.Update(entity, dvcvList));
                        //    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                        //        break;
                        //}
                        for (int i = 0; i < BranchList.Count; i++)
                        {
                            if (i != 0)
                                entity.checkStatus = "Second";
                            entity.BranchCode = BranchList[i].BranchCode;
                            dvcvList = GetChangedValueOfObject.GetChangedValueList(this.Sys001View.PreviousSys001Dto, entity);
                            CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.Update(entity, dvcvList));
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                                break;
                        }
                    }
                    else
                    {
                        entity.checkStatus = "First";
                        dvcvList = GetChangedValueOfObject.GetChangedValueList(this.Sys001View.PreviousSys001Dto, entity);
                        CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.Update(entity, dvcvList));
                    }
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.Sys001View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);						
                    }
                    else
                    {
                        this.Sys001View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
           // }
        }

        public void Delete(IList<PFMDTO00056> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].UpdatedUserId = CurrentUserEntity.CurrentUserID;
                itemList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
            } 
            CXClientWrapper.Instance.Invoke<ISAMSVE00049>(x => x.Delete(itemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.Sys001View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
				
            }
            else
            {
                this.Sys001View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

        public IList<PFMDTO00056> GetAll()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00049, IList<PFMDTO00056>>(service => service.GetAll());
        }

        public PFMDTO00056 SelectById(int id)
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00049, PFMDTO00056>(service => service.SelectById(id));
        }
        public void cboBranchNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.ViewData.BranchCode == null && this.view.chkStatus == false)
            {
                this.SetCustomErrorMessage(this.GetControl("cboBranchNo"), CXMessage.MV90029);
                return;
            }
        }
		
		#endregion
		
	}
}
