//----------------------------------------------------------------------
// <copyright file="TLMSVE00048.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
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
    public class TLMSVE00048 : BaseService, ITLMSVE00048
    {
        public ICXDAO00009 ViewDAO { get; set; }

        public IList<TLMDTO00004> HomeIncomeListingByAllBranch(DateTime startDate, DateTime endDate, string sourceBr,string branchcode)
        {
            IList<TLMDTO00004> iblTLFList = this.ViewDAO.HomeIncomeListingByAllBranch(sourceBr, startDate, endDate);

            if (iblTLFList.Count > 0)
            {
                if (!string.IsNullOrEmpty(branchcode))
                {
                    var homeIncomeListingByBranch = (from value in iblTLFList
                                                     where value.ToBranch == branchcode
                                                     select value).ToList();
                    return homeIncomeListingByBranch;
                }
                else
                { return iblTLFList; }

            }
            else
            {
                return iblTLFList;
            }
          //  return iblTLFDTO;
        }

        public IList<TLMDTO00004> ActiveIncomeListingByAllBranch(DateTime startDate, DateTime endDate, string sourceBr,string branchcode)
        {
            IList<TLMDTO00004> iblTLFDTO = this.ViewDAO.ActiveIncomeListingByAllBranch(sourceBr, startDate, endDate);
            if (iblTLFDTO.Count > 0)
            {
                if (!string.IsNullOrEmpty(branchcode))
                {
                    var activeIncomeListingByBranch = (from value in iblTLFDTO
                                                       where value.ToBranch == branchcode
                                                       select value).ToList();
                    return activeIncomeListingByBranch;
                }
                else
                    return iblTLFDTO;
            }
            else
            { return iblTLFDTO; }
        }


       

       
    }
}
