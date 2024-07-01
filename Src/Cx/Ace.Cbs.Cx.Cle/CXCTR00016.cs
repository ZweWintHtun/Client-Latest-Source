//----------------------------------------------------------------------
// <copyright file="CXCTR00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.Contracts.Service;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
namespace Ace.Cbs.Cx.Cle
{
    public class CXCTR00016 : AbstractPresenter, ICXCTR00016
    {
        public CXCTR00016()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        private string BranchCode { get; set; }
        private ICXCLE00016 view;
        public ICXCLE00016 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ICXCLE00016 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetManagerApproveEntity());
            }
        }
        /// <summary>
        /// ProgramInGroup Entity
        /// </summary>

        private ProgramInGroupDTO GetManagerApproveEntity()
        {
            ProgramInGroupDTO entity = new ProgramInGroupDTO();
            entity.UserName = this.View.UserName;
            entity.Password = this.View.Password;
            entity.ConfirmPassword = this.View.ConfirmPassword;
            entity.TestKey = this.View.TestKey;
            entity.ProgramPath = this.View.ProgramId;
            entity.HasTestKey = this.View.HasTestKey;
            entity.SourceBr = this.BranchCode;
            return entity;
        }

        //if cancel click want to ResetRememberPassword or not. 
        public void ClearControls()
        {
            this.View.UserName = string.Empty;
            this.View.TestKey = string.Empty;
            this.View.ResetRememberPassword(0,string.Empty, string.Empty, false);
            this.View.ChkRememberPassword = false;
            this.ClearPassword();
        }
      
        private void ClearPassword()
        {
            this.view.Password = string.Empty;
            this.view.ConfirmPassword = string.Empty;
        }

        private bool IsValidTestKey()
        {
            bool isValid = false;
            decimal TestKey = Convert.ToDecimal(this.View.TestKey);
            switch (this.View.RemittanceType)
            {
                case CXDMD00006.Drawing:
                    isValid = this.View.ValidTestKey.Equals(TestKey) ? true : false;
                    break;
                case CXDMD00006.Encash:
                    isValid = this.View.TestKey.Equals(CXCLE00017.Instance.GetTestKey(this.View.BranchKey, this.View.EncashDate.ToString("dd"), this.View.EncashDate.ToString("MM"), this.View.EncashAmount, CXCOM00007.Instance.BranchCode).ToString()) ? true : false;
                    break;
            }
            return isValid;


        }
    
        public void GetManagerApprove()
        {
            ProgramInGroupDTO entity = this.GetManagerApproveEntity();
            if (this.ValidateForm(entity))
            {
                if (this.View.RemittanceType != CXDMD00006.Other)
                {
                    if (!this.IsValidTestKey())
                    {
                        this.View.Failure(CXMessage.MV00169);//Invalid Testkey! Please Re Enter Again
                        return;
                    }
                }

                if (this.View.CurrentFormPermissionEntity.IsRememberPassword)
                {
                    this.View.Successful(this.View.CurrentFormPermissionEntity.UserId);
                }
                else
                {
                    bool isValidUser = CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.CheckUserNameandPassword(entity.UserName, entity.Password));
                    if (isValidUser)
                    {
                        int validPassword = CXClientWrapper.Instance.Invoke<IProgramInGroupService, int>(x => x.CheckManagerPermission(entity));
                        if (validPassword == 0)//(userEntity==null)
                        {
                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);// invalid Permission
                        }
                        else
                        {
                            this.View.Successful(validPassword);
                        }
                    }
                    else
                    {
                        this.View.Failure(CXMessage.MV00172);
                        //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode( CXMessage.MV00172); //Invalid Manager Permission.
                        return;
                    }
                }
            }
        }

        //public void txtUserName_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(this.view.UserName))
        //        {
        //            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90011); //User Name is required.

        //        }
        //        else
        //        {
        //            //if has a valid user, return false;
        //            bool inValidUser = CXClientWrapper.Instance.Invoke<IUserService, bool>(x => x.CheckUser(this.view.UserName,this.BranchCode));
        //            if (inValidUser)
        //                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90011); //User Name is required.
        //            else
        //                this.SetFocus("txtPassword");
        //        }
        //    }  
        //    catch (Exception ex)
        //    {
        //        this.SetCustomErrorMessage(this.GetControl("txtUserName"), CXMessage.MV90011);
        //    }
        //}
    }
}
