//----------------------------------------------------------------------
// <copyright file="MNMSVE00008.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    /// PO Editting for Encashment Service
    /// </summary>
    public class MNMSVE00020 : BaseService, IMNMSVE00020
    {
        #region DAO Properties

        public ITLMDAO00016 PODAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }        
        #endregion

        #region "Main Methods"    

        [Transaction(TransactionPropagation.Required)]
        public void DeleteOldPONoByActive(IList<TLMDTO00043> polist, string branchno, int updateUserId)
        {
            try
            {
                foreach (TLMDTO00043 po in polist)
                {
                    this.PODAO.DeletePOByActive(po.PONo, branchno, updateUserId);
                    this.ServiceResult.ErrorOccurred = false;
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }
        

        #endregion

        public bool CheckingChequeNo(string accountNo, string chequeNo, string branch)  
        {
            if (!chequeNo.Equals(string.Empty) && this.CodeChecker.IsVaildChequeNoforWithdrawal(accountNo, chequeNo, branch))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = this.CodeChecker.ServiceResult.MessageCode;
                return false;
            }
            return true;
        }

        public string GetDescriptionByAccountNo(string accountNo)
        {
            string customerDescription = string.Empty;
            IList<PFMDTO00001> customerList = this.CodeChecker.GetCustomerInfomationByAccountNo(accountNo, false);
            if (customerList.Count > 0)
            {
                customerDescription = customerList[0].Name;
            }
            return customerDescription;
        }
   

    }
}