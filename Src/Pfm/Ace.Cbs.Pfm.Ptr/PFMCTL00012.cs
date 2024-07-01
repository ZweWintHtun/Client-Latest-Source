//----------------------------------------------------------------------
// <copyright file="PFMCTL00012.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// LinkAccount (LinkAC) Entry
    /// </summary>
    public class PFMCTL00012 : AbstractPresenter, IPFMCTL00012
    {
        #region Properties

        /// <summary>
        /// Caof list collection
        /// </summary>
        IList<PFMDTO00017> CAOFList { get; set; }

        /// <summary>
        /// Saof list Collection
        /// </summary>
        IList<PFMDTO00016> SAOFList { get; set; }

        public ICXSVE00006 CodeChecker { get; set; }

        #endregion

        #region Form Initializer

        /// <summary>
        /// Link Account View.
        /// </summary>
        private IPFMVEW00012 linkAccountView;
        public IPFMVEW00012 LinkAccountView
        {
            set { this.WireTo(value); }
            get { return this.linkAccountView; }
        }

        /// <summary>
        /// Wrie Up Controller to View.
        /// </summary>
        /// <param name="linkAccountView">Link account view</param>
        private void WireTo(IPFMVEW00012 linkAccountView)
        {
            if (this.linkAccountView == null)
            {
                //Set LinkAccountView.
                this.linkAccountView = linkAccountView;

                //Initialize for validation.
                this.Initialize(this.linkAccountView, this.linkAccountView.LinkAccountEntity);

                //Add CustomValidating event 
                //this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.mtxtCurrentAccountNo_CustomValidating);

                //Add CustomValidating event 
                //this.ErrorProvider.Validating += new EventHandler<ValidationEventArgs>(this.mtxtSavingAccountNo_CustomValidating);
            }
        }

        #endregion

        #region Validation Methods

        /// <summary>
        /// Custom Validation for mtxtCurrentAccountNo.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">ValidationEventArgs</param>
        public void mtxtCurrentAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if ( e.HasXmlBaseError == false)
            {
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                if (CXCOM00006.Instance.Validate(this.LinkAccountView.CurrentAccountNo,CXCOM00009.AccountNoCodeFormat ,CXCOM00009.AccountNoCheckDigitFormula ))
                {                    
                    //Check this is CurrentAccount or not
                    if (CXCOM00006.Instance.isCurrentAccount(this.linkAccountView.CurrentAccountNo, CXCOM00009.AccountTypePosition) == false)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), CXMessage.MV00058);
                        return;
                    }

                    bool isLink = CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.HasCurrentAccountInLinkAccount(this.LinkAccountView.CurrentAccountNo));
                    // Check Current Link Account No
                    if (isLink)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00056 , new object[]{this.linkAccountView.CurrentAccountNo});
                        //This Account {0} is already Link Account.
                        this.SetFocus("mtxtCurrentAccountNo");
                        return;
                    }
                    
                    // Set Empty to control.
                    SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), string.Empty);

                    // Select Caof list by Current Account No.
                    
                    this.CAOFList = CXClientWrapper.Instance.Invoke<IPFMSVE00012, IList<PFMDTO00017>>(x => x.GetCAOFByAccountNumber(this.LinkAccountView.CurrentAccountNo,CurrentUserEntity.BranchCode));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        if (message == "MV00044")//Account No has been closed. (This message is from common module).
                        {
                            message = "MV00201";//Account No {0} has been closed.
                        }
                        if (message == "MV00224")//Invalid Account No {0} for Branch {1}.
                        {                           
                        this.SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), message, new object[] {this.linkAccountView.CurrentAccountNo,CurrentUserEntity.BranchCode}); //Invalid Account No. {0} for Branch {1}. (add by hmw)
                        }
                        else if (message == "MV00201")
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), message, new object[] { this.LinkAccountView.CurrentAccountNo }); //Account No {0} has been closed.. (add by hmw)
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), string.Empty);
                        }
                        return;
                    }
                    else
                    {

                        // if caof list count is greater than zero.
                        if (this.CAOFList != null && this.CAOFList.Count > 0)
                        {
                            // get customerNames from CAOFList.
                            var customerName = from value in this.CAOFList
                                               orderby value.Name
                                               select value.Name;

                            // Bind customerNames to lvCurrentNames.
                            this.LinkAccountView.lvCurrentNames_DataBind(customerName.ToList());
                        }
                        else
                        {
                            // Set Error Message to Control.                            
                            this.SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), CXMessage.MV00058); //Invalid Current Account No.
                            return;
                        }
                    }
                }
                else
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("mtxtCurrentAccountNo"), CXMessage.MV00058);
                }
            }
        }
        
        /// <summary>
        /// Custom Validation for mtxtSavingAccountNo.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">ValidationEventArgs</param>
        public void mtxtSavingAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                if (CXCOM00006.Instance.Validate(this.LinkAccountView.SavingAccountNo, CXCOM00009.AccountNoCodeFormat ,CXCOM00009.AccountNoCheckDigitFormula))
                {
                    //Check this is SavingAccount or not
                    if (CXCOM00006.Instance.isSavingAccount(this.linkAccountView.SavingAccountNo, CXCOM00009.AccountTypePosition) == false)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), CXMessage.MV00051);//Invalid Saving Account No.
                        return;
                    }

                    // Set Empty to control.
                    SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), string.Empty);

                    // Select Saof list by Current Account No.
                    this.SAOFList = CXClientWrapper.Instance.Invoke<IPFMSVE00012, IList<PFMDTO00016>>(x => x.GetSAOFByAccountNumber(this.LinkAccountView.SavingAccountNo,CurrentUserEntity.BranchCode));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {                        
                        string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                        if (message == "MV00044")//Account No has been closed. (This message is from common module).
                        {
                            message = "MV00201";//Account No {0} has been closed.
                        }
                        if (message == "MV00224")//Invalid Account No {0} for Branch {1}.
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), message, new object[] { this.LinkAccountView.SavingAccountNo, CurrentUserEntity.BranchCode }); //Invalid Account No. {0} for Branch {1}. (add by hmw)
                        }
                        else if (message == "MV00201")//Account No {0} has been closed.
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), message, new object[] { this.LinkAccountView.SavingAccountNo }); //Account No {0} has been closed.. (add by hmw)
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), string.Empty);
                        }
                        return;
                    }
                    else
                    {
                        // if saof list count is greater than zero.
                        if (this.SAOFList != null && this.SAOFList.Count > 0)
                        {
                            // get customerNames from SAOFList.
                            var customerName = from value in this.SAOFList
                                               orderby value.Name
                                               select value.Name;

                            // Bind customerNames to lvSavingNames.
                            this.LinkAccountView.lvSavingNames_DataBind(customerName.ToList());
                        }
                        else
                        {
                            // Set Error Message to Control.
                            this.SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), CXMessage.MV00051); //Invalid Saving Account No.
                            return;
                        }
                    }
                }           
                else
                {
                    // Set Error Message to Control.
                    this.SetCustomErrorMessage(this.GetControl("mtxtSavingAccountNo"), CXMessage.MV00051);
                }
            }
        }

        /// <summary>
        /// VaidateForm
        /// </summary>
        /// <param name="validationContext">validationContext</param>
        /// <returns></returns>
        public override bool ValidateForm(object validationContext)
        {
            //return validateForm.
            return base.ValidateForm(validationContext);
        }

        #endregion        

        #region Public Method

        /// <summary>
        /// Save Link Account entry.
        /// </summary>
        /// <param name="entity">Link Account Entry.</param>
        public void Save(PFMDTO00029 entity)
        {
            // Check Validation.
            if (this.ValidateForm(entity))
            {   
                //if Currency of current A/C and saving A/C should be same.                
                if (!this.CAOFList[0].CurrencyCode.Equals(this.SAOFList[0].CurrencyCode))
                {
                    //Currency of current A/C and saving A/C should be same.
                    this.LinkAccountView.Failure(CXMessage.MV00063,null);
                    return;
                }               

                // get source branch code from application setting.
                entity.SourceBranchCode = CurrentUserEntity.BranchCode;
                
                //get Second Priority Value 
                entity.SecondPriority = entity.SavingAccountNo;

                //get Third Priority Value
                entity.ThirdPriority = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ThirdPriorityValue);

                // get currencyCode.
                entity.CurrencyCode = this.CAOFList[0].CurrencyCode;

                // get Created User Id.
                entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                entity.AccessDate = DateTime.Now;

                // Call Save method from link Account Service.
                string accountNo = CXClientWrapper.Instance.Invoke<IPFMSVE00012,string>(x => x.Save(entity));

                // if error does not occur.
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    this.LinkAccountView.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);                    
                }
                //else error occurs.
                else
                {
                    if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00062")//Total minimum balance cannot be greater than ledger balance for Account No {0}.
                    {
                        if (accountNo.Substring(4, 1) == "1")//For Current Account textbox
                        {
                            this.LinkAccountView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,accountNo);                            
                        }
                        else if (accountNo.Substring(4, 1) == "2")//For Saving Account textbox
                        {
                            this.LinkAccountView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode, accountNo);                       
                        }
                    }
                    else
                    {
                        this.LinkAccountView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode,null);
                    }
                    return;
                }
            }   
        }
        public void ClearControls()
        {            
            this.linkAccountView.CurrentAccountNo = "";            
            this.linkAccountView.SavingAccountNo = "";            
            this.ClearAllCustomErrorMessage();
        }
        #endregion
      
    }
}