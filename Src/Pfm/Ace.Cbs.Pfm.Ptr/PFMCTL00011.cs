//----------------------------------------------------------------------
// <copyright file="PFMCTL00011.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>11/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    /// <summary>
    /// Current Account Closing Presenter
    /// </summary>
    public class PFMCTL00011 : AbstractPresenter, IPFMCTL00011
    {
        #region Private Variables
        private IPFMVEW00011 view;
        private bool isSaveValidate = false;
        private decimal homeExchangeRate = 0;
        #endregion

        #region Properties
        public IPFMVEW00011 View 
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        public bool hasCheque { get; set; }
        #endregion

        #region UI Logic
        private void WireTo(IPFMVEW00011 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, new PFMDTO00072());
            }
        }

        public void mtxtAccountNo_Validating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || this.isSaveValidate)
            {
                return;
            }

            // AccountNo Checking (Code Format and CheckDigit)
            if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
            {

                if (CXCOM00006.Instance.isCurrentAccount(this.view.AccountNo, CXCOM00009.AccountTypePosition) == false)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
                    return;
                }

                // Clear AccountNo Error
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);

                // Get Current Account Information
                IList<PFMDTO00072> currentAccount = CXClientWrapper.Instance.Invoke<IPFMSVE00011, IList<PFMDTO00072>>(x => x.GetCurrentAccountInfo(this.view.AccountNo,this.view.BranchCode));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if(CXClientWrapper.Instance.ServiceResult.MessageCode=="MV00091")
                    {                        
                        //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { CurrentUserEntity.BranchCode });
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.BranchCode });
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });                        
                    }                    
                    return;
                }
                else if (currentAccount.Count == 0)
                {
                    // Invalid Current Account No.
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
                    this.ClearControls(false);
                    return;
                }
                else if (CXClientWrapper.Instance.ServiceResult.MessageCode == "NoCheque")
                {
                    this.SetEnableDisable("txtChequeNo", false);
                    this.SetFocus("ntxtCharges");
                    this.hasCheque = false;
                }
                else
                {
                    this.SetEnableDisable("txtChequeNo", true);
                    this.SetFocus("txtChequeNo");
                    this.hasCheque = true;
                }

                

                this.view.CurrencyCode = currentAccount[0].CurrencyCode;
                this.view.AccountSignature = currentAccount[0].AccountSignature;
                if(!this.view.SaveStatus)
                    this.view.Charges = CXCLE00002.Instance.GetScalarObject<decimal>("Setup.AccountClose.Select", new object[] { this.view.CurrencyCode, this.view.BranchCode, true });
                this.View.Balance = currentAccount[0].CurrentBalance;
                this.view.NetBalance = this.view.Balance - this.view.Charges;
                this.View.Customers = currentAccount.ToDictionary(x => x.CustomerId, y => y.CustomerName);

                this.View.BindCustomer();

                this.homeExchangeRate = CXCOM00010.Instance.GetExchangeRate(this.view.CurrencyCode, "TT");
                if (this.homeExchangeRate == 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                    this.homeExchangeRate = 1;
                }
            }
            else
            {
                // Invalid Current Account No.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
            }
        }

        public void txtChequeNo_Validating(object sender, ValidationEventArgs e)
        {

            if (e.HasXmlBaseError || this.isSaveValidate )
            {
                return;              
            }
            else
            { this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat); }
           
        }

        public void ntxtCharges_Validating(object sender, ValidationEventArgs e)
        {
            this.view.NetBalance = this.view.Balance - this.view.Charges;
        }

                
        public void SaveCurrentAccountClose()
        {
            //this.isSaveValidate = true;
            PFMDTO00072 accountClose = this.GetAccountClose();
            accountClose.HasCheque = hasCheque;
            if (this.ValidateForm(accountClose))
            {
                if (this.view.Balance < this.view.Charges)
                {
                    // Insufficient Balance to charge.
                    this.SetCustomErrorMessage(this.GetControl("ntxtCharges"), CXMessage.MV00052);
                }

                if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00001) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                else
                {
                    CXClientWrapper.Instance.Invoke<IPFMSVE00011>(x => x.SaveCurrentAccountClose(accountClose));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            string message = CXClientWrapper.Instance.ServiceResult.MessageCode;
                            string messageDesp = Ace.Windows.CXClient.CXUIMessageUtilities.GetErrorMessage(message, string.Empty).ToString();
                            if (messageDesp.Contains("Cheque"))
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00059);//Invalid Cheque No.
                                this.SetFocus("txtChequeNo");
                                return;
                            }
                            else
                            {
                                if (message == "MV00091")
                                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00091, new object[] { this.GetBranchCode() });//Invalid Cheque No.
                                else if (message == "MV00058")
                                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00058);
                                else                                
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                                
                                    this.SetFocus("mtxtAccountNo");
                                return;
                            }
                        }
                                             
                        this.isSaveValidate = false;
                        return;
                    }
                    else
                    {
                        // Account  No ({0}) has been successfully closed.

                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00006, new object[] { CXCLE00007.GetFormatStringBy999(accountClose.AccountNo, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat)) });
                        this.ClearControls(true);
                        this.SetFocus("mtxtAccountNo");
                        this.view.SaveStatus = false;
                        return;
                    }
                }
            }         
            this.isSaveValidate = false;          
        }        

        public void ClearControls(bool isAccountNo)
        {
            this.view.AccountSignature = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.ChequeNo = string.Empty;
            this.view.CloseDate = DateTime.Now;
            this.view.Balance = decimal.Zero;
            this.view.NetBalance = decimal.Zero;
            this.view.Charges = decimal.Zero;
            this.view.Customers = new Dictionary<string, string>();
            this.view.BindCustomer();
            if (isAccountNo)
            {
                this.view.AccountNo = string.Empty;
                this.ClearAllCustomErrorMessage();
            }
        }

        public string GetBranchCode()
        {
            return CXCOM00007.Instance.BranchCode;
        }
        #endregion

        #region Helper Methods
        private PFMDTO00072 GetAccountClose()
        {
            PFMDTO00072 accountClose = new PFMDTO00072();

            accountClose.AccountNo = this.view.AccountNo;
            accountClose.AccountSignature = this.view.AccountSignature;
            accountClose.CurrencyCode = this.view.CurrencyCode;
            if (this.view.Customers.Count > 0)
            {
                accountClose.CustomerName = this.view.Customers.First().Value;
            }

            accountClose.CloseDate = DateTime.Now;
            accountClose.CustomerIds = this.view.Customers.Keys.ToArray<string>();
            accountClose.ChequeNo = this.view.ChequeNo;
            accountClose.BranchCode = this.view.BranchCode;
            accountClose.CurrentBalance = this.view.Balance;
            accountClose.Charges = this.view.Charges;

            if (accountClose.Charges != 0)
            {
                //select * from CoaSetup at CLientSqlite 
                accountClose.DebitCOAAccountNo = CXCOM00010.Instance.GetCOAAccountNo("CURCONTROL", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.BankAccountNo = CXCOM00010.Instance.GetCOAAccountNo("INCOME", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.CreditCOAAccountNo = CXCOM00010.Instance.GetCOAAccountNo("OTH_INCOME", accountClose.BranchCode, accountClose.CurrencyCode);
                accountClose.HomeExchangeRate = this.homeExchangeRate;
                accountClose.NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate("NEXT_SETTLEMENT_DATE", accountClose.BranchCode);
            }

            accountClose.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            accountClose.Active = true;

            return accountClose;
        }
        #endregion
    }
}