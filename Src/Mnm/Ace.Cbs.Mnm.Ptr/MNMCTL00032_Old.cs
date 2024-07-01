//----------------------------------------------------------------------
// <copyright file="MNMCTL00032.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// Controller
    /// </summary>
    public class MNMCTL00032 : AbstractPresenter, IMNMCTL00032
    {
        #region "Property"
        private bool isValidateForm = false;
        private bool isSaveValidate = false;
        public string accountsign = null;
        public string fname = null;
        PFMDTO00067 bindData;
        string Account = string.Empty;
        string Currency = string.Empty;

        DateTime openDate;
        DateTime createdDate;
        int createdUserId;

        private IMNMVEW00032 view;
        public IMNMVEW00032 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        #endregion "Property"

        #region WireTo

        private void WireTo(IMNMVEW00032 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetJointEntity());
            }
        }

        #endregion WireTo

        #region UI Logic
        
        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.NoOfPersonSign = 0;
            this.view.ReceiptNo = string.Empty;
            this.view.MinBalance = 0;     //Added by ASDA
            this.view.FReceipt = new PFMDTO00032();
            this.view.ChequeBookNo = string.Empty;
            this.view.ChequeStartNo = string.Empty;
            this.view.ChequeEndNo = string.Empty;
            this.view.DebitLinkAccount = string.Empty;
            this.view.LinkAccountName = string.Empty;
            this.view.CustomerDataSource = null;
            this.view.BindCustomer();
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.JoinType = "A";
            this.ClearAllCustomErrorMessage();
            this.view.Status = string.Empty;
            this.view.OldCustomers.Clear();
        }

        public bool AddCustomer()
        {
            // Validate date of birth is greater than 18.
            if (CXUIScreenTransit.Transit("frmPFMVEW00005", new object[] { false, true }) == System.Windows.Forms.DialogResult.OK)
            {
                PFMDTO00001 customer = CXUIScreenTransit.GetData<PFMDTO00001>("PFMVEW00005");
                if (customer != null)
                {
                    if (this.view.CustomerDataSource.Count > 0)
                    {
                        var duplicateRecord = this.view.CustomerDataSource.Where(x => x.CustomerId == customer.CustomerId).ToList<PFMDTO00001>();
                        if (duplicateRecord.Count() > 0)
                        {
                            // Duplicated Customer Id.
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00029);
                            return false;
                        }
                    }

                    this.view.CustomerDataSource.Add(customer);
                    return true;
                }
            }

            return false;
        }

        public void Save()
        {
            // Get Input Data
            PFMDTO00050 joint = this.GetJointEntity();
            joint.AcceptedDate = this.openDate;
            joint.CreatedDate = this.createdDate;
            joint.CreatedUserId = this.createdUserId;

            this.isValidateForm = true;

                            // Validation Logic
            if (this.ValidateForm(joint))
            {
                    // Saving Logic                
                    CXClientWrapper.Instance.Invoke<IMNMSVE00032>(x => x.SaveJoint(joint));

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        string accountCode = this.view.AccountNo;
                        this.View.Successful(CXMessage.MI90002, accountCode);                       //Update Successful
                        this.ClearControls();                                                       // Clear all controls
                        this.View.Status = string.Empty;
                        this.View.SetEnable();


                    }
            }

            this.isValidateForm = false;
        }

        #endregion

        #region Helper Methods

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
           
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false || isSaveValidate == false )
            {
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                try
                {
                    Nullable<CXDMD00011> accountType;
                    
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        if (this.View.Status != "save")
                        {
                            if (Account != this.view.AccountNo)
                            {
                                Account = this.view.AccountNo;
                                this.view.NoOfPersonSign = 0;
                                this.view.CustomerDataSource = null;
                                this.view.BindCustomer();
                                this.view.MinBalance = 0;
                                this.view.Photo = null;
                                this.view.Signature = null;
                                this.view.JoinType = "A";
                            }
                            this.JointAccountChecking();
                           
                        }
                        else if (this.View.Status == "save" && this.view.AccountNo != Account)
                        {
                            Account = string.Empty;
                            this.view.Status = string.Empty;
                            this.view.NoOfPersonSign = 0;
                            this.view.CustomerDataSource = null;
                            this.view.BindCustomer();
                            this.view.MinBalance = 0;
                            this.view.Photo = null;
                            this.view.Signature = null;
                            this.view.JoinType = "A";
                      
                            this.JointAccountChecking();
                        }
                        else
                        {

                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                                this.ClearControls();
                                return;
                            }
                        }                 
                    }
                    else
                    {
                        //Updating Error
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.ME90001);
                    }
                }
                catch (Exception ex)
                {
                  //  this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);

                    if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00211")
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { bindData.message });//Invalid Account No.
                    else
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);



                }
            }

        }

        public void txtMinBal_CustomValidating(object sender, ValidationEventArgs e)
        {
            decimal cbal = bindData.CBal;
            decimal ovdlimit = bindData.OverDraftAmount;
            decimal total = cbal + ovdlimit;
            decimal  minbal = this.view.MinBalance;

            if (minbal > total)
            {
                //Total minimum balance can't be greater than ledger balance.
                this.SetCustomErrorMessage(this.GetControl("txtMinbal"), CXMessage.MV00062, new object[] { this.view.AccountNo });
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtMinbal"), string.Empty);
            }
        }

        private void JointAccountChecking()
        {
            #region Old Coding

            //fname = this.View.TransactionStatus;   // get formname for accountType
            //if(fname != null)
            //{
            //       if (fname == "Current.Joint")    
            //       {
            //           // get current account information and acsign  
            //           IList<PFMDTO00017> currentAccount = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(this.view.AccountNo));
            //           if (currentAccount.Count <= 0)
            //           {
            //               this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00175);
            //               return;
            //           }
            //           else
            //           {
            //               if (currentAccount[0].CloseDate == null || currentAccount[0].CloseDate.ToString() == "" || currentAccount[0].CloseDate.ToString() == "01/01/0001 12:00:00 AM")  //check close date  
            //               {
            //                   accountsign = currentAccount[0].AccountSign;

            //                   if (accountsign[0] == 'C' && accountsign != "CJ")
            //                   {
            //                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058); //current joint account only(need)
            //                       return;
            //                   }
            //                   else if (accountsign == "CJ")
            //                   {
            //                       //this.view.CurrencyCode = currentAccount[0].CurrencyCode;
            //                       this.View.BindJointData();
            //                       return;
            //                   }
            //                   else
            //                   {
            //                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00058);
            //                       return;
            //                   }
            //               }  //check close date
            //               else
            //               {
            //                   this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044); //Account No has been closed.
            //                   return;
            //               }
            //           }
            //        }

            //        else if (fname == "Saving.Joint")
            //        {
            //            //get saving account information and acsign  
            //             IList<PFMDTO00016> savingAccount = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(this.view.AccountNo));
            //             if (savingAccount == null)
            //             {
            //                 this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00175);  //Account not found
            //                 return;
            //             }
            //             else
            //             {
            //                 if (savingAccount[0].CloseDate == null || savingAccount[0].CloseDate.ToString() == "" || savingAccount[0].CloseDate.ToString() == "01/01/0001 12:00:00 AM")  //check close date  
            //                 {
            //                     accountsign = savingAccount[0].AccountSign;

            //                     if (accountsign[0] == 'S' && accountsign != "SJ")
            //                     {
            //                         this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00051); // saving joint account only(need) 
            //                         return;
            //                     }
            //                     else if (accountsign == "SJ")
            //                     {
            //                         //this.view.CurrencyCode = savingAccount[0].CurrencyCode;
            //                         this.View.BindJointData();
            //                         return;
            //                     }
            //                 }
            //                 else
            //                 {
            //                     this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044); //Account No has been closed.
            //                     return;
            //                 }
            //             }
            //       }

            //       else if (fname == "Fixed.Joint")
            //       {
            //           //get fixed account information and acsign  
            //           IList<PFMDTO00021> fixedaccount = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00021>>(x => x.GetFAOFsByAccountNumber(this.view.AccountNo));
            //           if (fixedaccount == null)
            //           {
            //               this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00175);    //Account not found 
            //               return;
            //           }
            //           else
            //           {
            //               if (fixedaccount[0].CloseDate == null || fixedaccount[0].CloseDate.ToString() == "" || fixedaccount[0].CloseDate.ToString() == "01/01/0001 12:00:00 AM")  //check close date  
            //               {
            //                   accountsign = fixedaccount[0].AccountSignature;
            //                   if (accountsign[0] == 'F' && accountsign != "FJ")
            //                   {
            //                       this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00022);  //fixed deposit account only
            //                       return;
            //                   }
            //                   else if (accountsign == "FJ")
            //                   {
            //                       // this.View.CurrencyCode = fixedaccount[0].CurrencyCode;
            //                       this.View.BindJointData();
            //                       return;
            //                   }
            //               }
            //               else
            //               {
            //                   this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044); //Account No has been closed.
            //                   return;
            //               }
            //           }
            //       }
                         
            //    return;

            //}
            #endregion

            this.View.BindJointData();
            this.View.SetDisable();
            
        }
            
        public void gvCustomer_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.CustomerDataSource.Count < 2)
            {
                // This Account must at least two persons.
                this.SetCustomErrorMessage(this.GetControl("gvCustomer"), CXMessage.MV00032);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("gvCustomer"), string.Empty);
            }

            //if (this.view.TransactionStatus == "Fixed.Joint")
            //{
            //    //string amount = Convert.ToString(this.view.FReceipt.Amount);
            //    if (this.view.FReceipt.Amount == 0 || string.IsNullOrEmpty(amount))
            //    {
            //        // Invalid Receipt No.
            //        this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), CXMessage.MV00022);
            //    }
            //    else
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtReceiptNo"), string.Empty);
            //    }
            //}
        }

        public void txtNoOfPersonSign_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if (this.isValidateForm == false && this.view.CustomerDataSource.Count == 0)
            {
                return;
            }

            if (this.view.NoOfPersonSign < 2)
            {
                // Must be at least two person
                this.SetCustomErrorMessage(this.GetControl("txtNoPersonSign"), CXMessage.MV00028);
            }

            if (this.view.NoOfPersonSign > this.view.CustomerDataSource.Count)
            {
                // Invalid No of Person to Sign.
                this.SetCustomErrorMessage(this.GetControl("txtNoPersonSign"), CXMessage.MV00028);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtNoPersonSign"), string.Empty);
            }
        }

        private PFMDTO00050 GetJointEntity()
        {
            PFMDTO00050 jointEntity = new PFMDTO00050();
            jointEntity.AccountNo = this.view.AccountNo;
            jointEntity.TransactionStatus = this.view.TransactionStatus;

            if (string.IsNullOrEmpty(this.view.TransactionStatus) == false)
            {
                jointEntity.AccountType = this.view.TransactionStatus.Substring(0, this.view.TransactionStatus.IndexOf("."));
                jointEntity.SubAccountType = this.view.TransactionStatus.Substring(this.view.TransactionStatus.IndexOf(".") + 1);
            }
            
            jointEntity.BranchCode = CXCOM00007.Instance.BranchCode;
            jointEntity.CurrencySymbol = this.view.CurrencSymbol;
            jointEntity.CurrencyCode = this.view.CurrencyCode;
            
            jointEntity.NoOfPersonSign = this.view.NoOfPersonSign;
            jointEntity.FReceipt = this.view.FReceipt;
            jointEntity.ChequeBookNo = this.view.ChequeBookNo;
            jointEntity.ChequeStartNo = this.view.ChequeStartNo;
            jointEntity.ChequeEndNo = this.view.ChequeEndNo;
            jointEntity.DebitLinkAccount = this.view.DebitLinkAccount == string.Empty ? null : this.view.DebitLinkAccount;
            jointEntity.DebitLimit = this.view.DebitLimit;
            jointEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            //jointEntity.CreatedDate = DateTime.Now;
            //Added by ASDA** 
            jointEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;  
            jointEntity.UpdatedDate = DateTime.Now;
            //End**
            jointEntity.BranchCode = CurrentUserEntity.BranchCode;
            jointEntity.JoinType = this.view.JoinType;
            jointEntity.MinBal = this.view.MinBalance;
            jointEntity.OldCustomerIds = this.view.OldCustomers;
            if (this.View.CustomerDataSource.Count > 0)
            {
                jointEntity.CustomerIds = this.view.CustomerDataSource.Select(x => x.CustomerId).ToArray<string>();
            }

            if (this.view.TransactionStatus == "Saving.Joint")
            {
                jointEntity.SavingInterestRate = Convert.ToDecimal(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingInterestRate));
            }

            return jointEntity;
        }

        private string GetPersonSignatureString()
        {
            string returnValue = string.Empty;

            returnValue += this.view.NoOfPersonSign + " Person";

            if (this.view.NoOfPersonSign > 1)
            {
                returnValue += "s";
            }

            return returnValue + " will assign.";
        }

        public PFMDTO00067 GetAccountInformation(string accountNo,string acSign)
        {

            try
            {
                acSign = acSign + "." + this.View.CurrencyCode;

                bindData = CXClientWrapper.Instance.Invoke<IMNMSVE00032, PFMDTO00067>(service => service.GetJointAccountInformation(accountNo, acSign, CurrentUserEntity.BranchCode));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (!string.IsNullOrEmpty(bindData.message))
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { bindData.message });
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    if (bindData.SourceBr != CurrentUserEntity.BranchCode)
                    {
                        // Invalid Branch Code
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                        return null;
                    }
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                }
            }
            catch(Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(ex.Message);  
                //throw new Exception();
            }
            
                this.openDate = bindData.CustomerInfo[0].DATE_TIME;
                this.createdDate = bindData.CustomerInfo[0].CreatedDate;
                this.createdUserId = bindData.CustomerInfo[0].CreatedUserId;
            
            return bindData;
        }

        #endregion

    }
}