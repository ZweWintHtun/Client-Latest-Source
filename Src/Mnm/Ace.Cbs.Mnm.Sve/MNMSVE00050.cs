//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>01/15/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00050 : BaseService,IMNMSVE00050
    {
        IPFMDAO00040 SiDAO { get; set; }
        IMNMDAO00007 Pre_SiDAO { get; set; }

        public IList<MNMDTO00007> GetSiList(string sourceBr, string cur, string BudgetYear)
        {
            IList<PFMDTO00040> SiList = new List<PFMDTO00040>();
            IList<MNMDTO00007> Pre_SiList = new List<MNMDTO00007>();

            SiList = this.SiDAO.SelectByBudgetYear(sourceBr, cur, BudgetYear);
            Pre_SiList = this.Pre_SiDAO.SelectByBudgetYear(sourceBr, cur, BudgetYear);

            foreach (PFMDTO00040 si in SiList)
            {
                Pre_SiList.Add(this.ConvertSiDTO_To_PreSiDTO(si));
            }
            return Pre_SiList;
        }

        public MNMDTO00007 ConvertSiDTO_To_PreSiDTO(PFMDTO00040 si)
        {
            return new MNMDTO00007
            (
            si.Id,
            si.AccountNo,
            si.AccountSignature,
            si.CloseDate,
            si.Status,
            si.Budget,
            si.LastInt,
            si.AccruedInt.Value,
            si.Month1,
            si.Month2,
            si.Month3,
            si.Month4,
            si.Month5,
            si.Month6,
            si.Month7,
            si.Month8,
            si.Month9,
            si.Month10,
            si.Month11,
            si.Month12,
            si.SourceBranchCode,
            si.DATE_TIME.Value,
            si.CurrencyCode,  
            si.Active,
            si.TS,
            si.CreatedDate,
            si.CreatedUserId,
            si.UpdatedDate,
            si.UpdatedUserId
            );
        }
    }
}
