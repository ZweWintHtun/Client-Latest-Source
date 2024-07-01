//----------------------------------------------------------------------
// <copyright file="PFMSEV00012.cs" company="Ace Data Systems">
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
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Sve
{
    /// <summary>
    /// LinkAccount (LinkAC) Service.
    /// </summary>
    public class PFMSVE00012 : BaseService, IPFMSVE00012
    {
        #region Dao Properties

        /// <summary>
        /// Link Account Dao 
        /// </summary>
        private IPFMDAO00029 linkAccountDAO;
        public IPFMDAO00029 LinkAccountDAO
        {
            get { return this.linkAccountDAO; }
            set { this.linkAccountDAO = value; }
        }

        /// <summary>
        /// Cledger Dao
        /// </summary>
        private IPFMDAO00028 cledgerDAO;
        public IPFMDAO00028 CledgerDAO
        {
            get { return this.cledgerDAO; }
            set { this.cledgerDAO = value; }
        }

        /// <summary>
        /// CustomerId Dao
        /// </summary>
        private IPFMDAO00001 customerIdDAO;
        public IPFMDAO00001 CustomerIdDAO
        {
            get { return this.customerIdDAO; }
            set { this.customerIdDAO = value; }
        }

        public ICXSVE00006 CodeChecker { get; set; }

        #endregion

        #region Private Method

        /// <summary>
        /// MinimumBalance Valid or not.
        /// </summary>
        /// <param name="minimumBalance">min balance amount</param>
        /// <param name="accountNo">account nubmer</param>
        /// <returns></returns>
        private bool IsInValidMinimuimBalance(decimal minimumBalance, string accountNo)
        {
            // Call SelectMinimumBalanceByAccountNo method.
            PFMDTO00028 cledgerDTO = this.cledgerDAO.SelectMinimumBalanceByAccountNo(accountNo);

            //(minimum balance + minimun balance of CLedger table) is greater than current balance of CLedger table 
            if ((minimumBalance += cledgerDTO.MinimumBalance) > cledgerDTO.CurrentBal)
            {
                //return true.
                return true;
            }
            else
            {
                //return false
                return false;
            }
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Get Caof by account number.
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns></returns>
        public IList<PFMDTO00017> GetCAOFByAccountNumber(string accountNumber,string branchCode)
        {
            // Check account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNumber))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

           // Get Caof by account nubmer.                        
           IList<PFMDTO00017> CAOFList = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNumber));
           if (CAOFList.Count == 0)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = CXMessage.MV00058;//Invalid Current Account No.  
               return CAOFList;
           }
            
           else if (CAOFList != null)
           {
               //if (CAOFList[0].SourceBranchCode != CurrentUserEntity.BranchCode) //add by hmw (For different branch account no checking)  
               //if (CAOFList[0].SourceBranchCode != branchCode)
               //{
               //    this.ServiceResult.ErrorOccurred = true;
               //    this.ServiceResult.MessageCode = CXMessage.MV00224;//Invalid Account No {0} for Branch {1}.
               //    return CAOFList;
               //}
               //else
               //{
                   var customerId = from value in CAOFList
                                    where value.CustomerID != null
                                    select value.CustomerID;


                   if (customerId.ToList().Count > 0)
                   {
                       IList<string> customerIdList = customerId.ToList();
                       IList<PFMDTO00001> customerList = this.customerIdDAO.SelectListByCustId(customerIdList);
                       if (customerList != null)
                       {
                           for (int i = 0; i < CAOFList.Count; i++)
                           {
                               var customerName = (from value in customerList
                                                   where value.CustomerId == CAOFList[i].CustomerID
                                                   select value.Name).SingleOrDefault();

                               CAOFList[i].Name = string.IsNullOrEmpty(Convert.ToString(customerName)) ? string.Empty : Convert.ToString(customerName);
                           }
                       }
                   }

                   return CAOFList;
               
           }

           else
           {
               return null;
           }
        }
        
        /// <summary>
        /// Get SAOF by Account No
        /// </summary>
        /// <param name="accountNumber">Account No</param>
        /// <returns>Saof List Collection</returns>
        public IList<PFMDTO00016> GetSAOFByAccountNumber(string accountNumber,string branchCode)
        {
            // Check account no is already closed or not.
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNumber))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return null;
            }

            // Get Caof by account nubmer.
            IList<PFMDTO00016> SAOFList = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00016>>(x => x.GetSAOFsByAccountNumber(accountNumber));

            if (SAOFList != null)
            {
                //if (SAOFList[0].SourceBranchCode != CurrentUserEntity.BranchCode) //For different branch account no checking  
                //if (SAOFList[0].SourceBranchCode != branchCode)
                //{
                //    this.ServiceResult.ErrorOccurred = true;
                //    this.ServiceResult.MessageCode = CXMessage.MV00224;//Invalid Account No {0} for Branch {1}.
                //    return SAOFList;
                //}
                //else
                //{
                    var customerId = from value in SAOFList
                                     where value.Customer_Id != null
                                     select value.Customer_Id;

                    if (customerId.ToList().Count > 0)
                    {
                        IList<string> customerIdList = customerId.ToList();
                        IList<PFMDTO00001> customerList = this.customerIdDAO.SelectListByCustId(customerIdList);
                        if (customerList != null)
                        {
                            for (int i = 0; i < SAOFList.Count; i++)
                            {
                                var customerName = (from value in customerList
                                                    where value.CustomerId == SAOFList[i].Customer_Id
                                                    select value.Name).SingleOrDefault();
                                SAOFList[i].Name = string.IsNullOrEmpty(customerName) ? string.Empty : customerName.ToString();
                            }
                        }
                    }

                    return SAOFList;
                //}
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Save to LinkAccount datatable.
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(TransactionPropagation.Required)]
        public string Save(PFMDTO00029 entity)
        {
            string accountNo = string.Empty;
            try
            {                
                PFMORM00029 linkAccount = Mapper.Map<PFMDTO00029, PFMORM00029>(entity);

                // Check current account no is already closed or not.
                if (this.CodeChecker.IsClosedAccountForCLedger(entity.CurrentAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return;
                }

                // Check saving account no is already closed or not.
                if (this.CodeChecker.IsClosedAccountForCLedger(entity.SavingAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return;
                }

                // Check Loan Account No
                if (this.CodeChecker.HasLoanAccount(entity.CurrentAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return;
                }

                // Check Current Link Account No
                if (this.CodeChecker.HasCurrentAccountInLinkAccount(entity.CurrentAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return;
                }

                // Check Saving Link Account No
                if (this.CodeChecker.HasCurrentAccountInLinkAccount(entity.SavingAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                    //return;
                }

                if (IsInValidMinimuimBalance(linkAccount.MinimumCurrentAccountBalance, linkAccount.CurrentAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;

                    //Total minimum balance cannot be greater than ledger balance for Account No {0}
                    this.ServiceResult.MessageCode = CXMessage.MV00062;
                    accountNo = linkAccount.CurrentAccountNo;
                }
                if (IsInValidMinimuimBalance(linkAccount.MinimumSavingAccountBalance, linkAccount.SavingAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;

                    //Total minimum balance cannot be greater than ledger balance for Account No {0}
                    this.ServiceResult.MessageCode = CXMessage.MV00062;
                    accountNo = linkAccount.SavingAccountNo;

                }
                if (this.ServiceResult.ErrorOccurred != true)
                {
                    this.linkAccountDAO.Save(linkAccount);
                    this.ServiceResult.ErrorOccurred = false;
                    
                    // Saving Successful
                    this.ServiceResult.MessageCode = CXMessage.MI90001;
                }                
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90036;
            }
            return accountNo;          
        }
        #endregion        
    }
}