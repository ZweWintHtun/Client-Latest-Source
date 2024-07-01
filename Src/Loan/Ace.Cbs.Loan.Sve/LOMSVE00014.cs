//----------------------------------------------------------------------
// <copyright file="LOMSVE00014" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>13.01.2015</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00014 : BaseService, ILOMSVE00014
    {
        public ITLMDAO00018 LoansDAO { get; set; }

        public TLMDTO00018 isValidLoanNo(string lno, string sourceBr)
        {
            TLMDTO00018 LoanDTO = LoansDAO.GetLoansAccountInformation(lno, sourceBr);

            return LoanDTO;
        }
        
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLoansForNPLCase(string lno,string userName, string sourceBr, int updatedUserId)
        {
            try
            {
                LoansDAO.UpdateLoansForNPLCase(lno, userName, sourceBr, updatedUserId, false);
                return true;
            }
            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                return false;
                throw new Exception(ex.Message);                
            }
        }
    }
}
