//----------------------------------------------------------------------
// <copyright file="LOMSVE00032" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00032 : BaseService, ILOMSVE00032
    {
        IPFMDAO00028 CledgerDAO { get; set; }
        ICXDAO00009 ViewDAO { get; set; }
        
        public PFMDTO00028 CheckAccountNo(string accountNo, string sourceBr)
        {
            PFMDTO00028 cledgerAccount = this.CledgerDAO.SelectByAccountNoAndSourceBr(accountNo,sourceBr);
            return cledgerAccount;
        }

        public IList<LOMDTO00013> GetLegalListByAccountNo(string accountNo, string sourceBr)
        {
            IList<LOMDTO00013> LegalListByAccountNo = new List<LOMDTO00013>();
            LegalListByAccountNo = ViewDAO.GetLegalCaseListByAccountNo(accountNo, sourceBr);
            return LegalListByAccountNo;
        }
    }
}
