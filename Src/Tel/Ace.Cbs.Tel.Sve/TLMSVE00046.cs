//----------------------------------------------------------------------
// <copyright file="TLMSVE00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
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
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Ser.Sve;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// IBL Transaction Listing By Branch Service
    /// </summary>
    public class TLMSVE00046 : BaseService, ITLMSVE00046
    { 
        #region DAO
        public ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Main Method
        public IList<TLMDTO00004> HomeTransactionListinByBranch(DateTime startDate, DateTime endDate,string tranType,string branch,string sourcebranch,bool isReversal)
        {
            IList<TLMDTO00004> ibltlfDTOList = this.ViewDAO.HomeTransactionByBranchListing(startDate, endDate, branch, sourcebranch);

            if (!string.IsNullOrEmpty(tranType))
            {
                if (tranType == "-")
                {
                    if (isReversal == true)
                    {
                        var hometransactionListingByBranch = (from value in ibltlfDTOList
                                                              where value.TranType != "ENQ"
                                                              select value).ToList();
                        return hometransactionListingByBranch;
                    }
                    else
                    {
                        var hometransactionListingByBranch = (from value in ibltlfDTOList
                                                              where value.TranType != "ENQ" && value.Reversal == Convert.ToBoolean(0)
                                                              select value).ToList();
                        return hometransactionListingByBranch;
                    }

                }
                else
                {

                    if (isReversal == true)
                    {
                        var hometransactionListingByBranch = (from value in ibltlfDTOList
                                                              where value.TranType == tranType
                                                              select value).ToList();
                        return hometransactionListingByBranch;
                    }
                    else
                    {
                        var hometransactionListingByBranch = (from value in ibltlfDTOList
                                                              where value.TranType == tranType && value.Reversal == Convert.ToBoolean(0)
                                                              select value).ToList();
                        return hometransactionListingByBranch;
                    }
                }
            }
          
 
            
            
            if (ibltlfDTOList == null || ibltlfDTOList.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // No Data for Report
                return ibltlfDTOList;
            }
            else
           { return ibltlfDTOList; }
        }
        public IList<TLMDTO00004> ActiveTransactionListinByBranch(DateTime startDate, DateTime endDate, string tranType, string branch, string sourcebranch, bool isReversal)
        {
            IList<TLMDTO00004> ibltlfDTOList = this.ViewDAO.ActiveTransactionByBranchListing(startDate, endDate,branch,sourcebranch);

            if (!string.IsNullOrEmpty(tranType))
            {
                //if (tranType == "WENQ")
                if (tranType == "-")
                {
                    if (isReversal == true)
                    {
                        var activeTransactionListingByBranch = (from value in ibltlfDTOList
                                                                where value.TranType != "ENQ"
                                                                select value).ToList();
                        return activeTransactionListingByBranch;
                    }
                    else
                    {
                        var activeTransactionListingByBranch = (from value in ibltlfDTOList
                                                                where value.TranType != "ENQ" && value.Reversal == Convert.ToBoolean(0)
                                                                select value).ToList();
                        return activeTransactionListingByBranch;
                    }

                }
                else
                {
                    if (isReversal == true)
                    {
                        var activeTransactionListingByBranch = (from value in ibltlfDTOList
                                                                where value.TranType == tranType
                                                                select value).ToList();
                        return activeTransactionListingByBranch;
                    }
                    else
                    {
                        var activeTransactionListingByBranch = (from value in ibltlfDTOList
                                                                where value.TranType == tranType && value.Reversal == Convert.ToBoolean(0)
                                                                select value).ToList();
                        return activeTransactionListingByBranch;
                    }
                }
            }

            if (ibltlfDTOList == null || ibltlfDTOList.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // No Data for Report
                return ibltlfDTOList;
            }

            else
            { return ibltlfDTOList; }
        }
        #endregion
    }
}
